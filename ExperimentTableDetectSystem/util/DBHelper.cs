using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ExperimentTableDetectSystem.util
{
    public class DBHelper
    {
        private static readonly string connString = Properties.Settings.Default.DataBaseConnection;

        //private static readonly string connString = null;
        private SqlConnection conn = null;
        private SqlCommand comm = null;
        private SqlDataReader reader = null;

        private static volatile DBHelper instance;
        private static object syncRoot = new Object();

        private DBHelper() { }


        /// <summary>
        /// 返回单例模式
        /// </summary>
        /// <returns></returns>
        public static DBHelper GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new DBHelper();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// 执行非查询类SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, SqlParameter[] parameters)
        {
            int affectedRows = 0;

            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    string cmdText = sql;
                    comm = new SqlCommand(cmdText, conn);
                    comm.Transaction = transaction;
                    if (parameters != null)
                    {
                        comm.Parameters.AddRange(parameters);

                    }
                    affectedRows = comm.ExecuteNonQuery();
                    transaction.Commit();
                    transaction.Dispose();
                }

            }
            return affectedRows;
        }

        /// <summary>
        /// 执行无参数非查询SQL语句
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, null);
        }


        /// <summary>
        /// 执行查询类SQL语句，你需要手动关闭reader.
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="parameters">SQL参数列表</param>
        /// <returns>代表查询结果的SQLDataReader</returns>
        public SqlDataReader ExecuteReader(string sql, SqlParameter[] parameters)
        {
            conn = new SqlConnection(connString);
            comm = new SqlCommand(sql, conn);
            if (parameters != null)
            {
                comm.Parameters.AddRange(parameters);
            }
            conn.Open();
            reader = comm.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;

        }

        public SqlDataReader ExecuteReader(string sql)
        {
            return ExecuteReader(sql, null);
        }

        /// <summary>
        /// 返回表记录
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="parameters">SQL参数列表</param>
        /// <returns></returns>
        public DataTable ExecuteSqlDataAdapter(string sql, SqlParameter[] parameters, int index = 0)
        {
            DataSet ds = ExecuteSqlDataAdapter(sql, parameters);

            return ds.Tables[index];
        }

        /// <summary>
        /// 返回表数据集
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="parameters">SQL参数列表</param>
        /// <returns></returns>
        public DataSet ExecuteSqlDataAdapter(string sql, SqlParameter[] parameters)
        {
            using (conn = new SqlConnection(connString))
            {
                comm = new SqlCommand(sql, conn);
                if (parameters != null && parameters.Length > 0)
                {
                    comm.Parameters.AddRange(parameters);
                }
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                adapter.Dispose();
                return ds;
            }
        }

        public void Close()
        {
            if (conn != null)
            {
                conn = null;
            }
            if (comm != null)
            {
                comm = null;
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }

        }
    }
}
