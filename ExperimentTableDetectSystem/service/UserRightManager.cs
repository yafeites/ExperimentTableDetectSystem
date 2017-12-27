using ExperimentTableDetectSystem.entity;
using ExperimentTableDetectSystem.util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ExperimentTableDetectSystem.service
{
    public class UserRightManager
    {
        public static User user;
        DBHelper dbHelper;

        private UserRightManager(string userName, string password)
        {
            user = new User(userName, password);
            dbHelper = DBHelper.GetInstance();
        }

        private static volatile UserRightManager instance;
        public static UserRightManager GetInstance()
        {
            if (instance == null)
            {
                throw new Exception("UserRightManager 实例未初始化。");
            }
            return instance;
        }

        public static void Initial(string userName, string password)
        {
            if (instance != null)
            {
                user.userName = userName;
                user.password = password;
                return;
            }
            instance = new UserRightManager(userName, password);
        }


        internal bool Check()
        {
            string sql = string.Format("select * from UserManager where userName = '{0}' and password = '{1}'",
                user.userName, user.password);
            SqlDataReader reader = dbHelper.ExecuteReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                user.rightLevel = (int)reader["rightLevel"];//添加代码。。。
                return true;
            }
            return false;
        }


        internal bool CanDoThis(int OperationLeastLevel)
        {
            if (user.rightLevel >= OperationLeastLevel)
            {
                return true;
            }
            return false;
        }

    }


    public class UserPrivilegeException : Exception
    {
        public UserPrivilegeException(string message) : base(message)
        {
            System.Windows.Forms.MessageBox.Show(message);
        }
        public UserPrivilegeException() : base()
        {
            System.Windows.Forms.MessageBox.Show("用户没有足够权限");
        }
        public UserPrivilegeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
