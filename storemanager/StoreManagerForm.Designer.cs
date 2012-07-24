/*

Copyright dotNetRDF Project 2009-12
dotnetrdf-develop@lists.sf.net

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

dotNetRDF may alternatively be used under the LGPL or MIT License

http://www.gnu.org/licenses/lgpl.html
http://www.opensource.org/licenses/mit-license.php

If these licenses are not suitable for your intended use please contact
us at the above stated email address to discuss alternative
terms.

*/

namespace VDS.RDF.Utilities.StoreManager
{
    partial class StoreManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreManagerForm));
            this.tabFunctions = new System.Windows.Forms.TabControl();
            this.tabGraphs = new System.Windows.Forms.TabPage();
            this.lblGraphListUnavailable = new System.Windows.Forms.Label();
            this.btnGraphRefresh = new System.Windows.Forms.Button();
            this.lvwGraphs = new System.Windows.Forms.ListView();
            this.colGraphURI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuGraphs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuViewGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPreviewGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCountTriples = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyGraphTo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMoveGraphTo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRenameGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tabSparqlQuery = new System.Windows.Forms.TabPage();
            this.tableQueryTab = new System.Windows.Forms.TableLayoutPanel();
            this.txtSparqlQuery = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSaveQuery = new System.Windows.Forms.Button();
            this.btnSparqlQuery = new System.Windows.Forms.Button();
            this.numPageSize = new System.Windows.Forms.NumericUpDown();
            this.btnLoadQuery = new System.Windows.Forms.Button();
            this.chkPageQuery = new System.Windows.Forms.CheckBox();
            this.lblQueryIntro = new System.Windows.Forms.Label();
            this.tabSparqlUpdate = new System.Windows.Forms.TabPage();
            this.tableUpdateTab = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUpdateMode = new System.Windows.Forms.Label();
            this.btnSparqlUpdate = new System.Windows.Forms.Button();
            this.txtSparqlUpdate = new System.Windows.Forms.TextBox();
            this.lblUpdateIntro = new System.Windows.Forms.Label();
            this.tabImport = new System.Windows.Forms.TabPage();
            this.grpImportBatchSize = new System.Windows.Forms.GroupBox();
            this.lblBatchSize2 = new System.Windows.Forms.Label();
            this.numBatchSize = new System.Windows.Forms.NumericUpDown();
            this.lblBatchSize = new System.Windows.Forms.Label();
            this.grpImportOptions = new System.Windows.Forms.GroupBox();
            this.txtImportDefaultGraph = new System.Windows.Forms.TextBox();
            this.chkImportDefaultUri = new System.Windows.Forms.CheckBox();
            this.lblImport = new System.Windows.Forms.Label();
            this.grpImport = new System.Windows.Forms.GroupBox();
            this.btnImportUri = new System.Windows.Forms.Button();
            this.txtImportUri = new System.Windows.Forms.TextBox();
            this.lblUri = new System.Windows.Forms.Label();
            this.btnImportFile = new System.Windows.Forms.Button();
            this.btnBrowseImport = new System.Windows.Forms.Button();
            this.txtImportFile = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.tabExport = new System.Windows.Forms.TabPage();
            this.grpExport = new System.Windows.Forms.GroupBox();
            this.btnExportStore = new System.Windows.Forms.Button();
            this.btnBrowseExport = new System.Windows.Forms.Button();
            this.txtExportFile = new System.Windows.Forms.TextBox();
            this.lblExportFile = new System.Windows.Forms.Label();
            this.lblExport = new System.Windows.Forms.Label();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.btnRefreshStores = new System.Windows.Forms.Button();
            this.lvwStores = new System.Windows.Forms.ListView();
            this.colStoreID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuStores = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNewStore = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenStore = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteStore = new System.Windows.Forms.ToolStripMenuItem();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.propInfo = new System.Windows.Forms.PropertyGrid();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tabTasks = new System.Windows.Forms.TabPage();
            this.chkRemoveOldTasks = new System.Windows.Forms.CheckBox();
            this.lvwTasks = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTask = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuTasks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuViewDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewResults = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewErrors = new System.Windows.Forms.ToolStripMenuItem();
            this.View = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTasks = new System.Windows.Forms.Label();
            this.ofdImport = new System.Windows.Forms.OpenFileDialog();
            this.stsStatus = new System.Windows.Forms.StatusStrip();
            this.stsCurrent = new System.Windows.Forms.ToolStripStatusLabel();
            this.ofdQuery = new System.Windows.Forms.OpenFileDialog();
            this.sfdQuery = new System.Windows.Forms.SaveFileDialog();
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.tableForm = new System.Windows.Forms.TableLayoutPanel();
            this.tabFunctions.SuspendLayout();
            this.tabGraphs.SuspendLayout();
            this.mnuGraphs.SuspendLayout();
            this.tabSparqlQuery.SuspendLayout();
            this.tableQueryTab.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).BeginInit();
            this.tabSparqlUpdate.SuspendLayout();
            this.tableUpdateTab.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabImport.SuspendLayout();
            this.grpImportBatchSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBatchSize)).BeginInit();
            this.grpImportOptions.SuspendLayout();
            this.grpImport.SuspendLayout();
            this.tabExport.SuspendLayout();
            this.grpExport.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.mnuStores.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabTasks.SuspendLayout();
            this.mnuTasks.SuspendLayout();
            this.stsStatus.SuspendLayout();
            this.tableForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabFunctions
            // 
            this.tabFunctions.Controls.Add(this.tabGraphs);
            this.tabFunctions.Controls.Add(this.tabSparqlQuery);
            this.tabFunctions.Controls.Add(this.tabSparqlUpdate);
            this.tabFunctions.Controls.Add(this.tabImport);
            this.tabFunctions.Controls.Add(this.tabExport);
            this.tabFunctions.Controls.Add(this.tabServer);
            this.tabFunctions.Controls.Add(this.tabInfo);
            this.tabFunctions.Controls.Add(this.tabTasks);
            this.tabFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFunctions.Location = new System.Drawing.Point(10, 10);
            this.tabFunctions.Margin = new System.Windows.Forms.Padding(0);
            this.tabFunctions.Name = "tabFunctions";
            this.tabFunctions.Padding = new System.Drawing.Point(0, 0);
            this.tabFunctions.SelectedIndex = 0;
            this.tabFunctions.Size = new System.Drawing.Size(643, 388);
            this.tabFunctions.TabIndex = 0;
            // 
            // tabGraphs
            // 
            this.tabGraphs.Controls.Add(this.lblGraphListUnavailable);
            this.tabGraphs.Controls.Add(this.btnGraphRefresh);
            this.tabGraphs.Controls.Add(this.lvwGraphs);
            this.tabGraphs.Location = new System.Drawing.Point(4, 22);
            this.tabGraphs.Name = "tabGraphs";
            this.tabGraphs.Padding = new System.Windows.Forms.Padding(3);
            this.tabGraphs.Size = new System.Drawing.Size(635, 362);
            this.tabGraphs.TabIndex = 0;
            this.tabGraphs.Text = "Graphs";
            this.tabGraphs.UseVisualStyleBackColor = true;
            // 
            // lblGraphListUnavailable
            // 
            this.lblGraphListUnavailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraphListUnavailable.Location = new System.Drawing.Point(23, 117);
            this.lblGraphListUnavailable.Name = "lblGraphListUnavailable";
            this.lblGraphListUnavailable.Size = new System.Drawing.Size(568, 40);
            this.lblGraphListUnavailable.TabIndex = 6;
            this.lblGraphListUnavailable.Text = "Unable to list Graphs since your selected Store does not support this feature fro" +
    "m within this Tool";
            this.lblGraphListUnavailable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGraphListUnavailable.Visible = false;
            // 
            // btnGraphRefresh
            // 
            this.btnGraphRefresh.Enabled = false;
            this.btnGraphRefresh.Location = new System.Drawing.Point(269, 279);
            this.btnGraphRefresh.Name = "btnGraphRefresh";
            this.btnGraphRefresh.Size = new System.Drawing.Size(76, 23);
            this.btnGraphRefresh.TabIndex = 5;
            this.btnGraphRefresh.Text = "&Refresh";
            this.btnGraphRefresh.UseVisualStyleBackColor = true;
            this.btnGraphRefresh.Click += new System.EventHandler(this.btnGraphRefresh_Click);
            // 
            // lvwGraphs
            // 
            this.lvwGraphs.AllowDrop = true;
            this.lvwGraphs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGraphURI});
            this.lvwGraphs.ContextMenuStrip = this.mnuGraphs;
            this.lvwGraphs.FullRowSelect = true;
            this.lvwGraphs.GridLines = true;
            this.lvwGraphs.HideSelection = false;
            this.lvwGraphs.Location = new System.Drawing.Point(6, 6);
            this.lvwGraphs.MultiSelect = false;
            this.lvwGraphs.Name = "lvwGraphs";
            this.lvwGraphs.Size = new System.Drawing.Size(603, 267);
            this.lvwGraphs.TabIndex = 4;
            this.lvwGraphs.UseCompatibleStateImageBehavior = false;
            this.lvwGraphs.View = System.Windows.Forms.View.Details;
            this.lvwGraphs.DoubleClick += new System.EventHandler(this.lvwGraphs_DoubleClick);
            // 
            // colGraphURI
            // 
            this.colGraphURI.Text = "Graph URI";
            this.colGraphURI.Width = 583;
            // 
            // mnuGraphs
            // 
            this.mnuGraphs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewGraph,
            this.mnuPreviewGraph,
            this.mnuCountTriples,
            this.toolStripMenuItem1,
            this.mnuDeleteGraph,
            this.mnuCopyGraphTo,
            this.mnuMoveGraphTo});
            this.mnuGraphs.Name = "mnuGraphs";
            this.mnuGraphs.Size = new System.Drawing.Size(194, 142);
            this.mnuGraphs.Opening += new System.ComponentModel.CancelEventHandler(this.mnuGraphs_Opening);
            // 
            // mnuViewGraph
            // 
            this.mnuViewGraph.Name = "mnuViewGraph";
            this.mnuViewGraph.Size = new System.Drawing.Size(193, 22);
            this.mnuViewGraph.Text = "View Graph";
            this.mnuViewGraph.Click += new System.EventHandler(this.mnuViewGraph_Click);
            // 
            // mnuPreviewGraph
            // 
            this.mnuPreviewGraph.Name = "mnuPreviewGraph";
            this.mnuPreviewGraph.Size = new System.Drawing.Size(193, 22);
            this.mnuPreviewGraph.Text = "Preview first {0} Triples";
            this.mnuPreviewGraph.Click += new System.EventHandler(this.mnuPreviewGraph_Click);
            // 
            // mnuCountTriples
            // 
            this.mnuCountTriples.Name = "mnuCountTriples";
            this.mnuCountTriples.Size = new System.Drawing.Size(193, 22);
            this.mnuCountTriples.Text = "Count Triples";
            this.mnuCountTriples.Click += new System.EventHandler(this.mnuCountTriples_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(190, 6);
            // 
            // mnuDeleteGraph
            // 
            this.mnuDeleteGraph.Name = "mnuDeleteGraph";
            this.mnuDeleteGraph.Size = new System.Drawing.Size(193, 22);
            this.mnuDeleteGraph.Text = "Delete Graph";
            this.mnuDeleteGraph.Click += new System.EventHandler(this.mnuDeleteGraph_Click);
            // 
            // mnuCopyGraphTo
            // 
            this.mnuCopyGraphTo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopyGraph,
            this.toolStripMenuItem2});
            this.mnuCopyGraphTo.Name = "mnuCopyGraphTo";
            this.mnuCopyGraphTo.Size = new System.Drawing.Size(193, 22);
            this.mnuCopyGraphTo.Text = "Copy Graph To";
            // 
            // mnuCopyGraph
            // 
            this.mnuCopyGraph.Name = "mnuCopyGraph";
            this.mnuCopyGraph.Size = new System.Drawing.Size(132, 22);
            this.mnuCopyGraph.Text = "Self (Copy)";
            this.mnuCopyGraph.Click += new System.EventHandler(this.mnuCopyGraph_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(129, 6);
            // 
            // mnuMoveGraphTo
            // 
            this.mnuMoveGraphTo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRenameGraph,
            this.toolStripMenuItem3});
            this.mnuMoveGraphTo.Name = "mnuMoveGraphTo";
            this.mnuMoveGraphTo.Size = new System.Drawing.Size(193, 22);
            this.mnuMoveGraphTo.Text = "Move Graph To";
            // 
            // mnuRenameGraph
            // 
            this.mnuRenameGraph.Name = "mnuRenameGraph";
            this.mnuRenameGraph.Size = new System.Drawing.Size(147, 22);
            this.mnuRenameGraph.Text = "Self (Rename)";
            this.mnuRenameGraph.Click += new System.EventHandler(this.mnuRenameGraph_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(144, 6);
            // 
            // tabSparqlQuery
            // 
            this.tabSparqlQuery.Controls.Add(this.tableQueryTab);
            this.tabSparqlQuery.Location = new System.Drawing.Point(4, 22);
            this.tabSparqlQuery.Margin = new System.Windows.Forms.Padding(0);
            this.tabSparqlQuery.Name = "tabSparqlQuery";
            this.tabSparqlQuery.Padding = new System.Windows.Forms.Padding(10);
            this.tabSparqlQuery.Size = new System.Drawing.Size(635, 362);
            this.tabSparqlQuery.TabIndex = 1;
            this.tabSparqlQuery.Text = "SPARQL Query";
            this.tabSparqlQuery.UseVisualStyleBackColor = true;
            // 
            // tableQueryTab
            // 
            this.tableQueryTab.ColumnCount = 1;
            this.tableQueryTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableQueryTab.Controls.Add(this.txtSparqlQuery, 0, 1);
            this.tableQueryTab.Controls.Add(this.panel1, 0, 2);
            this.tableQueryTab.Controls.Add(this.lblQueryIntro, 0, 0);
            this.tableQueryTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableQueryTab.Location = new System.Drawing.Point(10, 10);
            this.tableQueryTab.Margin = new System.Windows.Forms.Padding(0);
            this.tableQueryTab.Name = "tableQueryTab";
            this.tableQueryTab.RowCount = 3;
            this.tableQueryTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableQueryTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableQueryTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableQueryTab.Size = new System.Drawing.Size(615, 342);
            this.tableQueryTab.TabIndex = 7;
            // 
            // txtSparqlQuery
            // 
            this.txtSparqlQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSparqlQuery.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSparqlQuery.Location = new System.Drawing.Point(3, 53);
            this.txtSparqlQuery.Multiline = true;
            this.txtSparqlQuery.Name = "txtSparqlQuery";
            this.txtSparqlQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSparqlQuery.Size = new System.Drawing.Size(609, 218);
            this.txtSparqlQuery.TabIndex = 1;
            this.txtSparqlQuery.Text = "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>\r\nPREFIX rdfs: <http://w" +
    "ww.w3.org/2000/01/rdf-schema#>\r\nPREFIX xsd: <http://www.w3.org/2001/XMLSchema#>\r" +
    "\n";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSaveQuery);
            this.panel1.Controls.Add(this.btnSparqlQuery);
            this.panel1.Controls.Add(this.numPageSize);
            this.panel1.Controls.Add(this.btnLoadQuery);
            this.panel1.Controls.Add(this.chkPageQuery);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 277);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(533, 62);
            this.panel1.TabIndex = 8;
            // 
            // btnSaveQuery
            // 
            this.btnSaveQuery.Location = new System.Drawing.Point(0, 35);
            this.btnSaveQuery.Name = "btnSaveQuery";
            this.btnSaveQuery.Size = new System.Drawing.Size(75, 23);
            this.btnSaveQuery.TabIndex = 4;
            this.btnSaveQuery.Text = "Save Query";
            this.btnSaveQuery.UseVisualStyleBackColor = true;
            this.btnSaveQuery.Click += new System.EventHandler(this.btnSaveQuery_Click);
            // 
            // btnSparqlQuery
            // 
            this.btnSparqlQuery.Location = new System.Drawing.Point(162, 35);
            this.btnSparqlQuery.Name = "btnSparqlQuery";
            this.btnSparqlQuery.Size = new System.Drawing.Size(75, 23);
            this.btnSparqlQuery.TabIndex = 6;
            this.btnSparqlQuery.Text = "Run Query";
            this.btnSparqlQuery.UseVisualStyleBackColor = true;
            this.btnSparqlQuery.Click += new System.EventHandler(this.btnSparqlQuery_Click);
            // 
            // numPageSize
            // 
            this.numPageSize.Location = new System.Drawing.Point(389, 10);
            this.numPageSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPageSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPageSize.Name = "numPageSize";
            this.numPageSize.Size = new System.Drawing.Size(120, 20);
            this.numPageSize.TabIndex = 3;
            this.numPageSize.ThousandsSeparator = true;
            this.numPageSize.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnLoadQuery
            // 
            this.btnLoadQuery.Location = new System.Drawing.Point(81, 35);
            this.btnLoadQuery.Name = "btnLoadQuery";
            this.btnLoadQuery.Size = new System.Drawing.Size(75, 23);
            this.btnLoadQuery.TabIndex = 5;
            this.btnLoadQuery.Text = "Load Query";
            this.btnLoadQuery.UseVisualStyleBackColor = true;
            this.btnLoadQuery.Click += new System.EventHandler(this.btnLoadQuery_Click);
            // 
            // chkPageQuery
            // 
            this.chkPageQuery.AutoSize = true;
            this.chkPageQuery.Location = new System.Drawing.Point(4, 12);
            this.chkPageQuery.Name = "chkPageQuery";
            this.chkPageQuery.Size = new System.Drawing.Size(390, 17);
            this.chkPageQuery.TabIndex = 2;
            this.chkPageQuery.Text = "Issue this query repeatedly until there are no further results using page size of" +
    " ";
            this.chkPageQuery.UseVisualStyleBackColor = true;
            // 
            // lblQueryIntro
            // 
            this.lblQueryIntro.Location = new System.Drawing.Point(0, 0);
            this.lblQueryIntro.Margin = new System.Windows.Forms.Padding(0);
            this.lblQueryIntro.Name = "lblQueryIntro";
            this.lblQueryIntro.Size = new System.Drawing.Size(606, 48);
            this.lblQueryIntro.TabIndex = 0;
            this.lblQueryIntro.Text = resources.GetString("lblQueryIntro.Text");
            // 
            // tabSparqlUpdate
            // 
            this.tabSparqlUpdate.Controls.Add(this.tableUpdateTab);
            this.tabSparqlUpdate.Location = new System.Drawing.Point(4, 22);
            this.tabSparqlUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.tabSparqlUpdate.Name = "tabSparqlUpdate";
            this.tabSparqlUpdate.Padding = new System.Windows.Forms.Padding(10);
            this.tabSparqlUpdate.Size = new System.Drawing.Size(635, 362);
            this.tabSparqlUpdate.TabIndex = 3;
            this.tabSparqlUpdate.Text = "SPARQL Update";
            this.tabSparqlUpdate.UseVisualStyleBackColor = true;
            // 
            // tableUpdateTab
            // 
            this.tableUpdateTab.ColumnCount = 1;
            this.tableUpdateTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableUpdateTab.Controls.Add(this.panel2, 0, 2);
            this.tableUpdateTab.Controls.Add(this.txtSparqlUpdate, 0, 1);
            this.tableUpdateTab.Controls.Add(this.lblUpdateIntro, 0, 0);
            this.tableUpdateTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableUpdateTab.Location = new System.Drawing.Point(10, 10);
            this.tableUpdateTab.Margin = new System.Windows.Forms.Padding(0);
            this.tableUpdateTab.Name = "tableUpdateTab";
            this.tableUpdateTab.RowCount = 3;
            this.tableUpdateTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableUpdateTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableUpdateTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableUpdateTab.Size = new System.Drawing.Size(615, 342);
            this.tableUpdateTab.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblUpdateMode);
            this.panel2.Controls.Add(this.btnSparqlUpdate);
            this.panel2.Location = new System.Drawing.Point(3, 283);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(452, 56);
            this.panel2.TabIndex = 6;
            // 
            // lblUpdateMode
            // 
            this.lblUpdateMode.AutoSize = true;
            this.lblUpdateMode.Location = new System.Drawing.Point(3, 6);
            this.lblUpdateMode.Name = "lblUpdateMode";
            this.lblUpdateMode.Size = new System.Drawing.Size(75, 13);
            this.lblUpdateMode.TabIndex = 4;
            this.lblUpdateMode.Text = "Update Mode:";
            // 
            // btnSparqlUpdate
            // 
            this.btnSparqlUpdate.Location = new System.Drawing.Point(0, 26);
            this.btnSparqlUpdate.Name = "btnSparqlUpdate";
            this.btnSparqlUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnSparqlUpdate.TabIndex = 3;
            this.btnSparqlUpdate.Text = "Run Update";
            this.btnSparqlUpdate.UseVisualStyleBackColor = true;
            this.btnSparqlUpdate.Click += new System.EventHandler(this.btnSparqlUpdate_Click);
            // 
            // txtSparqlUpdate
            // 
            this.txtSparqlUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSparqlUpdate.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSparqlUpdate.Location = new System.Drawing.Point(3, 53);
            this.txtSparqlUpdate.Multiline = true;
            this.txtSparqlUpdate.Name = "txtSparqlUpdate";
            this.txtSparqlUpdate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSparqlUpdate.Size = new System.Drawing.Size(609, 224);
            this.txtSparqlUpdate.TabIndex = 2;
            this.txtSparqlUpdate.Text = "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>\r\nPREFIX rdfs: <http://w" +
    "ww.w3.org/2000/01/rdf-schema#>\r\nPREFIX xsd: <http://www.w3.org/2001/XMLSchema#>\r" +
    "\n";
            // 
            // lblUpdateIntro
            // 
            this.lblUpdateIntro.Location = new System.Drawing.Point(0, 0);
            this.lblUpdateIntro.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpdateIntro.Name = "lblUpdateIntro";
            this.lblUpdateIntro.Size = new System.Drawing.Size(609, 46);
            this.lblUpdateIntro.TabIndex = 0;
            this.lblUpdateIntro.Text = resources.GetString("lblUpdateIntro.Text");
            // 
            // tabImport
            // 
            this.tabImport.Controls.Add(this.grpImportBatchSize);
            this.tabImport.Controls.Add(this.grpImportOptions);
            this.tabImport.Controls.Add(this.lblImport);
            this.tabImport.Controls.Add(this.grpImport);
            this.tabImport.Location = new System.Drawing.Point(4, 22);
            this.tabImport.Name = "tabImport";
            this.tabImport.Size = new System.Drawing.Size(635, 362);
            this.tabImport.TabIndex = 2;
            this.tabImport.Text = "Import Data";
            this.tabImport.UseVisualStyleBackColor = true;
            // 
            // grpImportBatchSize
            // 
            this.grpImportBatchSize.Controls.Add(this.lblBatchSize2);
            this.grpImportBatchSize.Controls.Add(this.numBatchSize);
            this.grpImportBatchSize.Controls.Add(this.lblBatchSize);
            this.grpImportBatchSize.Location = new System.Drawing.Point(6, 173);
            this.grpImportBatchSize.Name = "grpImportBatchSize";
            this.grpImportBatchSize.Size = new System.Drawing.Size(606, 37);
            this.grpImportBatchSize.TabIndex = 10;
            this.grpImportBatchSize.TabStop = false;
            this.grpImportBatchSize.Text = "Import Batch Size";
            // 
            // lblBatchSize2
            // 
            this.lblBatchSize2.AutoSize = true;
            this.lblBatchSize2.Location = new System.Drawing.Point(320, 16);
            this.lblBatchSize2.Name = "lblBatchSize2";
            this.lblBatchSize2.Size = new System.Drawing.Size(38, 13);
            this.lblBatchSize2.TabIndex = 2;
            this.lblBatchSize2.Text = "Triples";
            // 
            // numBatchSize
            // 
            this.numBatchSize.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numBatchSize.Location = new System.Drawing.Point(253, 14);
            this.numBatchSize.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numBatchSize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numBatchSize.Name = "numBatchSize";
            this.numBatchSize.Size = new System.Drawing.Size(61, 20);
            this.numBatchSize.TabIndex = 1;
            this.numBatchSize.ThousandsSeparator = true;
            this.numBatchSize.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // lblBatchSize
            // 
            this.lblBatchSize.AutoSize = true;
            this.lblBatchSize.Location = new System.Drawing.Point(6, 16);
            this.lblBatchSize.Name = "lblBatchSize";
            this.lblBatchSize.Size = new System.Drawing.Size(251, 13);
            this.lblBatchSize.TabIndex = 0;
            this.lblBatchSize.Text = "Where Batched Import is supported use Batches of ";
            // 
            // grpImportOptions
            // 
            this.grpImportOptions.Controls.Add(this.txtImportDefaultGraph);
            this.grpImportOptions.Controls.Add(this.chkImportDefaultUri);
            this.grpImportOptions.Location = new System.Drawing.Point(6, 216);
            this.grpImportOptions.Name = "grpImportOptions";
            this.grpImportOptions.Size = new System.Drawing.Size(606, 89);
            this.grpImportOptions.TabIndex = 9;
            this.grpImportOptions.TabStop = false;
            this.grpImportOptions.Text = "Default Target Graph URI";
            // 
            // txtImportDefaultGraph
            // 
            this.txtImportDefaultGraph.Enabled = false;
            this.txtImportDefaultGraph.Location = new System.Drawing.Point(20, 63);
            this.txtImportDefaultGraph.Name = "txtImportDefaultGraph";
            this.txtImportDefaultGraph.Size = new System.Drawing.Size(580, 20);
            this.txtImportDefaultGraph.TabIndex = 1;
            // 
            // chkImportDefaultUri
            // 
            this.chkImportDefaultUri.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkImportDefaultUri.Location = new System.Drawing.Point(6, 19);
            this.chkImportDefaultUri.Name = "chkImportDefaultUri";
            this.chkImportDefaultUri.Size = new System.Drawing.Size(594, 51);
            this.chkImportDefaultUri.TabIndex = 0;
            this.chkImportDefaultUri.Text = resources.GetString("chkImportDefaultUri.Text");
            this.chkImportDefaultUri.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkImportDefaultUri.UseVisualStyleBackColor = true;
            this.chkImportDefaultUri.CheckedChanged += new System.EventHandler(this.chkImportDefaultUri_CheckedChanged);
            // 
            // lblImport
            // 
            this.lblImport.Location = new System.Drawing.Point(3, 14);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(609, 73);
            this.lblImport.TabIndex = 8;
            this.lblImport.Text = resources.GetString("lblImport.Text");
            // 
            // grpImport
            // 
            this.grpImport.Controls.Add(this.btnImportUri);
            this.grpImport.Controls.Add(this.txtImportUri);
            this.grpImport.Controls.Add(this.lblUri);
            this.grpImport.Controls.Add(this.btnImportFile);
            this.grpImport.Controls.Add(this.btnBrowseImport);
            this.grpImport.Controls.Add(this.txtImportFile);
            this.grpImport.Controls.Add(this.lblFile);
            this.grpImport.Location = new System.Drawing.Point(6, 89);
            this.grpImport.Name = "grpImport";
            this.grpImport.Size = new System.Drawing.Size(606, 76);
            this.grpImport.TabIndex = 0;
            this.grpImport.TabStop = false;
            this.grpImport.Text = "Data Source";
            // 
            // btnImportUri
            // 
            this.btnImportUri.Location = new System.Drawing.Point(525, 45);
            this.btnImportUri.Name = "btnImportUri";
            this.btnImportUri.Size = new System.Drawing.Size(75, 23);
            this.btnImportUri.TabIndex = 7;
            this.btnImportUri.Text = "Import URI";
            this.btnImportUri.UseVisualStyleBackColor = true;
            this.btnImportUri.Click += new System.EventHandler(this.btnImportUri_Click);
            // 
            // txtImportUri
            // 
            this.txtImportUri.Location = new System.Drawing.Point(38, 47);
            this.txtImportUri.Name = "txtImportUri";
            this.txtImportUri.Size = new System.Drawing.Size(481, 20);
            this.txtImportUri.TabIndex = 6;
            // 
            // lblUri
            // 
            this.lblUri.AutoSize = true;
            this.lblUri.Location = new System.Drawing.Point(6, 50);
            this.lblUri.Name = "lblUri";
            this.lblUri.Size = new System.Drawing.Size(23, 13);
            this.lblUri.TabIndex = 5;
            this.lblUri.Text = "Uri:";
            // 
            // btnImportFile
            // 
            this.btnImportFile.Location = new System.Drawing.Point(525, 19);
            this.btnImportFile.Name = "btnImportFile";
            this.btnImportFile.Size = new System.Drawing.Size(75, 23);
            this.btnImportFile.TabIndex = 4;
            this.btnImportFile.Text = "Import File";
            this.btnImportFile.UseVisualStyleBackColor = true;
            this.btnImportFile.Click += new System.EventHandler(this.btnImportFile_Click);
            // 
            // btnBrowseImport
            // 
            this.btnBrowseImport.Location = new System.Drawing.Point(444, 19);
            this.btnBrowseImport.Name = "btnBrowseImport";
            this.btnBrowseImport.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseImport.TabIndex = 3;
            this.btnBrowseImport.Text = "&Browse";
            this.btnBrowseImport.UseVisualStyleBackColor = true;
            this.btnBrowseImport.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtImportFile
            // 
            this.txtImportFile.Location = new System.Drawing.Point(38, 21);
            this.txtImportFile.Name = "txtImportFile";
            this.txtImportFile.Size = new System.Drawing.Size(400, 20);
            this.txtImportFile.TabIndex = 2;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(6, 24);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(26, 13);
            this.lblFile.TabIndex = 1;
            this.lblFile.Text = "File:";
            // 
            // tabExport
            // 
            this.tabExport.Controls.Add(this.grpExport);
            this.tabExport.Controls.Add(this.lblExport);
            this.tabExport.Location = new System.Drawing.Point(4, 22);
            this.tabExport.Name = "tabExport";
            this.tabExport.Size = new System.Drawing.Size(635, 362);
            this.tabExport.TabIndex = 5;
            this.tabExport.Text = "Export Data";
            this.tabExport.UseVisualStyleBackColor = true;
            // 
            // grpExport
            // 
            this.grpExport.Controls.Add(this.btnExportStore);
            this.grpExport.Controls.Add(this.btnBrowseExport);
            this.grpExport.Controls.Add(this.txtExportFile);
            this.grpExport.Controls.Add(this.lblExportFile);
            this.grpExport.Location = new System.Drawing.Point(6, 72);
            this.grpExport.Name = "grpExport";
            this.grpExport.Size = new System.Drawing.Size(596, 82);
            this.grpExport.TabIndex = 10;
            this.grpExport.TabStop = false;
            this.grpExport.Text = "Export Destination";
            // 
            // btnExportStore
            // 
            this.btnExportStore.Location = new System.Drawing.Point(261, 47);
            this.btnExportStore.Name = "btnExportStore";
            this.btnExportStore.Size = new System.Drawing.Size(75, 23);
            this.btnExportStore.TabIndex = 7;
            this.btnExportStore.Text = "Export Store";
            this.btnExportStore.UseVisualStyleBackColor = true;
            this.btnExportStore.Click += new System.EventHandler(this.btnExportStore_Click);
            // 
            // btnBrowseExport
            // 
            this.btnBrowseExport.Location = new System.Drawing.Point(515, 18);
            this.btnBrowseExport.Name = "btnBrowseExport";
            this.btnBrowseExport.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseExport.TabIndex = 6;
            this.btnBrowseExport.Text = "&Browse";
            this.btnBrowseExport.UseVisualStyleBackColor = true;
            this.btnBrowseExport.Click += new System.EventHandler(this.btnBrowseExport_Click);
            // 
            // txtExportFile
            // 
            this.txtExportFile.Location = new System.Drawing.Point(39, 21);
            this.txtExportFile.Name = "txtExportFile";
            this.txtExportFile.Size = new System.Drawing.Size(470, 20);
            this.txtExportFile.TabIndex = 5;
            // 
            // lblExportFile
            // 
            this.lblExportFile.AutoSize = true;
            this.lblExportFile.Location = new System.Drawing.Point(7, 24);
            this.lblExportFile.Name = "lblExportFile";
            this.lblExportFile.Size = new System.Drawing.Size(26, 13);
            this.lblExportFile.TabIndex = 4;
            this.lblExportFile.Text = "File:";
            // 
            // lblExport
            // 
            this.lblExport.Location = new System.Drawing.Point(3, 14);
            this.lblExport.Name = "lblExport";
            this.lblExport.Size = new System.Drawing.Size(599, 64);
            this.lblExport.TabIndex = 9;
            this.lblExport.Text = resources.GetString("lblExport.Text");
            // 
            // tabServer
            // 
            this.tabServer.Controls.Add(this.btnRefreshStores);
            this.tabServer.Controls.Add(this.lvwStores);
            this.tabServer.Location = new System.Drawing.Point(4, 22);
            this.tabServer.Name = "tabServer";
            this.tabServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabServer.Size = new System.Drawing.Size(635, 362);
            this.tabServer.TabIndex = 7;
            this.tabServer.Text = "Server Management";
            this.tabServer.UseVisualStyleBackColor = true;
            // 
            // btnRefreshStores
            // 
            this.btnRefreshStores.Enabled = false;
            this.btnRefreshStores.Location = new System.Drawing.Point(269, 279);
            this.btnRefreshStores.Name = "btnRefreshStores";
            this.btnRefreshStores.Size = new System.Drawing.Size(76, 23);
            this.btnRefreshStores.TabIndex = 6;
            this.btnRefreshStores.Text = "&Refresh";
            this.btnRefreshStores.UseVisualStyleBackColor = true;
            this.btnRefreshStores.Click += new System.EventHandler(this.btnRefreshStores_Click);
            // 
            // lvwStores
            // 
            this.lvwStores.AllowDrop = true;
            this.lvwStores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStoreID});
            this.lvwStores.ContextMenuStrip = this.mnuStores;
            this.lvwStores.FullRowSelect = true;
            this.lvwStores.GridLines = true;
            this.lvwStores.HideSelection = false;
            this.lvwStores.Location = new System.Drawing.Point(6, 6);
            this.lvwStores.MultiSelect = false;
            this.lvwStores.Name = "lvwStores";
            this.lvwStores.Size = new System.Drawing.Size(603, 267);
            this.lvwStores.TabIndex = 5;
            this.lvwStores.UseCompatibleStateImageBehavior = false;
            this.lvwStores.View = System.Windows.Forms.View.Details;
            // 
            // colStoreID
            // 
            this.colStoreID.Text = "Store ID";
            this.colStoreID.Width = 583;
            // 
            // mnuStores
            // 
            this.mnuStores.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewStore,
            this.mnuOpenStore,
            this.mnuDeleteStore});
            this.mnuStores.Name = "mnuStores";
            this.mnuStores.Size = new System.Drawing.Size(138, 70);
            this.mnuStores.Opening += new System.ComponentModel.CancelEventHandler(this.mnuStores_Opening);
            // 
            // mnuNewStore
            // 
            this.mnuNewStore.Name = "mnuNewStore";
            this.mnuNewStore.Size = new System.Drawing.Size(137, 22);
            this.mnuNewStore.Text = "&New Store";
            this.mnuNewStore.Click += new System.EventHandler(this.mnuNewStore_Click);
            // 
            // mnuOpenStore
            // 
            this.mnuOpenStore.Name = "mnuOpenStore";
            this.mnuOpenStore.Size = new System.Drawing.Size(137, 22);
            this.mnuOpenStore.Text = "&Open Store";
            this.mnuOpenStore.Click += new System.EventHandler(this.mnuOpenStore_Click);
            // 
            // mnuDeleteStore
            // 
            this.mnuDeleteStore.Name = "mnuDeleteStore";
            this.mnuDeleteStore.Size = new System.Drawing.Size(137, 22);
            this.mnuDeleteStore.Text = "&Delete Store";
            this.mnuDeleteStore.Click += new System.EventHandler(this.mnuDeleteStore_Click);
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.propInfo);
            this.tabInfo.Controls.Add(this.lblInfo);
            this.tabInfo.Location = new System.Drawing.Point(4, 22);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(635, 362);
            this.tabInfo.TabIndex = 6;
            this.tabInfo.Text = "Information";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // propInfo
            // 
            this.propInfo.Location = new System.Drawing.Point(6, 57);
            this.propInfo.Name = "propInfo";
            this.propInfo.Size = new System.Drawing.Size(603, 245);
            this.propInfo.TabIndex = 2;
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(3, 12);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(606, 52);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = resources.GetString("lblInfo.Text");
            // 
            // tabTasks
            // 
            this.tabTasks.Controls.Add(this.chkRemoveOldTasks);
            this.tabTasks.Controls.Add(this.lvwTasks);
            this.tabTasks.Controls.Add(this.lblTasks);
            this.tabTasks.Location = new System.Drawing.Point(4, 22);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabTasks.Size = new System.Drawing.Size(635, 362);
            this.tabTasks.TabIndex = 4;
            this.tabTasks.Text = "Tasks";
            this.tabTasks.UseVisualStyleBackColor = true;
            // 
            // chkRemoveOldTasks
            // 
            this.chkRemoveOldTasks.AutoSize = true;
            this.chkRemoveOldTasks.Checked = true;
            this.chkRemoveOldTasks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemoveOldTasks.Location = new System.Drawing.Point(6, 285);
            this.chkRemoveOldTasks.Name = "chkRemoveOldTasks";
            this.chkRemoveOldTasks.Size = new System.Drawing.Size(341, 17);
            this.chkRemoveOldTasks.TabIndex = 2;
            this.chkRemoveOldTasks.Text = "Remove Completed Tasks from this View as New Tasks are added";
            this.chkRemoveOldTasks.UseVisualStyleBackColor = true;
            // 
            // lvwTasks
            // 
            this.lvwTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colTask,
            this.colState,
            this.colInfo});
            this.lvwTasks.ContextMenuStrip = this.mnuTasks;
            this.lvwTasks.FullRowSelect = true;
            this.lvwTasks.GridLines = true;
            this.lvwTasks.Location = new System.Drawing.Point(6, 59);
            this.lvwTasks.MultiSelect = false;
            this.lvwTasks.Name = "lvwTasks";
            this.lvwTasks.Size = new System.Drawing.Size(603, 220);
            this.lvwTasks.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvwTasks.TabIndex = 1;
            this.lvwTasks.UseCompatibleStateImageBehavior = false;
            this.lvwTasks.View = System.Windows.Forms.View.Details;
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 44;
            // 
            // colTask
            // 
            this.colTask.Text = "Task";
            this.colTask.Width = 127;
            // 
            // colState
            // 
            this.colState.Text = "Task State";
            this.colState.Width = 108;
            // 
            // colInfo
            // 
            this.colInfo.Text = "Task Information";
            this.colInfo.Width = 303;
            // 
            // mnuTasks
            // 
            this.mnuTasks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewDetail,
            this.mnuViewResults,
            this.mnuViewErrors,
            this.View,
            this.mnuCancel});
            this.mnuTasks.Name = "mnuTasks";
            this.mnuTasks.ShowImageMargin = false;
            this.mnuTasks.Size = new System.Drawing.Size(187, 98);
            this.mnuTasks.Opening += new System.ComponentModel.CancelEventHandler(this.mnuTasks_Opening);
            // 
            // mnuViewDetail
            // 
            this.mnuViewDetail.Name = "mnuViewDetail";
            this.mnuViewDetail.Size = new System.Drawing.Size(186, 22);
            this.mnuViewDetail.Text = "View Detailed Information";
            this.mnuViewDetail.Click += new System.EventHandler(this.mnuViewDetail_Click);
            // 
            // mnuViewResults
            // 
            this.mnuViewResults.Name = "mnuViewResults";
            this.mnuViewResults.Size = new System.Drawing.Size(186, 22);
            this.mnuViewResults.Text = "View Results";
            this.mnuViewResults.Click += new System.EventHandler(this.mnuViewResults_Click);
            // 
            // mnuViewErrors
            // 
            this.mnuViewErrors.Name = "mnuViewErrors";
            this.mnuViewErrors.Size = new System.Drawing.Size(186, 22);
            this.mnuViewErrors.Text = "View Error Trace";
            this.mnuViewErrors.Click += new System.EventHandler(this.mnuViewErrors_Click);
            // 
            // View
            // 
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(183, 6);
            // 
            // mnuCancel
            // 
            this.mnuCancel.Name = "mnuCancel";
            this.mnuCancel.Size = new System.Drawing.Size(186, 22);
            this.mnuCancel.Text = "Cancel";
            this.mnuCancel.Click += new System.EventHandler(this.mnuCancel_Click);
            // 
            // lblTasks
            // 
            this.lblTasks.Location = new System.Drawing.Point(3, 12);
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(606, 52);
            this.lblTasks.TabIndex = 0;
            this.lblTasks.Text = resources.GetString("lblTasks.Text");
            // 
            // ofdImport
            // 
            this.ofdImport.FileName = "example.rdf";
            this.ofdImport.Title = "Import from File";
            // 
            // stsStatus
            // 
            this.stsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsCurrent});
            this.stsStatus.Location = new System.Drawing.Point(0, 408);
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(663, 22);
            this.stsStatus.SizingGrip = false;
            this.stsStatus.TabIndex = 1;
            // 
            // stsCurrent
            // 
            this.stsCurrent.Name = "stsCurrent";
            this.stsCurrent.Size = new System.Drawing.Size(217, 17);
            this.stsCurrent.Text = "Waiting for the Store to become ready...";
            // 
            // ofdQuery
            // 
            this.ofdQuery.DefaultExt = "rq";
            this.ofdQuery.FileName = "ofdQuery";
            this.ofdQuery.Filter = "All Supported Files|*.rq|SPARQL Query Files|*.rq|All Files|*.*";
            this.ofdQuery.Title = "Open SPARQL Query";
            // 
            // sfdQuery
            // 
            this.sfdQuery.FileName = "query.rq";
            this.sfdQuery.Title = "Load SPARQL Query";
            // 
            // sfdExport
            // 
            this.sfdExport.Title = "Export Store As...";
            // 
            // tableForm
            // 
            this.tableForm.ColumnCount = 1;
            this.tableForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableForm.Controls.Add(this.tabFunctions, 0, 0);
            this.tableForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableForm.Location = new System.Drawing.Point(0, 0);
            this.tableForm.Margin = new System.Windows.Forms.Padding(10);
            this.tableForm.Name = "tableForm";
            this.tableForm.Padding = new System.Windows.Forms.Padding(10);
            this.tableForm.RowCount = 1;
            this.tableForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableForm.Size = new System.Drawing.Size(663, 408);
            this.tableForm.TabIndex = 3;
            // 
            // StoreManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 430);
            this.Controls.Add(this.tableForm);
            this.Controls.Add(this.stsStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StoreManagerForm";
            this.Text = "fclsGenericStoreManager";
            this.Load += new System.EventHandler(this.fclsGenericStoreManager_Load);
            this.tabFunctions.ResumeLayout(false);
            this.tabGraphs.ResumeLayout(false);
            this.mnuGraphs.ResumeLayout(false);
            this.tabSparqlQuery.ResumeLayout(false);
            this.tableQueryTab.ResumeLayout(false);
            this.tableQueryTab.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).EndInit();
            this.tabSparqlUpdate.ResumeLayout(false);
            this.tableUpdateTab.ResumeLayout(false);
            this.tableUpdateTab.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabImport.ResumeLayout(false);
            this.grpImportBatchSize.ResumeLayout(false);
            this.grpImportBatchSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBatchSize)).EndInit();
            this.grpImportOptions.ResumeLayout(false);
            this.grpImportOptions.PerformLayout();
            this.grpImport.ResumeLayout(false);
            this.grpImport.PerformLayout();
            this.tabExport.ResumeLayout(false);
            this.grpExport.ResumeLayout(false);
            this.grpExport.PerformLayout();
            this.tabServer.ResumeLayout(false);
            this.mnuStores.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabTasks.ResumeLayout(false);
            this.tabTasks.PerformLayout();
            this.mnuTasks.ResumeLayout(false);
            this.stsStatus.ResumeLayout(false);
            this.stsStatus.PerformLayout();
            this.tableForm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabFunctions;
        private System.Windows.Forms.TabPage tabGraphs;
        private System.Windows.Forms.TabPage tabSparqlQuery;
        private System.Windows.Forms.TabPage tabImport;
        private System.Windows.Forms.Button btnGraphRefresh;
        private System.Windows.Forms.ListView lvwGraphs;
        private System.Windows.Forms.ColumnHeader colGraphURI;
        private System.Windows.Forms.Label lblGraphListUnavailable;
        private System.Windows.Forms.Label lblQueryIntro;
        private System.Windows.Forms.TextBox txtSparqlQuery;
        private System.Windows.Forms.OpenFileDialog ofdImport;
        private System.Windows.Forms.StatusStrip stsStatus;
        private System.Windows.Forms.ToolStripStatusLabel stsCurrent;
        private System.Windows.Forms.OpenFileDialog ofdQuery;
        private System.Windows.Forms.SaveFileDialog sfdQuery;
        private System.Windows.Forms.TabPage tabSparqlUpdate;
        private System.Windows.Forms.Label lblUpdateIntro;
        private System.Windows.Forms.TextBox txtSparqlUpdate;
        private System.Windows.Forms.Button btnSparqlUpdate;
        private System.Windows.Forms.Label lblUpdateMode;
        private System.Windows.Forms.TabPage tabTasks;
        private System.Windows.Forms.ListView lvwTasks;
        private System.Windows.Forms.ColumnHeader colTask;
        private System.Windows.Forms.ColumnHeader colState;
        private System.Windows.Forms.ColumnHeader colInfo;
        private System.Windows.Forms.Label lblTasks;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.GroupBox grpImport;
        private System.Windows.Forms.Button btnImportUri;
        private System.Windows.Forms.TextBox txtImportUri;
        private System.Windows.Forms.Label lblUri;
        private System.Windows.Forms.Button btnImportFile;
        private System.Windows.Forms.Button btnBrowseImport;
        private System.Windows.Forms.TextBox txtImportFile;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.GroupBox grpImportOptions;
        private System.Windows.Forms.TextBox txtImportDefaultGraph;
        private System.Windows.Forms.CheckBox chkImportDefaultUri;
        private System.Windows.Forms.TabPage tabExport;
        private System.Windows.Forms.ContextMenuStrip mnuTasks;
        private System.Windows.Forms.ToolStripMenuItem mnuViewDetail;
        private System.Windows.Forms.ToolStripMenuItem mnuViewResults;
        private System.Windows.Forms.ToolStripMenuItem mnuViewErrors;
        private System.Windows.Forms.ToolStripSeparator View;
        private System.Windows.Forms.ToolStripMenuItem mnuCancel;
        private System.Windows.Forms.Label lblExport;
        private System.Windows.Forms.GroupBox grpExport;
        private System.Windows.Forms.Button btnBrowseExport;
        private System.Windows.Forms.TextBox txtExportFile;
        private System.Windows.Forms.Label lblExportFile;
        private System.Windows.Forms.SaveFileDialog sfdExport;
        private System.Windows.Forms.Button btnExportStore;
        private System.Windows.Forms.GroupBox grpImportBatchSize;
        private System.Windows.Forms.Label lblBatchSize2;
        private System.Windows.Forms.NumericUpDown numBatchSize;
        private System.Windows.Forms.Label lblBatchSize;
        private System.Windows.Forms.ContextMenuStrip mnuGraphs;
        private System.Windows.Forms.ToolStripMenuItem mnuViewGraph;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteGraph;
        private System.Windows.Forms.CheckBox chkRemoveOldTasks;
        private System.Windows.Forms.ToolStripMenuItem mnuPreviewGraph;
        private System.Windows.Forms.ToolStripMenuItem mnuCountTriples;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyGraphTo;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyGraph;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveGraphTo;
        private System.Windows.Forms.ToolStripMenuItem mnuRenameGraph;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.PropertyGrid propInfo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.ListView lvwStores;
        private System.Windows.Forms.ColumnHeader colStoreID;
        private System.Windows.Forms.Button btnRefreshStores;
        private System.Windows.Forms.ContextMenuStrip mnuStores;
        private System.Windows.Forms.ToolStripMenuItem mnuNewStore;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenStore;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteStore;
        private System.Windows.Forms.TableLayoutPanel tableForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableQueryTab;
        private System.Windows.Forms.NumericUpDown numPageSize;
        private System.Windows.Forms.CheckBox chkPageQuery;
        private System.Windows.Forms.Button btnLoadQuery;
        private System.Windows.Forms.Button btnSaveQuery;
        private System.Windows.Forms.Button btnSparqlQuery;
        private System.Windows.Forms.TableLayoutPanel tableUpdateTab;
        private System.Windows.Forms.Panel panel2;
    }
}