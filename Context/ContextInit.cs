using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jysk2_0.Context
{
    public class ContextInit : DropCreateDatabaseAlways<ContextJysk>
    {
        protected override void Seed(ContextJysk context)
        {
            context.Colors.Add(new Color() { Id = 1, Name="Sort/Hvid", Price=10d});
            context.Colors.Add(new Color() { Id = 2, Name = "1 Farve", Price = 15d });
            context.Colors.Add(new Color() { Id = 3, Name = "4 Farver", Price = 25d });

            context.PaperTypes.Add(new PaperType() { Id = 1, Name = "RubrikAnnonce" });
            context.PaperTypes.Add(new PaperType() { Id = 2, Name = "TekstAnnonce" });
            context.PaperTypes.Add(new PaperType() { Id = 3, Name = "JobAnnonce" });

            context.ColumnWidths.Add(new ColumnWidth() { Id = 1, ColumnCount = 1, MM = 41 });
            context.ColumnWidths.Add(new ColumnWidth() { Id = 2, ColumnCount = 2, MM = 83 });
            context.ColumnWidths.Add(new ColumnWidth() { Id = 3, ColumnCount = 3, MM = 131 });
            context.ColumnWidths.Add(new ColumnWidth() { Id = 4, ColumnCount = 4, MM = 176 });
            context.ColumnWidths.Add(new ColumnWidth() { Id = 5, ColumnCount = 5, MM = 221 });
            context.ColumnWidths.Add(new ColumnWidth() { Id = 6, ColumnCount = 6, MM = 226 });

            context.Papers.Add(new Paper() { Id = 1, PricePrMM = 5.5, Amount = 11000, Readers = 12002, Name = "Lokal avisen Esbjerg" });
            context.Papers.Add(new Paper() { Id = 2, PricePrMM = 6.5, Amount = 12000, Readers = 10302, Name = "Lokal avisen Kolding" });
            context.Papers.Add(new Paper() { Id = 3, PricePrMM = 7.5, Amount = 13000, Readers = 11002, Name = "Lokal avisen Skjern" });
            context.Papers.Add(new Paper() { Id = 4, PricePrMM = 6.6, Amount = 110000, Readers = 10402, Name = "Lokal avisen Grindsted" });

            base.Seed(context);
        }
    }
}