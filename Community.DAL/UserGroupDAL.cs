using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class UserGroupDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="UserGroup">UserGroup实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(UserGroup model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@GroupName",model.GroupName),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@PlatformId",model.PlatformId)
            };
           return DBHelper.ExecuteNonQuery("UserGroup_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="UserGroup">UserGroup实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(UserGroup model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@GroupName",model.GroupName),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@PlatformId",model.PlatformId)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("UserGroup_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="UserGroup">UserGroup实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(UserGroup model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@UserGroupId",model.UserGroupId),
                new SqlParameter ("@GroupName",model.GroupName),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@PlatformId",model.PlatformId)
            };
           return DBHelper.ExecuteNonQuery("UserGroup_Change",param);
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
                new SqlParameter ("@UserGroupId",Id)
            };
           return DBHelper.ExecuteNonQuery ("UserGroup_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("UserGroup_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<UserGroup> SelectAll()
        {
            List<UserGroup> list = new List<UserGroup>();
            UserGroup model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("UserGroup_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new UserGroup();
                    model.UserGroupId= Convert.ToInt32(dr["UserGroupId"]);
                    model.GroupName = dr["GroupName"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value != dr["PlatformId"])
                        model.PlatformId = Convert.ToInt32(dr["PlatformId"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>UserGroup实体类对象</returns>
        public UserGroup SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@UserGroupId",Id)
            };
            UserGroup model = new UserGroup();
            using (SqlDataReader dr = DBHelper.RunProcedure("UserGroup_SelectById", param))
            {
                if (dr.Read())
                {
                    model.UserGroupId= Convert.ToInt32(dr["UserGroupId"]);
                    model.GroupName = dr["GroupName"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value != dr["PlatformId"])
                        model.PlatformId = Convert.ToInt32(dr["PlatformId"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>UserGroup实体类对象</returns>
        public List<UserGroup> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<UserGroup> list = new List<UserGroup>();
            UserGroup model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("UserGroup_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new UserGroup();
                    model.UserGroupId= Convert.ToInt32(dr["UserGroupId"]);
                    model.GroupName = dr["GroupName"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value != dr["PlatformId"])
                        model.PlatformId = Convert.ToInt32(dr["PlatformId"]);
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
        /// <returns>UserGroup实体类对象</returns>
        public List<UserGroup> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<UserGroup> list = new List<UserGroup>();
            UserGroup model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("UserGroup_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new UserGroup();
                    model.UserGroupId= Convert.ToInt32(dr["UserGroupId"]);
                    model.GroupName = dr["GroupName"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value != dr["PlatformId"])
                        model.PlatformId = Convert.ToInt32(dr["PlatformId"]);
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

