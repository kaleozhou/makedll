//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MODEL
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// TravelAgencyContact
    /// </summary>
    public partial class TravelAgencyContact
    {
        /// <summary>
        /// 
        /// </summary>
        public int TravelAgencyContactId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> TravelAgencyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Telephone1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Telephone2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeiXinNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Skype { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LoginPwd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PayPassword { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> TravelAgencyContactStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MsgAuthCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> MsgAuthCodeSendDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HeadImage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Gender { get; set; }
    
        public virtual TravelAgency TravelAgency { get; set; }
    }
}
