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

    public partial class EmployeeMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeeMaster()
        {
            this.CustomerTrans = new HashSet<CustomerTran>();
        }
    
        public int EmployeeID { get; set; }

        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Enter employee name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Email-ID")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Enter employee email")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter a password")]
        [MinLength(8, ErrorMessage = "Password should be 8 characters long")]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter a contact number")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Numbers only")]
        public long Contact { get; set; }

        [ForeignKey("RolesMaster")]
        public int RoleID { get; set; }

        [Required(ErrorMessage = "Enter Salary")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Numbers only")]
        public long Salary { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerTran> CustomerTrans { get; set; }
        public virtual RolesMaster RolesMaster { get; set; }
    }
}
