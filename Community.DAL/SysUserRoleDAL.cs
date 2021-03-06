using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class SysUserRoleDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="SysUserRole">SysUserRole实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(SysUserRole model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@RoleId",model.RoleId)
            };
           return DBHelper.ExecuteNonQuery("SysUserRole_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="SysUserRole">SysUserRole实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(SysUserRole model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@RoleId",model.RoleId)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("SysUserRole_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="SysUserRole">SysUserRole实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(SysUserRole model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@Id",model.Id),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@RoleId",model.RoleId)
            };
           return DBHelper.ExecuteNonQuery("SysUserRole_Change",param);
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
                new SqlParameter ("@Id",Id)
            };
           return DBHelper.ExecuteNonQuery ("SysUserRole_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("SysUserRole_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<SysUserRole> SelectAll()
        {
            List<SysUserRole> list = new List<SysUserRole>();
            SysUserRole model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("SysUserRole_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new SysUserRole();
                    model.Id= Convert.ToInt32(dr["Id"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["RoleId"])
                        model.RoleId= Convert.ToInt32(dr["RoleId"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>SysUserRole实体类对象</returns>
        public SysUserRole SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@Id",Id)
            };
            SysUserRole model = new SysUserRole();
            using (SqlDataReader dr = DBHelper.RunProcedure("SysUserRole_SelectById", param))
            {
                if (dr.Read())
                {
                    model.Id= Convert.ToInt32(dr["Id"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["RoleId"])
                        model.RoleId= Convert.ToInt32(dr["RoleId"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>SysUserRole实体类对象</returns>
        public List<SysUserRole> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<SysUserRole> list = new List<SysUserRole>();
            SysUserRole model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("SysUserRole_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new SysUserRole();
                    model.Id= Convert.ToInt32(dr["Id"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["RoleId"])
                        model.RoleId= Convert.ToInt32(dr["RoleId"]);
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
        /// <returns>SysUserRole实体类对象</returns>
        public List<SysUserRole> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<SysUserRole> list = new List<SysUserRole>();
            SysUserRole model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("SysUserRole_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new SysUserRole();
                    model.Id= Convert.ToInt32(dr["Id"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["RoleId"])
                        model.RoleId= Convert.ToInt32(dr["RoleId"]);
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

