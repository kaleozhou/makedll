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
    /// BalanceOfWater
    /// </summary>
    public partial class BalanceOfWater
    {
        /// <summary>
        /// 
        /// </summary>
        public int BalanceOfWaterId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> FinancialAccountsId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> BalanceDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Balance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BalanceNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DocumentNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Budget { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> BalanceOfWaterStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Revenue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Spending { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Approval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ForNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ForType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PayInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Banding { get; set; }
    
        public virtual FinancialAccounts FinancialAccounts { get; set; }
    }
}
