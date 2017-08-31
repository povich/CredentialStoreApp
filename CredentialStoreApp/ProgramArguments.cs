using System;
using System.Collections.Generic;
using System.Linq;

namespace CredentialStoreApp
{
    public class ProgramArguments
    {
        //private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly string Nl = Environment.NewLine;

        private const string Tabs = "\t\t\t";

        public string Name { get; private set; }

        public string ShortName { get; private set; }

        public string Description { get; private set; }

        public bool IsSet { get; set; }

        public string Value { get; set; }

        public static readonly ProgramArguments Help = new ProgramArguments("Help", "?", "Arguments available for the command line.");

        //public static readonly ProgramArguments Config = new ProgramArguments("Config", "C", String.Format(@"Upgrade.ini location.{0}{1}Config=c:\location\Upgrade.ini", Nl, Tabs));
        public static readonly ProgramArguments Silent = new ProgramArguments("Silent", "S", @"Cmd line only. No UI.");

        public static readonly ProgramArguments Create = new ProgramArguments("Create", "C", @"Create credential. ex. Create (Must have full credential information including target, username, password)");

        public static readonly ProgramArguments Get = new ProgramArguments("Get", "G", @"Get specified credential. ex. Get=JoeBob");

        //public static readonly ProgramArguments GetAll = new ProgramArguments("GetAll", "GA", @"Get all credentials stored. ex. GetAll");

        public static readonly ProgramArguments Domain = new ProgramArguments("Domain", "D", @"Optional domain of credential. ex. Domain=omnicell.  This can be skipped for creds that dont require the domain to be specified.");

        public static readonly ProgramArguments Username = new ProgramArguments("Username", "U", @"Username to be stored. ex. Username=JoeBob");

        public static readonly ProgramArguments Password = new ProgramArguments("Password", "P", @"Password to be stored. ex. Password=12345");

        public static readonly ProgramArguments Remove = new ProgramArguments("Remove", "R", @"Remove Target from credential store..");

        //public static readonly ProgramArguments SkipDbBackup = new ProgramArguments("SkipDbBackup", "SDB", @"Tells the deployment tool to Skip Db Backups. DO NOT USE THIS IN PRODUCTION!!!");

        //public static readonly ProgramArguments Branch = new ProgramArguments("Branch", "B", string.Format(@"Tells the deployment tool to name db branches 'SiteNameDB'-'Branch'.  Also appends branch to install locations.{0}{1}Branch=feature-myfeature", Nl, Tabs));

        public static readonly List<ProgramArguments> AllArgs = new List<ProgramArguments> { Help, Silent, Create, Get, Domain, Username, Password, Remove };

        private ProgramArguments(string name, string shortName, string description)
        {
            Name = name;
            ShortName = shortName;
            Description = description;
        }

        public static List<string> GetAllDetails()
        {
            return AllArgs.Select(x => x.NameAndDescription()).ToList();
        }

        public string NameAndDescription()
        {
            return Name.PadRight(20, ' ') + ShortName.PadRight(7) + Description;
        }

        public override string ToString()
        {
            return Name;
        }

        public static void SetArgs(string[] args)
        {
            List<string> argList = new List<string>(args);
            argList = argList.Select(x => x.TrimStart('\\').TrimStart('-').TrimStart('/')).ToList();

            foreach (string arg in argList)
            {
                string param = arg;
                string value = String.Empty;

                if (arg.Contains("="))
                {
                    var vals = arg.Split('=');
                    param = vals[0];
                    value = vals[1];
                }

                ProgramArguments argFound = AllArgs.FirstOrDefault(x => x.Name.ToLower().Equals(param.ToLower()) || x.ShortName.ToLower().Equals(param.ToLower()));
                if (argFound != null)
                {
                    //Log.InfoFormat(@"Settings {0} as found.  Value is {1}", param, value);
                    argFound.IsSet = true;
                    argFound.Value = value;
                }
                else
                {
                    Console.WriteLine(@"{0}Not valid arg: {1}{0}", Nl, param);
                    Help.IsSet = true;
                }
            }
        }

        public static void CheckForHelp()
        {
            if (ProgramArguments.Help.IsSet)
            {
                ProgramArguments.GetAllDetails().ForEach(Console.WriteLine);
                Environment.Exit(0);
            }
        }
    }
}