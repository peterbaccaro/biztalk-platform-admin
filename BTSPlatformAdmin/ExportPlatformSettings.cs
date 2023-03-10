using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using BizTalk.Administration;

namespace BTSPlatformAdmin
{
    public partial class ExportPlatformSettings : Form
    {
        public ExportPlatformSettings()
        {
            InitializeComponent();
        }

        private void ExportPlatformSettingsWizard_Load(object sender, EventArgs e)
        {
            checkedListBoxHosts.Items.Clear();
            List<HostInfo> hostInfoList = WMIHelper.GetHosts();
            foreach (HostInfo hostInfo in hostInfoList)
            {
                checkedListBoxHosts.Items.Add(hostInfo.HostName);
            }

            for (int i = 0; i < checkedListBoxHosts.Items.Count; i++)
            {
                checkedListBoxHosts.SetItemChecked(i, true);
            }

            checkedListBoxAdapters.Items.Clear();
            List<AdapterInfo> adapterInfoList = WMIHelper.GetAdapters();
            foreach (AdapterInfo adapterInfo in adapterInfoList)
            {
                checkedListBoxAdapters.Items.Add(adapterInfo.AdapterName);
            }

            for (int i = 0; i < checkedListBoxAdapters.Items.Count; i++)
            {
                checkedListBoxAdapters.SetItemChecked(i, true);
            }
        }

        private void wizardPageExportFile_CloseFromNext(object sender, Gui.Wizard.PageEventArgs e)
        {
            string exportFilePath = txtExportFilePath.Text.Trim();

            if (exportFilePath == String.Empty)
            {
                MessageBox.Show("Please select an export file path.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                e.Page = wizardPageExportFile;
            }
            else if (!IsValidFilePath(exportFilePath))
            {
                MessageBox.Show("Please select a valid export file path.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                e.Page = wizardPageExportFile;
            }
        }

        private bool IsValidFilePath(string path)
        {
            string pattern = @"^(([a-zA-Z]\:)|(\\))(\\{1}|((\\{1})[^\\]([^/:*?<>""|]*))+)$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(path);
        }

        private void btnExportFileBrowse_Click(object sender, EventArgs e)
        {
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.Filter = "XML files|*.xml";
            saveFileDialog.Title = "Export Platform Settings As";
            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                txtExportFilePath.Text = saveFileDialog.FileName;
            }
        }

        private void wizardPageExportProcess_ShowFromNext(object sender, EventArgs e)
        {
            ExportPlatformSettingsWizard.BackEnabled = false;
            ExportPlatformSettingsWizard.NextEnabled = false;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                PlatformSettings biztalkPlatformSettings = new PlatformSettings();

                #region Hosts

                List<HostInfo> hostInfoList = WMIHelper.GetHosts();
                List<PlatformSettingsHost> psHostList = new List<PlatformSettingsHost>();
                foreach (HostInfo hostInfo in hostInfoList)
                {
                    if (checkedListBoxHosts.CheckedItems.Contains(hostInfo.HostName))
                    {
                        PlatformSettingsHost host = new PlatformSettingsHost()
                        {
                            hostname = hostInfo.HostName,
                            ntgroupname = hostInfo.NTGroupName,
                            isdefault = Convert.ToBoolean(hostInfo.IsDefault),
                            hosttracking = Convert.ToBoolean(hostInfo.HostTracking),
                            authtrusted = Convert.ToBoolean(hostInfo.AuthTrusted),
                            hosttype = hostInfo.HostType,
                            ishost32bitonly = Convert.ToBoolean(hostInfo.IsHost32BitOnly)
                        };
                        psHostList.Add(host);
                    }
                }
                biztalkPlatformSettings.Hosts = psHostList.ToArray();

                #endregion

                progressBarExport.Value = 25;

                #region HostInstances

                List<HostInstanceInfo> hostInstanceInfoList = WMIHelper.GetHostInstances();
                List<PlatformSettingsHostInstance> psHostInstanceList = new List<PlatformSettingsHostInstance>();
                foreach (HostInstanceInfo hostInstanceInfo in hostInstanceInfoList)
                {
                    if (checkedListBoxHosts.CheckedItems.Contains(hostInstanceInfo.HostName))
                    {
                        PlatformSettingsHostInstance hostInstance = new PlatformSettingsHostInstance()
                        {
                            hostname = hostInstanceInfo.HostName,
                            servername = hostInstanceInfo.ServerName,
                            startinstance = hostInstanceInfo.ServiceState == "Running",
                            username = hostInstanceInfo.Logon,
                            password = "",
                            isdisabled = hostInstanceInfo.IsDisabled
                        };
                        psHostInstanceList.Add(hostInstance);
                    }
                }
                biztalkPlatformSettings.HostInstances = psHostInstanceList.ToArray();

                #endregion

                progressBarExport.Value = 50;

                #region Adapters

                List<AdapterInfo> adapterInfoList = WMIHelper.GetAdapters();
                List<PlatformSettingsAdapter> psAdapter = new List<PlatformSettingsAdapter>();
                foreach (AdapterInfo adapterInfo in adapterInfoList)
                {
                    if (checkedListBoxAdapters.CheckedItems.Contains(adapterInfo.AdapterName))
                    {
                        PlatformSettingsAdapter adapter = new PlatformSettingsAdapter()
                        {
                            name = adapterInfo.AdapterName,
                            type = adapterInfo.AdapterName,
                            comment = adapterInfo.Comment,
                        };

                        List<AdapterHandlerInfo> adapterHandlerInfoList = WMIHelper.GetAdapterHandlers(adapterInfo.AdapterName);
                        List<object> adapterHandlers = new List<object>();
                        foreach (AdapterHandlerInfo adapterHandlerInfo in adapterHandlerInfoList)
                        {
                            if (checkedListBoxHosts.CheckedItems.Contains(adapterHandlerInfo.HostName))
                            {
                                if (adapterHandlerInfo.Direction == "Receive")
                                {
                                    PlatformSettingsAdapterReceiveHandler receiveHandler = new PlatformSettingsAdapterReceiveHandler()
                                    {
                                        hostname = adapterHandlerInfo.HostName,
                                        config = adapterHandlerInfo.Config
                                    };
                                    adapterHandlers.Add(receiveHandler);
                                }

                                if (adapterHandlerInfo.Direction == "Send")
                                {
                                    PlatformSettingsAdapterSendHandler sendHandler = new PlatformSettingsAdapterSendHandler()
                                    {
                                        hostname = adapterHandlerInfo.HostName,
                                        config = adapterHandlerInfo.Config,
                                        isdefault = Convert.ToBoolean(adapterHandlerInfo.IsDefault)
                                    };
                                    adapterHandlers.Add(sendHandler);
                                }
                            }
                        }
                        adapter.Items = adapterHandlers.ToArray();
                        psAdapter.Add(adapter);
                    }
                }
                biztalkPlatformSettings.Adapters = psAdapter.ToArray();

                #endregion

                progressBarExport.Value = 80;

                #region ProcessMachineNameMacro

                foreach (PlatformSettingsHost platformSettingHost in biztalkPlatformSettings.Hosts)
                {
                    platformSettingHost.ntgroupname = platformSettingHost.ntgroupname.ReplaceEx(Environment.MachineName, "%MachineName%");
                }

                foreach (PlatformSettingsHostInstance platformSettingsHostInstance in biztalkPlatformSettings.HostInstances)
                {
                    platformSettingsHostInstance.username = platformSettingsHostInstance.username.ReplaceEx(Environment.MachineName, "%MachineName%");
                    platformSettingsHostInstance.servername = platformSettingsHostInstance.servername.ReplaceEx(Environment.MachineName, "%MachineName%");
                }

                #endregion

                #region WriteToFile

                string configXML = Helpers.Serialization.SerializeObject<PlatformSettings>(biztalkPlatformSettings);

                StreamWriter sw = new StreamWriter(txtExportFilePath.Text);
                sw.Write(configXML);
                sw.Close();

                #endregion

                progressBarExport.Value = 100;

                ExportPlatformSettingsWizard.Next();
                ExportPlatformSettingsWizard.BackEnabled = false;
                ExportPlatformSettingsWizard.CancelEnabled = false;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(String.Format("Error: {0}", ex.Message), "Export Platform Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
