using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalk.Administration
{
    public static class PlatformSettingsExtensions
    {
        public static string Stringify(this PlatformSettingsHost platformSettingHost)
        {
            string result = "Host: ";

            result += String.Format("{0} ", platformSettingHost.hostname);
            result += String.Format("(Default:{0}, ", platformSettingHost.isdefault ? "Yes" : "No");
            result += String.Format("Tracking:{0}, ", platformSettingHost.hosttracking ? "Yes" : "No");
            result += String.Format("Trusted:{0}, ", platformSettingHost.authtrusted ? "Yes" : "No");
            result += String.Format("Type:{0}, ", platformSettingHost.hosttype);
            result += String.Format("32BitOnly:{0})", platformSettingHost.ishost32bitonly ? "Yes" : "No");

            return result;
        }

        public static string Stringify(this PlatformSettingsHostInstance platformSettingsHostInstance)
        {
            string result = "Host Instance: ";

            result += String.Format("{0} ", platformSettingsHostInstance.hostname);
            result += String.Format("(Server:{0}, ", platformSettingsHostInstance.servername);
            result += String.Format("Logon:{0}, ", platformSettingsHostInstance.username);
            result += String.Format("Disabled:{0})", platformSettingsHostInstance.isdisabled ? "Yes" : "No");

            return result;
        }

        public static string Stringify(this PlatformSettingsAdapter platformSettingsAdapter)
        {
            string result = "Adapter: ";

            result += String.Format("{0} ", platformSettingsAdapter.name);
            result += String.Format("(Comment:{0})", platformSettingsAdapter.comment);

            return result;
        }

        public static string Stringify(this PlatformSettingsAdapterReceiveHandler platformSettingsAdapterReceiveHandler)
        {
            string result = "Receive Handler: ";

            result += String.Format("{0} ", platformSettingsAdapterReceiveHandler.hostname);
            result += String.Format("(Config:{0})", platformSettingsAdapterReceiveHandler.config);

            return result;
        }


        public static string Stringify(this PlatformSettingsAdapterSendHandler platformSettingsAdapterSendHandler)
        {
            string result = "Send Handler: ";

            result += String.Format("{0} ", platformSettingsAdapterSendHandler.hostname);
            result += String.Format("(Default:{0}, ", platformSettingsAdapterSendHandler.isdefault ? "Yes" : "No");
            result += String.Format("Config:{0})", platformSettingsAdapterSendHandler.config);

            return result;
        }

    }
}
