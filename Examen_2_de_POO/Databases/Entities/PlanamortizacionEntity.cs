using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_2_de_POO.Databases.Entities
{
    [Table("planamoritiguacion", Schema = "dbo")]
    public class PlanamortizacionEntity
    {
        [ForeignKey("idcliente")]
        public virtual Guid IdCliente { get; set; }
        public virtual ClienteEntity Clientes { get; set; }

        [Column("numeroinstalacion")]
        public int numeroinstacia { get; set; }

        [Column("paymentDate")]
        public string fechapago { get; set; }

        [Column("days")]
        public int day { get; set; }

        [Column("interest")]
        public decimal interes { get; set; }

        [Column("principal")]
        public decimal principal { get; set; }

        [Column("levelPaymentWithoutSVSD")]
        public decimal pagoSinSVSD { get; set; }

        [Column("levelPaymentWithSVSD")]
        public decimal pagoconSVSD { get; set; }
        
        [Column("principalBalance")]
        public decimal saldoprincipal { get; set; }


    }
}
