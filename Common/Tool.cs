using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;

namespace Common
{
    public static class Tool
    {
        public const string vbCrlf = "vbCrlf";
        public static string AppPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        public static string Theme = ReadAppSitting("Theme");
        #region MD5加密
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="Pwd">要加密的字符串</param>
        /// <param name="salt">区别符</param>
        /// <returns>返回加密后的MD5字符</returns>

        public static string Md5(string Pwd, string salt = "king")
        {
            string result = FormsAuthentication.HashPasswordForStoringInConfigFile(Pwd + salt, "MD5");
            return FormsAuthentication.HashPasswordForStoringInConfigFile(result, "MD5");
        }
        #endregion

        #region 制作随机字母和数字
        /// <summary>
        /// 制作随机字母和数字
        /// </summary>
        /// <param name="Length">得到的随机字符串长度</param>
        /// <param name="type">0为小写字母数字混合，1为纯数字，2为纯小字母,3为大小写混合</param>
        /// <returns></returns>
        public static string MakeRandomNumber(int Length, int type = 0)
        {
            char[] constant = {   
            '0','1','2','3','4','5','6','7','8','9',  
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'   
          };
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            int max = 36;
            int min = 0;
            switch (type)
            {
                case 1:
                    max = 10;
                    break;
                case 2:
                    min = 10;
                    break;
                case 3:
                    min = 10;
                    max = 62;
                    break;
            }

            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(min, max)]);
            }
            return newRandom.ToString();
        }
        #endregion

        #region 读取文本文件
        /// <summary>
        /// 读取文本文件
        /// </summary>
        /// <param name="txtPath">文件路径</param>
        /// <param name="code">文件编码，默认是"GB2312"</param>
        /// <returns></returns>
        public static string ReadTxt(string txtPath, string code = "GB2312")
        {
            string txt = "";
            try
            {
                txtPath = txtPath.Replace("/", "\\");
                if (File.Exists(txtPath) == true)
                {
                    FileStream fs = new FileStream(txtPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(code));
                    txt = sr.ReadToEnd();
                    sr.Close();
                    fs.Dispose();
                }
                return txt;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region 创建并写入txt文件

        /// <summary>
        /// 创建并写入txt文件
        /// </summary>
        /// <param name="txtPath">文件路径</param>
        /// 要写入的内容
        /// <param name="code">文件编码格式，默认为GB2312</param>
        /// <returns></returns>
        public static bool WriteTxt(string txtPath, string Constr, string code = "GB2312")
        {
            try
            {
                txtPath = txtPath.Replace("/", "\\");
                txtPath = txtPath.Replace("$split$", "|");
                if (GetBody(Constr, "<meta[^<]*charset=([^<]*)\"").ToLower() == "utf-8") code = "UTF-8";
                if (Directory.Exists(Path.GetDirectoryName(txtPath)) == false) Directory.CreateDirectory(Path.GetDirectoryName(txtPath));
                StreamWriter sw = new StreamWriter(txtPath, false, Encoding.GetEncoding(code));
                sw.Write(Constr);
                sw.Close();
                return true;
            }
            catch
            { return false; }
        }
        #endregion

        #region 获取文件大小
        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="txtPath">文件地址</param>
        /// <param name="_appPath">网站目录地址</param>
        /// <returns></returns>
        public static long GetFileSize(string txtPath, string _appPath = "")
        {
            try
            {
                if (string.IsNullOrEmpty(_appPath))
                {
                    _appPath = AppPath;
                }
                txtPath = _appPath + txtPath.Replace("/", "\\");
                if (File.Exists(txtPath) == true)
                {
                    FileStream fs = new FileStream(txtPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    long len = fs.Length;
                    fs.Dispose();
                    return len;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region 写入注册表
        /// <summary>
        /// 写入注册表
        /// </summary>
        /// <param name="para">注册表键名</param>
        /// <param name="paraVale">注册表键值</param>
        /// <param name="paraDir">注册表目录名</param>
        /// <returns></returns>
        public static bool WriteKey(string para, string paraVale, string paraDir = "northsnow")
        {
            try
            {
                Microsoft.Win32.RegistryKey Key1 = Microsoft.Win32.Registry.CurrentUser;
                Microsoft.Win32.RegistryKey Key2 = Key1.OpenSubKey(paraDir, true);
                if (Key2 == null)
                    Key2 = Key1.CreateSubKey(paraDir);              //如果键不存在就创建它 
                Key2.SetValue(para, paraVale);
                return true;
            }
            catch
            { return false; }
        }
        #endregion

        #region 读取指定注册表的键值
        /// <summary>
        /// 读取指定注册表的键值
        /// </summary>
        /// <param name="para">注册表键名</param>
        /// <param name="paraDir">注册表键名目录</param>
        /// <returns></returns>
        public static string ReadKey(string para, string paraDir = "northsnow")
        {
            try
            {
                Microsoft.Win32.RegistryKey Key1 = Microsoft.Win32.Registry.CurrentUser;
                Microsoft.Win32.RegistryKey Key2 = Key1.OpenSubKey(paraDir, true);
                if (Key2 == null)
                    return "";
                else
                    return Key2.GetValue(para).ToString();
            }
            catch
            { return ""; }
        }
        #endregion

        #region 获取单个汉字的首拼音
        /// <summary>   
        /// 获取单个汉字的首拼音   
        /// </summary>   
        /// <param name="myChar">需要转换的字符</param>   
        /// <returns>转换结果</returns>   
        private static string getSpell(string myChar)
        {
            byte[] arrCN = System.Text.Encoding.Default.GetBytes(myChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return System.Text.Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "_";
            }
            else return myChar.ToUpper();
        }
        #endregion

        #region 获取字符串中汉字的首或全拼音
        /// <summary>   
        /// 获取字符串中汉字的首或全拼音   
        /// </summary>   
        /// <param name="para">需要转换的汉字字符串</param>   
        /// <param name="spellType">只转换得到首字母参为true,全拼为false</param>   
        /// <returns>转换结果</returns>  
        public static string GetSpell(string para, bool spellType = true)
        {
            string Str = "";
            para = Regex.Replace(para, "　", "");
            para = Regex.Replace(para, " ", "");
            for (int i = 0; i < para.Length; i++)
            {
                if (spellType == true)
                    Str += getSpell(para[i].ToString());
                else
                    Str += NPinyin.Pinyin.GetPinyin(para[i]);
            }
            return Str;
        }
        #endregion

        #region 正则单个过滤替换
        /// <summary>
        /// 正则单个过滤替换
        /// </summary>
        /// <param name="para">要过滤或者要替换的源字段串</param>
        /// <param name="ruleString">过滤或者替换规则</param>
        /// <param name="replaceString">替换成的内容</param>
        /// <returns></returns>
        private static string myFilter(string para, string ruleString, string replaceString = "")
        {
            try
            {
                Regex rgx = new Regex(ruleString, RegexOptions.IgnoreCase);
                return rgx.Replace(para, replaceString);
            }
            catch
            {
                return para;
            }
        }
        #endregion

        #region 正则过滤替换
        /// <summary>
        /// 正则过滤替换
        /// </summary>
        /// <param name="para">要过滤或者要替换的源字段串</param>
        /// <param name="ruleString">过滤或者替换规则多个用vbCrlf分隔</param>
        /// <param name="replaceString">替换成的内容多个用vbCrlf分隔</param>
        /// <returns></returns>
        public static string MyFilter(string para, string ruleString, string replaceString = "")
        {

            string[] RuleArray = Regex.Split(ruleString, vbCrlf);
            string[] ReplaceArray = Regex.Split(replaceString, vbCrlf);

            for (int i = 0; i < RuleArray.Length; i++)
            {
                if (replaceString == "")
                    para = myFilter(para, RuleArray[i]);
                else
                {
                    string item = "";
                    if (i < ReplaceArray.Length)
                        item = ReplaceArray[i];
                    para = myFilter(para, RuleArray[i], item);
                }

            }
            return para;
        }
        #endregion

        #region 截取正则规则内容
        /// <summary>
        /// 截取正则规则内容
        /// </summary>
        /// <param name="para">要截取的源字符串</param>
        /// <param name="ruleString">正则规则</param>
        /// <param name="filterStr">过滤规则</param>
        /// <returns></returns>
        public static string GetBody(string para, string ruleString, string filterStr = null)
        {

            try
            {
                MatchCollection Mc = Regex.Matches(para, ruleString, RegexOptions.IgnoreCase);
                if (Mc.Count > 0)
                {
                    if (string.IsNullOrEmpty(filterStr))
                        return Mc[0].Groups[1].Value;
                    else
                        return MyFilter(Mc[0].Groups[1].Value, filterStr.Replace("\r\n", vbCrlf));
                }
                else
                    return "";
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region 按正则取内容返回数据为数组
        /// <summary>
        /// 按正则取内容返回数据为数组
        /// </summary>
        /// <param name="para">要取内容的源文件</param>
        /// <param name="ruleString">正则规则</param>
        /// <returns></returns>
        public static string[] GetArray(string para, string ruleString)
        {
            IList<string> Result = new List<string>();
            try
            {
                MatchCollection Mc = Regex.Matches(para, ruleString, RegexOptions.IgnoreCase);
                foreach (Match ma in Mc)
                {
                    Result.Add(ma.Groups[1].Value);

                }
                return Result.ToArray();
            }
            catch
            {
                return Result.ToArray();
            }

        }
        #endregion

        #region 正则获取多个值，近回值为二维的List型
        /// <summary>
        /// 正则获取多个值，近回值为二维的List型
        /// </summary>
        /// <param name="para">要取内容的源文件</param>
        /// <param name="ruleString">正则规则</param>
        /// <returns></returns>
        public static List<List<string>> GetMultiArray(string para, string ruleString)
        {
            List<List<string>> Result = new List<List<string>>();

            try
            {
                MatchCollection Mc = Regex.Matches(para, ruleString, RegexOptions.IgnoreCase);
                foreach (Match Ma in Mc)
                {
                    List<string> RowList = new List<string>();
                    for (int i = 1; i < Ma.Groups.Count; i++)
                    {
                        RowList.Add(Ma.Groups[i].Value);
                    }
                    Result.Add(RowList);
                }
                return Result;
            }
            catch
            {
                return Result;
            }

        }
        #endregion

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

        public static string FromChinaz(string url)
        {
            string ChinazUrl = "http://tool.chinaz.com/Tools/PageCode.aspx?q=" + url.Replace("http://", "");
            string WebCodes = getWebCodes(ChinazUrl, "http://tool.chinaz.com/Tools/PageCode.aspx", "utf-8");
            WebCodes = GetBody(WebCodes, "<textarea name=\"code\" id=\"htmltext\" class=\"xml\" style=\"width:95%;height:500px;\">((.|\\n)+?)</textarea>");
            WebCodes = HttpUtility.HtmlDecode(WebCodes);
            return WebCodes;
        }
        

        #region 取指定文件的后缀名
        /// <summary>
        /// 取指定文件的后缀名
        /// </summary>
        /// <param name="PicName">文件名或文件路径</param>
        /// <returns></returns>
        public static string GetPicType(string PicName)
        {
            return Path.GetExtension(PicName);
        }
        #endregion

        #region 取指定地址的域名，返回结果中在域名前加了http://
        /// <summary>
        /// 取指定地址的域名，返回结果中在域名前加了http://
        /// </summary>
        /// <param name="Url">指定的地址</param>
        /// <returns></returns>
        public static string GetDomain(string Url)
        {
            try
            {
                Uri MyUrl = new Uri(Url);
                return "http://" + MyUrl.Host;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region 复制文件夹（及文件夹下所有子文件夹和文件）
        /// <summary>
        /// 复制文件夹（及文件夹下所有子文件夹和文件）
        /// </summary>
        /// <param name="sourcePath">待复制的文件夹路径</param>
        /// <param name="destinationPath">目标路径</param>
        public static void CopyDirectory(String sourcePath, String destinationPath)
        {
            DirectoryInfo info = new DirectoryInfo(sourcePath);
            Directory.CreateDirectory(destinationPath);
            foreach (FileSystemInfo fsi in info.GetFileSystemInfos())
            {
                String destName = Path.Combine(destinationPath, fsi.Name);

                if (fsi is System.IO.FileInfo)          //如果是文件，复制文件
                    File.Copy(fsi.FullName, destName, true);
                else                                    //如果是文件夹，新建文件夹，递归
                {
                    Directory.CreateDirectory(destName);
                    CopyDirectory(fsi.FullName, destName);
                }
            }
        }
        #endregion

        #region 删除文件夹（及文件夹下所有子文件夹和文件）
        /// <summary>
        /// 删除文件夹（及文件夹下所有子文件夹和文件）
        /// </summary>
        /// <param name="directoryPath"></param>
        public static void DeleteFolder(string directoryPath)
        {
            foreach (string d in Directory.GetFileSystemEntries(directoryPath))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d);     //删除文件  
                }
                else
                    DeleteFolder(d);    //删除文件夹
            }
            Directory.Delete(directoryPath);    //删除空文件夹
        }
        #endregion

        #region 把内容替换为纯文本
        /// <summary>
        /// 把内容替换为纯文本
        /// </summary>
        /// <param name="para">要处理的字符串</param>
        /// <returns></returns>
        public static string FilterTxtContent(string para)
        {
            if (para == "")
                return "";
            para = MyFilter(para, @"&nbsp;" + vbCrlf + "'" + vbCrlf + "\r\n" + vbCrlf + "<.+?>" + vbCrlf + @"\s*", " " + vbCrlf + "’");
            return para;
        }
        #endregion

        #region 下载文件
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="LocalFileName">本地保存地址</param>
        /// <param name="RemoteFileUrl">远程url地址</param>
        /// <param name="Referer">referer地址</param>
        /// <returns></returns>
        public static bool SaveRemoteFile(string LocalFileName, string RemoteFileUrl, string Referer)
        {
            try
            {
                //Dim Ads, GetRemoteData
                LocalFileName = LocalFileName.Replace("/", @"\");
                RemoteFileUrl = RemoteFileUrl.Replace(@"\", "/");
                Directory.CreateDirectory(Path.GetDirectoryName(LocalFileName));
                WinHttp.WinHttpRequest retrieval = new WinHttp.WinHttpRequest();
                retrieval.Open("GET", RemoteFileUrl);
                retrieval.SetRequestHeader("Referer", Referer);
                retrieval.Send();
                object GetRemoteData = retrieval.ResponseBody;
                retrieval = null;
                ADODB.Stream Ads = new ADODB.Stream();
                Ads.Type = ADODB.StreamTypeEnum.adTypeBinary;
                Ads.Open();
                Ads.Write(GetRemoteData);
                Ads.SaveToFile(LocalFileName, ADODB.SaveOptionsEnum.adSaveCreateOverWrite);
                Ads.Cancel();
                Ads.Close();
                Ads = null;

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 将相对地址转换为绝对地址
        /// <summary>
        /// 将相对地址转换为绝对地址
        /// </summary>
        /// <param name="PrimitiveUrl">要转换的相对地址</param>
        /// <param name="ConsultUrl">当前网页地址</param>
        /// <returns></returns>
        public static string DefiniteUrl(string PrimitiveUrl, string ConsultUrl)
        {
            try
            {
                Uri baseUri = new Uri(ConsultUrl);
                Uri myUri = new Uri(baseUri, PrimitiveUrl);
                return myUri.AbsoluteUri;
            }
            catch
            { return ""; }
        }
        #endregion

        #region 自动本地化图片
        /// <summary>
        /// 自动本地化图片
        /// </summary>
        /// <param name="ConStr">要本地化的内容</param>
        /// <param name="TistUrl">当前网页地址</param>
        /// <param name="FistPic">返回本地化图片的第一张图片</param>
        /// <param name="LocalPath">本地化保存的目录</param>
        /// <returns></returns>
        public static string ReplaceSaveRemoteFile(string ConStr, string TistUrl, ref string FistPic, string LocalPath = "", bool ZipPic = false, bool remote = false)
        {
            try
            {
                string TempStr = "";
                ConStr = FilterDomain(ConStr, TistUrl);
                string[] TempstrArray = GetArray(ConStr, @"(<img.+?[^\>]>)");
                string[] ImgArray = GetArray(ConStr, @"(<img.+?[^\>]>)");
                if (TempstrArray.Length == 0)
                    return ConStr;
                foreach (string item in TempstrArray)
                {
                    if (TempStr == "")
                        TempStr = GetBody(item, @"src\s*=\s*(.+?\.(gif|jpg|bmp|jpeg|psd|png|svg|dxf|wmf|tiff))");
                    else
                        TempStr = TempStr + "|" + GetBody(item, @"src\s*=\s*(.+?\.(gif|jpg|bmp|jpeg|psd|png|svg|dxf|wmf|tiff))");
                }
                TempStr = MyFilter(TempStr, "\"" + vbCrlf + "'");
                TempstrArray = TempStr.Split('|');
                TempStr = "";
                //过滤同一张图片
                foreach (string item in TempstrArray)
                {
                    if (TempStr.Contains(item + "|") == false)
                    {
                        if (TempStr == "")
                            TempStr = item + "|";
                        else
                            TempStr = TempStr + item + "|";
                    }

                }

                TempstrArray = TempStr.Split('|');
                TempStr = "";
                foreach (string item in TempstrArray)
                {
                    if (remote && item.Contains("http://") == false)
                    {
                        continue;
                    }
                    string ImgUrl = DefiniteUrl(item, TistUrl);
                    string TempImg = item;
                    if (TempImg == "") continue;
                    string NewImgPath = "";
                    if (LocalPath != "")
                    {
                        string DateStr = DateTime.Now.ToString("yyyyMMdd");
                        if (LocalPath.Contains("\\Images") == true)
                        {
                            string ImgName = "";
                            if (TempImg.LastIndexOf("/") > 0)
                                ImgName = TempImg.Substring(TempImg.LastIndexOf("/") + 1);
                            else
                                ImgName = TempImg;
                            NewImgPath = "/Images/" + ImgName;
                            LocalPath = LocalPath.Replace(@"\Images\", "");
                        }

                        else
                            NewImgPath = "/upload/" + DateStr + "/" + MakeRandomNumber(8) + GetPicType(TempImg);
                        SaveRemoteFile(LocalPath + NewImgPath.Replace("/", "\\"), ImgUrl, TistUrl);
                        if (ZipPic)
                        {
                            NewImgPath.ZipPic(LocalPath);
                        }

                    }
                    else
                    {
                        NewImgPath = ImgUrl;
                    }
                    //ConStr = ConStr.Replace(TempImg, NewImgPath);
                    foreach (var img in ImgArray)
                    {
                        if (img.Contains(TempImg))
                        {
                            ConStr = ConStr.Replace(img, "<img src=\"" + NewImgPath + "\"/>");
                        }
                    }
                    if (FistPic == "")
                        FistPic = NewImgPath;
                }
            }
            catch (Exception ex)
            {
                WriteTxt(LocalPath + "error.txt", ex.Message);
            }
            return ConStr;

        }

        #endregion



        #region 过滤域名
        /// <summary>
        /// 过滤域名
        /// </summary>
        /// <param name="ConStr">要过滤的内容</param>
        /// <param name="Url">过滤的地址</param>
        /// <returns></returns>
        private static string FilterDomain(string ConStr, string Url)
        {
            try
            {
                Uri MyUri = new Uri(Url);
                string Domain = MyUri.Host;
                ConStr = MyFilter(ConStr, "http://" + Domain + vbCrlf + Domain);
                return ConStr;
            }
            catch
            {
                return ConStr;
            }

        }
        #endregion

        #region 删除指定文件
        /// <summary>
        /// 删除指定文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>成功返回True,失败返回False</returns>
        public static bool DelFile(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (file.Exists == true)
                {
                    File.Delete(filePath);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 自动截取网页内容
        /// <summary>
        /// 自动截取网页内容
        /// </summary>
        /// <param name="WebCodes">源字符串</param>
        /// <param name="FontNum">获取的字符数量</param>
        /// <returns>返回字符串</returns>
        public static string GetAutoContent(string WebCodes, int FontNum = 200)
        {
            string Content = "";
            Content = MyFilter(WebCodes, "\r\n" + vbCrlf + "  " + vbCrlf + @"ICP备\d*" + vbCrlf + "<a.+?</a>");
            string[] DivArray = Regex.Split(Content, "</div>");
            string[] DivArray1 = Regex.Split(Content, "</td>");
            string[] DivResult;
            if (DivArray1.Length > DivArray.Length)
                DivResult = DivArray1;
            else
                DivResult = DivArray;

            Content = "";
            foreach (string divContent in DivResult)
            {
                string DivContent = MyFilter(divContent, @"<script.+?>(.|\n)+?</script>" + vbCrlf + @"<script.+?>.+?</script>" + vbCrlf + @"[^\u4e00-\u9fa5]");
                if (DivContent.Length == 0) continue;
                if (DivContent.Length > FontNum)
                {
                    Content = MyFilter(divContent, "<img" + vbCrlf + "</p>" + vbCrlf + "<br>" + vbCrlf + "<br />" + vbCrlf + "<p.+?>" + vbCrlf + "<p>" + vbCrlf + "<[^>]+>", "mylabimg" + vbCrlf + "mylabp" + vbCrlf + "mylabbr" + vbCrlf + "mylabbr");
                }
                Content = MyFilter(Content, "mylabp" + vbCrlf + "mylabbr" + vbCrlf + "mylabimg", "<BR />" + vbCrlf + "<BR />" + vbCrlf + "<img");
            }
            return Content;
        }
        #endregion

        #region 时间戳转为C#格式时间
        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name=”timeStamp”></param>
        /// <returns></returns>
        public static DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime); return dtStart.Add(toNow);
        }
        #endregion

        #region DateTime时间格式转换为Unix时间戳格式
        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name=”time”></param>
        /// <returns></returns>
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        #endregion

        #region 创建文件夹
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="DirPath">文件夹路径</param>
        public static bool CreateFolder(string DirPath)
        {
            try
            {
                if (Directory.Exists(Path.GetDirectoryName(DirPath)) == false)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(DirPath));
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 读取web.config APPSiteting的值
        /// <summary>
        /// 读取web.config APPSiteting的值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ReadAppSitting(string name)
        {
            try
            {
                return WebConfigurationManager.AppSettings[name];
            }
            catch (Exception)
            {

                return "";
            }
        }
        #endregion

        #region 修改添加web.config APPSiteting的值
        /// <summary>
        /// 修改添加web.config APPSiteting的值
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="value">键值</param>
        public static bool ModifyAppSetings(string key, string value)
        {
            try
            {
                Configuration configuration = WebConfigurationManager.OpenWebConfiguration("~");
                AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");
                if (appSettingsSection != null)
                {
                    if (appSettingsSection.Settings[key] != null)
                        appSettingsSection.Settings[key].Value = value;
                    else
                    {
                        appSettingsSection.Settings.Add(key, value);
                    }
                    configuration.Save();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion

        #region 获取Bootstrap分页
        /// <summary>
        /// 获取Bootstrap分页
        /// </summary>
        /// <param name="RsCount">总记录数</param>
        /// <param name="PageSize">分页大小</param>
        /// <param name="CurrentPage">当前页</param>
        /// <param name="PageUrl">当前地址</param>
        /// <returns></returns>
        public static string GetPageStr(int RsCount, int PageSize, int CurrentPage, string PageUrl)
        {
            string PageStr = "";
            if (RsCount > 0)
            {

                int PageCount = (int)System.Math.Ceiling((double)RsCount / PageSize);
                int k = CurrentPage;
                int m = 1, n = 10;
                if (k <= 5)
                {
                    if (PageCount <= 10)
                        n = PageCount;
                    else
                        n = 10;
                }
                else
                {
                    m = k - 5;
                    n = k + 5;
                    if (n > PageCount)
                    {
                        n = PageCount;
                        m = n - 10;
                        if (m < 1) m = 1;
                    }
                }
                string SubPageUrl = PageUrl + "/";

                PageStr = PageStr + "<li><a href=\"" + PageUrl + "\">首页</a></li>";
                string LastPage = "";
                if (CurrentPage == 1)
                    LastPage = "<li class=\"disabled\"><a href=\"#\">&laquo;</a></li>";
                else
                    LastPage = "<li><a href=\"" + SubPageUrl + (CurrentPage - 1) + "\">&laquo;</a></li>";
                PageStr = PageStr + LastPage;
                for (int t = m; t <= n; t++)
                {
                    if (t == CurrentPage)
                        PageStr = PageStr + "<li class=\"active\"><a href=\"#\">" + t + "<span class=\"sr-only\">(current)</span></a></li>";
                    else
                        PageStr = PageStr + "<li><a href=\"" + SubPageUrl + t + "\">" + t + "</a></li>";

                }
                string NextPage = "";
                if (CurrentPage == PageCount)
                    NextPage = "<li class=\"disabled\"><a href=\"#\">&raquo;</a></li>";
                else
                    NextPage = "<li><a href=\"" + SubPageUrl + (CurrentPage + 1) + "\">&raquo;</a></li>";
                PageStr = PageStr + NextPage + "<li><a href=\"" + SubPageUrl + PageCount + "\">尾页</a></li>";

            }
            return PageStr;
        }
        #endregion

        #region 获取Metro分页

        public static string GetMetroPageStr(int RsCount, int PageSize, int CurrentPage, string PageUrl)
        {
            string PreFix = GetPicType(PageUrl);
            string split = "_";
            if (!string.IsNullOrEmpty(PreFix))
            {
                PageUrl = PageUrl.Replace(PreFix, "");
            }
            else
            {
                split = "/";
            }
            int PageCount = (int)System.Math.Ceiling((double)RsCount / PageSize);
            int k = CurrentPage;
            int m = 1, n = 10;
            if (k <= 5)
            {
                if (PageCount <= 10)
                    n = PageCount;
                else
                    n = 10;
            }
            else
            {
                m = k - 5;
                n = k + 5;
                if (n > PageCount)
                {
                    n = PageCount;
                    m = n - 10;
                    if (m < 1) m = 1;
                }
            }
            string SubPageUrl = PageUrl;
            string PageStr = "";
            PageStr = PageStr + "<li class=\"first\"><a href=\"" + PageUrl + PreFix + "\"><i class=\"icon-first-2\"></i></a></li>";
            string LastPage = "";
            if (CurrentPage == 1)
                LastPage = "<li class=\"prev disabled\"><a><i class=\"icon-previous\"></i></a></li>";
            else
                LastPage = "<li class=\"prev\"><a href=\"" + SubPageUrl + split + (CurrentPage - 1) + PreFix + "\"><i class=\"icon-previous\"></i></a></li>";
            PageStr = PageStr + LastPage;
            for (int t = m; t <= n; t++)
            {
                if (t == CurrentPage)
                    PageStr = PageStr + "<li class=\"active\"><a href=\"#\"><i>" + t + "</i></a></li>";
                else
                {
                    if (t == 1)
                    {
                        PageStr = PageStr + "<li><a href=\"" + SubPageUrl + PreFix + "\"><i>" + t + "</i></a></li>";
                    }
                    else
                    {
                        PageStr = PageStr + "<li><a href=\"" + SubPageUrl + split + t + PreFix + "\"><i>" + t + "</i></a></li>";
                    }

                }

            }
            string NextPage = "";
            if (CurrentPage == PageCount)
                NextPage = "<li class=\"next disabled\"><a><i class=\"icon-next\"></i></a></li>";
            else
                NextPage = "<li class=\"next\"><a href=\"" + SubPageUrl + split + (CurrentPage + 1) + PreFix + "\"><i class=\"icon-next\"></i></a></li>";
            PageStr = PageStr + NextPage + "<li class=\"last\"><a href=\"" + SubPageUrl + split + PageCount + PreFix + "\"><i class=\"icon-last-2\"></i></a></li>";
            return PageStr;
        }
        #endregion

        #region 产生指定范围的随机数
        /// <summary>
        /// 产生指定范围的随机数
        /// </summary>
        /// <param name="low">最小数</param>
        /// <param name="uper">最大数</param>
        /// <param name="k">参数</param>
        /// <returns></returns>
        public static int MakeRnd(int low, int uper, int k = 10)
        {
            Random rd = new Random(k);
            return rd.Next(low, uper);
        }
        #endregion

        public static List<string> GetFiles(string path)
        {
            List<string> dir = Directory.GetDirectories(path).ToList();
            List<string> files = Directory.GetFiles(path).ToList();
            List<string> fileNames = new List<string>();
            foreach (string file in files) { fileNames.Add(Path.GetFileName(file)); }
            foreach (string item in dir)
            {
                List<string> subFileNames = GetFiles(item);
                fileNames.AddRange(subFileNames);
            }
            return fileNames;
        }

    }

}
