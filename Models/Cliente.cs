using System.ComponentModel.DataAnnotations;

namespace GimnasioApi.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string NombreCompleto { get; set; }

        [Required]
        public string DNI { get; set; }

        [Required]
        public DateTime FechaPago { get; set; }

        [Required]
        public DateTime FechaVencimiento { get; set; }

        public bool EstaPago { get; set; }
    }
}
