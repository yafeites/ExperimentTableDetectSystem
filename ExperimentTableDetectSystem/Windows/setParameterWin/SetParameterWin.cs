﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows.setParameterWin
{
    public partial class SetParameterWin : MetroFramework.Forms.MetroForm
    {
        private SetParameterWin()
        {
            InitializeComponent();
        }
        #region singleton
      //  private static object obj = new object();
        private static SetParameterWin instance;
        public static SetParameterWin getInstance()
        {
            if (instance == null||instance.IsDisposed)
            {
                //lock (obj)
               // {
                  //  if (instance == null)
                    //{
                        instance = new SetParameterWin();
                   // }
               // }
            }
            return instance;
        }
        #endregion
    }
}