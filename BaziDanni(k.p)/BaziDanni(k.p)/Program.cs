using BaziDanni_k.p_.Infrastructure;

namespace BaziDanni_k.p_
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
            DatabaseInitializer.Initialize(Form1.ConnectionString);
            Application.Run(new Form1());
        }
    }
}
