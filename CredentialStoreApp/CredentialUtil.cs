using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredentialManagement;

namespace CredentialStoreApp
{
    public static class CredentialUtil
    {
        public static Credential GetCredential(string target)
        {
            var cm = new Credential { Target = target };
            if (!cm.Load())
            {
                return null;
            }

            return cm;
        }

        public static Credential GetCredentials()
        {
            var cm = new Credential();
            if (!cm.Load())
            {
                return null;
            }

            return cm;
        }

        public static bool SetCredentials(
             string target, string username, string password)
        {
            return new Credential
            {
                Target = target,
                Username = username,
                Password = password,
                PersistanceType = PersistanceType.LocalComputer
            }.Save();
        }

        public static bool RemoveCredentials(string target)
        {
            return new Credential { Target = target }.Delete();
        }
    }
}
