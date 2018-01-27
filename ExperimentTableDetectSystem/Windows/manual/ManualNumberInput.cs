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
       // DataStoreManager dataStoreManager;
       private int i=1;
        public static int n = -1;
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
        private string SendCompany;
        public static string company;

        private ManualNumberInput()
        {
            InitializeComponent();

        }
        /// <summary>
        /// 输入编号，发往厂家，插入到表tbProductId
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
           this.valveid = txtValveId.Text;
            id = this.valveid;
            this.SendCompany = txtCompany.Text;
            company = this.SendCompany;
            string sqlstr = "select * from tbProductId where Id="+"'"+txtValveId.Text+"'" ;

            
            if (!OperateDb.IsTableNull(sqlstr))//说明存在此id的记录，biao，须建立新名字。

            {
                DataTable dt = OperateDb.readTableN(sqlstr);

                int n = dt.Rows.Count;
                MessageBox.Show("此编号已测"+n.ToString()+"次");
                 i = int.Parse(dt.Rows[n-1][1].ToString());
               i = i + 1;
                 MessageBox.Show("这是第"+i.ToString()+"测试。");
             
            }
            n = i;

            try
            {
                RecreateRecordManager.AddNewId(id, i,company);
            }
            catch (Exception ex)
            {
                MessageBox.Show("加入阀编号表错误" + ex.Message);
            }
            //接收数据插入到测试数据表里，14个表
           // dataStoreManager.Insertf1();


            this.Close();

            ManualExperimentWin win = ManualExperimentWin.getInstance();
            win.Show();
        }

      
    }
}
