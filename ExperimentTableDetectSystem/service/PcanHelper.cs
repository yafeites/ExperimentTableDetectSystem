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
        byte[] AllDatas = new byte[112];
        //byte[] AllData = new byte[32];
        double[] realValue;
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
            else { throw new Exception("pcanhelper初始化失败"); }
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
            double[] v = new double[76];//对外的实际值
            TPCANMsg CANMsg;
            TPCANTimestamp CANTimeStamp;
            TPCANStatus stsResult;

            for (int i = 0; i < 76; i++) { v[i] = 0; }
            do
            {
                stsResult = PCANBasic.Read(m_PcanHandle, out CANMsg, out CANTimeStamp);
                if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                {

                    v = ConvertToRealValue(CANMsg);
                    //   v = testrealvalue(CANMsg);
                    // v = MyProcessMessage(CANMsg);
                }
            }
            while (!Convert.ToBoolean(stsResult & TPCANStatus.PCAN_ERROR_QRCVEMPTY));

            return v;
        }



        public double[] ConvertToRealValue(TPCANMsg CanMsg)
        {
            realValue = new double[76];


           // int[] temp = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            //  if (CanMsg.ID != 0x280 && CanMsg.ID != 0x281 && CanMsg.ID != 0x282 && CanMsg.ID != 0x283 && CanMsg.ID != 0x284 && CanMsg.ID != 0x285 && CanMsg.ID != 0x286 && CanMsg.ID != 0x287 && CanMsg.ID != 0x288 && CanMsg.ID != 0x289 && CanMsg.ID != 0x290 && CanMsg.ID != 0x291)//
            //   {
            // return null;
            //   }
            //把289的第一帧数据换成222的第二帧
           // if (CanMsg.ID == 0x222)
            //{
           //     AllDatas[72] = CanMsg.DATA[1];
           // }

             if (CanMsg.ID == 0x301)
            {
                //temp[0] = 1;
                for (int i = 0; i < 8; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i];
                }
            }
            else if (CanMsg.ID == 0x302)
            {
               // temp[1] = 1;
                for (int i = 8; i < 16; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];

                }
            }
            else if (CanMsg.ID == 0x303)
            {
                //temp[2] = 1;
                for (int i = 16; i < 24; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x304)
            {
              //  temp[3] = 1;
                for (int i = 24; i < 32; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x305)
            {
               // temp[4] = 1;
                for (int i = 32; i < 40; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x306)
            {
                //temp[5] = 1;
                for (int i = 40; i < 48; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x307)
            {
               // temp[6] = 1;
                for (int i = 48; i < 56; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x308)
            {
               // temp[7] = 1;
                for (int i = 56; i < 64; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x310)
            {
               // temp[8] = 1;
                for (int i = 64; i < 72; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x401)
            {
               // temp[9] = 1;
                for (int i = 72; i < 80; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x402)
            {
                //temp[10] = 1;
                for (int i = 80; i < 88; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x403)
            {
                //temp[11] = 1;
                for (int i = 88; i < 96; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x309)
            {
                // temp[7] = 1;
                for (int i = 96; i < 104; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }
            else if (CanMsg.ID == 0x313)
            {
                // temp[7] = 1;
                for (int i = 104; i < 112; i++)
                {
                    AllDatas[i] = CanMsg.DATA[i % 8];
                }
            }


            //    if (temp[0] == 1 && temp[1] == 1 && temp[2] == 1 && temp[3] == 1 & temp[4] == 1 & temp[5] == 1 && temp[6] == 1 && temp[7] == 1 && temp[8] == 1 && temp[9] == 1 & temp[10] == 1 & temp[11] == 1)
            // {
            #region 将数值解析存到数组里
            //0 中位压力损失测试结束
            //1 门架上升结束
            //2 门架后倾结束
            //3 门架前倾结束
            //4 门架前倾动作检测结束
            //5 门架前倾自锁结束
            //6 泄露保压升降结束
            //7 内泄露A口结束
            //8 内泄露B口结束
            //9 门架下降结束
            int endFlag3 = f1(AllDatas[0]);
            int endFlag4 = f1(AllDatas[1]);
            int endFlag13leakageTest = f1(AllDatas[2]);
            int endFlag5 = f1(AllDatas[3]);
            int endFlag6 = f1(AllDatas[4]);
            int endFlag7 = f1(AllDatas[5]);
            int endFlag8 = f1(AllDatas[6]);
            int endFlag9 = f1(AllDatas[7]);
            int endFlag10 = f1(AllDatas[8]);
            int endFlag11 = f1(AllDatas[9]);

            //10 主泵1压力
            //11 主泵2压力
            //12 转向压力
            //13 推动滑阀力进口力
            //14 推动滑阀力出口力
            int mainPump1Pressure = Convert.ToInt32(AllDatas[16]) * 100 + Convert.ToInt32(AllDatas[17]);
            int mainPump2Pressure = Convert.ToInt32(AllDatas[18])* 100 + Convert.ToInt32(AllDatas[19]);
            int steerPressure = Convert.ToInt32(AllDatas[20]) * 100 + Convert.ToInt32(AllDatas[21]);
            int forceIn = Convert.ToInt32(AllDatas[22]) * 100 + Convert.ToInt32(AllDatas[23]);
            int forceOut = Convert.ToInt32(AllDatas[24]) * 100 + Convert.ToInt32(AllDatas[25]);

            //15 系统背压
            //16 油缸压力
            //17 油缸进口压力
            //18 油缸回油压力
            //19 中位压力损失
            //20 门架升降位移
            //21 门架倾斜位移
            //22 门架上升压力损失
            int systemBeiPressure = f1(AllDatas[26]);
            int oilPressure = f2(AllDatas[27], AllDatas[28]);
            int oilInPressure = f2(AllDatas[29], AllDatas[30]);
            int oilOutPressure = f2(AllDatas[31], AllDatas[32]);
            int mediumPressureLoss = f2(AllDatas[33], AllDatas[44]);
            int VerticalDis = f2(AllDatas[34], AllDatas[35]);
            int LeanDis = f2(AllDatas[36], AllDatas[37]);
            int UpPressureLoss = Convert.ToInt32(AllDatas[38]);

            //23 门架下降压力损失
            //24 门架前倾（自锁）进口压力损失
            //25 门架前倾（自锁）出口压力损失
            //26 门架后倾进口压力损失
            //27 门架后倾出口压力损失
            int DownPressureLoss = f1(AllDatas[39]);
            int ForwardInLoss = f1(AllDatas[40]);
            int ForwardOutLoss = f1(AllDatas[41]);
            int BackInLoss = f1(AllDatas[42]);
            int BackOutLoss = f1(AllDatas[43]);


            //28 推动滑阀1复位，5.28改为过载阀A1口实验状态
            //29 推动滑阀2复位，5.28改为过载阀A2口实验状态
            //30 推动滑阀3复位，5.28改为过载阀B1口实验状态
            //31 推动滑阀4复位，5.28改为过载阀B2口实验状态
            //32 滤油器1报警
            //33 滤油器2报警
            //34 滤油器3报警
            //35 先导压力
            //36 主泵1流量
            int slideValve1Reset = f1(AllDatas[58]);
            int slideValve2Reset = f1(AllDatas[59]);
            int slideValve3Reset = f1(AllDatas[60]);
            int slideValve4Reset = f1(AllDatas[61]);
            int oilFilter1Alarm = f1(AllDatas[64]);
            int oilFilter2Alarm = f1(AllDatas[65]);
            int oilFilter3Alarm = f1(AllDatas[66]);
            int pilotPressre = f3(AllDatas[67], AllDatas[68]);
            int pump1Flow = f3(AllDatas[72], AllDatas[73]);

            //37 主泵2流量
            //38 转向流量
            //39 泄漏流量
            //40 备用压力传感器1压力
            //41 备用压力传感器2压力(3.12日由于口子不够暂改为新增回油流量)
            //42 备用压力传感器3压力
            //43 备用压力传感器4压力
            //44 油箱温度
            //45 泵1出口温度
            //46 泵2出口温度
            int pump2Flow = f3(AllDatas[74], AllDatas[75]);
            int steerFlow = Convert.ToInt32(AllDatas[76])*100;
            int leakageFlow = f3(AllDatas[77], AllDatas[94]);
            int standbyPressure1 = f3(AllDatas[78], AllDatas[79]);
            int backflow = f3(AllDatas[80], AllDatas[81]);
            int standbyPressure3 = f3(AllDatas[82], AllDatas[83]);
            int standbyPressure4 = f3(AllDatas[84], AllDatas[85]);
            int tankTemp = f1(AllDatas[87]);
            int pump1OutTemp = f1(AllDatas[88]);
            int pump2OutTemp = f1(AllDatas[89]);

            //47 备用位移传感器1位移
            //48 备用位移传感器2位移
            //49 Q1-1的状态 //6.13改为备用1口中位泄漏试验状态
            //50 Q1-2的状态               2
            //51 Q2-1的状态               3
            //52 Q2-2的状态               4
            //53 主泵1压力超限信号
            //54 主泵2压力超限信号
            //55 内泄露流量超限信号
            //56 转向溢流阀实验状态
            //57 主溢流阀实验状态
            //58 换向泄露压力达到
            //59  下降动作检测后泄压状态
            //60 上升回程位移
            //61 前倾回程位移
            //62 后倾回程位移
            //63 过载阀A1口调定实验状态
            //64 过载阀B1口调定实验状态

            //65 换向泄露前倾口测试
            //66 换向泄露后倾口测试
            //67 换向泄露备用1口测试
            //68 换向泄露备用2口测试
            //69 换向泄露备用3口测试
            //70 换向泄露备用4口测试


            int standbyDis1 = f3(AllDatas[90], AllDatas[91]);
            int standbyDis2 = f3(AllDatas[92], AllDatas[93]);
            int q11State = f1(AllDatas[96]);
            int q12State = f1(AllDatas[97]);
            int q21State = f1(AllDatas[98]);
            int q22State = f1(AllDatas[99]);
            int pump1TooHigh = f1(AllDatas[100]);
            int pump2TooHigh = f1(AllDatas[101]);
            int overFlow = f1(AllDatas[86]);
            int steerLeakage = f1(AllDatas[48]);
            int mainLeakage = f1(AllDatas[49]);
            int changeLeakage = f1(AllDatas[50]);
            int end = AllDatas[12];
            int testUpDis = AllDatas[45];
            int testForwardDis = AllDatas[46];
            int testBackDis = AllDatas[47];
            int overflowA1Test = AllDatas[52];
            int overflowB1Test = AllDatas[53];

            int changeA = AllDatas[104];
            int changeB = AllDatas[105];
            int spare1 = AllDatas[106];
            int spare2 = AllDatas[107];
            int spare3 = AllDatas[108];
            int spare4 = AllDatas[109];

            //71 过载阀A2口调定实验状态
            //72 过载阀B2口调定实验状态
            //73 换向泄露上升口测试
            //74 转向阀启闭特性实验状态
            //75 主阀启闭特性实验状态

            int overflowA2Test = AllDatas[54];
            int overflowB2Test = AllDatas[55];
            int changeUp = f1(AllDatas[51]);
            int steerQb = AllDatas[13];
            int mainQb = AllDatas[14];

            realValue[0] = endFlag3;
            realValue[1] = endFlag4;
            realValue[2] = endFlag13leakageTest;
            realValue[3] = endFlag5;
            realValue[4] = endFlag6;
            realValue[5] = endFlag7;
            realValue[6] = endFlag8;
            realValue[7] = endFlag9;
            realValue[8] = endFlag10;
            realValue[9] = endFlag11;

            realValue[10] = mainPump1Pressure;
            realValue[11] = mainPump2Pressure;
            realValue[12] = steerPressure;
            realValue[13] = forceIn;
            realValue[14] = forceOut;
            realValue[15] = systemBeiPressure;
            realValue[16] = oilPressure;
            realValue[17] = oilInPressure;
            realValue[18] = oilOutPressure;
            realValue[19] = mediumPressureLoss;

            realValue[20] = VerticalDis;
            realValue[21] = LeanDis;
            realValue[22] = UpPressureLoss;
            realValue[23] = DownPressureLoss; 
            realValue[24] = ForwardInLoss;
            realValue[25] = ForwardOutLoss;
            realValue[26] = BackInLoss;
            realValue[27] = BackOutLoss;
            realValue[28] = slideValve1Reset;
            realValue[29] = slideValve2Reset;

            realValue[30] = slideValve3Reset;
            realValue[31] = slideValve4Reset;
            realValue[32] = oilFilter1Alarm;
            realValue[33] = oilFilter2Alarm;
            realValue[34] = oilFilter3Alarm;
            realValue[35] = pilotPressre;
            realValue[36] = pump1Flow;
            realValue[37] = pump2Flow;
            realValue[38] = steerFlow;
            realValue[39] = leakageFlow;

            realValue[40] = standbyPressure1;
            realValue[41] = backflow;
            realValue[42] = standbyPressure3;
            realValue[43] = standbyPressure4;
            realValue[44] = tankTemp;
            realValue[45] = pump1OutTemp;
            realValue[46] = pump2OutTemp;
            realValue[47] = standbyDis1;
            realValue[48] = standbyDis2;
            realValue[49] = q11State;

            realValue[50] = q12State;
            realValue[51] = q21State;
            realValue[52] = q22State;
            realValue[53] = pump1TooHigh;
            realValue[54] = pump2TooHigh;
            realValue[55] = overFlow;
            realValue[56] = steerLeakage;
            realValue[57] = mainLeakage;
            realValue[58] = changeLeakage;
            realValue[59] = end;
            realValue[60] = testUpDis;
            realValue[61] = testForwardDis;
            realValue[62] = testBackDis;
            realValue[63] = overflowA1Test;
            realValue[64] = overflowB1Test;
            realValue[65] = changeA;
            realValue[66] = changeB;
            realValue[67] = spare1;
            realValue[68] = spare2;
            realValue[69] = spare3;
            realValue[70] = spare4;

            realValue[71] = overflowA2Test;
            realValue[72] = overflowB2Test;
            realValue[73] = changeUp;
            realValue[74] = steerQb;
            realValue[75] = mainQb;


            #endregion
            //   for (int i = 0; i < 12; i++)
            //  {
            //     temp[i] = 0;
            //  }
            // }
            return realValue;

        }


        public int f1(byte a)
        {
            return Convert.ToInt32(a);
        }
        public int f2(byte a, byte b)
        {
            return Convert.ToInt32(a) * 100 + Convert.ToInt32(b);
        }
        public int f3(byte a,byte b)
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