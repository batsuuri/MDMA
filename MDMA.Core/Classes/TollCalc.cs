using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMA.Core
{
    class TollCalc
    {
        
        
        // Calculation of Drivers Compulsory Liability Insurance
        public RatioDCLI CalcDCLI(DCLI dcli)
        {
            RatioDCLI rate = new RatioDCLI(1);
            double it;
            #region I1
            #endregion

            #region I2
            #endregion
            #region I3
            #endregion

            #region I4
            rate.I4 = 1;
            #endregion

            #region I5
            rate.I5 = 1;
            //if (misstatment) // Meduuleg buruu ogson bol
            //{
            //    rate.I5 = 1.3;
            //}
            #endregion

            #region 
            if (!dcli.IsLimitedDrivers)
            {
                rate.I6 = 1.5;
            }
            #endregion

            #region I7
            it = 1;
            switch (dcli.Vechile.Transporttype)
            {
                case "B":
                    if (dcli.Vechile.EngineCapacity <= 1000)
                        it = 0.9;
                    else if (dcli.Vechile.EngineCapacity >= 1001 && dcli.Vechile.EngineCapacity <= 2000)
                        it = 1;
                    else if (dcli.Vechile.EngineCapacity >= 2001 && dcli.Vechile.EngineCapacity <= 3000)
                        it = 1.1;
                    else if (dcli.Vechile.EngineCapacity >= 3001 && dcli.Vechile.EngineCapacity <= 4000)
                        it = 1.2;
                    else if (dcli.Vechile.EngineCapacity >= 4001 )
                        it = 1.3;
                    break;
                case "C":
                    if (dcli.Vechile.Payloadcapacity <= 8000)
                        it = 1;
                    else
                        it = 1.3;
                    break;
                case "D":
                    if (dcli.Vechile.Seatingcapacity <= 16)
                        it = 1;
                    else
                        it = 1.3;
                    break;
                default:
                    break;
            }
            rate.I7 = it;
            #endregion

            #region I8
            if (dcli.Driver.IsOrg)
            {
                rate.I8 = 1.5;
            }
            #endregion

            #region I9
            // Achaanii machinii dugaar oruulj uzeh
            #endregion
            return rate;
        }
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
        }
    }
}
