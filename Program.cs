using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rudniev_Snake_V2
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arg)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm mainForm;
            if (arg.Length == 2)
                mainForm = new MainForm(Convert.ToInt32(arg[0]), Convert.ToInt32(arg[1]));
            else if (arg.Length == 1)
                mainForm = new MainForm(Convert.ToInt32(arg[0]));
            else
                mainForm = new MainForm();

            Application.Run(mainForm);
        }
    }
}