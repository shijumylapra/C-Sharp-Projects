using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//CODE WRITTEN BY SHIJU ABRAHAM 27-09-24-
namespace ProjectCityPower
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmCustomers());
        }
    }
}
//CODE WRITTEN BY SHIJU ABRAHAM 27-09-24-