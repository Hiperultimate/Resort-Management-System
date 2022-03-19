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

    public partial class RoomMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoomMaster()
        {
            this.CustomerTrans = new HashSet<CustomerTran>();
        }
    
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }

        [Range(0, 1, ErrorMessage = "Wrong input: Enter 0 for False, 1 for True")]
        public int IsOccupied { get; set; }
        public Nullable<long> RoomCost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerTran> CustomerTrans { get; set; }
    }
}
