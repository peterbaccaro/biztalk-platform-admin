using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace BizTalk.Administration
{
    public static class WMIHelper
    {
        private const string BTS_WMINameSpace = @"root\MicrosoftBizTalkServer";
        private const string BTS_ServerHostNameSpace = "MSBTS_ServerHost";
        private const string BTS_HostSettingNameSpace = "MSBTS_HostSetting";
        private const string BTS_HostInstanceNameSpace = "MSBTS_HostInstance";
        private const string BTS_AdapterSettingNameSpace = "MSBTS_AdapterSetting";
        private const string BTS_ReceiveHandlerNameSpace = "MSBTS_ReceiveHandler";
        private const string BTS_SendHandlerNameSpace = "MSBTS_SendHandler2";

        private enum BTSHostType
        {
            Invalid = 0,
            InProcess = 1,
            Isolated = 2
        }
        
        private enum BTSServiceState
        {
            Stopped = 1,
            StartPending = 2,
            StopPending = 3,
            Running = 4,
            ContinuePending = 5,
            PausePending = 6,
            Paused = 7,
            NotApplicable = 8
        }
        
        public static List<HostInfo> GetHosts()
        {
            List<HostInfo> hostInfoList = new List<HostInfo>();
            string query = String.Format("SELECT * FROM {0}", BTS_HostSettingNameSpace);
            ManagementObjectSearcher mgtObjSearcher = new ManagementObjectSearcher(new ManagementScope(BTS_WMINameSpace), new WqlObjectQuery(query), null);
            foreach (ManagementObject mgtObj in mgtObjSearcher.Get())
            {
                HostInfo hostInfo = new HostInfo()
                {
                    HostName = mgtObj.GetPropertyValue("Name").ToString(),
                    NTGroupName = mgtObj.GetPropertyValue("NTGroupName").ToString(),
                    IsDefault = mgtObj.GetPropertyValue("IsDefault").ToString(),
                    HostTracking = mgtObj.GetPropertyValue("HostTracking").ToString(),
                    AuthTrusted = mgtObj.GetPropertyValue("AuthTrusted").ToString(),
                    HostType = ((BTSHostType)Enum.Parse(typeof(BTSHostType), mgtObj.GetPropertyValue("HostType").ToString())).ToString(),
                    IsHost32BitOnly = mgtObj.GetPropertyValue("IsHost32BitOnly").ToString()
                };
                hostInfoList.Add(hostInfo);
            }
            return hostInfoList;
        }
        
        public static List<HostInstanceInfo> GetHostInstances()
        {
            List<HostInstanceInfo> hostInstanceInfoList = new List<HostInstanceInfo>();
            string query = String.Format("SELECT * FROM {0}", BTS_HostInstanceNameSpace);
            ManagementObjectSearcher mgtObjSearcher = new ManagementObjectSearcher(new ManagementScope(BTS_WMINameSpace), new WqlObjectQuery(query), null);
        
            foreach (ManagementObject mgtObj in mgtObjSearcher.Get())
            {
                HostInstanceInfo hostInstanceInfo = new HostInstanceInfo()
                {
                    HostName = mgtObj.GetPropertyValue("HostName").ToString(),
                    HostType = ((BTSHostType)Enum.Parse(typeof(BTSHostType), mgtObj.GetPropertyValue("HostType").ToString())).ToString(),
                    ServerName = mgtObj.GetPropertyValue("RunningServer").ToString(),
                    ServiceState = ((BTSServiceState)Enum.Parse(typeof(BTSServiceState), mgtObj.GetPropertyValue("ServiceState").ToString())).ToString(),
                    Logon = mgtObj.GetPropertyValue("Logon").ToString(),
                    IsDisabled = (bool)mgtObj.GetPropertyValue("IsDisabled")
                };
            
                hostInstanceInfoList.Add(hostInstanceInfo);
            }
            return hostInstanceInfoList;
        }

        public static List<AdapterInfo> GetAdapters()
        {
            List<AdapterInfo> adapterInfoList = new List<AdapterInfo>();
            string query = String.Format("SELECT * FROM {0}", BTS_AdapterSettingNameSpace);
            ManagementObjectSearcher mgtObjSearcher = new ManagementObjectSearcher(new ManagementScope(BTS_WMINameSpace), new WqlObjectQuery(query), null);

            foreach (ManagementObject mgtObj in mgtObjSearcher.Get())
            {
                AdapterInfo adapterInfo = new AdapterInfo()
                {
                    AdapterName = mgtObj.GetPropertyValue("Name").ToString(),
                    Comment = mgtObj.GetPropertyValue("Comment").ToString()
                };
                adapterInfoList.Add(adapterInfo);
            }
            return adapterInfoList;
        }

        public static List<AdapterHandlerInfo> GetAdapterHandlers(string adapterName)
        {
            List<AdapterHandlerInfo> adapterHandlerInfoList = new List<AdapterHandlerInfo>();
            ManagementObjectSearcher mgtObjSearcher = null;
            string query = null;

            query = String.Format("SELECT * FROM {0} WHERE AdapterName = '{1}'", BTS_ReceiveHandlerNameSpace, adapterName);
            mgtObjSearcher = new ManagementObjectSearcher(new ManagementScope(BTS_WMINameSpace), new WqlObjectQuery(query), null);
            foreach (ManagementObject mgtObj in mgtObjSearcher.Get())
            {
                AdapterHandlerInfo adapterHandlerInfo = new AdapterHandlerInfo()
                {
                    HostName = mgtObj.GetPropertyValue("HostName").ToString(),
                    Direction = "Receive",
                    IsDefault = "False",
                    AdapterName = mgtObj.GetPropertyValue("AdapterName").ToString(),
                    Config = mgtObj.GetPropertyValue("CustomCfg").ToString()
                };
                adapterHandlerInfoList.Add(adapterHandlerInfo);
            }

            query = String.Format("SELECT * FROM {0} WHERE AdapterName = '{1}'", BTS_SendHandlerNameSpace, adapterName);
            mgtObjSearcher = new ManagementObjectSearcher(new ManagementScope(BTS_WMINameSpace), new WqlObjectQuery(query), null);
            foreach (ManagementObject mgtObj in mgtObjSearcher.Get())
            {
                AdapterHandlerInfo adapterHandlerInfo = new AdapterHandlerInfo()
                {
                    HostName = mgtObj.GetPropertyValue("HostName").ToString(),
                    Direction = "Send",
                    IsDefault = mgtObj.GetPropertyValue("IsDefault").ToString(),
                    AdapterName = mgtObj.GetPropertyValue("AdapterName").ToString(),
                    Config = mgtObj.GetPropertyValue("CustomCfg").ToString()
                };
                adapterHandlerInfoList.Add(adapterHandlerInfo);
            }

            return adapterHandlerInfoList;
        }        

        public static WMIResult AddAdapter(string adapterName, string adapterType, string comment)
        {
            try
            {
                ManagementObject adapterSetting = null;
                ManagementClass adapterSettingClass = new ManagementClass(BTS_WMINameSpace, BTS_AdapterSettingNameSpace, new ObjectGetOptions());
                EnumerationOptions enumOptions = new EnumerationOptions();
                enumOptions.ReturnImmediately = false;
                foreach (ManagementObject mgtObj in adapterSettingClass.GetInstances(enumOptions))
                {
                    if ((mgtObj["Name"] != null) && (mgtObj["Name"].ToString().ToUpper() == adapterName.ToUpper()))
                    {
                        adapterSetting = mgtObj;
                    }
                }
                if (adapterSetting == null)
                {
                    adapterSetting = adapterSettingClass.CreateInstance();
                    adapterSetting.SetPropertyValue("Name", adapterName);
                    adapterSetting.SetPropertyValue("MgmtCLSID", adapterType);
                    adapterSetting.SetPropertyValue("Comment", comment);
                    PutOptions putOptions = new PutOptions();
                    putOptions.Type = PutType.UpdateOrCreate;
                    adapterSetting.Put(putOptions);
                }
                return new WMIResult() { Success = true, Message = String.Format("Adapter '{0}' has been created.", adapterName) };
            }
            catch (Exception ex)
            {
                return new WMIResult() { Success = false, Message = String.Format("AddAdapter '{0}' failed: {1}", adapterName, ex.Message) };
            }
        }
        
        public static WMIResult AddHost(string hostName, string ntGroupName, bool isDefault, bool hostTracking, bool authTrusted, string hostType, bool isHost32BitOnly)
        {
            try
            {
                BTSHostType btsHostType = (BTSHostType)Enum.Parse(typeof(BTSHostType), hostType);
                PutOptions putOptions = new PutOptions();
                putOptions.Type = PutType.UpdateOrCreate;
                ManagementObject hostSetting = new ManagementClass(BTS_WMINameSpace, BTS_HostSettingNameSpace, new ObjectGetOptions()).CreateInstance();
                hostSetting["Name"] = hostName;
                hostSetting["NTGroupName"] = ntGroupName;
                hostSetting["IsDefault"] = isDefault;
                hostSetting["HostTracking"] = hostTracking;
                hostSetting["AuthTrusted"] = authTrusted;
                hostSetting["HostType"] = btsHostType;
                hostSetting["IsHost32BitOnly"] = isHost32BitOnly;
                hostSetting.Put(putOptions);
        
                return new WMIResult() { Success = true, Message = String.Format("{0} Host '{1}' has been created.", hostType, hostName) };
            }
            catch (Exception ex)
            {
                return new WMIResult() { Success = false, Message = String.Format("AddHost '{0}' failed: {1}", hostName, ex.Message) };
            }
        }
        
        public static WMIResult AddHostInstance(string serverName, string hostName, string username, string password, bool startInstance, bool isDisabled)
        {
            try
            {
                ManagementObject serverHost = new ManagementClass(BTS_WMINameSpace, BTS_ServerHostNameSpace, new ObjectGetOptions()).CreateInstance();
                serverHost["ServerName"] = serverName;
                serverHost["HostName"] = hostName;
                serverHost.InvokeMethod("Map", null);
                    
                ManagementObject hostInstance = new ManagementClass(BTS_WMINameSpace, BTS_HostInstanceNameSpace, new ObjectGetOptions()).CreateInstance();
                hostInstance["Name"] = String.Format("Microsoft BizTalk Server {0} {1}", hostName, serverName);
                hostInstance["IsDisabled"] = isDisabled;
                object[] args = new object[] { username, password, true };
                hostInstance.InvokeMethod("Install", args);
                if (startInstance)
                    hostInstance.InvokeMethod("Start", null);
        
                return new WMIResult() { Success = true, Message = String.Format("Host instance '{0}' has been created on server '{1}'.", hostName, serverName) };
            }
            catch (Exception ex)
            {
                return new WMIResult() { Success = false, Message = String.Format("AddHostInstance '{0}' on server '{1}' failed: {2}", hostName, serverName, ex.Message) };
            }
        }
        
        public static WMIResult AddReceiveHandler(string adapterName, string hostName, string adapterConfig)
        {
            try
            {
                ManagementObject receiveHandler = new ManagementClass(BTS_WMINameSpace, BTS_ReceiveHandlerNameSpace, new ObjectGetOptions()).CreateInstance();
                receiveHandler.SetPropertyValue("AdapterName", adapterName);
                receiveHandler.SetPropertyValue("HostName", hostName);
                receiveHandler.SetPropertyValue("HostNameToSwitchTo", hostName);
                if (adapterConfig != "")
                    receiveHandler.SetPropertyValue("CustomCfg", adapterConfig);
                receiveHandler.Put();
                
                return new WMIResult() { Success = true, Message = String.Format("Host '{0}' added as a receive handler to adapter '{1}'.", hostName, adapterName) };
            }
            catch (Exception ex)
            {
                return new WMIResult() { Success = false, Message = String.Format("AddReceiveHandler for host '{0}' and adapter '{1}' failed: {2}", hostName, adapterName, ex.Message) };
            }
        }
        
        public static WMIResult AddSendHandler(string adapterName, string hostName, bool isDefault, string adapterConfig)
        {
            try
            {
                ManagementObject sendHandler = new ManagementClass(BTS_WMINameSpace, BTS_SendHandlerNameSpace, new ObjectGetOptions()).CreateInstance();
                sendHandler.SetPropertyValue("AdapterName", adapterName);
                sendHandler.SetPropertyValue("HostName", hostName);
                sendHandler.SetPropertyValue("HostNameToSwitchTo", hostName);
                sendHandler.SetPropertyValue("IsDefault", isDefault);
                if (adapterConfig != "")
                    sendHandler.SetPropertyValue("CustomCfg", adapterConfig);
                sendHandler.Put();
        
                return new WMIResult() { Success = true, Message = String.Format("Host '{0}' added as a send handler to adapter '{1}'.", hostName, adapterName) };
            }
            catch (Exception ex)
            {
                return new WMIResult() { Success = false, Message = String.Format("AddSendHandler for host '{0}' and adapter '{1}' failed: {2}", hostName, adapterName, ex.Message) };
            }
        }
        
        private static bool ObjectExists(ManagementClass mgtClass, string key, string value)
        {
            foreach (ManagementObject mgtObj in mgtClass.GetInstances())
            {
                if (mgtObj[key].ToString() == value)
                {
                    return true;
                }
            }
            return false;
        }
        
        private static bool ObjectExists(ManagementClass mgtClass, string key, string value, string key2, string value2)
        {
            foreach (ManagementObject mgtObj in mgtClass.GetInstances())
            {
                if ((mgtObj[key].ToString() == value) && (mgtObj[key2].ToString() == value2))
                {
                    return true;
                }
            }
            return false;
        }
        
        public static WMIResult RemoveAdapter(string adapterName)
        {
            try
            {
                ManagementObject adapterSetting = null;
                ManagementClass adapterSettingClass = new ManagementClass(BTS_WMINameSpace, BTS_AdapterSettingNameSpace, new ObjectGetOptions());
                if (adapterSettingClass.GetInstances().Count <= 0)
                {
                    adapterSetting = adapterSettingClass.CreateInstance();
                    adapterSetting.SetPropertyValue("Name", adapterName);
                    if (ObjectExists(adapterSettingClass, "Name", adapterName))
                    {
                        adapterSetting.Delete();
                    }
                }
        
                return new WMIResult() { Success = true, Message = String.Format("Adapter '{0}' has been removed.", adapterName) };
            }
            catch (Exception ex)
            {
                return new WMIResult() { Success = false, Message = String.Format("RemoveAdapter '{0}' failed: {1}", adapterName, ex.Message) };
            }
        }
        
        public static WMIResult RemoveHost(string hostName)
        {
            try
            {
                ManagementClass hostSettingClass = new ManagementClass(BTS_WMINameSpace, BTS_HostSettingNameSpace, new ObjectGetOptions());
                if (ObjectExists(hostSettingClass, "Name", hostName))
                {
                    ManagementObject hostSetting = hostSettingClass.CreateInstance();
                    hostSetting["Name"] = hostName;
                    hostSetting.Delete();
                }
        
                return new WMIResult() { Success = true, Message = String.Format("Host '{0}' has been removed.", hostName) };
            }
            catch (Exception ex)
            {
                return new WMIResult() { Success = false, Message = String.Format("RemoveHost '{0}' failed: {1}", hostName, ex.Message) };
            }
        }
        
        public static WMIResult RemoveHostInstance(string serverName, string hostName)
        {
            try
            {
                string str = "Microsoft BizTalk Server " + hostName + " " + serverName;
                ManagementClass hostInstanceClass = new ManagementClass(BTS_WMINameSpace, BTS_HostInstanceNameSpace, new ObjectGetOptions());
                EnumerationOptions options = new EnumerationOptions();
                options.ReturnImmediately = false;
                ManagementObjectCollection hostInstances = hostInstanceClass.GetInstances(options);
                ManagementObject hostInstance = null;
                foreach (ManagementObject mgtObj in hostInstances)
                {
                    if ((mgtObj["Name"] != null) && (mgtObj["Name"].ToString().ToUpper() == str.ToUpper()))
                    {
                        hostInstance = mgtObj;
                    }
                }
                if (hostInstance != null)
                {
                    if ((((BTSHostType)Enum.Parse(typeof(BTSHostType), hostInstance["HostType"].ToString())) != BTSHostType.Isolated) && ((BTSServiceState)Enum.Parse(typeof(BTSServiceState), hostInstance["ServiceState"].ToString()) == BTSServiceState.Running))
                    {
                        hostInstance.InvokeMethod("Stop", null);
                    }
                    hostInstance.InvokeMethod("UnInstall", null);
                    ManagementObject serverHostClass = new ManagementClass(BTS_WMINameSpace, BTS_ServerHostNameSpace, new ObjectGetOptions()).CreateInstance();
                    serverHostClass["ServerName"] = serverName;
                    serverHostClass["HostName"] = hostName;
                    serverHostClass.InvokeMethod("UnMap", null);
                }
        
                return new WMIResult() { Success = true, Message = String.Format("Host instance '{0}' has been removed on server '{1}'.", hostName, serverName) };
            }
            catch (Exception ex)
            {
                return new WMIResult() { Success = false, Message = String.Format("RemoveHostInstance '{0}' on server '{1}' failed: {2}", hostName, serverName, ex.Message) };
            }
        }
        
        public static WMIResult RemoveReceiveHandler(string adapterName, string hostName)
        {
            try
            {
                ManagementClass receiveHandlerClass = new ManagementClass(BTS_WMINameSpace, BTS_ReceiveHandlerNameSpace, new ObjectGetOptions());
                if (ObjectExists(receiveHandlerClass, "HostName", hostName, "AdapterName", adapterName))
                {
                    ManagementObject receiveHandler = receiveHandlerClass.CreateInstance();
                    receiveHandler.SetPropertyValue("AdapterName", adapterName);
                    receiveHandler.SetPropertyValue("HostName", hostName);
                    receiveHandler.Delete();
                }
        
                return new WMIResult() { Success = true, Message = String.Format("Host '{0}' removed as a receive handler to adapter '{1}'.", hostName, adapterName) };
            }
            catch (Exception ex)
            {
                return new WMIResult() { Success = false, Message = String.Format("RemoveReceiveHandler for host '{0}' and adapter '{1}' failed: {2}", hostName, adapterName, ex.Message) };
            }
        }
        
        public static WMIResult RemoveSendHandler(string adapterName, string hostName)
        {
            try
            {
                ManagementClass sendHandlerClass = new ManagementClass(BTS_WMINameSpace, BTS_SendHandlerNameSpace, new ObjectGetOptions());
                if (ObjectExists(sendHandlerClass, "HostName", hostName, "AdapterName", adapterName))
                {
                    ManagementObject sendHandler = sendHandlerClass.CreateInstance();
                    sendHandler.SetPropertyValue("AdapterName", adapterName);
                    sendHandler.SetPropertyValue("HostName", hostName);
                    sendHandler.Delete();
                }
        
                return new WMIResult() { Success = true, Message = String.Format("Host '{0}' removed as a send handler to adapter '{1}'.", hostName, adapterName) };
            }
            catch (Exception ex)
            {
                return new WMIResult() { Success = false, Message = String.Format("RemoveSendHandler for host '{0}' and adapter '{1}' failed: {2}", hostName, adapterName, ex.Message) };
            }
        }
    }
}
