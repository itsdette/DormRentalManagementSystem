using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DormRentalManagementSystem.Forms
{
    public partial class frmAdminWindows : Form
    {
        private string loggedInUserName;

        public frmAdminWindows(string userName)
        {
            InitializeComponent();
            loggedInUserName = userName;

        }

        public frmDashboard frmDashboard
        {
            get => default;
            set
            {
            }
        }

        public frmEmployee frmEmployee
        {
            get => default;
            set
            {
            }
        }

        public frmRoom frmRoom
        {
            get => default;
            set
            {
            }
        }

        public frmTenant frmTenant
        {
            get => default;
            set
            {
            }
        }

        public frmPayment frmPayment
        {
            get => default;
            set
            {
            }
        }

        public frmEmailSender frmEmailSender
        {
            get => default;
            set
            {
            }
        }

        public frmPaymentHistory frmPaymentHistory
        {
            get => default;
            set
            {
            }
        }

        public frmRoom frmRoom1
        {
            get => default;
            set
            {
            }
        }

        public frmDashboard frmDashboard1
        {
            get => default;
            set
            {
            }
        }

        public frmTenant frmTenant1
        {
            get => default;
            set
            {
            }
        }

        public frmEmployee frmEmployee1
        {
            get => default;
            set
            {
            }
        }

        public frmPayment frmPayment1
        {
            get => default;
            set
            {
            }
        }

        public frmPaymentHistory frmPaymentHistory1
        {
            get => default;
            set
            {
            }
        }

        public frmEmailSender frmEmailSender1
        {
            get => default;
            set
            {
            }
        }

        private void hideSubmenu()
        {
            panelPaymentlSubmenu.Visible = false;
        }

        private void showSubmenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void myBtnSetting(object sender, EventArgs e)
        {
            foreach (Control c in panel2.Controls)
            {
                c.BackColor = Color.FromArgb(254, 226, 226);
                c.ForeColor = Color.Black;
            }
            Control click = (Control)sender;
            click.BackColor = Color.FromArgb(185, 187, 223);
           // click.BackColor = Color.BurlyWood;
            click.ForeColor = Color.Black;


        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            myBtnSetting(btnDashboard, null);
              frmDashboard dashboard = new frmDashboard();
              dashboard.TopLevel = false;
              panel4.Controls.Clear();
              panel4.Controls.Add(dashboard);
              dashboard.BringToFront();
              dashboard.Show();
            
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            myBtnSetting(btnRooms, null);
            frmRoom rooms = new frmRoom();
            rooms.TopLevel = false;
            panel4.Controls.Clear();
            panel4.Controls.Add(rooms);
            rooms.BringToFront();
            rooms.Show();

        }

        private void btnTenants_Click(object sender, EventArgs e)
        {
            myBtnSetting(btnTenants, null);           
            frmTenant tenant = new frmTenant();
            tenant.TopLevel = false;
            panel4.Controls.Clear();
            panel4.Controls.Add(tenant);
            tenant.BringToFront();
            tenant.Show();
            
        }
        public void openAdmin(Object obj)
        {
            Application.Run(new frmMain());

        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            //   myBtnSetting(btnLogout, null);
             this.Close();
            Thread thread;
            thread = new Thread(openAdmin);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();


        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            myBtnSetting(btnEmployee, null);
            frmEmployee employee = new frmEmployee();         
            employee.TopLevel = false;
            panel4.Controls.Clear();
            panel4.Controls.Add(employee);
            employee.BringToFront();
            employee.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            myBtnSetting(btnPayment, null);
            showSubmenu(panelPaymentlSubmenu);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmAdminWindows_Load(object sender, EventArgs e)
        {
            // Update the label with the logged-in username
            labelUsername.Text = "Welcome " + loggedInUserName + ",";
            panelPaymentlSubmenu.Visible = false;
            frmDashboard dashboard = new frmDashboard();
            dashboard.TopLevel = false;
            panel4.Controls.Clear();
            panel4.Controls.Add(dashboard);
            dashboard.BringToFront();
            dashboard.Show();
        }

        private void btnAcceptPayment_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            myBtnSetting(btnAcceptPayment, null);
            frmPayment payment = new frmPayment();
            payment.TopLevel = false;
            panel4.Controls.Clear();
            panel4.Controls.Add(payment);
            payment.BringToFront();
            payment.Show();
        }

        private void btnPaymenthistory_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            myBtnSetting(btnPaymenthistory, null);
            frmPaymentHistory history = new frmPaymentHistory();
            history.TopLevel = false;
            panel4.Controls.Clear();
            panel4.Controls.Add(history);
            history.BringToFront();
            history.Show();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            myBtnSetting(btnEmail, null);
            frmEmailSender emailSender = new frmEmailSender();
            emailSender.TopLevel = false;
            panel4.Controls.Clear();
            panel4.Controls.Add(emailSender);
            emailSender.BringToFront();
            emailSender.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
