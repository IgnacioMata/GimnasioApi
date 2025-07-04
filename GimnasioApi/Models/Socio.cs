namespace GimnasioApi.Models
{
    public class Socio
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? DNI { get; set; }

       
        public DateTime? FechaAlta { get; set; } 
        public string? PlanMembresia { get; set; } 
    }
}
