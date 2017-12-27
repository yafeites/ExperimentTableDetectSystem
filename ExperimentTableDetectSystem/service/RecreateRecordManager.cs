using ExperimentTableDetectSystem.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExperimentTableDetectSystem.service
{
  public static  class RecreateRecordManager
    {
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




        public static void InitialDataBase()
        {
            RecreateUserManagerTable();

        }
    }
}
