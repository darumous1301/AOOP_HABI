using System;
using System.Windows.Forms;
using AOOP_HABI.Forms;
using AOOP_HABI.Services;

namespace AOOP_HABI
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

            var nameForm = new NameEntryForm();
            if (nameForm.ShowDialog() != DialogResult.OK)
                return;

            Application.Run(new MainForm());
            
            
        }
    }
}
