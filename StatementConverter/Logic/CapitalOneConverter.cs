using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.Globalization;
using StatementConverter.Logic.Model;

namespace StatementConverter.Logic
{
    class CapitalOneConverter : IConverter
    {
        public Worksheet convertDataToExcel(string data)
        {
            // Parse the data
            string[] rows = data.Split('\n');
            List<CapitalOneRow> dataRows = new List<CapitalOneRow>();

            string dateFormat = "M/dd/yy";
            foreach (string row in rows){
                string[] columns = row.Replace("\r", "").Split(' ');

                // Determine if the first column is a date. If so, we have a row to insert
                DateTime transactionDate;
                if (DateTime.TryParseExact(columns[0], 
                                           dateFormat, 
                                           CultureInfo.InvariantCulture, 
                                           DateTimeStyles.None, 
                                           out transactionDate))
                {
                    // We have a valid row. Let's retrieve the data and create a row object.
                    CapitalOneRow capitalOneRow = new CapitalOneRow();
                    capitalOneRow.TransactionDate = transactionDate;
                    capitalOneRow.Description = columns[1];
                    capitalOneRow.Amount = columns[3];

                    

                    // Add the new row
                    dataRows.Add(capitalOneRow);
                }
            }
            
            // Create excel file
            Application excelFile = new Application();
            excelFile.Visible = false;

            // Create a new workbork
            Workbook workbook = excelFile.Workbooks.Add(Missing.Value);

            // Create a new worksheet
            Worksheet worksheet = workbook.ActiveSheet;

            // Create the column headings for the worksheet
            worksheet.Name = "Capital One Transactions";
            worksheet.Cells[1, 1] = "Transaction Date";
            worksheet.Cells[1, 2] = "Description";
            worksheet.Cells[1, 3] = "Amount";

            // Loop through the rows of data, adding them to the spreadsheet
            int currentRow = 2;
            foreach (CapitalOneRow excelRow in dataRows){
                worksheet.Cells[currentRow, 1] = excelRow.TransactionDate;
                worksheet.Cells[currentRow, 2] = excelRow.Description;
                worksheet.Cells[currentRow, 3] = excelRow.Amount;

                currentRow++;
            }

            return worksheet;
        }
    }
}
