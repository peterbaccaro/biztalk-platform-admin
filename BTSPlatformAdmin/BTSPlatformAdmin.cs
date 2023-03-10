using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BizTalk.Administration;
using System.Xml;

namespace BTSPlatformAdmin
{
    public partial class BTSPlatformAdmin : Form
    {
        public BTSPlatformAdmin()
        {
            InitializeComponent();
        }

        private void BTSPlatformAdmin_Load(object sender, EventArgs e)
        {
            treeView.ExpandAll();
        }

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (splitContainer.SplitterDistance > 300)
                splitContainer.SplitterDistance = 300;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                switch (treeView.SelectedNode.Text)
                {
                    case "Console Root":
                    case "BizTalk Group":
                    case "Platform Settings":
                        lblTitle.Text = "Platform Settings";
                        picTitle.Image = imageListTitle.Images[0];
                        DisplayPlatformSettings();
                        break;
                    case "Hosts":
                        lblTitle.Text = "Hosts";
                        picTitle.Image = imageListTitle.Images[1];
                        DisplayHosts();
                        break;
                    case "Host Instances":
                        lblTitle.Text = "Host Instances";
                        picTitle.Image = imageListTitle.Images[2];
                        DisplayHostInstances();
                        break;
                    case "Adapters":
                        lblTitle.Text = "Adapters";
                        picTitle.Image = imageListTitle.Images[3];
                        DisplayAdapters();
                        break;
                    default:
                        string adapterName = treeView.SelectedNode.Text;
                        lblTitle.Text = adapterName;
                        picTitle.Image = imageListTitle.Images[4];
                        DisplayAdapter(adapterName);
                        break;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(String.Format("Error: {0}", ex.Message), "Display " + treeView.SelectedNode.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void DisplayPlatformSettings()
        {
            listView.Visible = false;
            listView.Clear();
            listView.Columns.Add("Name", 200);

            ListViewItem lvi = null;
                
            lvi = new ListViewItem(new string[] { "Hosts" });
            lvi.ImageIndex = 0;
            listView.Items.Add(lvi);

            lvi = new ListViewItem(new string[] { "Host Instances" });
            lvi.ImageIndex = 1;
            listView.Items.Add(lvi);

            lvi = new ListViewItem(new string[] { "Adapters" });
            lvi.ImageIndex = 2;
            listView.Items.Add(lvi);

            listView.Visible = true;
        }

        private void DisplayHosts()
        {
            List<HostInfo> hostInfoList = WMIHelper.GetHosts();

            listView.Visible = false;
            listView.Clear();
            listView.Columns.Add("Host Name", 200);
            listView.Columns.Add("Host Type", 75);
            listView.Columns.Add("Windows Group", 200);
            listView.Columns.Add("Tracking", 75);
            listView.Columns.Add("32bit Only", 75);

            foreach (HostInfo hostInfo in hostInfoList)
            {
                string hostTracking = hostInfo.HostTracking == "True" ? "Yes" : "No";
                string isHost32BitOnly = hostInfo.IsHost32BitOnly == "True" ? "Yes" : "No";

                ListViewItem lvi = new ListViewItem(new string[] { hostInfo.HostName, hostInfo.HostType, hostInfo.NTGroupName, hostTracking, isHost32BitOnly });
                lvi.Tag = hostInfo;
                lvi.ImageIndex = (hostInfo.IsDefault == "False" ? 3 : 4);
                listView.Items.Add(lvi);
            }

            listView.Visible = true;
        }

        private void DisplayHostInstances()
        {
            List<HostInstanceInfo> hostInstanceInfoList = WMIHelper.GetHostInstances();

            listView.Visible = false;
            listView.Clear();
            listView.Columns.Add("Host Name", 200);
            listView.Columns.Add("Host Type", 75);
            listView.Columns.Add("Server Name", 125);
            listView.Columns.Add("Status", 85);
            listView.Columns.Add("Logon", 150);
            listView.Columns.Add("Is Disabled", 75);

            foreach (HostInstanceInfo hostInstanceInfo in hostInstanceInfoList)
            {
                string isDisabled = hostInstanceInfo.IsDisabled ? "Yes" : "No";

                ListViewItem lvi = new ListViewItem(new string[] { hostInstanceInfo.HostName, hostInstanceInfo.HostType, hostInstanceInfo.ServerName, hostInstanceInfo.ServiceState, hostInstanceInfo.Logon, isDisabled });
                lvi.Tag = hostInstanceInfo;
                lvi.ImageIndex = 5;
                listView.Items.Add(lvi);
            }

            listView.Visible = true;
        }

        private void DisplayAdapters()
        {
            List<AdapterInfo> adapterInfoList = WMIHelper.GetAdapters();

            listView.Visible = false;
            treeView.Visible = false;

            treeView.SelectedNode.Nodes.Clear();
            listView.Clear();
            listView.Columns.Add("Adapter Name", 200);
            listView.Columns.Add("Comment", 500);

            foreach (AdapterInfo adapterInfo in adapterInfoList)
            {
                ListViewItem lvi = new ListViewItem(new string[] { adapterInfo.AdapterName, adapterInfo.Comment });
                lvi.Tag = adapterInfo;
                lvi.ImageIndex = 6;
                listView.Items.Add(lvi);

                TreeNode tn = new TreeNode(adapterInfo.AdapterName, 7, 7);
                treeView.SelectedNode.Nodes.Add(tn);
            }

            treeView.SelectedNode.ExpandAll();
            treeView.Visible = true;
            listView.Visible = true;
        }

        private void DisplayAdapter(string adapterName)
        {
            List<AdapterHandlerInfo> adapterHandlerInfoList = WMIHelper.GetAdapterHandlers(adapterName);

            listView.Visible = false;
            listView.ShowItemToolTips = true;
            listView.Clear();
            listView.Columns.Add("Host Name", 200);
            listView.Columns.Add("Direction", 75);
            listView.Columns.Add("Adapter Name", 200);

            foreach (AdapterHandlerInfo adapterHandlerInfo in adapterHandlerInfoList)
            {
                ListViewItem lvi = new ListViewItem(new string[] { adapterHandlerInfo.HostName, adapterHandlerInfo.Direction, adapterHandlerInfo.AdapterName });
                lvi.Tag = adapterHandlerInfo;
                lvi.ToolTipText = adapterHandlerInfo.Config;
                lvi.ImageIndex = adapterHandlerInfo.IsDefault == "False" ? 7 : 8;
                listView.Items.Add(lvi);
            }

            listView.Visible = true;

        }

        private void RefreshPage()
        {
            treeView.Visible = false;
            List<AdapterInfo> adapterInfoList = WMIHelper.GetAdapters();

            TreeNode adaptersTreeNode = treeView.Nodes.Find("Adapters", true)[0];
            adaptersTreeNode.Nodes.Clear();
            foreach (AdapterInfo adapterInfo in adapterInfoList)
            {
                TreeNode tn = new TreeNode(adapterInfo.AdapterName, 7, 7);
                adaptersTreeNode.Nodes.Add(tn);
            }

            TreeNode platformSettingsTreeNode = treeView.Nodes.Find("PlatformSettings", true)[0];
            treeView.SelectedNode = platformSettingsTreeNode;
            treeView.Select();

            treeView.SelectedNode.ExpandAll();
            treeView.Visible = true;
        }

        private void toolStripImportButton_Click(object sender, EventArgs e)
        {
            try
            {
                ImportPlatformSettings importPlatformSettings = new ImportPlatformSettings();
                importPlatformSettings.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error: {0}", ex.Message), "Import Platform Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripExportButton_Click(object sender, EventArgs e)
        {
            try
            {
                ExportPlatformSettings exportPlatformSettings = new ExportPlatformSettings();
                exportPlatformSettings.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error: {0}", ex.Message), "Export Platform Settings", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void toolStripRemoveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not currently available.", "Remove Platform Settings", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

        private void toolStripCompareButton_Click(object sender, EventArgs e)
        {
            try
            {
                ComparePlatformSettings comparePlatformSettings = new ComparePlatformSettings();
                comparePlatformSettings.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error: {0}", ex.Message), "Compare Platform Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripRefreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                RefreshPage();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(String.Format("Error: {0}", ex.Message), "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void listView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RefreshPage();
            }
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            string toolTipText = listView.SelectedItems[0].ToolTipText;
            if (toolTipText != "")
                MessageBox.Show(FormatXml(toolTipText), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void treeView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RefreshPage();
            }
        }

        private void toolStripAboutButton_Click(object sender, EventArgs e)
        {
            About frmAbout = new About();
            frmAbout.ShowDialog();
        }

        private string FormatXml(string xml)
        {
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xml);
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            XmlTextWriter xtw = null;

            try
            {
                xtw = new XmlTextWriter(sw);
                xtw.Formatting = Formatting.Indented;
                xtw.Indentation = 2;
                xd.WriteTo(xtw);
            }
            finally
            {
                if (xtw != null)
                    xtw.Close();
            }

            return sb.ToString();
        }
    }
}
