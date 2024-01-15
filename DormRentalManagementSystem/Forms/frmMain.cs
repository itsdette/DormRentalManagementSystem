using DormRentalManagementSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormRentalManagementSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public frmLoginSample frmLoginSample
        {
            get => default;
            set
            {
            }
        }

        public frmClosedWarning frmClosedWarning
        {
            get => default;
            set
            {
            }
        }

        public frmLoginSample frmLoginSample1
        {
            get => default;
            set
            {
            }
        }

        public frmClosedWarning frmClosedWarning1
        {
            get => default;
            set
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            new frmClosedWarning().ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //frmAdminWindows ad = new frmAdminWindows();
            //ad.ShowDialog();
          ///  new frmLogin().ShowDialog();
          new frmLoginSample().ShowDialog();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                panel2.MinimumSize = new System.Drawing.Size();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
