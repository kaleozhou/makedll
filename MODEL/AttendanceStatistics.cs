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
    /// AttendanceStatistics
    /// </summary>
    public partial class AttendanceStatistics
    {
        /// <summary>
        /// 
        /// </summary>
        public int AttendanceStatisticsId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string YearMonth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Late { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> CasualLeave { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> SickLeave { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> SpecialLeave { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Absent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AttendanceStatisticsStatus { get; set; }
    }
}
