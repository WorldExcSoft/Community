using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class BookTypeDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="BookType">BookType实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(BookType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@BookTypeName",model.BookTypeName),
                new SqlParameter ("@BookTypeDesc",model.BookTypeDesc),
                new SqlParameter ("@CreateTime",model.CreateTime),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@OrderIndex",model.OrderIndex)
            };
           return DBHelper.ExecuteNonQuery("BookType_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="BookType">BookType实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(BookType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@BookTypeName",model.BookTypeName),
                new SqlParameter ("@BookTypeDesc",model.BookTypeDesc),
                new SqlParameter ("@CreateTime",model.CreateTime),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@OrderIndex",model.OrderIndex)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("BookType_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="BookType">BookType实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(BookType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@BookTypeId",model.BookTypeId),
                new SqlParameter ("@BookTypeName",model.BookTypeName),
                new SqlParameter ("@BookTypeDesc",model.BookTypeDesc),
                new SqlParameter ("@CreateTime",model.CreateTime),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@OrderIndex",model.OrderIndex)
            };
           return DBHelper.ExecuteNonQuery("BookType_Change",param);
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
                new SqlParameter ("@BookTypeId",Id)
            };
           return DBHelper.ExecuteNonQuery ("BookType_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("BookType_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<BookType> SelectAll()
        {
            List<BookType> list = new List<BookType>();
            BookType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("BookType_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new BookType();
                    model.BookTypeId= Convert.ToInt32(dr["BookTypeId"]);
                    if (DBNull.Value!=dr["BookTypeName"])
                        model.BookTypeName = dr["BookTypeName"].ToString();
                    if (DBNull.Value!=dr["BookTypeDesc"])
                        model.BookTypeDesc = dr["BookTypeDesc"].ToString();
                    if (DBNull.Value!=dr["CreateTime"])
                        model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
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
        /// <returns>BookType实体类对象</returns>
        public BookType SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@BookTypeId",Id)
            };
            BookType model = new BookType();
            using (SqlDataReader dr = DBHelper.RunProcedure("BookType_SelectById", param))
            {
                if (dr.Read())
                {
                    model.BookTypeId= Convert.ToInt32(dr["BookTypeId"]);
                    if (DBNull.Value!=dr["BookTypeName"])
                        model.BookTypeName = dr["BookTypeName"].ToString();
                    if (DBNull.Value!=dr["BookTypeDesc"])
                        model.BookTypeDesc = dr["BookTypeDesc"].ToString();
                    if (DBNull.Value!=dr["CreateTime"])
                        model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
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
        /// <returns>BookType实体类对象</returns>
        public List<BookType> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<BookType> list = new List<BookType>();
            BookType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("BookType_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new BookType();
                    model.BookTypeId= Convert.ToInt32(dr["BookTypeId"]);
                    if (DBNull.Value!=dr["BookTypeName"])
                        model.BookTypeName = dr["BookTypeName"].ToString();
                    if (DBNull.Value!=dr["BookTypeDesc"])
                        model.BookTypeDesc = dr["BookTypeDesc"].ToString();
                    if (DBNull.Value!=dr["CreateTime"])
                        model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
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
        /// <returns>BookType实体类对象</returns>
        public List<BookType> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<BookType> list = new List<BookType>();
            BookType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("BookType_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new BookType();
                    model.BookTypeId= Convert.ToInt32(dr["BookTypeId"]);
                    if (DBNull.Value!=dr["BookTypeName"])
                        model.BookTypeName = dr["BookTypeName"].ToString();
                    if (DBNull.Value!=dr["BookTypeDesc"])
                        model.BookTypeDesc = dr["BookTypeDesc"].ToString();
                    if (DBNull.Value!=dr["CreateTime"])
                        model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
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

