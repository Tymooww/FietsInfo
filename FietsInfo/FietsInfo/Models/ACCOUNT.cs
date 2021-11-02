namespace FietsInfo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACCOUNT")]
    public partial class ACCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACCOUNT()
        {
            FIETSBENODIGDHEDEN = new HashSet<FIETSBENODIGDHEDEN>();
            INGESCHREVENSCHEMA = new HashSet<INGESCHREVENSCHEMA>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Required]
        [StringLength(255)]
        public string Gebruikersnaam { get; set; }

        [Required]
        [StringLength(255)]
        public string Wachtwoord { get; set; }

        [Required]
        [StringLength(255)]
        public string Voornaam { get; set; }

        [StringLength(255)]
        public string Leeftijd { get; set; }

        public bool IsAdmin { get; set; }

        public int Binnenbeenlengte { get; set; }

        public double Maatberekenen()
        {
            double Fietsmaat = Binnenbeenlengte * 0.68;
            return Fietsmaat;
        }

        public int? Gewicht { get; set; }

        public int? Lengte { get; set; }

        public int Niveau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FIETSBENODIGDHEDEN> FIETSBENODIGDHEDEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INGESCHREVENSCHEMA> INGESCHREVENSCHEMA { get; set; }
    }
}
