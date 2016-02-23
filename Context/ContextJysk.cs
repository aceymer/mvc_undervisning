using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jysk2_0.Context
{
    public class ContextJysk : DbContext
    {

        public ContextJysk() : base("JyskDB") {
            Database.SetInitializer(new ContextInit());
        }

        public DbSet<Paper> Papers { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ColumnWidth> ColumnWidths { get; set; }
        public DbSet<PaperType> PaperTypes { get; set; }

    }


}