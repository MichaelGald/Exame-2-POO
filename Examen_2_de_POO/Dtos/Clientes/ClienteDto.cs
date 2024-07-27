using Examen_2_de_POO.Databases.Entities;
using System.ComponentModel.DataAnnotations;

namespace Examen_2_de_POO.Dtos.Clientes
{
    public class ClienteDto
    {
        [Key]
        public Guid IdCliente { get; set; }
        public string name { get; set; }
        public decimal montoprestamo { get; set; }
        public decimal tasacomicion { get; set; }
        public decimal tasainteres { get; set; }
        public int termino { get; set; }
        public DateTime fecharembolso { get; set; }
        public DateTime fechaprimerpago { get; set; }
        public  List<PlanamortizacionEntity> PlanamortizacionEntity { get; set; }
    }
}
