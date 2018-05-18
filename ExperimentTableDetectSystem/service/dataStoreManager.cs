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
       public static  int n;
       public static string   productId;
        DBHelper dbhelper;
        System.Threading.Timer storeTimer1 { get; set; }
        System.Threading.Timer storeTimer2 { get; set; }
      
        PeakHelper peakhelper;
       #endregion
        private DataStoreManager()
        {
           

            dbhelper = DBHelper.GetInstance();
            peakhelper = PeakHelper.GetInstance();
            storeTimer1 = new System.Threading.Timer(_ =>
            {
                if (peakhelper.hasData)
                {
                   storeData1();
                }
            }, null, Timeout.Infinite, Timeout.Infinite);

            storeTimer2 = new System.Threading.Timer(_ =>
              {
                  if (peakhelper.hasData)
                  {
                      storeData2();
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
      
        public void StartTimer1(int dueTime, int period)
        {
            storeTimer1.Change(dueTime, period);
        }
      
        public void StopTimer1()
        {
            storeTimer1.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void startTimer2(int duetime,int period)
        {
            storeTimer2.Change(duetime, period);
        }

        public void stopTimer2()
        {
            storeTimer2.Change(Timeout.Infinite, Timeout.Infinite);
        }

        #region 数据保存具体实现
        /// <summary>
        /// 
        /// </summary>
        public void Insert(double[] value,string testName)
        {
            int pushvalvetime = 111;
            int v=0;
            string sql = string.Format("insert into allData values('{0}',{1},'{2}',{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43},{44},{45},{46},{47},{48},{49},{50},{51},{52},{53},{54})", productId, n, testName,value[0],value[1],value[2],value[3],value[4],value[5],value[6],value[7],value[8],v,value[9],value[10],v, value[11], value[12],v, value[13], value[14],v, value[15], value[16],v, value[17], value[18], value[19],v, value[20],value[21], value[22],v, value[23], value[24], value[25],v, value[26], value[27],value[43],value[44],value[45],value[46],value[47],value[48],value[49],value[50],pushvalvetime,pushvalvetime,pushvalvetime,pushvalvetime,pushvalvetime,pushvalvetime,pushvalvetime,pushvalvetime );
            dbhelper.ExecuteNonQuery(sql);
        }
      
        #endregion
        //。。。
        /// <summary>
        /// 手动试验数据保存具体实现方法
        /// </summary>
        public void storeData1()
        {
            double[] valuesNow = new double[51];
        
            for (int i = 0; i < 51; i++)
            {
                valuesNow[i] = peakhelper.AllValue[i];
            }
            if (valuesNow[28] == 0) { Insert(valuesNow,"主溢流阀调定试验"); }//未结束，正在做主溢流阀调定试验
            if (valuesNow[28] == 1 && valuesNow[29]==0) { Insert(valuesNow,"转向溢流阀调定试验"); }//已结束，正在做转向溢流阀调定试验
       
        }

        /// <summary>
        /// 自动试验数据保存
        /// </summary>
        public void storeData2()
        {
            double[] valuesNow = new double[51];
            // valuesNow  = peakhelper.AllValue;//数组赋值？？？
            for (int i = 0; i < 51; i++)
            {
                valuesNow[i] = peakhelper.AllValue[i];
            }
            if (valuesNow[9] == 0) { Insert(valuesNow, "中位压力损失试验"); }
            if (valuesNow[9] == 1) { Insert(valuesNow, "转向优先阀流量试验"); }
            if (valuesNow[30] == 1) { Insert(valuesNow,"中位压力损失试验"); }
            if (valuesNow[31] == 1) { Insert(valuesNow,"转向优先阀流量试验"); }
            if (valuesNow[32] == 1) { Insert(valuesNow,"小门架上升"); }
            if (valuesNow[33] == 1) { Insert(valuesNow,"小门架下降"); }
            if (valuesNow[34] == 1) { Insert(valuesNow, "大门架上升"); }
            if (valuesNow[35] == 1) { Insert(valuesNow, "大门架下降"); }
            if (valuesNow[36] == 1) { Insert(valuesNow,"小门架前倾"); }
            if (valuesNow[37] == 1) { Insert(valuesNow,"小门架后倾"); }
            if (valuesNow[38] == 1) { Insert(valuesNow,"大门架前倾"); }
            if (valuesNow[39] == 1) { Insert(valuesNow,"大门架后倾"); }
            if (valuesNow[40] == 1) { Insert(valuesNow,"内泄漏试验"); }
            if (valuesNow[41] == 1) { Insert(valuesNow,"小门架前倾自锁"); }
            if (valuesNow[42] == 1) {Insert(valuesNow,"大门架前倾自锁"); }
        }


    }
}
