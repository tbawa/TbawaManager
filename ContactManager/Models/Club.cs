namespace ContactManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Club")]
    public partial class Club
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Club()
        {
            Club1 = new HashSet<Club>();
            ClubContacts = new HashSet<ClubContact>();
        }

        public int ClubId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string LegalName { get; set; }

        [Required]
        [StringLength(50)]
        public string ShortName { get; set; }

        [StringLength(100)]
        public string WebsiteURL { get; set; }

        [StringLength(100)]
        public string FacebookURL { get; set; }

        public bool MemberClub { get; set; }

        public bool CountryClub { get; set; }

        public int? MemberOf { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string AddressLine1 { get; set; }

        [StringLength(200)]
        public string AddressLine2 { get; set; }

        [StringLength(200)]
        public string Locality { get; set; }

        [StringLength(4)]
        public string Postcode { get; set; }

        [StringLength(3)]
        public string State { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Club> Club1 { get; set; }

        public virtual Club Club2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClubContact> ClubContacts { get; set; }
    }
}
