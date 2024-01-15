using DormRentalManagementSystem.Class;
using MySql.Data.MySqlClient;
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

namespace DormRentalManagementSystem.Forms
{
    public partial class frmLoginSample : Form
    {
        Class.myDatabase database = new Class.myDatabase();
        string username, hashPassword;

        private Image hideImage;
        private Image showImage;
        private bool isPasswordVisible;
        private Panel panelLoading;
        Thread thread;
        public frmLoginSample()
        {
            InitializeComponent();
            InitializeLoadingPanel();
          //  originalImage = Image.FromFile(@"D:\ICONS\hide.png");
          //  isPasswordVisible = false;

            hideImage = Image.FromFile(@"D:\ICONS\hide.png");
            showImage = Image.FromFile(@"D:\ICONS\view.png");
            isPasswordVisible = false;
            //  isPasswordVisible = false;

            // originalText = ""; // Initialize originalText with the actual original text

        }

        public frmAdminWindows frmAdminWindows
        {
            get => default;
            set
            {
            }
        }

        public frmAdminWindows frmAdminWindows1
        {
            get => default;
            set
            {
            }
        }

        public frmAdminWindows frmAdminWindows2
        {
            get => default;
            set
            {
            }
        }

        public frmWarning frmWarning
        {
            get => default;
            set
            {
            }
        }

        private void InitializeLoadingPanel()
        {
            panelLoading = new Panel
            {
                Size = new Size(364, 282),
                BackColor = Color.FromArgb(128, 220, 220, 220), // 128 is the alpha component for transparency

                //   BackColor = Color.FromArgb(220, 220, 220),
                Visible = false
            };


            // Center the panel on the form
            panelLoading.Location = new Point((this.ClientSize.Width - panelLoading.Width) / 2, (this.ClientSize.Height - panelLoading.Height) / 2);
            // Set the transparency key to the same color as the BackColor
            panelLoading.BackColor = Color.FromArgb(0, panelLoading.BackColor);

            panelLoading.Controls.Add(label3);
            Controls.Add(panelLoading);

            // Make sure the panel is at the top of the control hierarchy
            panelLoading.BringToFront();
        }

        public void openAdmin(Object obj)
        {
            frmAdminWindows adminForm = new frmAdminWindows(obj.ToString());
            Application.Run(adminForm);
            //Application.Run(new frmAdminWindows());

        }

        private void btnToggle_Click_1(object sender, EventArgs e)
        {

            // Toggle the UseSystemPasswordChar property
            txtboxPassword.UseSystemPasswordChar = !isPasswordVisible;
            isPasswordVisible = !isPasswordVisible;

            // Change the image in the button
            SetButtonImage(isPasswordVisible ? showImage : hideImage);

            // Focus on the textbox to avoid losing the input
            txtboxPassword.Focus();
            
        }

        private void frmLoginSample_Load(object sender, EventArgs e)
        {

            // Set the initial image to the button
            SetButtonImage(showImage);
            txtboxPassword.UseSystemPasswordChar = !isPasswordVisible;


        }
        private void SetButtonImage(Image image)
        {
            btnToggle.Image = new Bitmap(image, new Size(20, 20)); // Adjust size as needed
            btnToggle.ImageAlign = ContentAlignment.MiddleCenter; // Adjust alignment as needed

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmWarning warn = new frmWarning();
             username = txtboxUsername.Text;
             hashPassword = frmEmployee.HashPassword(txtboxPassword.Text);

            DataTable dt = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `table_employee` WHERE Username = @user and Password = @pass", database.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            command.Parameters.Add("@user", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = hashPassword;

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                // Show the loading panel
                panelLoading.Visible = true;

                // Start the operation in a separate thread
                Thread thread = new Thread(() =>
                {
                    // Simulate some work
                    for (int i = 0; i < 300; i++)
                    {
                        Thread.Sleep(5);
                    }

                    // Close the loading panel when the operation is complete
                    if (panelLoading.InvokeRequired)
                    {
                        panelLoading.Invoke(new Action(() => { panelLoading.Visible = false; }));

                        // Open the frmAdminWindows with the username
                        thread = new Thread(openAdmin);
                        thread.SetApartmentState(ApartmentState.STA);
                        thread.Start(username);
                    }
                    else
                    {
                        panelLoading.Visible = false;
                    }

                    // Exit the application
                    Application.Exit();
                });

                // Start the thread
                thread.Start();
            }
            else
            {
                if (txtboxUsername.Text.Equals(""))
                {
                    warn.lblWarn.Text = "Enter Your Username to Login";
                    warn.Show();
                }
                else if (txtboxPassword.Text.Equals(""))
                {
                    warn.lblWarn.Text = "Enter Your Password to Login";
                    warn.Show();
                }
                else
                {
                    warn.lblWarn.Text = "Account does not exist!";
                    warn.Show();
                }
            }
        }
    }
}
