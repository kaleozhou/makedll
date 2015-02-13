using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace BLL
{
    public partial class Visitor
    {
       public LoginState Login(string _username,string _pwd)
       {
           MODEL.Visitor model = GetSingleModelBy(s => s.UserName == _username && s.VisitorStatus == true);
           if(model==null)
           {
               return LoginState.NoName;
           }
           else
           {
               if (Tool.Md5(_pwd, model.UserName) == model.Pwd)
               {
                   CookieHelper.SetCookie("VisitorId", model.VisitorId.ToString(),1800);
                   return LoginState.OK;
               }
               else
               {
                   return LoginState.PwdErr;
               }
           }
       }
        public MODEL.Visitor GetLoginInfo()
       {
           int _userID = CookieHelper.GetCookieValue("VisitorId").ToInt();
           MODEL.Visitor model = GetSingleModelBy(s => s.VisitorId == _userID);
           return model;
       }
       
    }
    public partial class BusinessMan
    {
        public LoginState Login(string _username, string _pwd)
        {
            MODEL.BusinessMan model = GetSingleModelBy(s => s.UserName == _username && s.BusinessManStatus == true);
            if (model == null)
            {
                return LoginState.NoName;
            }
            else
            {
                if (Tool.Md5(_pwd, model.UserName) == model.Pwd)
                {
                    CookieHelper.SetCookie("BusinessManId", model.BusinessManId.ToString(),1800);
                    return LoginState.OK;
                }
                else
                {
                    return LoginState.PwdErr;
                }
            }
        }
        public MODEL.BusinessMan GetLoginInfo()
        {
            int _userID = CookieHelper.GetCookieValue("BusinessManId").ToInt();
            MODEL.BusinessMan model = GetSingleModelBy(s => s.BusinessManId == _userID);
            return model;
        }
        
    }
    public partial class SupplierContact
    {
        public LoginState Login(string _username, string _pwd)
        {
            MODEL.SupplierContact model = GetSingleModelBy(s => s.LoginName == _username && s.IsUse == true);
            if (model == null)
            {
                return LoginState.NoName;
            }
            else
            {
                if (Tool.Md5(_pwd, model.LoginName) == model.Password)
                {
                    CookieHelper.SetCookie("SupplierContactID", model.SupplierContactId.ToString(),1800);
                    return LoginState.OK;
                }
                else
                {
                    return LoginState.PwdErr;
                }
            }
        }
        public MODEL.SupplierContact GetLoginInfo()
        {
            int _userID = CookieHelper.GetCookieValue("SupplierContactID").ToInt();
            MODEL.SupplierContact model = GetSingleModelBy(s => s.SupplierContactId == _userID);
            return model;
        }
        
    }
}
