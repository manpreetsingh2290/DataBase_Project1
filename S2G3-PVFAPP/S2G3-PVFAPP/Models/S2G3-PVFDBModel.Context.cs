﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace S2G3_PVFAPP.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class S2G3_PVFDBEntities : DbContext
    {
        public S2G3_PVFDBEntities()
            : base("name=S2G3_PVFDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CUSTOMER> CUSTOMER { get; set; }
        public virtual DbSet<DOES_BUSINESS_IN> DOES_BUSINESS_IN { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEE { get; set; }
        public virtual DbSet<HAS_SKILL> HAS_SKILL { get; set; }
        public virtual DbSet<ORDER> ORDER { get; set; }
        public virtual DbSet<ORDER_LINE> ORDER_LINE { get; set; }
        public virtual DbSet<PRODUCED_IN> PRODUCED_IN { get; set; }
        public virtual DbSet<PRODUCT> PRODUCT { get; set; }
        public virtual DbSet<PRODUCT_LINE> PRODUCT_LINE { get; set; }
        public virtual DbSet<RAW_MATERIAL> RAW_MATERIAL { get; set; }
        public virtual DbSet<SALESPERSON> SALESPERSON { get; set; }
        public virtual DbSet<SKILL> SKILL { get; set; }
        public virtual DbSet<SUPPLIES> SUPPLIES { get; set; }
        public virtual DbSet<TERRITORY> TERRITORY { get; set; }
        public virtual DbSet<USES> USES { get; set; }
        public virtual DbSet<VENDER> VENDER { get; set; }
        public virtual DbSet<WORK_CENTER> WORK_CENTER { get; set; }
        public virtual DbSet<WORKS_IN> WORKS_IN { get; set; }
    }
}
