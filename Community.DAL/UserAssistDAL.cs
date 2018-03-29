using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class UserAssistDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="UserAssist">UserAssist实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(UserAssist model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@ObjId",model.ObjId),
                new SqlParameter ("@ObjType",model.ObjType),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@CreateDate",model.CreateDate)
            };
           return DBHelper.ExecuteNonQuery("UserAssist_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="UserAssist">UserAssist实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(UserAssist model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@ObjId",model.ObjId),
                new SqlParameter ("@ObjType",model.ObjType),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@CreateDate",model.CreateDate)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("UserAssist_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="UserAssist">UserAssist实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(UserAssist model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@AssistId",model.AssistId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@ObjId",model.ObjId),
                new SqlParameter ("@ObjType",model.ObjType),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@CreateDate",model.CreateDate)
            };
           return DBHelper.ExecuteNonQuery("UserAssist_Change",param);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Delete(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@AssistId",Id)
            };
           return DBHelper.ExecuteNonQuery ("UserAssist_Delete",param);
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="WhereString">删除条件</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool DeleteByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
           return DBHelper.ExecuteNonQuery ("UserAssist_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<UserAssist> SelectAll()
        {
            List<UserAssist> list = new List<UserAssist>();
            UserAssist model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("UserAssist_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new UserAssist();
                    model.AssistId= Convert.ToInt32(dr["AssistId"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["ObjId"])
                        model.ObjId= Convert.ToInt32(dr["ObjId"]);
                    if (DBNull.Value!=dr["ObjType"])
                        model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>UserAssist实体类对象</returns>
        public UserAssist SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@AssistId",Id)
            };
            UserAssist model = new UserAssist();
            using (SqlDataReader dr = DBHelper.RunProcedure("UserAssist_SelectById", param))
            {
                if (dr.Read())
                {
                    model.AssistId= Convert.ToInt32(dr["AssistId"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["ObjId"])
                        model.ObjId= Convert.ToInt32(dr["ObjId"]);
                    if (DBNull.Value!=dr["ObjType"])
                        model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>UserAssist实体类对象</returns>
        public List<UserAssist> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<UserAssist> list = new List<UserAssist>();
            UserAssist model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("UserAssist_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new UserAssist();
                    model.AssistId= Convert.ToInt32(dr["AssistId"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["ObjId"])
                        model.ObjId= Convert.ToInt32(dr["ObjId"]);
                    if (DBNull.Value!=dr["ObjType"])
                        model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 数据访问通过条件查询并分页排序
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <param name="PageIndex">当前页码</param>
        /// <param name="PageSize">页大小（每页显示多少条数据）</param>
        /// <param name="OrderString">排序条件（排序条件为必须参数）</param>
        /// <returns>UserAssist实体类对象</returns>
        public List<UserAssist> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<UserAssist> list = new List<UserAssist>();
            UserAssist model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("UserAssist_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new UserAssist();
                    model.AssistId= Convert.ToInt32(dr["AssistId"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["ObjId"])
                        model.ObjId= Convert.ToInt32(dr["ObjId"]);
                    if (DBNull.Value!=dr["ObjType"])
                        model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    list.Add(model);
                }
            if (dr.NextResult() && dr.Read())
            {
            TotalCount = Convert.ToInt32(dr["TotalCount"]);
             }
            else
            {
            TotalCount = 0;
            }
            }
            return list;
        }

        
 
      #endregion

    }
}

