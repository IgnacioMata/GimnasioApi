namespace GimnasioWinForms
{
    public class Entrenador
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Especialidad { get; set; } = null!;
    }

    public class Socio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Dni { get; set; } = null!;
    }

    public class ReservaViewModel
    {
        public int Id { get; set; }
        public string FechaHora { get; set; } = null!;
        public Entrenador Entrenador { get; set; } = null!;
        public Socio Socio { get; set; } = null!;

        public string NombreEntrenador => Entrenador?.Nombre ?? string.Empty;
        public string EspecialidadEntrenador => Entrenador?.Especialidad ?? string.Empty;
        public string NombreSocio => Socio?.Nombre ?? string.Empty;
    }
}
