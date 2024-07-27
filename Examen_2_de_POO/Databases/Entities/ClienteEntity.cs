using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_2_de_POO.Databases.Entities
{
    [Table("clientes", Schema = "dbo")]
    public class ClienteEntity
    {
        [Key]
        [Required]
        [Column("IdCliente")]
        public Guid IdCliente { get; set; }

        [StringLength(100)]
        [Column("Name")]
        public string Name { get; set; }
        // Se elimino identityNumber porque me generaba conflitos y se me hizo mas facil con id

        [Required]
        [Column("Montoprestamo")]
        public decimal Montoprestamo { get; set; }

        [Required] 
        [Column("Tasacomision")] //Puede que si o no, si lo toma pero a aveces no, le da ansiedad 
                                
        public decimal Tasacomision { get; set; }

        [Required]
        [Column("Tasainteres")]
        public decimal Tasainteres { get; set; }

        [Required]
        [Column("Termino")]
        public int Termino { get; set; }

        [Required]
        [Column("Fechadesembolso")]
        public DateTime Fechadesembolso { get; set; }

        [Required]
        [Column("Fechaprimerpago")]
        public DateTime Fechaprimerpago { get; set; }

        public virtual ICollection<PlanamortizacionEntity> PlanamortizacionEntity { get; set; }
    }
}
