using ExperimentTableDetectSystem.util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ExperimentTableDetectSystem.service
{
   public class ConfigManager
    {
        #region 单例模式
        private DBHelper dbHelper;
        private ConfigManager(DBHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }
        private static volatile ConfigManager instance = null;
        /// <summary>
        /// 公有方法。。初始化实例对象
        /// </summary>
        /// <param name="dbHelper"></param>
        /// <param name="loadFromDB"></param>
        /// <returns></returns>
        public static ConfigManager Initialize(DBHelper dbHelper,bool loadFromDB)
        {
            if (instance != null)
            {
                throw new ConfigManagerException("Trying to initialize ConfigManager while its instance already exists.");
            }
            instance = new ConfigManager(dbHelper);
            if (loadFromDB)
            {
                try
                {
                    instance.LoadConfigFromDb();
                    System.Diagnostics.Debug.WriteLine("[ConfigManager.LoadConfigFromDb] Last config loaded.");
                }
                catch (ConfigManagerException ex)
                {
                    Debug.WriteLine("[ConfigManager.LoadConfigFromDb] last config loaded");
                    Debug.WriteLine("[ConfigManager.LoadConfigFromDb] Default config loaded.");
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            return instance;

        }
        /// <summary>
        /// 初始化重载
        /// </summary>
        /// <param name="dbHelper"></param>
        /// <returns></returns>
        public static ConfigManager Initialize(DBHelper dbHelper)
        {
            return Initialize(dbHelper, true);

        }
        /// <summary>
        /// 获取唯一的configmanager实例，初始化之前调用会报异常
        /// </summary>
        /// <returns></returns>
        public static ConfigManager GetInstance()
        {
            if (instance == null)
            {
                throw new ConfigManagerException("fail to getinstance before initialize");
            }
            return instance;
        }
        #endregion

        #region 配置字段
        /// <summary>
        /// 名称枚举
        /// </summary>
        public enum ConfigKeys
        {//
           // Atime,
          //  Btime,

            MaxTemp,
           MinTemp,

            BigBackS,
            BigForwardS,
            //BigSelfLockS,
            BigUpS,
            BigDownS,

           // LeakageLiftTime,
            MainP,
            MediumPTime,

            SmallBackS,
            SmallDownS,
            SmallForwardS,
           // SmallSelfLockS,
            SmallUpS,

            SteeringValveP,
           // SteerPreesureTestTime,

            Pump1Pressure,
            Pump2Pressure,
            LeakageFlow,

            P1Speed,
            P2Speed,
            HotMoterSpeed,
            LeadPumpSpeed,
            //BackMoterSpeed,

            ChangeLeakageP,
            OverloadP,

        }
        /// <summary>
        /// 代表配置的一项
        /// </summary>
        public class ConfigItem
        {
            public const int UNSET_VALUE = -1;
            public string readableName { get; private set; }
            public double minValue { get; private set; }
            public double maxValue { get; private set; }
            public double defaultValue { get; private set; }
            public double value { get; set; }
            public ConfigItem(string readableName, double minValue, double maxValue, double defaultValue)
            {
                this.readableName = readableName;
                this.minValue = minValue;
                this.maxValue = maxValue;
                this.defaultValue = defaultValue;
                this.value = defaultValue;
            }
        }
        /// <summary>
        /// 当前的配置项集合
        /// </summary>
        private Dictionary<ConfigKeys, ConfigItem> configItems = GetInitialConfig();

       /// <summary>
       /// 获取一套完整配置
       /// </summary>
       /// <returns></returns>
        private static Dictionary<ConfigKeys, ConfigItem> GetInitialConfig()
        {
            var config = new Dictionary<ConfigKeys, ConfigItem>()
            {
                {ConfigKeys.MaxTemp,new ConfigItem("加热电机环境最高温度",0,100,50) },
                {ConfigKeys.MinTemp,new ConfigItem("加热电机环境最低温度",0,100,20) },
                {ConfigKeys.MainP,new ConfigItem("主溢流阀调定压力",0,1000,50) },
                {ConfigKeys.SteeringValveP,new ConfigItem("转向溢流阀调定压力",0,10000,50) },

               // {ConfigKeys.Atime,new ConfigItem("泄露倾斜阀A口保压时间",0,10000,60) },
               // {ConfigKeys.Btime,new ConfigItem("泄露倾斜阀B口保压时间",0,10000,60) },
                //{ConfigKeys.LeakageLiftTime,new ConfigItem("泄露升降阀口保压时间",0,10000,60) },
                  {ConfigKeys.MediumPTime,new ConfigItem("中位压力损失测试时间",0,10000,60) },
                 //  {ConfigKeys.SteerPreesureTestTime,new ConfigItem("转向压力损失测试时间",0,10000,60) },

                {ConfigKeys.SmallBackS,new ConfigItem("小门架油缸后倾停止位移",0,10000,60) },
                {ConfigKeys.SmallDownS,new ConfigItem("小门架油缸下降停止位移",0,10000,60) },
                {ConfigKeys.SmallForwardS,new ConfigItem("小门架油缸前倾停止位移",0,10000,60) },
               // {ConfigKeys.SmallSelfLockS,new ConfigItem("小门架油缸自锁位移",0,10000,60) },
                {ConfigKeys.SmallUpS,new ConfigItem("小门架油缸上升停止位移",0,10000,60) },

                {ConfigKeys.BigBackS,new ConfigItem("大门架油缸后倾停止位移",0,10000,30) },
                {ConfigKeys.BigDownS,new ConfigItem("大门架油缸下降停止位移",0,10000,60) },
                {ConfigKeys.BigForwardS,new ConfigItem("大门架油缸前倾停止位移",0,10000,60) },
               // {ConfigKeys.BigSelfLockS,new ConfigItem("大门架油缸自锁位移",0,10000,60) },
                {ConfigKeys.BigUpS,new ConfigItem("大门架油缸上升停止位移",0,10000,60) },

                {ConfigKeys.Pump1Pressure,new ConfigItem("主泵1压力上限",0,10000,1000) },
                {ConfigKeys.Pump2Pressure,new ConfigItem("主泵2压力上限",0,10000,1000) },
                {ConfigKeys.LeakageFlow,new ConfigItem("内泄露流量上限",0,10000,1000) },

                {ConfigKeys.P1Speed,new ConfigItem("泵1转速",0,10000,1500) },
                {ConfigKeys.P2Speed,new ConfigItem("泵2转速",0,10000,1500) },
                {ConfigKeys.HotMoterSpeed,new ConfigItem("热电机转速",0,10000,1500) },
                {ConfigKeys.LeadPumpSpeed,new ConfigItem("先导泵转速",0,10000,1500) },
                //{ConfigKeys.BackMoterSpeed,new ConfigItem("回油电机转速",0,10000,1500) },

                {ConfigKeys.ChangeLeakageP,new ConfigItem("换向泄露测试调定压力",0,10000,50) },
                {ConfigKeys.OverloadP,new ConfigItem("过载阀测试调定压力",0,10000,50) },


            };

            return config;
        }

        /// <summary>
        /// 检查一套配置的完整性
        /// 若配置已经完整，true
        /// </summary>
        /// <param name="config"></param>
        /// <param name="missingKey"></param>
        /// <returns></returns>
        private static bool CheckIntegrety(Dictionary<ConfigKeys, ConfigItem> config, out ConfigKeys missingKey)
        {
            foreach (ConfigKeys configKey in Enum.GetValues(typeof(ConfigKeys)))
            {
                if (config[configKey].value == ConfigItem.UNSET_VALUE)
                {
                    Debug.WriteLine("[ConfigManager.CheckIntegrety]Missing key: " + configKey.ToString());
                    missingKey = configKey;
                    return false;
                }
            }
            missingKey = 0;
            return true;
        }

        /// <summary>
        /// 按key获取一个配置项
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private ConfigItem GetItem(ConfigKeys key)
        {
            ConfigItem item;
            if (configItems.TryGetValue(key, out item))
            {
                return item;
            }
            else
            {
                throw new ConfigManagerException("[ConfigManager.GetItem] Cannot find config with key: " + key.ToString());
            }
        }

        /// <summary>
        /// 设置一个配置项，值不在合法范围内抛出异常
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(ConfigKeys key, double value)
        {
            ConfigItem item = this.GetItem(key);

            if (!IsValueValid(key, value))
            {
                throw new ConfigManagerException(String.Format("[ConfigManager.Set] New value {0} is not in valid range({1}~{2})", value, item.minValue, item.maxValue));
            }

            item.value = value;
        }
        /// <summary>
        /// 获取一个配置项的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public double Get(ConfigKeys key)
        {
            return this.GetItem(key).value;
        }
        public string GetReadableName(ConfigKeys key)
        {
            return this.GetItem(key).readableName;
        }
        public double GetMinValue(ConfigKeys key)
        {
            return this.GetItem(key).minValue;
        }
        public double GetMaxValue(ConfigKeys key)
        {
            return this.GetItem(key).maxValue;
        }
        /// <summary>
        /// 检查值范围
        /// </summary>
        /// <param name="key"></param>
        /// <param name="valueToCheck"></param>
        /// <returns></returns>
        public bool IsValueValid(ConfigKeys key, double valueToCheck)
        {
            ConfigItem item = GetItem(key);
            if (valueToCheck < item.minValue || valueToCheck > item.maxValue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 数据库方法
        /// <summary>
        /// 重建数据库中的config表
        /// </summary>
        public void RecreateDbTable()
        {
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.config', 'U') IS NOT NULL 
                                        DROP TABLE dbo.config; ");
            dbHelper.ExecuteNonQuery(
                @"create table config
                (
                    name varchar(30) primary key,
                    value real not null
                )");
        }
        /// <summary>
        /// 从数据库中读取配置，不完整则抛异常
        /// </summary>
        public void LoadConfigFromDb()
        {
            SqlDataReader reader = dbHelper.ExecuteReader(@"SELECT * FROM config");
            var tempConfig = GetInitialConfig();
            while (reader.Read())
            {
                string key = reader.GetValue(0).ToString();
                ConfigKeys configKey;
                if (Enum.TryParse(key, false, out configKey) == false)
                {
                    throw new ConfigManagerException("[LoadConfigFromDb] Unknown config key: " + key);
                }
                double value = (float)reader.GetValue(1);
                tempConfig[configKey].value = value;
            }
            reader.Close();
            ConfigKeys missingKey;
            if (CheckIntegrety(tempConfig, out missingKey) == true)
            {
                this.configItems = tempConfig;
                Debug.WriteLine("[LoadConfigFromDb] Config updated.");
            }
            else
            {
                throw new ConfigManagerException("[LoadConfigFromDb] New config is broken. No changes applied. Missing key: " + missingKey.ToString());
            }
        }

        /// <summary>
        /// 将配置写到数据库中
        /// </summary>
        public void StoreConfigToDb()
        {
            ConfigKeys missingKey;
            if (CheckIntegrety(configItems, out missingKey) == false)
            {
                throw new ConfigManagerException("[StoreConfigToDb] Current config is broken. No changes applied. Missing key: " + missingKey.ToString());
            }
            dbHelper.ExecuteNonQuery(@"DELETE FROM config");
            List<KeyValuePair<string, double>> values = new List<KeyValuePair<string, double>>();
            foreach (ConfigKeys key in Enum.GetValues(typeof(ConfigKeys)))
            {
                values.Add(new KeyValuePair<string, double>(key.ToString(), this.Get(key)));
            }

            StringBuilder sql = new StringBuilder(@"INSERT INTO config (name, value) VALUES ");

            for (int i = 0; i < values.Count; i++)
            {
                sql.Append("( ");
                sql.AppendFormat("'{0}','{1}'", values[i].Key, values[i].Value);
                sql.Append(")");
                if (i < values.Count - 1)
                {
                    sql.Append(",");
                }
            }
            int affected = dbHelper.ExecuteNonQuery(sql.ToString());
            Debug.WriteLine("[StoreConfigToDb] " + affected.ToString() + " rows affected.");
        }
        #endregion
    }
    public class ConfigManagerException : Exception
    {
        public ConfigManagerException(string message) : base(message) { }
        public ConfigManagerException(string message, Exception inner) : base(message, inner) { }
    }
}
