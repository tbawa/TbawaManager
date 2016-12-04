namespace ContactManager.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TbawaModel : DbContext
    {
        public TbawaModel()
            : base("name=TbawaDB")
        {
        }

        public virtual DbSet<Affiliation> Affiliations { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<ClubContact> ClubContacts { get; set; }
        public virtual DbSet<OfficeBearer> OfficeBearers { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<ClubContactView> ClubContactViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>()
                .Property(e => e.AddressLine1)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.AddressLine2)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.Locality)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.Postcode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Club1)
                .WithOptional(e => e.Club2)
                .HasForeignKey(e => e.MemberOf);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.ClubContacts)
                .WithRequired(e => e.Club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.AddressLine1)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.AddressLine2)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Locality)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Postcode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Affiliations)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.ClubContacts)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.OfficeBearers)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Affiliations)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.ClubId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.ClubContacts)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.OfficeBearers)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Season>()
                .Property(e => e.SeasonId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ClubContactView>()
                .Property(e => e.Mobile)
                .IsUnicode(false);
        }
    }
}
