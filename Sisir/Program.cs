using System;
using System.Windows.Forms;

namespace Sisir
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]



        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var db = new DatabaseAdapter();
            var conn = db.ConnectToDb();

            if (conn != null)
            {
                Application.Run(new MainForm(db));
            }
        }
    }
}
