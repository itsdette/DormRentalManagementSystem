using DormRentalManagementSystem.Class;
using MySql.Data.MySqlClient;
using Mysqlx.Notice;
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
    public partial class frmPayment : Form
    {
        frmWarning warning = new frmWarning();
        Class.myDatabase database = new Class.myDatabase();
        string selectQuery, selectQuery2, searchText, searchQuery, randomLetters, currentDate, transactionNo;
        int uniqueNumber;
        decimal balance;
        decimal paymentAmount;
        decimal change;
        decimal rentAmount;
        
        public frmPayment()
        {
            InitializeComponent();
            txtboxPayment.TextChanged += txtboxPayment_TextChanged;
        }
        private void frmPayment_Load(object sender, EventArgs e)
        {
            Automatic();
            // retrieve all data from the table
            selectQuery = "SELECT TenantID, Name, RoomNo, RentAmount FROM table_tenant";

            // Call the GetData method to retrieve the data
            DataTable dt = database.getData(selectQuery, null);
            dataGridView1.DataSource = dt;

             selectQuery2 = "SELECT TenantID, Name, RoomNo, Balance, RentAmount FROM table_payment";
            DataTable dt2 = database.getData(selectQuery2, null);
            dataGridView2.DataSource = dt2;
            
            timer1.Start();

        }

        private void RefreshDataGridView()
        {
            //  query to retrieve all data from the table
             selectQuery = "SELECT TenantID, Name, RoomNo, Balance, RentAmount FROM table_payment";

            // Call the GetData method to retrieve the data
            DataTable dt = database.getData(selectQuery, null);

            // Bind the DataTable to the DataGridView
            dataGridView2.DataSource = dt;
            txtboxRent.Clear();
            txtboxRoomNo.Clear();
        }
        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
             searchText = txtboxSearch.Text.Trim();

             searchQuery = "SELECT TenantID, Name, RoomNo, RentAmount FROM table_tenant WHERE TenantID LIKE @searchText OR Name LIKE @searchText ";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
            new MySqlParameter("@searchText", "%" + searchText + "%")
            };

            DataTable result = database.getData(searchQuery, parameters);

            // Assuming dataGridView1 is your DataGridView control
            dataGridView1.DataSource = result; // Set the data source
        }

        private void txtboxPayment_TextChanged(object sender, EventArgs e)
        {

        }
        private string GenerateTransactionNumber(string paymentAmount)
        {
            
            // Generate three random letters
             randomLetters = GenerateRandomLetters();

            // Current date in the format YYYYMMDD
             currentDate = DateTime.Now.ToString("yyyyMMdd");

            // Generate a unique number (you can use a database-generated unique number)
             uniqueNumber = GetUniqueNumber();

            // Combine the random letters, current date, and unique number
             transactionNo = randomLetters + currentDate + uniqueNumber.ToString();

            return transactionNo;
        }

        private string GenerateRandomLetters()
        {
            Random random = new Random();
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(letters, 3)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        // simulate a unique number 
        private int GetUniqueNumber()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtboxPayment.Clear();
            txtboxBalance.Text = "";
            txtboxTenantID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtboxName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtboxRoomNo.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtboxRent.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();


            //string transactionNo = GenerateTransactionNumber(txtboxPayment.Text);

            // Set the generated transaction number in txtboxTransact
            txtboxTransacNo.Text = GenerateTransactionNumber(txtboxPayment.Text);
            btnUpdatePay.Enabled = false;
            btnAdd.Enabled = true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckIfTenantExists(txtboxTenantID.Text))
            {
                // Tenant ID exists, so disable the Add button

                btnAdd.Enabled = false;
                return;
            }

            //chang something

            if (!decimal.TryParse(txtboxRent.Text, out rentAmount) || !decimal.TryParse(txtboxPayment.Text, out paymentAmount))
            {
                warning.lblWarn.Text = "Invalid rent or payment amount!";
                warning.ShowDialog();
                return;
            }

            balance = rentAmount - paymentAmount;
            change = 0;

            if (balance < 0)
            {
                change = Math.Abs(balance);
                balance = 0;
            }
            
          string insertFirstPaymentQuery = "INSERT INTO table_payment_history (TransactionNo, TenantID, Name, RoomNo, RentAmount, Payment, Balance, Date, Time) VALUES " +
               "(@transactionNo, @tenantID, @name, @roomNo, @rentAmount, @payment, @balance, @date, @time)";

            MySqlParameter[] firstPaymentParameters = new MySqlParameter[]
            {
        new MySqlParameter("@transactionNo", txtboxTransacNo.Text),
        new MySqlParameter("@tenantID", txtboxTenantID.Text),
        new MySqlParameter("@name", txtboxName.Text),
        new MySqlParameter("@roomNo", txtboxRoomNo.Text),
        new MySqlParameter("@rentAmount", rentAmount),
        new MySqlParameter("@payment", paymentAmount),
        new MySqlParameter("@balance", balance),
        new MySqlParameter("@date", DateTime.Now.ToString("yyyy-MM-dd")),
        new MySqlParameter("@time", DateTime.Now.ToString("HH:mm:ss"))
            };

            database.setData(insertFirstPaymentQuery, firstPaymentParameters);
         
            string insertFirstPaymentQuery2 = "INSERT INTO table_payment (TenantID, Name, RoomNo, Balance, RentAmount) VALUES " +
               "( @tenantID, @name, @roomNo, @balance, @rentamount)";

            MySqlParameter[] firstPaymentParameters2 = new MySqlParameter[]
            {
        new MySqlParameter("@tenantID", txtboxTenantID.Text),
        new MySqlParameter("@name", txtboxName.Text),
        new MySqlParameter("@roomNo", txtboxRoomNo.Text),
        new MySqlParameter("@balance", balance),
        new MySqlParameter("@rentamount", txtboxRent.Text)
            };

            database.setData(insertFirstPaymentQuery2, firstPaymentParameters2);
            warning.lblWarn.Text = "First payment data has been successfully added!";
           // warning.Show();
            
            // Display the change in the change textbox
            txtboxChange.Text = change.ToString();

            // Refresh the DataGridView
            RefreshDataGridView();
        }
        private bool CheckIfTenantExists(string tenantID)
        { // Query to check if the tenant ID exists in table_payments
            string query = "SELECT COUNT(*) FROM table_payment WHERE TenantID = @tenantID";
            MySqlParameter[] parameter = new MySqlParameter[]
            {
                 new MySqlParameter("@tenantID", tenantID)
            };
            // ("@tenantID", tenantID);
            DataTable result = database.getData(query, parameter);
            int count = Convert.ToInt32(result.Rows[0][0]);
            return count > 0;
            // Execute the query and check if the count is greater than 0
            //object result = database.getData(query, parameter);
            //  int count = Convert.ToInt32(result);
            // return count > 0; 

        }

        public object getDataScalar(string query, MySqlParameter[] parameters)
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=dorm_rental_system"))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        connection.Open();
                        return command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions appropriately (e.g., log or display an error message)
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
            }
        }

        private void btnUpdatePay_Click(object sender, EventArgs e)
        {     
            

            if (!decimal.TryParse(txtboxBalance.Text, out balance) || !decimal.TryParse(txtboxPayment.Text, out paymentAmount))
            {
                warning.lblWarn.Text = "Invalid balance or payment amount!";
                warning.ShowDialog();
                return;
            }

            change = 0;

            if (paymentAmount > balance)
            {
                change = paymentAmount - balance;
                balance = 0;
            }
            else
            {
                balance -= paymentAmount;
            }

            // Update the balance in the textbox
            txtboxBalance.Text = balance.ToString();
            txtboxChange.Text = change.ToString();


            string insertFirstPaymentQuery = "INSERT INTO table_payment_history (TransactionNo, TenantID, Name, RoomNo, RentAmount, Payment, Balance, Date, Time) VALUES " +
              "(@transactionNo, @tenantID, @name, @roomNo, @rentAmount, @payment, @balance, @date, @time)";

            MySqlParameter[] firstPaymentParameters = new MySqlParameter[]
            {
        new MySqlParameter("@transactionNo", txtboxTransacNo.Text),
        new MySqlParameter("@tenantID", txtboxTenantID.Text),
        new MySqlParameter("@name", txtboxName.Text),
        new MySqlParameter("@roomNo", txtboxRoomNo.Text),
        new MySqlParameter("@rentAmount", txtboxRent.Text),
        new MySqlParameter("@payment", paymentAmount),
        new MySqlParameter("@balance", balance),
        new MySqlParameter("@date", DateTime.Now.ToString("yyyy-MM-dd")),
        new MySqlParameter("@time", DateTime.Now.ToString("HH:mm:ss"))
            };
            database.setData(insertFirstPaymentQuery, firstPaymentParameters);

            // Update the balance, payment amount, and other data in the database
            string updateBalanceQuery = "UPDATE table_payment SET Name = @name, RoomNo = @roomNo, Balance = @balance, RentAmount = @rentAmount WHERE TenantID = @tn";
            MySqlParameter[] updateBalanceParameters = new MySqlParameter[]
            {
        new MySqlParameter("@tn", txtboxTenantID.Text),
        new MySqlParameter("@name", txtboxName.Text),
        new MySqlParameter("@roomNo", txtboxRoomNo.Text),
        new MySqlParameter("@balance", balance),
        new MySqlParameter("@rentAmount", txtboxRent.Text)
            };
            database.setData(updateBalanceQuery, updateBalanceParameters);
            RefreshDataGridView();
            // Clear the textboxes for selecting other tenants
            txtboxRent.Clear();
            txtboxRoomNo.Clear();
            txtboxName.Clear();
            txtboxTenantID.Clear();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtboxPayment.Clear();
            int we = Convert.ToInt32(dataGridView2.CurrentRow.Cells[3].Value);
            if (we == 0)
            {
                txtboxTransacNo.Clear();
                txtboxTenantID.Clear();
                txtboxName.Clear();
                txtboxRoomNo.Clear();
                txtboxBalance.Clear();
                txtboxRent.Clear();
              //  warning.lblWarn.Text = "No Balance";
              //  warning.Show();
              new frmWarning().ShowDialog();


               // MessageBox.Show("No Balnce!");
            }
            else
            {
                txtboxTransacNo.Text = GenerateTransactionNumber(txtboxPayment.Text);
                txtboxTenantID.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                txtboxName.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                txtboxRoomNo.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                txtboxBalance.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                txtboxRent.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();

                btnAdd.Enabled = false;
                btnUpdatePay.Enabled = true;
            }
        }
        class Program{
        
        }
        static void Automatic()
        {
            // Assuming you have a database connection string
            string connectionString = "server=localhost;port=3306;username=root;password=;database=dorm_rental_system";

            // Get the starting date and time of the tenant and the rent amount from the database
            
            decimal rentAmount;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT t.TenantID, t.StartDate, t.RentAmount, tt.Balance FROM table_tenant t " +
                               "JOIN table_payment tt ON t.TenantID = tt.TenantID";

                //"SELECT t.TenantId, ts.StartDate, t.RentAmount, tt.CurrentBalance FROM Tenants t JOIN tableTenants tt ON t.TenantId = tt.TenantId JOIN tableStartDate ts ON t.TenantId = ts.TenantId";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    string tenantId = reader.GetString(0);
                    DateTime startingDate = DateTime.Parse(reader.GetString(1));
                    rentAmount = reader.GetDecimal(2);
                    decimal currentBalance = reader.GetDecimal(3);
                    TimeSpan timePassed = DateTime.Now - startingDate;


                    if (timePassed.TotalDays >= 30 )
                    {
                        decimal newBalance = currentBalance + rentAmount;
                        using (MySqlConnection updateConnection = new MySqlConnection(connectionString))
                        {
                            
                            updateConnection.Open();

                            string updateQuery = "UPDATE table_payment SET Balance = @newBalance WHERE TenantID = @id";
                            MySqlCommand updateCommand = new MySqlCommand(updateQuery, updateConnection);
                            updateCommand.Parameters.AddWithValue("@newBalance", newBalance);
                            updateCommand.Parameters.AddWithValue("@id", tenantId);
                            updateCommand.ExecuteNonQuery();

                            // Update the StartDate in the Tenants table
                            string updateStartDateQuery = "UPDATE table_tenant SET StartDate = @newStartDate WHERE TenantId = @id";
                            MySqlCommand updateStartDateCommand = new MySqlCommand(updateStartDateQuery, updateConnection);
                            DateTime newStartDate = startingDate.AddMonths(1); // Add 1 month to the starting date
                            updateStartDateCommand.Parameters.AddWithValue("@newStartDate", newStartDate.ToString("dd-MM-yyyy")); // Format the date as needed
                            updateStartDateCommand.Parameters.AddWithValue("@id", tenantId);
                            updateStartDateCommand.ExecuteNonQuery();

                            frmWarning warning = new frmWarning();
                            warning.lblWarn.Text = "30 days had passed. \nA balanced has been updated!";
                            warning.ShowDialog();
                        }
                      //  MessageBox.Show($"Rent amount added to the current balance for tenant {tenantId}.");
                        
                    }else
                      {
                     //   MessageBox.Show($"30 days have not passed since the starting date for tenant {tenantId}.");
         
                      }
                    
                }

            }
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
    }
}
