using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class ConvolutionFilter: MatrixFilter
    {
        public string Name { get; set; }
        public double Factor { get; set; }
        public double Bias { get; set; }
        public int Offset { get; set; }
    }
}
