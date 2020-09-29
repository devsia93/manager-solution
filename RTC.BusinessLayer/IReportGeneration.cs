using System;
using System.Collections.Generic;
using System.IO;

namespace RTC.BusinessLayer
{
    public interface IReportGenerator
    {
        void fillExcelTableByType(IEnumerable<object> grid, string currentTable, FileInfo xlsxFile);
    }
}
