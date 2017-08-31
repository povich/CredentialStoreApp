using System;
using System.Windows.Forms;
using log4net.Appender;

namespace ConfigurationUtility.Logging
{
    public class TextBoxAppender : AppenderSkeleton
    {
        private TextBox _textBox;
        public TextBox AppenderTextBox
        {
            get
            {
                return _textBox;
            }
            set
            {
                _textBox = value;
            }
        }
        public string FormName { get; set; }
        public string TextBoxName { get; set; }

        private Control FindControlRecursive(Control root, string textBoxName)
        {
            if (root.Name == textBoxName) return root;
            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, textBoxName);
                if (t != null) return t;
            }
            return null;
        }

        private bool _handleAvailable;
        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            if (_textBox == null)
            {
                if (String.IsNullOrEmpty(FormName) ||
                    String.IsNullOrEmpty(TextBoxName))
                    return;

                Form form = Application.OpenForms[FormName];
                if (form == null)
                    return;

                _textBox = (TextBox)FindControlRecursive(form, TextBoxName);
                if (_textBox == null)
                    return;

                form.FormClosing += (s, e) => _textBox = null;
            }
            if (IsHandleAvailable())
            {
                _textBox.BeginInvoke((MethodInvoker)(() => _textBox.AppendText(loggingEvent.RenderedMessage + Environment.NewLine)));
            }
        }

        private bool IsHandleAvailable()
        {
            if(!_textBox.InvokeRequired) _handleAvailable =  (_textBox.Handle != null) ? true : false;
                                                           
            return _handleAvailable;
        }
    }
}