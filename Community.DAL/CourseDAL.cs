using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class CourseDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Course">Course实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(Course model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@CourseName",model.CourseName),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@Source",model.Source),
                new SqlParameter ("@Duration",model.Duration),
                new SqlParameter ("@Credit",model.Credit),
                new SqlParameter ("@Coin",model.Coin),
                new SqlParameter ("@TeacherName",model.TeacherName),
                new SqlParameter ("@TeacherInfo",model.TeacherInfo),
                new SqlParameter ("@ClickCount",model.ClickCount),
                new SqlParameter ("@AssistCount",model.AssistCount),
                new SqlParameter ("@ChannelType",model.ChannelType),
                new SqlParameter ("@VideoType",model.VideoType),
                new SqlParameter ("@Recommend",model.Recommend),
                new SqlParameter ("@RecommendDate",model.RecommendDate),
                new SqlParameter ("@CourseTag",model.CourseTag),
                new SqlParameter ("@CourseImage",model.CourseImage),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@PlatformId",model.PlatformId)
            };
           return DBHelper.ExecuteNonQuery("Course_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Course">Course实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(Course model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@CourseName",model.CourseName),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@Source",model.Source),
                new SqlParameter ("@Duration",model.Duration),
                new SqlParameter ("@Credit",model.Credit),
                new SqlParameter ("@Coin",model.Coin),
                new SqlParameter ("@TeacherName",model.TeacherName),
                new SqlParameter ("@TeacherInfo",model.TeacherInfo),
                new SqlParameter ("@ClickCount",model.ClickCount),
                new SqlParameter ("@AssistCount",model.AssistCount),
                new SqlParameter ("@ChannelType",model.ChannelType),
                new SqlParameter ("@VideoType",model.VideoType),
                new SqlParameter ("@Recommend",model.Recommend),
                new SqlParameter ("@RecommendDate",model.RecommendDate),
                new SqlParameter ("@CourseTag",model.CourseTag),
                new SqlParameter ("@CourseImage",model.CourseImage),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@PlatformId",model.PlatformId)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("Course_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Course">Course实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(Course model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@CourseId",model.CourseId),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@CourseName",model.CourseName),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@Source",model.Source),
                new SqlParameter ("@Duration",model.Duration),
                new SqlParameter ("@Credit",model.Credit),
                new SqlParameter ("@Coin",model.Coin),
                new SqlParameter ("@TeacherName",model.TeacherName),
                new SqlParameter ("@TeacherInfo",model.TeacherInfo),
                new SqlParameter ("@ClickCount",model.ClickCount),
                new SqlParameter ("@AssistCount",model.AssistCount),
                new SqlParameter ("@ChannelType",model.ChannelType),
                new SqlParameter ("@VideoType",model.VideoType),
                new SqlParameter ("@Recommend",model.Recommend),
                new SqlParameter ("@RecommendDate",model.RecommendDate),
                new SqlParameter ("@CourseTag",model.CourseTag),
                new SqlParameter ("@CourseImage",model.CourseImage),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@PlatformId",model.PlatformId)
            };
           return DBHelper.ExecuteNonQuery("Course_Change",param);
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
                new SqlParameter ("@CourseId",Id)
            };
           return DBHelper.ExecuteNonQuery ("Course_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("Course_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<Course> SelectAll()
        {
            List<Course> list = new List<Course>();
            Course model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Course_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new Course();
                    model.CourseId= Convert.ToInt32(dr["CourseId"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["CourseName"])
                        model.CourseName = dr["CourseName"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    if (DBNull.Value!=dr["Source"])
                        model.Source = dr["Source"].ToString();
                    if (DBNull.Value!=dr["Duration"])
                        model.Duration= Convert.ToInt32(dr["Duration"]);
                    if (DBNull.Value!=dr["Credit"])
                        model.Credit= Convert.ToDecimal(dr["Credit"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
                    if (DBNull.Value!=dr["TeacherName"])
                        model.TeacherName = dr["TeacherName"].ToString();
                    if (DBNull.Value!=dr["TeacherInfo"])
                        model.TeacherInfo = dr["TeacherInfo"].ToString();
                    if (DBNull.Value!=dr["ClickCount"])
                        model.ClickCount= Convert.ToInt32(dr["ClickCount"]);
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["ChannelType"])
                        model.ChannelType = dr["ChannelType"].ToString();
                    if (DBNull.Value!=dr["VideoType"])
                        model.VideoType= Convert.ToInt32(dr["VideoType"]);
                    if (DBNull.Value!=dr["Recommend"])
                        model.Recommend= Convert.ToInt32(dr["Recommend"]);
                    if (DBNull.Value!=dr["RecommendDate"])
                        model.RecommendDate= Convert.ToDateTime(dr["RecommendDate"]);
                    if (DBNull.Value!=dr["CourseTag"])
                        model.CourseTag = dr["CourseTag"].ToString();
                    if (DBNull.Value!=dr["CourseImage"])
                        model.CourseImage = dr["CourseImage"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["PlatformId"])
                        model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>Course实体类对象</returns>
        public Course SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@CourseId",Id)
            };
            Course model = new Course();
            using (SqlDataReader dr = DBHelper.RunProcedure("Course_SelectById", param))
            {
                if (dr.Read())
                {
                    model.CourseId= Convert.ToInt32(dr["CourseId"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["CourseName"])
                        model.CourseName = dr["CourseName"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    if (DBNull.Value!=dr["Source"])
                        model.Source = dr["Source"].ToString();
                    if (DBNull.Value!=dr["Duration"])
                        model.Duration= Convert.ToInt32(dr["Duration"]);
                    if (DBNull.Value!=dr["Credit"])
                        model.Credit= Convert.ToDecimal(dr["Credit"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
                    if (DBNull.Value!=dr["TeacherName"])
                        model.TeacherName = dr["TeacherName"].ToString();
                    if (DBNull.Value!=dr["TeacherInfo"])
                        model.TeacherInfo = dr["TeacherInfo"].ToString();
                    if (DBNull.Value!=dr["ClickCount"])
                        model.ClickCount= Convert.ToInt32(dr["ClickCount"]);
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["ChannelType"])
                        model.ChannelType = dr["ChannelType"].ToString();
                    if (DBNull.Value!=dr["VideoType"])
                        model.VideoType= Convert.ToInt32(dr["VideoType"]);
                    if (DBNull.Value!=dr["Recommend"])
                        model.Recommend= Convert.ToInt32(dr["Recommend"]);
                    if (DBNull.Value!=dr["RecommendDate"])
                        model.RecommendDate= Convert.ToDateTime(dr["RecommendDate"]);
                    if (DBNull.Value!=dr["CourseTag"])
                        model.CourseTag = dr["CourseTag"].ToString();
                    if (DBNull.Value!=dr["CourseImage"])
                        model.CourseImage = dr["CourseImage"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["PlatformId"])
                        model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>Course实体类对象</returns>
        public List<Course> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<Course> list = new List<Course>();
            Course model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Course_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new Course();
                    model.CourseId= Convert.ToInt32(dr["CourseId"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["CourseName"])
                        model.CourseName = dr["CourseName"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    if (DBNull.Value!=dr["Source"])
                        model.Source = dr["Source"].ToString();
                    if (DBNull.Value!=dr["Duration"])
                        model.Duration= Convert.ToInt32(dr["Duration"]);
                    if (DBNull.Value!=dr["Credit"])
                        model.Credit= Convert.ToDecimal(dr["Credit"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
                    if (DBNull.Value!=dr["TeacherName"])
                        model.TeacherName = dr["TeacherName"].ToString();
                    if (DBNull.Value!=dr["TeacherInfo"])
                        model.TeacherInfo = dr["TeacherInfo"].ToString();
                    if (DBNull.Value!=dr["ClickCount"])
                        model.ClickCount= Convert.ToInt32(dr["ClickCount"]);
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["ChannelType"])
                        model.ChannelType = dr["ChannelType"].ToString();
                    if (DBNull.Value!=dr["VideoType"])
                        model.VideoType= Convert.ToInt32(dr["VideoType"]);
                    if (DBNull.Value!=dr["Recommend"])
                        model.Recommend= Convert.ToInt32(dr["Recommend"]);
                    if (DBNull.Value!=dr["RecommendDate"])
                        model.RecommendDate= Convert.ToDateTime(dr["RecommendDate"]);
                    if (DBNull.Value!=dr["CourseTag"])
                        model.CourseTag = dr["CourseTag"].ToString();
                    if (DBNull.Value!=dr["CourseImage"])
                        model.CourseImage = dr["CourseImage"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["PlatformId"])
                        model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
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
        /// <returns>Course实体类对象</returns>
        public List<Course> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<Course> list = new List<Course>();
            Course model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Course_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new Course();
                    model.CourseId= Convert.ToInt32(dr["CourseId"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["CourseName"])
                        model.CourseName = dr["CourseName"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    if (DBNull.Value!=dr["Source"])
                        model.Source = dr["Source"].ToString();
                    if (DBNull.Value!=dr["Duration"])
                        model.Duration= Convert.ToInt32(dr["Duration"]);
                    if (DBNull.Value!=dr["Credit"])
                        model.Credit= Convert.ToDecimal(dr["Credit"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
                    if (DBNull.Value!=dr["TeacherName"])
                        model.TeacherName = dr["TeacherName"].ToString();
                    if (DBNull.Value!=dr["TeacherInfo"])
                        model.TeacherInfo = dr["TeacherInfo"].ToString();
                    if (DBNull.Value!=dr["ClickCount"])
                        model.ClickCount= Convert.ToInt32(dr["ClickCount"]);
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["ChannelType"])
                        model.ChannelType = dr["ChannelType"].ToString();
                    if (DBNull.Value!=dr["VideoType"])
                        model.VideoType= Convert.ToInt32(dr["VideoType"]);
                    if (DBNull.Value!=dr["Recommend"])
                        model.Recommend= Convert.ToInt32(dr["Recommend"]);
                    if (DBNull.Value!=dr["RecommendDate"])
                        model.RecommendDate= Convert.ToDateTime(dr["RecommendDate"]);
                    if (DBNull.Value!=dr["CourseTag"])
                        model.CourseTag = dr["CourseTag"].ToString();
                    if (DBNull.Value!=dr["CourseImage"])
                        model.CourseImage = dr["CourseImage"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["PlatformId"])
                        model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
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

