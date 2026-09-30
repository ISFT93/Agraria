using Agraria.Formularios;

namespace Agraria
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var inicio = new Inicio(true); // arranca en modo invitado hasta que se autentique
            inicio.WindowState = FormWindowState.Maximized;
            Application.Run(inicio);
        }
    }
}