using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.Windows.manual;
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
    public partial class ManualExperimentWin : MetroFramework.Forms.MetroForm
    {
        #region 字段
        private string valveid;
        public static bool isDone=false;
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

        public string Company
        {
            get
            {
                return company;
            }

            set
            {
                company = value;
            }
        }

        private string company;
        PeakHelper peakHelperer;
        DataStoreManager dataStoreManager;
        ConfigManager config;
        #endregion

        #region singleton 
        private static ManualExperimentWin instance;
        public static ManualExperimentWin getInstance()
        {
            if (instance == null||instance.IsDisposed)
            {
            instance = new ManualExperimentWin();
            }
            return instance;
        }
        #endregion

        public ManualExperimentWin()
        {
            InitializeComponent();
            peakHelperer = PeakHelper.GetInstance();
            dataStoreManager = DataStoreManager.GetInstance();
            config = ConfigManager.GetInstance();
        }
       

        private void ManualExperimentWin_Load(object sender, EventArgs e)
        {
            //isDone = true;
            this.panel1.BackColor = Color.FromArgb(255, 50, 161, 206);
            this.panel2.Width = this.panel1.Width / 2;
            this.panel4.Height = this.panel2.Height / 2;
            this.panel6.Height = this.panel4.Height;
            this.valveid = ManualNumberInput.id;
            this.company = ManualNumberInput.company;
            lblValveId.Text = "编号:" + this.valveid.ToString() + "  发往厂家:" + this.company.ToString();
            //获得配置项的值，赋予报警参数? ? ?
            timer1.Enabled = true;
           // peakHelperer.StartTimer(250);
           // dataStoreManager.StartTimer(500, 1000);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshData();
        }

        /// <summary>
        /// 数据显示
        /// </summary>
        private void refreshData()
        {

        }

        private void ManualExperimentWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataStoreManager != null)
            {
                dataStoreManager.StopTimer();
            }
            if (peakHelperer != null)
            {
                peakHelperer.StopTimer();
            }
            isDone = true;
        }
    }
}
