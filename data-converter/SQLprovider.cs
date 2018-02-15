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

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dataTable);
                Console.WriteLine("Query PullData executed");

                conn.Close();
                da.Dispose();
                Console.WriteLine("Connection closed");

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

            return dataTable;
        }

        public DataTable getTables ()
        {
            dataTable = new DataTable();
            string query = "SELECT table_name FROM information_schema.tables WHERE table_schema='" + conn_string.Database + "';";
            MySqlConnection conn = new MySqlConnection(conn_string.ToString());
            MySqlCommand cmd = new MySqlCommand(query, conn);

            try {
                conn.Open();
                Console.WriteLine("Connection open");

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dataTable);
                Console.WriteLine("Query getTables executed");

                conn.Close();
                da.Dispose();
                Console.WriteLine("Connection closed");

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

            return dataTable;
        }
    }
}
