using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class BookChapterDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="BookChapter">BookChapter实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(BookChapter model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@BookId",model.BookId),
                new SqlParameter ("@ChapterName",model.ChapterName),
                new SqlParameter ("@Url",model.Url),
                new SqlParameter ("@Content",model.Content),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@WordCount",model.WordCount),
                new SqlParameter ("@ClickCount",model.ClickCount),
                new SqlParameter ("@AssistCount",model.AssistCount),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@OrderIndex",model.OrderIndex)
            };
           return DBHelper.ExecuteNonQuery("BookChapter_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="BookChapter">BookChapter实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(BookChapter model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@BookId",model.BookId),
                new SqlParameter ("@ChapterName",model.ChapterName),
                new SqlParameter ("@Url",model.Url),
                new SqlParameter ("@Content",model.Content),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@WordCount",model.WordCount),
                new SqlParameter ("@ClickCount",model.ClickCount),
                new SqlParameter ("@AssistCount",model.AssistCount),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@OrderIndex",model.OrderIndex)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("BookChapter_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="BookChapter">BookChapter实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(BookChapter model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@BookChapterId",model.BookChapterId),
                new SqlParameter ("@BookId",model.BookId),
                new SqlParameter ("@ChapterName",model.ChapterName),
                new SqlParameter ("@Url",model.Url),
                new SqlParameter ("@Content",model.Content),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@WordCount",model.WordCount),
                new SqlParameter ("@ClickCount",model.ClickCount),
                new SqlParameter ("@AssistCount",model.AssistCount),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@OrderIndex",model.OrderIndex)
            };
           return DBHelper.ExecuteNonQuery("BookChapter_Change",param);
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
                new SqlParameter ("@BookChapterId",Id)
            };
           return DBHelper.ExecuteNonQuery ("BookChapter_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("BookChapter_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<BookChapter> SelectAll()
        {
            List<BookChapter> list = new List<BookChapter>();
            BookChapter model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("BookChapter_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new BookChapter();
                    model.BookChapterId= Convert.ToInt32(dr["BookChapterId"]);
                    if (DBNull.Value!=dr["BookId"])
                        model.BookId= Convert.ToInt32(dr["BookId"]);
                    if (DBNull.Value!=dr["ChapterName"])
                        model.ChapterName = dr["ChapterName"].ToString();
                    if (DBNull.Value!=dr["Url"])
                        model.Url = dr["Url"].ToString();
                    if (DBNull.Value!=dr["Content"])
                        model.Content = dr["Content"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["WordCount"])
                        model.WordCount= Convert.ToInt32(dr["WordCount"]);
                    if (DBNull.Value!=dr["ClickCount"])
                        model.ClickCount= Convert.ToInt32(dr["ClickCount"]);
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>BookChapter实体类对象</returns>
        public BookChapter SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@BookChapterId",Id)
            };
            BookChapter model = new BookChapter();
            using (SqlDataReader dr = DBHelper.RunProcedure("BookChapter_SelectById", param))
            {
                if (dr.Read())
                {
                    model.BookChapterId= Convert.ToInt32(dr["BookChapterId"]);
                    if (DBNull.Value!=dr["BookId"])
                        model.BookId= Convert.ToInt32(dr["BookId"]);
                    if (DBNull.Value!=dr["ChapterName"])
                        model.ChapterName = dr["ChapterName"].ToString();
                    if (DBNull.Value!=dr["Url"])
                        model.Url = dr["Url"].ToString();
                    if (DBNull.Value!=dr["Content"])
                        model.Content = dr["Content"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["WordCount"])
                        model.WordCount= Convert.ToInt32(dr["WordCount"]);
                    if (DBNull.Value!=dr["ClickCount"])
                        model.ClickCount= Convert.ToInt32(dr["ClickCount"]);
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>BookChapter实体类对象</returns>
        public List<BookChapter> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<BookChapter> list = new List<BookChapter>();
            BookChapter model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("BookChapter_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new BookChapter();
                    model.BookChapterId= Convert.ToInt32(dr["BookChapterId"]);
                    if (DBNull.Value!=dr["BookId"])
                        model.BookId= Convert.ToInt32(dr["BookId"]);
                    if (DBNull.Value!=dr["ChapterName"])
                        model.ChapterName = dr["ChapterName"].ToString();
                    if (DBNull.Value!=dr["Url"])
                        model.Url = dr["Url"].ToString();
                    if (DBNull.Value!=dr["Content"])
                        model.Content = dr["Content"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["WordCount"])
                        model.WordCount= Convert.ToInt32(dr["WordCount"]);
                    if (DBNull.Value!=dr["ClickCount"])
                        model.ClickCount= Convert.ToInt32(dr["ClickCount"]);
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
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
        /// <returns>BookChapter实体类对象</returns>
        public List<BookChapter> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<BookChapter> list = new List<BookChapter>();
            BookChapter model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("BookChapter_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new BookChapter();
                    model.BookChapterId= Convert.ToInt32(dr["BookChapterId"]);
                    if (DBNull.Value!=dr["BookId"])
                        model.BookId= Convert.ToInt32(dr["BookId"]);
                    if (DBNull.Value!=dr["ChapterName"])
                        model.ChapterName = dr["ChapterName"].ToString();
                    if (DBNull.Value!=dr["Url"])
                        model.Url = dr["Url"].ToString();
                    if (DBNull.Value!=dr["Content"])
                        model.Content = dr["Content"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["WordCount"])
                        model.WordCount= Convert.ToInt32(dr["WordCount"]);
                    if (DBNull.Value!=dr["ClickCount"])
                        model.ClickCount= Convert.ToInt32(dr["ClickCount"]);
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
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

