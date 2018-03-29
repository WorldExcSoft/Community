using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.Common
{
    public abstract class DBHelper
    {
        private static readonly string connectString = ConfigurationManager.ConnectionStrings["connectString"].ToString();

        /// <summary>
        /// 执行命令(没有返回自定义结果）
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(string cmdText, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            PreCommand(conn, cmd, cmdText, param);
            bool b = false;
            try
            {
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                b = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return b;
        }
        /// <summary>
        /// 执行命令并返回自定义结果
        /// </summary>
        /// <returns></returns>
        public static object ExecuteScalar(string cmdText, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            PreCommand(conn, cmd, cmdText, param);
            object obj = null;
            try
            {
                obj = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
            }
            catch(Exception e) {
                throw new Exception(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return obj;
        }
        /// <summary>
        /// 返回读取器对象
        /// </summary>
        public static SqlDataReader ExecuteReader(string cmdText, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            PreCommand(conn, cmd, cmdText, param);
            SqlDataReader rd = null;
            try
            {
                rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
            }
            catch { conn.Close(); }
            return rd;
        }


        /**/
        /// <summary> 
        /// 执行存储过程 
        /// </summary> 
        /// <param name="storedProcName">存储过程名</param> 
        /// <param name="parameters">存储过程参数</param> 
        /// <returns>SqlDataReader</returns> 
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectString);
            SqlDataReader returnReader;
            connection.Open();
            using (SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters))
            {
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    return returnReader;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        /// <summary>
        /// 公共方法
        /// </summary>
        private static void PreCommand(SqlConnection conn, SqlCommand cmd, string cmdText, SqlParameter[] para)
        {
            conn.ConnectionString = connectString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.StoredProcedure;
            if (para != null)
                cmd.Parameters.AddRange(para);
        }


        /**/
        /// <summary> 
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值) 
        /// </summary> 
        /// <param name="connection">数据库连接</param> 
        /// <param name="storedProcName">存储过程名</param> 
        /// <param name="parameters">存储过程参数</param> 
        /// <returns>SqlCommand</returns> 
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }


    }
}
