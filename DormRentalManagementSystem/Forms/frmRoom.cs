using CircularProgressBar;
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

namespace DormRentalManagementSystem.Forms
{
    public partial class frmRoom : Form
    {
        frmWarning warning = new frmWarning();
        Class.myDatabase database = new Class.myDatabase();
        Class.ComboBox combo = new Class.ComboBox();

        int roomIDIndex, roomNoIndex, roomTypeIndex, rentAmountIndex;
        string roomId, roomType, roomNo, rentAmount;

        public frmRoom()
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string roomNo = txtboxRoomNo.Text; 
       
            if (txtboxRoomNo.Text.Equals("") || txtboxRent.Text.Equals("") || comboBoxRoomType.Text.Equals(""))
            {
                warning.lblWarn.Text = "Please input data!";
                warning.ShowDialog();
            }

            else if (!Regex.Match(txtboxRoomNo.Text, "^[a-zA-Z0-9]+(?:[-.][a-zA-Z0-9]+)?$").Success)
            {
                warning.lblWarn.Text = "Invalid RoomNo input!";
                warning.ShowDialog();
            }

            else if (!Regex.Match(txtboxRent.Text, "^\\d+(\\.\\d{2})?$").Success)
            {
                warning.lblWarn.Text = "Invalid Rent Amount input!";
                warning.ShowDialog();
            }
            else if(database.DataExists(roomNo))
            {
                warning.lblWarn.Text = "Room No. already exist!!";
                warning.ShowDialog();
            }

            else
            {              
                string insertQuery = "INSERT INTO table_rooms (RoomNo, RoomType, RentAmount) VALUES " + "(@roomNo, @roomType, @rentAmount)";

                MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@roomNo", txtboxRoomNo.Text),
                    new MySqlParameter("@roomType", comboBoxRoomType.Text),
                    new MySqlParameter("@rentAmount", txtboxRent.Text)
                };

                database.setData(insertQuery, parameters);
                warning.lblWarn.Text = "Data saved Successfully!";
                warning.ShowDialog();

                frmRoom_Load(sender, e);

            }
        }

        private void frmRoom_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            //    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Clear the selection
            //   dataGridView1.CurrentCell = null;
            UpdateCircularProgressBar();
            
        }


        private void RefreshDataGridView()
        {
            //  query to retrieve all data from the table
            string selectQuery = "SELECT * FROM table_rooms";

            // Call the GetData method to retrieve the data
            DataTable dt = database.getData(selectQuery, null);

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = dt;
            txtboxRent.Clear();
            txtboxRoomNo.Clear();
        }

        private bool ChangesMade()
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            string roomNo = Convert.ToString(selectedRow.Cells["RoomNo"].Value);
            string roomType = Convert.ToString(selectedRow.Cells["RoomType"].Value);
            string rentAmount = Convert.ToString(selectedRow.Cells["RentAmount"].Value);

            return
                roomNo != txtboxRoomNo.Text ||
                roomType != comboBoxRoomType.Text ||
                rentAmount != txtboxRent.Text;
        }




        /*

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the selected row in the DataGridView
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            // Extract the ID 
            int idToUpdate = Convert.ToInt32(selectedRow.Cells["RoomID"].Value);

            // Check if required fields are not empty
            if (string.IsNullOrEmpty(txtboxRoomNo.Text) || string.IsNullOrEmpty(txtboxRent.Text))
            {
                warning.lblWarn.Text = "Incomplete details";
                warning.ShowDialog();
                return; 
                // Exit the method 
            }

            if (ChangesMade())
            {
                string updateQuery = "UPDATE table_rooms SET RoomNo = @roomNo, RoomType = @roomType, RentAmount = @rentAmount WHERE RoomID = @id";

                MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@id", idToUpdate),
                    new MySqlParameter("@roomNo", txtboxRoomNo.Text),
                    new MySqlParameter("@roomType", comboBoxRoomType.Text),
                    new MySqlParameter("@rentAmount", txtboxRent.Text)
                    
                };

                // Call the setData method to update the data
                int rowsAffected = database.setData(updateQuery, parameters);

                if (rowsAffected > 0)
                {
                    warning.lblWarn.Text = "Data has been successfully updated!";
                    warning.ShowDialog();
                    frmRoom_Load(sender, e);
                }                
                else
                {
                    warning.lblWarn.Text = "No data updated!";
                    warning.ShowDialog();
                    frmRoom_Load(sender, e);
                }
            }
            else
            {
                warning.lblWarn.Text = "No changes made. Update canceled.";
                warning.ShowDialog();
                frmRoom_Load(sender, e);
            }
        }


        */


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the selected row in the DataGridView
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            // Extract the ID 
            int idToUpdate = Convert.ToInt32(selectedRow.Cells["RoomID"].Value);

            // Check if required fields are not empty
            if (string.IsNullOrEmpty(txtboxRoomNo.Text) || string.IsNullOrEmpty(txtboxRent.Text))
            {
                warning.lblWarn.Text = "Incomplete details";
                warning.ShowDialog();
                return;
                // Exit the method 
            }

            if (ChangesMade())
            {
                // Get the existing room details
                string getRoomDetailsQuery = "SELECT * FROM table_rooms WHERE RoomID = @id";
                MySqlParameter[] getRoomDetailsParameters = new MySqlParameter[]
                {
            new MySqlParameter("@id", idToUpdate)
                };
                DataTable roomDetails = database.getData(getRoomDetailsQuery, getRoomDetailsParameters);

                // Update the room details
                string updateRoomQuery = "UPDATE table_rooms SET RoomNo = @roomNo, RoomType = @roomType, RentAmount = @rentAmount WHERE RoomID = @id";
                MySqlParameter[] roomParameters = new MySqlParameter[]
                {
            new MySqlParameter("@id", idToUpdate),
            new MySqlParameter("@roomNo", txtboxRoomNo.Text),
            new MySqlParameter("@roomType", comboBoxRoomType.Text),
            new MySqlParameter("@rentAmount", txtboxRent.Text)
                };

                int rowsAffectedRoom = database.setData(updateRoomQuery, roomParameters);

                if (rowsAffectedRoom > 0)
                {
                    warning.lblWarn.Text = "Room data has been successfully updated!";

                    // Identify relevant tenants for the updated room
                    int roomId = Convert.ToInt32(roomDetails.Rows[0]["RoomID"]);
                    UpdateTenantsForRoom(roomId);

                    warning.ShowDialog();
                    frmRoom_Load(sender, e);
                }
                else
                {
                    warning.lblWarn.Text = "No room data updated!";
                    warning.ShowDialog();
                    frmRoom_Load(sender, e);
                }
            }
            else
            {
                warning.lblWarn.Text = "No changes made. Update canceled.";
                warning.ShowDialog();
                frmRoom_Load(sender, e);
            }
        }

        // Function to update tenants associated with the specified room
        private void UpdateTenantsForRoom(int roomId)
        {
            // Identify relevant tenants based on your table structure and relationships
            // For example, if the table_tenant has a foreign key RoomID that references table_rooms.RoomID,
            // you can update tenants with a query like:

            string updateTenantsQuery = "UPDATE table_tenant SET RoomNo = @roomNo, RoomType = @roomType, RentAmount = @rentAmount WHERE RoomID = @roomId";
            MySqlParameter[] tenantParameters = new MySqlParameter[]
            {
        new MySqlParameter("@roomNo", txtboxRoomNo.Text),
        new MySqlParameter("@roomType", comboBoxRoomType.Text),
        new MySqlParameter("@rentAmount", txtboxRent.Text),
        new MySqlParameter("@roomId", roomId)
            };

            int rowsAffectedTenants = database.setData(updateTenantsQuery, tenantParameters);

            // Handle the result if needed
        }




        private void btnDelete_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM table_rooms WHERE RoomID = @id";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@id", txtboxRoomID.Text)
         /*       new MySqlParameter("@name", txtboxName.Text),
                new MySqlParameter("@uname", txtboxUsername.Text),
                new MySqlParameter("@pass", txtboxPassword.Text),
                new MySqlParameter("@sex", comboBoxSex.Text),
                new MySqlParameter("@contact", txtboxContact.Text),
                new MySqlParameter("@type", txtboxEmpType.Text)
                */
            };

            int rowsAffected = database.setData(deleteQuery, parameters);
            frmRoom_Load(sender, e);

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
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtboxRoomID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtboxRoomNo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBoxRoomType.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtboxRent.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }
        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtboxSearch.Text.Trim();

            string searchQuery = "SELECT * FROM table_rooms WHERE RoomID LIKE @searchText OR RoomType LIKE @searchText OR RoomNo LIKE @searchText OR RentAmount LIKE @searchText";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@searchText", "%" + searchText + "%")
            };

            DataTable result = database.getData(searchQuery, parameters);

            // Assuming dataGridView1 is your DataGridView control
            dataGridView1.DataSource = result;
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //change something
            
            // Assuming the column names in your DataGridView
             roomIDIndex = dataGridView1.Columns["RoomID"].Index;
             roomNoIndex = dataGridView1.Columns["RoomNo"].Index;
             roomTypeIndex = dataGridView1.Columns["RoomType"].Index;
             rentAmountIndex = dataGridView1.Columns["RentAmount"].Index;


            if (e.ColumnIndex == roomIDIndex || e.ColumnIndex == roomNoIndex  || e.ColumnIndex == roomTypeIndex || e.ColumnIndex == rentAmountIndex)
            {
                 roomId = dataGridView1.Rows[e.RowIndex].Cells[roomIDIndex].Value.ToString();
                 roomType = dataGridView1.Rows[e.RowIndex].Cells[roomTypeIndex].Value.ToString();
                 roomNo = dataGridView1.Rows[e.RowIndex].Cells[roomNoIndex].Value.ToString();
                 rentAmount = dataGridView1.Rows[e.RowIndex].Cells[rentAmountIndex].Value.ToString();


                // Check if the room is occupied
                bool isOccupied = IsRoomOccupied(roomId, roomType, roomNo,  rentAmount);

                // Set the background color based on the occupancy status
                //  e.BackColor = Color.FromArgb(254, 226, 226);

                // e.CellStyle.BackColor = isOccupied ? Color.Red : Color.Green;
                  e.CellStyle.BackColor = isOccupied ? Color.FromArgb(191, 172, 226) : Color.FromArgb(241, 198, 231);
                  e.CellStyle.ForeColor = isOccupied ? Color.Black : Color.Black;              

               // UpdateDataGridViewColors();

            }
        }

             private bool IsRoomOccupied(string roomId, string roomType, string roomNo, string rentAmount)
             {
                 // Query to check if the room is occupied in your database
                 string checkOccupancyQuery = "SELECT COUNT(*) FROM table_tenant WHERE RoomID = @id AND RoomType = @RoomType AND RoomNo = @RoomNo AND RentAmount = @rent";
                 MySqlParameter[] parameters = new MySqlParameter[]
                 {
                     new MySqlParameter("@id", roomId ),
                     new MySqlParameter("@RoomType", roomType), 
                     new MySqlParameter("@RoomNo", roomNo),
                     new MySqlParameter("@rent", rentAmount)
                 };

                 int tenantCount = Convert.ToInt32(database.getData(checkOccupancyQuery, parameters).Rows[0][0]);

                 // Room is occupied if there is at least one tenant
                 return tenantCount > 0;
             }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //dataGridView1.ClearSelection();
        }

        private void gunaCircleProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateCircularProgressBar()
        {
            // Assuming you have circularProgressBar control on your form

            // Get the total number of rooms
            int totalRooms = GetTotalRooms();

            // Get the number of occupied rooms
            int occupiedRooms = GetOccupiedRooms();

            // Get the number of available rooms
            int availableRooms = totalRooms - occupiedRooms;

            // Calculate the percentage of occupied and available rooms
            double percentageOccupied = Math.Round(((double)occupiedRooms / totalRooms) * 100);
            double percentageAvailable = Math.Round(((double)availableRooms / totalRooms) * 100);

            // Set the value of the circular progress bar based on the occupied percentage
            circularProgressBar1.Value = (int)percentageOccupied;

            // Optionally, set the text to display the percentage
            circularProgressBar1.Text = $"{(int)percentageOccupied}% Occupied, \n{(int)percentageAvailable}% Available";
        }

        private int GetTotalRooms()
        {
            string query = "SELECT COUNT(*) FROM table_rooms";
            DataTable result = database.getData(query, null);

            // Check if the DataTable has rows and the value is in the first column of the first row
            if (result.Rows.Count > 0 && result.Rows[0][0] != DBNull.Value)
            {
                int totalRooms = Convert.ToInt32(result.Rows[0][0]);
                return totalRooms;
            }

            // Handle the case where the query didn't return any result
            return 0;
        }

        private int GetOccupiedRooms()
        {
            string query = "SELECT COUNT(DISTINCT RoomID) FROM table_tenant WHERE RoomID IS NOT NULL";
            DataTable result = database.getData(query, null);

            // Check if the DataTable has rows and the value is in the first column of the first row
            if (result.Rows.Count > 0 && result.Rows[0][0] != DBNull.Value)
            {
                int occupiedRooms = Convert.ToInt32(result.Rows[0][0]);
                return occupiedRooms;
            }

            // Handle the case where the query didn't return any result
            return 0;
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
