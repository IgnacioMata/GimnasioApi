using GimnasioApi.Models;

namespace GimnasioApi.DTOs
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public string FechaHora { get; set; } // En formato simplificado
        public Entrenador Entrenador { get; set; }
        public Socio Socio { get; set; }
    }
}
