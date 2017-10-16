using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMA.Core
{
     public class DCLI
    {
        public Customer Driver { get; set; }
        public Vehicle Vehicle { get; set; }
        public Customer[] Drivers { get; set; }
        public bool IsLimitedDrivers { get; set; }

    }
    public struct RatioDCLI
    {
        public double I1;
        public double I2;
        public double I3;
        public double I4;
        public double I5;
        public double I6;
        public double I7;
        public double I8;
        public double I9;
        public double TotalFee;

        public RatioDCLI(int i)
        {
            I1 = i;
            I2 = i;
            I3 = i;
            I4 = i;
            I5 = i;
            I6 = i;
            I7 = i;
            I8 = i;
            I9 = i;
            TotalFee = 0;
        }
    }

}
