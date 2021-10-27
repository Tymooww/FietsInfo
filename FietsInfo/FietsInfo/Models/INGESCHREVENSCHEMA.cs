namespace FietsInfo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INGESCHREVENSCHEMA")]
    public partial class INGESCHREVENSCHEMA
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Trainingsnaam { get; set; }

        public bool? IsVoltooid { get; set; }

        public int? DagenVoltooid { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        public virtual TRAININGSSCHEMA TRAININGSSCHEMA { get; set; }
    }
}
