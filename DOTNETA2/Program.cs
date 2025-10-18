using DOTNETA2.DAO;

namespace DOTNETA2;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        
        using (var db = new TransactionContext())
        {
            db.Database.EnsureCreated();
        }
        ApplicationConfiguration.Initialize();
        Application.Run(new FormDashboard());
    }
}