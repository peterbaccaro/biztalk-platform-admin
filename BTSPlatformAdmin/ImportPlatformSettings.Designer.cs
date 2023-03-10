namespace BTSPlatformAdmin
{
    partial class ImportPlatformSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportPlatformSettings));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.imageListGrid = new System.Windows.Forms.ImageList(this.components);
            this.ImportPlatformSettingsWizard = new Gui.Wizard.Wizard();
            this.wizardPageWelcome = new Gui.Wizard.WizardPage();
            this.wizardInfoPageWelcome = new Gui.Wizard.InfoPage();
            this.wizardPageFinish = new Gui.Wizard.WizardPage();
            this.wizardInfoPageFinish = new Gui.Wizard.InfoPage();
            this.wizardPageProgress = new Gui.Wizard.WizardPage();
            this.listViewProgress = new System.Windows.Forms.ListView();
            this.wizardHeaderImportProcess = new Gui.Wizard.Header();
            this.wizardPageLogonCredentials = new Gui.Wizard.WizardPage();
            this.dataGridLogonCredentials = new System.Windows.Forms.DataGridView();
            this.wizardHeaderLogonCredentials = new Gui.Wizard.Header();
            this.wizardPageWindowsGroups = new Gui.Wizard.WizardPage();
            this.dataGridWindowsGroups = new System.Windows.Forms.DataGridView();
            this.wizardHeaderWindowsGroups = new Gui.Wizard.Header();
            this.wizardPageImportFile = new Gui.Wizard.WizardPage();
            this.btnImportFileBrowse = new System.Windows.Forms.Button();
            this.txtImportFilePath = new System.Windows.Forms.TextBox();
            this.lblImportFilePath = new System.Windows.Forms.Label();
            this.wizardHeaderImportFile = new Gui.Wizard.Header();
            this.ImportPlatformSettingsWizard.SuspendLayout();
            this.wizardPageWelcome.SuspendLayout();
            this.wizardPageFinish.SuspendLayout();
            this.wizardPageProgress.SuspendLayout();
            this.wizardPageLogonCredentials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLogonCredentials)).BeginInit();
            this.wizardPageWindowsGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWindowsGroups)).BeginInit();
            this.wizardPageImportFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListGrid
            // 
            this.imageListGrid.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListGrid.ImageStream")));
            this.imageListGrid.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListGrid.Images.SetKeyName(0, "NTGroup.jpg");
            this.imageListGrid.Images.SetKeyName(1, "NTUser.jpg");
            this.imageListGrid.Images.SetKeyName(2, "GridSuccess.png");
            this.imageListGrid.Images.SetKeyName(3, "GridError.png");
            // 
            // ImportPlatformSettingsWizard
            // 
            this.ImportPlatformSettingsWizard.Controls.Add(this.wizardPageWelcome);
            this.ImportPlatformSettingsWizard.Controls.Add(this.wizardPageFinish);
            this.ImportPlatformSettingsWizard.Controls.Add(this.wizardPageProgress);
            this.ImportPlatformSettingsWizard.Controls.Add(this.wizardPageLogonCredentials);
            this.ImportPlatformSettingsWizard.Controls.Add(this.wizardPageWindowsGroups);
            this.ImportPlatformSettingsWizard.Controls.Add(this.wizardPageImportFile);
            this.ImportPlatformSettingsWizard.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportPlatformSettingsWizard.Location = new System.Drawing.Point(0, 0);
            this.ImportPlatformSettingsWizard.Name = "ImportPlatformSettingsWizard";
            this.ImportPlatformSettingsWizard.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.wizardPageWelcome,
            this.wizardPageImportFile,
            this.wizardPageWindowsGroups,
            this.wizardPageLogonCredentials,
            this.wizardPageProgress,
            this.wizardPageFinish});
            this.ImportPlatformSettingsWizard.Size = new System.Drawing.Size(506, 376);
            this.ImportPlatformSettingsWizard.TabIndex = 0;
            this.ImportPlatformSettingsWizard.Load += new System.EventHandler(this.ImportPlatformSettingsWizard_Load);
            // 
            // wizardPageWelcome
            // 
            this.wizardPageWelcome.Controls.Add(this.wizardInfoPageWelcome);
            this.wizardPageWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageWelcome.IsFinishPage = false;
            this.wizardPageWelcome.Location = new System.Drawing.Point(0, 0);
            this.wizardPageWelcome.Name = "wizardPageWelcome";
            this.wizardPageWelcome.Size = new System.Drawing.Size(506, 328);
            this.wizardPageWelcome.TabIndex = 2;
            // 
            // wizardInfoPageWelcome
            // 
            this.wizardInfoPageWelcome.BackColor = System.Drawing.Color.White;
            this.wizardInfoPageWelcome.Image = ((System.Drawing.Image)(resources.GetObject("wizardInfoPageWelcome.Image")));
            this.wizardInfoPageWelcome.Location = new System.Drawing.Point(2, 2);
            this.wizardInfoPageWelcome.Name = "wizardInfoPageWelcome";
            this.wizardInfoPageWelcome.PageText = "This wizard enables you to import BizTalk platforms setting from a file.";
            this.wizardInfoPageWelcome.PageTitle = "Welcome to the Import Platform Settings Wizard";
            this.wizardInfoPageWelcome.Size = new System.Drawing.Size(503, 325);
            this.wizardInfoPageWelcome.TabIndex = 2;
            // 
            // wizardPageFinish
            // 
            this.wizardPageFinish.Controls.Add(this.wizardInfoPageFinish);
            this.wizardPageFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageFinish.IsFinishPage = false;
            this.wizardPageFinish.Location = new System.Drawing.Point(0, 0);
            this.wizardPageFinish.Name = "wizardPageFinish";
            this.wizardPageFinish.Size = new System.Drawing.Size(506, 328);
            this.wizardPageFinish.TabIndex = 7;
            // 
            // wizardInfoPageFinish
            // 
            this.wizardInfoPageFinish.BackColor = System.Drawing.Color.White;
            this.wizardInfoPageFinish.Image = ((System.Drawing.Image)(resources.GetObject("wizardInfoPageFinish.Image")));
            this.wizardInfoPageFinish.Location = new System.Drawing.Point(2, 2);
            this.wizardInfoPageFinish.Name = "wizardInfoPageFinish";
            this.wizardInfoPageFinish.PageText = "To close this wizard, click Finish.";
            this.wizardInfoPageFinish.PageTitle = "Completing the Import Platform Settings Wizard";
            this.wizardInfoPageFinish.Size = new System.Drawing.Size(503, 325);
            this.wizardInfoPageFinish.TabIndex = 2;
            // 
            // wizardPageProgress
            // 
            this.wizardPageProgress.Controls.Add(this.listViewProgress);
            this.wizardPageProgress.Controls.Add(this.wizardHeaderImportProcess);
            this.wizardPageProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageProgress.IsFinishPage = false;
            this.wizardPageProgress.Location = new System.Drawing.Point(0, 0);
            this.wizardPageProgress.Name = "wizardPageProgress";
            this.wizardPageProgress.Size = new System.Drawing.Size(506, 328);
            this.wizardPageProgress.TabIndex = 6;
            this.wizardPageProgress.ShowFromNext += new System.EventHandler(this.wizardPageProgress_ShowFromNext);
            // 
            // listViewProgress
            // 
            this.listViewProgress.Location = new System.Drawing.Point(12, 71);
            this.listViewProgress.Name = "listViewProgress";
            this.listViewProgress.Size = new System.Drawing.Size(485, 243);
            this.listViewProgress.TabIndex = 8;
            this.listViewProgress.UseCompatibleStateImageBehavior = false;
            this.listViewProgress.View = System.Windows.Forms.View.Details;
            // 
            // wizardHeaderImportProcess
            // 
            this.wizardHeaderImportProcess.BackColor = System.Drawing.SystemColors.Control;
            this.wizardHeaderImportProcess.CausesValidation = false;
            this.wizardHeaderImportProcess.Description = "BizTalk platform settings are being imported.";
            this.wizardHeaderImportProcess.Image = ((System.Drawing.Image)(resources.GetObject("wizardHeaderImportProcess.Image")));
            this.wizardHeaderImportProcess.Location = new System.Drawing.Point(0, 0);
            this.wizardHeaderImportProcess.Name = "wizardHeaderImportProcess";
            this.wizardHeaderImportProcess.Size = new System.Drawing.Size(503, 64);
            this.wizardHeaderImportProcess.TabIndex = 7;
            this.wizardHeaderImportProcess.Title = "Import Process";
            // 
            // wizardPageLogonCredentials
            // 
            this.wizardPageLogonCredentials.Controls.Add(this.dataGridLogonCredentials);
            this.wizardPageLogonCredentials.Controls.Add(this.wizardHeaderLogonCredentials);
            this.wizardPageLogonCredentials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageLogonCredentials.IsFinishPage = false;
            this.wizardPageLogonCredentials.Location = new System.Drawing.Point(0, 0);
            this.wizardPageLogonCredentials.Name = "wizardPageLogonCredentials";
            this.wizardPageLogonCredentials.Size = new System.Drawing.Size(506, 328);
            this.wizardPageLogonCredentials.TabIndex = 5;
            this.wizardPageLogonCredentials.CloseFromNext += new Gui.Wizard.PageEventHandler(this.wizardPageLogonCredentials_CloseFromNext);
            // 
            // dataGridLogonCredentials
            // 
            this.dataGridLogonCredentials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLogonCredentials.Location = new System.Drawing.Point(10, 82);
            this.dataGridLogonCredentials.Name = "dataGridLogonCredentials";
            this.dataGridLogonCredentials.Size = new System.Drawing.Size(487, 228);
            this.dataGridLogonCredentials.TabIndex = 4;
            // 
            // wizardHeaderLogonCredentials
            // 
            this.wizardHeaderLogonCredentials.BackColor = System.Drawing.SystemColors.Control;
            this.wizardHeaderLogonCredentials.CausesValidation = false;
            this.wizardHeaderLogonCredentials.Description = "Specify the host instance logon credentials to use.";
            this.wizardHeaderLogonCredentials.Image = ((System.Drawing.Image)(resources.GetObject("wizardHeaderLogonCredentials.Image")));
            this.wizardHeaderLogonCredentials.Location = new System.Drawing.Point(0, 0);
            this.wizardHeaderLogonCredentials.Name = "wizardHeaderLogonCredentials";
            this.wizardHeaderLogonCredentials.Size = new System.Drawing.Size(506, 64);
            this.wizardHeaderLogonCredentials.TabIndex = 3;
            this.wizardHeaderLogonCredentials.Title = "Logon Credentials";
            // 
            // wizardPageWindowsGroups
            // 
            this.wizardPageWindowsGroups.Controls.Add(this.dataGridWindowsGroups);
            this.wizardPageWindowsGroups.Controls.Add(this.wizardHeaderWindowsGroups);
            this.wizardPageWindowsGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageWindowsGroups.IsFinishPage = false;
            this.wizardPageWindowsGroups.Location = new System.Drawing.Point(0, 0);
            this.wizardPageWindowsGroups.Name = "wizardPageWindowsGroups";
            this.wizardPageWindowsGroups.Size = new System.Drawing.Size(506, 328);
            this.wizardPageWindowsGroups.TabIndex = 4;
            this.wizardPageWindowsGroups.CloseFromNext += new Gui.Wizard.PageEventHandler(this.wizardPageWindowsGroups_CloseFromNext);
            // 
            // dataGridWindowsGroups
            // 
            this.dataGridWindowsGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridWindowsGroups.Location = new System.Drawing.Point(10, 82);
            this.dataGridWindowsGroups.Name = "dataGridWindowsGroups";
            this.dataGridWindowsGroups.Size = new System.Drawing.Size(487, 140);
            this.dataGridWindowsGroups.TabIndex = 3;
            // 
            // wizardHeaderWindowsGroups
            // 
            this.wizardHeaderWindowsGroups.BackColor = System.Drawing.SystemColors.Control;
            this.wizardHeaderWindowsGroups.CausesValidation = false;
            this.wizardHeaderWindowsGroups.Description = "Specify the Windows groups to use.";
            this.wizardHeaderWindowsGroups.Image = ((System.Drawing.Image)(resources.GetObject("wizardHeaderWindowsGroups.Image")));
            this.wizardHeaderWindowsGroups.Location = new System.Drawing.Point(0, 0);
            this.wizardHeaderWindowsGroups.Name = "wizardHeaderWindowsGroups";
            this.wizardHeaderWindowsGroups.Size = new System.Drawing.Size(506, 64);
            this.wizardHeaderWindowsGroups.TabIndex = 2;
            this.wizardHeaderWindowsGroups.Title = "Windows Groups";
            // 
            // wizardPageImportFile
            // 
            this.wizardPageImportFile.Controls.Add(this.btnImportFileBrowse);
            this.wizardPageImportFile.Controls.Add(this.txtImportFilePath);
            this.wizardPageImportFile.Controls.Add(this.lblImportFilePath);
            this.wizardPageImportFile.Controls.Add(this.wizardHeaderImportFile);
            this.wizardPageImportFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageImportFile.IsFinishPage = false;
            this.wizardPageImportFile.Location = new System.Drawing.Point(0, 0);
            this.wizardPageImportFile.Name = "wizardPageImportFile";
            this.wizardPageImportFile.Size = new System.Drawing.Size(506, 328);
            this.wizardPageImportFile.TabIndex = 3;
            this.wizardPageImportFile.CloseFromNext += new Gui.Wizard.PageEventHandler(this.wizardPageImportFile_CloseFromNext);
            // 
            // btnImportFileBrowse
            // 
            this.btnImportFileBrowse.Location = new System.Drawing.Point(417, 125);
            this.btnImportFileBrowse.Name = "btnImportFileBrowse";
            this.btnImportFileBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnImportFileBrowse.TabIndex = 5;
            this.btnImportFileBrowse.Text = "&Browse";
            this.btnImportFileBrowse.UseVisualStyleBackColor = true;
            this.btnImportFileBrowse.Click += new System.EventHandler(this.btnImportFileBrowse_Click);
            // 
            // txtImportFilePath
            // 
            this.txtImportFilePath.Location = new System.Drawing.Point(10, 98);
            this.txtImportFilePath.Name = "txtImportFilePath";
            this.txtImportFilePath.Size = new System.Drawing.Size(482, 21);
            this.txtImportFilePath.TabIndex = 4;
            // 
            // lblImportFilePath
            // 
            this.lblImportFilePath.AutoSize = true;
            this.lblImportFilePath.Location = new System.Drawing.Point(10, 82);
            this.lblImportFilePath.Name = "lblImportFilePath";
            this.lblImportFilePath.Size = new System.Drawing.Size(87, 13);
            this.lblImportFilePath.TabIndex = 3;
            this.lblImportFilePath.Text = "Import File Path:";
            // 
            // wizardHeaderImportFile
            // 
            this.wizardHeaderImportFile.BackColor = System.Drawing.SystemColors.Control;
            this.wizardHeaderImportFile.CausesValidation = false;
            this.wizardHeaderImportFile.Description = "Specify the import file path.";
            this.wizardHeaderImportFile.Image = ((System.Drawing.Image)(resources.GetObject("wizardHeaderImportFile.Image")));
            this.wizardHeaderImportFile.Location = new System.Drawing.Point(0, 0);
            this.wizardHeaderImportFile.Name = "wizardHeaderImportFile";
            this.wizardHeaderImportFile.Size = new System.Drawing.Size(506, 64);
            this.wizardHeaderImportFile.TabIndex = 1;
            this.wizardHeaderImportFile.Title = "Import File";
            // 
            // ImportPlatformSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 369);
            this.Controls.Add(this.ImportPlatformSettingsWizard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportPlatformSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Platform Settings";
            this.ImportPlatformSettingsWizard.ResumeLayout(false);
            this.wizardPageWelcome.ResumeLayout(false);
            this.wizardPageFinish.ResumeLayout(false);
            this.wizardPageProgress.ResumeLayout(false);
            this.wizardPageLogonCredentials.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLogonCredentials)).EndInit();
            this.wizardPageWindowsGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWindowsGroups)).EndInit();
            this.wizardPageImportFile.ResumeLayout(false);
            this.wizardPageImportFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard ImportPlatformSettingsWizard;
        private Gui.Wizard.WizardPage wizardPageWelcome;
        private Gui.Wizard.InfoPage wizardInfoPageWelcome;
        private Gui.Wizard.WizardPage wizardPageImportFile;
        private Gui.Wizard.WizardPage wizardPageWindowsGroups;
        private Gui.Wizard.WizardPage wizardPageLogonCredentials;
        private Gui.Wizard.WizardPage wizardPageProgress;
        private Gui.Wizard.WizardPage wizardPageFinish;
        private Gui.Wizard.Header wizardHeaderImportFile;
        private System.Windows.Forms.Button btnImportFileBrowse;
        private System.Windows.Forms.TextBox txtImportFilePath;
        private System.Windows.Forms.Label lblImportFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Gui.Wizard.Header wizardHeaderWindowsGroups;
        private System.Windows.Forms.DataGridView dataGridWindowsGroups;
        private System.Windows.Forms.ImageList imageListGrid;
        private Gui.Wizard.Header wizardHeaderLogonCredentials;
        private System.Windows.Forms.DataGridView dataGridLogonCredentials;
        private Gui.Wizard.Header wizardHeaderImportProcess;
        private Gui.Wizard.InfoPage wizardInfoPageFinish;
        private System.Windows.Forms.ListView listViewProgress;

    }
}