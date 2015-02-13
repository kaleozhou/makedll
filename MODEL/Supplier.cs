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
    /// Supplier
    /// </summary>
    public partial class Supplier
    {
        public Supplier()
        {
            this.Messages = new HashSet<Messages>();
            this.OnlineChat = new HashSet<OnlineChat>();
            this.Payment = new HashSet<Payment>();
            this.Refund = new HashSet<Refund>();
            this.SignContract = new HashSet<SignContract>();
            this.SupplierContact = new HashSet<SupplierContact>();
        }
    
        /// <summary>
        /// 
        /// </summary>
        public int SupplierId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SupplierNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> AccountBalance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> PaidAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> PlatformCommission { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SupplierProp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Contacts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BankAccount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerService { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Telphone1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Telphone2 { get; set; }
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
        public Nullable<bool> SupplierStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> SettlementCommission { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> PlatformLicensing { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> StartDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> EndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MainLineArea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string InArea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> AddDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Area1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Area2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Area3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> BlockedBalances { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StartPlace { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ObjectPlace { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProductType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BrandName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CheckForm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> SignContractId { get; set; }
    
        public virtual ICollection<Messages> Messages { get; set; }
        public virtual ICollection<OnlineChat> OnlineChat { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Refund> Refund { get; set; }
        public virtual ICollection<SignContract> SignContract { get; set; }
        public virtual ICollection<SupplierContact> SupplierContact { get; set; }
    }
}
