using ConsultorioApi.Models;

namespace ConsultorioApi.DTOs
{
    public class TurnoDTO
    {
        public int Id { get; set; }
        public string FechaHora { get; set; } // En formato simplificado
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
    }
}