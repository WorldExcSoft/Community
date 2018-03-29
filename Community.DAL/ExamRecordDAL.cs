using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class ExamRecordDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ExamRecord">ExamRecord实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(ExamRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamId",model.ExamId),
                new SqlParameter ("@PaperId",model.PaperId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@LastDate",model.LastDate),
                new SqlParameter ("@TotalTime",model.TotalTime),
                new SqlParameter ("@ExamNumber",model.ExamNumber),
                new SqlParameter ("@LastScore",model.LastScore),
                new SqlParameter ("@HighScore",model.HighScore),
                new SqlParameter ("@UserCredit",model.UserCredit),
                new SqlParameter ("@UserCoin",model.UserCoin),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("ExamRecord_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ExamRecord">ExamRecord实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(ExamRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamId",model.ExamId),
                new SqlParameter ("@PaperId",model.PaperId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@LastDate",model.LastDate),
                new SqlParameter ("@TotalTime",model.TotalTime),
                new SqlParameter ("@ExamNumber",model.ExamNumber),
                new SqlParameter ("@LastScore",model.LastScore),
                new SqlParameter ("@HighScore",model.HighScore),
                new SqlParameter ("@UserCredit",model.UserCredit),
                new SqlParameter ("@UserCoin",model.UserCoin),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("ExamRecord_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ExamRecord">ExamRecord实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(ExamRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamRecordId",model.ExamRecordId),
                new SqlParameter ("@ExamId",model.ExamId),
                new SqlParameter ("@PaperId",model.PaperId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@LastDate",model.LastDate),
                new SqlParameter ("@TotalTime",model.TotalTime),
                new SqlParameter ("@ExamNumber",model.ExamNumber),
                new SqlParameter ("@LastScore",model.LastScore),
                new SqlParameter ("@HighScore",model.HighScore),
                new SqlParameter ("@UserCredit",model.UserCredit),
                new SqlParameter ("@UserCoin",model.UserCoin),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("ExamRecord_Change",param);
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
                new SqlParameter ("@ExamRecordId",Id)
            };
           return DBHelper.ExecuteNonQuery ("ExamRecord_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("ExamRecord_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<ExamRecord> SelectAll()
        {
            List<ExamRecord> list = new List<ExamRecord>();
            ExamRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ExamRecord_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new ExamRecord();
                    model.ExamRecordId= Convert.ToInt32(dr["ExamRecordId"]);
                    model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    model.PaperId= Convert.ToInt32(dr["PaperId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastDate"])
                        model.LastDate= Convert.ToDateTime(dr["LastDate"]);
                    if (DBNull.Value!=dr["TotalTime"])
                        model.TotalTime= Convert.ToInt32(dr["TotalTime"]);
                    if (DBNull.Value!=dr["ExamNumber"])
                        model.ExamNumber= Convert.ToInt32(dr["ExamNumber"]);
                    if (DBNull.Value!=dr["LastScore"])
                        model.LastScore= Convert.ToInt32(dr["LastScore"]);
                    if (DBNull.Value!=dr["HighScore"])
                        model.HighScore= Convert.ToInt32(dr["HighScore"]);
                    if (DBNull.Value!=dr["UserCredit"])
                        model.UserCredit= Convert.ToDecimal(dr["UserCredit"]);
                    if (DBNull.Value!=dr["UserCoin"])
                        model.UserCoin= Convert.ToDecimal(dr["UserCoin"]);
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
        /// <returns>ExamRecord实体类对象</returns>
        public ExamRecord SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamRecordId",Id)
            };
            ExamRecord model = new ExamRecord();
            using (SqlDataReader dr = DBHelper.RunProcedure("ExamRecord_SelectById", param))
            {
                if (dr.Read())
                {
                    model.ExamRecordId= Convert.ToInt32(dr["ExamRecordId"]);
                    model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    model.PaperId= Convert.ToInt32(dr["PaperId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastDate"])
                        model.LastDate= Convert.ToDateTime(dr["LastDate"]);
                    if (DBNull.Value!=dr["TotalTime"])
                        model.TotalTime= Convert.ToInt32(dr["TotalTime"]);
                    if (DBNull.Value!=dr["ExamNumber"])
                        model.ExamNumber= Convert.ToInt32(dr["ExamNumber"]);
                    if (DBNull.Value!=dr["LastScore"])
                        model.LastScore= Convert.ToInt32(dr["LastScore"]);
                    if (DBNull.Value!=dr["HighScore"])
                        model.HighScore= Convert.ToInt32(dr["HighScore"]);
                    if (DBNull.Value!=dr["UserCredit"])
                        model.UserCredit= Convert.ToDecimal(dr["UserCredit"]);
                    if (DBNull.Value!=dr["UserCoin"])
                        model.UserCoin= Convert.ToDecimal(dr["UserCoin"]);
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
        /// <returns>ExamRecord实体类对象</returns>
        public List<ExamRecord> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<ExamRecord> list = new List<ExamRecord>();
            ExamRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ExamRecord_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new ExamRecord();
                    model.ExamRecordId= Convert.ToInt32(dr["ExamRecordId"]);
                    model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    model.PaperId= Convert.ToInt32(dr["PaperId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastDate"])
                        model.LastDate= Convert.ToDateTime(dr["LastDate"]);
                    if (DBNull.Value!=dr["TotalTime"])
                        model.TotalTime= Convert.ToInt32(dr["TotalTime"]);
                    if (DBNull.Value!=dr["ExamNumber"])
                        model.ExamNumber= Convert.ToInt32(dr["ExamNumber"]);
                    if (DBNull.Value!=dr["LastScore"])
                        model.LastScore= Convert.ToInt32(dr["LastScore"]);
                    if (DBNull.Value!=dr["HighScore"])
                        model.HighScore= Convert.ToInt32(dr["HighScore"]);
                    if (DBNull.Value!=dr["UserCredit"])
                        model.UserCredit= Convert.ToDecimal(dr["UserCredit"]);
                    if (DBNull.Value!=dr["UserCoin"])
                        model.UserCoin= Convert.ToDecimal(dr["UserCoin"]);
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
        /// <returns>ExamRecord实体类对象</returns>
        public List<ExamRecord> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<ExamRecord> list = new List<ExamRecord>();
            ExamRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ExamRecord_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new ExamRecord();
                    model.ExamRecordId= Convert.ToInt32(dr["ExamRecordId"]);
                    model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    model.PaperId= Convert.ToInt32(dr["PaperId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastDate"])
                        model.LastDate= Convert.ToDateTime(dr["LastDate"]);
                    if (DBNull.Value!=dr["TotalTime"])
                        model.TotalTime= Convert.ToInt32(dr["TotalTime"]);
                    if (DBNull.Value!=dr["ExamNumber"])
                        model.ExamNumber= Convert.ToInt32(dr["ExamNumber"]);
                    if (DBNull.Value!=dr["LastScore"])
                        model.LastScore= Convert.ToInt32(dr["LastScore"]);
                    if (DBNull.Value!=dr["HighScore"])
                        model.HighScore= Convert.ToInt32(dr["HighScore"]);
                    if (DBNull.Value!=dr["UserCredit"])
                        model.UserCredit= Convert.ToDecimal(dr["UserCredit"]);
                    if (DBNull.Value!=dr["UserCoin"])
                        model.UserCoin= Convert.ToDecimal(dr["UserCoin"]);
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

