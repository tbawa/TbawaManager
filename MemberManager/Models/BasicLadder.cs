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
    
    public partial class BasicLadder
    {
        public int CompID { get; set; }
        public int CompTeamID { get; set; }
        public string Grade { get; set; }
        public string Division { get; set; }
        public string Name { get; set; }
        public Nullable<int> Points { get; set; }
        public Nullable<int> GamesPlayed { get; set; }
        public Nullable<int> GamesWon { get; set; }
        public Nullable<int> GamesLost { get; set; }
        public Nullable<int> GamesDrawn { get; set; }
        public Nullable<int> RunsFor { get; set; }
        public Nullable<int> RunsAgainst { get; set; }
        public Nullable<decimal> Percentage { get; set; }
    }
}