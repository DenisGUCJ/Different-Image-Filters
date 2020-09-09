using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class DitheringInterval
    {
        public double Seed { get; set; }
        public Tuple<int,int> Index { get; set; }
        public double UpperK { get; set; }
        public double LowerK { get; set; }

    }
}
