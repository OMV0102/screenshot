using System;
using System.Windows.Forms;

namespace screenshot
{
    static class Program
    {
        public static String[] args;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(String[] argv)
        {
            Program.args = argv;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
