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
    /// EntryFlow
    /// </summary>
    public partial class EntryFlow
    {
        /// <summary>
        /// 
        /// </summary>
        public int EntryFlowId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RecruitingDepartment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> ApplicantsId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FirstDepartment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PreliminaryOpinions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SecondDepartment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReexaminationOpinions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GeneralManager { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Progress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> EntryFlowStatus { get; set; }
    
        public virtual Applicants Applicants { get; set; }
    }
}
