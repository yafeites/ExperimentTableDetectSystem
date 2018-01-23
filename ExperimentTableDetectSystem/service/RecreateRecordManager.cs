using ExperimentTableDetectSystem.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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
          //记得string后有空格
            //dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.AdjustmentTestOfMainValve', 'U') IS NOT NULL 
                                       // DROP TABLE dbo.AdjustmentTestOfMainValve; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+@"
                (productId int IDENTITY(1,1) NOT NULL,
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

          //  dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.AdjustmentTestOfSteeringValve', 'U') IS NOT NULL 
                                       // DROP TABLE dbo.AdjustmentTestOfSteeringValve; ");
            dbHelper.ExecuteNonQuery(
                "create table "+s+ @"
               (
	[productId] [int] IDENTITY(1,1) NOT NULL,
	[P1] [real] NOT NULL,
	[Q1] [real] NOT NULL,
	[P2] [real] NOT NULL,
	[Q2] [real] NULL,
    [time] [real] NULL,
) ");
        }

        /// <summary>
        /// 自动测试1。。。。。。
        /// </summary>
        public static void f1(string name)
        {
           // dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.steeringPriorityValveFlowTest', 'U') IS NOT NULL 
                                       // DROP TABLE dbo.steeringPriorityValveFlowTest; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
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

          //  dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoTwo', 'U') IS NOT NULL 
                                      //  DROP TABLE dbo.autoTwo; ");
            dbHelper.ExecuteNonQuery(
               "create table "+name+ @"
               (
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

          //  dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoThree', 'U') IS NOT NULL 
                                      //  DROP TABLE dbo.autoThree; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
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

           // dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoFour', 'U') IS NOT NULL 
                                      //  DROP TABLE dbo.autoFour; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
	    [P1] [real] NULL,
    	[Q1] [real] NULL,
	    [P2] [real] NULL,
	    [Q2] [real] NULL,
	    [Pi] [real] NULL,
	    [Max(P1-P2)-Pi] [real] NULL,
	    [S] [real] NULL,
	    [V] [real] NULL,
	    [F] [real] NULL,
	    [T] [real] NULL,
        [time] [real] NULL
) ");
        }

        public static void f5(string name)
        {

           // dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoFive', 'U') IS NOT NULL 
                                       // DROP TABLE dbo.autoFive; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
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

           // dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoSix', 'U') IS NOT NULL 
                                       // DROP TABLE dbo.autoSix; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
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

          //  dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoSeven', 'U') IS NOT NULL 
                                     //   DROP TABLE dbo.autoSeven; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
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

          //  dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoEight', 'U') IS NOT NULL 
                                       // DROP TABLE dbo.autoEight; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
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

            //dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoNine', 'U') IS NOT NULL 
                                        //DROP TABLE dbo.autoNine; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
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

           // dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoTen', 'U') IS NOT NULL 
                                     //   DROP TABLE dbo.autoTen; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
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

            //dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoEleven', 'U') IS NOT NULL 
                                      //  DROP TABLE dbo.autoEleven; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
    [P1] [real] NULL,
	[Q1] [real] NULL,
    [P2] [real] NULL,
	[Q2] [real] NULL,
	[Pb] [real] NULL,
    [Max( P1,P2)-Pb] [real] NULL,
[time] [real] NULL
) ");
        }

        public static void f12(string name)
        {

           // dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.auto12', 'U') IS NOT NULL 
                                       // DROP TABLE dbo.auto12; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+ @"
               (
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

       

        public static void CreateValveTable(string s)
        {
            M1("valve"+s+"M1");
            M2("valve"+s+"M2");
            CreateAutoTable("valve"+s);

        }
        #endregion

        /// <summary>
        /// 删表
        /// </summary>
        /// <param name="s"></param>
        public static void deleteTable(string s)
        {
            //dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoThree', 'U') IS NOT NULL 
                                      //  DROP TABLE dbo.autoThree; ");
            dbHelper.ExecuteNonQuery("IF OBJECT_ID("+"'dbo."+s+"', 'U') IS NOT NULL"
                                      +" DROP TABLE "+"dbo."+s +";");
        }

        /// <summary>
        /// 加编号
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n"></param>
        public static void AddNewId(string s,int n)
        {
            
         
            string m1 = "M1";//试验项目1。。。
            string m2 = "M2";
            string[] f=new string[12];
            for (int i = 0; i < 12; i++)
            {
                f[i] = "f"+i.ToString();
            }
          

            string str = string.Format("insert into tbProductId values('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')", s,n, m1, m2,f[0],f[1],f[2],f[3],f[4],f[5],f[6],f[7],f[8],f[9],f[10],f[11]);
            dbHelper.ExecuteNonQuery(str);
        }

        public  static  void CreateId()
        {
            dbHelper.ExecuteNonQuery(
                @"create table tbProductId
                ([Id] [nvarchar](50) NOT NULL,
	[n] [int] NULL,
	[M1] [nvarchar](50) NULL,
	[M2] [nvarchar](50) NULL,
	[f1] [nvarchar](50) NULL,
	[f2] [nvarchar](50) NULL,
	[f3] [nvarchar](50) NULL,
	[f4] [nvarchar](50) NULL,
	[f5] [nvarchar](50) NULL,
	[f6] [nvarchar](50) NULL,
	[f7] [nvarchar](50) NULL,
	[f8] [nvarchar](50) NULL,
	[f9] [nvarchar](50) NULL,
	[f10] [nvarchar](50) NULL,
	[f11] [nvarchar](50) NULL,
	[f12] [nvarchar](50) NULL
                )");
        }

        public static void InitialDataBase()
        {
            RecreateUserManagerTable();


        }

    }
}
