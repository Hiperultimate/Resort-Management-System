//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resort_Management_System.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Resort_Management_DBEntities : DbContext
    {
        public Resort_Management_DBEntities()
            : base("name=Resort_Management_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AmenitiesMaster> AmenitiesMasters { get; set; }
        public virtual DbSet<CustomerTran> CustomerTrans { get; set; }
        public virtual DbSet<EmployeeMaster> EmployeeMasters { get; set; }
        public virtual DbSet<FacilityAmenityTran> FacilityAmenityTrans { get; set; }
        public virtual DbSet<RolesMaster> RolesMasters { get; set; }
        public virtual DbSet<RoomMaster> RoomMasters { get; set; }
    }
}
