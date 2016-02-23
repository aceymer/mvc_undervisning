using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Jysk2_0
{
    public partial class ColumnWidth
    {
        public string ColumnWidthString
        {
            get { return ColumnCount + " spalte (" + MM + " mm)"; }
        }
    }
}