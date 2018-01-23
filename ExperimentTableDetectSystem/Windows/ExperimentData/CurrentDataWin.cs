using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows.ExperimentData
{
    public partial class CurrentDataWin : MetroFramework.Forms.MetroForm
    {
        public static string name;
        public CurrentDataWin()
        {
            InitializeComponent();
        }

       

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string s = txtId.Text;
            string n = lstN.SelectedItem.ToString();
            string test = lstSelection.SelectedItem.ToString();
            textBox1.Text = n;
            textBox2.Text = test;
            name = "valve" + s + n + test;
            HistoryDataWin win = new HistoryDataWin();
            win.Show();
        }
    }
}
