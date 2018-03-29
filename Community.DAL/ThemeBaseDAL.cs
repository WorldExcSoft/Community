using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class ThemeBaseDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ThemeBase">ThemeBase实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(ThemeBase model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ThemeBaseName",model.ThemeBaseName),
                new SqlParameter ("@ThemeTypeId",model.ThemeTypeId),
                new SqlParameter ("@ThemeBaseType",model.ThemeBaseType),
                new SqlParameter ("@ThemeScore",model.ThemeScore),
                new SqlParameter ("@ThemeAnswer",model.ThemeAnswer),
                new SqlParameter ("@AnswerDesc",model.AnswerDesc),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@LastUpdateDate",model.LastUpdateDate),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@DifficultyLevel",model.DifficultyLevel),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@ThemeDesc",model.ThemeDesc)
            };
           return DBHelper.ExecuteNonQuery("ThemeBase_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ThemeBase">ThemeBase实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(ThemeBase model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ThemeBaseName",model.ThemeBaseName),
                new SqlParameter ("@ThemeTypeId",model.ThemeTypeId),
                new SqlParameter ("@ThemeBaseType",model.ThemeBaseType),
                new SqlParameter ("@ThemeScore",model.ThemeScore),
                new SqlParameter ("@ThemeAnswer",model.ThemeAnswer),
                new SqlParameter ("@AnswerDesc",model.AnswerDesc),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@LastUpdateDate",model.LastUpdateDate),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@DifficultyLevel",model.DifficultyLevel),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@ThemeDesc",model.ThemeDesc)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("ThemeBase_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ThemeBase">ThemeBase实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(ThemeBase model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ThemeBaseId",model.ThemeBaseId),
                new SqlParameter ("@ThemeBaseName",model.ThemeBaseName),
                new SqlParameter ("@ThemeTypeId",model.ThemeTypeId),
                new SqlParameter ("@ThemeBaseType",model.ThemeBaseType),
                new SqlParameter ("@ThemeScore",model.ThemeScore),
                new SqlParameter ("@ThemeAnswer",model.ThemeAnswer),
                new SqlParameter ("@AnswerDesc",model.AnswerDesc),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@LastUpdateDate",model.LastUpdateDate),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@DifficultyLevel",model.DifficultyLevel),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@ThemeDesc",model.ThemeDesc)
            };
           return DBHelper.ExecuteNonQuery("ThemeBase_Change",param);
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
                new SqlParameter ("@ThemeBaseId",Id)
            };
           return DBHelper.ExecuteNonQuery ("ThemeBase_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("ThemeBase_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<ThemeBase> SelectAll()
        {
            List<ThemeBase> list = new List<ThemeBase>();
            ThemeBase model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ThemeBase_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new ThemeBase();
                    model.ThemeBaseId= Convert.ToInt32(dr["ThemeBaseId"]);
                    if (DBNull.Value!=dr["ThemeBaseName"])
                        model.ThemeBaseName = dr["ThemeBaseName"].ToString();
                    if (DBNull.Value!=dr["ThemeTypeId"])
                        model.ThemeTypeId= Convert.ToInt32(dr["ThemeTypeId"]);
                    if (DBNull.Value!=dr["ThemeBaseType"])
                        model.ThemeBaseType= Convert.ToInt32(dr["ThemeBaseType"]);
                    if (DBNull.Value!=dr["ThemeScore"])
                        model.ThemeScore= Convert.ToDecimal(dr["ThemeScore"]);
                    if (DBNull.Value!=dr["ThemeAnswer"])
                        model.ThemeAnswer = dr["ThemeAnswer"].ToString();
                    if (DBNull.Value!=dr["AnswerDesc"])
                        model.AnswerDesc = dr["AnswerDesc"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastUpdateDate"])
                        model.LastUpdateDate= Convert.ToDateTime(dr["LastUpdateDate"]);
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["DifficultyLevel"])
                        model.DifficultyLevel= Convert.ToInt32(dr["DifficultyLevel"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["ThemeDesc"])
                        model.ThemeDesc = dr["ThemeDesc"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>ThemeBase实体类对象</returns>
        public ThemeBase SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ThemeBaseId",Id)
            };
            ThemeBase model = new ThemeBase();
            using (SqlDataReader dr = DBHelper.RunProcedure("ThemeBase_SelectById", param))
            {
                if (dr.Read())
                {
                    model.ThemeBaseId= Convert.ToInt32(dr["ThemeBaseId"]);
                    if (DBNull.Value!=dr["ThemeBaseName"])
                        model.ThemeBaseName = dr["ThemeBaseName"].ToString();
                    if (DBNull.Value!=dr["ThemeTypeId"])
                        model.ThemeTypeId= Convert.ToInt32(dr["ThemeTypeId"]);
                    if (DBNull.Value!=dr["ThemeBaseType"])
                        model.ThemeBaseType= Convert.ToInt32(dr["ThemeBaseType"]);
                    if (DBNull.Value!=dr["ThemeScore"])
                        model.ThemeScore= Convert.ToDecimal(dr["ThemeScore"]);
                    if (DBNull.Value!=dr["ThemeAnswer"])
                        model.ThemeAnswer = dr["ThemeAnswer"].ToString();
                    if (DBNull.Value!=dr["AnswerDesc"])
                        model.AnswerDesc = dr["AnswerDesc"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastUpdateDate"])
                        model.LastUpdateDate= Convert.ToDateTime(dr["LastUpdateDate"]);
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["DifficultyLevel"])
                        model.DifficultyLevel= Convert.ToInt32(dr["DifficultyLevel"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["ThemeDesc"])
                        model.ThemeDesc = dr["ThemeDesc"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>ThemeBase实体类对象</returns>
        public List<ThemeBase> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<ThemeBase> list = new List<ThemeBase>();
            ThemeBase model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ThemeBase_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new ThemeBase();
                    model.ThemeBaseId= Convert.ToInt32(dr["ThemeBaseId"]);
                    if (DBNull.Value!=dr["ThemeBaseName"])
                        model.ThemeBaseName = dr["ThemeBaseName"].ToString();
                    if (DBNull.Value!=dr["ThemeTypeId"])
                        model.ThemeTypeId= Convert.ToInt32(dr["ThemeTypeId"]);
                    if (DBNull.Value!=dr["ThemeBaseType"])
                        model.ThemeBaseType= Convert.ToInt32(dr["ThemeBaseType"]);
                    if (DBNull.Value!=dr["ThemeScore"])
                        model.ThemeScore= Convert.ToDecimal(dr["ThemeScore"]);
                    if (DBNull.Value!=dr["ThemeAnswer"])
                        model.ThemeAnswer = dr["ThemeAnswer"].ToString();
                    if (DBNull.Value!=dr["AnswerDesc"])
                        model.AnswerDesc = dr["AnswerDesc"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastUpdateDate"])
                        model.LastUpdateDate= Convert.ToDateTime(dr["LastUpdateDate"]);
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["DifficultyLevel"])
                        model.DifficultyLevel= Convert.ToInt32(dr["DifficultyLevel"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["ThemeDesc"])
                        model.ThemeDesc = dr["ThemeDesc"].ToString();
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
        /// <returns>ThemeBase实体类对象</returns>
        public List<ThemeBase> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<ThemeBase> list = new List<ThemeBase>();
            ThemeBase model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ThemeBase_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new ThemeBase();
                    model.ThemeBaseId= Convert.ToInt32(dr["ThemeBaseId"]);
                    if (DBNull.Value!=dr["ThemeBaseName"])
                        model.ThemeBaseName = dr["ThemeBaseName"].ToString();
                    if (DBNull.Value!=dr["ThemeTypeId"])
                        model.ThemeTypeId= Convert.ToInt32(dr["ThemeTypeId"]);
                    if (DBNull.Value!=dr["ThemeBaseType"])
                        model.ThemeBaseType= Convert.ToInt32(dr["ThemeBaseType"]);
                    if (DBNull.Value!=dr["ThemeScore"])
                        model.ThemeScore= Convert.ToDecimal(dr["ThemeScore"]);
                    if (DBNull.Value!=dr["ThemeAnswer"])
                        model.ThemeAnswer = dr["ThemeAnswer"].ToString();
                    if (DBNull.Value!=dr["AnswerDesc"])
                        model.AnswerDesc = dr["AnswerDesc"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastUpdateDate"])
                        model.LastUpdateDate= Convert.ToDateTime(dr["LastUpdateDate"]);
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["DifficultyLevel"])
                        model.DifficultyLevel= Convert.ToInt32(dr["DifficultyLevel"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["ThemeDesc"])
                        model.ThemeDesc = dr["ThemeDesc"].ToString();
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

