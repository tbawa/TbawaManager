namespace ContactManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClubContactView")]
    public partial class ClubContactView
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string ClubName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string RoleName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Mobile { get; set; }
    }
}
