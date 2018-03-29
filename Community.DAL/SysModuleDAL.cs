using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class SysModuleDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="SysModule">SysModule实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(SysModule model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ModuleName",model.ModuleName),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@PageCode",model.PageCode),
                new SqlParameter ("@Url",model.Url),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@Level",model.Level),
                new SqlParameter ("@IsSystem",model.IsSystem),
                new SqlParameter ("@IsClose",model.IsClose),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Remark",model.Remark)
            };
           return DBHelper.ExecuteNonQuery("SysModule_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="SysModule">SysModule实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(SysModule model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ModuleName",model.ModuleName),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@PageCode",model.PageCode),
                new SqlParameter ("@Url",model.Url),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@Level",model.Level),
                new SqlParameter ("@IsSystem",model.IsSystem),
                new SqlParameter ("@IsClose",model.IsClose),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Remark",model.Remark)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("SysModule_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="SysModule">SysModule实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(SysModule model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ModuleID",model.ModuleID),
                new SqlParameter ("@ModuleName",model.ModuleName),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@PageCode",model.PageCode),
                new SqlParameter ("@Url",model.Url),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@Level",model.Level),
                new SqlParameter ("@IsSystem",model.IsSystem),
                new SqlParameter ("@IsClose",model.IsClose),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Remark",model.Remark)
            };
           return DBHelper.ExecuteNonQuery("SysModule_Change",param);
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
                new SqlParameter ("@ModuleID",Id)
            };
           return DBHelper.ExecuteNonQuery ("SysModule_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("SysModule_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<SysModule> SelectAll()
        {
            List<SysModule> list = new List<SysModule>();
            SysModule model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("SysModule_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new SysModule();
                    model.ModuleID= Convert.ToInt32(dr["ModuleID"]);
                    model.ModuleName = dr["ModuleName"].ToString();
                    model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    model.PageCode = dr["PageCode"].ToString();
                    if (DBNull.Value!=dr["Url"])
                        model.Url = dr["Url"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["Level"])
                        model.Level= Convert.ToInt32(dr["Level"]);
                    if (DBNull.Value!=dr["IsSystem"])
                        model.IsSystem= Convert.ToBoolean(dr["IsSystem"]);
                    if (DBNull.Value!=dr["IsClose"])
                        model.IsClose= Convert.ToBoolean(dr["IsClose"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Remark"])
                        model.Remark = dr["Remark"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>SysModule实体类对象</returns>
        public SysModule SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ModuleID",Id)
            };
            SysModule model = new SysModule();
            using (SqlDataReader dr = DBHelper.RunProcedure("SysModule_SelectById", param))
            {
                if (dr.Read())
                {
                    model.ModuleID= Convert.ToInt32(dr["ModuleID"]);
                    model.ModuleName = dr["ModuleName"].ToString();
                    model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    model.PageCode = dr["PageCode"].ToString();
                    if (DBNull.Value!=dr["Url"])
                        model.Url = dr["Url"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["Level"])
                        model.Level= Convert.ToInt32(dr["Level"]);
                    if (DBNull.Value!=dr["IsSystem"])
                        model.IsSystem= Convert.ToBoolean(dr["IsSystem"]);
                    if (DBNull.Value!=dr["IsClose"])
                        model.IsClose= Convert.ToBoolean(dr["IsClose"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Remark"])
                        model.Remark = dr["Remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>SysModule实体类对象</returns>
        public List<SysModule> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<SysModule> list = new List<SysModule>();
            SysModule model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("SysModule_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new SysModule();
                    model.ModuleID= Convert.ToInt32(dr["ModuleID"]);
                    model.ModuleName = dr["ModuleName"].ToString();
                    model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    model.PageCode = dr["PageCode"].ToString();
                    if (DBNull.Value!=dr["Url"])
                        model.Url = dr["Url"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["Level"])
                        model.Level= Convert.ToInt32(dr["Level"]);
                    if (DBNull.Value!=dr["IsSystem"])
                        model.IsSystem= Convert.ToBoolean(dr["IsSystem"]);
                    if (DBNull.Value!=dr["IsClose"])
                        model.IsClose= Convert.ToBoolean(dr["IsClose"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Remark"])
                        model.Remark = dr["Remark"].ToString();
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
        /// <returns>SysModule实体类对象</returns>
        public List<SysModule> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<SysModule> list = new List<SysModule>();
            SysModule model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("SysModule_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new SysModule();
                    model.ModuleID= Convert.ToInt32(dr["ModuleID"]);
                    model.ModuleName = dr["ModuleName"].ToString();
                    model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    model.PageCode = dr["PageCode"].ToString();
                    if (DBNull.Value!=dr["Url"])
                        model.Url = dr["Url"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["Level"])
                        model.Level= Convert.ToInt32(dr["Level"]);
                    if (DBNull.Value!=dr["IsSystem"])
                        model.IsSystem= Convert.ToBoolean(dr["IsSystem"]);
                    if (DBNull.Value!=dr["IsClose"])
                        model.IsClose= Convert.ToBoolean(dr["IsClose"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Remark"])
                        model.Remark = dr["Remark"].ToString();
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

