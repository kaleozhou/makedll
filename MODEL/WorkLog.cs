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
    /// WorkLog
    /// </summary>
    public partial class WorkLog
    {
        /// <summary>
        /// 
        /// </summary>
        public int WorkLogId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> RecordDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LogType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LogContent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> LogStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ShareTo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> WorkLogStatus { get; set; }
    }
}
