using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class ExamCourseDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ExamCourse">ExamCourse实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(ExamCourse model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamId",model.ExamId),
                new SqlParameter ("@CourseId",model.CourseId),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("ExamCourse_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ExamCourse">ExamCourse实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(ExamCourse model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamId",model.ExamId),
                new SqlParameter ("@CourseId",model.CourseId),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("ExamCourse_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ExamCourse">ExamCourse实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(ExamCourse model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamCourseId",model.ExamCourseId),
                new SqlParameter ("@ExamId",model.ExamId),
                new SqlParameter ("@CourseId",model.CourseId),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("ExamCourse_Change",param);
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
                new SqlParameter ("@ExamCourseId",Id)
            };
           return DBHelper.ExecuteNonQuery ("ExamCourse_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("ExamCourse_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<ExamCourse> SelectAll()
        {
            List<ExamCourse> list = new List<ExamCourse>();
            ExamCourse model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ExamCourse_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new ExamCourse();
                    model.ExamCourseId= Convert.ToInt32(dr["ExamCourseId"]);
                    model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    model.CourseId= Convert.ToInt32(dr["CourseId"]);
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
        /// <returns>ExamCourse实体类对象</returns>
        public ExamCourse SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamCourseId",Id)
            };
            ExamCourse model = new ExamCourse();
            using (SqlDataReader dr = DBHelper.RunProcedure("ExamCourse_SelectById", param))
            {
                if (dr.Read())
                {
                    model.ExamCourseId= Convert.ToInt32(dr["ExamCourseId"]);
                    model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    model.CourseId= Convert.ToInt32(dr["CourseId"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>ExamCourse实体类对象</returns>
        public List<ExamCourse> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<ExamCourse> list = new List<ExamCourse>();
            ExamCourse model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ExamCourse_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new ExamCourse();
                    model.ExamCourseId= Convert.ToInt32(dr["ExamCourseId"]);
                    model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    model.CourseId= Convert.ToInt32(dr["CourseId"]);
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
        /// <returns>ExamCourse实体类对象</returns>
        public List<ExamCourse> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<ExamCourse> list = new List<ExamCourse>();
            ExamCourse model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ExamCourse_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new ExamCourse();
                    model.ExamCourseId= Convert.ToInt32(dr["ExamCourseId"]);
                    model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    model.CourseId= Convert.ToInt32(dr["CourseId"]);
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

