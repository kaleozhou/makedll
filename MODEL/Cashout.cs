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
    /// Cashout
    /// </summary>
    public partial class Cashout
    {
        /// <summary>
        /// 
        /// </summary>
        public int CashoutId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> ApplyDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> ToAccountDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> TheWithdrawalDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Fee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StoreNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Applicant { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ToAccountType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CheckState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> CashoutStatus { get; set; }
    }
}
