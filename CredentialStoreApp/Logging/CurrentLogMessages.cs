using System;
using System.Windows.Forms;

using log4net;
using log4net.Core;
using log4net.Repository.Hierarchy;
using ConfigurationUtility.Logging;

namespace InsyteDeployment.MainWindow.Logging
{
    public partial class CurrentLogMessages : Form
    {
        private static CurrentLogMessages _statusWindow;
        private static bool _shown;
        private static TextBoxAppender _appender;

        private CurrentLogMessages()
        {
            InitializeComponent();
            SetUpUiLogging();
        }

        public static CurrentLogMessages GetStatusWindow()
        {
            return _statusWindow = _statusWindow ?? GetNewStatusWindow();
        }

        private static CurrentLogMessages GetNewStatusWindow()
        {
            var window = new CurrentLogMessages();
            window.Closing += WindowOnClosing;

            return window;
        }

        private static void WindowOnClosing(object o, EventArgs e)
        {
            _shown = false;
            _statusWindow = null;
            ((Hierarchy)LogManager.GetRepository()).Root.RemoveAppender(_appender);
        }

        private void SetUpUiLogging()
        {
            _appender = new TextBoxAppender { AppenderTextBox = tbOutput, Threshold = Level.Debug, Name = "TBAppender" };
            ((Hierarchy)LogManager.GetRepository()).Root.AddAppender(_appender);
        }

        public void ShowOneWindow()
        {
            if (!_shown)
            {
                _shown = true;
                Show();
            }
        }

        private void BtnCloseClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
