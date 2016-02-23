using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jysk2_0.Context
{
    public class ColumnWidth
    {
        public int Id { get; set; }
        public int MM { get; set; }
        public int ColumnCount { get; set; }

        public string ColumnWidthString {
            get { return ColumnCount + " spalte (" + MM + " mm)"; }
        }
    }
}