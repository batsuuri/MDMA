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
            }
            else
                CustDetail.InnerText = res.Desc;        }


    }
}