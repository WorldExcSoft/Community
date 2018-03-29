using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class CourseMmsDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="CourseMms">CourseMms实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(CourseMms model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@Mms",model.Mms),
                new SqlParameter ("@MmsName",model.MmsName),
                new SqlParameter ("@VideoLength",model.VideoLength),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@CourseId",model.CourseId)
            };
           return DBHelper.ExecuteNonQuery("CourseMms_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="CourseMms">CourseMms实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(CourseMms model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@Mms",model.Mms),
                new SqlParameter ("@MmsName",model.MmsName),
                new SqlParameter ("@VideoLength",model.VideoLength),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@CourseId",model.CourseId)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("CourseMms_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="CourseMms">CourseMms实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(CourseMms model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@CourseMmsId",model.CourseMmsId),
                new SqlParameter ("@Mms",model.Mms),
                new SqlParameter ("@MmsName",model.MmsName),
                new SqlParameter ("@VideoLength",model.VideoLength),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@CourseId",model.CourseId)
            };
           return DBHelper.ExecuteNonQuery("CourseMms_Change",param);
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
                new SqlParameter ("@CourseMmsId",Id)
            };
           return DBHelper.ExecuteNonQuery ("CourseMms_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("CourseMms_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<CourseMms> SelectAll()
        {
            List<CourseMms> list = new List<CourseMms>();
            CourseMms model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("CourseMms_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new CourseMms();
                    model.CourseMmsId= Convert.ToInt32(dr["CourseMmsId"]);
                    if (DBNull.Value!=dr["Mms"])
                        model.Mms = dr["Mms"].ToString();
                    if (DBNull.Value!=dr["MmsName"])
                        model.MmsName = dr["MmsName"].ToString();
                    if (DBNull.Value!=dr["VideoLength"])
                        model.VideoLength= Convert.ToInt32(dr["VideoLength"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["CourseId"])
                        model.CourseId= Convert.ToInt32(dr["CourseId"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>CourseMms实体类对象</returns>
        public CourseMms SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@CourseMmsId",Id)
            };
            CourseMms model = new CourseMms();
            using (SqlDataReader dr = DBHelper.RunProcedure("CourseMms_SelectById", param))
            {
                if (dr.Read())
                {
                    model.CourseMmsId= Convert.ToInt32(dr["CourseMmsId"]);
                    if (DBNull.Value!=dr["Mms"])
                        model.Mms = dr["Mms"].ToString();
                    if (DBNull.Value!=dr["MmsName"])
                        model.MmsName = dr["MmsName"].ToString();
                    if (DBNull.Value!=dr["VideoLength"])
                        model.VideoLength= Convert.ToInt32(dr["VideoLength"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["CourseId"])
                        model.CourseId= Convert.ToInt32(dr["CourseId"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>CourseMms实体类对象</returns>
        public List<CourseMms> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<CourseMms> list = new List<CourseMms>();
            CourseMms model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("CourseMms_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new CourseMms();
                    model.CourseMmsId= Convert.ToInt32(dr["CourseMmsId"]);
                    if (DBNull.Value!=dr["Mms"])
                        model.Mms = dr["Mms"].ToString();
                    if (DBNull.Value!=dr["MmsName"])
                        model.MmsName = dr["MmsName"].ToString();
                    if (DBNull.Value!=dr["VideoLength"])
                        model.VideoLength= Convert.ToInt32(dr["VideoLength"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["CourseId"])
                        model.CourseId= Convert.ToInt32(dr["CourseId"]);
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
        /// <returns>CourseMms实体类对象</returns>
        public List<CourseMms> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<CourseMms> list = new List<CourseMms>();
            CourseMms model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("CourseMms_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new CourseMms();
                    model.CourseMmsId= Convert.ToInt32(dr["CourseMmsId"]);
                    if (DBNull.Value!=dr["Mms"])
                        model.Mms = dr["Mms"].ToString();
                    if (DBNull.Value!=dr["MmsName"])
                        model.MmsName = dr["MmsName"].ToString();
                    if (DBNull.Value!=dr["VideoLength"])
                        model.VideoLength= Convert.ToInt32(dr["VideoLength"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["CourseId"])
                        model.CourseId= Convert.ToInt32(dr["CourseId"]);
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

