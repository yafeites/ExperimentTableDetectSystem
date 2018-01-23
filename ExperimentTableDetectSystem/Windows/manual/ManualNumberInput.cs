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
        int i=1;
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


            try
            {
                RecreateRecordManager.AddNewId(id, i);
            }
            catch (Exception ex)
            {
                MessageBox.Show("加入阀编号表错误" + ex.Message);
            }
            try
            {
                RecreateRecordManager.CreateValveTable(id + "第" + i.ToString()+"次");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "建立阀每个试验数据表错误");
            }


            this.Close();

            ManualExperimentWin win = ManualExperimentWin.getInstance();
            win.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            del();
        }
        private void del()
        {
            string[] s = new string[13];
            string ss = "valve1第3次f";
            for (int i = 1; i < 13; i++)
            {
                s[i] = ss + i.ToString();
            }
            try
            {
                for (int i = 1; i < 13; i++)
                {
                    RecreateRecordManager.deleteTable(s[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "删表出现失败");
            }

            MessageBox.Show("删除成功.");
        }
    }
}
