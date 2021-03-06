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

    public partial class FacilityAmenityTran
    {
        public int LuxuryID { get; set; }

        [Display(Name = "Luxury Name")]
        [Required(ErrorMessage = "Enter Luxury Name")]
        public string LuxuryName { get; set; }

        [Required]
        [Display(Name = "Amenity-ID")]
        [ForeignKey("AmenitiesMaster")]
        public int AmenityID { get; set; }

        [Required]
        [Display(Name = "Luxury Cost")]
        public Nullable<long> LuxuryCost { get; set; }
    
        public virtual AmenitiesMaster AmenitiesMaster { get; set; }
    }
}
