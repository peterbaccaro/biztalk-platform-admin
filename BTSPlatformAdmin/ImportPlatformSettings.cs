using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;
using BizTalk.Administration;

namespace BTSPlatformAdmin
{
    public partial class ImportPlatformSettings : Form
    {
        private PlatformSettings _platformSettings;

        private void ImportPlatformSettingsWizard_Load(object sender, EventArgs e)
        {
            #region DataGridWindowsGroups

            dataGridWindowsGroups.RowHeadersVisible = false;
            dataGridWindowsGroups.AllowUserToResizeColumns = false;
            dataGridWindowsGroups.AllowUserToResizeRows = false;
            dataGridWindowsGroups.AllowUserToAddRows = false;
            dataGridWindowsGroups.StandardTab = true;
            dataGridWindowsGroups.SelectionMode = DataGridViewSelectionMode.CellSelect;

            DataGridViewImageColumn colNTGroupIcon = new DataGridViewImageColumn();
            colNTGroupIcon.ReadOnly = true;
            colNTGroupIcon.Image = imageListGrid.Images[0];
            colNTGroupIcon.Width = 25;

            DataGridViewTextBoxColumn colRoleName = new DataGridViewTextBoxColumn();
            colRoleName.ReadOnly = true;
            colRoleName.Name = "Role Name";
            colRoleName.Width = 200;

            DataGridViewTextBoxColumn colWindowsGroup = new DataGridViewTextBoxColumn();
            colWindowsGroup.ReadOnly = false;
            colWindowsGroup.Name = "Windows Group";
            colWindowsGroup.Width = 225;

            dataGridWindowsGroups.Columns.Add(colNTGroupIcon);
            dataGridWindowsGroups.Columns.Add(colRoleName);
            dataGridWindowsGroups.Columns.Add(colWindowsGroup);

            #endregion

            #region DataGridLogonCredentials

            dataGridLogonCredentials.RowHeadersVisible = false;
            dataGridLogonCredentials.AllowUserToResizeColumns = false;
            dataGridLogonCredentials.AllowUserToResizeRows = false;
            dataGridLogonCredentials.AllowUserToAddRows = false;
            dataGridLogonCredentials.StandardTab = true;
            dataGridLogonCredentials.SelectionMode = DataGridViewSelectionMode.CellSelect;

            DataGridViewImageColumn colNTUserIcon = new DataGridViewImageColumn();
            colNTUserIcon.ReadOnly = true;
            colNTUserIcon.Image = imageListGrid.Images[1];
            colNTUserIcon.Width = 25;

            DataGridViewTextBoxColumn colHostName = new DataGridViewTextBoxColumn();
            colHostName.ReadOnly = true;
            colHostName.Name = "Host Name";
            colHostName.Width = 150;

            DataGridViewTextBoxColumn colServerName = new DataGridViewTextBoxColumn();
            colServerName.ReadOnly = true;
            colServerName.Name = "Server Name";
            colServerName.Width = 125;

            DataGridViewTextBoxColumn colLogon = new DataGridViewTextBoxColumn();
            colLogon.ReadOnly = false;
            colLogon.Name = "Logon";
            colLogon.Width = 150;

            DataGridViewPasswordTextBoxColumn colPassword = new DataGridViewPasswordTextBoxColumn();
            colPassword.ReadOnly = false;
            colPassword.Name = "Password";
            colPassword.Width = 125;
            colPassword.PasswordChar = '*';

            dataGridLogonCredentials.Columns.Add(colNTUserIcon);
            dataGridLogonCredentials.Columns.Add(colHostName);
            dataGridLogonCredentials.Columns.Add(colServerName);
            dataGridLogonCredentials.Columns.Add(colLogon);
            dataGridLogonCredentials.Columns.Add(colPassword);

            #endregion
        }

        public ImportPlatformSettings()
        {
            InitializeComponent();
        }

        private void btnImportFileBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.AddExtension = true;
            openFileDialog.DefaultExt = ".xml";
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = "XML files|*.xml";
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Select Platform Settings to Import";
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                txtImportFilePath.Text = openFileDialog.FileName;
            }
        }

        private bool IsValidFilePath(string path)
        {
            string pattern = @"^(([a-zA-Z]\:)|(\\))(\\{1}|((\\{1})[^\\]([^/:*?<>""|]*))+)$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(path);
        }

        private void wizardPageImportFile_CloseFromNext(object sender, Gui.Wizard.PageEventArgs e)
        {
            string importFilePath = txtImportFilePath.Text.Trim();

            if (importFilePath == String.Empty)
            {
                MessageBox.Show("Please select an import file path.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                e.Page = wizardPageImportFile;
                return;
            }
            else if (!IsValidFilePath(importFilePath))
            {
                MessageBox.Show("Please select a valid import file path.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                e.Page = wizardPageImportFile;
                return;
            }

            try
            {
                string config = new StreamReader(txtImportFilePath.Text).ReadToEnd();
                _platformSettings = Helpers.Serialization.DeserializeObject<PlatformSettings>(config);

                #region ProcessMachineNameMacro

                foreach (PlatformSettingsHost platformSettingHost in _platformSettings.Hosts)
                {
                    platformSettingHost.ntgroupname = platformSettingHost.ntgroupname.ReplaceEx("%MachineName%", Environment.MachineName);
                }

                foreach (PlatformSettingsHostInstance platformSettingsHostInstance in _platformSettings.HostInstances)
                {
                    platformSettingsHostInstance.username = platformSettingsHostInstance.username.ReplaceEx("%MachineName%", Environment.MachineName);
                    platformSettingsHostInstance.servername = platformSettingsHostInstance.servername.ReplaceEx("%MachineName%", Environment.MachineName);

                }

                #endregion

                dataGridWindowsGroups.Visible = false;
                dataGridWindowsGroups.Rows.Clear();

                PlatformSettingsHost platformSettingsInProcessHost = _platformSettings.Hosts.First<PlatformSettingsHost>(host => host.hosttype == "InProcess");
                PlatformSettingsHost platformSettingsIsolatedHost = _platformSettings.Hosts.First<PlatformSettingsHost>(host => host.hosttype == "Isolated");

                dataGridWindowsGroups.Rows.Add(null, "BizTalk Host Instance Account", platformSettingsInProcessHost.ntgroupname);
                dataGridWindowsGroups.Rows.Add(null, "BizTalk Isolated Host Instance Account", platformSettingsIsolatedHost.ntgroupname);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error: {0}", ex.Message), "Import Platform Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Page = wizardPageImportFile;
            }
            finally
            {
                dataGridWindowsGroups.Visible = true;
            }
        }

        private void wizardPageWindowsGroups_CloseFromNext(object sender, Gui.Wizard.PageEventArgs e)
        {
            string hostInstanceAccountInProcess = dataGridWindowsGroups.Rows[0].Cells["Windows Group"].Value.ToString();
            if (!Helpers.DirectoryServices.GroupExists(hostInstanceAccountInProcess))
            {
                MessageBox.Show("Please enter a valid BizTalk Host Instance Account.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Page = wizardPageWindowsGroups;
                return;
            }

            string hostInstanceAccountIsolated = dataGridWindowsGroups.Rows[1].Cells["Windows Group"].Value.ToString();
            if (!Helpers.DirectoryServices.GroupExists(hostInstanceAccountIsolated))
            {
                MessageBox.Show("Please enter a valid BizTalk Isolated Host Instance Account.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Page = wizardPageWindowsGroups;
                return;
            }

            foreach (PlatformSettingsHost platformSettingHost in _platformSettings.Hosts)
            {
                switch (platformSettingHost.hosttype)
                {
                    case "InProcess":
                        platformSettingHost.ntgroupname = hostInstanceAccountInProcess;
                        break;

                    case "Isolated":
                        platformSettingHost.ntgroupname = hostInstanceAccountIsolated;
                        break;
                }
            }

            try
            {
                dataGridLogonCredentials.Visible = false;
                dataGridLogonCredentials.Rows.Clear();

                foreach (PlatformSettingsHostInstance platformSettingsHostInstance in _platformSettings.HostInstances)
                {
                    dataGridLogonCredentials.Rows.Add(null, platformSettingsHostInstance.hostname, platformSettingsHostInstance.servername, platformSettingsHostInstance.username, platformSettingsHostInstance.password);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error: {0}", ex.Message), "Import Platform Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Page = wizardPageWindowsGroups;
            }
            finally
            {
                dataGridLogonCredentials.Visible = true;
            }
        }

        private void wizardPageLogonCredentials_CloseFromNext(object sender, Gui.Wizard.PageEventArgs e)
        {
            for (int i = 0; i < dataGridLogonCredentials.RowCount; i++)
            {
                string username = dataGridLogonCredentials.Rows[i].Cells["Logon"].Value.ToString();
                string password = dataGridLogonCredentials.Rows[i].Cells["Password"].Value.ToString();

                if (!Helpers.DirectoryServices.CredentialsValid(username, password))
                {
                    MessageBox.Show(String.Format("Logon credentials for valid for Logon '{0}'.", username), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Page = wizardPageLogonCredentials;
                    return;
                }
                else
                {
                    string hostname = dataGridLogonCredentials.Rows[i].Cells["Host Name"].Value.ToString();
                    string servername = dataGridLogonCredentials.Rows[i].Cells["Server Name"].Value.ToString();

                    PlatformSettingsHostInstance platformSettingsHostInstance = _platformSettings.HostInstances.First<PlatformSettingsHostInstance>(hostInstance => hostInstance.hostname == hostname && hostInstance.servername == servername);
                    platformSettingsHostInstance.username = username;
                    platformSettingsHostInstance.password = password;
                }
            }
        }

        private void wizardPageProgress_ShowFromNext(object sender, EventArgs e)
        {
            const int ImageIdxSuccess = 2;
            const int ImageIdxError = 3;
            ImportPlatformSettingsWizard.BackEnabled = false;
            ImportPlatformSettingsWizard.NextEnabled = false;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                listViewProgress.Clear();
                listViewProgress.SmallImageList = imageListGrid;
                listViewProgress.LargeImageList = imageListGrid;
                listViewProgress.Columns.Add("", 25);
                listViewProgress.Columns.Add("Details", 800);

                foreach (PlatformSettingsHost platformSettingsHost in _platformSettings.Hosts)
                {
                    WMIResult result = WMIHelper.AddHost(platformSettingsHost.hostname, platformSettingsHost.ntgroupname, platformSettingsHost.isdefault, platformSettingsHost.hosttracking, platformSettingsHost.authtrusted, platformSettingsHost.hosttype, platformSettingsHost.ishost32bitonly);
                    ListViewItem lvi = new ListViewItem(new string[] { "", result.Message });
                    lvi.ToolTipText = result.Message;
                    lvi.ImageIndex = result.Success ? ImageIdxSuccess : ImageIdxError;
                    listViewProgress.Items.Add(lvi);
                }

                foreach (PlatformSettingsHostInstance platformSettingsHostInstance in _platformSettings.HostInstances)
                {
                    WMIResult result = WMIHelper.AddHostInstance(platformSettingsHostInstance.servername, platformSettingsHostInstance.hostname, platformSettingsHostInstance.username, platformSettingsHostInstance.password, platformSettingsHostInstance.startinstance, platformSettingsHostInstance.isdisabled);
                    ListViewItem lvi = new ListViewItem(new string[] { "", result.Message });
                    lvi.ToolTipText = result.Message;
                    lvi.ImageIndex = result.Success ? ImageIdxSuccess : ImageIdxError;
                    listViewProgress.Items.Add(lvi);
                }

                foreach (PlatformSettingsAdapter platformSettingsAdapter in _platformSettings.Adapters)
                {
                    WMIResult result = WMIHelper.AddAdapter(platformSettingsAdapter.name, platformSettingsAdapter.type, platformSettingsAdapter.comment);
                    ListViewItem lvi = new ListViewItem(new string[] { "", result.Message });
                    lvi.ToolTipText = result.Message;
                    lvi.ImageIndex = result.Success ? ImageIdxSuccess : ImageIdxError;
                    listViewProgress.Items.Add(lvi);

                    foreach (object obj in platformSettingsAdapter.Items)
                    {
                        if (obj.GetType() == typeof(PlatformSettingsAdapterReceiveHandler))
                        {
                            PlatformSettingsAdapterReceiveHandler platformSettingsAdapterReceiveHandler = (PlatformSettingsAdapterReceiveHandler)obj;

                            result = WMIHelper.AddReceiveHandler(platformSettingsAdapter.name, platformSettingsAdapterReceiveHandler.hostname, platformSettingsAdapterReceiveHandler.config);
                            lvi = new ListViewItem(new string[] { "", result.Message });
                            lvi.ToolTipText = result.Message;
                            lvi.ImageIndex = result.Success ? ImageIdxSuccess : ImageIdxError;
                            listViewProgress.Items.Add(lvi);
                        }
                        else if (obj.GetType() == typeof(PlatformSettingsAdapterSendHandler))
                        {
                            PlatformSettingsAdapterSendHandler platformSettingsAdapterSendHandler = (PlatformSettingsAdapterSendHandler)obj;

                            result = WMIHelper.AddSendHandler(platformSettingsAdapter.name, platformSettingsAdapterSendHandler.hostname, platformSettingsAdapterSendHandler.isdefault, platformSettingsAdapterSendHandler.config);
                            lvi = new ListViewItem(new string[] { "", result.Message });
                            lvi.ToolTipText = result.Message;
                            lvi.ImageIndex = result.Success ? ImageIdxSuccess : ImageIdxError;
                            listViewProgress.Items.Add(lvi);
                        }
                    }
                }

                ImportPlatformSettingsWizard.NextEnabled = true;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(String.Format("Error: {0}", ex.Message), "Import Platform Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
