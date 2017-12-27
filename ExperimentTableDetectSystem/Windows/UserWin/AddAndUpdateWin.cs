using ExperimentTableDetectSystem.entity;
using ExperimentTableDetectSystem.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows.UserWin
{
    public partial class AddAndUpdateWin : MetroFramework.Forms.MetroForm
    {
        public AddAndUpdateWin()
        {
            InitializeComponent();
        }

        private int TP { get; set; } //标识1，新增窗口。。2，修改窗口
        string IDTemp;
        DBHelper dbhelper;
        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;           //得到传过来的值和对象
            this.TP = mea.Temp;                           //得到标识
            foreach (Control item in this.Controls)       //清空文本框
            {
                if (item is TextBox)
                {
                    TextBox tb = item as TextBox;
                    tb.Text = "";
                }
            }
            if (this.TP == 1)
            {

            }
            else if (this.TP == 2)
            {
                User user = mea.obj as User;           //给新增窗口文本框赋值
                txtUserName.Text = user.userName;
                txtPassword.Text = user.password;
                IDTemp = user.phid;
                if (user.rightLevel == 3)
                {
                    cmbUserLevel.Text = "系统管理员";   //组合框显示值
                }
                else if (user.rightLevel == 2)
                {
                    cmbUserLevel.Text = "主管";
                }
                else if (user.rightLevel == 1)
                {
                    cmbUserLevel.Text = "操作员";
                }

            }
        }
        #region 新增或修改确定，将数据送回数据库
        private void btnConfirm_Click(object sender, EventArgs e)
        {
           // LoggerHelper.Log("用户设置界面", "用户权限进行了更改");
            string msg;
            bool Exist = false;
            int r = -1;
            dbhelper = DBHelper.GetInstance();
            if (this.TP == 1)                         //新增
            {
                int level = 0;
                string a = "";
                string b = "";
                string c = "";
                if (cmbUserLevel.SelectedIndex == 2)
                {
                    level = 3;
                    a = "有";
                    b = "有";
                    c = "有";
                }
                else if (cmbUserLevel.SelectedIndex == 1)
                {
                    level = 2;
                    a = "有";
                    b = "有";
                    c = "无";
                }
                else if (cmbUserLevel.SelectedIndex == 0)
                {
                    level = 1;
                    a = "有";
                    b = "无";
                    c = "无";
                }
                Exist = CheckUserName();
                if (Exist)
                {
                    MessageBox.Show("用户名已存在，请重新输入");
                }
                else
                {


                    string sql = string.Format("insert into UserManager(userName,password,rightLevel,viewLog,ParameterSet,systemSet) values('{0}','{1}',{2},'{3}','{4}','{5}')", txtUserName.Text, txtPassword.Text, level, a, b, c);
                    if (txtUserName.Text == "" || txtPassword.Text == "" || level == 0)
                    {
                        new InputException();
                    }
                    else
                    {
                        try
                        {
                            r = dbhelper.ExecuteNonQuery(sql);
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        msg = r > 0 ? "操作成功" : "操作失败";
                        MessageBox.Show(msg);
                        this.Close();
                    }

                }

            }
            else if (this.TP == 2)           //修改
            {

                int level = 0;
                string a = "";
                string b = "";
                string c = "";
                if (cmbUserLevel.SelectedIndex == 2)
                {
                    level = 3;
                    a = "有";
                    b = "有";
                    c = "有";
                }
                else if (cmbUserLevel.SelectedIndex == 1)
                {
                    level = 2;
                    a = "有";
                    b = "有";
                    c = "无";
                }
                else if (cmbUserLevel.SelectedIndex == 0)
                {
                    level = 1;
                    a = "有";
                    b = "无";
                    c = "无";
                }



                string sql = string.Format("update UserManager set userName='{0}',password='{1}',rightLevel={2},viewLog='{3}',parameterSet='{4}',systemSet='{5}' where phid={6}", txtUserName.Text, txtPassword.Text, level, a, b, c, IDTemp);
                if (txtUserName.Text == "" || txtPassword.Text == "" || cmbUserLevel.SelectedIndex > 2 || cmbUserLevel.SelectedIndex < 0)
                {
                    new InputException();
                }
                else
                {
                    try
                    {

                        r = dbhelper.ExecuteNonQuery(sql);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    msg = r > 0 ? "操作成功" : "操作失败";
                    MessageBox.Show(msg);
                    this.Close();
                }


            }


        }
        #endregion

        private void AddAndUpdateUser_Load(object sender, EventArgs e)
        {
            if (this.TP == 2)
            {
                txtUserName.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        private bool CheckUserName()
        {
            bool exist = false;
            string checkuserstr = "select userName from UserManager";
            try
            {
                SqlDataReader reader = dbhelper.ExecuteReader(checkuserstr);
                while (reader.Read())
                {
                    if (reader.GetString(0).Equals(this.txtUserName.Text))
                    {
                        exist = true;

                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return exist;
        }
    }
    public class InputException : Exception
    {
        public InputException() : base()
        {
            System.Windows.Forms.MessageBox.Show("请输入正确");
        }
    }
}
