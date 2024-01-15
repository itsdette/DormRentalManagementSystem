using DormRentalManagementSystem.Class;
using Guna.UI.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DormRentalManagementSystem.Forms
{
    public partial class frmDashboard : Form
    {
        Class.myDatabase database = new Class.myDatabase();
        string stmt, stmtt, employee, roomNo, roomType;
        int totalRooms, occupiedRooms, availableRooms, maxOccupants, occupiedTenants;
        double percentageOccupied, percentageAvailable;
        public frmDashboard()
        {
            InitializeComponent();
            dataGridView1.RowPrePaint += dataGridView1_RowPrePaint;
        }
        
        private void frmDashboard_Load(object sender, EventArgs e)
        {

            dataGridView3.ClearSelection();
            UpdateCircularProgressBar();
            LoadRoomDetails();
            LoadTenantDetails();
            DisplayEmployeeData();
            dataGridView2.ClearSelection();
            dataGridView1.ClearSelection();
            UpdateProgressBarColor();

            //   circularProgressBar2.Text = $"{(int)percentage}% \nNumber Of Tenants";
            circularProgressBar1.Font = new Font("Arial", 10, FontStyle.Bold); // You can adjust the font size and style
            circularProgressBar1.ForeColor = Color.Black; // Set the font color

            circularProgressBar2.Font = new Font("Arial", 10, FontStyle.Bold); // You can adjust the font size and style
            circularProgressBar2.ForeColor = Color.Black; // Set the font color
            using (database.getConnection())
            {
                
                 stmt = "SELECT COUNT(*) FROM table_rooms";
                using (MySqlCommand cmdCount = new MySqlCommand(stmt, database.getConnection()))
                {
                    database.getConnection().Open();
                    // Execute the query and get the result
                    lblRoom.Text = cmdCount.ExecuteScalar().ToString();
                }
                 stmtt = "SELECT COUNT(*) FROM table_tenant";
                using (MySqlCommand cmdCount = new MySqlCommand(stmtt, database.getConnection()))
                {
                    // Execute the query and get the result
                    lblTenant.Text = cmdCount.ExecuteScalar().ToString();
                }
                 employee = "SELECT COUNT(*) FROM table_employee";
                using (MySqlCommand cmdCount = new MySqlCommand(employee, database.getConnection()))
                {
                    // Execute the query and get the result
                    labelEmployee.Text = cmdCount.ExecuteScalar().ToString();
                }
                
                database.getConnection().Close();   

            }

        }


        private void UpdateCircularProgressBar()
        {
            
            // Get the total number of rooms
             totalRooms = GetTotalRooms();

            // Get the number of occupied rooms
             occupiedRooms = GetOccupiedRooms();

            // Get the number of available rooms
             availableRooms = totalRooms - occupiedRooms;

            // Calculate the percentage of occupied and available rooms
             percentageOccupied = Math.Round(((double)occupiedRooms / totalRooms) * 100);
             percentageAvailable = Math.Round(((double)availableRooms / totalRooms) * 100);

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
                 totalRooms = Convert.ToInt32(result.Rows[0][0]);
                return totalRooms;
            }
            return 0;
        }

        private int GetOccupiedRooms()
        {
            string query = "SELECT COUNT(DISTINCT RoomID) FROM table_tenant WHERE RoomID IS NOT NULL";
            DataTable result = database.getData(query, null);

            // Check if the DataTable has rows and the value is in the first column of the first row
            if (result.Rows.Count > 0 && result.Rows[0][0] != DBNull.Value)
            {
                 occupiedRooms = Convert.ToInt32(result.Rows[0][0]);
                return occupiedRooms;
            }

            // Handle the case where the query didn't return any result
            return 0;
        }
        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }
        private void LoadRoomDetails()
        {
            // Clear existing data in the DataGridView
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear(); // Clear existing columns

            // Add columns to the DataGridView
            dataGridView1.Columns.Add("RoomNoColumn", "Room No");
            dataGridView1.Columns.Add("RoomTypeColumn", "Room Type");
            dataGridView1.Columns.Add("MaxOccupantsColumn", "Max Occupants");
            dataGridView1.Columns.Add("OccupiedTenantsColumn", "Occupied Tenants");

            // SQL query to retrieve room details
            string query = "SELECT RoomNo, RoomType FROM table_rooms";

            // Execute the query and get the result as a DataTable
            DataTable result = database.getData(query, null);

            // Check if there are rows in the result
            if (result.Rows.Count > 0)
            {
                // Iterate through the rows and populate the DataGridView
                foreach (DataRow row in result.Rows)
                {
                     roomNo = row["RoomNo"].ToString();
                     roomType = row["RoomType"].ToString();
                     maxOccupants = GetMaxOccupantsForRoomType(roomType);
                     occupiedTenants = GetOccupiedTenantsCount(roomNo);
                    

                    // Add a new row to the DataGridView
                    dataGridView1.Rows.Add(roomNo, roomType, maxOccupants, occupiedTenants);
                }
            }

        }

        // Function to get the maximum occupants for a given room type
        private int GetMaxOccupantsForRoomType(string roomType)
        {
            // Use a switch statement or other logic to determine the maximum occupants
            switch (roomType.ToLower())
            {
                case "single room":
                    return 1;
                case "double room":
                    return 2;
                case "triple room":
                    return 3;
                case "quad room":
                    return 4;
                default:
                    return 0; // Set a default value or handle unknown room types
            }
        }

        private int GetOccupiedTenantsCount(string roomID)
        {
            // Replace this query with your actual query to get the count of occupied tenants for the room
            string query = "SELECT COUNT(*) FROM table_tenant WHERE RoomNo= @RoomNo";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
        new MySqlParameter("@RoomNo", roomID)
            };

            // Execute the query to get the count
            DataTable result = database.getData(query, parameters);

            // Check if the DataTable has rows and the value is in the first column of the first row
            if (result.Rows.Count > 0 && result.Rows[0][0] != DBNull.Value)
            {
                int occupiedTenants = Convert.ToInt32(result.Rows[0][0]);
                return occupiedTenants;
            }
            return 0;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            // Get the values from the corresponding cells in the current row
            int maxOccupants = Convert.ToInt32(row.Cells["MaxOccupantsColumn"].Value);
            int occupiedTenants = Convert.ToInt32(row.Cells["OccupiedTenantsColumn"].Value);

            // Set the background color based on the conditions
            if (occupiedTenants >= maxOccupants)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(167, 203, 217); // Room is fully occupied
            }
         /*   else if (occupiedTenants > 0)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(212, 226, 212); // Room has no occupants
             // row.DefaultCellStyle.BackColor = Color.FromArgb(241, 198, 231); // Room has occupants but not fully occupied
            }
          */  else
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(225, 204, 236); // available
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        //for tenant
        private void LoadTenantDetails()
        {
            // Clear existing data in the DataGridView
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear(); // Clear existing columns

            // Add columns to the DataGridView
            dataGridView2.Columns.Add("RoomNoColumn", "Room No");
            dataGridView2.Columns.Add("TenantIDColumn", "Tenant ID");
            dataGridView2.Columns.Add("NameColumn", "Name");
            dataGridView2.Columns.Add("StartDateColumn", "Start Date");

            // SQL query to retrieve tenant details
            string query = "SELECT RoomNo, TenantID, Name, StartDate FROM table_tenant";

            // Execute the query and get the result as a DataTable
            DataTable result = database.getData(query, null);

            // Check if there are rows in the result
            if (result.Rows.Count > 0)
            {
                // Iterate through the rows and populate the DataGridView
                foreach (DataRow row in result.Rows)
                {
                    string roomNo = row["RoomNo"].ToString();
                    string tenantID = row["TenantID"].ToString();
                    string name = row["Name"].ToString();
                    string startDate = row["StartDate"].ToString();

                    // Add a new row to the DataGridView
                    dataGridView2.Rows.Add(roomNo, tenantID, name, startDate);
                }
            }
        }

        private void UpdateProgressBarColor()
        {
            // Get the total number of tenants
            int totalTenants = GetTotalTenantsCount();

            // Get the total number of max occupants from the DataGridView
            int totalMaxOccupants = GetTotalMaxOccupantsFromDataGridView();

            // Calculate the percentage of tenants relative to max occupants
            double percentage = (double)totalTenants / totalMaxOccupants * 100;

            // Set the circular progress bar values based on the totals
            circularProgressBar2.Maximum = 100;  // Max value is 100% for the percentage
            circularProgressBar2.Value = (int)percentage;
           // circularProgressBar1.Text = $"{(int)percentageOccupied}% Occupied, \n{(int)percentageAvailable}% Available";

            circularProgressBar2.Text = $"{(int)percentage}% \nNumber Of Tenants";
            circularProgressBar2.Font = new Font("Arial", 10, FontStyle.Bold); // You can adjust the font size and style
            circularProgressBar2.ForeColor = Color.Black; // Set the font color


            // Update the color based on the percentage
            if (percentage <= 100)
            {
                circularProgressBar2.ProgressColor = Color.FromArgb(178, 200, 223);  // Pink for tenants
                circularProgressBar2.ForeColor = Color.Pink;
            }
            else
            {
                circularProgressBar2.ProgressColor = Color.FromArgb(213, 164, 207);  // Blue for max occupants
                circularProgressBar2.ForeColor = Color.Blue;
            }
        }
        private int GetTotalTenantsCount()
        {
            int totalTenants = 0;

            try
            {
                string query = "SELECT COUNT(*) FROM table_tenant";
                using (MySqlCommand command = new MySqlCommand(query, database.getConnection()))
                {
                    database.getConnection().Open();
                    totalTenants = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions or log errors as needed
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                database.getConnection().Close();
            }

            return totalTenants;
        }
            private int GetTotalMaxOccupantsFromDataGridView()
           {
               int totalMaxOccupants = 0;

               try
               {
                   int maxOccupantsColumnIndex = dataGridView1.Columns["MaxOccupantsColumn"].Index;
                   foreach (DataGridViewRow row in dataGridView1.Rows)
                   {
                       // Check if the column exists in the row
                       if (row.Cells.Count > maxOccupantsColumnIndex && row.Cells[maxOccupantsColumnIndex].Value != null)
                       {
                           totalMaxOccupants += Convert.ToInt32(row.Cells[maxOccupantsColumnIndex].Value);
                       }
                   }
               }
               catch (Exception ex)
               {
                   // Handle exceptions or log errors as needed
                   MessageBox.Show("Error: " + ex.Message);
               }

               return totalMaxOccupants;
           }

        private void UpdateProgressBarColorButton_Click(object sender, EventArgs e)
        {
            UpdateProgressBarColor();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        //for employee
        private void DisplayEmployeeData()
        {
            try
            {
                // SQL query to retrieve specific columns from the table_employee
                string query = "SELECT Id, Name, Username, EmployeeType FROM table_employee";

                // Execute the query and get the result as a DataTable
                DataTable result = database.getData(query, null);

                // Set the DataTable as the DataSource for the DataGridView
                dataGridView3.DataSource = result;
            }
            catch (Exception ex)
            {
                // Handle exceptions or log errors as needed
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
