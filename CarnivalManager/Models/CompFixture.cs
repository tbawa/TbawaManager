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
    
    public partial class CompFixture
    {
        public int CompID { get; set; }
        public int TimeSlot { get; set; }
        public int Diamond { get; set; }
        public int Game { get; set; }
        public Nullable<int> HomeTeamID { get; set; }
        public Nullable<int> AwayTeamID { get; set; }
        public string HomeTeamMatchCode { get; set; }
        public string HomeTeamWinLoss { get; set; }
        public string AwayTeamMatchCode { get; set; }
        public string AwayTeamWinLoss { get; set; }
        public Nullable<int> HomeTeamRuns { get; set; }
        public Nullable<int> AwayTeamRuns { get; set; }
        public Nullable<int> PlateUmpireNo { get; set; }
        public Nullable<int> FirstBaseUmpireNo { get; set; }
        public Nullable<int> SecondBaseUmpireNo { get; set; }
    
        public virtual Comp Comp { get; set; }
        public virtual CompDiamond CompDiamond { get; set; }
        public virtual CompTeam CompTeam { get; set; }
        public virtual CompTeam CompTeam1 { get; set; }
        public virtual CompTimeSlot CompTimeSlot { get; set; }
    }
}
