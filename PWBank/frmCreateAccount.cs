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
    public partial class frmCreateAccount : Form
    {
        Account acc = new Account();
        StreamWriter writer;
        FileStream creater;
        public frmCreateAccount()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            bool PWStrong = true;
            bool onlyLetters = true;
            bool illegal = false;
            bool unique = acc.Unique(txtUsername.Text);
            foreach (char c in txtPassword.Text)
            {
                if (c == 'ª' )
                {
                    illegal = true;
                    break;
                }
                if (!char.IsLetter(c))
                {
                    onlyLetters = false;
                    break;
                }
            }
            if (unique)
            {
                if ((onlyLetters || txtPassword.Text.Length < 8) && !illegal)
                {
                    if (MessageBox.Show("Your password is weak. Would you like to continue with this password?", "Password Weak", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        PWStrong = false;
                    }
                }
                else if (illegal)
                {
                    MessageBox.Show("You have an illegal character in your password or username, please use only letters, numbers, and keyboard symbols.");
                }

                if (PWStrong)
                {
                    string username = txtUsername.Text;
                    string password = txtPassword.Text;
                    creater = File.Create(acc.folderPath + @"\" + username + ".userInfo");
                    creater.Close();

                    writer = new StreamWriter(acc.folderPath + @"\" + username + ".userInfo", false);
                    writer.Write(password + String.Format("\n"));
                    writer.Close();

                    frmSignIn frmSignIn = new frmSignIn();
                    frmSignIn.Show();
                    Hide();
                }
            } else
            { 
                MessageBox.Show("That username has already been taken.");
            }
        }
    }
}
