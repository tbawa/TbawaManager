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
    
    public partial class CompClub
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompClub()
        {
            this.CompTeams = new HashSet<CompTeam>();
        }
    
        public int CompClubID { get; set; }
        public string Name { get; set; }
        public int CompID { get; set; }
        public int ClubID { get; set; }
        public string Grade { get; set; }
    
        public virtual Club Club { get; set; }
        public virtual Comp Comp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompTeam> CompTeams { get; set; }
    }
}
