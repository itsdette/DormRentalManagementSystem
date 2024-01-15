using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormRentalManagementSystem.Forms
{
    public partial class frmEmailSender : Form
    {


        public frmEmailSender()
        {
            InitializeComponent();
        }

        public frmEmailTemplate frmEmailTemplate
        {
            get => default;
            set
            {
            }
        }

        public frmEmailNew frmEmailNew
        {
            get => default;
            set
            {
            }
        }

        public frmEmailNew frmEmailNew1
        {
            get => default;
            set
            {
            }
        }

        public frmEmailTemplate frmEmailTemplate1
        {
            get => default;
            set
            {
            }
        }

        private void frmEmailSender_Load(object sender, EventArgs e)
        {
            
        }
        private void myBtnSetting(object sender, EventArgs e)
        {
            foreach (Control c in panel2.Controls)
            {
                c.BackColor = Color.FromArgb(254, 226, 226);
                c.ForeColor = Color.Black;
            }
            Control click = (Control)sender;
            click.BackColor = Color.FromArgb(254, 189, 197);
            // click.BackColor = Color.BurlyWood;
            click.ForeColor = Color.Black;
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            myBtnSetting(btnTemplate, null);
            frmEmailTemplate template = new frmEmailTemplate();
            template.TopLevel = false;
            panel3.Controls.Clear();
            panel3.Controls.Add(template);
            template.BringToFront();
            template.Show();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            myBtnSetting(btnNew, null);
            frmEmailNew newEmail = new frmEmailNew();
            newEmail.TopLevel = false;
            panel3.Controls.Clear();
            panel3.Controls.Add(newEmail);
            newEmail.BringToFront();
            newEmail.Show();
        }

    }
}
