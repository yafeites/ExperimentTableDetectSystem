using ExperimentTableDetectSystem.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.util;

namespace ExperimentTableDetectSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginWin loginwin = new LoginWin();
            Initialize(args);
            initialPeakHelper();
            if (loginwin.ShowDialog()== DialogResult.OK)
            {
                loginwin.Close();
                Application.Run(new MainWin());
            }
            
        }

        private static void Initialize(string[] args)
        {
            bool recreate = false;
            bool isResetDb = false;

            if (args.Length > 0)
            {
                recreate = bool.Parse(args[0]);
                isResetDb = bool.Parse(args[1]);
            }

          

            //数据库初始化
            try
            {
                if (recreate)
                {
                    RecreateRecordManager.InitialDataBase();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化数据库表报错:" + ex.Message);
            }

            //配置初始化
            try
            {
                DBHelper dbHelper = DBHelper.GetInstance();
                if (isResetDb)
                {
                    ConfigManager.Initialize(dbHelper, false);
                    ConfigManager.GetInstance().RecreateDbTable();
                }
                else
                {
                    ConfigManager.Initialize(dbHelper);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("配置初始化错误" + ex.Message);
            }

          }
        /// <summary>
        /// 初始化peakhelper，后来使用调用GetInstance()即可
        /// </summary>
        private static void initialPeakHelper()
        {
           
            PcanHelper pcan = new PcanHelper();
            try
            {
                PeakHelper.Initialize(pcan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"在program.cs初始化peakhelper失败");
            }
        }

    }
}
