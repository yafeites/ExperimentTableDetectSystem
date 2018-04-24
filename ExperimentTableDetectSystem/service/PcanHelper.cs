using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TPCANHandle = System.Byte;


namespace ExperimentTableDetectSystem.service
{
    public class PcanHelper
    {
        #region 字段
        private TPCANHandle m_PcanHandle;
        private TPCANBaudrate m_Baudrate;
        byte[] AllData = new byte[32];


        private delegate void ReadDelegateHandler();
        private AutoResetEvent m_ReceiveEvent;
        #endregion

        /// <summary>
        /// 单例模式
        /// </summary>
        private static volatile PcanHelper instance;
        private static object syncRoot = new Object();

        /// <summary>
        /// 公有方法获取单例
        /// </summary>
        /// <returns></returns>
        public static PcanHelper GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (syncRoot == null)
                    {
                        instance = new PcanHelper();
                    }
                }

            }
            return instance;
        }






        #region 方法
        public PcanHelper()
        {
            m_ReceiveEvent = new AutoResetEvent(false);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void initialize()
        {
            m_PcanHandle = PCANBasic.PCAN_USBBUS1;//通道
            m_Baudrate = TPCANBaudrate.PCAN_BAUD_500K;//波特率
            TPCANStatus result;                     //状态
            result = PCANBasic.Initialize(m_PcanHandle, m_Baudrate);//初始化
            if (result == TPCANStatus.PCAN_ERROR_OK)
            {
                ConfiguerTraceFile();
            }
            else { MessageBox.Show("pcanhelper初始化失败"); }
        }

        /// <summary>
        /// 设置一个通道的配置
        /// </summary>
        public TPCANStatus setValue()
        {
            UInt32 iBuffer;
            TPCANStatus stsResult;

            iBuffer = Convert.ToUInt32(m_ReceiveEvent.SafeWaitHandle.DangerousGetHandle().ToInt32());
            stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_RECEIVE_EVENT, ref iBuffer, sizeof(UInt32));
            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
            {
                //  MessageBox.Show(GetFormatedError(stsResult), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // return;
            }
            return stsResult;

        }


        /// <summary>
        /// Function for reading PCAN-Basic message 读pcan消息，返回数组
        /// </summary>
        public double[] ReadMessages()
        {
            double[] v = new double[11];//对外的实际值
            TPCANMsg CANMsg;
            TPCANTimestamp CANTimeStamp;
            TPCANStatus stsResult;
            // We read at least one time the queue looking for messages.
            // If a message is found, we look again trying to find more.
            // If the queue is empty or an error occurr, we get out from
            // the dowhile statement.
            //		
            do
            {
                stsResult = PCANBasic.Read(m_PcanHandle, out CANMsg, out CANTimeStamp);
                if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                {
                   // v = MyProcessMessage(CANMsg);//处理数据
                    v = ConvertToRealValue(CANMsg);
                }
            }
            while (!Convert.ToBoolean(stsResult & TPCANStatus.PCAN_ERROR_QRCVEMPTY));

            return v;
        }





        /// <summary>
        /// 收到消息后处理消息
        /// </summary>
        /// <param name="CANMsg"></param>
        /// <param name="CANTimeStamp"></param>
      //  int[] a = new int[4] { 0, 0, 0, 0 };
        /// <summary>
        /// 处理帧信息，解释成自己的值
        /// </summary>
        /// <param name="CANMsg"></param>
        /// <returns></returns>
        //public double[] MyProcessMessage(TPCANMsg CANMsg)
        //{
        //    #region 抱罐车处理数据
        //    double[] value = new double[11];

        //    if (CANMsg.ID != 0x184 && CANMsg.ID != 0x284 && CANMsg.ID != 0x384 && CANMsg.ID != 0x484)
        //    {
        //        return null;
        //    }
        //    if (CANMsg.ID == 0x184)
        //    {
        //        a[0] = 1;
        //        for (int i = 0; i < 8; i++)
        //            AllData[i] = CANMsg.DATA[i];
        //    }
        //    else if (CANMsg.ID == 0x284)
        //    {
        //        a[1] = 1;
        //        for (int i = 8; i < 16; i++)
        //            AllData[i] = CANMsg.DATA[i % 8];
        //    }
        //    else if (CANMsg.ID == 0x384)
        //    {
        //        a[2] = 1;
        //        for (int i = 16; i < 24; i++)
        //            AllData[i] = CANMsg.DATA[i % 8];
        //    }
        //    else if (CANMsg.ID == 0x484)
        //    {
        //        a[3] = 1;
        //        for (int i = 24; i < 32; i++)
        //            AllData[i] = CANMsg.DATA[i % 8];
        //    }

        //    if ((a[0] == 1) && (a[1] == 1) && (a[2] == 1) && (a[3] == 1))
        //    {

        //        //accuHighPre value 
        //        value[0] = (Convert.ToInt32(AllData[8]) * 100 + Convert.ToInt32(AllData[9]));
        //        //accuLowPre value
        //        value[1] = Convert.ToInt32(AllData[10]);
        //        //pmOutPre value
        //        value[2] = (Convert.ToInt32(AllData[11]) * 100 + Convert.ToInt32(AllData[12]));
        //        //pmInPre value
        //        value[3] = Convert.ToInt32(AllData[13]);
        //        //slipPumpPre value
        //        value[4] = Convert.ToInt32(AllData[14]);
        //        //carSpeed value
        //        value[5] = AllData[15];
        //        //engineSpeed value
        //        value[6] = (Convert.ToInt32(AllData[16]) * 100 + Convert.ToInt32(AllData[17]));
        //        //acceSign value
        //        value[7] = (Convert.ToInt32(AllData[18]) * 100 + Convert.ToInt32(AllData[19])) / 10.0;
        //        //brakeSign value
        //        value[8] = (Convert.ToInt32(AllData[20]) * 100 + Convert.ToInt32(AllData[21])) / 10.0;
        //        //moterDisplacement value
        //        value[9] = Convert.ToInt32(AllData[30]);
        //        //pumpDisplacement value
        //        value[10] = Convert.ToInt32(AllData[31]);

        //        //ReceivelistMsg.Add(value);
        //        a[0] = a[1] = a[2] = a[3] = 0;

        //    }
        //    return value;
        //    #endregion

        //}

        public double[] ConvertToRealValue(TPCANMsg CanMsg)
        {
            double[] realValue = new double[52];

            byte[] AllDatas = new byte[96];
            int[] temp = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            if (CanMsg.ID != 0x280 && CanMsg.ID != 0x281 && CanMsg.ID != 0x282 && CanMsg.ID != 0x283 && CanMsg.ID != 0x284 && CanMsg.ID != 0x285 && CanMsg.ID != 0x286 && CanMsg.ID != 0x287 && CanMsg.ID != 0x288 && CanMsg.ID != 0x289 && CanMsg.ID != 0x290 && CanMsg.ID != 0x291)//
            {
                return null;
            }
            if (CanMsg.ID == 0x280)
            {
                temp[0] = 1;
                for (int i = 0; i < 8; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i];
                }
            }
            else if (CanMsg.ID == 0x281)
            {
                temp[1] = 0;
                for (int i = 8; i < 16; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];

                }
            }
            else if (CanMsg.ID == 0x282)
            {
                temp[2] = 0;
                for (int i = 16; i < 24; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x283)
            {
                temp[3] = 0;
                for (int i = 24; i < 32; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x284)
            {
                temp[4] = 0;
                for (int i = 32; i < 40; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x285)
            {
                temp[5] = 0;
                for (int i = 40; i < 48; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x286)
            {
                temp[6] = 0;
                for (int i = 48; i < 56; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x287)
            {
                temp[7] = 0;
                for (int i = 56; i < 64; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x288)
            {
                temp[8] = 0;
                for (int i = 64; i < 72; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x289)
            {
                temp[9] = 0;
                for (int i = 72; i < 80; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x290)
            {
                temp[10] = 0;
                for (int i = 80; i < 88; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x291)
            {
                temp[11] = 0;
                for (int i = 88; i < 96; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            if (temp[0] == 1 && temp[1] == 1 && temp[2] == 1 && temp[3] == 1 & temp[4] == 1 & temp[5] == 1 && temp[6] == 1 && temp[7] == 1 && temp[8] == 1 && temp[9] == 1 & temp[10] == 1 & temp[11] == 1)
            {
                #region 将数值解析存到数组里
                //1 主泵1流量
                //2 主泵2流量
                //3 转向流量
                //4 泄露流量
                //5 主泵1压力
                //6 主泵2压力
                //7 转向压力
                //8 中位压力损失
                //9 小门架上升位移
                //10 小门架上升压力损失
                int pump1Flow = Convert.ToInt32(AllDatas[0]);
                int pump2Flow = Convert.ToInt32(AllDatas[1]);
                int steerFlow = Convert.ToInt32(AllDatas[2]);
                int leakageFlow = Convert.ToInt32(AllDatas[3]);
                int mainPump1Pressure = Convert.ToInt32(AllDatas[16]) * 100 + Convert.ToInt32(AllDatas[17]);
                int mainPump2Pressure = Convert.ToInt32(AllDatas[18]) * 100 + Convert.ToInt32(AllDatas[19]);
                int steerPressure = Convert.ToInt32(AllDatas[20]) * 100 + Convert.ToInt32(AllDatas[21]);
                int mediumPressureLoss = Convert.ToInt32(AllDatas[22]);

                int smallUpDis = Convert.ToInt32(AllDatas[23]) * 100 + Convert.ToInt32(AllDatas[24]);
                int smallUpPressureLoss = Convert.ToInt32(AllDatas[26]);

                //11 小门架下降位移
                //12 小门架下降压力损失
                //13 大门架上升位移
                //14 大门架上升压力损失
                //15 大门架下降位移
                //16 大门架下降压力损失
                //17 小门架前倾位移
                //18 小门架前倾进油口压力损失
                //19 小门架前倾出油口压力损失
                //20 小门架后倾位移

                int smallDownDis = f2(AllData[27], AllDatas[28]);
                int smallDownPressureLoss = f1(AllDatas[30]);

                int bigUpDis = f2(AllDatas[31], AllDatas[32]);
                int bigUpPressureLoss = f1(AllDatas[34]);
                int bigDownDis = f2(AllDatas[35], AllDatas[36]);
                int bigDownPressureLoss = f1(AllDatas[38]);

                int smallForwardDis = f2(AllDatas[39], AllDatas[40]);
                int smallForwardInLoss = f1(AllDatas[42]);
                int smallForwardOutLoss = f1(AllDatas[43]);
                int smallBackDis = f2(AllDatas[44], AllDatas[45]);

                //21 小门架后倾进油口压力损失
                //22 小门架后倾出油口压力损失
                //23 大门架前倾位移
                //24 大门架前倾进油口压力损失
                //25 大门架前倾出油口压力损失
                //26 大门架后倾位移
                //27 大门架后倾进油口压力损失
                //28 大门架后倾出油口压力损失
                //29 手动1实验结束标志
                //30 手动2实验结束标志
                 
                int smallBackInLoss = f1(AllDatas[47]);
                int smallBackOutLoss = f1(AllDatas[48]);

                int bigForwardDis = f2(AllDatas[49], AllDatas[50]);
                int bigForwardInLoss = f1(AllDatas[52]);
                int bigForwardOutLoss = f1(AllDatas[53]);
                int bigBackDis = f2(AllDatas[54], AllDatas[55]);
                int bigBackInLoss = f1(AllDatas[57]);
                int bigBackOutLoss = f1(AllDatas[58]);

                int shoudong1 = f1(AllDatas[60]);
                int shoudong2 = f1(AllDatas[61]);

                //31 中位压力损失测试结束
                //32 转向优先阀流量测试结束
                //33 小门架上升实验结束
                //34 小门架下降实验结束
                //35 大门架上升实验结束
                //36 大门架下降
                //37 小门架前倾
                //38 小门架后倾
                //39 大门架前倾
                //40 大门架后倾
                int endFlag3= f1(AllDatas[62]);
                int endFlag4 = f1(AllDatas[63]);
                int endFlag5 = f1(AllDatas[64]);
                int endFlag6 = f1(AllDatas[65]);
                int endFlag7 = f1(AllDatas[66]);
                int endFlag8 = f1(AllDatas[67]);
                int endFlag9 = f1(AllDatas[68]);
                int endFlag10 = f1(AllDatas[69]);
                int endFlag11 = f1(AllDatas[70]);
                int endFlag12 = f1(AllDatas[71]);

                //41 内泄漏测试结束标志
                //42 小门架前倾自锁实验结束
                //43 大门架前倾自锁实验结束
                //44 推动滑阀力1
                //45 推动滑阀力2
                //46 推动滑阀力3
                //47 推动滑阀力4
                //48 系统背压
                //49 油缸压力
                //50 油缸进油口压力
                //51 油缸回油压力
                int endFlag13leakageTest= f1(AllDatas[72]);
                int endFlag14 = f1(AllDatas[73]);
                int endFlag15 = f1(AllDatas[74]);

                int force1 = f1(AllDatas[76]);
                int force2 = f1(AllDatas[77]);
                int force3 = f1(AllDatas[78]);
                int force4 = f1(AllDatas[79]);
                int systemBeiPressure = f1(AllDatas[80]);
                int oilPressure = f2(AllDatas[81], AllDatas[82]);
                int oilInPressure = f2(AllDatas[83], AllDatas[84]);

                int oilOutPressure = f2(AllDatas[85], AllDatas[86]);



                realValue[0] = pump1Flow;
                realValue[1] = pump2Flow;
                realValue[2] = steerFlow;
                realValue[3] = leakageFlow;
                realValue[4] = mainPump1Pressure;
                realValue[5] = mainPump2Pressure;
                realValue[6] = steerPressure;
                realValue[7] = mediumPressureLoss;
                realValue[8] = smallUpDis;
                realValue[9] = smallUpPressureLoss;

                realValue[10] = smallDownDis;
                realValue[11] = smallDownPressureLoss;
                realValue[12] = bigUpDis;
                realValue[13] = bigUpPressureLoss;
                realValue[14] = bigDownDis;
                realValue[15] = bigDownPressureLoss;
                realValue[16] = smallForwardDis;
                realValue[17] = smallForwardInLoss;
                realValue[18] = smallForwardOutLoss;
                realValue[19] = smallBackDis;

                realValue[20] = smallBackInLoss;
                realValue[21] = smallBackOutLoss;
                realValue[22] = bigForwardDis;
                realValue[23] = bigForwardInLoss;
                realValue[24] = bigForwardOutLoss;
                realValue[25] = bigBackDis;
                realValue[26] = bigBackInLoss;
                realValue[27] = bigBackOutLoss;
                realValue[28] = shoudong1;
                realValue[29] = shoudong2;

                realValue[30] = endFlag3;
                realValue[31] = endFlag4;
                realValue[32] = endFlag5;
                realValue[33] = endFlag6;
                realValue[34] = endFlag7;
                realValue[35] = endFlag8;
                realValue[36] = endFlag9;
                realValue[37] = endFlag10;
                realValue[38] = endFlag11;
                realValue[39] = endFlag12;
                realValue[40] = endFlag13leakageTest;
                realValue[41] = endFlag14;
                realValue[42] = endFlag15;

                realValue[43] = force1;
                realValue[44] = force2;
                realValue[45] = force3;
                realValue[46] = force4;

                realValue[47] = systemBeiPressure;
                realValue[48] = oilPressure;
                realValue[49] = oilInPressure;
                realValue[50] = oilOutPressure;
                #endregion
                for (int i = 0; i < 12; i++)
                {
                    temp[i] = 0;
                }
            }
            return realValue;

        }

        public int f1(byte a)
        {
            return Convert.ToInt32(a);
        }
        public int f2(byte a,byte b)
        {
            return Convert.ToInt32(a) * 100 + Convert.ToInt32(b);
        }

        /// <summary>
        /// 关闭PCAN
        /// </summary>
        public void close()
        {
            PCANBasic.Uninitialize(m_PcanHandle);

        }

        /// <summary>
        /// 得到通道名
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public string FormatChannelName(TPCANHandle handle)
        {
            TPCANDevice m_device;
            byte byChannel;
            m_device = (TPCANDevice)(handle >> 4);//转换成16进制
            byChannel = (byte)(handle & 0xF);

            return string.Format("{0} {1}({2:X2}h)", m_device, byChannel, handle);
        }

        /// <summary>
        /// 配置日志信息
        /// </summary>
        public void ConfiguerLogFile()
        {
            UInt32 iBuffer;
            iBuffer = PCANBasic.LOG_FUNCTION_ALL;
            PCANBasic.SetValue(PCANBasic.PCAN_NONEBUS, TPCANParameter.PCAN_LOG_CONFIGURE, ref iBuffer, sizeof(UInt32));

        }

        /// <summary>
        /// 如果初始化成功，则配置通道
        /// </summary>
        public void ConfiguerTraceFile()
        {
            UInt32 iBuffer;
            TPCANStatus stsResult;
            //Configure the maximum size of a trace file to 5 megabytes
            //
            iBuffer = 5;
            stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_TRACE_SIZE,
                       ref iBuffer, sizeof(UInt32));
            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
                // tsslCANStatus.Text = GetFormatedError(stsResult);

                // Configure the way how trace files are created: 
                // * Standard name is used
                // * Existing file is ovewritten, 
                // * Only one file is created.
                // * Recording stopts when the file size reaches 5 megabytes.
                //
                iBuffer = PCANBasic.TRACE_FILE_SINGLE | PCANBasic.TRACE_FILE_OVERWRITE;
            stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_TRACE_CONFIGURE, ref iBuffer, sizeof(UInt32));
            //  if (stsResult != TPCANStatus.PCAN_ERROR_OK)
            // tsslCANStatus.Text = GetFormatedError(stsResult);

        }

        /// <summary>
        /// 获取错误详细信息
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public string GetFormatedError(TPCANStatus error)
        {
            StringBuilder strTemp = new StringBuilder(256);
            if (PCANBasic.GetErrorText(error, 0, strTemp) != TPCANStatus.PCAN_ERROR_OK)
                return string.Format("An error occurred. Error-code's text({0:X}) couldn't be retrieved", error);
            else
                return strTemp.ToString();
        }
        #endregion

        /// <summary>
        /// 发送数据函数
        /// </summary>
        /// <param name="CANMsg"></param>
        public TPCANStatus writeee(TPCANMsg CANMsg)
        {
            return PCANBasic.Write(m_PcanHandle, ref CANMsg);
        }

    }
}
