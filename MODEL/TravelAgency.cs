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
    /// TravelAgency
    /// </summary>
    public partial class TravelAgency
    {
        public TravelAgency()
        {
            this.Invoice = new HashSet<Invoice>();
            this.LeaveMessage = new HashSet<LeaveMessage>();
            this.TravelAgencyContact = new HashSet<TravelAgencyContact>();
            this.VisitRecord = new HashSet<VisitRecord>();
        }
    
        /// <summary>
        /// 
        /// </summary>
        public int TravelAgencyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> AreaId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BrandName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WebUrl { get; set; }
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
        public Nullable<bool> TravelAgencyStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ComapnyDescription { get; set; }
    
        public virtual Area Area { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<LeaveMessage> LeaveMessage { get; set; }
        public virtual ICollection<TravelAgencyContact> TravelAgencyContact { get; set; }
        public virtual ICollection<VisitRecord> VisitRecord { get; set; }
    }
}
