namespace CredentialStoreApp
{
    partial class CredentialStoreUi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetCred = new System.Windows.Forms.Button();
            this.lblDomain = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tbDomain = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPasswordResult = new System.Windows.Forms.Label();
            this.tbPasswordResult = new System.Windows.Forms.TextBox();
            this.tbUserNameResult = new System.Windows.Forms.TextBox();
            this.tbDomainResult = new System.Windows.Forms.TextBox();
            this.lblUserNameResult = new System.Windows.Forms.Label();
            this.lblDomainResult = new System.Windows.Forms.Label();
            this.btnSaveCred = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetCred
            // 
            this.btnGetCred.Location = new System.Drawing.Point(12, 170);
            this.btnGetCred.Name = "btnGetCred";
            this.btnGetCred.Size = new System.Drawing.Size(121, 27);
            this.btnGetCred.TabIndex = 1;
            this.btnGetCred.Text = "Get Credential";
            this.btnGetCred.UseVisualStyleBackColor = true;
            this.btnGetCred.Click += new System.EventHandler(this.btnGetCreds_Click);
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Location = new System.Drawing.Point(13, 50);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(56, 17);
            this.lblDomain.TabIndex = 2;
            this.lblDomain.Text = "Domain";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(300, 50);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(75, 17);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "UserName";
            // 
            // tbDomain
            // 
            this.tbDomain.Location = new System.Drawing.Point(12, 79);
            this.tbDomain.Name = "tbDomain";
            this.tbDomain.Size = new System.Drawing.Size(271, 22);
            this.tbDomain.TabIndex = 6;
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(303, 79);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(271, 22);
            this.tbUserName.TabIndex = 8;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(12, 132);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(562, 22);
            this.tbPassword.TabIndex = 9;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(13, 112);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "Password";
            // 
            // lblPasswordResult
            // 
            this.lblPasswordResult.AutoSize = true;
            this.lblPasswordResult.Location = new System.Drawing.Point(13, 274);
            this.lblPasswordResult.Name = "lblPasswordResult";
            this.lblPasswordResult.Size = new System.Drawing.Size(69, 17);
            this.lblPasswordResult.TabIndex = 16;
            this.lblPasswordResult.Text = "Password";
            // 
            // tbPasswordResult
            // 
            this.tbPasswordResult.Location = new System.Drawing.Point(12, 294);
            this.tbPasswordResult.Name = "tbPasswordResult";
            this.tbPasswordResult.Size = new System.Drawing.Size(562, 22);
            this.tbPasswordResult.TabIndex = 15;
            // 
            // tbUserNameResult
            // 
            this.tbUserNameResult.Location = new System.Drawing.Point(303, 241);
            this.tbUserNameResult.Name = "tbUserNameResult";
            this.tbUserNameResult.Size = new System.Drawing.Size(271, 22);
            this.tbUserNameResult.TabIndex = 14;
            // 
            // tbDomainResult
            // 
            this.tbDomainResult.Location = new System.Drawing.Point(12, 241);
            this.tbDomainResult.Name = "tbDomainResult";
            this.tbDomainResult.Size = new System.Drawing.Size(271, 22);
            this.tbDomainResult.TabIndex = 13;
            // 
            // lblUserNameResult
            // 
            this.lblUserNameResult.AutoSize = true;
            this.lblUserNameResult.Location = new System.Drawing.Point(300, 212);
            this.lblUserNameResult.Name = "lblUserNameResult";
            this.lblUserNameResult.Size = new System.Drawing.Size(75, 17);
            this.lblUserNameResult.TabIndex = 12;
            this.lblUserNameResult.Text = "UserName";
            // 
            // lblDomainResult
            // 
            this.lblDomainResult.AutoSize = true;
            this.lblDomainResult.Location = new System.Drawing.Point(13, 212);
            this.lblDomainResult.Name = "lblDomainResult";
            this.lblDomainResult.Size = new System.Drawing.Size(56, 17);
            this.lblDomainResult.TabIndex = 11;
            this.lblDomainResult.Text = "Domain";
            // 
            // btnSaveCred
            // 
            this.btnSaveCred.Location = new System.Drawing.Point(303, 170);
            this.btnSaveCred.Name = "btnSaveCred";
            this.btnSaveCred.Size = new System.Drawing.Size(121, 27);
            this.btnSaveCred.TabIndex = 17;
            this.btnSaveCred.Text = "Save Credential";
            this.btnSaveCred.UseVisualStyleBackColor = true;
            this.btnSaveCred.Click += new System.EventHandler(this.btnSaveCred_Click);
            // 
            // CredentialStoreUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 364);
            this.Controls.Add(this.btnSaveCred);
            this.Controls.Add(this.lblPasswordResult);
            this.Controls.Add(this.tbPasswordResult);
            this.Controls.Add(this.tbUserNameResult);
            this.Controls.Add(this.tbDomainResult);
            this.Controls.Add(this.lblUserNameResult);
            this.Controls.Add(this.lblDomainResult);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.tbDomain);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblDomain);
            this.Controls.Add(this.btnGetCred);
            this.Name = "CredentialStoreUi";
            this.Text = "CredentialStoreUi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGetCred;
        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox tbDomain;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblPasswordResult;
        private System.Windows.Forms.TextBox tbPasswordResult;
        private System.Windows.Forms.TextBox tbUserNameResult;
        private System.Windows.Forms.TextBox tbDomainResult;
        private System.Windows.Forms.Label lblUserNameResult;
        private System.Windows.Forms.Label lblDomainResult;
        private System.Windows.Forms.Button btnSaveCred;
    }
}

