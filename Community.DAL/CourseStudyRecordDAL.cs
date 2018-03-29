using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class CourseStudyRecordDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="CourseStudyRecord">CourseStudyRecord实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(CourseStudyRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@CourseId",model.CourseId),
                new SqlParameter ("@MmsId",model.MmsId),
                new SqlParameter ("@Credit",model.Credit),
                new SqlParameter ("@Coin",model.Coin),
                new SqlParameter ("@FinishDate",model.FinishDate),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@LastStartDate",model.LastStartDate),
                new SqlParameter ("@LastEndDate",model.LastEndDate),
                new SqlParameter ("@StudyCount",model.StudyCount),
                new SqlParameter ("@StudyTimes",model.StudyTimes),
                new SqlParameter ("@IsComplete",model.IsComplete),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@TotalTimes",model.TotalTimes)
            };
           return DBHelper.ExecuteNonQuery("CourseStudyRecord_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="CourseStudyRecord">CourseStudyRecord实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(CourseStudyRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@CourseId",model.CourseId),
                new SqlParameter ("@MmsId",model.MmsId),
                new SqlParameter ("@Credit",model.Credit),
                new SqlParameter ("@Coin",model.Coin),
                new SqlParameter ("@FinishDate",model.FinishDate),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@LastStartDate",model.LastStartDate),
                new SqlParameter ("@LastEndDate",model.LastEndDate),
                new SqlParameter ("@StudyCount",model.StudyCount),
                new SqlParameter ("@StudyTimes",model.StudyTimes),
                new SqlParameter ("@IsComplete",model.IsComplete),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@TotalTimes",model.TotalTimes)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("CourseStudyRecord_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="CourseStudyRecord">CourseStudyRecord实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(CourseStudyRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@StudyRecordId",model.StudyRecordId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@CourseId",model.CourseId),
                new SqlParameter ("@MmsId",model.MmsId),
                new SqlParameter ("@Credit",model.Credit),
                new SqlParameter ("@Coin",model.Coin),
                new SqlParameter ("@FinishDate",model.FinishDate),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@LastStartDate",model.LastStartDate),
                new SqlParameter ("@LastEndDate",model.LastEndDate),
                new SqlParameter ("@StudyCount",model.StudyCount),
                new SqlParameter ("@StudyTimes",model.StudyTimes),
                new SqlParameter ("@IsComplete",model.IsComplete),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@TotalTimes",model.TotalTimes)
            };
           return DBHelper.ExecuteNonQuery("CourseStudyRecord_Change",param);
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
                new SqlParameter ("@StudyRecordId",Id)
            };
           return DBHelper.ExecuteNonQuery ("CourseStudyRecord_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("CourseStudyRecord_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<CourseStudyRecord> SelectAll()
        {
            List<CourseStudyRecord> list = new List<CourseStudyRecord>();
            CourseStudyRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("CourseStudyRecord_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new CourseStudyRecord();
                    model.StudyRecordId= Convert.ToInt32(dr["StudyRecordId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.CourseId= Convert.ToInt32(dr["CourseId"]);
                    model.MmsId= Convert.ToInt32(dr["MmsId"]);
                    model.Credit= Convert.ToDecimal(dr["Credit"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
                    if (DBNull.Value!=dr["FinishDate"])
                        model.FinishDate= Convert.ToDateTime(dr["FinishDate"]);
                    model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastStartDate"])
                        model.LastStartDate= Convert.ToDateTime(dr["LastStartDate"]);
                    if (DBNull.Value!=dr["LastEndDate"])
                        model.LastEndDate= Convert.ToDateTime(dr["LastEndDate"]);
                    if (DBNull.Value!=dr["StudyCount"])
                        model.StudyCount= Convert.ToInt32(dr["StudyCount"]);
                    if (DBNull.Value!=dr["StudyTimes"])
                        model.StudyTimes= Convert.ToInt32(dr["StudyTimes"]);
                    if (DBNull.Value!=dr["IsComplete"])
                        model.IsComplete= Convert.ToBoolean(dr["IsComplete"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["TotalTimes"])
                        model.TotalTimes= Convert.ToInt32(dr["TotalTimes"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>CourseStudyRecord实体类对象</returns>
        public CourseStudyRecord SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@StudyRecordId",Id)
            };
            CourseStudyRecord model = new CourseStudyRecord();
            using (SqlDataReader dr = DBHelper.RunProcedure("CourseStudyRecord_SelectById", param))
            {
                if (dr.Read())
                {
                    model.StudyRecordId= Convert.ToInt32(dr["StudyRecordId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.CourseId= Convert.ToInt32(dr["CourseId"]);
                    model.MmsId= Convert.ToInt32(dr["MmsId"]);
                    model.Credit= Convert.ToDecimal(dr["Credit"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
                    if (DBNull.Value!=dr["FinishDate"])
                        model.FinishDate= Convert.ToDateTime(dr["FinishDate"]);
                    model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastStartDate"])
                        model.LastStartDate= Convert.ToDateTime(dr["LastStartDate"]);
                    if (DBNull.Value!=dr["LastEndDate"])
                        model.LastEndDate= Convert.ToDateTime(dr["LastEndDate"]);
                    if (DBNull.Value!=dr["StudyCount"])
                        model.StudyCount= Convert.ToInt32(dr["StudyCount"]);
                    if (DBNull.Value!=dr["StudyTimes"])
                        model.StudyTimes= Convert.ToInt32(dr["StudyTimes"]);
                    if (DBNull.Value!=dr["IsComplete"])
                        model.IsComplete= Convert.ToBoolean(dr["IsComplete"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["TotalTimes"])
                        model.TotalTimes= Convert.ToInt32(dr["TotalTimes"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>CourseStudyRecord实体类对象</returns>
        public List<CourseStudyRecord> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<CourseStudyRecord> list = new List<CourseStudyRecord>();
            CourseStudyRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("CourseStudyRecord_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new CourseStudyRecord();
                    model.StudyRecordId= Convert.ToInt32(dr["StudyRecordId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.CourseId= Convert.ToInt32(dr["CourseId"]);
                    model.MmsId= Convert.ToInt32(dr["MmsId"]);
                    model.Credit= Convert.ToDecimal(dr["Credit"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
                    if (DBNull.Value!=dr["FinishDate"])
                        model.FinishDate= Convert.ToDateTime(dr["FinishDate"]);
                    model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastStartDate"])
                        model.LastStartDate= Convert.ToDateTime(dr["LastStartDate"]);
                    if (DBNull.Value!=dr["LastEndDate"])
                        model.LastEndDate= Convert.ToDateTime(dr["LastEndDate"]);
                    if (DBNull.Value!=dr["StudyCount"])
                        model.StudyCount= Convert.ToInt32(dr["StudyCount"]);
                    if (DBNull.Value!=dr["StudyTimes"])
                        model.StudyTimes= Convert.ToInt32(dr["StudyTimes"]);
                    if (DBNull.Value!=dr["IsComplete"])
                        model.IsComplete= Convert.ToBoolean(dr["IsComplete"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["TotalTimes"])
                        model.TotalTimes= Convert.ToInt32(dr["TotalTimes"]);
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
        /// <returns>CourseStudyRecord实体类对象</returns>
        public List<CourseStudyRecord> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<CourseStudyRecord> list = new List<CourseStudyRecord>();
            CourseStudyRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("CourseStudyRecord_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new CourseStudyRecord();
                    model.StudyRecordId= Convert.ToInt32(dr["StudyRecordId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.CourseId= Convert.ToInt32(dr["CourseId"]);
                    model.MmsId= Convert.ToInt32(dr["MmsId"]);
                    model.Credit= Convert.ToDecimal(dr["Credit"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
                    if (DBNull.Value!=dr["FinishDate"])
                        model.FinishDate= Convert.ToDateTime(dr["FinishDate"]);
                    model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastStartDate"])
                        model.LastStartDate= Convert.ToDateTime(dr["LastStartDate"]);
                    if (DBNull.Value!=dr["LastEndDate"])
                        model.LastEndDate= Convert.ToDateTime(dr["LastEndDate"]);
                    if (DBNull.Value!=dr["StudyCount"])
                        model.StudyCount= Convert.ToInt32(dr["StudyCount"]);
                    if (DBNull.Value!=dr["StudyTimes"])
                        model.StudyTimes= Convert.ToInt32(dr["StudyTimes"]);
                    if (DBNull.Value!=dr["IsComplete"])
                        model.IsComplete= Convert.ToBoolean(dr["IsComplete"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["TotalTimes"])
                        model.TotalTimes= Convert.ToInt32(dr["TotalTimes"]);
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

