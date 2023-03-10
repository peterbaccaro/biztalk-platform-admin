namespace BTSPlatformAdmin
{
    partial class ComparePlatformSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComparePlatformSettings));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.imageListGrid = new System.Windows.Forms.ImageList(this.components);
            this.ComparePlatformSettingsWizard = new Gui.Wizard.Wizard();
            this.wizardPageWelcome = new Gui.Wizard.WizardPage();
            this.wizardInfoPageWelcome = new Gui.Wizard.InfoPage();
            this.wizardPageFinish = new Gui.Wizard.WizardPage();
            this.wizardInfoPageFinish = new Gui.Wizard.InfoPage();
            this.wizardPageProgress = new Gui.Wizard.WizardPage();
            this.listViewProgress = new System.Windows.Forms.ListView();
            this.wizardHeaderCompareProcess = new Gui.Wizard.Header();
            this.wizardPageCompareFile = new Gui.Wizard.WizardPage();
            this.btnCompareFileBrowse = new System.Windows.Forms.Button();
            this.lblCompareFilePath = new System.Windows.Forms.Label();
            this.txtCompareFilePath = new System.Windows.Forms.TextBox();
            this.wizardHeaderCompareFile = new Gui.Wizard.Header();
            this.ComparePlatformSettingsWizard.SuspendLayout();
            this.wizardPageWelcome.SuspendLayout();
            this.wizardPageFinish.SuspendLayout();
            this.wizardPageProgress.SuspendLayout();
            this.wizardPageCompareFile.SuspendLayout();
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
            // ComparePlatformSettingsWizard
            // 
            this.ComparePlatformSettingsWizard.Controls.Add(this.wizardPageWelcome);
            this.ComparePlatformSettingsWizard.Controls.Add(this.wizardPageFinish);
            this.ComparePlatformSettingsWizard.Controls.Add(this.wizardPageProgress);
            this.ComparePlatformSettingsWizard.Controls.Add(this.wizardPageCompareFile);
            this.ComparePlatformSettingsWizard.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComparePlatformSettingsWizard.Location = new System.Drawing.Point(0, 0);
            this.ComparePlatformSettingsWizard.Name = "ComparePlatformSettingsWizard";
            this.ComparePlatformSettingsWizard.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.wizardPageWelcome,
            this.wizardPageCompareFile,
            this.wizardPageProgress,
            this.wizardPageFinish});
            this.ComparePlatformSettingsWizard.Size = new System.Drawing.Size(506, 376);
            this.ComparePlatformSettingsWizard.TabIndex = 0;
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
            this.wizardInfoPageWelcome.Location = new System.Drawing.Point(2, 2);
            this.wizardInfoPageWelcome.Name = "wizardInfoPageWelcome";
            this.wizardInfoPageWelcome.PageText = "This wizard enables you to compare a settings file against the BizTalk platforms " +
                "settings.";
            this.wizardInfoPageWelcome.PageTitle = "Welcome to the Compare Platform Settings Wizard";
            this.wizardInfoPageWelcome.Size = new System.Drawing.Size(503, 325);
            this.wizardInfoPageWelcome.TabIndex = 3;
            // 
            // wizardPageFinish
            // 
            this.wizardPageFinish.Controls.Add(this.wizardInfoPageFinish);
            this.wizardPageFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageFinish.IsFinishPage = false;
            this.wizardPageFinish.Location = new System.Drawing.Point(0, 0);
            this.wizardPageFinish.Name = "wizardPageFinish";
            this.wizardPageFinish.Size = new System.Drawing.Size(506, 328);
            this.wizardPageFinish.TabIndex = 4;
            // 
            // wizardInfoPageFinish
            // 
            this.wizardInfoPageFinish.BackColor = System.Drawing.Color.White;
            this.wizardInfoPageFinish.Image = ((System.Drawing.Image)(resources.GetObject("wizardInfoPageFinish.Image")));
            this.wizardInfoPageFinish.Location = new System.Drawing.Point(2, 2);
            this.wizardInfoPageFinish.Name = "wizardInfoPageFinish";
            this.wizardInfoPageFinish.PageText = "To close this wizard, click Finish.";
            this.wizardInfoPageFinish.PageTitle = "Completing the Compare Platform Settings Wizard";
            this.wizardInfoPageFinish.Size = new System.Drawing.Size(503, 325);
            this.wizardInfoPageFinish.TabIndex = 3;
            // 
            // wizardPageProgress
            // 
            this.wizardPageProgress.Controls.Add(this.listViewProgress);
            this.wizardPageProgress.Controls.Add(this.wizardHeaderCompareProcess);
            this.wizardPageProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageProgress.IsFinishPage = false;
            this.wizardPageProgress.Location = new System.Drawing.Point(0, 0);
            this.wizardPageProgress.Name = "wizardPageProgress";
            this.wizardPageProgress.Size = new System.Drawing.Size(506, 328);
            this.wizardPageProgress.TabIndex = 3;
            this.wizardPageProgress.ShowFromNext += new System.EventHandler(this.wizardPageProgress_ShowFromNext);
            // 
            // listViewProgress
            // 
            this.listViewProgress.Location = new System.Drawing.Point(12, 71);
            this.listViewProgress.Name = "listViewProgress";
            this.listViewProgress.Size = new System.Drawing.Size(485, 243);
            this.listViewProgress.TabIndex = 9;
            this.listViewProgress.UseCompatibleStateImageBehavior = false;
            this.listViewProgress.View = System.Windows.Forms.View.Details;
            // 
            // wizardHeaderCompareProcess
            // 
            this.wizardHeaderCompareProcess.BackColor = System.Drawing.SystemColors.Control;
            this.wizardHeaderCompareProcess.CausesValidation = false;
            this.wizardHeaderCompareProcess.Description = "BizTalk platform settings are being compared.";
            this.wizardHeaderCompareProcess.Image = ((System.Drawing.Image)(resources.GetObject("wizardHeaderCompareProcess.Image")));
            this.wizardHeaderCompareProcess.Location = new System.Drawing.Point(0, 0);
            this.wizardHeaderCompareProcess.Name = "wizardHeaderCompareProcess";
            this.wizardHeaderCompareProcess.Size = new System.Drawing.Size(503, 64);
            this.wizardHeaderCompareProcess.TabIndex = 8;
            this.wizardHeaderCompareProcess.Title = "Compare Process";
            // 
            // wizardPageCompareFile
            // 
            this.wizardPageCompareFile.Controls.Add(this.btnCompareFileBrowse);
            this.wizardPageCompareFile.Controls.Add(this.lblCompareFilePath);
            this.wizardPageCompareFile.Controls.Add(this.txtCompareFilePath);
            this.wizardPageCompareFile.Controls.Add(this.wizardHeaderCompareFile);
            this.wizardPageCompareFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageCompareFile.IsFinishPage = false;
            this.wizardPageCompareFile.Location = new System.Drawing.Point(0, 0);
            this.wizardPageCompareFile.Name = "wizardPageCompareFile";
            this.wizardPageCompareFile.Size = new System.Drawing.Size(506, 328);
            this.wizardPageCompareFile.TabIndex = 2;
            this.wizardPageCompareFile.CloseFromNext += new Gui.Wizard.PageEventHandler(this.wizardPageCompareFile_CloseFromNext);
            // 
            // btnCompareFileBrowse
            // 
            this.btnCompareFileBrowse.Location = new System.Drawing.Point(417, 125);
            this.btnCompareFileBrowse.Name = "btnCompareFileBrowse";
            this.btnCompareFileBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnCompareFileBrowse.TabIndex = 7;
            this.btnCompareFileBrowse.Text = "&Browse";
            this.btnCompareFileBrowse.UseVisualStyleBackColor = true;
            this.btnCompareFileBrowse.Click += new System.EventHandler(this.btnCompareFileBrowse_Click);
            // 
            // lblCompareFilePath
            // 
            this.lblCompareFilePath.AutoSize = true;
            this.lblCompareFilePath.Location = new System.Drawing.Point(10, 82);
            this.lblCompareFilePath.Name = "lblCompareFilePath";
            this.lblCompareFilePath.Size = new System.Drawing.Size(87, 13);
            this.lblCompareFilePath.TabIndex = 6;
            this.lblCompareFilePath.Text = "Import File Path:";
            // 
            // txtCompareFilePath
            // 
            this.txtCompareFilePath.Location = new System.Drawing.Point(10, 98);
            this.txtCompareFilePath.Name = "txtCompareFilePath";
            this.txtCompareFilePath.Size = new System.Drawing.Size(482, 21);
            this.txtCompareFilePath.TabIndex = 5;
            // 
            // wizardHeaderCompareFile
            // 
            this.wizardHeaderCompareFile.BackColor = System.Drawing.SystemColors.Control;
            this.wizardHeaderCompareFile.CausesValidation = false;
            this.wizardHeaderCompareFile.Description = "Specify the compare file path.";
            this.wizardHeaderCompareFile.Image = ((System.Drawing.Image)(resources.GetObject("wizardHeaderCompareFile.Image")));
            this.wizardHeaderCompareFile.Location = new System.Drawing.Point(0, 0);
            this.wizardHeaderCompareFile.Name = "wizardHeaderCompareFile";
            this.wizardHeaderCompareFile.Size = new System.Drawing.Size(506, 64);
            this.wizardHeaderCompareFile.TabIndex = 2;
            this.wizardHeaderCompareFile.Title = "Compare File";
            // 
            // ComparePlatformSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 369);
            this.Controls.Add(this.ComparePlatformSettingsWizard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComparePlatformSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ComparePlatformSettings";
            this.ComparePlatformSettingsWizard.ResumeLayout(false);
            this.wizardPageWelcome.ResumeLayout(false);
            this.wizardPageFinish.ResumeLayout(false);
            this.wizardPageProgress.ResumeLayout(false);
            this.wizardPageCompareFile.ResumeLayout(false);
            this.wizardPageCompareFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard ComparePlatformSettingsWizard;
        private Gui.Wizard.WizardPage wizardPageWelcome;
        private Gui.Wizard.WizardPage wizardPageFinish;
        private Gui.Wizard.WizardPage wizardPageProgress;
        private Gui.Wizard.WizardPage wizardPageCompareFile;
        private Gui.Wizard.InfoPage wizardInfoPageWelcome;
        private Gui.Wizard.InfoPage wizardInfoPageFinish;
        private Gui.Wizard.Header wizardHeaderCompareProcess;
        private System.Windows.Forms.ListView listViewProgress;
        private Gui.Wizard.Header wizardHeaderCompareFile;
        private System.Windows.Forms.TextBox txtCompareFilePath;
        private System.Windows.Forms.Label lblCompareFilePath;
        private System.Windows.Forms.Button btnCompareFileBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ImageList imageListGrid;
    }
}