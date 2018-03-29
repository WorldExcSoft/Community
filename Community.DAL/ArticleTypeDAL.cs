using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class ArticleTypeDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ArticleType">ArticleType实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(ArticleType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ArticleTypeName",model.ArticleTypeName),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@PlatformId",model.PlatformId)
            };
           return DBHelper.ExecuteNonQuery("ArticleType_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ArticleType">ArticleType实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(ArticleType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ArticleTypeName",model.ArticleTypeName),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@PlatformId",model.PlatformId)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("ArticleType_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ArticleType">ArticleType实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(ArticleType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ArticleTypeId",model.ArticleTypeId),
                new SqlParameter ("@ArticleTypeName",model.ArticleTypeName),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@PlatformId",model.PlatformId)
            };
           return DBHelper.ExecuteNonQuery("ArticleType_Change",param);
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
                new SqlParameter ("@ArticleTypeId",Id)
            };
           return DBHelper.ExecuteNonQuery ("ArticleType_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("ArticleType_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<ArticleType> SelectAll()
        {
            List<ArticleType> list = new List<ArticleType>();
            ArticleType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ArticleType_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new ArticleType();
                    model.ArticleTypeId= Convert.ToInt32(dr["ArticleTypeId"]);
                    if (DBNull.Value!=dr["ArticleTypeName"])
                        model.ArticleTypeName = dr["ArticleTypeName"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["PlatformId"])
                        model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>ArticleType实体类对象</returns>
        public ArticleType SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ArticleTypeId",Id)
            };
            ArticleType model = new ArticleType();
            using (SqlDataReader dr = DBHelper.RunProcedure("ArticleType_SelectById", param))
            {
                if (dr.Read())
                {
                    model.ArticleTypeId= Convert.ToInt32(dr["ArticleTypeId"]);
                    if (DBNull.Value!=dr["ArticleTypeName"])
                        model.ArticleTypeName = dr["ArticleTypeName"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["PlatformId"])
                        model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>ArticleType实体类对象</returns>
        public List<ArticleType> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<ArticleType> list = new List<ArticleType>();
            ArticleType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ArticleType_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new ArticleType();
                    model.ArticleTypeId= Convert.ToInt32(dr["ArticleTypeId"]);
                    if (DBNull.Value!=dr["ArticleTypeName"])
                        model.ArticleTypeName = dr["ArticleTypeName"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["PlatformId"])
                        model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
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
        /// <returns>ArticleType实体类对象</returns>
        public List<ArticleType> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<ArticleType> list = new List<ArticleType>();
            ArticleType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ArticleType_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new ArticleType();
                    model.ArticleTypeId= Convert.ToInt32(dr["ArticleTypeId"]);
                    if (DBNull.Value!=dr["ArticleTypeName"])
                        model.ArticleTypeName = dr["ArticleTypeName"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["PlatformId"])
                        model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
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

