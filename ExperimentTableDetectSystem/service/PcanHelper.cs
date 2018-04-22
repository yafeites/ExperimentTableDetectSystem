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
        public double[] value=new double[11];
       
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
            if(instance==null)
            {
                lock (syncRoot)
                { if (syncRoot == null)
                    {
                        instance = new PcanHelper();
                    }
                }

            }return instance;
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
                    v = MyProcessMessage(CANMsg);//处理数据
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
        int[] a = new int[4] { 0, 0, 0, 0 };
        /// <summary>
        /// 处理帧信息，解释成自己的值
        /// </summary>
        /// <param name="CANMsg"></param>
        /// <returns></returns>
        public double[] MyProcessMessage(TPCANMsg CANMsg)
        {
            value = new double[11];
            if (CANMsg.ID != 0x184 && CANMsg.ID != 0x284 && CANMsg.ID != 0x384 && CANMsg.ID != 0x484)
            {
                return null;
            }
            if (CANMsg.ID == 0x184)
            {
                a[0] = 1;
                for (int i = 0; i < 8; i++)
                    AllData[i] = CANMsg.DATA[i];
            }
            else if (CANMsg.ID == 0x284)
            {
                a[1] = 1;
                for (int i = 8; i < 16; i++)
                    AllData[i] = CANMsg.DATA[i % 8];
            }
            else if (CANMsg.ID == 0x384)
            {
                a[2] = 1;
                for (int i = 16; i < 24; i++)
                    AllData[i] = CANMsg.DATA[i % 8];
            }
            else if (CANMsg.ID == 0x484)
            {
                a[3] = 1;
                for (int i = 24; i < 32; i++)
                    AllData[i] = CANMsg.DATA[i % 8];
            }

            if ((a[0] == 1) && (a[1] == 1) && (a[2] == 1) && (a[3] == 1))
            {

                //accuHighPre value 
                value[0] = (Convert.ToInt32(AllData[8]) * 100 + Convert.ToInt32(AllData[9]));
                //accuLowPre value
                value[1] = Convert.ToInt32(AllData[10]);
                //pmOutPre value
                value[2] = (Convert.ToInt32(AllData[11]) * 100 + Convert.ToInt32(AllData[12]));
                //pmInPre value
                value[3] = Convert.ToInt32(AllData[13]);
                //slipPumpPre value
                value[4] = Convert.ToInt32(AllData[14]);
                //carSpeed value
                value[5] = AllData[15];
                //engineSpeed value
                value[6] = (Convert.ToInt32(AllData[16]) * 100 + Convert.ToInt32(AllData[17]));
                //acceSign value
                value[7] = (Convert.ToInt32(AllData[18]) * 100 + Convert.ToInt32(AllData[19])) / 10.0;
                //brakeSign value
                value[8] = (Convert.ToInt32(AllData[20]) * 100 + Convert.ToInt32(AllData[21])) / 10.0;
                //moterDisplacement value
                value[9] = Convert.ToInt32(AllData[30]);
                //pumpDisplacement value
                value[10] = Convert.ToInt32(AllData[31]);

                //ReceivelistMsg.Add(value);
                a[0] = a[1] = a[2] = a[3] = 0;
         
            }
            return value;


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
        public void writeee(TPCANMsg CANMsg)
        {
            PCANBasic.Write(m_PcanHandle, ref CANMsg);
        }

    }
}
