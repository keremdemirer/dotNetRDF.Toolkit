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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    public partial class fclsGenericStoreManager : CrossThreadForm
    {
        private IGenericIOManager _manager;
        private int _taskID = 0;

        public fclsGenericStoreManager(IGenericIOManager manager)
        {
            InitializeComponent();

            this._manager = manager;
            this.Text = this._manager.ToString();
        }

        public IGenericIOManager Manager
        {
            get
            {
                return this._manager;
            }
        }

        private void fclsGenericStoreManager_Load(object sender, EventArgs e)
        {
            //Determine whether SPARQL Query is supported
            if (!(this._manager is IQueryableGenericIOManager))
            {
                this.tabFunctions.TabPages.Remove(this.tabSparqlQuery);
            }

            //Determine what SPARQL Update mode if any is supported
            if (this._manager is IUpdateableGenericIOManager)
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
                this.grpImport.Enabled = false;
            }
        }

        #region Store Operations

        private void ListGraphs()
        {
            ListGraphsTask task = new ListGraphsTask(this._manager);
            this.AddTask<IEnumerable<Uri>>(task, this.ListGraphsCallback);
        }

        private void Query()
        {
            if (!this._manager.IsReady)
            {
                MessageBox.Show("Please wait for Store to be ready before attempting to make a SPARQL Query", "Store Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this._manager is IQueryableGenericIOManager)
            {
                QueryTask task = new QueryTask((IQueryableGenericIOManager)this._manager, this.txtSparqlQuery.Text);
                this.AddTask<Object>(task, this.QueryCallback);
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

            ImportFileTask task = new ImportFileTask(this._manager, this.txtImportFile.Text, targetUri);
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
                ImportUriTask task = new ImportUriTask(this._manager, new Uri(this.txtImportUri.Text), targetUri);
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.ofdImport.Filter = Constants.RdfOrDatasetFilter;
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
                if (graphUri.Equals("Default Graph")) graphUri = String.Empty;
                Graph g = new Graph();
                this._manager.LoadGraph(g, graphUri);
                if (!graphUri.Equals(String.Empty))
                {
                    g.BaseUri = new Uri(graphUri);
                }
                GraphViewerForm graphViewer = new GraphViewerForm(g, this._manager.ToString());
                graphViewer.MdiParent = this.MdiParent;
                graphViewer.Show();
            }
        }

        private void timStartup_Tick(object sender, EventArgs e)
        {
            if (this._manager.IsReady)
            {
                this.stsCurrent.Text = "Store is ready";
                this.ListGraphs();
                this.timStartup.Stop();
            }
        }

        private void btnSaveQuery_Click(object sender, EventArgs e)
        {
            this.sfdQuery.Filter = Constants.SparqlQueryFilter;
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
            this.ofdQuery.Filter = Constants.SparqlQueryFilter;
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
            this.sfdExport.Filter = Constants.RdfDatasetFilter;
            if (this.sfdExport.ShowDialog() == DialogResult.OK)
            {
                this.txtExportFile.Text = this.sfdExport.FileName;
            }
        }

        private void btnExportStore_Click(object sender, EventArgs e)
        {
            this.Export();
        }

        #region Context Menu

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
                        this.mnuCancel.Enabled = (importTask.IsCancellable && importTask.State != TaskState.Completed && importTask.State != TaskState.CompletedWithErrors);
                    }
                    else if (tag is ListGraphsTask)
                    {
                        ListGraphsTask graphsTask = (ListGraphsTask)tag;
                        this.mnuViewErrors.Enabled = graphsTask.Error != null;
                        this.mnuViewResults.Enabled = false;
                        this.mnuCancel.Enabled = graphsTask.IsCancellable;
                    }
                    else if (tag is ITask<TaskResult>)
                    {
                        ITask<TaskResult> basicTask = (ITask<TaskResult>)tag;
                        this.mnuViewErrors.Enabled = basicTask.Error != null;
                        this.mnuViewResults.Enabled = false;
                        this.mnuCancel.Enabled = (basicTask.IsCancellable && basicTask.State != TaskState.Completed && basicTask.State != TaskState.CompletedWithErrors);
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
                    fclsTaskInformation<Object> queryInfo = new fclsTaskInformation<object>((QueryTask)tag, this._manager.ToString());
                    queryInfo.MdiParent = this.MdiParent;
                    queryInfo.Show();
                }
                else if (tag is UpdateTask)
                {
                    fclsTaskInformation<TaskResult> updateInfo = new fclsTaskInformation<TaskResult>((UpdateTask)tag, this._manager.ToString());
                    updateInfo.MdiParent = this.MdiParent;
                    updateInfo.Show();
                }
                else if (tag is ListGraphsTask)
                {
                    fclsTaskInformation<IEnumerable<Uri>> listInfo = new fclsTaskInformation<IEnumerable<Uri>>((ListGraphsTask)tag, this._manager.ToString());
                    listInfo.MdiParent = this.MdiParent;
                    listInfo.Show();
                }
                else if (tag is ITask<TaskResult>)
                {
                    fclsTaskInformation<TaskResult> simpleInfo = new fclsTaskInformation<TaskResult>((ITask<TaskResult>)tag, this._manager.ToString());
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
                    fclsTaskErrorTrace<Object> queryInfo = new fclsTaskErrorTrace<object>((ITask<Object>)tag, this._manager.ToString());
                    queryInfo.MdiParent = this.MdiParent;
                    queryInfo.Show();
                }
                else if (tag is ListGraphsTask)
                {
                    fclsTaskErrorTrace<IEnumerable<Uri>> listInfo = new fclsTaskErrorTrace<IEnumerable<Uri>>((ITask<IEnumerable<Uri>>)tag, this._manager.ToString());
                    listInfo.MdiParent = this.MdiParent;
                    listInfo.Show();
                }
                else if (tag is ITask<TaskResult>)
                {
                    fclsTaskErrorTrace<TaskResult> simpleInfo = new fclsTaskErrorTrace<TaskResult>((ITask<TaskResult>)tag, this._manager.ToString());
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
                            GraphViewerForm graphViewer = new GraphViewerForm((IGraph)result);
                            CrossThreadSetMdiParent(graphViewer);
                            CrossThreadShow(graphViewer);
                        }
                        else if (result is SparqlResultSet)
                        {
                            ResultSetViewerForm resultsViewer = new ResultSetViewerForm((SparqlResultSet)result);
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

        private void QueryCallback(ITask<Object> task)
        {
            if (task is QueryTask)
            {
                QueryTask qTask = (QueryTask)task;
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
                    ResultSetViewerForm resultsViewer = new ResultSetViewerForm((SparqlResultSet)result, this._manager.ToString());
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
                CrossThreadMessage("Import Completed OK - " + task.Information, "Import Completed", MessageBoxIcon.Information);
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

        #endregion

    }
}
