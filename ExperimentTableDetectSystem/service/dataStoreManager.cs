using ExperimentTableDetectSystem.util;
using ExperimentTableDetectSystem.Windows.manual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExperimentTableDetectSystem.service
{
  public  class DataStoreManager
    {
        private  int number;
        private  double productId;
        DBHelper dbhelper;
        private DataStoreManager()
        {
            dbhelper = DBHelper.GetInstance();
           // number = ManualNumberInput.n;

        }
        private static volatile DataStoreManager instance;
        public static DataStoreManager Initialize()
        {
            if (instance != null)
            {
                throw new Exception("初始化数据保存类失败，实例已存在");

            }
            instance = new DataStoreManager();
            return instance;
        }
        public static DataStoreManager GetInstance()
        {
            if (instance == null) { throw new Exception("数据保存类实例不存在"); }
            return instance;
        }

        /// <summary>
        /// 
        /// </summary>
        public void InsertM1()
        {

        }
        public void InsertM2()
        {

        }
        public void Insertf1()
        {

        }
        public void Insertf2()
        {

        }
        public void Insertf3()
        {

        }
        //。。。
    }
}
