using System;
using System.Collections.Generic;
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

            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = true;
            oWB = oXL.Workbooks.Add("");
            DataTable tables = sql.getTables();

            object misvalue = System.Reflection.Missing.Value;
            List<DataTable> dtList = new List<DataTable>();

            foreach (DataRow table in tables.Rows) {
                foreach (Object item in table.ItemArray) {
                    if (item != null || (string) item != string.Empty) {
                        DataTable data = sql.PullData(item.ToString());
                        if (data.Rows.Count > 0 && data != null) {
                            dtList.Add(data);
                        }
                    }
                }
            }

            foreach (DataTable t in dtList) {
                DataRow firstrow = t.Rows[0];
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet) oWB.Sheets.Add();

                int headingCount = 1;
                int itemCount = 1;
                int rowCount = 2;

                foreach (DataColumn col in firstrow.Table.Columns) {
                    oSheet.Cells[1, headingCount] = col.ToString();
                    headingCount++;
                }

                foreach (DataRow row in t.Rows) {
                    foreach (Object item in row.ItemArray) {
                        if (item != null || (string) item != string.Empty) {
                            oSheet.Cells[rowCount, itemCount] = item.ToString();
                            itemCount++;
                        }
                    }

                    itemCount = 1;
                    rowCount++;
                }
            }
        }
    }
}
