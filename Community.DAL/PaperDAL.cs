using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class PaperDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Paper">Paper实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(Paper model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PaperName",model.PaperName),
                new SqlParameter ("@PaperTypeId",model.PaperTypeId),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@LastUpdateDate",model.LastUpdateDate),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@TimeLimit",model.TimeLimit),
                new SqlParameter ("@FullScore",model.FullScore),
                new SqlParameter ("@PaperDesc",model.PaperDesc),
                new SqlParameter ("@AnswerMode",model.AnswerMode),
                new SqlParameter ("@BuildAction",model.BuildAction),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("Paper_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Paper">Paper实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(Paper model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PaperName",model.PaperName),
                new SqlParameter ("@PaperTypeId",model.PaperTypeId),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@LastUpdateDate",model.LastUpdateDate),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@TimeLimit",model.TimeLimit),
                new SqlParameter ("@FullScore",model.FullScore),
                new SqlParameter ("@PaperDesc",model.PaperDesc),
                new SqlParameter ("@AnswerMode",model.AnswerMode),
                new SqlParameter ("@BuildAction",model.BuildAction),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("Paper_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Paper">Paper实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(Paper model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PaperId",model.PaperId),
                new SqlParameter ("@PaperName",model.PaperName),
                new SqlParameter ("@PaperTypeId",model.PaperTypeId),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@LastUpdateDate",model.LastUpdateDate),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@TimeLimit",model.TimeLimit),
                new SqlParameter ("@FullScore",model.FullScore),
                new SqlParameter ("@PaperDesc",model.PaperDesc),
                new SqlParameter ("@AnswerMode",model.AnswerMode),
                new SqlParameter ("@BuildAction",model.BuildAction),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("Paper_Change",param);
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
                new SqlParameter ("@PaperId",Id)
            };
           return DBHelper.ExecuteNonQuery ("Paper_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("Paper_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<Paper> SelectAll()
        {
            List<Paper> list = new List<Paper>();
            Paper model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Paper_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new Paper();
                    model.PaperId= Convert.ToInt32(dr["PaperId"]);
                    if (DBNull.Value!=dr["PaperName"])
                        model.PaperName = dr["PaperName"].ToString();
                    model.PaperTypeId= Convert.ToInt32(dr["PaperTypeId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastUpdateDate"])
                        model.LastUpdateDate= Convert.ToDateTime(dr["LastUpdateDate"]);
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["TimeLimit"])
                        model.TimeLimit= Convert.ToInt32(dr["TimeLimit"]);
                    if (DBNull.Value!=dr["FullScore"])
                        model.FullScore= Convert.ToInt32(dr["FullScore"]);
                    if (DBNull.Value!=dr["PaperDesc"])
                        model.PaperDesc = dr["PaperDesc"].ToString();
                    if (DBNull.Value!=dr["AnswerMode"])
                        model.AnswerMode= Convert.ToInt32(dr["AnswerMode"]);
                    if (DBNull.Value!=dr["BuildAction"])
                        model.BuildAction= Convert.ToInt32(dr["BuildAction"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
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
        /// <returns>Paper实体类对象</returns>
        public Paper SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PaperId",Id)
            };
            Paper model = new Paper();
            using (SqlDataReader dr = DBHelper.RunProcedure("Paper_SelectById", param))
            {
                if (dr.Read())
                {
                    model.PaperId= Convert.ToInt32(dr["PaperId"]);
                    if (DBNull.Value!=dr["PaperName"])
                        model.PaperName = dr["PaperName"].ToString();
                    model.PaperTypeId= Convert.ToInt32(dr["PaperTypeId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastUpdateDate"])
                        model.LastUpdateDate= Convert.ToDateTime(dr["LastUpdateDate"]);
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["TimeLimit"])
                        model.TimeLimit= Convert.ToInt32(dr["TimeLimit"]);
                    if (DBNull.Value!=dr["FullScore"])
                        model.FullScore= Convert.ToInt32(dr["FullScore"]);
                    if (DBNull.Value!=dr["PaperDesc"])
                        model.PaperDesc = dr["PaperDesc"].ToString();
                    if (DBNull.Value!=dr["AnswerMode"])
                        model.AnswerMode= Convert.ToInt32(dr["AnswerMode"]);
                    if (DBNull.Value!=dr["BuildAction"])
                        model.BuildAction= Convert.ToInt32(dr["BuildAction"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>Paper实体类对象</returns>
        public List<Paper> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<Paper> list = new List<Paper>();
            Paper model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Paper_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new Paper();
                    model.PaperId= Convert.ToInt32(dr["PaperId"]);
                    if (DBNull.Value!=dr["PaperName"])
                        model.PaperName = dr["PaperName"].ToString();
                    model.PaperTypeId= Convert.ToInt32(dr["PaperTypeId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastUpdateDate"])
                        model.LastUpdateDate= Convert.ToDateTime(dr["LastUpdateDate"]);
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["TimeLimit"])
                        model.TimeLimit= Convert.ToInt32(dr["TimeLimit"]);
                    if (DBNull.Value!=dr["FullScore"])
                        model.FullScore= Convert.ToInt32(dr["FullScore"]);
                    if (DBNull.Value!=dr["PaperDesc"])
                        model.PaperDesc = dr["PaperDesc"].ToString();
                    if (DBNull.Value!=dr["AnswerMode"])
                        model.AnswerMode= Convert.ToInt32(dr["AnswerMode"]);
                    if (DBNull.Value!=dr["BuildAction"])
                        model.BuildAction= Convert.ToInt32(dr["BuildAction"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
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
        /// <returns>Paper实体类对象</returns>
        public List<Paper> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<Paper> list = new List<Paper>();
            Paper model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Paper_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new Paper();
                    model.PaperId= Convert.ToInt32(dr["PaperId"]);
                    if (DBNull.Value!=dr["PaperName"])
                        model.PaperName = dr["PaperName"].ToString();
                    model.PaperTypeId= Convert.ToInt32(dr["PaperTypeId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastUpdateDate"])
                        model.LastUpdateDate= Convert.ToDateTime(dr["LastUpdateDate"]);
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["TimeLimit"])
                        model.TimeLimit= Convert.ToInt32(dr["TimeLimit"]);
                    if (DBNull.Value!=dr["FullScore"])
                        model.FullScore= Convert.ToInt32(dr["FullScore"]);
                    if (DBNull.Value!=dr["PaperDesc"])
                        model.PaperDesc = dr["PaperDesc"].ToString();
                    if (DBNull.Value!=dr["AnswerMode"])
                        model.AnswerMode= Convert.ToInt32(dr["AnswerMode"]);
                    if (DBNull.Value!=dr["BuildAction"])
                        model.BuildAction= Convert.ToInt32(dr["BuildAction"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
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

