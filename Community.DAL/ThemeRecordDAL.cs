using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class ThemeRecordDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ThemeRecord">ThemeRecord实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(ThemeRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PaperRecordId",model.PaperRecordId),
                new SqlParameter ("@ExamId",model.ExamId),
                new SqlParameter ("@PaperId",model.PaperId),
                new SqlParameter ("@ThemeId",model.ThemeId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@AddScoreUserId",model.AddScoreUserId),
                new SqlParameter ("@AddScoreRemark",model.AddScoreRemark),
                new SqlParameter ("@AddScoreDate",model.AddScoreDate),
                new SqlParameter ("@UserAnswer",model.UserAnswer),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@UserScore",model.UserScore)
            };
           return DBHelper.ExecuteNonQuery("ThemeRecord_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ThemeRecord">ThemeRecord实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(ThemeRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PaperRecordId",model.PaperRecordId),
                new SqlParameter ("@ExamId",model.ExamId),
                new SqlParameter ("@PaperId",model.PaperId),
                new SqlParameter ("@ThemeId",model.ThemeId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@AddScoreUserId",model.AddScoreUserId),
                new SqlParameter ("@AddScoreRemark",model.AddScoreRemark),
                new SqlParameter ("@AddScoreDate",model.AddScoreDate),
                new SqlParameter ("@UserAnswer",model.UserAnswer),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@UserScore",model.UserScore)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("ThemeRecord_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ThemeRecord">ThemeRecord实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(ThemeRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ThemeRecordId",model.ThemeRecordId),
                new SqlParameter ("@PaperRecordId",model.PaperRecordId),
                new SqlParameter ("@ExamId",model.ExamId),
                new SqlParameter ("@PaperId",model.PaperId),
                new SqlParameter ("@ThemeId",model.ThemeId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@AddScoreUserId",model.AddScoreUserId),
                new SqlParameter ("@AddScoreRemark",model.AddScoreRemark),
                new SqlParameter ("@AddScoreDate",model.AddScoreDate),
                new SqlParameter ("@UserAnswer",model.UserAnswer),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@UserScore",model.UserScore)
            };
           return DBHelper.ExecuteNonQuery("ThemeRecord_Change",param);
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
                new SqlParameter ("@ThemeRecordId",Id)
            };
           return DBHelper.ExecuteNonQuery ("ThemeRecord_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("ThemeRecord_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<ThemeRecord> SelectAll()
        {
            List<ThemeRecord> list = new List<ThemeRecord>();
            ThemeRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ThemeRecord_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new ThemeRecord();
                    model.ThemeRecordId= Convert.ToInt32(dr["ThemeRecordId"]);
                    if (DBNull.Value!=dr["PaperRecordId"])
                        model.PaperRecordId= Convert.ToInt32(dr["PaperRecordId"]);
                    if (DBNull.Value!=dr["ExamId"])
                        model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    if (DBNull.Value!=dr["PaperId"])
                        model.PaperId= Convert.ToInt32(dr["PaperId"]);
                    if (DBNull.Value!=dr["ThemeId"])
                        model.ThemeId= Convert.ToInt32(dr["ThemeId"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["AddScoreUserId"])
                        model.AddScoreUserId= Convert.ToInt32(dr["AddScoreUserId"]);
                    if (DBNull.Value!=dr["AddScoreRemark"])
                        model.AddScoreRemark = dr["AddScoreRemark"].ToString();
                    if (DBNull.Value!=dr["AddScoreDate"])
                        model.AddScoreDate= Convert.ToDateTime(dr["AddScoreDate"]);
                    if (DBNull.Value!=dr["UserAnswer"])
                        model.UserAnswer = dr["UserAnswer"].ToString();
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["UserScore"])
                        model.UserScore= Convert.ToDecimal(dr["UserScore"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>ThemeRecord实体类对象</returns>
        public ThemeRecord SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ThemeRecordId",Id)
            };
            ThemeRecord model = new ThemeRecord();
            using (SqlDataReader dr = DBHelper.RunProcedure("ThemeRecord_SelectById", param))
            {
                if (dr.Read())
                {
                    model.ThemeRecordId= Convert.ToInt32(dr["ThemeRecordId"]);
                    if (DBNull.Value!=dr["PaperRecordId"])
                        model.PaperRecordId= Convert.ToInt32(dr["PaperRecordId"]);
                    if (DBNull.Value!=dr["ExamId"])
                        model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    if (DBNull.Value!=dr["PaperId"])
                        model.PaperId= Convert.ToInt32(dr["PaperId"]);
                    if (DBNull.Value!=dr["ThemeId"])
                        model.ThemeId= Convert.ToInt32(dr["ThemeId"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["AddScoreUserId"])
                        model.AddScoreUserId= Convert.ToInt32(dr["AddScoreUserId"]);
                    if (DBNull.Value!=dr["AddScoreRemark"])
                        model.AddScoreRemark = dr["AddScoreRemark"].ToString();
                    if (DBNull.Value!=dr["AddScoreDate"])
                        model.AddScoreDate= Convert.ToDateTime(dr["AddScoreDate"]);
                    if (DBNull.Value!=dr["UserAnswer"])
                        model.UserAnswer = dr["UserAnswer"].ToString();
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["UserScore"])
                        model.UserScore= Convert.ToDecimal(dr["UserScore"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>ThemeRecord实体类对象</returns>
        public List<ThemeRecord> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<ThemeRecord> list = new List<ThemeRecord>();
            ThemeRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ThemeRecord_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new ThemeRecord();
                    model.ThemeRecordId= Convert.ToInt32(dr["ThemeRecordId"]);
                    if (DBNull.Value!=dr["PaperRecordId"])
                        model.PaperRecordId= Convert.ToInt32(dr["PaperRecordId"]);
                    if (DBNull.Value!=dr["ExamId"])
                        model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    if (DBNull.Value!=dr["PaperId"])
                        model.PaperId= Convert.ToInt32(dr["PaperId"]);
                    if (DBNull.Value!=dr["ThemeId"])
                        model.ThemeId= Convert.ToInt32(dr["ThemeId"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["AddScoreUserId"])
                        model.AddScoreUserId= Convert.ToInt32(dr["AddScoreUserId"]);
                    if (DBNull.Value!=dr["AddScoreRemark"])
                        model.AddScoreRemark = dr["AddScoreRemark"].ToString();
                    if (DBNull.Value!=dr["AddScoreDate"])
                        model.AddScoreDate= Convert.ToDateTime(dr["AddScoreDate"]);
                    if (DBNull.Value!=dr["UserAnswer"])
                        model.UserAnswer = dr["UserAnswer"].ToString();
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["UserScore"])
                        model.UserScore= Convert.ToDecimal(dr["UserScore"]);
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
        /// <returns>ThemeRecord实体类对象</returns>
        public List<ThemeRecord> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<ThemeRecord> list = new List<ThemeRecord>();
            ThemeRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ThemeRecord_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new ThemeRecord();
                    model.ThemeRecordId= Convert.ToInt32(dr["ThemeRecordId"]);
                    if (DBNull.Value!=dr["PaperRecordId"])
                        model.PaperRecordId= Convert.ToInt32(dr["PaperRecordId"]);
                    if (DBNull.Value!=dr["ExamId"])
                        model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    if (DBNull.Value!=dr["PaperId"])
                        model.PaperId= Convert.ToInt32(dr["PaperId"]);
                    if (DBNull.Value!=dr["ThemeId"])
                        model.ThemeId= Convert.ToInt32(dr["ThemeId"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["AddScoreUserId"])
                        model.AddScoreUserId= Convert.ToInt32(dr["AddScoreUserId"]);
                    if (DBNull.Value!=dr["AddScoreRemark"])
                        model.AddScoreRemark = dr["AddScoreRemark"].ToString();
                    if (DBNull.Value!=dr["AddScoreDate"])
                        model.AddScoreDate= Convert.ToDateTime(dr["AddScoreDate"]);
                    if (DBNull.Value!=dr["UserAnswer"])
                        model.UserAnswer = dr["UserAnswer"].ToString();
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["UserScore"])
                        model.UserScore= Convert.ToDecimal(dr["UserScore"]);
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

