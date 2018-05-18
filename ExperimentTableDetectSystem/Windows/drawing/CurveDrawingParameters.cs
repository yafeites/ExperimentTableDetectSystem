using ExperimentTableDetectSystem.Windows.manual;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows.Draw
{
    public partial class CurveDrawingParameters : MetroFramework.Forms.MetroForm
    {
        public CurveDrawingParameters()
        {
            InitializeComponent();
        }

        private void CurveDrawingParameters_Load(object sender, EventArgs e)
        {

        }

        private void btnChooseDone_Click(object sender, EventArgs e)
        {
            CurveDrawing win = new CurveDrawing();
            win.Show();
        }
    }
}
