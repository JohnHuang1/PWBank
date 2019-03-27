using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace PWBank
{
    public partial class frmSignIn : Form
    {
        Account acc = new Account();
        public frmSignIn()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (!acc.Unique(txtUsername.Text))
            {
                acc = new Account(txtUsername.Text);
                if (acc.accountPassword == txtPassword.Text)
                {
                    frmDisplay frmDisplay = new frmDisplay(txtUsername.Text);
                    frmDisplay.Show();
                    Hide();
                } else
                {
                    MessageBox.Show("Password is incorrect.");
                }
            } else
            {
                MessageBox.Show("Username is incorrect.");
            }
        }

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            frmCreateAccount frmCreateAccount = new frmCreateAccount();
            frmCreateAccount.Show();
            Hide();
        }
    }
}
