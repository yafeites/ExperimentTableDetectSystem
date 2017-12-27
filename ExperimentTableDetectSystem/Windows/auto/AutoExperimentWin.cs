using ExperimentTableDetectSystem.Windows.auto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows
{
    public partial class AutoExperimentWin : MetroFramework.Forms.MetroForm
    {
        #region singleton
        private static AutoExperimentWin instance;
     //   private static object obj = new object();
        public static AutoExperimentWin getInstance()
       {
            if (instance == null||instance.IsDisposed)
            { //lock (obj)
               // {
                  //  if (instance == null)
                   // {
                        instance = new AutoExperimentWin();
                   // }
               // }
             }
            return instance;
        }
        #endregion
        private AutoExperimentWin()
        {
            InitializeComponent();
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            this.Close();
            autoDataDisplayWin win = autoDataDisplayWin.getInstance();
            win.Show();
        }
    }
}
