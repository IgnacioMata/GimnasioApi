using System;

namespace GimnasioApi.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int EntrenadorId { get; set; }
        public int SocioId { get; set; }
        public DateTime FechaHora { get; set; }

        public Entrenador? Entrenador { get; set; }
        public Socio? Socio { get; set; }
    }
}
