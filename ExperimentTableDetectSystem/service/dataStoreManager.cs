using ExperimentTableDetectSystem.util;
using ExperimentTableDetectSystem.Windows.manual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ExperimentTableDetectSystem.service
{
  public  class DataStoreManager
    {
        #region 字段
        private  int number;
        private  double productId;
        DBHelper dbhelper;
        System.Threading.Timer storeTimer { get; set; }
        PeakHelper peakHelper;
       #endregion
        private DataStoreManager()
        {
            dbhelper = DBHelper.GetInstance();
            storeTimer = new System.Threading.Timer(_ =>
            {
                if (peakHelper.hasData)
                {
                    storeData();
                }
            }, null, Timeout.Infinite, Timeout.Infinite);


        }
        private static volatile DataStoreManager instance;
        /// <summary>
        /// 初始化，放在mainwin加载时使用
        /// </summary>
        /// <returns></returns>
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
      
        public void StartTimer(int dueTime, int period)
        {
            storeTimer.Change(dueTime, period);
        }
      
        public void StopTimer()
        {
            storeTimer.Change(Timeout.Infinite, Timeout.Infinite);
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
        /// <summary>
        /// 数据保存具体实现方法
        /// </summary>
        public void storeData()
        {

        }
    }
}
