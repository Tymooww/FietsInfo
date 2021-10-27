namespace FietsInfo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRAININGSSCHEMA")]
    public partial class TRAININGSSCHEMA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRAININGSSCHEMA()
        {
            INGESCHREVENSCHEMA = new HashSet<INGESCHREVENSCHEMA>();
        }

        [Key]
        [StringLength(255)]
        public string Trainingsnaam { get; set; }

        [Required]
        [StringLength(255)]
        public string Omschrijving { get; set; }

        public int Urenmaandag { get; set; }

        public int Urendinsdag { get; set; }

        public int Urenwoensdag { get; set; }

        public int Urendonderdag { get; set; }

        public int Urenvrijdag { get; set; }

        public int Urenzaterdag { get; set; }

        public int Urenzondag { get; set; }

        public int trainingsniveau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INGESCHREVENSCHEMA> INGESCHREVENSCHEMA { get; set; }
    }
}
