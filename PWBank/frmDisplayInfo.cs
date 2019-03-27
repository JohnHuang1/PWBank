using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PWBank
{
    public partial class frmDisplayInfo : Form
    {
        string accName, username, password;
        TextBox txtAccount, txtUsername, txtPassword;
        Account acc;
        frmDisplay frmParent;

        private void frmDisplayInfo_Load(object sender, EventArgs e)
        {
            lblAccount.Text = accName;
            lblUsername.Text = username;
            lblPassword.Text = password;
        }

        #region Labels
        private void lblAccount_DoubleClick(object sender, EventArgs e)
        {
            txtAccount = new TextBox();
            txtAccount.Size = lblAccount.Size;
            Controls.Add(txtAccount);
            txtAccount.Location = lblAccount.Location;
            txtAccount.Text = lblAccount.Text;
            lblAccount.Hide();
            if (btnClose.Text == "Close")
            {
                btnClose.Text = "Save";
            }
        }

        private void lblUsername_DoubleClick(object sender, EventArgs e)
        {
            txtUsername = new TextBox();
            txtUsername.Size = lblUsername.Size;
            Controls.Add(txtUsername);
            txtUsername.Location = lblUsername.Location;
            txtUsername.Text = lblUsername.Text;
            lblUsername.Hide();
            if (btnClose.Text == "Close")
            {
                btnClose.Text = "Save";
            }
        }

        private void lblPassword_DoubleClick(object sender, EventArgs e)
        {
            txtPassword = new TextBox();
            txtPassword.Size = lblPassword.Size;
            Controls.Add(txtPassword);
            txtPassword.Location = lblPassword.Location;
            txtPassword.Text = lblPassword.Text;
            lblPassword.Hide();
            if (btnClose.Text == "Close")
            {
                btnClose.Text = "Save";
            }
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Text == "Save")
            {
                Account.Info oldInfo = new Account.Info(accName, username, password);
                string newAccName, newUsername, newPassword;
                #region IfElse Statements
                if (txtAccount != null)
                {
                    newAccName = txtAccount.Text;
                }else {
                    newAccName = accName;
                }

                if (txtUsername != null)
                {
                    newUsername = txtUsername.Text;
                }
                else
                {
                    newUsername = username;
                }

                if (txtPassword != null)
                {
                    newPassword = txtPassword.Text;
                }
                else
                {
                    newPassword = password;
                }
                #endregion
                Account.Info newInfo = new Account.Info(newAccName, newUsername, newPassword);
                acc.ReplaceInfo(oldInfo, newInfo);
                frmParent.RefreshInfo();
                Hide();
            } else
            {
                Hide();
            }
        }
        
        public frmDisplayInfo(string accName, string username, string password, string fileName, ref frmDisplay frmDisplay)
        {
            this.accName = accName;
            this.username = username;
            this.password = password;
            acc = new Account(fileName);

            frmParent = frmDisplay;
            InitializeComponent();
        }
        
        

    }
}
