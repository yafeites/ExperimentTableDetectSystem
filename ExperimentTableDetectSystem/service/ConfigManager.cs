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
            mainPumpN1,
            mainPumpN2,
            mainOverflowValveP,
            steeringOverflowValveP,
            portalTestTime,
            aloneTestTime,
            compoundTestTime,
            mediumPreLossTime,
            liftingOilDis,
            frontOilDis,
            backOilDis,
            downOilDis,
            frontTestNumber,
            frontSelfLockTestTime,
            changeDirectionNumber,
            backPressureHoldTime,
            linkagePressureHoldTime

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
                {ConfigKeys.mainPumpN1,new ConfigItem("主泵1转速",0,10000,50) },
                {ConfigKeys.mainPumpN2,new ConfigItem("主泵2转速",0,10000,50) },
                {ConfigKeys.mainOverflowValveP,new ConfigItem("主溢流阀调定压力",0,1000,50) },
                {ConfigKeys.steeringOverflowValveP,new ConfigItem("转向溢流阀调定压力",0,10000,50) },
                {ConfigKeys.portalTestTime,new ConfigItem("门架动作试验时间",0,10000,60) },
                {ConfigKeys.aloneTestTime,new ConfigItem("转向优先阀流量测试：单独测试试验时间",0,10000,60) },
                {ConfigKeys.compoundTestTime,new ConfigItem("转向优先阀流量测试：复合测试试验时间",0,10000,60) },
                {ConfigKeys.mediumPreLossTime,new ConfigItem("中位压力损失试验：试验时间",0,10000,60) },
                {ConfigKeys.liftingOilDis,new ConfigItem("起升压力损失试验:油缸位移",0,10000,60) },
                {ConfigKeys.frontOilDis,new ConfigItem("前倾压力损失：前倾油缸行走位移",0,10000,60) },
                {ConfigKeys.backOilDis,new ConfigItem("后倾压力损失：后倾油缸行走位移",0,10000,60) },
                {ConfigKeys.downOilDis,new ConfigItem("油缸下降位移",0,10000,60) },
                {ConfigKeys.frontTestNumber,new ConfigItem("前倾动作检测：试验次数",0,10000,30) },
                {ConfigKeys.frontSelfLockTestTime,new ConfigItem("前倾自锁：试验时间",0,10000,60) },
                {ConfigKeys.changeDirectionNumber,new ConfigItem("背压试验：换向次数",0,10000,60) },
                {ConfigKeys.backPressureHoldTime,new ConfigItem("背压试验：保压时间",0,10000,60) },
                {ConfigKeys.linkagePressureHoldTime,new ConfigItem("内泄漏测试：保压时间",0,10000,60) },


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
