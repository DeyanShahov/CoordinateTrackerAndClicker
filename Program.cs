using CoordinateTrackerAndClicker.Users;
using System;
using System.Windows.Forms;

namespace CoordinateTrackerAndClicker
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FirestoreHelper.SetEnvironmentVariable(); // Първо викам настройките за Firebase-a
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new Form2());
        }
    }
}
