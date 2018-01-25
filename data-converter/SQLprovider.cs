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
            conn_string.Server = "127.0.0.1";
            conn_string.UserID = "root";
            conn_string.Password = "";
            conn_string.Database = "conversion";
            dataTable = new DataTable();
        }

        public DataTable PullData(String table)
        {
            String query = "SELECT * FROM " + table;
            MySqlConnection conn = new MySqlConnection(conn_string.ToString());
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try {
                conn.Open();
                Console.WriteLine("Connection Open");
                // create data adapter
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();

                Console.WriteLine("Query executed");
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

            return dataTable;
        }
    }
}
