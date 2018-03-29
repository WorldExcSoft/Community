using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class BookDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Book">Book实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(Book model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@BookTypeId",model.BookTypeId),
                new SqlParameter ("@BookName",model.BookName),
                new SqlParameter ("@BookDesc",model.BookDesc),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@AuthorInfo",model.AuthorInfo),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@BookChapterCount",model.BookChapterCount),
                new SqlParameter ("@WordCount",model.WordCount),
                new SqlParameter ("@ClickCount",model.ClickCount),
                new SqlParameter ("@AssistCount",model.AssistCount),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@Credit",model.Credit),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Coin",model.Coin)
            };
           return DBHelper.ExecuteNonQuery("Book_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Book">Book实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(Book model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@BookTypeId",model.BookTypeId),
                new SqlParameter ("@BookName",model.BookName),
                new SqlParameter ("@BookDesc",model.BookDesc),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@AuthorInfo",model.AuthorInfo),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@BookChapterCount",model.BookChapterCount),
                new SqlParameter ("@WordCount",model.WordCount),
                new SqlParameter ("@ClickCount",model.ClickCount),
                new SqlParameter ("@AssistCount",model.AssistCount),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@Credit",model.Credit),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Coin",model.Coin)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("Book_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Book">Book实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(Book model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@BookId",model.BookId),
                new SqlParameter ("@BookTypeId",model.BookTypeId),
                new SqlParameter ("@BookName",model.BookName),
                new SqlParameter ("@BookDesc",model.BookDesc),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@AuthorInfo",model.AuthorInfo),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@BookChapterCount",model.BookChapterCount),
                new SqlParameter ("@WordCount",model.WordCount),
                new SqlParameter ("@ClickCount",model.ClickCount),
                new SqlParameter ("@AssistCount",model.AssistCount),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@Credit",model.Credit),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Coin",model.Coin)
            };
           return DBHelper.ExecuteNonQuery("Book_Change",param);
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
                new SqlParameter ("@BookId",Id)
            };
           return DBHelper.ExecuteNonQuery ("Book_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("Book_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<Book> SelectAll()
        {
            List<Book> list = new List<Book>();
            Book model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Book_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new Book();
                    model.BookId= Convert.ToInt32(dr["BookId"]);
                    if (DBNull.Value!=dr["BookTypeId"])
                        model.BookTypeId= Convert.ToInt32(dr["BookTypeId"]);
                    if (DBNull.Value!=dr["BookName"])
                        model.BookName = dr["BookName"].ToString();
                    if (DBNull.Value!=dr["BookDesc"])
                        model.BookDesc = dr["BookDesc"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value != dr["AuthorInfo"])
                        model.AuthorInfo = dr["AuthorInfo"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["BookChapterCount"])
                        model.BookChapterCount= Convert.ToInt32(dr["BookChapterCount"]);
                    if (DBNull.Value!=dr["WordCount"])
                        model.WordCount= Convert.ToInt32(dr["WordCount"]);
                    if (DBNull.Value!=dr["ClickCount"])
                        model.ClickCount= Convert.ToInt32(dr["ClickCount"]);
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["Credit"])
                        model.Credit= Convert.ToDecimal(dr["Credit"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>Book实体类对象</returns>
        public Book SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@BookId",Id)
            };
            Book model = new Book();
            using (SqlDataReader dr = DBHelper.RunProcedure("Book_SelectById", param))
            {
                if (dr.Read())
                {
                    model.BookId= Convert.ToInt32(dr["BookId"]);
                    if (DBNull.Value!=dr["BookTypeId"])
                        model.BookTypeId= Convert.ToInt32(dr["BookTypeId"]);
                    if (DBNull.Value!=dr["BookName"])
                        model.BookName = dr["BookName"].ToString();
                    if (DBNull.Value!=dr["BookDesc"])
                        model.BookDesc = dr["BookDesc"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value != dr["AuthorInfo"])
                        model.AuthorInfo = dr["AuthorInfo"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["BookChapterCount"])
                        model.BookChapterCount= Convert.ToInt32(dr["BookChapterCount"]);
                    if (DBNull.Value!=dr["WordCount"])
                        model.WordCount= Convert.ToInt32(dr["WordCount"]);
                    if (DBNull.Value!=dr["ClickCount"])
                        model.ClickCount= Convert.ToInt32(dr["ClickCount"]);
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["Credit"])
                        model.Credit= Convert.ToDecimal(dr["Credit"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>Book实体类对象</returns>
        public List<Book> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<Book> list = new List<Book>();
            Book model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Book_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new Book();
                    model.BookId= Convert.ToInt32(dr["BookId"]);
                    if (DBNull.Value!=dr["BookTypeId"])
                        model.BookTypeId= Convert.ToInt32(dr["BookTypeId"]);
                    if (DBNull.Value!=dr["BookName"])
                        model.BookName = dr["BookName"].ToString();
                    if (DBNull.Value!=dr["BookDesc"])
                        model.BookDesc = dr["BookDesc"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value != dr["AuthorInfo"])
                        model.AuthorInfo = dr["AuthorInfo"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["BookChapterCount"])
                        model.BookChapterCount= Convert.ToInt32(dr["BookChapterCount"]);
                    if (DBNull.Value!=dr["WordCount"])
                        model.WordCount= Convert.ToInt32(dr["WordCount"]);
                    if (DBNull.Value!=dr["ClickCount"])
                        model.ClickCount= Convert.ToInt32(dr["ClickCount"]);
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["Credit"])
                        model.Credit= Convert.ToDecimal(dr["Credit"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
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
        /// <returns>Book实体类对象</returns>
        public List<Book> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<Book> list = new List<Book>();
            Book model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Book_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new Book();
                    model.BookId= Convert.ToInt32(dr["BookId"]);
                    if (DBNull.Value!=dr["BookTypeId"])
                        model.BookTypeId= Convert.ToInt32(dr["BookTypeId"]);
                    if (DBNull.Value!=dr["BookName"])
                        model.BookName = dr["BookName"].ToString();
                    if (DBNull.Value!=dr["BookDesc"])
                        model.BookDesc = dr["BookDesc"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value != dr["AuthorInfo"])
                        model.AuthorInfo = dr["AuthorInfo"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["BookChapterCount"])
                        model.BookChapterCount= Convert.ToInt32(dr["BookChapterCount"]);
                    if (DBNull.Value!=dr["WordCount"])
                        model.WordCount= Convert.ToInt32(dr["WordCount"]);
                    if (DBNull.Value!=dr["ClickCount"])
                        model.ClickCount= Convert.ToInt32(dr["ClickCount"]);
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["Credit"])
                        model.Credit= Convert.ToDecimal(dr["Credit"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
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

