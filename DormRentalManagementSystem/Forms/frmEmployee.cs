using DormRentalManagementSystem.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormRentalManagementSystem.Forms
{
    public partial class frmEmployee : Form
    {
        frmWarning warning = new frmWarning();
        Class.myDatabase database = new Class.myDatabase();
        Class.ComboBox combo = new Class.ComboBox();
        string name, username, password, sex, contact, empType;
        string sql, hashedPassword, insertQuery, updateQuery;
        int idToUpdate, rowsAffected;

        private Image hideImage;
        private Image showImage;
        private bool isPasswordVisible;

        public frmEmployee()
        {
            InitializeComponent();
            hideImage = Image.FromFile(@"D:\ICONS\hide.png");
            showImage = Image.FromFile(@"D:\ICONS\view.png");
            isPasswordVisible = false;
        }

        public frmWarning frmWarning
        {
            get => default;
            set
            {
            }
        }

        public frmWarning frmWarning1
        {
            get => default;
            set
            {
            }
        }

        internal Class.ComboBox ComboBox
        {
            get => default;
            set
            {
            }
        }

        public static string HashPassword(string password)
        {
            byte[] bytePass = Encoding.UTF8.GetBytes(password);
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] hashBytes = sha1.ComputeHash(bytePass);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            // Toggle the UseSystemPasswordChar property
            txtboxPassword.UseSystemPasswordChar = !isPasswordVisible;
            isPasswordVisible = !isPasswordVisible;

            // Change the image in the button
            SetButtonImage(isPasswordVisible ? showImage : hideImage);

            // Focus on the textbox to avoid losing the input
            txtboxPassword.Focus();
        }

        private void SetButtonImage(Image image)
        {
            btnToggle.Image = new Bitmap(image, new Size(20, 20)); // Adjust size as needed
            btnToggle.ImageAlign = ContentAlignment.MiddleCenter; // Adjust alignment as needed

        }

        /*   public static string HashPassword(string password)
           {
               byte[] bytePass = Encoding.UTF8.GetBytes(password);
               using (SHA1 sha1 = SHA1.Create())
               {
                   byte[] hashByte = sha1.ComputeHash(bytePass);
                   return Convert.ToHexString(hashByte).ToLower().Replace("-", "");
               }
           }
      */

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (txtboxName.Text.Equals("") || txtboxUsername.Text.Equals("") || comboBoxType.Text.Equals("") || txtboxContact.Text.Equals("") || txtboxPassword.Text.Equals("") || comboBoxSex.Text.Equals(""))
            {
                warning.lblWarn.Text = "Please input data!";
                warning.ShowDialog();

            }

            else if (!Regex.Match(txtboxName.Text, "^[A-Za-z -]+$").Success)
            {
                warning.lblWarn.Text = "Invalid name input!";
                warning.ShowDialog();
            }

            else if (!Regex.Match(txtboxUsername.Text, "^[a-zA-Z0-9 -]*$").Success)
            {
                warning.lblWarn.Text = "Invalid Username input!";
                warning.ShowDialog();
            }
            else if (!Regex.Match(txtboxPassword.Text, "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{3,}$").Success)
            {
                warning.lblWarn.Text = "Invalid paswword input!";
                warning.ShowDialog();
            }

            else if (!Regex.Match(txtboxContact.Text, "^^09\\d{9}$*$").Success)
            {
                warning.lblWarn.Text = "Invalid Contact No. input!";
                warning.ShowDialog();
            }
            
            else
            {
                // string insertQuery = "INSERT INTO YourTable (Column1, Column2) VALUES (@Param1, @Param2)";
                 hashedPassword = HashPassword(txtboxPassword.Text);

                 insertQuery = "INSERT INTO table_employee (Name, Username, Password, Sex, ContactNo, EmployeeType) VALUES " +
                    "(@name, @uname, @pass, @sex, @contact, @type) ";

                MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@name", txtboxName.Text), 
                    new MySqlParameter("@uname", txtboxUsername.Text),
                     new MySqlParameter("@pass", hashedPassword),
                    //new MySqlParameter("@pass", txtboxPassword.Text),
                    new MySqlParameter("@sex", comboBoxSex.Text),
                    new MySqlParameter("@contact", txtboxContact.Text),
                    new MySqlParameter("@type", comboBoxType.Text)

                };
                database.setData(insertQuery, parameters);
                warning.lblWarn.Text = "Successful!";
                warning.ShowDialog();

                frmEmployee_Load_1(sender, e);

            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the selected row in the DataGridView
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            // Extract the ID 
            idToUpdate = Convert.ToInt32(selectedRow.Cells["Id"].Value);

            // Check if there are any changes

            if (txtboxName.Text.Equals("") || txtboxUsername.Text.Equals("") || comboBoxType.Text.Equals("") || txtboxContact.Text.Equals("") || txtboxPassword.Text.Equals("") || comboBoxSex.Text.Equals(""))
            {
                warning.lblWarn.Text = "Please input data!";
                warning.ShowDialog();

            }

            else if (!Regex.Match(txtboxName.Text, "^[A-Za-z -]+$").Success)
            {
                warning.lblWarn.Text = "Invalid name input!";
                warning.ShowDialog();
            }

            else if (!Regex.Match(txtboxUsername.Text, "^[a-zA-Z0-9 -]*$").Success)
            {
                warning.lblWarn.Text = "Invalid Username input!";
                warning.ShowDialog();
            }
            else if (!Regex.Match(txtboxPassword.Text, "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{3,}$").Success)
            {
                warning.lblWarn.Text = "Invalid paswword input!";
                warning.ShowDialog();
            }

            else if (!Regex.Match(txtboxContact.Text, "^^09\\d{9}$*$").Success)
            {
                warning.lblWarn.Text = "Invalid Contact No. input!";
                warning.ShowDialog();
            }
            else
            {
            if (ChangesMade())
            {
                hashedPassword = HashPassword(txtboxPassword.Text);
                updateQuery = "UPDATE table_employee SET Name = @name, Username = @uname, Password = @pass, Sex = @sex, ContactNo = @contact, EmployeeType = @type WHERE Id = @id";

                MySqlParameter[] parameters = new MySqlParameter[]
                {
            new MySqlParameter("@name", txtboxName.Text),
            new MySqlParameter("@uname", txtboxUsername.Text),
            new MySqlParameter("@pass", hashedPassword),
            //new MySqlParameter("@pass", txtboxPassword.Text),
            new MySqlParameter("@sex", comboBoxSex.Text),
            new MySqlParameter("@contact", txtboxContact.Text),
            new MySqlParameter("@type", comboBoxType.Text),
            new MySqlParameter("@id", idToUpdate)
                };

                // Call the setData method to update the data
                rowsAffected = database.setData(updateQuery, parameters);

                if (rowsAffected > 0)
                {
                    warning.lblWarn.Text = "Data has been successfully updated!";
                    warning.ShowDialog();

                    frmEmployee_Load_1(sender, e);
                }
                else
                {
                    warning.lblWarn.Text = "No data updated!";
                    warning.ShowDialog();
                    frmEmployee_Load_1(sender, e);

                }
            }
            else
            {

                  warning.lblWarn.Text = "No changes made. Update canceled.";
                  warning.ShowDialog();
                  frmEmployee_Load_1(sender, e);

            }
        }

        }  

        private bool ChangesMade()
        {
            // Get the selected row in the DataGridView
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            //change something
            // Extract the values from the selected row
             name = Convert.ToString(selectedRow.Cells["Name"].Value);
             username = Convert.ToString(selectedRow.Cells["Username"].Value);
             password = Convert.ToString(selectedRow.Cells["Password"].Value);
             sex = Convert.ToString(selectedRow.Cells["Sex"].Value);
             contact = Convert.ToString(selectedRow.Cells["ContactNo"].Value);
             empType = Convert.ToString(selectedRow.Cells["EmployeeType"].Value);

            // Compare the values with the current values in the form controls
            return
                name != txtboxName.Text ||
                username != txtboxUsername.Text ||
                password != txtboxPassword.Text ||
                sex != comboBoxSex.Text ||
                contact != txtboxContact.Text ||
                empType != comboBoxType.Text;
        }
            private void btnDelete_Click(object sender, EventArgs e)
        {

            string deleteQuery = "DELETE FROM table_employee WHERE Id = @id";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@id", lblID.Text)
         /*       new MySqlParameter("@name", txtboxName.Text),
                new MySqlParameter("@uname", txtboxUsername.Text),
                new MySqlParameter("@pass", txtboxPassword.Text),
                new MySqlParameter("@sex", comboBoxSex.Text),
                new MySqlParameter("@contact", txtboxContact.Text),
                new MySqlParameter("@type", txtboxEmpType.Text)
                */
            };

            int rowsAffected = database.setData(deleteQuery, parameters);
            frmEmployee_Load_1(sender, e);

            if (rowsAffected > 0)
            {
                warning.lblWarn.Text = "Data has been successfully deleted!";
                warning.ShowDialog();
            }
            else
            {
                warning.lblWarn.Text = "No data deleted!";
                warning.ShowDialog();
            }
        }

        private void RefreshDataGridView()
        {
            // Construct your SELECT query to retrieve all data from the table
            string selectQuery = "SELECT * FROM table_employee";

            // Call the GetData method to retrieve the data
            // DataTable dataTable = database.GetData(selectQuery, null);
            DataTable dt = database.getData(selectQuery, null);

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = dt;

            txtboxContact.Clear();
            //  txtboxEmpType.Clear();
            txtboxName.Clear();
            txtboxPassword.Clear();
            txtboxUsername.Clear();


        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtboxName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtboxUsername.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
           // txtboxPassword.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBoxSex.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtboxContact.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBoxType.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void frmEmployee_Load_1(object sender, EventArgs e)
        {
            RefreshDataGridView();
            lblID.Visible = false;

            comboBoxType.DataSource = combo.employeeType();
            comboBoxType.DisplayMember = "EmployeeType";

            // Set the initial image to the button
            SetButtonImage(showImage);
            txtboxPassword.UseSystemPasswordChar = !isPasswordVisible;

        }

        private void comboBoxType_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
