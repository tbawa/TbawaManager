//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MemberManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CompDate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompDate()
        {
            this.CompTimeSlots = new HashSet<CompTimeSlot>();
        }
    
        public int CompID { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Comp Comp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompTimeSlot> CompTimeSlots { get; set; }
    }
}
