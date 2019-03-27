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
    public partial class frmCreateInfo : Form
    {
        Account acc;
        string file;

        public frmCreateInfo(string file)
        {
            this.file = file;
            acc = new Account(file);
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Account.Info inputInfo = new Account.Info(txtAccount.Text, txtUsername.Text, txtPassword.Text);
            if (acc.UniqueInfo(inputInfo))
            {
                acc.AddInfo(inputInfo);
            }
            frmDisplay frmDisplay = new frmDisplay(file);
            frmDisplay.Show();
            Hide();
        }

        private void frmCreateInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmDisplay frmDisplay = new frmDisplay(file);
            frmDisplay.Show();
        }
    }
}
