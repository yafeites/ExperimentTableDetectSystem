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
    public partial class ManualExperimentWin : MetroFramework.Forms.MetroForm
    {
        #region singleton 
        private static ManualExperimentWin instance;
        private static object obj = new object();
        public static ManualExperimentWin getInstance()
        {
            if (instance == null)
            {
                lock (obj)
                {
                    if (instance == null)
                    {
                        instance = new ManualExperimentWin();
                    }
                }
            }
            return instance;
        }
        #endregion
        public ManualExperimentWin()
        {
            InitializeComponent();
        }
    }
}
