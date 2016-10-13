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
    /// TimeBucketRecord
    /// </summary>
    public partial class TimeBucketRecord
    {
        public TimeBucketRecord()
        {
            this.Salary = new HashSet<Salary>();
        }
    
        /// <summary>
        /// 
        /// </summary>
        public int RecordId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> EmployeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> RetailSalesId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TimeBucket { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> BaseWage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> FullAttendance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Deduction { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> PensionInsurance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> TaxRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> PersonalIncomeTax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Subsidies { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> SeniorityPay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> PostAllowance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> CommunicationAllowance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> TransportationAllowance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> MealSupplement { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> TravelAllowance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Other { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Performance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> DaikouShebao { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> DaikouYibao { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> DaikouGongshang { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> DaikouShengyu { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> DaikouShiye { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> DaikouGongjijin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> DaikouWuxian { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> DaikouQita { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> DaikouGeshui { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> JiaoWuxian { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> AccruedWages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> RealWages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> SalarySum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> TimeBucketRecordStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> StartDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> EndDate { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual RetailSales RetailSales { get; set; }
        public virtual ICollection<Salary> Salary { get; set; }
    }
}
