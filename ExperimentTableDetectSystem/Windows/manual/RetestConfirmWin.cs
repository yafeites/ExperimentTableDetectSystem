using ExperimentTableDetectSystem.service;
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
    public partial class RetestConfirmWin : MetroFramework.Forms.MetroForm
    {
        private string valveid;
        private string company;
        private string SendCompany;
        public static string id;
        public string menjiaType;
        public string valveType;
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
        private string MenjiaType
        {
            get
            {
                return menjiaType;
            }

            set
            {
                menjiaType = value;
            }
        }
        
        private string ValveType
        {
            get
            {
                return valveType;
            }

            set
            {
                valveType = value;
            }
        }
        
        PeakHelper Peak;
        public static int n = 1;
        private static RetestConfirmWin instance;
        public static RetestConfirmWin getInstance()
        {
            if (instance == null || instance.IsDisposed)
            {

                instance = new RetestConfirmWin();
            }
            return instance;
        }
        public RetestConfirmWin()
        {
            InitializeComponent();
            Peak = PeakHelper.GetInstance();
        }


        private void ManualExperimentWin_Load(object sender, EventArgs e)
        {
            this.valveid = ManualNumberInput.id;
            id = this.valveid;
            metroLabel1.Text = "阀编号："+ this.valveid ;
            string sqlstr = "select * from tbProductId where Id=" + "'" + this.valveid + "'";
            if (!OperateDb.IsTableNull(sqlstr))//说明存在此id的记录，biao，须建立新名字。

            {
                DataTable dt = OperateDb.readTableN(sqlstr);

                n = dt.Rows.Count;
              //  MessageBox.Show("此编号已测" + n.ToString() + "次");
                //   i = int.Parse(dt.Rows[n-1][1].ToString());
               // n = n + 1;
               // MessageBox.Show("这是第" + n.ToString() + "测试。");

            }
            metroLabel3.Text = "已测" + n.ToString() + "次";
            this.SendCompany = ManualNumberInput.company;
            company = this.SendCompany;
            metroLabel2.Text = "发往厂家：" + this.SendCompany;
        }

        private void btnRetest_Click(object sender, EventArgs e)
        {
            this.Valveid = ManualNumberInput.id;
            id = this.Valveid;
            this.SendCompany = ManualNumberInput.company;
            company = this.SendCompany;
            this.MenjiaType = ManualNumberInput.menjiaType;
            menjiaType = this.MenjiaType;
            this.ValveType = ManualNumberInput.valveType;
            valveType = this.ValveType;
            string sql = "select * from tbProductId where Id=" + "'" + id + "'";
            if (!OperateDb.IsTableNull(sql))//说明存在此id的记录，biao，须建立新名字。

            {
                DataTable dt = OperateDb.readTableN(sql);

                n = dt.Rows.Count;
                n = n + 1;
                MessageBox.Show("第" + n.ToString() + "次测试开始。");
            }
            try
            {
                RecreateRecordManager.AddNewId(id, n, company, menjiaType, valveType);
            }
            catch (Exception ex)
            {
                MessageBox.Show("加入阀编号表错误" + ex.Message);
            }
            this.Close();

            ManualExperimentWin win = ManualExperimentWin.getInstance();
            win.Show();
        }
    }
}
