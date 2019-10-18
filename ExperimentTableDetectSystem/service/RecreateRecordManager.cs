using ExperimentTableDetectSystem.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.service
{
    public static class RecreateRecordManager
    {
        // string sqlSteeveForce = string.Format("insert into SteeveForce values(newid(),getdate(),'{0}',{1},{2},{3},{4})", name, dicSteeve[0].GetForce(), dicSteeve[1].GetForce(), dicSteeve[2].GetForce(), dicSteeve[3].GetForce());
        private static DBHelper dbHelper = DBHelper.GetInstance();
        /// <summary>
        ///1 重建用户表
        /// </summary>+++
        public static void RecreateUserManagerTable()
        {

            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.UserManager', 'U') IS NOT NULL 
                                        DROP TABLE dbo.UserManager; ");
            dbHelper.ExecuteNonQuery(
                @"create table UserManager
                (phid int IDENTITY(1,1) NOT NULL,
	             userName nvarchar(50) NOT NULL,
	             password nvarchar(50) NOT NULL,
	             rightLevel int NOT NULL,
	             viewLog nvarchar(50) NULL,
	             parameterSet nvarchar(50) NULL,
	             systemSet nvarchar(50) NULL,
                )");
            dbHelper.ExecuteNonQuery("insert into UserManager values('admin','12345',3,'有','有','有')");
        }

        ///报警记录表
        public static void RecreateAlarmTable()
        {

            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.Alarm', 'U') IS NOT NULL 
                                        DROP TABLE dbo.Alarm; ");
            dbHelper.ExecuteNonQuery(
                @"create table Alarm
                (userName nvarchar(50) NOT NULL,
                 time datetime NULL,
                 warntype nvarchar(50) NULL,
                )");
        }

        /// <summary>
        /// 加编号
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n"></param>
        public static void AddNewId(string id, int n, string company, string menjiaType, string valveType)
        {
            string str = string.Format("insert into tbProductId values('{0}',{1},'{2}','{3}','{4}','{5}')", id, n, company,menjiaType, valveType,DateTime.Now);
            dbHelper.ExecuteNonQuery(str);
        }

        /// <summary>
        /// 建立编号的表,管理阀编号（包括id和次数n），用于查询
        /// </summary>
        public static void CreateProductId()
        {
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.tbProductId', 'U') IS NOT NULL 
                                        DROP TABLE dbo.tbProductId; ");
            dbHelper.ExecuteNonQuery(
                @"create table tbProductId
                ([Id] [nvarchar](50) NOT NULL,
	             [n] [int] NULL,
	             [sendCompany] [nvarchar](50) NULL,
                 [menjiaType] [nvarchar](50) NULL,
                 [valveType] [nvarchar](50) NULL,
                 [currentTime] [datetime] NOT NULL
                )");
        }


        //建立数据总表
        public static void CreateTotalTable()
        {
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.allData', 'U') IS NOT NULL 
                                        DROP TABLE dbo.allData; ");
            dbHelper.ExecuteNonQuery(
                @"create table allData
                ([productId] [nvarchar](50) NOT NULL,
  	             [n] [int] NOT NULL,
[menjiaType] [nvarchar](50) NOT NULL,
[valveType] [nvarchar](50) NOT NULL,
[testName] [nvarchar](50) NOT NULL,
	[pump1flow] [real] NULL,
	[pump2flow] [real] NULL,
	[steerflow] [real] NULL,
	[leakageflow] [real] NULL,

	[mainPumpP1] [real] NULL,
	[mainPumpP2] [real] NULL,
	[steerPressure] [real] NULL,
	[mediumPressureLoss] [real] NULL,
    [menjiaVerticalDis] [real] NULL,
    [menjiaUpV] [real] NULL,
	[menjiaUpPreLoss] [real] NULL,
	[menjiaDownV] [real] NULL,
	[menjiaDownPreLoss] [real] NULL,
    [menjiaLeanDis] [real] NULL,
    [menjiaForwardV] [real] NULL,
	[menjiaForwardInLoss] [real] NULL,
	[menjiaForwardOutLoss] [real] NULL,
	[menjiaBackV] [real] NULL,
    [menjiaBackInLoss] [real] NULL,
    [menjiaBackOutLoss] [real] NULL,
	[forceIn] [real] NULL,
	[forceOut] [real] NULL,

    [systembackPressure] [real] NULL,
    [cylinderPressure] [real] NULL,
    [cylinderInPressure] [real] NULL,
    [cylinderOutPressure] [real] NULL,


    [pilotPressure] [real] NULL,
    [tankTemp] [real] NULL,
    [pump1OutTemp] [real] NULL,
    [pump2OutTemp] [real] NULL,
    [testUpDis] [real] NULL,
    [testForwardDis] [real] NULL,
    [testBackDis] [real] NULL,
    [currentTime] [datetime] NOT NULL,
    [backflow] [real] NULL
                )");
        }

        public static void InitialDataBase()
        {
            RecreateUserManagerTable();
            CreateProductId();
          //  CreateValveTable();
            CreateTotalTable();
            RecreateAlarmTable();
        }

    }
}
