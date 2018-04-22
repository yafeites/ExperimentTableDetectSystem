using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ExperimentTableDetectSystem.service
{
    using System.Runtime.InteropServices;
    using TPCANHandle = System.Byte;

    #region Enumerations
    /// <summary>
    /// Represents a PCAN status/error code
    /// </summary>
    [Flags]
    public enum TPCANStatus : uint
    {
        PCAN_ERROR_OK = 0X00000,
        PCAN_ERROR_XMTFULL = 0X00001,
        PCAN_ERROR_OVERRUN = 0x00002,
        PCAN_ERROR_BUSLIGHT = 0x00004,
        PCAN_ERROR_BUSHEAVY = 0x00008,
        PCAN_ERROR_BUSOFF = 0x00010,
        PCAN_ERROR_ANYBUSERR = (PCAN_ERROR_BUSLIGHT | PCAN_ERROR_BUSHEAVY | PCAN_ERROR_BUSOFF),
        PCAN_ERROR_QRCVEMPTY = 0x00020,
        PCAN_ERROR_QOVERRUN = 0x00040,
        PCAN_ERROR_QXMTFULL = 0x00080,
        PCAN_ERROR_REGTEST = 0x00100,
        PCAN_ERROR_NODRIVER = 0x00200,
        PCAN_ERROR_HWINUSE = 0x00400,
        PCAN_ERROR_NETINUSE = 0x00800,
        PCAN_ERROR_ILLHW = 0x01400,
        PCAN_ERROR_ILLNET = 0x01800,
        PCAN_ERROR_ILLCLIENT = 0x01C00,
        PCAN_ERROR_ILLHANDLE = (PCAN_ERROR_ILLHW | PCAN_ERROR_ILLNET | PCAN_ERROR_ILLCLIENT),
        PCAN_ERROR_RESOURCE = 0x02000,
        PCAN_ERROR_ILLPARAMTYPE = 0x04000,
        PCAN_ERROR_ILLPARAMVAL = 0x08000,
        PCAN_ERROR_UNKNOWN = 0x10000,
        PCAN_ERROR_ILLDATA = 0x20000,
        PCAN_ERROR_INITIALIZE = 0x40000,
        PCAN_ERROR_ILLOPERATION = 0x80000,
    }

    /// <summary>
    /// Represents a PCAN device
    /// </summary>
    public enum TPCANDevice : byte
    {
        PCAN_NONE = 0,
        PCAN_PEAKCAN = 1,
        PCAN_ISA = 2,
        PCAN_DNG = 3,
        PCAN_PCI = 4,
        PCAN_USB = 5,
        PCAN_PCC = 6
    }

    /// <summary>
    /// Represents a PCAN parameter to be read or set
    /// </summary>
    public enum TPCANParameter : byte
    {
        PCAN_DEVICE_NUMBER = 1,
        PCAN_5VOLTS_POWER = 2,
        PCAN_RECEIVE_EVENT = 3,
        PCAN_MESSAGE_FILTER = 4,
        PCAN_API_VERSION = 5,
        PCAN_CHANNEL_VERSION = 6,
        PCAN_BUSOFF_AUTORESET = 7,
        PCAN_LISTEN_ONLY = 8,
        PCAN_LOG_LOCATION = 9,
        PCAN_LOG_STATUS = 10,
        PCAN_LOG_CONFIGURE = 11,
        PCAN_LOG_TEXT = 12,
        PCAN_CHANNEL_CONDITION = 13,
        PCAN_HARDWARE_NAME = 14,
        PCAN_RECEIVE_STATUS = 15,
        PCAN_CONTROLLER_NUMBER = 16,
        PCAN_TRACE_LOCATION = 17,
        PCAN_TRACE_STATUS = 18,
        PCAN_TRACE_SIZE = 19,
        PCAN_TRACE_CONFIGURE = 20,
        PCAN_CHANNEL_IDENTIFYING = 21,
    }

    /// <summary>
    /// Represents the type of a PCAN message
    /// </summary>
    [Flags]
    public enum TPCANMessageType : byte
    {
        PCAN_MESSAGE_STANDARD = 0x00,
        PCAN_MESSAGE_RTR = 0x01,
        PCAN_MESSAGE_EXTENDED = 0x02,
        PCAN_MESSAGE_STATUS = 0x80,
    }

    /// <summary>
    /// Represents a PCAN filter mode
    /// </summary>
    public enum TPCANMode : byte
    {
        PCAN_MODE_STANDARD = TPCANMessageType.PCAN_MESSAGE_STANDARD,
        PCAN_MODE_EXTENDED = TPCANMessageType.PCAN_MESSAGE_EXTENDED,
    }

    /// <summary>
    /// Represents a PCAN Baud rate register value
    /// </summary>
    public enum TPCANBaudrate : ushort
    {
        PCAN_BAUD_1M = 0x0014,
        PCAN_BAUD_800K = 0x0016,
        PCAN_BAUD_500K = 0x001C,
        PCAN_BAUD_250K = 0x011C,
        PCAN_BAUD_125K = 0x031C,
        PCAN_BAUD_100K = 0x432F,
        PCAN_BAUD_95K = 0xC34E,
        PCAN_BAUD_83K = 0x852B,
        PCAN_BAUD_50K = 0x472F,
        PCAN_BAUD_47K = 0x1414,
        PCAN_BAUD_33K = 0x8B2F,
        PCAN_BAUD_20K = 0x532F,
        PCAN_BAUD_10K = 0x672F,
        PCAN_BAUD_5K = 0x7F7F,
    }

    /// <summary>
    /// Represents the type of PCAN (non plug&play) hardware to be initialized
    /// </summary>
    public enum TPCANType : byte
    {
        PCAN_TYPE_ISA = 0x01,
        PCAN_TYPE_ISA_SJA = 0x09,
        PCAN_TYPE_ISA_PHYTEC = 0x04,
        PCAN_TYPE_DNG = 0x02,
        PCAN_TYPE_DNG_EPP = 0x03,
        PCAN_TYPE_DNG_SJA = 0x05,
        PCAN_TYPE_DNG_SJA_EPP = 0x06,
    }

    #endregion

    #region Structures
    /// <summary>
    /// Represents a PCAN message
    /// </summary>
    public struct TPCANMsg
    {
        public uint ID;
        [MarshalAs(UnmanagedType.U1)]
        public TPCANMessageType MSGTYPE;
        public byte LEN;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] DATA;
    }

    /// <summary>
    /// Represents a timestamp of a received PCAN message.
    /// Total Microseconds = micros + 1000 * millis + 0xFFFFFFFF * 1000 * millis_overflow
    /// </summary>
    public struct TPCANTimestamp
    {
        public uint millis;
        public ushort millis_overflow;
        public ushort micros;
    }

    #endregion
    #region PCANBasic class
    public static class PCANBasic
    {

        #region PCAN_BUS Handles Definition
        /// <summary>
        /// Undefined/default value for a PCAN bus
        /// </summary>
        public const TPCANHandle PCAN_NONEBUS = 0x00;
        public const TPCANHandle PCAN_ISABUS1 = 0x21;
        public const TPCANHandle PCAN_ISABUS2 = 0x22;
        public const TPCANHandle PCAN_ISABUS3 = 0x23;
        public const TPCANHandle PCAN_ISABUS4 = 0x24;
        public const TPCANHandle PCAN_ISABUS5 = 0x25;
        public const TPCANHandle PCAN_ISABUS6 = 0x26;
        public const TPCANHandle PCAN_ISABUS7 = 0x27;
        public const TPCANHandle PCAN_ISABUS8 = 0x28;
        public const TPCANHandle PCAN_DNGBUS1 = 0x31;
        public const TPCANHandle PCAN_PCIBUS1 = 0x41;
        public const TPCANHandle PCAN_PCIBUS2 = 0x42;
        public const TPCANHandle PCAN_PCIBUS3 = 0x43;
        public const TPCANHandle PCAN_PCIBUS4 = 0x44;
        public const TPCANHandle PCAN_PCIBUS5 = 0x45;
        public const TPCANHandle PCAN_PCIBUS6 = 0x46;
        public const TPCANHandle PCAN_PCIBUS7 = 0x47;
        public const TPCANHandle PCAN_PCIBUS8 = 0x48;
        public const TPCANHandle PCAN_USBBUS1 = 0x51;
        public const TPCANHandle PCAN_USBBUS2 = 0x52;
        public const TPCANHandle PCAN_USBBUS3 = 0x53;
        public const TPCANHandle PCAN_USBBUS4 = 0x54;
        public const TPCANHandle PCAN_USBBUS5 = 0x55;
        public const TPCANHandle PCAN_USBBUS6 = 0x56;
        public const TPCANHandle PCAN_USBBUS7 = 0x57;
        public const TPCANHandle PCAN_USBBUS8 = 0x58;
        public const TPCANHandle PCAN_PCCBUS1 = 0x61;
        public const TPCANHandle PCAN_PCCBUS2 = 0x62;
        #endregion

        #region Parameter values definition
        /// <summary>
        /// The PCAN parameter is not set (inactive)
        /// </summary>
        public const int PCAN_PARAMETER_OFF = 0;
        public const int PCAN_PARAMETER_ON = 1;
        public const int PCAN_FILTER_CLOSE = 0;
        public const int PCAN_FILTER_OPEN = 1;
        public const int PCAN_FILTER_CUSTOM = 2;
        public const int PCAN_CHANNEL_UNAVAILABLE = 0;
        public const int PCAN_CHANNEL_AVAILABLE = 1;
        public const int PCAN_CHANNEL_OCCUPIED = 2;
        public const int LOG_FUNCTION_DEFAULT = 0x00;
        public const int LOG_FUNCTION_ENTRY = 0x01;
        public const int LOG_FUNCTION_PARAMETERS = 0x02;
        public const int LOG_FUNCTION_LEAVE = 0x04;
        public const int LOG_FUNCTION_WRITE = 0x08;
        public const int LOG_FUNCTION_READ = 0x10;
        public const int LOG_FUNCTION_ALL = 0xFFFF;
        public const int TRACE_FILE_SINGLE = 0x00;
        public const int TRACE_FILE_SEGMENTED = 0x01;
        public const int TRACE_FILE_DATE = 0x02;
        public const int TRACE_FILE_TIME = 0x04;
        public const int TRACE_FILE_OVERWRITE = 0x80;
        #endregion

        #region PCANBasic API Implementation
        /* Initialize():  Initializes a PCAN Channel 
         * Uinitialize(): Uninitializes one or all PCAN Channels initialized by CAN_Initialize
         * Reset():       Resets the receive and transmit queues of the PCAN Channel
         * GetStatus():   Gets the current status of a PCAN Channel
         * Read():        Reads a CAN message from the receive queue of a PCAN Channel
         * Write():       Transmits a CAN message 
         * FilterMessage():
         * GetValue():    Retrieves a PCAN Channel value
         * SetValue():    Configures or sets a PCAN Channel value
         * GetErrorText():Returns a descriptive text of a given TPCANStatus error code, in any desired language
        */

        /// <summary>
        /// Initializes a PCAN Channel 
        /// </summary>
        /// <param name="Channel">The handle of a PCAN Channel</param>
        /// <param name="Btr0Btr1">The speed for the communication (BTR0BTR1 code)</param>
        /// <param name="HwType">NON PLUG&PLAY: The type of hardware and operation mode</param>
        /// <param name="IOPort">NON PLUG&PLAY: The I/O address for the parallel port</param>
        /// <param name="Interrupt">NON PLUG&PLAY: Interrupt number of the parallel por</param>
        /// <returns>A TPCANStatus error code</returns>
        [DllImport("PCANBasic.dll", EntryPoint = "CAN_Initialize")]
        public static extern TPCANStatus Initialize(
            [MarshalAs(UnmanagedType.U1)] TPCANHandle Channel,
            [MarshalAs(UnmanagedType.U2)] TPCANBaudrate Btr0Btr1,
            [MarshalAs(UnmanagedType.U1)] TPCANType HwType,
            UInt32 IOPort,
            UInt16 Interrupt);

        /// <summary>
        /// Initializes a PCAN Channel
        /// </summary>
        /// <param name="Channel">The handle of a PCAN Channel</param>
        /// <param name="Btr0Btr1">The speed for the communication (BTR0BTR1 code)</param>
        /// <returns>A TPCANStatus error code</returns>
        public static TPCANStatus Initialize(TPCANHandle Channel, TPCANBaudrate Btr0Btr1)
        {
            return Initialize(Channel, Btr0Btr1, (TPCANType)0, 0, 0);
        }

        /// <summary>
        /// Uninitializes one or all PCAN Channels initialized by CAN_Initialize
        /// </summary>
        /// <remarks>Giving the TPCANHandle value "PCAN_NONEBUS", 
        /// uninitialize all initialized channels</remarks>
        /// <param name="Channel">The handle of a PCAN Channel</param>
        /// <returns>A TPCANStatus error code</returns>
        [DllImport("PCANBasic.dll", EntryPoint = "CAN_Uninitialize")]
        public static extern TPCANStatus Uninitialize([MarshalAs(UnmanagedType.U1)]TPCANHandle Channel);

        /// <summary>
        /// Resets the receive and transmit queues of the PCAN Channel
        /// </summary>
        /// <remarks>A reset of the CAN controller is not performed</remarks>
        /// <param name="Channel">The handle of a PCAN Channel</param>
        /// <returns>A TPCANStatus error code</returns>
        [DllImport("PCANBasic.dll", EntryPoint = "CAN_Reset")]
        public static extern TPCANStatus Reset([MarshalAs(UnmanagedType.U1)]TPCANHandle Channel);

        /// <summary>
        /// Gets the current status of a PCAN Channel
        /// </summary>
        /// <param name="Channel">The handle of a PCAN Channel</param>
        /// <returns>A TPCANStatus error code</returns>
        [DllImport("PCANBasic.dll", EntryPoint = "CAN_GetStatus")]
        public static extern TPCANStatus GetStatus([MarshalAs(UnmanagedType.U1)]TPCANHandle Channel);

        /// <summary>
        /// Reads a CAN message from the receive queue of a PCAN Channel
        /// </summary>
        /// <param name="Channel">The handle of a PCAN Channel</param>
        /// <param name="MessageBuffer">A TPCANMsg structure buffer to store the CAN message</param>
        /// <param name="TimestampBuffer">A TPCANTimestamp structure buffer to get
        /// the reception time of the message</param>
        /// <returns>A TPCANStatus error code</returns>
        [DllImport("PCANBasic.dll", EntryPoint = "CAN_Read")]
        public static extern TPCANStatus Read(
            [MarshalAs(UnmanagedType.U1)] TPCANHandle Channel,
            out TPCANMsg MessageBuffer,
            out TPCANTimestamp TimestampBuffer);

        [DllImport("PCANBasic.dll", EntryPoint = "CAN_Read")]
        private static extern TPCANStatus Read(
            [MarshalAs(UnmanagedType.U1)] TPCANHandle Channel,
            out TPCANMsg MessageBuffer,
            IntPtr bufferPointer);

        /// <summary>
        /// Reads a CAN message from the receive queue of a PCAN Channel
        /// </summary>
        /// <param name="Channel">The handle of a PCAN Channel</param>
        /// <param name="MessageBuffer">A TPCANMsg structure buffer to store the CAN message</param>        
        /// <returns>A TPCANStatus error code</returns>
        public static TPCANStatus Read(TPCANHandle Channel, out TPCANMsg MessageBuffer)
        {
            return Read(Channel, out MessageBuffer, IntPtr.Zero);
        }

        /// <summary>
        ///  Transmits a CAN message 
        /// </summary>
        /// <param name="Channel">The handle of a PCAN Channel</param>
        /// <param name="MessageBuffer">A TPCANMsg buffer with the message to be sent</param>
        /// <returns>A TPCANStatus error code</returns>
        [DllImport("PCANBasic.dll", EntryPoint = "CAN_Write")]
        public static extern TPCANStatus Write([MarshalAs(UnmanagedType.U1)]TPCANHandle Channel,
            ref TPCANMsg MessageBuffer);

        /// <summary>
        /// Configures the reception filter
        /// </summary>
        /// <remarks>The message filter will be expanded with every call to 
        /// this function. If it is desired to reset the filter, please use
        /// the 'SetValue' function</remarks>
        /// <param name="Channel">The handle of a PCAN Channel</param>
        /// <param name="FromID">The lowest CAN ID to be received</param>
        /// <param name="ToID">The highest CAN ID to be received</param>
        /// <param name="Mode">Message type, Standard (11-bit identifier) or
        /// Extended (29-bit identifier)</param>
        /// <returns>A TPCANStatus error code</returns>
        [DllImport("PCANBasic.dll", EntryPoint = "CAN_FilterMessages")]
        public static extern TPCANStatus FilterMessages(
            [MarshalAs(UnmanagedType.U1)] TPCANHandle Channel,
            UInt32 FromID,
            UInt32 ToID,
            [MarshalAs(UnmanagedType.U1)] TPCANMode Mode);

        /// <summary>
        /// Retrieves a PCAN Channel value
        /// </summary>
        /// <remarks>Parameters can be present or not according with the kind 
        /// of Hardware (PCAN Channel) being used. If a parameter is not available,
        /// a PCAN_ERROR_ILLPARAMTYPE error will be returned</remarks>
        /// <param name="Channel">The handle of a PCAN Channel</param>
        /// <param name="Parameter">The TPCANParameter parameter to get</param>
        /// <param name="StringBuffer">Buffer for the parameter value</param>
        /// <param name="BufferLength">Size in bytes of the buffer</param>
        /// <returns>A TPCANStatus error code</returns>
        [DllImport("PCANBasic.dll", EntryPoint = "CAN_GetValue")]
        public static extern TPCANStatus GetValue(
            [MarshalAs(UnmanagedType.U1)] TPCANHandle Channel,
            [MarshalAs(UnmanagedType.U1)] TPCANParameter Parameter,
            StringBuilder StringBuffer,
            UInt32 BufferLength);

        /// <summary>
        /// Retrieves a PCAN Channel value
        /// </summary>
        /// <remarks>Parameters can be present or not according with the kind 
        /// of Hardware (PCAN Channel) being used. If a parameter is not available,
        /// a PCAN_ERROR_ILLPARAMTYPE error will be returned</remarks>
        /// <param name="Channel">The handle of a PCAN Channel</param>
        /// <param name="Parameter">The TPCANParameter parameter to get</param>
        /// <param name="NumericBuffer">Buffer for the parameter value</param>
        /// <param name="BufferLength">Size in bytes of the buffer</param>
        /// <returns>A TPCANStatus error code</returns>
        [DllImport("PCANBasic.dll", EntryPoint = "CAN_GetValue")]
        public static extern TPCANStatus GetValue(
            [MarshalAs(UnmanagedType.U1)] TPCANHandle Channel,
            [MarshalAs(UnmanagedType.U1)] TPCANParameter Parameter,
            out UInt32 NumericBuffer,
            UInt32 BufferLength);

        /// <summary>
        /// Configures or sets a PCAN Channel value 
        /// </summary>
        /// <remarks>Parameters can be present or not according with the kind 
        /// of Hardware (PCAN Channel) being used. If a parameter is not available,
        /// a PCAN_ERROR_ILLPARAMTYPE error will be returned</remarks>
        /// <param name="Channel">The handle of a PCAN Channel</param>
        /// <param name="Parameter">The TPCANParameter parameter to set</param>
        /// <param name="NumericBuffer">Buffer with the value to be set</param>
        /// <param name="BufferLength">Size in bytes of the buffer</param>
        /// <returns>A TPCANStatus error code</returns>
        [DllImport("PCANBasic.dll", EntryPoint = "CAN_SetValue")]
        public static extern TPCANStatus SetValue(
            [MarshalAs(UnmanagedType.U1)]
            TPCANHandle Channel,
            [MarshalAs(UnmanagedType.U1)]
            TPCANParameter Parameter,
            ref UInt32 NumericBuffer,
            UInt32 BufferLength);

        /// <summary>
        /// Configures or sets a PCAN Channel value
        /// </summary>
        /// <remarks>Parameters can be present or not according with the kind 
        /// of Hardware (PCAN Channel) being used. If a parameter is not available,
        /// a PCAN_ERROR_ILLPARAMTYPE error will be returned</remarks>
        /// <param name="Channel">The handle of a PCAN Channel</param>
        /// <param name="Parameter"></param>
        /// <param name="StringBuffer">Buffer with the value to be set</param>
        /// <param name="BufferLength">Size in bytes of the buffer</param>
        /// <returns>A TPCANStatus error code</returns>
        [DllImport("PCANBasic.dll", EntryPoint = "CAN_SetValue")]
        public static extern TPCANStatus SetValue(
            [MarshalAs(UnmanagedType.U1)]
            TPCANHandle Channel,
            [MarshalAs(UnmanagedType.U1)]
            TPCANParameter Parameter,
            [MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 3)]
            string StringBuffer,
            UInt32 BufferLength);

        /// <summary>
        /// Returns a descriptive text of a given TPCANStatus error 
        /// code, in any desired language
        /// </summary>
        /// <remarks>The current languages available for translation are: 
        /// Neutral (0x00), German (0x07), English (0x09), Spanish (0x0A),
        /// Italian (0x10) and French (0x0C)</remarks>
        /// <param name="Error">A TPCANStatus error code</param>
        /// <param name="Language">Indicates a 'Primary language ID'</param>
        /// <param name="StringBuffer">Buffer for the text (must be at least 256 in length)</param>
        /// <returns>A TPCANStatus error code</returns>
        [DllImport("PCANBasic.dll", EntryPoint = "CAN_GetErrorText")]
        public static extern TPCANStatus GetErrorText(
            [MarshalAs(UnmanagedType.U4)] TPCANStatus Error,
            UInt16 Language,
            StringBuilder StringBuffer);

        internal static TPCANStatus Read(byte channel, out TPCANMsg messageBuffer, out IntPtr bufferPointer)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    #endregion

}
