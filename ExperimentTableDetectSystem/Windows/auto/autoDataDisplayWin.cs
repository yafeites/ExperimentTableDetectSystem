using ExperimentTableDetectSystem.Windows.manual;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows.auto
{
    public partial class autoDataDisplayWin : MetroFramework.Forms.MetroForm
    {
        #region singleton
        private static autoDataDisplayWin instance;
    
        public static autoDataDisplayWin getInstance()
        {
            if (instance == null||instance.IsDisposed)
            {
              
                        instance = new autoDataDisplayWin();
                 
             }
            return instance;
        }
        #endregion
        
        private string valveid;

        public string Valveid
        {
            get
            {
                return valveid;
            }

            set
            {
                valveid = value;
            }
        }

        private autoDataDisplayWin()
        {
            InitializeComponent();
        }
        
        private void autoDataDisplayWin_Load(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.FromArgb(255, 50, 161, 206);
            this.panel2.Width = this.panel1.Width / 2;
            this.panel4.Height = this.panel2.Height / 2;
            this.panel6.Height = this.panel4.Height;
            this.valveid = ManualNumberInput.id;
            this.lblValveId.Text = valveid;
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            TestFinishedWin win = new TestFinishedWin();
            win.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void autoDataDisplayWin_FormClosing(object sender, FormClosingEventArgs e)
        {
           // ManualExperimentWin.isDone = false;
        }
    }
}
