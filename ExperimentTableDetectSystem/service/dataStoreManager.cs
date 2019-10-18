using ExperimentTableDetectSystem.util;
using ExperimentTableDetectSystem.Windows.auto;
using ExperimentTableDetectSystem.Windows.manual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ExperimentTableDetectSystem.service
{
    public class DataStoreManager
    {
        #region 字段
        public static int n;
        public static string productId;
        public static string menjiaType;
        public static string valveType;
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

        public void startTimer2(int duetime, int period)
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
        public void Insert(double[] value, string testName)
        {

            string sql = string.Format("insert into allData values('{0}',{1},'{2}','{3}','{4}',{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},'{38}',{39})", productId, n, menjiaType ,valveType , testName, value[36], value[37], value[38], value[39], value[10], value[11], value[12], value[19], value[20], autoDataDisplayWin.SmallUpV, value[22],  autoDataDisplayWin.SmallDownV, value[23], value[21], autoDataDisplayWin.SmallForwardV, value[24], value[25],  autoDataDisplayWin.SmallBackV, value[26], value[27], value[13], value[14], value[15], value[16], value[17], value[18], autoDataDisplayWin.realPilotPressure, value[44], value[45], value[46], value[60], value[61], value[62],DateTime.Now,value[41]);
            dbhelper.ExecuteNonQuery(sql);
        }

        //  private static string ConvertToString(DateTime dateTime)
        // {
        //   return dateTime.ToString("yyyy-MM-dd HH-mm-ss ");
        //}

        #endregion


        //。。。
        /// <summary>
        /// 手动试验数据保存具体实现方法
        /// </summary>
        public void storeData1()
        {
            double[] valuesNow = new double[76];

            for (int i = 0; i < 76; i++)
            {
                valuesNow[i] = peakhelper.AllValue[i];
            }
            if (valuesNow[39] == 0)
            {
                valuesNow[39] = 600;
            }
            else
            {
                valuesNow[39] = 60 / valuesNow[39];
            }
            if (valuesNow[56] == 1) { Insert(valuesNow, "转向溢流阀调定试验"); }//正在做转向溢流阀调定试验
            if (valuesNow[57] == 1 ) { Insert(valuesNow, "主溢流阀调定试验"); }//做主溢流阀调定试验
            if (valuesNow[73] == 1) { Insert(valuesNow, "换向泄漏上升口试验"); }//正在做换向泄漏试验
            if (valuesNow[65] == 1) { Insert(valuesNow, "换向泄漏前倾口试验"); }//正在做换向泄漏试验
            if (valuesNow[66] == 1) { Insert(valuesNow, "换向泄漏后倾口试验"); }//正在做换向泄漏试验
            if (valuesNow[67] == 1) { Insert(valuesNow, "换向泄漏备用1口试验"); }//正在做换向泄漏试验
            if (valuesNow[68] == 1) { Insert(valuesNow, "换向泄漏备用2口试验"); }//正在做换向泄漏试验
            if (valuesNow[69] == 1) { Insert(valuesNow, "换向泄漏备用3口试验"); }//正在做换向泄漏试验
            if (valuesNow[70] == 1) { Insert(valuesNow, "换向泄漏备用4口试验"); }//正在做换向泄漏试验
            if (valuesNow[63] == 1) { Insert(valuesNow, "过载阀A1口调定试验"); }
            if (valuesNow[64] == 1) { Insert(valuesNow, "过载阀B1口调定试验"); }
            if (valuesNow[71] == 1) { Insert(valuesNow, "过载阀A2口调定试验"); }
            if (valuesNow[72] == 1) { Insert(valuesNow, "过载阀B2口调定试验"); }
           // if (valuesNow[74] == 1) { Insert(valuesNow, "转向阀启闭特性试验"); }
           // if (valuesNow[75] == 1) { Insert(valuesNow, "主溢流阀启闭特性试验"); }
           // if (valuesNow[28] == 1) { Insert(valuesNow, "过载阀A1口启闭特性试验"); }
           // if (valuesNow[29] == 1) { Insert(valuesNow, "过载阀A2口启闭特性试验"); }
           // if (valuesNow[30] == 1) { Insert(valuesNow, "过载阀B1口启闭特性试验"); }
           // if (valuesNow[31] == 1) { Insert(valuesNow, "过载阀B2口启闭特性试验"); }
        }

        /// <summary>
        /// 自动试验数据保存
        /// </summary>
        public void storeData2()
        {
            double[] valuesNow = new double[76];
            for (int i = 0; i < 76; i++)
            {
                valuesNow[i] = peakhelper.AllValue[i];
            }
            if (valuesNow[39] == 0)
            {
                valuesNow[39] = 600;
            }
            else
            {
                valuesNow[39] = 60 / valuesNow[39];
            }
            if (valuesNow[0] == 1) { Insert(valuesNow, "中位压力损失试验"); }
            if (valuesNow[1] == 1) { Insert(valuesNow, "门架上升试验"); }
            if (valuesNow[2] == 1) { Insert(valuesNow, "门架后倾试验"); }
            if (valuesNow[3] == 1) { Insert(valuesNow, "门架前倾试验"); }
            if (valuesNow[4] == 1) { Insert(valuesNow, "门架前倾动作检测"); }
            if (valuesNow[5] == 1) { Insert(valuesNow, "门架前倾自锁"); }
            if (valuesNow[6] == 1) { Insert(valuesNow, "泄漏保压升降测试"); }
            if (valuesNow[7] == 1) { Insert(valuesNow, "倾斜阀A口内泄漏测试"); }
            if (valuesNow[8] == 1) { Insert(valuesNow, "倾斜阀B口内泄漏测试"); }
            if (valuesNow[9] == 1) { Insert(valuesNow, "门架下降试验"); }
            if (valuesNow[49] == 1) { Insert(valuesNow, "备用1口内泄漏测试"); }
            if (valuesNow[50] == 1) { Insert(valuesNow, "备用2口内泄漏测试"); }
            if (valuesNow[51] == 1) { Insert(valuesNow, "备用3口内泄漏测试"); }
            if (valuesNow[52] == 1) { Insert(valuesNow, "备用4口内泄漏测试"); }
        }


    }
}
