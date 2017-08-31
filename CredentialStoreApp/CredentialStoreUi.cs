using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CredentialManagement;

namespace CredentialStoreApp
{
    public partial class CredentialStoreUi : Form
    {
        public CredentialStoreUi()
        {
            InitializeComponent();
        }

        private void btnGetCreds_Click(object sender, EventArgs e)
        {
            var user =  CredentialUtil.GetCredential(GetTarget()) ?? new Credential();
            tbDomainResult.Text = GetDomain(user);
            tbUserNameResult.Text = user.Username;
            tbPasswordResult.Text = user.Password;
        }

        private static string GetDomain(Credential user)
        {
            string[] userParts = user.Target?.Split('\\');

            return userParts?.Length < 2 ? string.Empty : userParts?[0] ?? string.Empty;
        }

        private string GetTarget()
        {
            return string.IsNullOrWhiteSpace(tbDomain.Text) ? tbUserName.Text : tbDomain.Text + @"\" + tbUserName.Text;
        }

        private void btnSaveCred_Click(object sender, EventArgs e)
        {
            CredentialUtil.SetCredentials(GetTarget(), tbUserName.Text, tbPassword.Text);
        }
    }
}
