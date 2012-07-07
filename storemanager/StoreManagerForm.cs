﻿/*

Copyright Robert Vesse 2009-10
rvesse@vdesign-studios.com

------------------------------------------------------------------------

This file is part of dotNetRDF.

dotNetRDF is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

dotNetRDF is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with dotNetRDF.  If not, see <http://www.gnu.org/licenses/>.

------------------------------------------------------------------------

If this license is not suitable for your intended use please contact
us at the above stated email address to discuss alternative
terms.

*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using VDS.RDF;
using VDS.RDF.GUI;
using VDS.RDF.GUI.WinForms;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
using VDS.RDF.Storage;
using VDS.RDF.Storage.Params;
using VDS.RDF.Update;
using VDS.RDF.Writing;
using VDS.RDF.Utilities.StoreManager.Tasks;

namespace VDS.RDF.Utilities.StoreManager
{
    public partial class StoreManagerForm
        : CrossThreadForm
    {
        private IStorageProvider _manager;
        private int _taskID = 0;
        private EventHandler _copyGraphHandler, _moveGraphHandler;

        public StoreManagerForm(IStorageProvider manager)
        {
            InitializeComponent();

            //Configure Form
            this._manager = manager;
            this.Text = this._manager.ToString();

            //Configure Tasks List
            this.lvwTasks.ListViewItemSorter = new SortTasksByID();

            //Configure Graphs List
            this.lvwGraphs.ItemDrag += new ItemDragEventHandler(lvwGraphs_ItemDrag);
            this.lvwGraphs.DragEnter += new DragEventHandler(lvwGraphs_DragEnter);
            this.lvwGraphs.DragDrop += new DragEventHandler(lvwGraphs_DragDrop);
            this._copyGraphHandler = this.CopyGraphClick;
            this._moveGraphHandler = this.MoveGraphClick;
        }

        public IStorageProvider Manager
        {
            get
            {
                return this._manager;
            }
        }

        private void fclsGenericStoreManager_Load(object sender, EventArgs e)
        {
            //Determine whether SPARQL Query is supported
            if (!(this._manager is IQueryableStorage))
            {
                this.tabFunctions.TabPages.Remove(this.tabSparqlQuery);
            }

            //Determine what SPARQL Update mode if any is supported
            if (this._manager is IUpdateableStorage)
            {
                this.lblUpdateMode.Text = "Update Mode: Native";
            }
            else if (!this._manager.IsReadOnly)
            {
                this.lblUpdateMode.Text = "Update Mode: Approximated";
            }
            else
            {
                this.tabFunctions.TabPages.Remove(this.tabSparqlUpdate);
            }

            //Disable Import for Read-Only stores
            if (this._manager.IsReadOnly)
            {
                this.tabFunctions.TabPages.Remove(this.tabImport);
            }

            //Disable Server Management for non Storage Servers
            if (!(this._manager is IStorageServer))
            {
                this.tabFunctions.TabPages.Remove(this.tabServer);
            }

            //Show Connection Information
            this.propInfo.SelectedObject = new Connections.ConnectionInfo(this._manager);
        }

        #region Store Operations

        public void ListGraphs()
        {
            ListGraphsTask task = new ListGraphsTask(this._manager);
            this.AddTask<IEnumerable<Uri>>(task, this.ListGraphsCallback);
        }

        public void ListStores()
        {
            ListStoresTask task = new ListStoresTask(this._manager as IStorageServer);
            this.AddTask<IEnumerable<String>>(task, this.ListStoresCallback);
        }

        private void ViewGraph(String graphUri)
        {
            ViewGraphTask task = new ViewGraphTask(this._manager, graphUri);
            this.AddTask<IGraph>(task, this.ViewGraphCallback);
        }

        private void PreviewGraph(String graphUri)
        {
            PreviewGraphTask task = new PreviewGraphTask(this._manager, graphUri, Properties.Settings.Default.PreviewSize);
            this.AddTask<IGraph>(task, this.PreviewGraphCallback);
        }

        private void CountTriples(String graphUri)
        {
            CountTriplesTask task = new CountTriplesTask(this._manager, graphUri);
            this.AddTask<TaskValueResult<int>>(task, this.CountTriplesCallback);
        }

        private void DeleteGraph(String graphUri)
        {
            DeleteGraphTask task = new DeleteGraphTask(this._manager, graphUri);
            this.AddTask<TaskResult>(task, this.DeleteGraphCallback);
        }

        private void Query()
        {
            if (!this._manager.IsReady)
            {
                MessageBox.Show("Please wait for Store to be ready before attempting to make a SPARQL Query", "Store Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this._manager is IQueryableStorage)
            {
                if (this.chkPageQuery.Checked)
                {
                    QueryTask task = new QueryTask((IQueryableStorage)this._manager, this.txtSparqlQuery.Text, (int)this.numPageSize.Value);
                    this.AddTask<Object>(task, this.QueryCallback);
                }
                else
                {
                    QueryTask task = new QueryTask((IQueryableStorage)this._manager, this.txtSparqlQuery.Text);
                    this.AddTask<Object>(task, this.QueryCallback);
                }
            }
            else
            {
                MessageBox.Show("Unable to execute a SPARQL Query since your Store does not support SPARQL", "SPARQL Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update()
        {
            if (!this._manager.IsReady)
            {
                MessageBox.Show("Please wait for Store to be ready before attempting to make a SPARQL Update", "Store Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UpdateTask task = new UpdateTask(this._manager, this.txtSparqlUpdate.Text);
            this.AddTask<TaskResult>(task, this.UpdateCallback);
        }

        private void ImportFile()
        {
            if (!this._manager.IsReady)
            {
                MessageBox.Show("Please wait for Store to be ready before attempting to Import Data", "Store Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.txtImportFile.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a File to import from!", "No File to Import", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Uri targetUri = null;
            try
            {
                if (this.chkImportDefaultUri.Checked)
                {
                    targetUri = new Uri(this.txtImportDefaultGraph.Text);
                }
            }
            catch (UriFormatException uriEx)
            {
                MessageBox.Show("Cannot import data to an Invalid Default Target Graph URI - " + uriEx.Message, "Invalid Default Target Graph URI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ImportFileTask task = new ImportFileTask(this._manager, this.txtImportFile.Text, targetUri, (int)this.numBatchSize.Value);
            this.AddTask<TaskResult>(task, this.ImportCallback);
        }

        private void ImportUri()
        {
            if (!this._manager.IsReady)
            {
                MessageBox.Show("Please wait for Store to be ready before attempting to Import Data", "Store Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.txtImportUri.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a URI to import from!", "No URI to Import", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Uri targetUri = null;
            try
            {
                if (this.chkImportDefaultUri.Checked)
                {
                    targetUri = new Uri(this.txtImportDefaultGraph.Text);
                }
            }
            catch (UriFormatException uriEx)
            {
                MessageBox.Show("Cannot import data to an Invalid Default Target Graph URI - " + uriEx.Message, "Invalid Default Target Graph URI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ImportUriTask task = new ImportUriTask(this._manager, new Uri(this.txtImportUri.Text), targetUri, (int)this.numBatchSize.Value);
                this.AddTask<TaskResult>(task, this.ImportCallback);
            }
            catch (UriFormatException uriEx)
            {
                MessageBox.Show("Cannot import data from an invalid URI - " + uriEx.Message, "Invalid Import URI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Export()
        {
            if (!this._manager.IsReady)
            {
                MessageBox.Show("Please wait for Store to be ready before attempting to Import Data", "Store Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.txtExportFile.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a File to export to!", "No Export Destination", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExportTask task = new ExportTask(this._manager, this.txtExportFile.Text);
            this.AddTask<TaskResult>(task, this.ExportCallback);
        }

        public void CopyGraph(String graphUri, IStorageProvider target)
        {
            if (target == null) return;

            Uri source = graphUri.Equals("Default Graph") ? null : new Uri(graphUri);
            if (ReferenceEquals(this._manager, target))
            {
                CopyMoveRenameGraphForm rename = new CopyMoveRenameGraphForm("Copy");

                if (rename.ShowDialog() == DialogResult.OK)
                {
                    CopyMoveTask task = new CopyMoveTask(this._manager, target, source, rename.Uri, ReferenceEquals(this._manager, target));
                    this.AddTask(task, this.CopyMoveRenameCallback);
                }
            }
            else
            {
                CopyMoveTask task = new CopyMoveTask(this._manager, target, source, source, true);
                this.AddTask(task, this.CopyMoveRenameCallback);
            }
        }

        private void RenameGraph(String graphUri)
        {
            CopyMoveRenameGraphForm rename = new CopyMoveRenameGraphForm("Rename");
            Uri source = graphUri.Equals("Default Graph") ? null : new Uri(graphUri);
            if (rename.ShowDialog() == DialogResult.OK)
            {
                CopyMoveTask task = new CopyMoveTask(this._manager, this._manager, source, rename.Uri, false);
                this.AddTask<TaskResult>(task, this.CopyMoveRenameCallback);
            }
        }

        public void MoveGraph(String graphUri, IStorageProvider target)
        {
            if (target == null) return;

            if (ReferenceEquals(this._manager, target))
            {
                this.RenameGraph(graphUri);
            }
            else
            {
                Uri source = graphUri.Equals("Default Graph") ? null : new Uri(graphUri);
                CopyMoveTask task = new CopyMoveTask(this._manager, target, source, source, false);
                this.AddTask<TaskResult>(task, this.CopyMoveRenameCallback);
            }
        }

        #endregion

        #region Control Event Handlers

        private void btnSparqlQuery_Click(object sender, EventArgs e)
        {
            this.Query();
        }

        private void btnGraphRefresh_Click(object sender, EventArgs e)
        {
            this.ListGraphs();
        }

        private void btnRefreshStores_Click(object sender, EventArgs e)
        {
            this.ListStores();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.ofdImport.Filter = MimeTypesHelper.GetFilenameFilter(true, true, false, false, false, false);
            if (this.ofdImport.ShowDialog() == DialogResult.OK)
            {
                this.txtImportFile.Text = this.ofdImport.FileName;
            }
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            this.ImportFile();
        }

        private void btnImportUri_Click(object sender, EventArgs e)
        {
            this.ImportUri();
        }

        private void lvwGraphs_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.lvwGraphs.SelectedItems.Count > 0)
            {
                String graphUri = this.lvwGraphs.SelectedItems[0].Text;
                if (graphUri.Equals("Default Graph")) graphUri = null;

                this.ViewGraph(graphUri);
            }
        }

        void lvwGraphs_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.lvwGraphs.SelectedItems.Count > 0)
            {
                String graphUri = this.lvwGraphs.SelectedItems[0].Text;
                CopyMoveDragInfo info = new CopyMoveDragInfo(this, graphUri);
                DragDropEffects effects = DragDropEffects.Copy;
                if (this._manager.DeleteSupported) effects = effects | DragDropEffects.Move; //Move only possible if this manager supports DeleteGraph()

                this.lvwGraphs.DoDragDrop(info, effects);
            }
        }

        void lvwGraphs_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & DragDropEffects.Copy) != 0 || (e.AllowedEffect & DragDropEffects.Move) != 0)
            {
                if (e.Data.GetDataPresent(typeof(CopyMoveDragInfo)))
                {
                    //Cannot Copy/Move if a read-only manager is the target
                    if (this._manager.IsReadOnly) return;

                    CopyMoveDragInfo info = e.Data.GetData(typeof(CopyMoveDragInfo)) as CopyMoveDragInfo;
                    if (info == null) return;

                    DragDropEffects effects = DragDropEffects.Copy;
                    if (info.Source.DeleteSupported) effects = effects | DragDropEffects.Move; //Move only possible if the source manager supports DeleteGraph()
                    e.Effect = effects;
                }
            }
        }

        void lvwGraphs_DragDrop(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & DragDropEffects.Copy) != 0 || (e.AllowedEffect & DragDropEffects.Move) != 0)
            {
                if (e.Data.GetDataPresent(typeof(CopyMoveDragInfo)))
                {
                    CopyMoveDragInfo info = e.Data.GetData(typeof(CopyMoveDragInfo)) as CopyMoveDragInfo;
                    if (info == null) return;

                    //Check whether Move is permitted?
                    if ((e.Effect & DragDropEffects.Move) != 0)
                    {
                        CopyMoveDialogue copyMoveConfirm = new CopyMoveDialogue(info, this._manager);
                        if (copyMoveConfirm.ShowDialog() == DialogResult.OK)
                        {
                            if (copyMoveConfirm.IsMove)
                            {
                                info.Form.MoveGraph(info.SourceUri, this._manager);
                            }
                            else if (copyMoveConfirm.IsCopy)
                            {
                                info.Form.CopyGraph(info.SourceUri, this._manager);
                            }
                        }
                    }
                    else
                    {
                        //Just do a Copy
                        info.Form.CopyGraph(info.SourceUri, this._manager);
                    }
                }
            }
        }

        private void timStartup_Tick(object sender, EventArgs e)
        {
            if (this._manager.IsReady)
            {
                this.stsCurrent.Text = "Store is ready";
                this.ListGraphs();
                this.ListStores();
                this.timStartup.Stop();
            }
        }

        private void btnSaveQuery_Click(object sender, EventArgs e)
        {
            this.sfdQuery.Filter = MimeTypesHelper.GetFilenameFilter(false, false, false, true, false, true);
            if (this.sfdQuery.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(this.sfdQuery.FileName))
                {
                    writer.Write(this.txtSparqlQuery.Text);
                }
            }
        }

        private void btnLoadQuery_Click(object sender, EventArgs e)
        {
            this.ofdQuery.Filter = MimeTypesHelper.GetFilenameFilter(false, false, false, true, false, true);
            if (this.ofdQuery.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(this.ofdQuery.FileName))
                {
                    this.txtSparqlQuery.Text = reader.ReadToEnd();
                }
            }
        }

        private void btnSparqlUpdate_Click(object sender, EventArgs e)
        {
            this.Update();
        }

        private void chkImportDefaultUri_CheckedChanged(object sender, EventArgs e)
        {
            this.txtImportDefaultGraph.Enabled = this.chkImportDefaultUri.Checked;
        }

        private void btnBrowseExport_Click(object sender, EventArgs e)
        {
            this.sfdExport.Filter = MimeTypesHelper.GetFilenameFilter(false, true, false, false, false, false);
            if (this.sfdExport.ShowDialog() == DialogResult.OK)
            {
                this.txtExportFile.Text = this.sfdExport.FileName;
            }
        }

        private void btnExportStore_Click(object sender, EventArgs e)
        {
            this.Export();
        }

        #region Graphs Context Menu

        private void mnuGraphs_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.lvwGraphs.SelectedItems.Count > 0)
            {
                this.mnuDeleteGraph.Enabled = this._manager.DeleteSupported;
                this.mnuPreviewGraph.Text = String.Format("Preview first {0} Triples", Properties.Settings.Default.PreviewSize);
                this.mnuMoveGraphTo.Enabled = this._manager.DeleteSupported;
                this.mnuCopyGraph.Enabled = !this._manager.IsReadOnly;
                this.mnuRenameGraph.Enabled = !this._manager.IsReadOnly && this._manager.DeleteSupported;

                //Fill Copy To and Move To menus
                while (this.mnuCopyGraphTo.DropDownItems.Count > 2)
                {
                    this.mnuCopyGraphTo.DropDownItems.RemoveAt(2);
                }
                while (this.mnuMoveGraphTo.DropDownItems.Count > 2)
                {
                    this.mnuMoveGraphTo.DropDownItems.RemoveAt(2);
                }
                foreach (IStorageProvider manager in Program.ActiveConnections)
                {
                    if (!ReferenceEquals(manager, this._manager) && !manager.IsReadOnly)
                    {
                        //Copy To entry
                        ToolStripMenuItem item = new ToolStripMenuItem(manager.ToString());
                        item.Tag = manager;
                        item.Click += this._copyGraphHandler;
                        this.mnuCopyGraphTo.DropDownItems.Add(item);

                        //Move To entry
                        item = new ToolStripMenuItem(manager.ToString());
                        item.Tag = manager;
                        item.Click += this._moveGraphHandler;
                        this.mnuMoveGraphTo.DropDownItems.Add(item);
                    }
                }
                if (mnuCopyGraphTo.DropDownItems.Count == 2 && this._manager.IsReadOnly)
                {
                    this.mnuCopyGraphTo.Enabled = false;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void mnuViewGraph_Click(object sender, EventArgs e)
        {
            if (this.lvwGraphs.SelectedItems.Count > 0)
            {
                String graphUri = this.lvwGraphs.SelectedItems[0].Text;
                if (graphUri.Equals("Default Graph")) graphUri = null;

                this.ViewGraph(graphUri);
            }
        }

        private void mnuDeleteGraph_Click(object sender, EventArgs e)
        {
            if (this.lvwGraphs.SelectedItems.Count > 0)
            {
                String graphUri = this.lvwGraphs.SelectedItems[0].Text;
                if (graphUri.Equals("Default Graph")) graphUri = null;

                this.DeleteGraph(graphUri);
            }
        }

        private void mnuPreviewGraph_Click(object sender, EventArgs e)
        {
            if (this.lvwGraphs.Items.Count > 0)
            {
                String graphUri = this.lvwGraphs.SelectedItems[0].Text;
                if (graphUri.Equals("Default Graph")) graphUri = null;

                this.PreviewGraph(graphUri);
            }
        }

        private void mnuCountTriples_Click(object sender, EventArgs e)
        {
            if (this.lvwGraphs.Items.Count > 0)
            {
                String graphUri = this.lvwGraphs.SelectedItems[0].Text;
                if (graphUri.Equals("Default Graph")) graphUri = null;

                this.CountTriples(graphUri);
            }
        }

        private void mnuCopyGraph_Click(object sender, EventArgs e)
        {
            if (this.lvwGraphs.SelectedItems.Count > 0)
            {
                String graphUri = this.lvwGraphs.SelectedItems[0].Text;
                this.CopyGraph(graphUri, this._manager);
            }
        }

        private void mnuRenameGraph_Click(object sender, EventArgs e)
        {
            if (this.lvwGraphs.SelectedItems.Count > 0)
            {
                String graphUri = this.lvwGraphs.SelectedItems[0].Text;
                this.RenameGraph(graphUri);
            }
        }

        private void CopyGraphClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null) return;
            if (item.Tag is IStorageProvider)
            {
                if (this.lvwGraphs.SelectedItems.Count > 0)
                {
                    String graphUri = this.lvwGraphs.SelectedItems[0].Text;
                    this.CopyGraph(graphUri, item.Tag as IStorageProvider);
                }
            }
        }

        private void MoveGraphClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null) return;
            if (item.Tag is IStorageProvider)
            {
                if (this.lvwGraphs.SelectedItems.Count > 0)
                {
                    String graphUri = this.lvwGraphs.SelectedItems[0].Text;
                    this.MoveGraph(graphUri, item.Tag as IStorageProvider);
                }
            }
        }

        #endregion

        #region Tasks Context Menu

        private void mnuTasks_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.lvwTasks.SelectedItems.Count > 0)
            {
                ListViewItem item = this.lvwTasks.SelectedItems[0];
                Object tag = item.Tag;
                if (tag != null)
                {
                    if (tag is QueryTask)
                    {
                        QueryTask qTask = (QueryTask)tag;
                        this.mnuViewErrors.Enabled = qTask.Error != null;
                        this.mnuViewResults.Enabled = (qTask.State == TaskState.Completed && qTask.Result != null);
                        this.mnuCancel.Enabled = qTask.IsCancellable;
                    }
                    else if (tag is BaseImportTask)
                    {
                        BaseImportTask importTask = (BaseImportTask)tag;
                        this.mnuViewErrors.Enabled = importTask.Error != null;
                        this.mnuViewResults.Enabled = false;
                        this.mnuCancel.Enabled = importTask.IsCancellable;
                    }
                    else if (tag is ListGraphsTask)
                    {
                        ListGraphsTask graphsTask = (ListGraphsTask)tag;
                        this.mnuViewErrors.Enabled = graphsTask.Error != null;
                        this.mnuViewResults.Enabled = false;
                        this.mnuCancel.Enabled = graphsTask.IsCancellable;
                    }
                    else if (tag is CountTriplesTask)
                    {
                        CountTriplesTask countTask = (CountTriplesTask)tag;
                        this.mnuViewErrors.Enabled = countTask.Error != null;
                        this.mnuViewResults.Enabled = false;
                        this.mnuCancel.Enabled = countTask.IsCancellable;
                    }
                    else if (tag is ITask<IGraph>)
                    {
                        ITask<IGraph> graphTask = (ITask<IGraph>)tag;
                        this.mnuViewErrors.Enabled = graphTask.Error != null;
                        this.mnuViewResults.Enabled = (graphTask.State == TaskState.Completed && graphTask.Result != null);
                        this.mnuCancel.Enabled = graphTask.IsCancellable;
                    }
                    else if (tag is ITask<TaskResult>)
                    {
                        ITask<TaskResult> basicTask = (ITask<TaskResult>)tag;
                        this.mnuViewErrors.Enabled = basicTask.Error != null;
                        this.mnuViewResults.Enabled = false;
                        this.mnuCancel.Enabled = basicTask.IsCancellable;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            if (this.lvwTasks.SelectedItems.Count > 0)
            {
                ListViewItem item = this.lvwTasks.SelectedItems[0];
                Object tag = item.Tag;

                if (tag is CancellableTask<TaskResult>)
                {
                    ((CancellableTask<TaskResult>)tag).Cancel();
                }
            }
        }

        private void mnuViewDetail_Click(object sender, EventArgs e)
        {
            if (this.lvwTasks.SelectedItems.Count > 0)
            {
                ListViewItem item = this.lvwTasks.SelectedItems[0];
                Object tag = item.Tag;

                if (tag is QueryTask)
                {
                    TaskInformationForm<Object> queryInfo = new TaskInformationForm<object>((QueryTask)tag, this._manager.ToString());
                    queryInfo.MdiParent = this.MdiParent;
                    queryInfo.Show();
                }
                else if (tag is UpdateTask)
                {
                    TaskInformationForm<TaskResult> updateInfo = new TaskInformationForm<TaskResult>((UpdateTask)tag, this._manager.ToString());
                    updateInfo.MdiParent = this.MdiParent;
                    updateInfo.Show();
                }
                else if (tag is ListGraphsTask)
                {
                    TaskInformationForm<IEnumerable<Uri>> listInfo = new TaskInformationForm<IEnumerable<Uri>>((ListGraphsTask)tag, this._manager.ToString());
                    listInfo.MdiParent = this.MdiParent;
                    listInfo.Show();
                }
                else if (tag is CountTriplesTask)
                {
                    TaskInformationForm<TaskValueResult<int>> countInfo = new TaskInformationForm<TaskValueResult<int>>((CountTriplesTask)tag, this._manager.ToString());
                    countInfo.MdiParent = this.MdiParent;
                    countInfo.Show();
                }
                else if (tag is ITask<IGraph>)
                {
                    TaskInformationForm<IGraph> graphInfo = new TaskInformationForm<IGraph>((ITask<IGraph>)tag, this._manager.ToString());
                    graphInfo.MdiParent = this.MdiParent;
                    graphInfo.Show();
                }
                else if (tag is ITask<TaskResult>)
                {
                    TaskInformationForm<TaskResult> simpleInfo = new TaskInformationForm<TaskResult>((ITask<TaskResult>)tag, this._manager.ToString());
                    simpleInfo.MdiParent = this.MdiParent;
                    simpleInfo.Show();
                }
                else
                {
                    MessageBox.Show("Task Information cannot be shown as the Task type is unknown", "Task Information Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void mnuViewErrors_Click(object sender, EventArgs e)
        {
            if (this.lvwTasks.SelectedItems.Count > 0)
            {
                ListViewItem item = this.lvwTasks.SelectedItems[0];
                Object tag = item.Tag;

                if (tag is QueryTask)
                {
                    TaskErrorTraceForm<Object> queryInfo = new TaskErrorTraceForm<object>((ITask<Object>)tag, this._manager.ToString());
                    queryInfo.MdiParent = this.MdiParent;
                    queryInfo.Show();
                }
                else if (tag is ListGraphsTask)
                {
                    TaskErrorTraceForm<IEnumerable<Uri>> listInfo = new TaskErrorTraceForm<IEnumerable<Uri>>((ITask<IEnumerable<Uri>>)tag, this._manager.ToString());
                    listInfo.MdiParent = this.MdiParent;
                    listInfo.Show();
                }
                else if (tag is ITask<IGraph>)
                {
                    TaskErrorTraceForm<IGraph> graphInfo = new TaskErrorTraceForm<IGraph>((ITask<IGraph>)tag, this._manager.ToString());
                    graphInfo.MdiParent = this.MdiParent;
                    graphInfo.Show();
                }
                else if (tag is ITask<TaskResult>)
                {
                    TaskErrorTraceForm<TaskResult> simpleInfo = new TaskErrorTraceForm<TaskResult>((ITask<TaskResult>)tag, this._manager.ToString());
                    simpleInfo.MdiParent = this.MdiParent;
                    simpleInfo.Show();
                }
                else
                {
                    MessageBox.Show("Task Information cannot be shown as the Task type is unknown", "Task Information Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void mnuViewResults_Click(object sender, EventArgs e)
        {
            if (this.lvwTasks.SelectedItems.Count > 0)
            {
                ListViewItem item = this.lvwTasks.SelectedItems[0];
                Object tag = item.Tag;

                if (tag is QueryTask)
                {
                    QueryTask qTask = (QueryTask)tag;
                    if (qTask.State == TaskState.Completed && qTask.Result != null)
                    {
                        Object result = qTask.Result;

                        if (result is IGraph)
                        {
                            GraphViewerForm graphViewer = new GraphViewerForm((IGraph)result, this._manager.ToString());
                            CrossThreadSetMdiParent(graphViewer);
                            CrossThreadShow(graphViewer);
                        }
                        else if (result is SparqlResultSet)
                        {
                            ResultSetViewerForm resultsViewer = new ResultSetViewerForm((SparqlResultSet)result, this._manager.ToString(), qTask.Query.NamespaceMap);
                            CrossThreadSetMdiParent(resultsViewer);
                            CrossThreadShow(resultsViewer);
                        }
                        else
                        {
                            CrossThreadMessage("Unable to show Query Results as did not get a Graph/Result Set as expected", "Unable to Show Results", MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Query Results are unavailable", "Results Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (tag is ITask<IGraph>)
                {
                    ITask<IGraph> graphTask = (ITask<IGraph>)tag;
                    if (graphTask.Result != null)
                    {
                        GraphViewerForm graphViewer = new GraphViewerForm(graphTask.Result, this._manager.ToString());
                        CrossThreadSetMdiParent(graphViewer);
                        CrossThreadShow(graphViewer);
                    }
                    else
                    {
                        CrossThreadMessage("Unable to show Graph as there is no Graph as expected", "Unable to Show Graph", MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #endregion

        #region Task Management

        private void AddTask<T>(ITask<T> task, TaskCallback<T> callback) where T : class
        {
            String[] items = new String[]
            {
                (++this._taskID).ToString(),
                task.Name,
                task.State.GetStateDescription(),
                task.Information
            };
            ListViewItem item = new ListViewItem(items);
            item.Tag = task;
            CrossThreadAddItem(this.lvwTasks, item);

            //Ensure that the Task Information gets updated automatically when the Task State changes
            TaskStateChanged d = delegate()
            {
                CrossThreadAlterSubItem(item, 2, task.State.GetStateDescription());
                CrossThreadAlterSubItem(item, 3, task.Information);
                CrossThreadRefresh(this.lvwTasks);
            };
            task.StateChanged += d;

            //Clear old Tasks if necessary and enabled
            if (this.chkRemoveOldTasks.Checked)
            {
                if (this.lvwTasks.Items.Count > 10)
                {
                    int i = this.lvwTasks.Items.Count - 1;
                    do
                    {
                        ListViewItem oldItem = this.lvwTasks.Items[i];
                        if (oldItem.Tag is ITaskBase)
                        {
                            ITaskBase t = (ITaskBase)oldItem.Tag;
                            if (t.State == TaskState.Completed || t.State == TaskState.CompletedWithErrors)
                            {
                                this.lvwTasks.Items.RemoveAt(i);
                                i--;
                            }
                        }

                        i--;
                    } while (this.lvwTasks.Items.Count > 10 && i >= 0);
                }
            }

            //Start the Task
            task.RunTask(callback);
        }

        private void ListGraphsCallback(ITask<IEnumerable<Uri>> task)
        {
            if (task.State == TaskState.Completed && task.Result != null)
            {
                this.CrossThreadSetText(this.stsCurrent, "Rendering Graph List...");
                this.CrossThreadSetVisibility(this.lvwGraphs, true);
                this.CrossThreadBeginUpdate(this.lvwGraphs);
                this.CrossThreadClear(this.lvwGraphs);

                foreach (Uri u in task.Result)
                {
                    if (u != null)
                    {
                        this.CrossThreadAdd(this.lvwGraphs, u.ToString());
                    }
                    else
                    {
                        this.CrossThreadAdd(this.lvwGraphs, "Default Graph");
                    }
                }

                this.CrossThreadEndUpdate(this.lvwGraphs);

                this.CrossThreadSetText(this.stsCurrent, "Store is ready");
                this.CrossThreadSetEnabled(this.btnGraphRefresh, true);

                task.Information = this.lvwGraphs.Items.Count + " Graph URI(s) were returned";
            }
            else
            {
                this.CrossThreadSetText(this.stsCurrent, "Graph Listing unavailable - Store is ready");
                if (task.Error != null)
                {
                    CrossThreadMessage("Unable to list Graphs due to the following error:\n" + task.Error.Message, "Graph List Unavailable", MessageBoxIcon.Warning);
                }
                this.CrossThreadSetVisibility(this.lvwGraphs, false);
                this.CrossThreadSetVisibility(this.lblGraphListUnavailable, true);
                this.CrossThreadRefresh(this.tabGraphs);
            }
        }

        private void ListStoresCallback(ITask<IEnumerable<String>> task)
        {
            if (task.State == TaskState.Completed && task.Result != null)
            {
                this.CrossThreadSetText(this.stsCurrent, "Rendering Store List...");
                this.CrossThreadSetVisibility(this.lvwStores, true);
                this.CrossThreadBeginUpdate(this.lvwStores);
                this.CrossThreadClear(this.lvwStores);

                foreach (String id in task.Result)
                {
                    if (id != null)
                    {
                        this.CrossThreadAdd(this.lvwStores, id);
                    }
                }

                this.CrossThreadEndUpdate(this.lvwStores);

                this.CrossThreadSetText(this.stsCurrent, "Store is ready");
                this.CrossThreadSetEnabled(this.btnRefreshStores, true);

                task.Information = this.lvwStores.Items.Count + " Store IDs were returned";
            }
            else
            {
                this.CrossThreadSetText(this.stsCurrent, "Store Listing unavailable - Store is ready");
                if (task.Error != null)
                {
                    CrossThreadMessage("Unable to list Stores due to the following error:\n" + task.Error.Message, "Store List Unavailable", MessageBoxIcon.Warning);
                }
                this.CrossThreadSetVisibility(this.lvwStores, false);
                this.CrossThreadSetVisibility(this.lblStoreListUnavailable, true);
                this.CrossThreadRefresh(this.tabServer);
            }
        }

        private void ViewGraphCallback(ITask<IGraph> task)
        {
            if (task.State == TaskState.Completed && task.Result != null)
            {
                GraphViewerForm graphViewer = new GraphViewerForm(task.Result, this._manager.ToString());
                CrossThreadSetMdiParent(graphViewer);
                CrossThreadShow(graphViewer);
            }
            else
            {
                if (task.Error != null)
                {
                    CrossThreadMessage("View Graph Failed due to the following error: " + task.Error.Message, "View Graph Failed", MessageBoxIcon.Error);
                }
                else
                {
                    CrossThreadMessage("View Graph Failed due to an unknown error", "View Graph Failed", MessageBoxIcon.Error);
                }
            }
        }

        private void PreviewGraphCallback(ITask<IGraph> task)
        {
            if (task.State == TaskState.Completed && task.Result != null)
            {
                GraphViewerForm graphViewer = new GraphViewerForm(task.Result, this._manager.ToString());
                CrossThreadSetMdiParent(graphViewer);
                CrossThreadShow(graphViewer);
            }
            else
            {
                if (task.Error != null)
                {
                    CrossThreadMessage("Preview Graph Failed due to the following error: " + task.Error.Message, "Preview Graph Failed", MessageBoxIcon.Error);
                }
                else
                {
                    CrossThreadMessage("Preview Graph Failed due to an unknown error", "Preview Graph Failed", MessageBoxIcon.Error);
                }
            }
        }

        private void CountTriplesCallback(ITask<TaskValueResult<int>> task)
        {
            if (task.State == TaskState.Completed && task.Result != null)
            {
                MessageBox.Show(task.Information, "Triples Counted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (task.Error != null)
                {
                    CrossThreadMessage("Count Triples Failed due to the following error: " + task.Error.Message, "Count Triples Failed", MessageBoxIcon.Error);
                }
                else
                {
                    CrossThreadMessage("Count Triples Failed due to an unknown error", "Count Triples Failed", MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteGraphCallback(ITask<TaskResult> task)
        {
            if (task.State == TaskState.Completed)
            {
                CrossThreadMessage(task.Information, "Deleted Graph OK", MessageBoxIcon.Information);
                ListGraphs();
            }
            else
            {
                if (task.Error != null)
                {
                    CrossThreadMessage("Delete Graph Failed due to the following error: " + task.Error.Message, "Delete Graph Failed", MessageBoxIcon.Error);
                }
                else
                {
                    CrossThreadMessage("Delete Graph Failed due to an unknown error", "Delete Graph Failed", MessageBoxIcon.Error);
                }
            }
        }

        private void QueryCallback(ITask<Object> task)
        {
            QueryTask qTask = null;
            if (task is QueryTask)
            {
                qTask = (QueryTask)task;
                if (qTask.Query != null)
                {
                    try
                    {
                        if (task.State == TaskState.Completed)
                        {
                            this.CrossThreadSetText(this.stsCurrent, "Query Completed OK (Took " + qTask.Query.QueryExecutionTime.Value.ToString() + ")");
                        }
                        else
                        {
                            this.CrossThreadSetText(this.stsCurrent, "Query Failed (Took " + qTask.Query.QueryExecutionTime.Value.ToString() + ")");
                        }
                    }
                    catch
                    {
                        //Ignore Exceptions in reporting Execution Time
                    }
                }
            }
            else
            {
                CrossThreadMessage("Unexpected Error - QueryCallback was invoked but the given task was not a QueryTask", "Unexpected Error", MessageBoxIcon.Exclamation);
                return;
            }

            if (task.State == TaskState.Completed)
            {
                Object result = task.Result;

                if (result is IGraph)
                {
                    GraphViewerForm graphViewer = new GraphViewerForm((IGraph)result, this._manager.ToString());
                    CrossThreadSetMdiParent(graphViewer);
                    CrossThreadShow(graphViewer);
                }
                else if (result is SparqlResultSet)
                {
                    ResultSetViewerForm resultsViewer = new ResultSetViewerForm((SparqlResultSet)result, this._manager.ToString(), qTask.Query.NamespaceMap);
                    CrossThreadSetMdiParent(resultsViewer);
                    CrossThreadShow(resultsViewer);
                }
                else
                {
                    CrossThreadMessage("Unable to show Query Results as did not get a Graph/Result Set as expected", "Unable to Show Results", MessageBoxIcon.Error);
                }
            }
            else
            {
                if (task.Error != null)
                {
                    CrossThreadMessage("Query Failed due to the following error: " + task.Error.Message, "Query Failed", MessageBoxIcon.Error);
                }
                else
                {
                    CrossThreadMessage("Query Failed due to an unknown error", "Query Failed", MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateCallback(ITask<TaskResult> task)
        {
            if (task is UpdateTask)
            {
                UpdateTask uTask = (UpdateTask)task;
                if (uTask.Updates != null)
                {
                    try
                    {
                        if (task.State == TaskState.Completed)
                        {
                            this.CrossThreadSetText(this.stsCurrent, "Updates Completed OK (Took " + uTask.Updates.UpdateExecutionTime.Value.ToString() + ")");
                        }
                        else
                        {
                            this.CrossThreadSetText(this.stsCurrent, "Updates Failed (Took " + uTask.Updates.UpdateExecutionTime.Value.ToString() + ")");
                        }
                    }
                    catch
                    {
                        //Ignore Exceptions in reporting Execution Time
                    }
                }
            }

            if (task.State == TaskState.Completed)
            {
                CrossThreadMessage("Updates Completed successfully", "Updates Completed", MessageBoxIcon.Information);
            }
            else
            {
                if (task.Error != null)
                {
                    CrossThreadMessage("Updates Failed due to the following error: " + task.Error.Message, "Updates Failed", MessageBoxIcon.Error);
                }
                else
                {
                    CrossThreadMessage("Updates Failed due to an unknown error", "Updates Failed", MessageBoxIcon.Error);
                }
            }
        }

        private void ImportCallback(ITask<TaskResult> task)
        {
            if (task.State == TaskState.Completed)
            {
                CrossThreadMessage("Import Completed OK\n" + task.Information, "Import Completed", MessageBoxIcon.Information);
            }
            else
            {
                if (task.Error != null)
                {
                    CrossThreadMessage("Import Failed due to the following error: " + task.Error.Message, "Import Failed", MessageBoxIcon.Error);
                }
                else
                {
                    CrossThreadMessage("Import Failed due to an unknown error", "Import Failed", MessageBoxIcon.Error);
                }
            }
            this.ListGraphs();
        }

        private void ExportCallback(ITask<TaskResult> task)
        {
            if (task.State == TaskState.Completed)
            {
                CrossThreadMessage("Export Completed OK - " + task.Information, "Export Completed", MessageBoxIcon.Information);
            }
            else
            {
                if (task.Error != null)
                {
                    CrossThreadMessage("Export Failed due to the following error: " + task.Error.Message, "Export Failed", MessageBoxIcon.Error);
                }
                else
                {
                    CrossThreadMessage("Export Failed due to an unknown error", "Export Failed", MessageBoxIcon.Error);
                }
            }
        }

        private void CopyMoveRenameCallback(ITask<TaskResult> task)
        {
            if (task.State == TaskState.Completed)
            {
                CrossThreadMessage(task.Name + " Completed OK - " + task.Information, task.Name + " Completed", MessageBoxIcon.Information);
                this.ListGraphs();

                if (task is CopyMoveTask)
                {
                    CopyMoveTask cmTask = (CopyMoveTask)task;
                    if (!ReferenceEquals(this._manager, cmTask.Target))
                    {
                        foreach (StoreManagerForm managerForm in Program.MainForm.MdiChildren.OfType<StoreManagerForm>())
                        {
                            if (!ReferenceEquals(this, managerForm) && ReferenceEquals(cmTask.Target, managerForm.Manager))
                            {
                                managerForm.ListGraphs();
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                if (task.Error != null)
                {
                    CrossThreadMessage(task.Name + " Failed due to the following error: " + task.Error.Message, task.Name + " Failed", MessageBoxIcon.Error);
                }
                else
                {
                    CrossThreadMessage(task.Name + " Failed due to an unknown error", task.Name + " Failed", MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        protected override void OnClosed(EventArgs e)
        {
            this._manager.Dispose();
        }
    }

    class SortTasksByID : IComparer, IComparer<ListViewItem>
    {

        public int Compare(ListViewItem x, ListViewItem y)
        {
            int a, b;
            if (Int32.TryParse(x.SubItems[0].Text, out a))
            {
                if (Int32.TryParse(y.SubItems[0].Text, out b))
                {
                    return -1 * a.CompareTo(b);
                }
                else
                {
                    return 1;
                }
            } 
            else
            {
                return -1;
            }
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {
            if (x is ListViewItem && y is ListViewItem)
            {
                return this.Compare((ListViewItem)x, (ListViewItem)y);
            }
            else
            {
                return 0;
            }
        }

        #endregion
    }
}
