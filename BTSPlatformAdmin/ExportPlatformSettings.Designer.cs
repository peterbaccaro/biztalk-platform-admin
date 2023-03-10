namespace BTSPlatformAdmin
{
    partial class ExportPlatformSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportPlatformSettings));
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ExportPlatformSettingsWizard = new Gui.Wizard.Wizard();
            this.wizardPageExportProcess = new Gui.Wizard.WizardPage();
            this.lblExportProgress = new System.Windows.Forms.Label();
            this.wizardHeaderExportProcess = new Gui.Wizard.Header();
            this.progressBarExport = new System.Windows.Forms.ProgressBar();
            this.wizardPageExportFile = new Gui.Wizard.WizardPage();
            this.wizardHeaderExportFile = new Gui.Wizard.Header();
            this.btnExportFileBrowse = new System.Windows.Forms.Button();
            this.txtExportFilePath = new System.Windows.Forms.TextBox();
            this.lblExportFilePath = new System.Windows.Forms.Label();
            this.wizardPageAdapters = new Gui.Wizard.WizardPage();
            this.lblAdapters = new System.Windows.Forms.Label();
            this.checkedListBoxAdapters = new System.Windows.Forms.CheckedListBox();
            this.wizardHeaderAdapters = new Gui.Wizard.Header();
            this.wizardPageHosts = new Gui.Wizard.WizardPage();
            this.lblHosts = new System.Windows.Forms.Label();
            this.checkedListBoxHosts = new System.Windows.Forms.CheckedListBox();
            this.wizardHeaderHosts = new Gui.Wizard.Header();
            this.wizardPageWelcome = new Gui.Wizard.WizardPage();
            this.wizardInfoPageWelcome = new Gui.Wizard.InfoPage();
            this.wizardPageFinish = new Gui.Wizard.WizardPage();
            this.wizardInfoPageFinish = new Gui.Wizard.InfoPage();
            this.ExportPlatformSettingsWizard.SuspendLayout();
            this.wizardPageExportProcess.SuspendLayout();
            this.wizardPageExportFile.SuspendLayout();
            this.wizardPageAdapters.SuspendLayout();
            this.wizardPageHosts.SuspendLayout();
            this.wizardPageWelcome.SuspendLayout();
            this.wizardPageFinish.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExportPlatformSettingsWizard
            // 
            this.ExportPlatformSettingsWizard.Controls.Add(this.wizardPageWelcome);
            this.ExportPlatformSettingsWizard.Controls.Add(this.wizardPageFinish);
            this.ExportPlatformSettingsWizard.Controls.Add(this.wizardPageExportProcess);
            this.ExportPlatformSettingsWizard.Controls.Add(this.wizardPageExportFile);
            this.ExportPlatformSettingsWizard.Controls.Add(this.wizardPageAdapters);
            this.ExportPlatformSettingsWizard.Controls.Add(this.wizardPageHosts);
            this.ExportPlatformSettingsWizard.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportPlatformSettingsWizard.Location = new System.Drawing.Point(2, 1);
            this.ExportPlatformSettingsWizard.Name = "ExportPlatformSettingsWizard";
            this.ExportPlatformSettingsWizard.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.wizardPageWelcome,
            this.wizardPageHosts,
            this.wizardPageAdapters,
            this.wizardPageExportFile,
            this.wizardPageExportProcess,
            this.wizardPageFinish});
            this.ExportPlatformSettingsWizard.Size = new System.Drawing.Size(506, 376);
            this.ExportPlatformSettingsWizard.TabIndex = 0;
            this.ExportPlatformSettingsWizard.Load += new System.EventHandler(this.ExportPlatformSettingsWizard_Load);
            // 
            // wizardPageExportProcess
            // 
            this.wizardPageExportProcess.Controls.Add(this.lblExportProgress);
            this.wizardPageExportProcess.Controls.Add(this.wizardHeaderExportProcess);
            this.wizardPageExportProcess.Controls.Add(this.progressBarExport);
            this.wizardPageExportProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageExportProcess.IsFinishPage = false;
            this.wizardPageExportProcess.Location = new System.Drawing.Point(0, 0);
            this.wizardPageExportProcess.Name = "wizardPageExportProcess";
            this.wizardPageExportProcess.Size = new System.Drawing.Size(506, 328);
            this.wizardPageExportProcess.TabIndex = 5;
            this.wizardPageExportProcess.ShowFromNext += new System.EventHandler(this.wizardPageExportProcess_ShowFromNext);
            // 
            // lblExportProgress
            // 
            this.lblExportProgress.AutoSize = true;
            this.lblExportProgress.Location = new System.Drawing.Point(11, 81);
            this.lblExportProgress.Name = "lblExportProgress";
            this.lblExportProgress.Size = new System.Drawing.Size(53, 13);
            this.lblExportProgress.TabIndex = 7;
            this.lblExportProgress.Text = "Progress:";
            // 
            // wizardHeaderExportProcess
            // 
            this.wizardHeaderExportProcess.BackColor = System.Drawing.SystemColors.Control;
            this.wizardHeaderExportProcess.CausesValidation = false;
            this.wizardHeaderExportProcess.Description = "BizTalk platform settings are being exported.";
            this.wizardHeaderExportProcess.Image = ((System.Drawing.Image)(resources.GetObject("wizardHeaderExportProcess.Image")));
            this.wizardHeaderExportProcess.Location = new System.Drawing.Point(0, 0);
            this.wizardHeaderExportProcess.Name = "wizardHeaderExportProcess";
            this.wizardHeaderExportProcess.Size = new System.Drawing.Size(503, 64);
            this.wizardHeaderExportProcess.TabIndex = 6;
            this.wizardHeaderExportProcess.Title = "Export Process";
            // 
            // progressBarExport
            // 
            this.progressBarExport.Location = new System.Drawing.Point(11, 100);
            this.progressBarExport.Name = "progressBarExport";
            this.progressBarExport.Size = new System.Drawing.Size(485, 23);
            this.progressBarExport.TabIndex = 0;
            // 
            // wizardPageExportFile
            // 
            this.wizardPageExportFile.Controls.Add(this.wizardHeaderExportFile);
            this.wizardPageExportFile.Controls.Add(this.btnExportFileBrowse);
            this.wizardPageExportFile.Controls.Add(this.txtExportFilePath);
            this.wizardPageExportFile.Controls.Add(this.lblExportFilePath);
            this.wizardPageExportFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageExportFile.IsFinishPage = false;
            this.wizardPageExportFile.Location = new System.Drawing.Point(0, 0);
            this.wizardPageExportFile.Name = "wizardPageExportFile";
            this.wizardPageExportFile.Size = new System.Drawing.Size(506, 328);
            this.wizardPageExportFile.TabIndex = 4;
            this.wizardPageExportFile.CloseFromNext += new Gui.Wizard.PageEventHandler(this.wizardPageExportFile_CloseFromNext);
            // 
            // wizardHeaderExportFile
            // 
            this.wizardHeaderExportFile.BackColor = System.Drawing.SystemColors.Control;
            this.wizardHeaderExportFile.CausesValidation = false;
            this.wizardHeaderExportFile.Description = "Specify the export file path.";
            this.wizardHeaderExportFile.Image = ((System.Drawing.Image)(resources.GetObject("wizardHeaderExportFile.Image")));
            this.wizardHeaderExportFile.Location = new System.Drawing.Point(0, 0);
            this.wizardHeaderExportFile.Name = "wizardHeaderExportFile";
            this.wizardHeaderExportFile.Size = new System.Drawing.Size(506, 64);
            this.wizardHeaderExportFile.TabIndex = 3;
            this.wizardHeaderExportFile.Title = "Export File";
            // 
            // btnExportFileBrowse
            // 
            this.btnExportFileBrowse.Location = new System.Drawing.Point(417, 125);
            this.btnExportFileBrowse.Name = "btnExportFileBrowse";
            this.btnExportFileBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnExportFileBrowse.TabIndex = 2;
            this.btnExportFileBrowse.Text = "&Browse";
            this.btnExportFileBrowse.UseVisualStyleBackColor = true;
            this.btnExportFileBrowse.Click += new System.EventHandler(this.btnExportFileBrowse_Click);
            // 
            // txtExportFilePath
            // 
            this.txtExportFilePath.Location = new System.Drawing.Point(10, 98);
            this.txtExportFilePath.Name = "txtExportFilePath";
            this.txtExportFilePath.Size = new System.Drawing.Size(482, 21);
            this.txtExportFilePath.TabIndex = 1;
            // 
            // lblExportFilePath
            // 
            this.lblExportFilePath.AutoSize = true;
            this.lblExportFilePath.Location = new System.Drawing.Point(10, 82);
            this.lblExportFilePath.Name = "lblExportFilePath";
            this.lblExportFilePath.Size = new System.Drawing.Size(87, 13);
            this.lblExportFilePath.TabIndex = 0;
            this.lblExportFilePath.Text = "Export File Path:";
            // 
            // wizardPageAdapters
            // 
            this.wizardPageAdapters.Controls.Add(this.lblAdapters);
            this.wizardPageAdapters.Controls.Add(this.checkedListBoxAdapters);
            this.wizardPageAdapters.Controls.Add(this.wizardHeaderAdapters);
            this.wizardPageAdapters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageAdapters.IsFinishPage = false;
            this.wizardPageAdapters.Location = new System.Drawing.Point(0, 0);
            this.wizardPageAdapters.Name = "wizardPageAdapters";
            this.wizardPageAdapters.Size = new System.Drawing.Size(506, 328);
            this.wizardPageAdapters.TabIndex = 3;
            // 
            // lblAdapters
            // 
            this.lblAdapters.AutoSize = true;
            this.lblAdapters.Location = new System.Drawing.Point(36, 81);
            this.lblAdapters.Name = "lblAdapters";
            this.lblAdapters.Size = new System.Drawing.Size(55, 13);
            this.lblAdapters.TabIndex = 3;
            this.lblAdapters.Text = "Adapters:";
            // 
            // checkedListBoxAdapters
            // 
            this.checkedListBoxAdapters.CheckOnClick = true;
            this.checkedListBoxAdapters.FormattingEnabled = true;
            this.checkedListBoxAdapters.Location = new System.Drawing.Point(107, 81);
            this.checkedListBoxAdapters.Name = "checkedListBoxAdapters";
            this.checkedListBoxAdapters.Size = new System.Drawing.Size(276, 228);
            this.checkedListBoxAdapters.TabIndex = 1;
            // 
            // wizardHeaderAdapters
            // 
            this.wizardHeaderAdapters.BackColor = System.Drawing.SystemColors.Control;
            this.wizardHeaderAdapters.CausesValidation = false;
            this.wizardHeaderAdapters.Description = "Select the Adapters to Export";
            this.wizardHeaderAdapters.Image = ((System.Drawing.Image)(resources.GetObject("wizardHeaderAdapters.Image")));
            this.wizardHeaderAdapters.Location = new System.Drawing.Point(0, 0);
            this.wizardHeaderAdapters.Name = "wizardHeaderAdapters";
            this.wizardHeaderAdapters.Size = new System.Drawing.Size(506, 64);
            this.wizardHeaderAdapters.TabIndex = 0;
            this.wizardHeaderAdapters.Title = "Adapters";
            // 
            // wizardPageHosts
            // 
            this.wizardPageHosts.Controls.Add(this.lblHosts);
            this.wizardPageHosts.Controls.Add(this.checkedListBoxHosts);
            this.wizardPageHosts.Controls.Add(this.wizardHeaderHosts);
            this.wizardPageHosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageHosts.IsFinishPage = false;
            this.wizardPageHosts.Location = new System.Drawing.Point(0, 0);
            this.wizardPageHosts.Name = "wizardPageHosts";
            this.wizardPageHosts.Size = new System.Drawing.Size(506, 328);
            this.wizardPageHosts.TabIndex = 2;
            // 
            // lblHosts
            // 
            this.lblHosts.AutoSize = true;
            this.lblHosts.Location = new System.Drawing.Point(36, 81);
            this.lblHosts.Name = "lblHosts";
            this.lblHosts.Size = new System.Drawing.Size(38, 13);
            this.lblHosts.TabIndex = 2;
            this.lblHosts.Text = "Hosts:";
            // 
            // checkedListBoxHosts
            // 
            this.checkedListBoxHosts.CheckOnClick = true;
            this.checkedListBoxHosts.FormattingEnabled = true;
            this.checkedListBoxHosts.Location = new System.Drawing.Point(107, 81);
            this.checkedListBoxHosts.Name = "checkedListBoxHosts";
            this.checkedListBoxHosts.Size = new System.Drawing.Size(276, 228);
            this.checkedListBoxHosts.TabIndex = 1;
            // 
            // wizardHeaderHosts
            // 
            this.wizardHeaderHosts.BackColor = System.Drawing.SystemColors.Control;
            this.wizardHeaderHosts.CausesValidation = false;
            this.wizardHeaderHosts.Description = "Select the Hosts to Export";
            this.wizardHeaderHosts.Image = ((System.Drawing.Image)(resources.GetObject("wizardHeaderHosts.Image")));
            this.wizardHeaderHosts.Location = new System.Drawing.Point(0, 0);
            this.wizardHeaderHosts.Name = "wizardHeaderHosts";
            this.wizardHeaderHosts.Size = new System.Drawing.Size(506, 64);
            this.wizardHeaderHosts.TabIndex = 0;
            this.wizardHeaderHosts.Title = "Hosts";
            // 
            // wizardPageWelcome
            // 
            this.wizardPageWelcome.Controls.Add(this.wizardInfoPageWelcome);
            this.wizardPageWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageWelcome.IsFinishPage = false;
            this.wizardPageWelcome.Location = new System.Drawing.Point(0, 0);
            this.wizardPageWelcome.Name = "wizardPageWelcome";
            this.wizardPageWelcome.Size = new System.Drawing.Size(506, 328);
            this.wizardPageWelcome.TabIndex = 1;
            // 
            // wizardInfoPageWelcome
            // 
            this.wizardInfoPageWelcome.BackColor = System.Drawing.Color.White;
            this.wizardInfoPageWelcome.Image = ((System.Drawing.Image)(resources.GetObject("wizardInfoPageWelcome.Image")));
            this.wizardInfoPageWelcome.Location = new System.Drawing.Point(0, 0);
            this.wizardInfoPageWelcome.Name = "wizardInfoPageWelcome";
            this.wizardInfoPageWelcome.PageText = "This wizard enables you to export BizTalk platforms setting to a file.";
            this.wizardInfoPageWelcome.PageTitle = "Welcome to the Export Platform Settings Wizard";
            this.wizardInfoPageWelcome.Size = new System.Drawing.Size(503, 325);
            this.wizardInfoPageWelcome.TabIndex = 0;
            // 
            // wizardPageFinish
            // 
            this.wizardPageFinish.Controls.Add(this.wizardInfoPageFinish);
            this.wizardPageFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageFinish.IsFinishPage = false;
            this.wizardPageFinish.Location = new System.Drawing.Point(0, 0);
            this.wizardPageFinish.Name = "wizardPageFinish";
            this.wizardPageFinish.Size = new System.Drawing.Size(506, 328);
            this.wizardPageFinish.TabIndex = 6;
            // 
            // wizardInfoPageFinish
            // 
            this.wizardInfoPageFinish.BackColor = System.Drawing.Color.White;
            this.wizardInfoPageFinish.Image = ((System.Drawing.Image)(resources.GetObject("wizardInfoPageFinish.Image")));
            this.wizardInfoPageFinish.Location = new System.Drawing.Point(0, 0);
            this.wizardInfoPageFinish.Name = "wizardInfoPageFinish";
            this.wizardInfoPageFinish.PageText = "You have successfully exported the platform settings. To close this wizard, click" +
                " Finish.";
            this.wizardInfoPageFinish.PageTitle = "Completing the Export Platform Settings Wizard";
            this.wizardInfoPageFinish.Size = new System.Drawing.Size(503, 325);
            this.wizardInfoPageFinish.TabIndex = 1;
            // 
            // ExportPlatformSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 369);
            this.Controls.Add(this.ExportPlatformSettingsWizard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportPlatformSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export Platform Settings";
            this.ExportPlatformSettingsWizard.ResumeLayout(false);
            this.wizardPageExportProcess.ResumeLayout(false);
            this.wizardPageExportProcess.PerformLayout();
            this.wizardPageExportFile.ResumeLayout(false);
            this.wizardPageExportFile.PerformLayout();
            this.wizardPageAdapters.ResumeLayout(false);
            this.wizardPageAdapters.PerformLayout();
            this.wizardPageHosts.ResumeLayout(false);
            this.wizardPageHosts.PerformLayout();
            this.wizardPageWelcome.ResumeLayout(false);
            this.wizardPageFinish.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard ExportPlatformSettingsWizard;
        private Gui.Wizard.WizardPage wizardPageExportProcess;
        private Gui.Wizard.WizardPage wizardPageExportFile;
        private Gui.Wizard.WizardPage wizardPageAdapters;
        private Gui.Wizard.WizardPage wizardPageHosts;
        private Gui.Wizard.WizardPage wizardPageWelcome;
        private Gui.Wizard.InfoPage wizardInfoPageWelcome;
        private System.Windows.Forms.CheckedListBox checkedListBoxHosts;
        private Gui.Wizard.Header wizardHeaderHosts;
        private System.Windows.Forms.Label lblHosts;
        private Gui.Wizard.Header wizardHeaderAdapters;
        private System.Windows.Forms.Label lblAdapters;
        private System.Windows.Forms.CheckedListBox checkedListBoxAdapters;
        private System.Windows.Forms.Button btnExportFileBrowse;
        private System.Windows.Forms.TextBox txtExportFilePath;
        private System.Windows.Forms.Label lblExportFilePath;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Gui.Wizard.Header wizardHeaderExportFile;
        private System.Windows.Forms.ProgressBar progressBarExport;
        private Gui.Wizard.WizardPage wizardPageFinish;
        private Gui.Wizard.Header wizardHeaderExportProcess;
        private System.Windows.Forms.Label lblExportProgress;
        private Gui.Wizard.InfoPage wizardInfoPageFinish;
    }
}