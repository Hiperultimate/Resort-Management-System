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
    using System.Collections.Generic;
    
    public partial class CustomerTran
    {
        public int BookingID { get; set; }
        public string CustomerName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string IdentityProof { get; set; }
        public long Contact { get; set; }
        public string Address { get; set; }
        public Nullable<int> HostEmployee { get; set; }
        public Nullable<int> RoomNumber { get; set; }
        public Nullable<int> LuxuryProvided { get; set; }
        public System.DateTime CheckInDate { get; set; }
        public System.DateTime CheckOutDate { get; set; }
        public int PaymentStatus { get; set; }
        public Nullable<long> TotalPayment { get; set; }
    
        public virtual AmenitiesMaster AmenitiesMaster { get; set; }
        public virtual EmployeeMaster EmployeeMaster { get; set; }
        public virtual RoomMaster RoomMaster { get; set; }
    }
}
