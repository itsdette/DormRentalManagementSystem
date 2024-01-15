using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DormRentalManagementSystem.Forms.frmRoom;

namespace DormRentalManagementSystem.Forms
{
    public partial class frmTenant : Form
    {
        frmWarning warning = new frmWarning();
        Class.myDatabase database = new Class.myDatabase();
        Class.ComboBox combo = new Class.ComboBox();

        string tenantID, name, roomID, roomNo, roomType, startDate, rentAmount;

        public frmTenant()
        {
            InitializeComponent();
        }

        public frmWarning frmWarning
        {
            get => default;
            set
            {
            }
        }

        public frmTenantDetails frmTenantDetails
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

        private void frmTenant_Load(object sender, EventArgs e)
        {

            RefreshDataGridView();
            comboBoxRoomType.SelectedIndexChanged += comboBoxRoomType_SelectedIndexChanged;

            // Subscribe to the SelectedIndexChanged event of comboBoxRoomNo
            comboBoxRoomNo.SelectedIndexChanged += comboBoxRoomNo_SelectedIndexChanged;
            comboBoxRoomType.DataSource = combo.roomType();
            comboBoxRoomType.DisplayMember = "RoomType";

            txtboxSearch.TextChanged += txtboxSearch_TextChanged;
           

            bool viewButtonColumnExists = false;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.HeaderText == "View")
                {
                    viewButtonColumnExists = true;
                    break;
                }
            }

            // If the button column doesn't exist, add it
            if (!viewButtonColumnExists)
            {
                // Add a button column to the DataGridView
                DataGridViewButtonColumn viewButtonColumn = new DataGridViewButtonColumn
                {
                    Text = "+",
                    UseColumnTextForButtonValue = true,
                    Name = "View",
                    HeaderText = "View"
                };

                dataGridView1.Columns.Add(viewButtonColumn);
                int lastColumnIndex = dataGridView1.Columns.Count - 1;
                dataGridView1.Columns[lastColumnIndex].Width = 85;
            }
            


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Check if "View" button column is clicked
                if (e.ColumnIndex == dataGridView1.Columns["View"].Index)
                {
                    // "View" button is clicked, show the details in a new form
                    string tenantID = selectedRow.Cells["TenantID"].Value?.ToString();
                    frmTenantDetails tenantDetailsForm = new frmTenantDetails(tenantID);
                    tenantDetailsForm.Show();
                }
                else
                {

                    //change something
                    // "View" button is not clicked, populate textboxes with information
                     tenantID = selectedRow.Cells["TenantID"].Value?.ToString();
                     name = selectedRow.Cells["Name"].Value?.ToString();
                     roomID = selectedRow.Cells["RoomID"].Value?.ToString();
                     roomNo = selectedRow.Cells["RoomNo"].Value?.ToString();
                     roomType = selectedRow.Cells["RoomType"].Value?.ToString();
                     startDate = selectedRow.Cells["StartDate"].Value?.ToString();
                     rentAmount = selectedRow.Cells["RentAmount"].Value?.ToString();

                    // Populate your textboxes
                    txtboxTenantID.Text = tenantID;
                    txtboxName.Text = name;
                    txtboxRoomID.Text = roomID;
                    comboBoxRoomNo.Text = roomNo;
                    comboBoxRoomType.Text = roomType;

                    DateTime parsedStartDate;

                    if (DateTime.TryParse(startDate, out parsedStartDate))
                    {
                        dateTimePickerStartDate.Value = parsedStartDate;
                    }
                    else
                    {
                        // Handle the case where startDate is not a valid date
                        // You might want to set a default date or display an error message
                    }

                    textBoxRentAmount.Text = rentAmount;

                    // Retrieve additional details and populate textboxes
                    string tenantDetailsQuery = "SELECT * FROM table_tenant WHERE TenantID = @TenantID";
                    MySqlParameter[] parameters = new MySqlParameter[]
                    {
                new MySqlParameter("@TenantID", tenantID),
                    };

                    DataTable tenantDetails = database.getData(tenantDetailsQuery, parameters);

                    if (tenantDetails.Rows.Count > 0)
                    {
                        string sex = tenantDetails.Rows[0]["Sex"]?.ToString();
                        string contactNo = tenantDetails.Rows[0]["ContactNo"]?.ToString();
                        string birthday = tenantDetails.Rows[0]["Birthday"]?.ToString();
                        string emailAddress = tenantDetails.Rows[0]["EmailAddress"]?.ToString();

                        comboBoxSex.Text = sex;
                        txtboxContact.Text = contactNo;
                        txtboxEmail.Text = emailAddress;

                        // ... Populate other textboxes as needed
                    }
                    else
                    {
                        // Handle the case where no data is found in table_tenant for the selected TenantID
                        // You may clear or set default values for additional textboxes
                    }
                }
            }
            /*    start
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                    if (e.ColumnIndex == dataGridView1.Columns["View"].Index) // Check if "View" button is clicked
                    {
                        // Your existing code to show frmTenantDetails
                        string tenantID = selectedRow.Cells["TenantID"].Value?.ToString();
                        frmTenantDetails tenantDetailsForm = new frmTenantDetails(tenantID);
                        tenantDetailsForm.Show();
                    }
                    else
                    {
                        // Populate textboxes when other cells are clicked
                        string tenantID = selectedRow.Cells["TenantID"].Value?.ToString();
                        string name = selectedRow.Cells["Name"].Value?.ToString();
                        string roomID = selectedRow.Cells["RoomID"].Value?.ToString();
                        string roomNo = selectedRow.Cells["RoomNo"].Value?.ToString();
                        string roomType = selectedRow.Cells["RoomType"].Value?.ToString();
                        string startDate = selectedRow.Cells["StartDate"].Value?.ToString();
                        string rentAmount = selectedRow.Cells["RentAmount"].Value?.ToString();

                        // Populate your textboxes
                        txtboxTenantID.Text = tenantID;
                        txtboxName.Text = name;
                        txtboxRoomID.Text = roomID;
                        comboBoxRoomNo.Text = roomNo;
                        comboBoxRoomType.Text = roomType;

                        DateTime parsedStartDate;

                        if (DateTime.TryParse(startDate, out parsedStartDate))
                        {
                            dateTimePickerStartDate.Value = parsedStartDate;
                        }
                        else
                        {
                            // Handle the case where startDate is not a valid date
                            // You might want to set a default date or display an error message
                        }

                        textBoxRentAmount.Text = rentAmount;

                        // Your existing code to retrieve additional details and populate textboxes
                    }
                } end*/
           
        }

        private void comboBoxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxRoomNo.DataSource = null;
            textBoxRentAmount.Text = "";
            txtboxRoomID.Text = ""; // Clear the txtboxRoomId

            // When the selected room type changes, populate comboBoxRoomNo accordingly
            string selectedRoomType = comboBoxRoomType.Text;

            // Populate comboBoxRoomNo and txtboxRoomId based on the selected room type
            string roomDetailsQuery = "SELECT RoomNo, RoomID FROM table_rooms WHERE RoomType = @RoomType";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@RoomType", selectedRoomType),
            };

            DataTable roomDetails = database.getData(roomDetailsQuery, parameters);

            if (roomDetails.Rows.Count > 0)
            {
                // Assuming comboBoxRoomNo is your ComboBox control
                comboBoxRoomNo.DataSource = roomDetails;
                comboBoxRoomNo.DisplayMember = "RoomNo";

                // Set txtboxRoomId to the RoomID of the first row (assuming there is one row)
                txtboxRoomID.Text = roomDetails.Rows[0]["RoomID"].ToString();
            }
            else
            {
                txtboxRoomID.Text = "N/A"; 
            }
          

        }

        private void comboBoxRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
           string selectedRoomNo = comboBoxRoomNo.Text;

            // Retrieve RentAmount and RoomID based on the selected room number
            string rentAmountQuery = "SELECT RentAmount, RoomID FROM table_rooms WHERE RoomNo = @RoomNo";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@RoomNo", selectedRoomNo)
            };

            DataTable roomData = database.getData(rentAmountQuery, parameters);

            if (roomData.Rows.Count > 0)
            {
                // Assuming RentAmount and RoomID are numeric values; adjust as needed
                decimal rentAmount = Convert.ToDecimal(roomData.Rows[0]["RentAmount"]);
                int roomId = Convert.ToInt32(roomData.Rows[0]["RoomID"]);

                textBoxRentAmount.Text = rentAmount.ToString();
                txtboxRoomID.Text = roomId.ToString();
            }
            else
            {
                textBoxRentAmount.Text = "N/A"; 
                txtboxRoomID.Text = "N/A"; 
            }    
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RefreshDataGridView()
        {
            // retrieve all data from the table
            string selectQuery = "SELECT TenantID, Name, RoomID, RoomNo, RoomType, StartDate, RentAmount FROM table_tenant";

            // Call the GetData method to retrieve the data
            DataTable dt = database.getData(selectQuery, null);
            dataGridView1.DataSource = dt;
            txtboxContact.Clear();
            txtboxEmail.Clear();
            txtboxName.Clear();
            txtboxRoomID.Clear();
            txtboxTenantID.Clear();

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtboxName.Text.Equals("") || dateTimePickerBirthday.Text.Equals("") || txtboxEmail.Text.Equals("") || txtboxContact.Text.Equals("") || dateTimePickerStartDate.Text.Equals("") || comboBoxSex.Text.Equals("") || txtboxRoomID.Text.Equals(""))
            {
                warning.lblWarn.Text = "Please input data!";
                warning.ShowDialog();

            }
            else if (!Regex.Match(txtboxName.Text, "^[A-Za-z -]+$").Success)
            {
                warning.lblWarn.Text = "Invalid name input!";
                warning.ShowDialog();
            }
            else if (!Regex.Match(txtboxContact.Text, "^^09\\d{9}$*$").Success)
            {
                warning.lblWarn.Text = "Invalid Contact No. input!";
                warning.ShowDialog();
            }
            else if (!Regex.Match(txtboxEmail.Text, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$").Success)
            {
                warning.lblWarn.Text = "Invalid Email Address input!";
                warning.ShowDialog();
            }
            else
            {
                // Check if the selected room is already occupied
                string selectedRoomID = txtboxRoomID.Text;
                string selectedRoomType = comboBoxRoomType.Text;
                string selectedRoomNo = comboBoxRoomNo.Text;

                string checkRoomOccupancyQuery = "SELECT COUNT(*) FROM table_tenant WHERE RoomID = @RoomID AND RoomType = @RoomType AND RoomNo = @RoomNo";
                MySqlParameter[] checkRoomOccupancyParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@RoomID", selectedRoomID),
                    new MySqlParameter("@RoomType", selectedRoomType),
                    new MySqlParameter("@RoomNo", selectedRoomNo)
                };

                int existingTenantCount = Convert.ToInt32(database.getData(checkRoomOccupancyQuery, checkRoomOccupancyParameters).Rows[0][0]);
                int allowedTenantCount = 0;

                switch (selectedRoomType.ToLower())
                {
                    case "single room":
                        allowedTenantCount = 1;
                        break;
                    case "double room":
                        allowedTenantCount = 2;
                        break;
                    case "triple room":
                        allowedTenantCount = 3;
                        break;
                    case "quad room":
                        allowedTenantCount = 4;
                        break;
                    default:
                        break;
                }
                if (existingTenantCount >= allowedTenantCount)  //(existingTenantCount > 0)
                {
                    warning.lblWarn.Text = $"Room is already occupied by {allowedTenantCount} tenants.";
                    warning.ShowDialog();
                }
                else
                {
                    // Room is available, proceed to add the new tenant
                    string insertQuery = "INSERT INTO table_tenant (Name, Sex, Birthday, ContactNo, EmailAddress, RoomID, RoomNo, RoomType, StartDate, RentAmount) VALUES " +
                        "(@name, @sex, @birthday, @contact, @email, @roomID, @RoomNo, @RoomType, @startdate, @Rent)";

                    MySqlParameter[] parameters = new MySqlParameter[]
                    {
                new MySqlParameter("@name", txtboxName.Text),
                new MySqlParameter("@sex", comboBoxSex.Text),
                new MySqlParameter("@birthday", dateTimePickerBirthday.Value.ToString("MM-dd-yyyy")),

               // new MySqlParameter("@birthday", dateTimePickerBirthday.Text),
                new MySqlParameter("@contact", txtboxContact.Text),
                new MySqlParameter("@email", txtboxEmail.Text),
                new MySqlParameter("@roomID", txtboxRoomID.Text),
                new MySqlParameter("@RoomNo", comboBoxRoomNo.Text),
                new MySqlParameter("@RoomType", comboBoxRoomType.Text),
                new MySqlParameter("@startdate", dateTimePickerStartDate.Value.ToString("dd-MM-yyyy")),
                //new MySqlParameter("@startdate", dateTimePickerStartDate.Text),
                new MySqlParameter("@Rent", textBoxRentAmount.Text)
                    };

                    database.setData(insertQuery, parameters);
                    warning.lblWarn.Text = "Successful!";
                    warning.ShowDialog();

                    frmTenant_Load(sender, e);
                }
            }                  
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            // Extract the ID 
            int idToUpdate = Convert.ToInt32(selectedRow.Cells["TenantID"].Value);

            if (txtboxName.Text.Equals("") || dateTimePickerBirthday.Text.Equals("") || txtboxEmail.Text.Equals("") || txtboxContact.Text.Equals("") || dateTimePickerStartDate.Text.Equals("") || comboBoxSex.Text.Equals("") || txtboxRoomID.Text.Equals(""))
            {
                warning.lblWarn.Text = "Please input data!";
                warning.ShowDialog();

            }
            else if (!Regex.Match(txtboxName.Text, "^[A-Za-z -]+$").Success)
            {
                warning.lblWarn.Text = "Invalid name input!";
                warning.ShowDialog();
            }
            else if (!Regex.Match(txtboxContact.Text, "^^09\\d{9}$*$").Success)
            {
                warning.lblWarn.Text = "Invalid Contact No. input!";
                warning.ShowDialog();
            }
            else if (!Regex.Match(txtboxEmail.Text, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$").Success)
            {
                warning.lblWarn.Text = "Invalid Email Address input!";
                warning.ShowDialog();
            }
            else
            {
                // Check if there are any changes
                if (ChangesMade())
                {
                    string updateQuery = "UPDATE table_tenant SET Name = @name, Sex = @sex, Birthday = @birthday, ContactNo = @contact, EmailAddress = @email, RoomID = @room, RoomNo = @roomNo,RoomType = @roomType, StartDate = @start, RentAmount = @rent WHERE TenantID = @id";

                    MySqlParameter[] parameters = new MySqlParameter[]
                    {
                    new MySqlParameter("@name", txtboxName.Text),
                    new MySqlParameter("@sex", comboBoxSex.Text),
                    new MySqlParameter("@birthday", dateTimePickerBirthday.Value.ToString("MM-dd-yyyy")),
                    new MySqlParameter("@contact", txtboxContact.Text),
                    new MySqlParameter("@email", txtboxEmail.Text),
                    new MySqlParameter("@room", txtboxRoomID.Text),
                    new MySqlParameter("@roomNo", comboBoxRoomNo.Text),
                    new MySqlParameter("@roomType", comboBoxRoomType.Text),
                    new MySqlParameter("@start", dateTimePickerStartDate.Value.ToString("dd-MM-yyyy")),
                    new MySqlParameter("@rent", textBoxRentAmount.Text),
                    new MySqlParameter("@id", idToUpdate)
                    };
                    // Call the setData method to update the data
                    int rowsAffected = database.setData(updateQuery, parameters);

                    if (rowsAffected > 0)
                    {
                        warning.lblWarn.Text = "Data has been successfully updated!";
                        warning.ShowDialog();
                        frmTenant_Load(sender, e);
                    }
                    else
                    {
                        warning.lblWarn.Text = "No data updated!";
                        warning.ShowDialog();
                        frmTenant_Load(sender, e);
                    }
                }
                else
                {
                    warning.lblWarn.Text = "No changes made. Update canceled.";
                    warning.ShowDialog();
                    frmTenant_Load(sender, e);
                }
            }
        }

        private bool ChangesMade()
        {
            // Get the selected row in the DataGridView
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            // Extract the values from the selected row
            string name = Convert.ToString(selectedRow.Cells["Name"].Value);
         //   string sex = Convert.ToString(selectedRow.Cells["sex"].Value);
        //    string birthday = Convert.ToString(selectedRow.Cells["Birthday"].Value);
          //  string contact = Convert.ToString(selectedRow.Cells["ContactNo"].Value);
       //     string email = Convert.ToString(selectedRow.Cells["EmailAddress"].Value);
            string roomID = Convert.ToString(selectedRow.Cells["RoomID"].Value);
            string roomNo = Convert.ToString(selectedRow.Cells["RoomNo"].Value);
            string roomType = Convert.ToString(selectedRow.Cells["RoomType"].Value);
            string start = Convert.ToString(selectedRow.Cells["StartDate"].Value);
            string rent = Convert.ToString(selectedRow.Cells["RentAmount"].Value);

            // Compare the values with the current values in the form controls
            return
                name != txtboxName.Text ||
            //    sex != comboBoxSex.Text ||
            //    birthday != dateTimePickerBirthday.Text ||
            //    contact != txtboxContact.Text ||
            //    email != txtboxEmail.Text ||
                roomID != txtboxRoomID.Text ||
                roomNo != comboBoxRoomNo.Text ||
                roomType != comboBoxRoomType.Text ||
                start != dateTimePickerStartDate.Text ||
                rent != textBoxRentAmount.Text; // Fix here, use txtboxRentAmount.Text instead of dateTimePickerStartDate.Text
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

            string deleteQuery = "DELETE FROM table_tenant WHERE TenantID = @id";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@id", txtboxTenantID.Text)
         /*       new MySqlParameter("@name", txtboxName.Text),
                new MySqlParameter("@uname", txtboxUsername.Text),
                new MySqlParameter("@pass", txtboxPassword.Text),
                new MySqlParameter("@sex", comboBoxSex.Text),
                new MySqlParameter("@contact", txtboxContact.Text),
                new MySqlParameter("@type", txtboxEmpType.Text)
                */
            };

            int rowsAffected = database.setData(deleteQuery, parameters);

            //delete tenant payment history
            string deleteQuerys = "DELETE FROM table_payment WHERE TenantID = @id";
            MySqlParameter[] parameterst = new MySqlParameter[]
            {
                new MySqlParameter("@id", txtboxTenantID.Text)
         /*       new MySqlParameter("@name", txtboxName.Text),
                new MySqlParameter("@uname", txtboxUsername.Text),
                new MySqlParameter("@pass", txtboxPassword.Text),
                new MySqlParameter("@sex", comboBoxSex.Text),
                new MySqlParameter("@contact", txtboxContact.Text),
                new MySqlParameter("@type", txtboxEmpType.Text)
                */
            };
            database.setData(deleteQuerys, parameterst);


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
        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtboxSearch.Text.Trim();

            string searchQuery = "SELECT TenantID, Name, RoomID, RoomNo, RoomType, StartDate, RentAmount FROM table_tenant WHERE TenantID LIKE @searchText OR Name LIKE @searchText ";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
            new MySqlParameter("@searchText", "%" + searchText + "%")
            };
            DataTable result = database.getData(searchQuery, parameters);
            // Assuming dataGridView1 is your DataGridView control
            dataGridView1.DataSource = result; // Set the data source
        }
    }
}
