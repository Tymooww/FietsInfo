using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FietsInfo
{
    public partial class DatabaseModel : DbContext
    {
        public DatabaseModel()
            : base("name=DatabaseModel")
        {
        }

        public virtual DbSet<ACCOUNT> ACCOUNT { get; set; }
        public virtual DbSet<FIETSBENODIGDHEDEN> FIETSBENODIGDHEDEN { get; set; }
        public virtual DbSet<INGESCHREVENSCHEMA> INGESCHREVENSCHEMA { get; set; }
        public virtual DbSet<TRAININGSSCHEMA> TRAININGSSCHEMA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.Wachtwoord)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.Voornaam)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.Leeftijd)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.INGESCHREVENSCHEMA)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FIETSBENODIGDHEDEN>()
                .Property(e => e.Aspectnaam)
                .IsUnicode(false);

            modelBuilder.Entity<FIETSBENODIGDHEDEN>()
                .Property(e => e.Informatie)
                .IsUnicode(false);

            modelBuilder.Entity<INGESCHREVENSCHEMA>()
                .Property(e => e.Trainingsnaam)
                .IsUnicode(false);

            modelBuilder.Entity<TRAININGSSCHEMA>()
                .Property(e => e.Trainingsnaam)
                .IsUnicode(false);

            modelBuilder.Entity<TRAININGSSCHEMA>()
                .Property(e => e.Omschrijving)
                .IsUnicode(false);

            modelBuilder.Entity<TRAININGSSCHEMA>()
                .HasMany(e => e.INGESCHREVENSCHEMA)
                .WithRequired(e => e.TRAININGSSCHEMA)
                .WillCascadeOnDelete(false);
        }
    }
}
