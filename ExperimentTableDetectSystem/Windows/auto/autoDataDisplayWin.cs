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
        private autoDataDisplayWin()
        {
            InitializeComponent();
        }
    }
}
