﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BlueVacationEntities : DbContext
    {
        public BlueVacationEntities()
            : base("name=BlueVacationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Ads> Ads { get; set; }
        public DbSet<Applicants> Applicants { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<AttendanceStatistics> AttendanceStatistics { get; set; }
        public DbSet<Audition> Audition { get; set; }
        public DbSet<BalanceOfWater> BalanceOfWater { get; set; }
        public DbSet<BookingInformation> BookingInformation { get; set; }
        public DbSet<BusinessMan> BusinessMan { get; set; }
        public DbSet<Cashout> Cashout { get; set; }
        public DbSet<CCArea> CCArea { get; set; }
        public DbSet<CommonContact> CommonContact { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<ContractApplication> ContractApplication { get; set; }
        public DbSet<ContractReturn> ContractReturn { get; set; }
        public DbSet<Debriefing> Debriefing { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EntryFlow> EntryFlow { get; set; }
        public DbSet<ExpressList> ExpressList { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<FileCenter> FileCenter { get; set; }
        public DbSet<FinancialAccounts> FinancialAccounts { get; set; }
        public DbSet<FixedAssets> FixedAssets { get; set; }
        public DbSet<GroupStage> GroupStage { get; set; }
        public DbSet<HeadOffice> HeadOffice { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<LanEmail> LanEmail { get; set; }
        public DbSet<Leader> Leader { get; set; }
        public DbSet<LeaveMessage> LeaveMessage { get; set; }
        public DbSet<LineItinerary> LineItinerary { get; set; }
        public DbSet<LineSchedule> LineSchedule { get; set; }
        public DbSet<LoginLog> LoginLog { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Notice> Notice { get; set; }
        public DbSet<OnlineChat> OnlineChat { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderToCommonContact> OrderToCommonContact { get; set; }
        public DbSet<OtherPayment> OtherPayment { get; set; }
        public DbSet<OtherSupply> OtherSupply { get; set; }
        public DbSet<Para> Para { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PayToSupplier> PayToSupplier { get; set; }
        public DbSet<PCArea> PCArea { get; set; }
        public DbSet<QueueInfo> QueueInfo { get; set; }
        public DbSet<Receivables> Receivables { get; set; }
        public DbSet<Recharge> Recharge { get; set; }
        public DbSet<RecruitmentApplication> RecruitmentApplication { get; set; }
        public DbSet<RecruitmentEmployee> RecruitmentEmployee { get; set; }
        public DbSet<Refund> Refund { get; set; }
        public DbSet<RefundWords> RefundWords { get; set; }
        public DbSet<ReminderFee> ReminderFee { get; set; }
        public DbSet<RetailSales> RetailSales { get; set; }
        public DbSet<Salary> Salary { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<SetEmployeeSalary> SetEmployeeSalary { get; set; }
        public DbSet<SignContract> SignContract { get; set; }
        public DbSet<SocialSecurity> SocialSecurity { get; set; }
        public DbSet<SocialSecurityAttrition> SocialSecurityAttrition { get; set; }
        public DbSet<SocialSecurityInto> SocialSecurityInto { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierContact> SupplierContact { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<TimeBucketRecord> TimeBucketRecord { get; set; }
        public DbSet<TransactionFlow> TransactionFlow { get; set; }
        public DbSet<Travel> Travel { get; set; }
        public DbSet<TravelAgency> TravelAgency { get; set; }
        public DbSet<TravelAgencyContact> TravelAgencyContact { get; set; }
        public DbSet<TravelFee> TravelFee { get; set; }
        public DbSet<TravelProduct> TravelProduct { get; set; }
        public DbSet<UseChapterFlow> UseChapterFlow { get; set; }
        public DbSet<Visa> Visa { get; set; }
        public DbSet<Visitor> Visitor { get; set; }
        public DbSet<VisitRecord> VisitRecord { get; set; }
        public DbSet<WorkLog> WorkLog { get; set; }
        public DbSet<WorkPlan> WorkPlan { get; set; }
    }
}
