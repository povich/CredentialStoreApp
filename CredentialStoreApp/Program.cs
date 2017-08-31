using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net.Config;

namespace CredentialStoreApp
{
    static class Program
    {
        // defines for commandline output
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int AttachParentProcess = -1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += LoadResources;
            AttachConsole(AttachParentProcess);
            Console.WriteLine(@"");
            SetUpLogging();
            ProgramArguments.SetArgs(args);
            ProgramArguments.CheckForHelp();

            if (ProgramArguments.Silent.IsSet)
            {
                new CredentialStoreConsole().Start();
                Environment.Exit(0);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                CredentialStoreUi main = new CredentialStoreUi();
                //new MainPresenter(main);
                Application.ThreadException += ApplicationOnThreadException;
                //Application.ApplicationExit += main.ApplicationExitingHandler;
                main.ShowDialog();
            }
        }
        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs threadExceptionEventArgs)
        {
            //Log.FatalFormat("An unhandled application level exception has occurred: {0}{1}", Environment.NewLine, threadExceptionEventArgs.Exception);
            throw threadExceptionEventArgs.Exception;
        }

        private static Assembly LoadResources(object sender, ResolveEventArgs args)
        {

            string resourceName = new AssemblyName(args.Name).Name + ".dll";
            string resource = Array.Find(typeof(Program).Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
            {
                // ReSharper disable once PossibleNullReferenceException - if something goes wrong an exception should be thrown
                Byte[] assemblyData = new Byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }

        private static void SetUpLogging()
        {
            //XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "PIPLogging.xml"));
            //Log.InfoFormat("Logging set up for {0}.", AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "PIPLogging.xml");
            string resource = Array.Find(typeof(Program).Assembly.GetManifestResourceNames(), element => element.EndsWith("Logging.xml"));
            Stream inFile = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
            XmlConfigurator.Configure(inFile);
        }
    }
}
