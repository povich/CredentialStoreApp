using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CredentialManagement;
using log4net;

namespace CredentialStoreApp
{
    public class CredentialStoreConsole
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Start()
        {
            //if (ProgramArguments.GetAll.IsSet)
            //{
            //    Console.WriteLine(CredentialUtil.GetCredentials());
            //}
            //else 
            Log.DebugFormat("{0}Start{0}",new string('-',30));
            if (ProgramArguments.Get.IsSet) { GetCredential();}
            else if (ProgramArguments.Create.IsSet) { SetCredential();}
            else if (ProgramArguments.Remove.IsSet)
            {
                RemoveCredential();
            }
            else
            {
                ProgramArguments.Help.IsSet = true;
                ProgramArguments.CheckForHelp();
            }
        }

        public void GetCredential()
        {
            try
            {
                Log.DebugFormat(@"Getting credential.");
                if (ProgramArguments.Username.IsSet)
                {
                    Log.DebugFormat(@"Looking up user: {0}", ProgramArguments.Username.Value);
                    string target = GetTarget();
                    Log.DebugFormat(@"Target to retrieve (domain\user or just user if domain not specified): {0}", target);
                    Credential cred = CredentialUtil.GetCredential(target);
                    LogCredential(cred);
                    ShowCredential(cred);
                }
                else
                {
                    Console.WriteLine(@"Username must be set.");
                    Log.Error(@"Username must be set.");
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        private void ShowCredential(Credential credential)
        {
            if (credential != null)
            {
                string output = string.Format("Target:   {1}{0}Username: {2}{0}Password: {3}{0}",
                    Environment.NewLine, credential.Target, credential.Username, credential.Password);
                Console.WriteLine(output);
            }
            else
            {
                Console.WriteLine(@"No credential was available.{0}Target:   {0}Username: {0}Password: {0}",Environment.NewLine);
            }
        }

        private void LogCredential(Credential credential)
        {
            if (credential != null)
            {
                string output = string.Format("Target:   {1}{0}Username: {2}{0}",
                    Environment.NewLine, credential.Target, credential.Username);
                Log.DebugFormat("Credential info: {1}{0}",Environment.NewLine, output);
            }
            else
            {
                Log.DebugFormat("No credential was available.");
            }
        }

        public void SetCredential()
        {
            if (ProgramArguments.Username.IsSet && ProgramArguments.Password.IsSet)
            {
                Credential cred = new Credential(ProgramArguments.Username.Value, ProgramArguments.Password.Value);
                LogCredential(cred);
                CredentialUtil.SetCredentials(GetTarget(), cred.Username, cred.Password);
            }
            else
            {
                Console.WriteLine(@"Username and Password must be set.");
            }
        }

        public void RemoveCredential()
        {
            if (ProgramArguments.Username.IsSet)
            {
                CredentialUtil.RemoveCredentials(GetTarget());
            }
            else
            {
                Console.WriteLine(@"Username must be set.");
            }
            
        }

        private string GetTarget()
        {
            return ProgramArguments.Domain.IsSet ? ProgramArguments.Domain.Value + @"\" + ProgramArguments.Username.Value : ProgramArguments.Username.Value;
        }
    }
}
