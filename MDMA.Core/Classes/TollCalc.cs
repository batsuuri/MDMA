using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MDMA.Core
{
    public class FeeCalc
    {
        // Calculation of Drivers Compulsory Liability Insurance
        public RatioDCLI CalcDCLI(DCLI dcli)
        {
            RatioDCLI rate = new RatioDCLI(1);
            double it = 1;

            #region 
            int zip = Func.ToInt(dcli.Driver.ZipCode);
            if (zip < 19000)
            {
                it = 1.2;
            }
            else if ((zip > 43000 && zip < 44000) || (zip > 40000 && zip < 42000) || (zip > 45000 && zip < 45999) || (zip > 61000 && zip < 61999))
            {
                it = 1.1;
            }
            else
                it = 1;
            rate.I1 = it;
            #endregion

            #region I2
            if (!dcli.IsLimitedDrivers) // Жолоочын тоо хязгаарлаагүй бол 3 -р бүлэгт оруулж И2 =1 байна
            {
                it = 1.2;
            }
            else
            {
                int X = 3; 
                double[] n = { 2.45, 2.3, 1.55, 1.4, 1, 0.95, 0.9, 0.85, 0.8, 0.75, 0.7, 0.65, 0.6, 0.55, 0.5 };
                int[,] r = {
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 14 }
                        , {0, 0, 0, 2, 2, 3, 4, 5, 5, 6, 6, 7, 7, 7, 8}
                        , {0, 0, 0, 0, 0, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4}
                        , {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2}
                        , {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};

                // Calculation PGroup,Хоосон бол 0, 14 -с бага бол утгыг нь 1 -р нэмэгдүүлнэ, 14 -с их бол хэвээр
                X = Func.ToInt(dcli.Driver.PGroup) == 0 ? 0 : (dcli.Driver.PGroup <= 14 ? dcli.Driver.PGroup + 1 : dcli.Driver.PGroup);

                // Нөхөн төлбөр авч байсан тоо 4 -с их бол R массиваас 4 -р баганыг сонгоно
                int Y = Func.ToInt(dcli.Driver.PNumAmends) >= 4 ? 4 : Func.ToInt(dcli.Driver.PNumAmends);
                
                it = n[r[Y,X]];
            }

            rate.I2 = it;
            #endregion

            #region I3
            it = 1;
            if (!dcli.IsLimitedDrivers) // Жолоочын тоо хязгаарлаагүй бол 1.2
            {
                it = 1.2;
            }
            else
            {
                double tmp = 1;
                tmp = CalcI3(dcli.Driver);
                if (tmp > it)
                {
                    it = tmp;
                }
                if (dcli.Drivers !=null && dcli.Drivers.Count()>0)
                {
                    for (int i = 0; i < dcli.Drivers.Count(); i++)
                    {
                        tmp = CalcI3(dcli.Drivers[i]);
                        if (tmp>it)
                        {
                            it = tmp;
                        }
                    }
                }
            }
            rate.I3 = it;
            #endregion

            #region I4
            // Дандаа 1 жилээр байгуулна гэж үзэв
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
            if (!dcli.IsLimitedDrivers) // Жолоочийн тоо хязгаарлаагүй бол
            {
                rate.I6 = 1.5;
            }
            #endregion

            #region I7
            it = 1;
            switch (dcli.Vehicle.Transporttype.ToUpper())
            {
                case "B":
                    if (dcli.Vehicle.EngineCapacity <= 1000)
                        it = 0.9;
                    else if (dcli.Vehicle.EngineCapacity >= 1001 && dcli.Vehicle.EngineCapacity <= 2000)
                        it = 1;
                    else if (dcli.Vehicle.EngineCapacity >= 2001 && dcli.Vehicle.EngineCapacity <= 3000)
                        it = 1.1;
                    else if (dcli.Vehicle.EngineCapacity >= 3001 && dcli.Vehicle.EngineCapacity <= 4000)
                        it = 1.2;
                    else if (dcli.Vehicle.EngineCapacity >= 4001 )
                        it = 1.3;
                    break;
                case "C":
                    if (dcli.Vehicle.Payloadcapacity <= 8000)
                        it = 1;
                    else
                        it = 1.3;
                    break;
                case "D":
                    if (dcli.Vehicle.Seatingcapacity <= 16)
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
            if (dcli.Driver.IsOrg) // Байгууллага бол
            {
                rate.I8 = 1.5;
            }
            #endregion

            #region I9
            // Achaanii machinii dugaar oruulj uzeh
            #endregion

            #region CalcFee
            double initialFee = 33000; // 

            //"A" == e("#Transporttype").val() && (e("#ci0").text("12500"), e("#prt_ci0").text("12500")),
            //"B" == e("#Transporttype").val() && (e("#ci0").text("33000"), e("#prt_ci0").text("33000")),
            //"C" == e("#Transporttype").val() && (e("#ci0").text("42500"), e("#prt_ci0").text("42500")),
            //"D" == e("#Transporttype").val() && (e("#ci0").text("53000"), e("#prt_ci0").text("53000")),
            //"M" == e("#Transporttype").val() && (e("#ci0").text("12500"), e("#prt_ci0").text("12500")),
            switch (dcli.Vehicle.Transporttype.ToUpper())
            {
                case "A":
                case "M":
                    initialFee = 12500;
                    break;
                case "C":
                    initialFee = 42500;
                    break;
                case "D":
                    initialFee = 53000;
                    break;
                default:
                    break;
            }
            rate.TotalFee = initialFee * rate.I1 * rate.I2 * rate.I3 * rate.I4 * rate.I5 * rate.I6 * rate.I7 * rate.I8 * rate.I9;
           
            #endregion
            return rate;
        }

        #region Helper Function
        private double CalcI3(Customer driver) {
            double it = 1;

            string regNumPatern = @"\w{2}\d{8}";
            if (Regex.IsMatch(driver.Rn, regNumPatern)) // Монголын регистерийн дугаар бол
            {
                string temp = driver.Rn.Substring(2, 6);
                if (Func.ToInt("20" + driver.Rn.Substring(2, 2)) > DateTime.Now.Year)
                {
                    temp = "19" + temp;
                }
                else
                    temp = "20" + temp;
                DateTime birthdate = Func.ToDate(temp);
                driver.Age = Func.DateDiff("Y", birthdate, DateTime.Now); // Нас
            }
            else
            {
                driver.Age = 0;
            }

            if (driver.Age < 25 && driver.Experience < 3)
            {
                it = 1.2;
            }
            else if (driver.Age < 25 && driver.Experience >= 3)
            {
                it = 1.15;
            }
            else if (driver.Age >= 25 && driver.Experience < 3)
            {
                it = 1.1;
            }
            else if (driver.Age >= 25 && driver.Experience >= 3)
            {
                it = 1;
            }
            return it;
            //ff =117 - parseInt(e("#Rn").val().substring(2, 4)) < 25 ? parseInt(e("#Experience").val()) < 3 ? 1.2 : 1.15 : 117 - parseInt(e("#Rn").val().substring(2, 4)) == 25 ? parseInt(e("#Rn").val().substring(4, 6)) <= parseInt(ddate.substring(5, 7)) && parseInt(e("#Rn").val().substring(6, 8)) <= parseInt(ddate.substring(8, 10)) ? parseInt(e("#Experience").val()) < 3 ? 1.1 : 1 : parseInt(e("#Rn").val().substring(4, 6)) == parseInt(ddate.substring(5, 7)) && parseInt(e("#Rn").val().substring(6, 8)) <= parseInt(ddate.substring(8, 10)) ? parseInt(e("#Experience").val()) < 3 ? 1.1 : 1 : parseInt(e("#Experience").val()) < 3 ? 1.2 : 1.15 : parseInt(e("#Experience").val()) < 3 ? 1.1 : 1

        }
        #endregion
    }
}
