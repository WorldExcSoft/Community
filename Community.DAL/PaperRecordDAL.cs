using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class PaperRecordDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="PaperRecord">PaperRecord实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(PaperRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamId",model.ExamId),
                new SqlParameter ("@PaperId",model.PaperId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@StartDate",model.StartDate),
                new SqlParameter ("@EndDate",model.EndDate),
                new SqlParameter ("@TotalTime",model.TotalTime),
                new SqlParameter ("@UserScore",model.UserScore),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("PaperRecord_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="PaperRecord">PaperRecord实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(PaperRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamId",model.ExamId),
                new SqlParameter ("@PaperId",model.PaperId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@StartDate",model.StartDate),
                new SqlParameter ("@EndDate",model.EndDate),
                new SqlParameter ("@TotalTime",model.TotalTime),
                new SqlParameter ("@UserScore",model.UserScore),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("PaperRecord_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="PaperRecord">PaperRecord实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(PaperRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PaperRecordId",model.PaperRecordId),
                new SqlParameter ("@ExamId",model.ExamId),
                new SqlParameter ("@PaperId",model.PaperId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@StartDate",model.StartDate),
                new SqlParameter ("@EndDate",model.EndDate),
                new SqlParameter ("@TotalTime",model.TotalTime),
                new SqlParameter ("@UserScore",model.UserScore),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("PaperRecord_Change",param);
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
                new SqlParameter ("@PaperRecordId",Id)
            };
           return DBHelper.ExecuteNonQuery ("PaperRecord_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("PaperRecord_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<PaperRecord> SelectAll()
        {
            List<PaperRecord> list = new List<PaperRecord>();
            PaperRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("PaperRecord_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new PaperRecord();
                    model.PaperRecordId= Convert.ToInt32(dr["PaperRecordId"]);
                    if (DBNull.Value!=dr["ExamId"])
                        model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    if (DBNull.Value!=dr["PaperId"])
                        model.PaperId= Convert.ToInt32(dr["PaperId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["StartDate"])
                        model.StartDate= Convert.ToDateTime(dr["StartDate"]);
                    if (DBNull.Value!=dr["EndDate"])
                        model.EndDate= Convert.ToDateTime(dr["EndDate"]);
                    if (DBNull.Value!=dr["TotalTime"])
                        model.TotalTime= Convert.ToInt32(dr["TotalTime"]);
                    if (DBNull.Value!=dr["UserScore"])
                        model.UserScore= Convert.ToDecimal(dr["UserScore"]);
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
        /// <returns>PaperRecord实体类对象</returns>
        public PaperRecord SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PaperRecordId",Id)
            };
            PaperRecord model = new PaperRecord();
            using (SqlDataReader dr = DBHelper.RunProcedure("PaperRecord_SelectById", param))
            {
                if (dr.Read())
                {
                    model.PaperRecordId= Convert.ToInt32(dr["PaperRecordId"]);
                    if (DBNull.Value!=dr["ExamId"])
                        model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    if (DBNull.Value!=dr["PaperId"])
                        model.PaperId= Convert.ToInt32(dr["PaperId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["StartDate"])
                        model.StartDate= Convert.ToDateTime(dr["StartDate"]);
                    if (DBNull.Value!=dr["EndDate"])
                        model.EndDate= Convert.ToDateTime(dr["EndDate"]);
                    if (DBNull.Value!=dr["TotalTime"])
                        model.TotalTime= Convert.ToInt32(dr["TotalTime"]);
                    if (DBNull.Value!=dr["UserScore"])
                        model.UserScore= Convert.ToDecimal(dr["UserScore"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>PaperRecord实体类对象</returns>
        public List<PaperRecord> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<PaperRecord> list = new List<PaperRecord>();
            PaperRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("PaperRecord_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new PaperRecord();
                    model.PaperRecordId= Convert.ToInt32(dr["PaperRecordId"]);
                    if (DBNull.Value!=dr["ExamId"])
                        model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    if (DBNull.Value!=dr["PaperId"])
                        model.PaperId= Convert.ToInt32(dr["PaperId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["StartDate"])
                        model.StartDate= Convert.ToDateTime(dr["StartDate"]);
                    if (DBNull.Value!=dr["EndDate"])
                        model.EndDate= Convert.ToDateTime(dr["EndDate"]);
                    if (DBNull.Value!=dr["TotalTime"])
                        model.TotalTime= Convert.ToInt32(dr["TotalTime"]);
                    if (DBNull.Value!=dr["UserScore"])
                        model.UserScore= Convert.ToDecimal(dr["UserScore"]);
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
        /// <returns>PaperRecord实体类对象</returns>
        public List<PaperRecord> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<PaperRecord> list = new List<PaperRecord>();
            PaperRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("PaperRecord_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new PaperRecord();
                    model.PaperRecordId= Convert.ToInt32(dr["PaperRecordId"]);
                    if (DBNull.Value!=dr["ExamId"])
                        model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    if (DBNull.Value!=dr["PaperId"])
                        model.PaperId= Convert.ToInt32(dr["PaperId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["StartDate"])
                        model.StartDate= Convert.ToDateTime(dr["StartDate"]);
                    if (DBNull.Value!=dr["EndDate"])
                        model.EndDate= Convert.ToDateTime(dr["EndDate"]);
                    if (DBNull.Value!=dr["TotalTime"])
                        model.TotalTime= Convert.ToInt32(dr["TotalTime"]);
                    if (DBNull.Value!=dr["UserScore"])
                        model.UserScore= Convert.ToDecimal(dr["UserScore"]);
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

