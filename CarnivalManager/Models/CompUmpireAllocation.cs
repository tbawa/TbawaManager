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
    
    public partial class CompUmpireAllocation
    {
        public int CompID { get; set; }
        public int TimeSlot { get; set; }
        public int Diamond { get; set; }
        public int PlateUmpireCompTeamID { get; set; }
        public Nullable<int> FirstBaseUmpireCompTeamID { get; set; }
        public Nullable<int> SecondBaseUmpireCompTeamID { get; set; }
    
        public virtual CompDiamond CompDiamond { get; set; }
        public virtual CompTimeSlot CompTimeSlot { get; set; }
    }
}