using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class LearnExperienceDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="LearnExperience">LearnExperience实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(LearnExperience model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@CourseId",model.CourseId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@Title",model.Title),
                new SqlParameter ("@Content",model.Content),
                new SqlParameter ("@CreateTime",model.CreateTime),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Status",model.Status)
            };
           return DBHelper.ExecuteNonQuery("LearnExperience_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="LearnExperience">LearnExperience实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(LearnExperience model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@CourseId",model.CourseId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@Title",model.Title),
                new SqlParameter ("@Content",model.Content),
                new SqlParameter ("@CreateTime",model.CreateTime),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Status",model.Status)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("LearnExperience_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="LearnExperience">LearnExperience实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(LearnExperience model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@LearnExperienceId",model.LearnExperienceId),
                new SqlParameter ("@CourseId",model.CourseId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@Title",model.Title),
                new SqlParameter ("@Content",model.Content),
                new SqlParameter ("@CreateTime",model.CreateTime),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Status",model.Status)
            };
           return DBHelper.ExecuteNonQuery("LearnExperience_Change",param);
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
                new SqlParameter ("@LearnExperienceId",Id)
            };
           return DBHelper.ExecuteNonQuery ("LearnExperience_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("LearnExperience_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<LearnExperience> SelectAll()
        {
            List<LearnExperience> list = new List<LearnExperience>();
            LearnExperience model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("LearnExperience_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new LearnExperience();
                    model.LearnExperienceId= Convert.ToInt32(dr["LearnExperienceId"]);
                    if (DBNull.Value!=dr["CourseId"])
                        model.CourseId= Convert.ToInt32(dr["CourseId"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["Title"])
                        model.Title = dr["Title"].ToString();
                    if (DBNull.Value!=dr["Content"])
                        model.Content = dr["Content"].ToString();
                    if (DBNull.Value!=dr["CreateTime"])
                        model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>LearnExperience实体类对象</returns>
        public LearnExperience SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@LearnExperienceId",Id)
            };
            LearnExperience model = new LearnExperience();
            using (SqlDataReader dr = DBHelper.RunProcedure("LearnExperience_SelectById", param))
            {
                if (dr.Read())
                {
                    model.LearnExperienceId= Convert.ToInt32(dr["LearnExperienceId"]);
                    if (DBNull.Value!=dr["CourseId"])
                        model.CourseId= Convert.ToInt32(dr["CourseId"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["Title"])
                        model.Title = dr["Title"].ToString();
                    if (DBNull.Value!=dr["Content"])
                        model.Content = dr["Content"].ToString();
                    if (DBNull.Value!=dr["CreateTime"])
                        model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>LearnExperience实体类对象</returns>
        public List<LearnExperience> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<LearnExperience> list = new List<LearnExperience>();
            LearnExperience model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("LearnExperience_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new LearnExperience();
                    model.LearnExperienceId= Convert.ToInt32(dr["LearnExperienceId"]);
                    if (DBNull.Value!=dr["CourseId"])
                        model.CourseId= Convert.ToInt32(dr["CourseId"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["Title"])
                        model.Title = dr["Title"].ToString();
                    if (DBNull.Value!=dr["Content"])
                        model.Content = dr["Content"].ToString();
                    if (DBNull.Value!=dr["CreateTime"])
                        model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
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
        /// <returns>LearnExperience实体类对象</returns>
        public List<LearnExperience> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<LearnExperience> list = new List<LearnExperience>();
            LearnExperience model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("LearnExperience_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new LearnExperience();
                    model.LearnExperienceId= Convert.ToInt32(dr["LearnExperienceId"]);
                    if (DBNull.Value!=dr["CourseId"])
                        model.CourseId= Convert.ToInt32(dr["CourseId"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["Title"])
                        model.Title = dr["Title"].ToString();
                    if (DBNull.Value!=dr["Content"])
                        model.Content = dr["Content"].ToString();
                    if (DBNull.Value!=dr["CreateTime"])
                        model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
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

