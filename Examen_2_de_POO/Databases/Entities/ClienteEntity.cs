using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_2_de_POO.Databases.Entities
{
    [Table("clientes" , Schema ="dbo")]
    public class ClienteEntity
    {
        [StringLength(100)]
        [Column("name")]
        public string name { get; set; }

        [Key]
        [Required]
        [Column("identityNumber")]
        public virtual Guid IdCliente { get; set; }

        [Required]
        [Column("loanAmount")]
        public decimal montoprestamo { get; set; }

        [Required]
        [Column("commissionRate")]
        public decimal tasacomicion { get; set; }

        [Required]
        [Column("interestRate")]
        public decimal tasainteres { get; set; }

        [Column("term")]
        public string termino { get; set; }

        [Column("disbursementDate")]
        public string fecharembolso { get; set; }

        [Column("firstPaymentDate")]
        public string fechaprimerpago { get; set; }

        public virtual PlanamortizacionEntity PlanamortizacionEntity { get; set; }
    }
}
