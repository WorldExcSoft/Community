using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class SysEventDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="SysEvent">SysEvent实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(SysEvent model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@UserName",model.UserName),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@ModuleName",model.ModuleName),
                new SqlParameter ("@PageCode",model.PageCode),
                new SqlParameter ("@ModuleUrl",model.ModuleUrl),
                new SqlParameter ("@EventType",model.EventType),
                new SqlParameter ("@VisitIp",model.VisitIp),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("SysEvent_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="SysEvent">SysEvent实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(SysEvent model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@UserName",model.UserName),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@ModuleName",model.ModuleName),
                new SqlParameter ("@PageCode",model.PageCode),
                new SqlParameter ("@ModuleUrl",model.ModuleUrl),
                new SqlParameter ("@EventType",model.EventType),
                new SqlParameter ("@VisitIp",model.VisitIp),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("SysEvent_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="SysEvent">SysEvent实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(SysEvent model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@EventId",model.EventId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@UserName",model.UserName),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@ModuleName",model.ModuleName),
                new SqlParameter ("@PageCode",model.PageCode),
                new SqlParameter ("@ModuleUrl",model.ModuleUrl),
                new SqlParameter ("@EventType",model.EventType),
                new SqlParameter ("@VisitIp",model.VisitIp),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("SysEvent_Change",param);
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
                new SqlParameter ("@EventId",Id)
            };
           return DBHelper.ExecuteNonQuery ("SysEvent_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("SysEvent_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<SysEvent> SelectAll()
        {
            List<SysEvent> list = new List<SysEvent>();
            SysEvent model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("SysEvent_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new SysEvent();
                    model.EventId= Convert.ToInt32(dr["EventId"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["UserName"])
                        model.UserName = dr["UserName"].ToString();
                    model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["ModuleName"])
                        model.ModuleName = dr["ModuleName"].ToString();
                    if (DBNull.Value!=dr["PageCode"])
                        model.PageCode = dr["PageCode"].ToString();
                    if (DBNull.Value!=dr["ModuleUrl"])
                        model.ModuleUrl = dr["ModuleUrl"].ToString();
                    model.EventType= Convert.ToInt32(dr["EventType"]);
                    if (DBNull.Value!=dr["VisitIp"])
                        model.VisitIp = dr["VisitIp"].ToString();
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>SysEvent实体类对象</returns>
        public SysEvent SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@EventId",Id)
            };
            SysEvent model = new SysEvent();
            using (SqlDataReader dr = DBHelper.RunProcedure("SysEvent_SelectById", param))
            {
                if (dr.Read())
                {
                    model.EventId= Convert.ToInt32(dr["EventId"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["UserName"])
                        model.UserName = dr["UserName"].ToString();
                    model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["ModuleName"])
                        model.ModuleName = dr["ModuleName"].ToString();
                    if (DBNull.Value!=dr["PageCode"])
                        model.PageCode = dr["PageCode"].ToString();
                    if (DBNull.Value!=dr["ModuleUrl"])
                        model.ModuleUrl = dr["ModuleUrl"].ToString();
                    model.EventType= Convert.ToInt32(dr["EventType"]);
                    if (DBNull.Value!=dr["VisitIp"])
                        model.VisitIp = dr["VisitIp"].ToString();
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>SysEvent实体类对象</returns>
        public List<SysEvent> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<SysEvent> list = new List<SysEvent>();
            SysEvent model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("SysEvent_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new SysEvent();
                    model.EventId= Convert.ToInt32(dr["EventId"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["UserName"])
                        model.UserName = dr["UserName"].ToString();
                    model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["ModuleName"])
                        model.ModuleName = dr["ModuleName"].ToString();
                    if (DBNull.Value!=dr["PageCode"])
                        model.PageCode = dr["PageCode"].ToString();
                    if (DBNull.Value!=dr["ModuleUrl"])
                        model.ModuleUrl = dr["ModuleUrl"].ToString();
                    model.EventType= Convert.ToInt32(dr["EventType"]);
                    if (DBNull.Value!=dr["VisitIp"])
                        model.VisitIp = dr["VisitIp"].ToString();
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
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
        /// <returns>SysEvent实体类对象</returns>
        public List<SysEvent> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<SysEvent> list = new List<SysEvent>();
            SysEvent model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("SysEvent_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new SysEvent();
                    model.EventId= Convert.ToInt32(dr["EventId"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["UserName"])
                        model.UserName = dr["UserName"].ToString();
                    model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["ModuleName"])
                        model.ModuleName = dr["ModuleName"].ToString();
                    if (DBNull.Value!=dr["PageCode"])
                        model.PageCode = dr["PageCode"].ToString();
                    if (DBNull.Value!=dr["ModuleUrl"])
                        model.ModuleUrl = dr["ModuleUrl"].ToString();
                    model.EventType= Convert.ToInt32(dr["EventType"]);
                    if (DBNull.Value!=dr["VisitIp"])
                        model.VisitIp = dr["VisitIp"].ToString();
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
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

