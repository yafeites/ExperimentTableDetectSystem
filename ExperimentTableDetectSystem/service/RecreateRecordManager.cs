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
        /// </summary>
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

        #region 测试表部分 2手动 12自动
        /// <summary>
        /// 2.1 手动试验表。主溢流阀调定试验表
        /// </summary>
        public static void M1(string name)
        {
            //记得string后有空格[Id] [nvarchar](50) NOT NULL,
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.valveM1', 'U') IS NOT NULL 
             DROP TABLE dbo.valveM1; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+@"
                (productId nvarchar(50)  NOT NULL,                 
                 n int NOT NULL,
	             P1 real NOT NULL,
	            Q1 real NOT NULL,
	            P2 real NOT NULL,
	            Q2 real NULL,
	            time real NULL
                )");

        }
        /// <summary>
        /// 2.2转向溢流阀
        /// </summary>
        public static void M2(string s)
        {

           dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.valveM2', 'U') IS NOT NULL 
                                        DROP TABLE dbo.valveM2; ");
            dbHelper.ExecuteNonQuery(
                "create table "+s+ @"
               (
	[productId] [nvarchar](50) NOT NULL,
  	[n] [int] NOT NULL,
	[P1] [real] NOT NULL,
	[Q1] [real] NOT NULL,
	[P2] [real] NOT NULL,
	[Q2] [real] NULL,
    [P] [real] NULL,
    [time] [real] NULL,
) ");
        }

        /// <summary>
        /// 自动测试1。。。。。。
        /// </summary>
        public static void f1(string name)
        {
           dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.valvef1', 'U') IS NOT NULL 
                                        DROP TABLE dbo.valvef1; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
    [productId] [nvarchar](50) NOT NULL,
  	[n] [int] NOT NULL,
	[P1] [real] NULL,
	[Q1] [real] NULL,
	[P2] [real] NULL,
	[Q2] [real] NULL,
	[P3] [real] NULL,
	[Q3] [real] NULL,
	[V1] [real] NULL,
	[V2] [real] NULL,
    [time] [real] NULL,
) ");
        }

        public static void f2(string name)
        {

           dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.valvef2', 'U') IS NOT NULL 
                                        DROP TABLE dbo.valvef2; ");
            dbHelper.ExecuteNonQuery(
               "create table "+name+ @"
               (
   [productId] [nvarchar](50) NOT NULL,
  	[n] [int] NOT NULL,
	[P] [real] NULL,
	[Q] [real] NULL,
	[Pi] [real] NULL,
	[P-Pi] [real] NULL,
	[S] [real] NULL,
	[V] [real] NULL,
	[F] [real] NULL,
	[T] [real] NULL,
   [time] [real] NULL
) ");
        }

        public static void f3(string name)
        {

            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.valvef3', 'U') IS NOT NULL 
                                        DROP TABLE dbo.valvef3; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
        [productId] [nvarchar](50) NOT NULL,
  	    [n] [int] NOT NULL,
	    [P] [real] NULL,
	    [Q] [real] NULL,
    	[Pi] [real] NULL,
       [Pb] [real] NULL,
	    [P-Pi] [real] NULL,
	    [S] [real] NULL,
	    [V] [real] NULL,
	    [F] [real] NULL,
	    [T] [real] NULL,
        [time] [real] NULL,
) ");
        }

        public static void f4(string name)
        {

            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.valvef4', 'U') IS NOT NULL 
                                       DROP TABLE dbo.valvef4; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
        [productId] [nvarchar](50) NOT NULL,
      	[n] [int] NOT NULL,
	    [P1] [real] NULL,
    	[Q1] [real] NULL,
	    [P2] [real] NULL,
	    [Q2] [real] NULL,
	    [Pi] [real] NULL,
	    [P3] [real] NULL,
	    [S] [real] NULL,
	    [V] [real] NULL,
	    [F] [real] NULL,
	    [T] [real] NULL,
        [time] [real] NULL
) ");
        }

        public static void f5(string name)
        {

           dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.valvef5', 'U') IS NOT NULL 
                                        DROP TABLE dbo.valvef5; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
    [productId] [nvarchar](50) NOT NULL,
  	[n] [int] NOT NULL,
    [P1] [real] NULL,
	[Q1] [real] NULL,
	[P2] [real] NULL,
	[Q2] [real] NULL,
	[Pi] [real] NULL,
    [Pb] [real] NULL,
	[Pi-Pb] [real] NULL,
	[S] [real] NULL,
	[V] [real] NULL,
	[F] [real] NULL,
	[T] [real] NULL,
    [time] [real] NULL
) ");
        }

        public static void f6(string name)
        {

           dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.valvef6', 'U') IS NOT NULL 
                                        DROP TABLE dbo.valvef6; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
     [productId] [nvarchar](50) NOT NULL,
  	[n] [int] NOT NULL,
    [P] [real] NULL,
	[Q] [real] NULL,
	[Pi] [real] NULL,
	[Po] [real] NULL,
	[Pb] [real] NULL,
   	[P-Pi] [real] NULL,
	[Po-Pb] [real] NULL,
    [S] [real] NULL,
	[V] [real] NULL,
	[F] [real] NULL,
	[T] [real] NULL,
    [time] [real] NULL
) ");
        }

        public static void f7(string name)
        {

            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.valvef7', 'U') IS NOT NULL 
                                        DROP TABLE dbo.valvef7; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
     [productId] [nvarchar](50) NOT NULL,
  	[n] [int] NOT NULL,
    [P] [real] NULL,
	[Q] [real] NULL,
	[Pi] [real] NULL,
	[Po] [real] NULL,
	[Pb] [real] NULL,
   	[P-Pi] [real] NULL,
	[Po-Pb] [real] NULL,
    [S] [real] NULL,
	[V] [real] NULL,
	[F] [real] NULL,
	[T] [real] NULL,
    [time] [real] NULL
) ");
        }

        public static void f8(string name)
        {

           dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.valvef8', 'U') IS NOT NULL 
                                       DROP TABLE dbo.valvef8; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
    [productId] [nvarchar](50) NOT NULL,
  	[n] [int] NOT NULL,
    [P1] [real] NULL,
	[Q1] [real] NULL,
    [P2] [real] NULL,
	[Q2] [real] NULL,
	[Pi] [real] NULL,
	[Po] [real] NULL,
	[Pb] [real] NULL,
   	[P-Pi] [real] NULL,
	[Po-Pb] [real] NULL,
    [S] [real] NULL,
	[V] [real] NULL,
	[F] [real] NULL,
	[T] [real] NULL,
[time] [real] NULL
) ");
        }

        public static void f9(string name)
        {

            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.valvef9', 'U') IS NOT NULL 
                                        DROP TABLE dbo.valvef9; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
    [productId] [nvarchar](50) NOT NULL,
  	[n] [int] NOT NULL,
    [P1] [real] NULL,
	[Q1] [real] NULL,
    [P2] [real] NULL,
	[Q2] [real] NULL,
	[Pi] [real] NULL,
	[Po] [real] NULL,
	[Pb] [real] NULL,
   	[P-Pi] [real] NULL,
	[Po-Pb] [real] NULL,
    [S] [real] NULL,
	[V] [real] NULL,
	[F] [real] NULL,
	[T] [real] NULL,
     [time] [real] NULL
) ");
        }

        public static void f10(string name)
        {

           dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.valvef10', 'U') IS NOT NULL 
                                        DROP TABLE dbo.valvef10; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
    [productId] [nvarchar](50) NOT NULL,
  	[n] [int] NOT NULL,
    [P1] [real] NULL,
	[Q1] [real] NULL,
    [P2] [real] NULL,
	[Q2] [real] NULL,
	[Pb] [real] NULL,
    [Q3] [real] NULL,
[time] [real] NULL
) ");
        }
        public static void f11(string name)
        {

            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.valvef11', 'U') IS NOT NULL 
                                        DROP TABLE dbo.valvef11; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
    [productId] [nvarchar](50) NOT NULL,
  	[n] [int] NOT NULL,
    [P1] [real] NULL,
	[Q1] [real] NULL,
    [P2] [real] NULL,
	[Q2] [real] NULL,
	[Pb] [real] NULL,
    [P3] [real] NULL,
[time] [real] NULL
) ");
        }

        public static void f12(string name)
        {

            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.valvef12', 'U') IS NOT NULL 
                                        DROP TABLE dbo.valvef12; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
    [productId] [nvarchar](50) NOT NULL,
  	[n] [int] NOT NULL,
    [P1] [real] NULL,
	[Q2] [real] NULL,
    [P2] [real] NULL,
	[Pa] [real] NULL,
	[Pb] [real] NULL,
    [Q3] [real] NULL,
    [time] [real] NULL
) ");
        }
       

        public static void CreateAutoTable(string s)
        {
            //自动
            f1(s+"f1");
            f2(s+"f2");
            f3(s+"f3");
            f4(s+"f4");
            f5(s+"f5");
            f6(s+"f6");
            f7(s+"f7");
            f8(s+"f8");
            f9(s+"f9");
            f10(s+"f10");
            f11(s+"f11");
            f12(s+"f12");
        }

       
        /// <summary>
        /// 建立阀测试数据的表（14个表）
        /// </summary>
        public static void CreateValveTable()
        {
            try
            {
                M1("valveM1");
                M2("valveM2");
                CreateAutoTable("valve");
            }
            catch(Exception ex)
            {
                MessageBox.Show("初始化建立阀测试表发生异常" + ex.Message);
            }

        }
        #endregion

      

        /// <summary>
        /// 加编号
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n"></param>
        public static void AddNewId(string id,int n,string company)
        {                                      
                 string str = string.Format("insert into tbProductId values('{0}',{1},'{2}')", id,n,company);
            dbHelper.ExecuteNonQuery(str);
        }
        /// <summary>
        /// 建立编号的表,管理阀编号（包括id和次数n），用于查询
        /// </summary>
        public  static  void CreateProductId()
        {
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.tbProductId', 'U') IS NOT NULL 
                                        DROP TABLE dbo.tbProductId; ");
            dbHelper.ExecuteNonQuery(
                @"create table tbProductId
                ([Id] [nvarchar](50) NOT NULL,
	             [n] [int] NULL,
	             [sendCompany] [nvarchar](50) NULL,
                )");
        }

        public static void InitialDataBase()
        {
            RecreateUserManagerTable();
            CreateProductId();
            CreateValveTable();

        }

    }
}
