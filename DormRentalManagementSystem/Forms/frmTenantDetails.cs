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
    public partial class frmTenantDetails : Form
    {

        frmWarning warning = new frmWarning();
        Class.myDatabase database = new Class.myDatabase();
        Class.ComboBox combo = new Class.ComboBox();
        public frmTenantDetails(string tenantID)
        {
            InitializeComponent();

            DataTable tenantDetails = GetTenantDetails(tenantID);

            // Check if details are available
            if (tenantDetails.Rows.Count > 0)
            {
                // Set values for controls based on the fetched details
                labelTenantID.Text = tenantDetails.Rows[0]["TenantID"].ToString();
                labelName.Text = tenantDetails.Rows[0]["Name"].ToString();
                labelSex.Text = tenantDetails.Rows[0]["Sex"].ToString();
                labelBirthday.Text = tenantDetails.Rows[0]["Birthday"].ToString();
                labelContact.Text = tenantDetails.Rows[0]["ContactNo"].ToString();
                labelEmail.Text = tenantDetails.Rows[0]["EmailAddress"].ToString();
                labelRoomID.Text = tenantDetails.Rows[0]["RoomID"].ToString();
                labelRoomNo.Text = tenantDetails.Rows[0]["RoomNo"].ToString();
                labelRoomType.Text = tenantDetails.Rows[0]["RoomType"].ToString();
                labelStartDate.Text = tenantDetails.Rows[0]["StartDate"].ToString();
                labelRent.Text = tenantDetails.Rows[0]["RentAmount"].ToString();

            }
            else
            {
                // Handle the case where no details are found
                MessageBox.Show("Details not found for the selected tenant.");
                this.Close(); // Close the form if no details are found
            }
        }

        private DataTable GetTenantDetails(string tenantID)
        {
            // logic to fetch tenant details from the database
            string query = "SELECT * FROM table_tenant WHERE TenantID = @TenantID";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
            new MySqlParameter("@TenantID", tenantID),
            };

            return database.getData(query, parameters);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
