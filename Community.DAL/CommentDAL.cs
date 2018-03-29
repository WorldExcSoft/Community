using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class CommentDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Comment">Comment实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(Comment model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@UserID",model.UserID),
                new SqlParameter ("@ObjId",model.ObjId),
                new SqlParameter ("@ObjType",model.ObjType),
                new SqlParameter ("@CommentContent",model.CommentContent),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@CreateTime",model.CreateTime),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@CheckWay",model.CheckWay),
                new SqlParameter ("@CheckUserId",model.CheckUserId),
                new SqlParameter ("@CheckDate",model.CheckDate),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("Comment_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Comment">Comment实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(Comment model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@UserID",model.UserID),
                new SqlParameter ("@ObjId",model.ObjId),
                new SqlParameter ("@ObjType",model.ObjType),
                new SqlParameter ("@CommentContent",model.CommentContent),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@CreateTime",model.CreateTime),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@CheckWay",model.CheckWay),
                new SqlParameter ("@CheckUserId",model.CheckUserId),
                new SqlParameter ("@CheckDate",model.CheckDate),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("Comment_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Comment">Comment实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(Comment model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@CommentId",model.CommentId),
                new SqlParameter ("@UserID",model.UserID),
                new SqlParameter ("@ObjId",model.ObjId),
                new SqlParameter ("@ObjType",model.ObjType),
                new SqlParameter ("@CommentContent",model.CommentContent),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@CreateTime",model.CreateTime),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@CheckWay",model.CheckWay),
                new SqlParameter ("@CheckUserId",model.CheckUserId),
                new SqlParameter ("@CheckDate",model.CheckDate),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("Comment_Change",param);
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
                new SqlParameter ("@CommentId",Id)
            };
           return DBHelper.ExecuteNonQuery ("Comment_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("Comment_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<Comment> SelectAll()
        {
            List<Comment> list = new List<Comment>();
            Comment model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Comment_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new Comment();
                    model.CommentId= Convert.ToInt32(dr["CommentId"]);
                    if (DBNull.Value!=dr["UserID"])
                        model.UserID= Convert.ToInt32(dr["UserID"]);
                    if (DBNull.Value!=dr["ObjId"])
                        model.ObjId= Convert.ToInt32(dr["ObjId"]);
                    if (DBNull.Value!=dr["ObjType"])
                        model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    if (DBNull.Value!=dr["CommentContent"])
                        model.CommentContent = dr["CommentContent"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["CreateTime"])
                        model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["CheckWay"])
                        model.CheckWay= Convert.ToInt32(dr["CheckWay"]);
                    if (DBNull.Value!=dr["CheckUserId"])
                        model.CheckUserId= Convert.ToInt32(dr["CheckUserId"]);
                    if (DBNull.Value!=dr["CheckDate"])
                        model.CheckDate= Convert.ToDateTime(dr["CheckDate"]);
                    if (DBNull.Value!=dr["IsDelete"])
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
        /// <returns>Comment实体类对象</returns>
        public Comment SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@CommentId",Id)
            };
            Comment model = new Comment();
            using (SqlDataReader dr = DBHelper.RunProcedure("Comment_SelectById", param))
            {
                if (dr.Read())
                {
                    model.CommentId= Convert.ToInt32(dr["CommentId"]);
                    if (DBNull.Value!=dr["UserID"])
                        model.UserID= Convert.ToInt32(dr["UserID"]);
                    if (DBNull.Value!=dr["ObjId"])
                        model.ObjId= Convert.ToInt32(dr["ObjId"]);
                    if (DBNull.Value!=dr["ObjType"])
                        model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    if (DBNull.Value!=dr["CommentContent"])
                        model.CommentContent = dr["CommentContent"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["CreateTime"])
                        model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["CheckWay"])
                        model.CheckWay= Convert.ToInt32(dr["CheckWay"]);
                    if (DBNull.Value!=dr["CheckUserId"])
                        model.CheckUserId= Convert.ToInt32(dr["CheckUserId"]);
                    if (DBNull.Value!=dr["CheckDate"])
                        model.CheckDate= Convert.ToDateTime(dr["CheckDate"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>Comment实体类对象</returns>
        public List<Comment> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<Comment> list = new List<Comment>();
            Comment model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Comment_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new Comment();
                    model.CommentId= Convert.ToInt32(dr["CommentId"]);
                    if (DBNull.Value!=dr["UserID"])
                        model.UserID= Convert.ToInt32(dr["UserID"]);
                    if (DBNull.Value!=dr["ObjId"])
                        model.ObjId= Convert.ToInt32(dr["ObjId"]);
                    if (DBNull.Value!=dr["ObjType"])
                        model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    if (DBNull.Value!=dr["CommentContent"])
                        model.CommentContent = dr["CommentContent"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["CreateTime"])
                        model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["CheckWay"])
                        model.CheckWay= Convert.ToInt32(dr["CheckWay"]);
                    if (DBNull.Value!=dr["CheckUserId"])
                        model.CheckUserId= Convert.ToInt32(dr["CheckUserId"]);
                    if (DBNull.Value!=dr["CheckDate"])
                        model.CheckDate= Convert.ToDateTime(dr["CheckDate"]);
                    if (DBNull.Value!=dr["IsDelete"])
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
        /// <returns>Comment实体类对象</returns>
        public List<Comment> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<Comment> list = new List<Comment>();
            Comment model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Comment_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new Comment();
                    model.CommentId= Convert.ToInt32(dr["CommentId"]);
                    if (DBNull.Value!=dr["UserID"])
                        model.UserID= Convert.ToInt32(dr["UserID"]);
                    if (DBNull.Value!=dr["ObjId"])
                        model.ObjId= Convert.ToInt32(dr["ObjId"]);
                    if (DBNull.Value!=dr["ObjType"])
                        model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    if (DBNull.Value!=dr["CommentContent"])
                        model.CommentContent = dr["CommentContent"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["CreateTime"])
                        model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["CheckWay"])
                        model.CheckWay= Convert.ToInt32(dr["CheckWay"]);
                    if (DBNull.Value!=dr["CheckUserId"])
                        model.CheckUserId= Convert.ToInt32(dr["CheckUserId"]);
                    if (DBNull.Value!=dr["CheckDate"])
                        model.CheckDate= Convert.ToDateTime(dr["CheckDate"]);
                    if (DBNull.Value!=dr["IsDelete"])
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

