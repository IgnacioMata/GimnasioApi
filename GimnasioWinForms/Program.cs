namespace GimnasioWinForms
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal de la aplicaci�n.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormGym());
        }
    }
}
