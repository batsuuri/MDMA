using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using MDMA;
using MDMA.Core;
namespace MDMA.Service
{
    /// <summary>
    /// Summary description for MDMA
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AppService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Result Call(string func, string json) {

            Result res = new Result();
            try
            {

            }
            catch (Exception ex)
            {
                Main.ErrorLog("AppService_Call:" + func, ex);
                Main.TestLog("AppService_Call:" + func, json);
            }
            return res;
        }

        private Result Login(object[] param)
        {
            Result result = new Result();
            ServiceUser sUser = new ServiceUser();
            byte[] pin;
            try
            {
                // 2015.06.09 MOST - iin huselteer haasan
                // 2015.09.25 Customs&Tax төслийн хүрээнд буцааж нээв. Өмнөх хувилбарыг дэмжих боломжтой байхаар шийдэв.
                if (param != null && param.Length != 0)
                {
                    if ((Func.ToShort(param[0]) >= app_data_encrypted_version_android && Func.ToShort(param[1]) == (short)enumChannel.eAndroid_channel) ||
                            (Func.ToShort(param[0]) >= app_data_encrypted_version_ios && Func.ToShort(param[1]) == (short)enumChannel.eIPhone_channel))
                    {

                        DecryptData(ref param, 2);
                    }
                }

                if (param.Length == 11)
                {
                    #region Login process

                    sUser.Version = Func.ToShort(param[0]);
                    sUser.Channel = Func.ToShort(param[1]);
                    sUser.Type = (enumAppletType)Func.ToShort(param[2]); //1- customer 2- merchant 3-agent
                    sUser.Lang = (enumLang)Func.ToShort(param[3]);
                    sUser.LoginName = Func.ToStr(param[4]);
                    sUser.MSISDN = Func.ToStr(param[5]);
                    sUser.EncPin = Func.ToStr(param[6]);
                    sUser.Pin = Func.ToStr(param[7]); //server-s hash-lsan byte[]-g hex bolgood yavuulj bgaa.
                    pin = CUtility.StringToByteArray(sUser.Pin);
                    sUser.Pin = Convert.ToBase64String(pin);
                    sUser.HostIP = Func.ToStr(param[8]);
                    sUser.HostName = Func.ToStr(param[9]);
                    sUser.HostMac = Func.ToStr(param[10]);
                    CUtility._webremote.SessionType = (short)sUser.Type;
                    CUtility._webremote.SourceNo = sUser.Channel;
                    CUtility._webremote.TerminalType = sUser.Version;

                    result = CUtility._webremote.CustLogin(sUser.LoginName, sUser.MSISDN, sUser.EncPin, sUser.HostName, CUtility.GetClientIPAddress(), sUser.HostMac, (int)sUser.Lang, sUser.Version, (short)sUser.Type, sUser.Channel, false);

                    #endregion Login process

                    #region Unsuccessfully login

                    if (result.retType != 0 && result.retType != 60007216 && result.retType != 12200108)
                    {
                        CUtility.ErrorLog(sUser.MSISDN, "Login failed. LoginName: " + sUser.LoginName + " MSISDN: " + sUser.MSISDN + " retDesc = " + result.retDesc + " rettype = " + result.retType.ToString());
                        if (result.retType == 1 || result.retType == 12000001 || result.retType == 101 || result.retType == 102)
                        {
                            result.retDesc = CUtility.GetConnectionFailedMessage((short)sUser.Lang);
                        }
                        sUser.retType = result.retType;
                        sUser.retDesc = result.retDesc;
                    }

                    #endregion Unsuccessfully login

                    #region Successfull login

                    else
                    {
                        #region Init User

                        sUser.SessionID = (ulong)Func.ToLong(result.retParams[0]);

                        sUser.KeyHex = Func.ToStr(result.retParams[1]);
                        sUser.IVHex = Func.ToStr(result.retParams[2]);
                        object[] obj = new object[2];
                        if (sUser.Type == enumAppletType.eCustomer)
                        {
                            sUser.IsPrepiad = Func.ToShort(result.retParams[3]);
                            sUser.CustType = Func.ToShort(result.retParams[4]);     // OnlineCustomer - 5, Affiliate - 2
                            sUser.MSISDN = Func.ToStr(result.retParams[5]);
                            sUser.IsNewPinCode = Func.ToShort(result.retParams[6]);
                            sUser.ID = Func.ToLong(result.retParams[7]);
                        }
                        else if (sUser.Type == enumAppletType.eMerchant)
                        {
                            sUser.IsPrepiad = Func.ToShort(result.retParams[3]);
                            sUser.CustType = Func.ToShort(result.retParams[3]);
                            sUser.MSISDN = Func.ToStr(result.retParams[4]);
                            sUser.IsNewPinCode = Func.ToShort(result.retParams[5]);
                            sUser.ID = Func.ToLong(result.retParams[6]);
                        }
                        else
                        {
                            sUser.CustType = 0;
                            sUser.MSISDN = Func.ToStr(result.retParams[3]);
                            sUser.IsNewPinCode = Func.ToShort(result.retParams[4]);
                        }

                        if (result.retType == 60007216 || result.retType == 12200108)
                        {
                            sUser.IsNewPinCode = 2;
                        }
                        sUser.retType = result.retType;
                        sUser.retDesc = result.retDesc;
                        result.retType = 0;
                        obj[0] = sUser.CustType;
                        obj[1] = sUser.IsNewPinCode;
                        result.retParams = obj;
                        mSmartUser = sUser; //Amjilttai bol session-d hadgalna.

                        #endregion Init User
                    }

                    #endregion
                }
                else
                {
                    result.retType = 1;
                    result.retDesc = "Параметр буруу!|Wrong parameters!";
                }
            }
            catch (Exception ex)
            {
                CUtility.ErrorLog("Login Ex : ", ex);
                sUser.retType = 1;
                sUser.retDesc = "Системд алдаа гарлаа!|System error!";
            }
            return result;
        }
    }
}
