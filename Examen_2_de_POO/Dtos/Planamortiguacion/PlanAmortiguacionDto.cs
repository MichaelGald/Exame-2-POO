using Examen_2_de_POO.Databases.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examen_2_de_POO.Dtos.Planamortiguacion
{
    public class PlanAmortiguacionDto
    {
        [Key] 
        public int PlanamortizacionId { get; set; }

        [ForeignKey("Cliente")] 
        public Guid ClienteId { get; set; }

        public virtual ClienteEntity Cliente { get; set; }

        public int Numeroinstalacion { get; set; }

        public DateTime Fechapago { get; set; }

        public int Days { get; set; }

        public decimal Interes { get; set; }

        public decimal Principal { get; set; }

        public decimal PagoNivelSinSVSD { get; set; }

        public decimal PagoNivelSconSVSD { get; set; }

        public decimal Balanceprincipal { get; set; }
    }
}
