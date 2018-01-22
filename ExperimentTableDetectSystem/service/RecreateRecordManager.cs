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
                "create table "+s+@"
               (
	[productId] [int] IDENTITY(1,1) NOT NULL,
	[P1] [real] NOT NULL,
	[Q1] [real] NOT NULL,
	[P2] [real] NOT NULL,
	[Q2] [real] NULL
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
                "create table "+name+@"
               (
	[P1] [real] NULL,
	[Q1] [real] NULL,
	[P2] [real] NULL,
	[Q2] [real] NULL,
	[P3] [real] NULL,
	[Q3] [real] NULL,
	[V1] [real] NULL,
	[V2] [real] NULL
) ");
        }

        public static void f2(string name)
        {

          //  dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoTwo', 'U') IS NOT NULL 
                                      //  DROP TABLE dbo.autoTwo; ");
            dbHelper.ExecuteNonQuery(
               "create table "+name+@"
               (
	[P] [real] NULL,
	[Q] [real] NULL,
	[Pi] [real] NULL,
	[P-Pi] [real] NULL,
	[S] [real] NULL,
	[V] [real] NULL,
	[F] [real] NULL,
	[T] [real] NULL
) ");
        }

        public static void f3(string name)
        {

          //  dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoThree', 'U') IS NOT NULL 
                                      //  DROP TABLE dbo.autoThree; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+@"
               (
	    [P] [real] NULL,
	    [Q] [real] NULL,
    	[Pi] [real] NULL,
       [Pb] [real] NULL,
	    [P-Pi] [real] NULL,
	    [S] [real] NULL,
	    [V] [real] NULL,
	    [F] [real] NULL,
	    [T] [real] NULL
) ");
        }

        public static void f4(string name)
        {

           // dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoFour', 'U') IS NOT NULL 
                                      //  DROP TABLE dbo.autoFour; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+@"
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
	    [T] [real] NULL
) ");
        }

        public static void f5(string name)
        {

           // dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoFive', 'U') IS NOT NULL 
                                       // DROP TABLE dbo.autoFive; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+@"
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
	[T] [real] NULL
) ");
        }

        public static void f6(string name)
        {

           // dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoSix', 'U') IS NOT NULL 
                                       // DROP TABLE dbo.autoSix; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+@"
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
	[T] [real] NULL
) ");
        }

        public static void f7(string name)
        {

          //  dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoSeven', 'U') IS NOT NULL 
                                     //   DROP TABLE dbo.autoSeven; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+@"
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
	[T] [real] NULL
) ");
        }

        public static void f8(string name)
        {

          //  dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoEight', 'U') IS NOT NULL 
                                       // DROP TABLE dbo.autoEight; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+@"
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
	[T] [real] NULL
) ");
        }

        public static void f9(string name)
        {

            //dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoNine', 'U') IS NOT NULL 
                                        //DROP TABLE dbo.autoNine; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+@"
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
	[T] [real] NULL
) ");
        }

        public static void f10(string name)
        {

           // dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoTen', 'U') IS NOT NULL 
                                     //   DROP TABLE dbo.autoTen; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+@"
               (
    [P1] [real] NULL,
	[Q1] [real] NULL,
    [P2] [real] NULL,
	[Q2] [real] NULL,
	[Pb] [real] NULL,
    [Q3] [real] NULL,
) ");
        }
        public static void f11(string name)
        {

            //dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoEleven', 'U') IS NOT NULL 
                                      //  DROP TABLE dbo.autoEleven; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+@"
               (
    [P1] [real] NULL,
	[Q1] [real] NULL,
    [P2] [real] NULL,
	[Q2] [real] NULL,
	[Pb] [real] NULL,
    [Max( P1,P2)-Pb] [real] NULL,
) ");
        }

        public static void f12(string name)
        {

           // dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.auto12', 'U') IS NOT NULL 
                                       // DROP TABLE dbo.auto12; ");
            dbHelper.ExecuteNonQuery(
                "create table "+name+@"
               (
    [P1] [real] NULL,
	[Q2] [real] NULL,
    [P2] [real] NULL,
	[Pa] [real] NULL,
	[Pb] [real] NULL,
    [Q3] [real] NULL,
) ");
        }
       

        public static void CreateAutoTable(string s)
        {
            //自动
            f1(s+"tb1");
            f2(s+"tb2");
            f3(s+"tb3");
            f4(s+"tb4");
            f5(s+"tb5");
            f6(s+"tb6");
            f7(s+"tb7");
            f8(s+"tb8");
            f9(s+"tb9");
            f10(s+"tb10");
            f11(s+"tb11");
            f12(s+"tb12");
        }

        public static void InitialDataBase()
        {
            RecreateUserManagerTable();
        
          
        }

        public static void CreateValveTable(string s)
        {
            M1("valve"+s+"M1");
            M2("valve"+s+"M2");
            CreateAutoTable("valve"+s);

        }

        public static void DropTable(string s)
        {
            deleteTable("valve" + s + "M1");
            deleteTable("valve" + s + "M2");
            deleteTable("valve" + s + "tb1");
            deleteTable("valve" + s + "tb2");
            deleteTable("valve" + s + "tb3");
            deleteTable("valve" + s + "tb4");
            deleteTable("valve" + s + "tb5");
            deleteTable("valve" + s + "tb6");
            deleteTable("valve" + s + "tb7");
            deleteTable("valve" + s + "tb8");
            deleteTable("valve" + s + "tb9");
            deleteTable("valve" + s + "tb10");
            deleteTable("valve" + s + "tb11");
            deleteTable("valve" + s + "tb12");

        }

        public static void deleteTable(string s)
        {
            //dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.autoThree', 'U') IS NOT NULL 
                                      //  DROP TABLE dbo.autoThree; ");
            dbHelper.ExecuteNonQuery("IF OBJECT_ID("+"'dbo."+s+"', 'U') IS NOT NULL"
                                      +" DROP TABLE "+"dbo."+s +";");
        }

        public static void AddNewId(string s)
        {
            
            int a = int.Parse(s);
            string m1 = "shoudong1";//试验项目1。。。
            string m2 = "shoudong2";
            string str = string.Format("insert into tbProductId values({0},'{1}','{2}')", a, m1, m2);
            dbHelper.ExecuteNonQuery(str);
        }

        /// <summary>
        /// 判断表是否为空
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool IsTableNull(string sql)
        {

            DBHelper dbhelper = DBHelper.GetInstance();
            DataTable dt = dbhelper.ExecuteSqlDataAdapter(sql, null, 0);
            if (dt.Rows.Count == 0) { return true; }//是空表
            else { return false; }
        }
    }
}
