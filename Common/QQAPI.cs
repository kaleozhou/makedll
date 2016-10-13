using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace Common
{
   public class QQAPI
    {
       public static QQUserInfo get_user_info(string AppID,string format="json")
       {
           try
           {
               string accessToken = CookieHelper.GetCookieValue("accessToken");
               string url = "https://graph.qq.com/oauth2.0/me?access_token=" + accessToken;
               string WebCodes = getWebCodes(url, url, "utf-8").Replace("callback( ","").Replace(");","");
               Callback cback = new Callback();
               cback = JsonConvert.DeserializeObject<Callback>(WebCodes);
               url = "https://graph.qq.com/user/get_user_info?oauth_consumer_key=" + AppID + "&access_token=" + accessToken + "&openid=" + cback.openid + "&format=" + format;
               WebCodes = getWebCodes(url, url, "utf-8");
               QQUserInfo model = new QQUserInfo();
               model = JsonConvert.DeserializeObject<QQUserInfo>(WebCodes);
               model.openid = cback.openid;
               return model;
           }
           catch 
           {
               return null;
           }

       }
       #region 获取网页源码
       /// <summary>
       /// 获取网页源码
       /// </summary>
       /// <param name="url">要获取网页的地址</param>
       /// <param name="RefererUrl">网页的refer</param>
       /// <param name="charSet">网页的字符编码，不知道是什么编码时输入空</param>
       /// <returns></returns>
       public static string getWebCodes(string Url, string RefererUrl = "http://www.baidu.com", string charSet = "GB2312")
       {
           string strHTML = "";
           try
           {
               WebClient myWebClient = new WebClient();
               myWebClient.Headers.Add(HttpRequestHeader.Referer, RefererUrl);
               Stream myStream = myWebClient.OpenRead(Url);
               StreamReader sr = new StreamReader(myStream, System.Text.Encoding.GetEncoding(charSet));
               strHTML = sr.ReadToEnd().ToString();
               myStream.Close();
               return strHTML;
           }
           catch
           {
               return strHTML;
           }
       }
       #endregion
    }
    public class Callback
    {
        public string client_id { get; set; }
        public string openid { get; set; }

    }
    public class QQUserInfo
    {
        public string openid { get; set; }
        public int ret { get; set; }
        public string msg { get; set; }
        public string nickname { get; set; }
        public string figureurl { get; set; }
        public string figureurl_1 { get; set; }
        public string figureurl_2 { get; set; }
        public string figureurl_qq_1 { get; set; }
        public string figureurl_qq_2 { get; set; }
        public string gender { get; set; }
        public int is_yellow_vip { get; set; }
        public int vip { get; set; }
        public int yellow_vip_level { get; set; }
        public int level { get; set; }
        public int is_yellow_year_vip { get; set; }
        
    }
}
