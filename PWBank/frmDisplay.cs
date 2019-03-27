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
    public partial class frmDisplay : Form
    {
        private string fileName;
        Account acc;
        
        List<Account.Info> infoArr = new List<Account.Info>();
        
        public frmDisplay(string file)
        {
            acc = new Account(file);
            fileName = file;
            InitializeComponent();
            RefreshListBox();
        }

        public void RefreshInfo()
        {
            acc.SetInfo();
        }
        private void RefreshListBox()
        {
            lstAcc.Items.Clear();
            foreach (string name in acc.GetAccountNames())
            {
                lstAcc.Items.Add(name);
            }
        }

        private void lstAcc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            acc.SetInfo();
            Account.Info selectedInfo = acc.GetInfoAtIndex(lstAcc.SelectedIndex);
            frmDisplay frm = this;
            frmDisplayInfo frmDisplayInfo = new frmDisplayInfo(selectedInfo.account, selectedInfo.userName, selectedInfo.password, fileName, ref frm);
            frmDisplayInfo.Show();
            
        }


        #region MenuStrip
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreateInfo frmCreateInfo = new frmCreateInfo(fileName);
            frmCreateInfo.Show();
            Hide();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acc.SetInfo();
            RefreshListBox();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstAcc.SelectedIndex != -1)
            {
                acc.DeleteInfoAtIndex(lstAcc.SelectedIndex);
            }
            RefreshListBox();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSignIn frmSignIn = new frmSignIn();
            frmSignIn.Show();
            Hide();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelp frmHelp = new frmHelp();
            frmHelp.Show();
        }
        #endregion

    }
}
