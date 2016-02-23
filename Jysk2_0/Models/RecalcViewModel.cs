using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jysk2_0.Models
{

    //Recalc test
    public class RecalcViewModel
    {
        [Display(Name="Selections", ResourceType=typeof(Resources.Resources))]
        public int SelectedColorId { get; set; }
        public SelectList Colors { get; set; }
        public SelectList PaperTypes { get; set; }
        public SelectList ColumnWidths { get; set; }
    }
}