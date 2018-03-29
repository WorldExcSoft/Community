using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class SysRolePermissionDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="SysRolePermission">SysRolePermission实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(SysRolePermission model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@RoleId",model.RoleId),
                new SqlParameter ("@PageCode",model.PageCode),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@PageValue",model.PageValue)
            };
           return DBHelper.ExecuteNonQuery("SysRolePermission_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="SysRolePermission">SysRolePermission实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(SysRolePermission model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@RoleId",model.RoleId),
                new SqlParameter ("@PageCode",model.PageCode),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@PageValue",model.PageValue)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("SysRolePermission_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="SysRolePermission">SysRolePermission实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(SysRolePermission model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PermissionId",model.PermissionId),
                new SqlParameter ("@RoleId",model.RoleId),
                new SqlParameter ("@PageCode",model.PageCode),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@PageValue",model.PageValue)
            };
           return DBHelper.ExecuteNonQuery("SysRolePermission_Change",param);
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
                new SqlParameter ("@PermissionId",Id)
            };
           return DBHelper.ExecuteNonQuery ("SysRolePermission_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("SysRolePermission_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<SysRolePermission> SelectAll()
        {
            List<SysRolePermission> list = new List<SysRolePermission>();
            SysRolePermission model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("SysRolePermission_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new SysRolePermission();
                    model.PermissionId= Convert.ToInt32(dr["PermissionId"]);
                    model.RoleId= Convert.ToInt32(dr["RoleId"]);
                    if (DBNull.Value!=dr["PageCode"])
                        model.PageCode = dr["PageCode"].ToString();
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["PageValue"])
                        model.PageValue= Convert.ToInt32(dr["PageValue"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>SysRolePermission实体类对象</returns>
        public SysRolePermission SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PermissionId",Id)
            };
            SysRolePermission model = new SysRolePermission();
            using (SqlDataReader dr = DBHelper.RunProcedure("SysRolePermission_SelectById", param))
            {
                if (dr.Read())
                {
                    model.PermissionId= Convert.ToInt32(dr["PermissionId"]);
                    model.RoleId= Convert.ToInt32(dr["RoleId"]);
                    if (DBNull.Value!=dr["PageCode"])
                        model.PageCode = dr["PageCode"].ToString();
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["PageValue"])
                        model.PageValue= Convert.ToInt32(dr["PageValue"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>SysRolePermission实体类对象</returns>
        public List<SysRolePermission> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<SysRolePermission> list = new List<SysRolePermission>();
            SysRolePermission model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("SysRolePermission_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new SysRolePermission();
                    model.PermissionId= Convert.ToInt32(dr["PermissionId"]);
                    model.RoleId= Convert.ToInt32(dr["RoleId"]);
                    if (DBNull.Value!=dr["PageCode"])
                        model.PageCode = dr["PageCode"].ToString();
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["PageValue"])
                        model.PageValue= Convert.ToInt32(dr["PageValue"]);
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
        /// <returns>SysRolePermission实体类对象</returns>
        public List<SysRolePermission> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<SysRolePermission> list = new List<SysRolePermission>();
            SysRolePermission model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("SysRolePermission_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new SysRolePermission();
                    model.PermissionId= Convert.ToInt32(dr["PermissionId"]);
                    model.RoleId= Convert.ToInt32(dr["RoleId"]);
                    if (DBNull.Value!=dr["PageCode"])
                        model.PageCode = dr["PageCode"].ToString();
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["PageValue"])
                        model.PageValue= Convert.ToInt32(dr["PageValue"]);
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

