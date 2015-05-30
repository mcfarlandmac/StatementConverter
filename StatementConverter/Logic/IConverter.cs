using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace StatementConverter.Logic
{
    interface IConverter
    {
        Worksheet convertDataToExcel(string data);
    }
}
