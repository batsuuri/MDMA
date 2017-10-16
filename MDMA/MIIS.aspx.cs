using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MDMA.Core;
namespace MDMA
{
    public partial class MIIS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WebAPI.MIIS m = new WebAPI.MIIS();
            Result res = m.GetDriverInfo(txtRN.Text);
            if (res.Succeed)
            {
                CustDetail.InnerText = Func.ToStr(res.Data);
                Customer cust = new Customer();
                cust = Newtonsoft.Json.JsonConvert.DeserializeObject<Customer>(Func.ToStr(res.Data));
                Session["Cust"] = cust;
            }
            else
                CustDetail.InnerText = res.Desc + Environment.NewLine + Func.ToStr(res.Data);        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            WebAPI.MIIS m = new WebAPI.MIIS();
            Result res = m.GetVechileInfo(txtVN.Text);
            if (res.Succeed)
            {
                VechileDetail.InnerText = Func.ToStr(res.Data);

                Vehicle car = new Vehicle();
                car = Newtonsoft.Json.JsonConvert.DeserializeObject<Vehicle>(Func.ToStr(res.Data));

                Session["Car"] = car;
            }
            else
                VechileDetail.InnerText = res.Desc + Environment.NewLine + Func.ToStr(res.Data);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            FeeCalc calc = new FeeCalc();
            DCLI dcli = new DCLI();
            dcli.IsLimitedDrivers = true;
            dcli.Driver = (Customer)Session["Cust"];
            dcli.Vehicle = (Vehicle)Session["Car"];
            dcli.Drivers = null;

            RatioDCLI rate  = calc.CalcDCLI(dcli);
            txtFee.Text = Func.ToStr(rate.TotalFee);

            string it = "Й1: " + Func.ToStr(rate.I1);
            it = it + Environment.NewLine +  "Й2: " + Func.ToStr(rate.I2);
            it = it + Environment.NewLine +  "Й3: " + Func.ToStr(rate.I3);
            it = it + Environment.NewLine +  "Й4: " + Func.ToStr(rate.I4);
            it = it + Environment.NewLine +  "Й5: " + Func.ToStr(rate.I5);
            it = it + Environment.NewLine +  "Й6: " + Func.ToStr(rate.I6);
            it = it + Environment.NewLine +  "Й7: " + Func.ToStr(rate.I7);
            it = it + Environment.NewLine +  "Й8: " + Func.ToStr(rate.I8);
            it = it + Environment.NewLine +  "Й9: " + Func.ToStr(rate.I9);
            txtIt.InnerText = it;
        }
    }
}