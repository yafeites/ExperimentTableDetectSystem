using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using BridgeDetectSystem;

namespace ExperimentTableDetectSystem
{
    public partial class LoginWin : MetroFramework.Forms.MetroForm
    {
        public LoginWin()
        {
            InitializeComponent();
        }

        private void LoginWin_Load(object sender, EventArgs e)
        {
            this.initial();
        }
        private void initial()
        {
            this.btnConfirm.Width = 60;
            this.btnConfirm.Height = 30;
            this.btnCancel.Width = 60;
            this.btnCancel.Height = 30;
            this.metroLabel1.Width = 40;
            this.metroLabel1.Height = 30;
            this.metroLabel2.Width = 40;
            this.metroLabel2.Height = 30;
            this.txtUserName.Width = 120;
            this.txtUserName.Height = 30;
            this.txtPassword.Width = 120;
            this.txtPassword.Height = 30;

            this.metroLabel1.Location = new System.Drawing.Point(this.panel1.Width * 15 / 80, this.panel1.Height / 10);
            this.txtUserName.Location = new System.Drawing.Point(this.panel1.Width * 20 / 80, this.panel1.Height / 10);
            this.metroLabel2.Location = new System.Drawing.Point(this.panel1.Width * 35 / 80, this.panel1.Height / 10);
            this.txtPassword.Location = new System.Drawing.Point(this.panel1.Width * 40 / 80, this.panel1.Height / 10);
            this.btnConfirm.Location = new System.Drawing.Point(this.panel1.Width * 55 / 80, this.panel1.Height / 10);
            this.btnCancel.Location = new System.Drawing.Point(this.panel1.Width * 62 / 80, this.panel1.Height / 10);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
           
            string userName = this.txtUserName.Text;
            string password = this.txtPassword.Text;
            UserRightManager.Initial(userName, password);
            UserRightManager manager = UserRightManager.GetInstance();
            try
            {
                if (manager.Check())
                {
                    this.DialogResult = DialogResult.OK;

                }
                else
                {
                    MessageBox.Show("账号或密码错误，请重新输入");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
           // PcanHelper p = PcanHelper.GetInstance();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            TestForm x = new TestForm();
            x.Show();
        }

      
    }
}
