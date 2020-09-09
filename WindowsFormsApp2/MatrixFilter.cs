using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    abstract public class MatrixFilter
    {
        public double[][] Kernel { get; set; }
        public int AnchorX { get; set; }
        public int AnchorY { get; set; }
}
}
