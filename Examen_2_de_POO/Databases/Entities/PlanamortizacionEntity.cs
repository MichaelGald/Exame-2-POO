﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_2_de_POO.Databases.Entities
{
    [Table("Planamortiguacion", Schema = "dbo")]
    public class PlanamortizacionEntity
    {
        [Key]
        [Column("PlanamortizacionId")]
        public int PlanamortizacionId { get; set; }

        [Required]
        [Column("ClienteId")]
        public Guid ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual ClienteEntity Cliente { get; set; }

        [Column("Numeroinstalacion")]
        public int Numeroinstalacion { get; set; }

        [Column("Fechapago")]
        public DateTime Fechapago { get; set; }

        [Column("Days")]
        public int Days { get; set; }

        [Column("Interes")]
        public decimal Interes { get; set; }

        [Column("Principal")]
        public decimal Principal { get; set; }

        [Column("PagoNivelSinSVSD")]
        public decimal PagoNivelSinSVSD { get; set; }

        [Column("PagoNivelSconSVSD")]
        public decimal PagoNivelSconSVSD { get; set; }

        [Column("Balanceprincipal")]
        public decimal Balanceprincipal { get; set; }
    }
}
