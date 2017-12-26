using ExperimentTableDetectSystem.Windows.setParameterWin;
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
    public partial class MainWin : MetroFramework.Forms.MetroForm
    {
        public MainWin()
        {
            InitializeComponent();
        }

        private void btnManualExperiment_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAutoExperiment_Click(object sender, EventArgs e)
        {
            AutoExperimentWin win = new AutoExperimentWin();
            win.Show();
        }

        private void btnSetParameter_Click(object sender, EventArgs e)
        {
            SetParameterWin win = SetParameterWin.getInstance();
            win.Show();
        }

       
    }
}
