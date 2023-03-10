namespace BTSPlatformAdmin
{
    partial class BTSPlatformAdmin
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Hosts", 4, 4);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Host Instances", 5, 5);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Adapters", 6, 6);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Platform Settings", 3, 3, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("BizTalk Group", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Console Root", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BTSPlatformAdmin));
            this.treeView = new System.Windows.Forms.TreeView();
            this.imageListTree = new System.Windows.Forms.ImageList(this.components);
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListGrid = new System.Windows.Forms.ImageList(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripImportButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripExportButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripCompareButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripRemoveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripRefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripAboutButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.imageListTitle = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageListTree;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            treeNode1.ImageIndex = 4;
            treeNode1.Name = "Hosts";
            treeNode1.SelectedImageIndex = 4;
            treeNode1.Text = "Hosts";
            treeNode2.ImageIndex = 5;
            treeNode2.Name = "HostInstances";
            treeNode2.SelectedImageIndex = 5;
            treeNode2.Text = "Host Instances";
            treeNode3.ImageIndex = 6;
            treeNode3.Name = "Adapters";
            treeNode3.SelectedImageIndex = 6;
            treeNode3.Text = "Adapters";
            treeNode4.ImageIndex = 3;
            treeNode4.Name = "PlatformSettings";
            treeNode4.SelectedImageIndex = 3;
            treeNode4.Text = "Platform Settings";
            treeNode5.ImageIndex = 2;
            treeNode5.Name = "BizTalkGroup";
            treeNode5.SelectedImageIndex = 2;
            treeNode5.Text = "BizTalk Group";
            treeNode6.ImageIndex = 0;
            treeNode6.Name = "ConsoleRoot";
            treeNode6.SelectedImageIndex = 0;
            treeNode6.Text = "Console Root";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(297, 456);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeView_KeyUp);
            // 
            // imageListTree
            // 
            this.imageListTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTree.ImageStream")));
            this.imageListTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTree.Images.SetKeyName(0, "TreeRoot.jpg");
            this.imageListTree.Images.SetKeyName(1, "TreeBizTalkAdmin.jpg");
            this.imageListTree.Images.SetKeyName(2, "TreeBizTalkGroup.jpg");
            this.imageListTree.Images.SetKeyName(3, "TreePlatformSettings.jpg");
            this.imageListTree.Images.SetKeyName(4, "TreeHosts.jpg");
            this.imageListTree.Images.SetKeyName(5, "TreeHostInstance.jpg");
            this.imageListTree.Images.SetKeyName(6, "TreeAdapters.jpg");
            this.imageListTree.Images.SetKeyName(7, "TreeAdapter.jpg");
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(0, 37);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(409, 419);
            this.listView.SmallImageList = this.imageListGrid;
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            this.listView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView_KeyUp);
            // 
            // imageListGrid
            // 
            this.imageListGrid.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListGrid.ImageStream")));
            this.imageListGrid.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListGrid.Images.SetKeyName(0, "TreeHosts.jpg");
            this.imageListGrid.Images.SetKeyName(1, "TreeHostInstance.jpg");
            this.imageListGrid.Images.SetKeyName(2, "TreeAdapters.jpg");
            this.imageListGrid.Images.SetKeyName(3, "GridHost.jpg");
            this.imageListGrid.Images.SetKeyName(4, "GridHostDefault.jpg");
            this.imageListGrid.Images.SetKeyName(5, "GridHostInstance.jpg");
            this.imageListGrid.Images.SetKeyName(6, "GridAdapter.jpg");
            this.imageListGrid.Images.SetKeyName(7, "GridAdapterHandler.jpg");
            this.imageListGrid.Images.SetKeyName(8, "GridAdapterHandlerDefault.jpg");
            this.imageListGrid.Images.SetKeyName(9, "GridSuccess.png");
            this.imageListGrid.Images.SetKeyName(10, "GridError.png");
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(30, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(50, 24);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title";
            // 
            // picTitle
            // 
            this.picTitle.Image = ((System.Drawing.Image)(resources.GetObject("picTitle.Image")));
            this.picTitle.Location = new System.Drawing.Point(3, 4);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(25, 24);
            this.picTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTitle.TabIndex = 3;
            this.picTitle.TabStop = false;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripImportButton,
            this.toolStripExportButton,
            this.toolStripCompareButton,
            this.toolStripRemoveButton,
            this.toolStripSeparator1,
            this.toolStripRefreshButton,
            this.toolStripSeparator2,
            this.toolStripAboutButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(720, 31);
            this.toolStrip.TabIndex = 4;
            // 
            // toolStripImportButton
            // 
            this.toolStripImportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripImportButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripImportButton.Image")));
            this.toolStripImportButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripImportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripImportButton.Name = "toolStripImportButton";
            this.toolStripImportButton.Size = new System.Drawing.Size(36, 28);
            this.toolStripImportButton.Text = "Import Platform Settings";
            this.toolStripImportButton.Click += new System.EventHandler(this.toolStripImportButton_Click);
            // 
            // toolStripExportButton
            // 
            this.toolStripExportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripExportButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripExportButton.Image")));
            this.toolStripExportButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripExportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExportButton.Name = "toolStripExportButton";
            this.toolStripExportButton.Size = new System.Drawing.Size(36, 28);
            this.toolStripExportButton.Text = "Export Platform Settings";
            this.toolStripExportButton.Click += new System.EventHandler(this.toolStripExportButton_Click);
            // 
            // toolStripCompareButton
            // 
            this.toolStripCompareButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCompareButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCompareButton.Image")));
            this.toolStripCompareButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripCompareButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCompareButton.Name = "toolStripCompareButton";
            this.toolStripCompareButton.Size = new System.Drawing.Size(36, 28);
            this.toolStripCompareButton.Text = "Compare Platform Settings";
            this.toolStripCompareButton.ToolTipText = "Compare Platform Settings";
            this.toolStripCompareButton.Click += new System.EventHandler(this.toolStripCompareButton_Click);
            // 
            // toolStripRemoveButton
            // 
            this.toolStripRemoveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRemoveButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRemoveButton.Image")));
            this.toolStripRemoveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripRemoveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRemoveButton.Name = "toolStripRemoveButton";
            this.toolStripRemoveButton.Size = new System.Drawing.Size(36, 28);
            this.toolStripRemoveButton.Text = "Remove Platform Settings";
            this.toolStripRemoveButton.Visible = false;
            this.toolStripRemoveButton.Click += new System.EventHandler(this.toolStripRemoveButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripRefreshButton
            // 
            this.toolStripRefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRefreshButton.Image")));
            this.toolStripRefreshButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripRefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRefreshButton.Name = "toolStripRefreshButton";
            this.toolStripRefreshButton.Size = new System.Drawing.Size(36, 28);
            this.toolStripRefreshButton.Text = "Refresh";
            this.toolStripRefreshButton.Click += new System.EventHandler(this.toolStripRefreshButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripAboutButton
            // 
            this.toolStripAboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAboutButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAboutButton.Image")));
            this.toolStripAboutButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripAboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAboutButton.Name = "toolStripAboutButton";
            this.toolStripAboutButton.Size = new System.Drawing.Size(36, 28);
            this.toolStripAboutButton.Text = "About";
            this.toolStripAboutButton.Click += new System.EventHandler(this.toolStripAboutButton_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Location = new System.Drawing.Point(3, 34);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lblTitle);
            this.splitContainer.Panel2.Controls.Add(this.picTitle);
            this.splitContainer.Panel2.Controls.Add(this.listView);
            this.splitContainer.Size = new System.Drawing.Size(717, 460);
            this.splitContainer.SplitterDistance = 300;
            this.splitContainer.TabIndex = 5;
            this.splitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            // 
            // imageListTitle
            // 
            this.imageListTitle.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTitle.ImageStream")));
            this.imageListTitle.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTitle.Images.SetKeyName(0, "TitlePlatformSettings.jpg");
            this.imageListTitle.Images.SetKeyName(1, "TitleHosts.jpg");
            this.imageListTitle.Images.SetKeyName(2, "TitleHostInstances.jpg");
            this.imageListTitle.Images.SetKeyName(3, "TitleAdapters.jpg");
            this.imageListTitle.Images.SetKeyName(4, "TitleAdapter.jpg");
            this.imageListTitle.Images.SetKeyName(5, "TitleCompare.jpg");
            // 
            // BTSPlatformAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 497);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BTSPlatformAdmin";
            this.Text = "BizTalk Server Platform Administration";
            this.Load += new System.EventHandler(this.BTSPlatformAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picTitle;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ImageList imageListTree;
        private System.Windows.Forms.ToolStripButton toolStripImportButton;
        private System.Windows.Forms.ToolStripButton toolStripExportButton;
        private System.Windows.Forms.ToolStripButton toolStripAboutButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripRefreshButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ImageList imageListTitle;
        private System.Windows.Forms.ImageList imageListGrid;
        private System.Windows.Forms.ToolStripButton toolStripCompareButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripButton toolStripRemoveButton;
    }
}

