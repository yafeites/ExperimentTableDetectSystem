using ExperimentTableDetectSystem.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginWin loginwin = new LoginWin();
        
            if (loginwin.ShowDialog()== DialogResult.OK)
            {
                loginwin.Close();
                Application.Run(new MainWin());
            }
            
        }
    }
}
