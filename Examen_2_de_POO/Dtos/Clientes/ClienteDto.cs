using Examen_2_de_POO.Databases.Entities;
using System.ComponentModel.DataAnnotations;

namespace Examen_2_de_POO.Dtos.Clientes
{
    public class ClienteDto
    {
        public string name { get; set; }
        public virtual Guid IdCliente { get; set; }
        public decimal montoprestamo { get; set; }
        public decimal tasacomicion { get; set; }
        public decimal tasainteres { get; set; }
        public string termino { get; set; }
        public string fecharembolso { get; set; }
        public string fechaprimerpago { get; set; }
        public virtual PlanamortizacionEntity PlanamortizacionEntity { get; set; }
    }
}
