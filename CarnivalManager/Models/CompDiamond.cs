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
    
    public partial class CompDiamond
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompDiamond()
        {
            this.CompFixtures = new HashSet<CompFixture>();
            this.CompUmpireAllocations = new HashSet<CompUmpireAllocation>();
        }
    
        public int CompID { get; set; }
        public int Diamond { get; set; }
        public string Name { get; set; }
    
        public virtual Comp Comp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompFixture> CompFixtures { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompUmpireAllocation> CompUmpireAllocations { get; set; }
    }
}
