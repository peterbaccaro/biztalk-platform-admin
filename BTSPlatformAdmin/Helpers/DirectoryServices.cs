using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace BTSPlatformAdmin.Helpers
{
    public static class DirectoryServices
    {
        public static bool CredentialsValid(string accountName, string password)
        {
            PrincipalContext principalContext = IsLocalAccount(accountName) ? new PrincipalContext(ContextType.Machine, Environment.MachineName) : new PrincipalContext(ContextType.Domain, accountName.Split('\\')[0]);

            return principalContext.ValidateCredentials(accountName, password);
        }

        public static bool GroupExists(string groupName)
        {
            try
            {
                PrincipalContext principalContext = IsLocalGroup(groupName) ? new PrincipalContext(ContextType.Machine, Environment.MachineName) : new PrincipalContext(ContextType.Domain, groupName.Split('\\')[0]);
                GroupPrincipal groupPrincipal = GroupPrincipal.FindByIdentity(principalContext, groupName);

                return groupPrincipal != null;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsLocalGroup(string groupname)
        {
            if (!groupname.Contains("\\") || groupname.StartsWith("\\") || groupname.ToUpper().Contains(Environment.MachineName.ToUpper()))
                return true;
            else
                return false;
        }

        private static bool IsLocalAccount(string accountName)
        {
            if (!accountName.Contains("\\") || accountName.StartsWith("\\") || accountName.ToUpper().Contains(Environment.MachineName.ToUpper()))
                return true;
            else
                return false;
        }
    }
}
