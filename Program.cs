using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemestralneZadanie_MC
{
}

namespace SemestralneZadanie_MC
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
