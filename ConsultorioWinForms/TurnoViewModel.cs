namespace ConsultorioWinForms
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Especialidad { get; set; } = null!;
    }

    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Dni { get; set; } = null!;
    }

    public class TurnoViewModel
    {
        public int Id { get; set; }
        public string FechaHora { get; set; } = null!;
        public Medico Medico { get; set; } = null!;
        public Paciente Paciente { get; set; } = null!;

        public string NombreMedico => Medico?.Nombre ?? string.Empty;
        public string EspecialidadMedico => Medico?.Especialidad ?? string.Empty;
        public string NombrePaciente => Paciente?.Nombre ?? string.Empty;
    }
}
