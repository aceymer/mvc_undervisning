using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jysk2_0.Context
{
    public class Paper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Readers { get; set; }
        public double PricePrMM { get; set; }
        
    }
}