using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class ArticleDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Article">Article实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(Article model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ArticleName",model.ArticleName),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@CreateUserName",model.CreateUserName),
                new SqlParameter ("@Source",model.Source),
                new SqlParameter ("@Content",model.Content),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@PublishDate",model.PublishDate),
                new SqlParameter ("@ArticleType",model.ArticleType),
                new SqlParameter ("@AssistCount",model.AssistCount),
                new SqlParameter ("@ClickRate",model.ClickRate),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@IsPush",model.IsPush),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@ShowType",model.ShowType),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Remark",model.Remark)
            };
           return DBHelper.ExecuteNonQuery("Article_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Article">Article实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(Article model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ArticleName",model.ArticleName),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@CreateUserName",model.CreateUserName),
                new SqlParameter ("@Source",model.Source),
                new SqlParameter ("@Content",model.Content),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@PublishDate",model.PublishDate),
                new SqlParameter ("@ArticleType",model.ArticleType),
                new SqlParameter ("@AssistCount",model.AssistCount),
                new SqlParameter ("@ClickRate",model.ClickRate),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@IsPush",model.IsPush),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@ShowType",model.ShowType),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Remark",model.Remark)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("Article_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Article">Article实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(Article model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ArticleId",model.ArticleId),
                new SqlParameter ("@ArticleName",model.ArticleName),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@CreateUserName",model.CreateUserName),
                new SqlParameter ("@Source",model.Source),
                new SqlParameter ("@Content",model.Content),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@PublishDate",model.PublishDate),
                new SqlParameter ("@ArticleType",model.ArticleType),
                new SqlParameter ("@AssistCount",model.AssistCount),
                new SqlParameter ("@ClickRate",model.ClickRate),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@IsPush",model.IsPush),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@ShowType",model.ShowType),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Remark",model.Remark)
            };
           return DBHelper.ExecuteNonQuery("Article_Change",param);
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
                new SqlParameter ("@ArticleId",Id)
            };
           return DBHelper.ExecuteNonQuery ("Article_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("Article_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<Article> SelectAll()
        {
            List<Article> list = new List<Article>();
            Article model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Article_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new Article();
                    model.ArticleId= Convert.ToInt32(dr["ArticleId"]);
                    if (DBNull.Value!=dr["ArticleName"])
                        model.ArticleName = dr["ArticleName"].ToString();
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["CreateUserName"])
                        model.CreateUserName = dr["CreateUserName"].ToString();
                    if (DBNull.Value!=dr["Source"])
                        model.Source = dr["Source"].ToString();
                    if (DBNull.Value!=dr["Content"])
                        model.Content = dr["Content"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["PublishDate"])
                        model.PublishDate= Convert.ToDateTime(dr["PublishDate"]);
                    if (DBNull.Value!=dr["ArticleType"])
                        model.ArticleType = dr["ArticleType"].ToString();
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["ClickRate"])
                        model.ClickRate= Convert.ToInt32(dr["ClickRate"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["IsPush"])
                        model.IsPush= Convert.ToInt32(dr["IsPush"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["ShowType"])
                        model.ShowType= Convert.ToInt32(dr["ShowType"]);
                    if (DBNull.Value!=dr["IsDelete"])
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
        /// <returns>Article实体类对象</returns>
        public Article SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ArticleId",Id)
            };
            Article model = new Article();
            using (SqlDataReader dr = DBHelper.RunProcedure("Article_SelectById", param))
            {
                if (dr.Read())
                {
                    model.ArticleId= Convert.ToInt32(dr["ArticleId"]);
                    if (DBNull.Value!=dr["ArticleName"])
                        model.ArticleName = dr["ArticleName"].ToString();
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["CreateUserName"])
                        model.CreateUserName = dr["CreateUserName"].ToString();
                    if (DBNull.Value!=dr["Source"])
                        model.Source = dr["Source"].ToString();
                    if (DBNull.Value!=dr["Content"])
                        model.Content = dr["Content"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["PublishDate"])
                        model.PublishDate= Convert.ToDateTime(dr["PublishDate"]);
                    if (DBNull.Value!=dr["ArticleType"])
                        model.ArticleType = dr["ArticleType"].ToString();
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["ClickRate"])
                        model.ClickRate= Convert.ToInt32(dr["ClickRate"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["IsPush"])
                        model.IsPush= Convert.ToInt32(dr["IsPush"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["ShowType"])
                        model.ShowType= Convert.ToInt32(dr["ShowType"]);
                    if (DBNull.Value!=dr["IsDelete"])
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
        /// <returns>Article实体类对象</returns>
        public List<Article> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<Article> list = new List<Article>();
            Article model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Article_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new Article();
                    model.ArticleId= Convert.ToInt32(dr["ArticleId"]);
                    if (DBNull.Value!=dr["ArticleName"])
                        model.ArticleName = dr["ArticleName"].ToString();
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["CreateUserName"])
                        model.CreateUserName = dr["CreateUserName"].ToString();
                    if (DBNull.Value!=dr["Source"])
                        model.Source = dr["Source"].ToString();
                    if (DBNull.Value!=dr["Content"])
                        model.Content = dr["Content"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["PublishDate"])
                        model.PublishDate= Convert.ToDateTime(dr["PublishDate"]);
                    if (DBNull.Value!=dr["ArticleType"])
                        model.ArticleType = dr["ArticleType"].ToString();
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["ClickRate"])
                        model.ClickRate= Convert.ToInt32(dr["ClickRate"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["IsPush"])
                        model.IsPush= Convert.ToInt32(dr["IsPush"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["ShowType"])
                        model.ShowType= Convert.ToInt32(dr["ShowType"]);
                    if (DBNull.Value!=dr["IsDelete"])
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
        /// <returns>Article实体类对象</returns>
        public List<Article> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<Article> list = new List<Article>();
            Article model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Article_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new Article();
                    model.ArticleId= Convert.ToInt32(dr["ArticleId"]);
                    if (DBNull.Value!=dr["ArticleName"])
                        model.ArticleName = dr["ArticleName"].ToString();
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["CreateUserName"])
                        model.CreateUserName = dr["CreateUserName"].ToString();
                    if (DBNull.Value!=dr["Source"])
                        model.Source = dr["Source"].ToString();
                    if (DBNull.Value!=dr["Content"])
                        model.Content = dr["Content"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["PublishDate"])
                        model.PublishDate= Convert.ToDateTime(dr["PublishDate"]);
                    if (DBNull.Value!=dr["ArticleType"])
                        model.ArticleType = dr["ArticleType"].ToString();
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["ClickRate"])
                        model.ClickRate= Convert.ToInt32(dr["ClickRate"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["IsPush"])
                        model.IsPush= Convert.ToInt32(dr["IsPush"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["ShowType"])
                        model.ShowType= Convert.ToInt32(dr["ShowType"]);
                    if (DBNull.Value!=dr["IsDelete"])
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

