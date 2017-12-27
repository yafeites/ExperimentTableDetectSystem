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
      //  private static object obj = new object();
        public static autoDataDisplayWin getInstance()
        {
            if (instance == null||instance.IsDisposed)
            {
              //  lock (obj)
               // {
                    //if (instance == null)
                    //{
                        instance = new autoDataDisplayWin();
                   // }
               // }
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
            this.valveid = ManualNumberInput.id;
            this.lblValveId.Text = valveid;

        }
    }
}
