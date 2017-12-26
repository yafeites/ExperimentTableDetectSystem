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
        public AutoExperimentWin()
        {
            InitializeComponent();
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            autoDataDisplayWin win = new autoDataDisplayWin();
            win.Show();
        }
    }
}
