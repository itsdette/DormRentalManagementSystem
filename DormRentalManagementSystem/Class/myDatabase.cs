using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace DormRentalManagementSystem.Class
{
    internal class myDatabase
    {

        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=dorm_rental_system");
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        public DataTable dt;
        int result;

        public void OpenConnection()
        {

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

        }
        public void ClosedConnection()
        {

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
        public DataTable getData(string query, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand(query, getConnection());

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            return dt;
        }
        //create a function to set data and execute ung query
        public int setData(string query, MySqlParameter[] parameters)
        {

            MySqlCommand command = new MySqlCommand(query, getConnection());
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            OpenConnection();
            int commandState = command.ExecuteNonQuery();

            ClosedConnection();

            return commandState;

        }


        public bool DataExists(string roomNo)
        {
            // Use getData method to check if the RoomNo already exists in the specified table
            string selectQuery = "SELECT COUNT(*) FROM table_rooms WHERE roomNo = @RoomNo";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@RoomNo", roomNo)
            };

            DataTable result = getData(selectQuery, parameters);

            // Check if any rows were returned and if the count is greater than 0
            return result.Rows.Count > 0 && Convert.ToInt32(result.Rows[0][0]) > 0;
        }



    }
}
