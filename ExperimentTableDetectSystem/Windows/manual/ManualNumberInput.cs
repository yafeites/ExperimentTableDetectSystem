using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows.manual
{
    public partial class ManualNumberInput : MetroFramework.Forms.MetroForm
    {
        #region singleton
        private static ManualNumberInput instance;
       // private static object obj = new object();
        public static ManualNumberInput getInstance()
        {
            if (instance == null||instance.IsDisposed)
            {// lock (obj)
                //{
                   // if (instance == null)
                   // {
                        instance = new ManualNumberInput();
                    //}
                //}
            }
            return instance;
        }
        #endregion
        private ManualNumberInput()
        {
            InitializeComponent();
        }
    }
}
