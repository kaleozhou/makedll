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
    /// Employee
    /// </summary>
    public partial class Employee
    {
        public Employee()
        {
            this.Salary = new HashSet<Salary>();
            this.SetEmployeeSalary = new HashSet<SetEmployeeSalary>();
            this.SocialSecurity1 = new HashSet<SocialSecurity>();
            this.SocialSecurityAttrition = new HashSet<SocialSecurityAttrition>();
            this.TimeBucketRecord = new HashSet<TimeBucketRecord>();
        }
    
        /// <summary>
        /// 
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> StaffBirthday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StaffNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IdNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Nation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MaritalStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Mark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Telphone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CulturalDegree { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AccountProp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> EmployeeStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string County { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WorkExperience { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EducationExperience { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SocialSecurity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BankOfDeposit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AccountNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> DepartmentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EmergencyContact { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EmergencyPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IdNumberPhoto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> EmploymentDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> TerminationDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> LeaveDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> AuditStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> EntryAuditDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> LeaveAuditDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DepartMent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> RetailSalesId { get; set; }
    
        public virtual RetailSales RetailSales { get; set; }
        public virtual ICollection<Salary> Salary { get; set; }
        public virtual ICollection<SetEmployeeSalary> SetEmployeeSalary { get; set; }
        public virtual ICollection<SocialSecurity> SocialSecurity1 { get; set; }
        public virtual ICollection<SocialSecurityAttrition> SocialSecurityAttrition { get; set; }
        public virtual ICollection<TimeBucketRecord> TimeBucketRecord { get; set; }
    }
}
