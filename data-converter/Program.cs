using System;
using System.Data;

namespace dataconverter
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            SQLprovider sql = new SQLprovider(); 
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;

            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = true;
            oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
            oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

            object misvalue = System.Reflection.Missing.Value;
            DataTable t = sql.PullData("AuthAssignment");
            DataRow firstrow = t.Rows[0];

            int columnCounter = 0;
            foreach (System.Data.DataColumn col in firstrow.Table.Columns) {
                oSheet.Cells[1, columnCounter] = col.ToString();
                Console.Write(col + " | ");
            }
            Console.WriteLine(" ");

            foreach(System.Data.DataRow row in t.Rows) {
                foreach(Object item in row.ItemArray) {
                    if (item != null || (string)item != string.Empty) {
                        Console.Write(item + " | ");
                    }
                }
                Console.WriteLine(" ");
            }
        }
    }
}
