using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class PlatformDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Platform">Platform实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(Platform model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PlatformName",model.PlatformName),
                new SqlParameter ("@DomainName",model.DomainName),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Status",model.Status)
                
            };
           return DBHelper.ExecuteNonQuery("Platform_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Platform">Platform实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(Platform model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PlatformName",model.PlatformName),
                new SqlParameter ("@DomainName",model.DomainName),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Status",model.Status)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("Platform_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Platform">Platform实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(Platform model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PlatformId",model.PlatformId),
                new SqlParameter ("@PlatformName",model.PlatformName),
                new SqlParameter ("@DomainName",model.DomainName),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Status",model.Status)
            };
           return DBHelper.ExecuteNonQuery("Platform_Change",param);
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
                new SqlParameter ("@PlatformId",Id)
            };
           return DBHelper.ExecuteNonQuery ("Platform_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("Platform_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<Platform> SelectAll()
        {
            List<Platform> list = new List<Platform>();
            Platform model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Platform_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new Platform();
                    model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
                    if (DBNull.Value!=dr["PlatformName"])
                        model.PlatformName = dr["PlatformName"].ToString();
                    if (DBNull.Value!=dr["DomainName"])
                        model.DomainName = dr["DomainName"].ToString();
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>Platform实体类对象</returns>
        public Platform SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PlatformId",Id)
            };
            Platform model = new Platform();
            using (SqlDataReader dr = DBHelper.RunProcedure("Platform_SelectById", param))
            {
                if (dr.Read())
                {
                    model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
                    if (DBNull.Value!=dr["PlatformName"])
                        model.PlatformName = dr["PlatformName"].ToString();
                    if (DBNull.Value!=dr["DomainName"])
                        model.DomainName = dr["DomainName"].ToString();
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>Platform实体类对象</returns>
        public List<Platform> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<Platform> list = new List<Platform>();
            Platform model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Platform_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new Platform();
                    model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
                    if (DBNull.Value!=dr["PlatformName"])
                        model.PlatformName = dr["PlatformName"].ToString();
                    if (DBNull.Value!=dr["DomainName"])
                        model.DomainName = dr["DomainName"].ToString();
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
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
        /// <returns>Platform实体类对象</returns>
        public List<Platform> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<Platform> list = new List<Platform>();
            Platform model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Platform_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new Platform();
                    model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
                    if (DBNull.Value!=dr["PlatformName"])
                        model.PlatformName = dr["PlatformName"].ToString();
                    if (DBNull.Value!=dr["DomainName"])
                        model.DomainName = dr["DomainName"].ToString();
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
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

