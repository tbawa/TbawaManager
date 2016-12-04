namespace ContactManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Affiliation")]
    public partial class Affiliation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClubId { get; set; }

        public int PersonId { get; set; }

        [Column(TypeName = "date")]
        public DateTime AffiliationDate { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public int? NumberOfTeams { get; set; }

        public int? NumberOfPlayers { get; set; }

        public int? NumberOfVolunteers { get; set; }

        public virtual Role Role { get; set; }

        public virtual Person Person { get; set; }
    }
}
