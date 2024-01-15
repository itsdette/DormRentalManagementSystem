using DormRentalManagementSystem.Class;
using MySql.Data.MySqlClient;
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
    public partial class frmPaymentHistory : Form
    {

        frmWarning warning = new frmWarning();
        Class.myDatabase database = new Class.myDatabase();
        Class.ComboBox combo = new Class.ComboBox();
        string selectQuery;
        public frmPaymentHistory()
        {
            InitializeComponent();
        }

        private void frmPaymentHistory_Load(object sender, EventArgs e)
        {
            //  query to retrieve all data from the table
             selectQuery = "SELECT * FROM table_payment_history";

            // Call the GetData method to retrieve the data
            DataTable dt = database.getData(selectQuery, null);

            // Bind the DataTable to the DataGridView
            dataGridView2.DataSource = dt;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtboxSearch.Text.Trim();

            string searchQuery = "SELECT TransactionNo, PaymentID, TenantID, Name, RoomNo, RentAmount, Payment, Balance, Date, Time FROM table_payment_history WHERE TransactionNo LIKE @searchText OR Name LIKE @searchText OR TenantID LIKE @searchText ";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
            new MySqlParameter("@searchText", "%" + searchText + "%")
            };
            DataTable result = database.getData(searchQuery, parameters);
            // Assuming dataGridView1 is your DataGridView control
            dataGridView2.DataSource = result; // Set the data source
        }
    }
}
