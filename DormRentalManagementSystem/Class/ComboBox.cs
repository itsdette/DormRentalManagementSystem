using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace DormRentalManagementSystem.Class
{
    internal class ComboBox
    {

        Class.myDatabase database = new Class.myDatabase();

        public DataTable employeeType()
        {
            string query = "SELECT DISTINCT EmployeeType FROM `table_employee`";
            DataTable dt = new DataTable();
            dt = database.getData(query, null);
            return dt;
        }

        public DataTable roomType()
        {
            string query = "SELECT DISTINCT RoomType FROM table_rooms";
            DataTable dt = new DataTable();
            dt = database.getData(query, null);
            return dt;
        }

        public DataTable email()
        {
            string query = " SELECT DISTINCT EmailAddress FROM table_tenant";
            DataTable dt = new DataTable();
            dt = database.getData(query, null);
            return dt;
        }


    }


}
