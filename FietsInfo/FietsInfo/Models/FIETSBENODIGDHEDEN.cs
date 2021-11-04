namespace FietsInfo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FIETSBENODIGDHEDEN")]
    public partial class FIETSBENODIGDHEDEN
    {
        [Key]
        [StringLength(255)]
        public string Aspectnaam { get; set; }

        [Required]
        [StringLength(255)]
        public string Informatie { get; set; }

        [StringLength(255)]
        public string Gebruikersnaam { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }
    }
}
