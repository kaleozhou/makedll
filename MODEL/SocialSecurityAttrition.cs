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
    /// SocialSecurityAttrition
    /// </summary>
    public partial class SocialSecurityAttrition
    {
        /// <summary>
        /// 
        /// </summary>
        public int SocialSecurityAttritionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> EmployeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> StopPayDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> EntryDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string InsuranceType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AttritionReason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> SocialSecurityAttritionStatus { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
