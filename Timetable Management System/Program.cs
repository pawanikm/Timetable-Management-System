using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timetable_Management_System
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
            Application.Run(new Location.Main_Window());
            //Application.Run(new Time_Table_Management_System.Form1());
            //Application.Run(new TimeTableManagementSystem.GenerateTimeTable());
        }
    }
}
