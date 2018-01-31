using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace dataconverter
{
    public class SQLprovider
    {
        private MySqlConnectionStringBuilder conn_string;
        DataTable dataTable;

        public SQLprovider()
        {
            conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "";
            conn_string.UserID = "";
            conn_string.Password = "";
            conn_string.Database = "";
        }

        public DataTable PullData(String table)
        {
            dataTable = new DataTable();
            string query = "SELECT * FROM " + table;
            MySqlConnection conn = new MySqlConnection(conn_string.ToString());
            MySqlCommand cmd = new MySqlCommand(query, conn);

            try {
                conn.Open();
                Console.WriteLine("Connection open");
                // create data adapter
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(dataTable);
                Console.WriteLine("Query executed");
                conn.Close();
                Console.WriteLine("Connection closed");
                da.Dispose();
                

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

            return dataTable;
        }
    }
}
