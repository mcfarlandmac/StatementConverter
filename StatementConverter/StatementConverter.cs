using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using StatementConverter.Logic;

namespace StatementConverter
{
    public partial class StatementConverter : Form
    {
        public StatementConverter()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            IConverter converter = new CapitalOneConverter();

            Excel.Worksheet excelWorksheet = converter.convertDataToExcel(txtData.Text);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel 2003|*.xls";
            saveFileDialog.Title = "Save Excel File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                excelWorksheet.SaveAs(saveFileDialog.FileName);
            }
        }
    }
}
