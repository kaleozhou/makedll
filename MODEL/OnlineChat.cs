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
    /// OnlineChat
    /// </summary>
    public partial class OnlineChat
    {
        /// <summary>
        /// 
        /// </summary>
        public int OnlineChatId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> BusinessManId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> SupplierId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> PostDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ExchangeInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> OnlineChatStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> MessageType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> RefTravelProductId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> IsRead { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MessageTitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> SupplierContactId { get; set; }
    
        public virtual BusinessMan BusinessMan { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual SupplierContact SupplierContact { get; set; }
    }
}
