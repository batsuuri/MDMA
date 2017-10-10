using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MDMA.Core;
using System.Configuration;
using System.Net;
using System.Text;
using System.IO;

namespace MDMA
{
    public class WebAPI
    {
        public class MIIS
        {
            public static string _user = Func.ToStr(ConfigurationManager.AppSettings["MIIS_User"]);
            public static string _pass= Func.ToStr(ConfigurationManager.AppSettings["MIIS_Pass"]);
            public static string _url= Func.ToStr(ConfigurationManager.AppSettings["MIIS_Url"]);
            private string _sessionid = "";


            public Result GetDriverInfo(string rn)
            {
                Result res = new Result(true);

                try
                {
                    res = Login();
                    if (!res.Succeed)
                    {
                        return res;
                    }

                    //https://miis.ami.mn/MIIS/sagent/rnsearch?rn=%D0%B9%D1%8082051311
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url+ "sagent/rnsearch?rn=" + rn);
                    
                    request.Method = "Get";
                    request.KeepAlive = true;
                    request.Accept = "application/json, text/javascript, */*; q=0.01";
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("Cookie", _sessionid);
                    //request.ContentType = "application/x-www-form-urlencoded";
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    string myResponse = "";
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
                    {
                        myResponse = sr.ReadToEnd();
                    }
                    res.Data = myResponse;
                }
                catch (Exception ex)
                {
                    res.Succeed = false;
                    res.Desc = ex.ToString();
                    Main.ErrorLog("WebAPI.MIIS.GetDriverInfo", ex.ToString());
                }

                return res;
            }

            public Result GetVechileInfo(string sn)
            {
                Result res = new Result(true);

                try
                {
                    res = Login();
                    if (!res.Succeed)
                    {
                        return res;
                    }

                    //https://miis.ami.mn/MIIS/sagent/vsnsearch?sn=0144%D0%A3%D0%9D%D0%91
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url + "sagent/vsnsearch?sn=" + sn);

                    request.Method = "Get";
                    request.KeepAlive = true;
                    request.Accept = "application/json, text/javascript, */*; q=0.01";
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("Cookie", _sessionid);
                    //request.ContentType = "application/x-www-form-urlencoded";
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    string myResponse = "";
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
                    {
                        myResponse = sr.ReadToEnd();
                    }
                    res.Data = myResponse;
                }
                catch (Exception ex)
                {
                    res.Succeed = false;
                    res.Desc = ex.ToString();
                    Main.ErrorLog("WebAPI.MIIS.GetVechileInfo", ex.ToString());
                }

                return res;
            }

            internal Result Login()
            {
                Result res = new Result(true);

                try
                {

                    CookieContainer cookies = new CookieContainer();
                    System.Net.ServicePointManager.Expect100Continue = false;

                    HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(_url);
                    request1.CookieContainer = cookies;
                    //Get the response from the server and save the cookies from the first request..
                    HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url + "login");

                    request.Method = "POST";
                    request.KeepAlive = true;
                    request.Accept ="text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.CookieContainer = cookies;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
                    request.Referer = _url;
                    request.AllowWriteStreamBuffering = true;
                    request.ProtocolVersion = HttpVersion.Version11;
                    request.AllowAutoRedirect = false;
                    request.Date = System.DateTime.Now;

                    request.Headers.Add("Origin", "https://miis.ami.mn");
                    request.Headers.Add("Accept-Language", "n-US,en;q=0.8,bg;q=0.6,ru;q=0.4,mn;q=0.2");
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.Add("Upgrade-Insecure-Requests", "1");
                    request.Headers.Add("Cache-Control", "max-age=0");

                    var postData = "username="+_user;
                    postData += "&password="+_pass;

                    //var data = Encoding.ASCII.GetBytes(postData);

                    request.ContentLength = postData.Length;

                    StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
                    requestWriter.Write(postData);
                    requestWriter.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.Found && Func.ToStr( response.GetResponseHeader("Location")) != "")
                        _sessionid = request.Headers["Cookie"];
                    else
                    {
                        res.Desc = "MIIS -д нэвтэрч чадсангүй.";
                        res.Succeed = false;
                        string myResponse = "";
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
                        {
                            myResponse = sr.ReadToEnd();
                        }
                        res.Data = myResponse;
                    }

                    //_sessionid = response.Cookies["JSESSIONID"].Value;

                    response.Close();

                }
                catch (Exception ex)
                {
                    res.Succeed = false;
                    res.Desc = ex.ToString();
                    Main.ErrorLog("WebAPI.MIIS.Login", ex.ToString());
                }
               

                return res;
            }
        }
    }
}
