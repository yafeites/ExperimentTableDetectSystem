using ExperimentTableDetectSystem.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows.setParameterWin
{
    public partial class SetParameterWin : MetroFramework.Forms.MetroForm
    {
        ConfigManager configManager;
        List<NumericUpDown> numericList;
        List<ConfigManager.ConfigKeys> configKeysList;
        private SetParameterWin()
        {
            InitializeComponent();
            configManager = ConfigManager.GetInstance();
            numericList = new List<NumericUpDown>()
            {
                txt1,
                txt2,
                txt3,
                txt4,
                txt5,
                txt6,
                txt7,
                txt8,
                txt9,
                txt10,
                txt11,
                txt12,
                txt13,
                txt14,
                txt15,
                txt16,
                txt17
            };
            configKeysList = new List<ConfigManager.ConfigKeys>()
            {// mainPumpN1,
            //mainPumpN2,
            //mainOverflowValveP,
            //steeringOverflowValveP,
            //portalTestTime,
            //aloneTestTime,
            //compoundTestTime,
            //mediumPreLossTime,
            //liftingOilDis,
            //frontOilDis,
            //backOilDis,
            //downOilDis,
            //frontTestNumber,
            //frontSelfLockTestTime,
            //changeDirectionNumber,
            //backPressureHoldTime,
            //linkagePressureHoldTime
             ConfigManager.ConfigKeys.mainPumpN1,
             ConfigManager.ConfigKeys.mainPumpN2,
             ConfigManager.ConfigKeys.mainOverflowValveP,
             ConfigManager.ConfigKeys.steeringOverflowValveP,
             ConfigManager.ConfigKeys.portalTestTime,//5
             ConfigManager.ConfigKeys.aloneTestTime,
             ConfigManager.ConfigKeys.compoundTestTime,
             ConfigManager.ConfigKeys.mediumPreLossTime,
             ConfigManager.ConfigKeys.liftingOilDis,
             ConfigManager.ConfigKeys.frontOilDis,//10
             ConfigManager.ConfigKeys.backOilDis,
             ConfigManager.ConfigKeys.downOilDis,
             ConfigManager.ConfigKeys.frontTestNumber,
             ConfigManager.ConfigKeys.frontSelfLockTestTime,
             ConfigManager.ConfigKeys.changeDirectionNumber,//15
             ConfigManager.ConfigKeys.backPressureHoldTime,
             ConfigManager.ConfigKeys.linkagePressureHoldTime,

            };
            SetNumericValue(numericList, configKeysList);//文本框与配置相对应
            
            
        }
        #region singleton
     
        private static SetParameterWin instance;
        public static SetParameterWin getInstance()
        {
            if (instance == null||instance.IsDisposed)
            {
                        instance = new SetParameterWin();
                  
            }
            return instance;
        }
        #endregion

        private void SetNumericValue(List<NumericUpDown> numericList, List<ConfigManager.ConfigKeys> configKeysList)
        {
            for (int i = 0; i < numericList.Count; i++)
            {
                numericList[i].Maximum = Convert.ToDecimal(configManager.GetMaxValue(configKeysList[i]));
                numericList[i].Minimum = Convert.ToDecimal(configManager.GetMinValue(configKeysList[i]));
                numericList[i].Value = Convert.ToDecimal(configManager.Get(configKeysList[i]));
            }
        }

        private void SetConfigValue()
        {
            for (int i = 0; i < numericList.Count; i++)
            {
                configManager.Set(configKeysList[i], Convert.ToDouble(numericList[i].Value));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            { SetConfigValue();
                configManager.StoreConfigToDb();
                MessageBox.Show("保存成功.");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
