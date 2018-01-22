using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.util;
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
        private DBHelper dbhelper=DBHelper.GetInstance();
        #region singleton
        private static ManualNumberInput instance;
       
        public static ManualNumberInput getInstance()
        {
            if (instance == null||instance.IsDisposed)
            {

                instance = new ManualNumberInput();
            }
            return instance;
        }
        #endregion
        private  string valveid;
        public static string id;
        public  string Valveid
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

        private ManualNumberInput()
        {
            InitializeComponent();

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
           this.valveid = txtValveId.Text;
            id = this.valveid;
            string sqlstr = "select * from tbProductId where Id="+txtValveId.Text ;
            if (!RecreateRecordManager.IsTableNull(sqlstr)) { MessageBox.Show("已经有阀的数据，是否重新测？"); }
//??????????
           
            try
            {
                RecreateRecordManager.AddNewId(txtValveId.Text);
                RecreateRecordManager.CreateValveTable(txtValveId.Text); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"建立阀数据表错误");
            }
            
            
            this.Close();

            ManualExperimentWin win = ManualExperimentWin.getInstance();
            win.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
