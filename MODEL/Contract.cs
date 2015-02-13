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
    /// Contract
    /// </summary>
    public partial class Contract
    {
        /// <summary>
        /// 
        /// </summary>
        public int ContractId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> ReturnNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> ApplyNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> ApplyDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> YesNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StoreNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContractNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Claimant { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UseState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> ContractStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Condition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReturnContractNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> ContractApplicationId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> ContractReturnId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReturnRroof { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReturnRemark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<bool> ReturnIfLost { get; set; }
    
        public virtual ContractApplication ContractApplication { get; set; }
        public virtual ContractReturn ContractReturn { get; set; }
    }
}