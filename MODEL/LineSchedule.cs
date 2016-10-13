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
    /// LineSchedule
    /// </summary>
    public partial class LineSchedule
    {
        public LineSchedule()
        {
            this.Orders = new HashSet<Orders>();
        }
    
        /// <summary>
        /// 
        /// </summary>
        public int LineScheduleId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> GroupStageId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> VisitorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> Adult { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> Children { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> TravelDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> ScheduleDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> SeatLock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> LineScheduleStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> BusinessManId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> OccupationOverTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> OrderStatus { get; set; }
    
        public virtual BusinessMan BusinessMan { get; set; }
        public virtual GroupStage GroupStage { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
