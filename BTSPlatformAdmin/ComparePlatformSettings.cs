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
using BizTalk.Administration;

namespace BTSPlatformAdmin
{
    public partial class ComparePlatformSettings : Form
    {
        public ComparePlatformSettings()
        {
            InitializeComponent();
        }

        private void btnCompareFileBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.AddExtension = true;
            openFileDialog.DefaultExt = ".xml";
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = "XML files|*.xml";
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Select Platform Settings to Compare";
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                txtCompareFilePath.Text = openFileDialog.FileName;
            }
        }

        private bool IsValidFilePath(string path)
        {
            string pattern = @"^(([a-zA-Z]\:)|(\\))(\\{1}|((\\{1})[^\\]([^/:*?<>""|]*))+)$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(path);
        }

        private void wizardPageCompareFile_CloseFromNext(object sender, Gui.Wizard.PageEventArgs e)
        {
            string compareFilePath = txtCompareFilePath.Text.Trim();

            if (compareFilePath == String.Empty)
            {
                MessageBox.Show("Please select a compare file path.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                e.Page = wizardPageCompareFile;
                return;
            }
            else if (!IsValidFilePath(compareFilePath))
            {
                MessageBox.Show("Please select a valid compare file path.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                e.Page = wizardPageCompareFile;
                return;
            }
        }

        private PlatformSettings GetBizTalkPlatformSettings()
        {
            PlatformSettings platformSettings = new PlatformSettings();

            List<HostInfo> hostInfoList = WMIHelper.GetHosts();
            List<PlatformSettingsHost> psHostList = new List<PlatformSettingsHost>();
            foreach (HostInfo hostInfo in hostInfoList)
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
            platformSettings.Hosts = psHostList.ToArray();

            List<HostInstanceInfo> hostInstanceInfoList = WMIHelper.GetHostInstances();
            List<PlatformSettingsHostInstance> psHostInstanceList = new List<PlatformSettingsHostInstance>();
            foreach (HostInstanceInfo hostInstanceInfo in hostInstanceInfoList)
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
            platformSettings.HostInstances = psHostInstanceList.ToArray();

            List<AdapterInfo> adapterInfoList = WMIHelper.GetAdapters();
            List<PlatformSettingsAdapter> psAdapter = new List<PlatformSettingsAdapter>();
            foreach (AdapterInfo adapterInfo in adapterInfoList)
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
                adapter.Items = adapterHandlers.ToArray();
                psAdapter.Add(adapter);
            }
            platformSettings.Adapters = psAdapter.ToArray();

            return platformSettings;
        }
        
        private void wizardPageProgress_ShowFromNext(object sender, EventArgs e)
        {
            const int ImageIdxSuccess = 2;
            const int ImageIdxError = 3;
            ComparePlatformSettingsWizard.BackEnabled = false;
            ComparePlatformSettingsWizard.NextEnabled = false;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                listViewProgress.Clear();
                listViewProgress.SmallImageList = imageListGrid;
                listViewProgress.LargeImageList = imageListGrid;
                listViewProgress.Columns.Add("", 25);
                listViewProgress.Columns.Add("Platform Settings (File)", 500);
                listViewProgress.Columns.Add("Platform Settings (BizTalk)", 500);

                string configXml = new StreamReader(txtCompareFilePath.Text).ReadToEnd();

                PlatformSettings platformSettingsFile = Helpers.Serialization.DeserializeObject<PlatformSettings>(configXml);

                #region ProcessMachineNameMacro

                foreach (PlatformSettingsHost platformSettingHost in platformSettingsFile.Hosts)
                {
                    platformSettingHost.ntgroupname = platformSettingHost.ntgroupname.ReplaceEx("%MachineName%", Environment.MachineName);
                }

                foreach (PlatformSettingsHostInstance platformSettingsHostInstance in platformSettingsFile.HostInstances)
                {
                    platformSettingsHostInstance.username = platformSettingsHostInstance.username.ReplaceEx("%MachineName%", Environment.MachineName);
                    platformSettingsHostInstance.servername = platformSettingsHostInstance.servername.ReplaceEx("%MachineName%", Environment.MachineName);

                }

                #endregion


                PlatformSettings platformSettingsBizTalk = GetBizTalkPlatformSettings();

                //Compare Hosts
                foreach (PlatformSettingsHost platformSettingsFileHost in platformSettingsFile.Hosts)
                {
                    string platformSettingsFileHostSettings = platformSettingsFileHost.Stringify();
                    PlatformSettingsHost platformSettingsBizTalkHost = Array.Find<PlatformSettingsHost>(platformSettingsBizTalk.Hosts, host => host.hostname == platformSettingsFileHost.hostname);
                    string platformSettingsBizTalkHostSettings = (platformSettingsBizTalkHost != null) ? platformSettingsBizTalkHost.Stringify() : "<Missing>";

                    ListViewItem lvi = new ListViewItem(new string[] { "", platformSettingsFileHostSettings, platformSettingsBizTalkHostSettings });
                    if (platformSettingsFileHostSettings == platformSettingsBizTalkHostSettings)
                    {
                        lvi.ImageIndex = ImageIdxSuccess;
                    }
                    else
                    {
                        lvi.BackColor = Color.Red;
                        lvi.ImageIndex = ImageIdxError;
                    }

                    listViewProgress.Items.Add(lvi);
                }

                //Compare Host Instances
                foreach (PlatformSettingsHostInstance platformSettingsFileHostInstance in platformSettingsFile.HostInstances)
                {
                    string platformSettingsFileHostInstanceSettings = platformSettingsFileHostInstance.Stringify();
                    PlatformSettingsHostInstance platformSettingsBizTalkHostInstance = Array.Find<PlatformSettingsHostInstance>(platformSettingsBizTalk.HostInstances, hostInstance => hostInstance.hostname == platformSettingsFileHostInstance.hostname);
                    string platformSettingsBizTalkHostInstanceSettings = (platformSettingsBizTalkHostInstance != null) ? platformSettingsBizTalkHostInstance.Stringify() : "<Missing>";

                    ListViewItem lvi = new ListViewItem(new string[] { "", platformSettingsFileHostInstanceSettings, platformSettingsBizTalkHostInstanceSettings });
                    if (platformSettingsFileHostInstanceSettings == platformSettingsBizTalkHostInstanceSettings)
                    {
                        lvi.ImageIndex = ImageIdxSuccess;
                    }
                    else
                    {
                        lvi.BackColor = Color.Red;
                        lvi.ImageIndex = ImageIdxError;
                    }

                    listViewProgress.Items.Add(lvi);
                }

                //Compare Adapters and Adapter Handlers
                foreach (PlatformSettingsAdapter platformSettingsFileAdapter in platformSettingsFile.Adapters)
                {
                    string platformSettingsFileAdapterSettings = platformSettingsFileAdapter.Stringify();
                    PlatformSettingsAdapter platformSettingsBizTalkAdapter = Array.Find<PlatformSettingsAdapter>(platformSettingsBizTalk.Adapters, adapter => adapter.name == platformSettingsFileAdapter.name);
                    string platformSettingsBizTalkAdapterSettings = (platformSettingsBizTalkAdapter != null) ? platformSettingsBizTalkAdapter.Stringify() : "<Missing>";

                    ListViewItem lvi = new ListViewItem(new string[] { "", platformSettingsFileAdapterSettings, platformSettingsBizTalkAdapterSettings });
                    if (platformSettingsFileAdapterSettings == platformSettingsBizTalkAdapterSettings)
                    {
                        lvi.ImageIndex = ImageIdxSuccess;
                    }
                    else
                    {
                        lvi.BackColor = Color.Red;
                        lvi.ImageIndex = ImageIdxError;
                    }

                    listViewProgress.Items.Add(lvi);

                    foreach (object obj in platformSettingsFileAdapter.Items)
                    {
                        if (obj.GetType() == typeof(PlatformSettingsAdapterReceiveHandler))
                        {
                            PlatformSettingsAdapterReceiveHandler platformSettingsFileAdapterReceiveHandler = (PlatformSettingsAdapterReceiveHandler)obj;
                            string platformSettingsFileAdapterReceiveHandlerSettings = platformSettingsFileAdapterReceiveHandler.Stringify();
                            
                            IEnumerable<PlatformSettingsAdapterReceiveHandler> platformSettingsBizTalkAdapterReceiveHandlers = platformSettingsBizTalkAdapter.Items.OfType<PlatformSettingsAdapterReceiveHandler>();
                            PlatformSettingsAdapterReceiveHandler platformSettingsBizTalkAdapterReceiveHandler = platformSettingsBizTalkAdapterReceiveHandlers.First<PlatformSettingsAdapterReceiveHandler>(rh => rh.hostname == platformSettingsFileAdapterReceiveHandler.hostname);
                            string platformSettingsBizTalkAdapterReceiveHandlerSettings = (platformSettingsBizTalkAdapterReceiveHandler != null) ? platformSettingsBizTalkAdapterReceiveHandler.Stringify() : "<Missing>";

                            lvi = new ListViewItem(new string[] { "", platformSettingsFileAdapterReceiveHandlerSettings, platformSettingsBizTalkAdapterReceiveHandlerSettings });
                            if (platformSettingsFileAdapterReceiveHandlerSettings == platformSettingsBizTalkAdapterReceiveHandlerSettings)
                            {
                                lvi.ImageIndex = ImageIdxSuccess;
                            }
                            else
                            {
                                lvi.BackColor = Color.Red;
                                lvi.ImageIndex = ImageIdxError;
                            }

                            listViewProgress.Items.Add(lvi);
                        }
                        else if (obj.GetType() == typeof(PlatformSettingsAdapterSendHandler))
                        {
                            PlatformSettingsAdapterSendHandler platformSettingsFileAdapterSendHandler = (PlatformSettingsAdapterSendHandler)obj;
                            string platformSettingsFileAdapterSendHandlerSettings = platformSettingsFileAdapterSendHandler.Stringify();

                            IEnumerable<PlatformSettingsAdapterSendHandler> platformSettingsBizTalkAdapterSendHandlers = platformSettingsBizTalkAdapter.Items.OfType<PlatformSettingsAdapterSendHandler>();
                            PlatformSettingsAdapterSendHandler platformSettingsBizTalkAdapterSendHandler = platformSettingsBizTalkAdapterSendHandlers.First<PlatformSettingsAdapterSendHandler>(sh => sh.hostname == platformSettingsFileAdapterSendHandler.hostname);
                            string platformSettingsBizTalkAdapterSendHandlerSettings = (platformSettingsBizTalkAdapterSendHandler != null) ? platformSettingsBizTalkAdapterSendHandler.Stringify() : "<Missing>";

                            lvi = new ListViewItem(new string[] { "", platformSettingsFileAdapterSendHandlerSettings, platformSettingsBizTalkAdapterSendHandlerSettings });
                            if (platformSettingsFileAdapterSendHandlerSettings == platformSettingsBizTalkAdapterSendHandlerSettings)
                            {
                                lvi.ImageIndex = ImageIdxSuccess;
                            }
                            else
                            {
                                lvi.BackColor = Color.Red;
                                lvi.ImageIndex = ImageIdxError;
                            }

                            listViewProgress.Items.Add(lvi);
                        }
                    }
                }

                ComparePlatformSettingsWizard.NextEnabled = true;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(String.Format("Error: {0}", ex.Message), "Compare Platform Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
