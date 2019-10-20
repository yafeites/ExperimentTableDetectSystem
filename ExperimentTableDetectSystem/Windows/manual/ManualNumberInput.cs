using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.util;
using ExperimentTableDetectSystem.Windows.auto;
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
        private List<string> listCombobox;
        private DBHelper dbhelper = DBHelper.GetInstance();
        PeakHelper peak;
        private int i = 1;
        public static int n = 1;
        #region singleton
        private static ManualNumberInput instance;

        public static ManualNumberInput getInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ManualNumberInput();
            }
            return instance;
        }
        #endregion

        private string valveid;
        public static string id;
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
        private string SendCompany;
        public static string company;
        private string MenjiaType;
        public static string menjiaType;
        private string ValveType;
        public static string valveType;

        private ManualNumberInput()
        {
            InitializeComponent();
            peak = PeakHelper.GetInstance();
        }
        /// <summary>
        /// 输入编号，发往厂家，插入到表tbProductId
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cbbCompany.Text == "" || txtValveId.Text == "" || cbbMenjiaType.Text == "" || cbbValveType.Text == "")
            {
                MessageBox.Show("请输入，不能为空");
            }
            else
            {
                #region 0x105
                TPCANMsg canmsg105;

                canmsg105 = new TPCANMsg();
                canmsg105.ID = 0x105;
                canmsg105.LEN = Convert.ToByte(8);
                canmsg105.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                canmsg105.DATA = new byte[8];

                if (cbbMenjiaType.Text == "小门架")
                {
                    canmsg105.DATA[0] = 1;
                }
                if (cbbMenjiaType.Text == "大门架")
                {
                    canmsg105.DATA[1] = 1;
                }
                if (cbbValveType.Text == "普通_二联")
                {
                    canmsg105.DATA[2] = 1;
                    canmsg105.DATA[3] = 1;
                }
                if (cbbValveType.Text == "普通_三联")
                {
                    canmsg105.DATA[2] = 1;
                    canmsg105.DATA[3] = 2;
                }
                if (cbbValveType.Text == "普通_四联")
                {
                    canmsg105.DATA[2] = 1;
                    canmsg105.DATA[3] = 3;

                }
                if (cbbValveType.Text == "CDB4_二联")
                {
                    canmsg105.DATA[2] = 2;
                    canmsg105.DATA[3] = 1;
                }
                if (cbbValveType.Text == "CDB4_三联")
                {
                    canmsg105.DATA[2] = 2;
                    canmsg105.DATA[3] = 2;
                }
                if (cbbValveType.Text == "CDB4_四联")
                {
                    canmsg105.DATA[2] = 2;
                    canmsg105.DATA[3] = 3;
                }

                #endregion
                TPCANStatus sts4 = peak.write(canmsg105);
                if(sts4 == TPCANStatus.PCAN_ERROR_OK)
                {
                    MessageBox.Show("阀信息输入成功");
                }

                this.valveid = txtValveId.Text;
                id = this.valveid;
                this.SendCompany = cbbCompany.Text;
                company = this.SendCompany;
                this.MenjiaType = cbbMenjiaType.Text;
                menjiaType = this.MenjiaType;
                this.ValveType = cbbValveType.Text;
                valveType = this.ValveType;

                string sqlstr = "select * from tbProductId where Id=" + "'" + txtValveId.Text + "'";


                if (!OperateDb.IsTableNull(sqlstr))//说明存在此id的记录，biao，须建立新名字。

                {
                    DataTable dt = OperateDb.readTableN(sqlstr);

                    n = dt.Rows.Count;
                    MessageBox.Show("此编号已测" + n.ToString() + "次，这是第" + (n+1).ToString() + "次测试");
                    //   i = int.Parse(dt.Rows[n-1][1].ToString());
                    n = n + 1;
                    //  MessageBox.Show("这是第" + n.ToString() + "测试。");

                }
                else
                {
                    n = 1;
                }
                //n = i;

                try
                {
                    RecreateRecordManager.AddNewId(id, n, company,menjiaType,valveType);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加入阀编号表错误" + ex.Message);
                }
            this.Close();
            ManualSelectWin win = new ManualSelectWin();
            //TestFinishedWin win = new TestFinishedWin();
            win.Show();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbbCompany.Text == "" || txtValveId.Text == "" || cbbMenjiaType.Text == "" || cbbValveType.Text == "")
            {
                MessageBox.Show("请输入，不能为空");
            }
            else
            {
                #region 0x105
                TPCANMsg canmsg105;

                canmsg105 = new TPCANMsg();
                canmsg105.ID = 0x105;
                canmsg105.LEN = Convert.ToByte(8);
                canmsg105.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                canmsg105.DATA = new byte[8];

                if (cbbMenjiaType.Text == "小门架")
                {
                    canmsg105.DATA[0] = 1;
                }
                if (cbbMenjiaType.Text == "大门架")
                {
                    canmsg105.DATA[1] = 1;
                }
                if (cbbValveType.Text == "普通_二联")
                {
                    canmsg105.DATA[2] = 1;
                    canmsg105.DATA[3] = 1;
                }
                if (cbbValveType.Text == "普通_三联")
                {
                    canmsg105.DATA[2] = 1;
                    canmsg105.DATA[3] = 2;
                }
                if (cbbValveType.Text == "普通_四联")
                {
                    canmsg105.DATA[2] = 1;
                    canmsg105.DATA[3] = 3;

                }
                if (cbbValveType.Text == "CDB4_二联")
                {
                    canmsg105.DATA[2] = 2;
                    canmsg105.DATA[3] = 1;
                }
                if (cbbValveType.Text == "CDB4_三联")
                {
                    canmsg105.DATA[2] = 2;
                    canmsg105.DATA[3] = 2;
                }
                if (cbbValveType.Text == "CDB4_四联")
                {
                    canmsg105.DATA[2] = 2;
                    canmsg105.DATA[3] = 3;
                }



                #endregion
                TPCANStatus sts4 = peak.write(canmsg105);
                if (sts4 == TPCANStatus.PCAN_ERROR_OK)
                {
                    MessageBox.Show("阀信息输入成功");
                }

                this.valveid = txtValveId.Text;
                id = this.valveid;
                this.SendCompany = cbbCompany.Text;
                company = this.SendCompany;
                this.MenjiaType = cbbMenjiaType.Text;
                menjiaType = this.MenjiaType;
                this.ValveType = cbbValveType.Text;
                valveType = this.ValveType;

                string sqlstr = "select * from tbProductId where Id=" + "'" + txtValveId.Text + "'";


                if (!OperateDb.IsTableNull(sqlstr))//说明存在此id的记录，biao，须建立新名字。

                {
                    DataTable dt = OperateDb.readTableN(sqlstr);

                    n = dt.Rows.Count;
                    MessageBox.Show("此编号已测" + n.ToString() + "次，这是第" + (n + 1).ToString() + "次测试");
                    //   i = int.Parse(dt.Rows[n-1][1].ToString());
                      n = n + 1;
                    //  MessageBox.Show("这是第" + n.ToString() + "测试。");

                }
                else
                {
                    n = 1;
                }
                //n = i;

                try
                {
                    RecreateRecordManager.AddNewId(id, n, company, menjiaType, valveType);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加入阀编号表错误" + ex.Message);
                }
            this.Close();
            AutoExperimentWin win = AutoExperimentWin.getInstance();
            win.Show();
            }

        }

        private void ManualNumberInput_Load(object sender, EventArgs e)
        {
            listCombobox = getComboboxItems(this.cbbCompany);

        }
        public List<string> getComboboxItems(ComboBox cb)
        {
            //初始化绑定默认关键词
            List<string> listOnit = new List<string>();
            //将数据项添加到listOnit中
            for (int i = 0; i < cb.Items.Count; i++)
            {
                listOnit.Add(cb.Items[i].ToString());
            }
            return listOnit;
        }
        private void cbbCompany_TextUpdate(object sender, EventArgs e)
        {
            List<string> listNew = new List<string>();
            //清空combobox
            cbbCompany.Items.Clear();
            //清空listNew
            listNew.Clear();
            //遍历全部备查数据
            foreach (var item in listCombobox)
            {
                if (item.Contains(cbbCompany.Text))
                {
                    //符合，插入ListNew
                    listNew.Add(item);
                }
            }
            //combobox添加已经查询到的关键字
            cbbCompany.Items.AddRange(listNew.ToArray());
            //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
            cbbCompany.SelectionStart = cbbCompany.Text.Length;
            //保持鼠标指针原来状态，有时鼠标指针会被下拉框覆盖，所以要进行一次设置
            Cursor = Cursors.Default;
            //自动弹出下拉框
            cbbCompany.DroppedDown = true;

        }
    }
}
