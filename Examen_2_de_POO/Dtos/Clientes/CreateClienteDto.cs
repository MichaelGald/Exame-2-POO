using Examen_2_de_POO.Databases.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examen_2_de_POO.Dtos.Clientes
{
    public class CreateClienteDto
    {
        [Display(Name = "cliente")]
        [StringLength(100, ErrorMessage = "El cliente {0} no puede tener mas de {1}")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public string name { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        public decimal montoprestamo { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        public decimal tasacomicion { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        public decimal tasainteres { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        public string termino { get; set; }

        public string fecharembolso { get; set; }

        public string fechaprimerpago { get; set; }
    }
}
