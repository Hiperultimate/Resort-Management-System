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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CustomerTran
    {
        public int BookingID { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Enter Customer Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Enter Customer's Age")]
        public int Age { get; set; }

        [Display(Name = "Email-ID")]
        [Required(ErrorMessage = "Enter employee email")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Display(Name = "Identity Proof")]
        [Required(ErrorMessage = "Enter Identity Proof")]
        public string IdentityProof { get; set; }

        [Required(ErrorMessage = "Enter a contact number")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Numbers only")]
        public long Contact { get; set; }

        [Required]
        public string Address { get; set; }

        [ForeignKey("EmployeeMaster")]
        [Display(Name = "Host Employee")]
        public Nullable<int> HostEmployee { get; set; }

        [ForeignKey("RoomMaster")]
        [Display(Name = "Room Number")]
        public Nullable<int> RoomNumber { get; set; }

        [ForeignKey("AmenitiesMaster")]
        [Display(Name = "Luxury Provided")] // Does not works with foreign key for some reason
        public Nullable<int> LuxuryProvided { get; set; }

        [Display(Name = "Check-in-Date")]
        [Required(ErrorMessage = "Enter a check in date")]
        [DataType(DataType.DateTime)]
        public System.DateTime CheckInDate { get; set; }

        [Display(Name = "Check-out-Date")]
        [Required(ErrorMessage = "Enter a check out date")]
        [DataType(DataType.DateTime)]
        public System.DateTime CheckOutDate { get; set; }

        [Required]
        [Display(Name = "Payment Status")]
        [Range(0, 1, ErrorMessage = "Wrong input: Enter 0 for False, 1 for True")]
        public int PaymentStatus { get; set; }

        [Display(Name = "Total Payment")]
        public Nullable<long> TotalPayment { get; set; }
    
        public virtual AmenitiesMaster AmenitiesMaster { get; set; }
        public virtual EmployeeMaster EmployeeMaster { get; set; }
        public virtual RoomMaster RoomMaster { get; set; }
    }
}
