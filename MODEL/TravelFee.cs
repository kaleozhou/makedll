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
    /// TravelFee
    /// </summary>
    public partial class TravelFee
    {
        /// <summary>
        /// 
        /// </summary>
        public int FeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> TravelProductId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FeeItem { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string logo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> IsContains { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TemplateName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> Sort { get; set; }
    
        public virtual TravelProduct TravelProduct { get; set; }
    }
}