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
    public partial class TestFinishedWin : MetroFramework.Forms.MetroForm
    {
        public TestFinishedWin()
        {
            InitializeComponent();
        }
        private string valveid;

        private void TestFinishedWin_Load(object sender, EventArgs e)
        {
            this.valveid = ManualNumberInput.id;
            lblCon.Text = this.valveid + "已完成测试";
        }

        private void btnRetest_Click(object sender, EventArgs e)
        {
            this.Close();
            ManualNumberInput win = ManualNumberInput.getInstance();
            win.Show();
        }
    }
}
