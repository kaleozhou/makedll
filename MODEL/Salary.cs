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
    /// Salary
    /// </summary>
    public partial class Salary
    {
        /// <summary>
        /// 
        /// </summary>
        public int SalaryId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> EmployeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> GrantDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> GetDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> BaseWage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Attendance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> FullAttendence { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Seniority { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Bonus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> AccruedWages { get; set; }
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
        public Nullable<decimal> TaxableIncome { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> PersonalIncomeTax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> RealWages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> SalaryStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> ProbationSalary { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> TaxRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> QuickDeduction { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Subsidies { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> seniorityPay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> PostAllowance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> WorkingDay { get; set; }
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
        public Nullable<decimal> DaikouShebo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> DaikouYiBao { get; set; }
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
        public Nullable<decimal> Beiyong1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Beiyong2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Beiyong3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Beiyong4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Beiyong5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AccountNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BankOfDeposit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> RecordId { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual TimeBucketRecord TimeBucketRecord { get; set; }
    }
}
