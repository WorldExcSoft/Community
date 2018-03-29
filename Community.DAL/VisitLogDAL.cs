using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class VisitLogDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="VisitLog">VisitLog实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(VisitLog model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@CreateTime",model.CreateTime),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@UserIP",model.UserIP),
                new SqlParameter ("@UserCity",model.UserCity),
                new SqlParameter ("@Device",model.Device),
                new SqlParameter ("@Browse",model.Browse),
                new SqlParameter ("@Url",model.Url),
                new SqlParameter ("@GroupId",model.GroupId),
                new SqlParameter ("@ProId",model.ProId),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@VisitCount",model.VisitCount),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@IsFront",model.IsFront)
                
            };
           return DBHelper.ExecuteNonQuery("VisitLog_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="VisitLog">VisitLog实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(VisitLog model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@CreateTime",model.CreateTime),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@UserIP",model.UserIP),
                new SqlParameter ("@UserCity",model.UserCity),
                new SqlParameter ("@Device",model.Device),
                new SqlParameter ("@Browse",model.Browse),
                new SqlParameter ("@Url",model.Url),
                new SqlParameter ("@GroupId",model.GroupId),
                new SqlParameter ("@ProId",model.ProId),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@VisitCount",model.VisitCount),
                new SqlParameter ("@IsDelete",model.IsDelete),
                 new SqlParameter ("@IsFront",model.IsFront)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("VisitLog_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="VisitLog">VisitLog实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(VisitLog model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@Id",model.Id),
                new SqlParameter ("@CreateTime",model.CreateTime),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@UserIP",model.UserIP),
                new SqlParameter ("@UserCity",model.UserCity),
                new SqlParameter ("@Device",model.Device),
                new SqlParameter ("@Browse",model.Browse),
                new SqlParameter ("@Url",model.Url),
                new SqlParameter ("@GroupId",model.GroupId),
                new SqlParameter ("@ProId",model.ProId),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@VisitCount",model.VisitCount),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@IsFront",model.IsFront)
            };
           return DBHelper.ExecuteNonQuery("VisitLog_Change",param);
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
                new SqlParameter ("@Id",Id)
            };
           return DBHelper.ExecuteNonQuery ("VisitLog_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("VisitLog_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<VisitLog> SelectAll()
        {
            List<VisitLog> list = new List<VisitLog>();
            VisitLog model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("VisitLog_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new VisitLog();
                    model.Id= Convert.ToInt32(dr["Id"]);
                    model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["UserIP"])
                        model.UserIP = dr["UserIP"].ToString();
                    if (DBNull.Value!=dr["UserCity"])
                        model.UserCity = dr["UserCity"].ToString();
                    if (DBNull.Value!=dr["Device"])
                        model.Device= Convert.ToInt32(dr["Device"]);
                    if (DBNull.Value!=dr["Browse"])
                        model.Browse = dr["Browse"].ToString();
                    if (DBNull.Value!=dr["Url"])
                        model.Url = dr["Url"].ToString();
                    if (DBNull.Value!=dr["GroupId"])
                        model.GroupId= Convert.ToInt32(dr["GroupId"]);
                    if (DBNull.Value!=dr["ProId"])
                        model.ProId= Convert.ToInt32(dr["ProId"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    if (DBNull.Value!=dr["VisitCount"])
                        model.VisitCount= Convert.ToInt32(dr["VisitCount"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    model.IsFront = Convert.ToBoolean(dr["IsFront"]);
                    
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>VisitLog实体类对象</returns>
        public VisitLog SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@Id",Id)
            };
            VisitLog model = new VisitLog();
            using (SqlDataReader dr = DBHelper.RunProcedure("VisitLog_SelectById", param))
            {
                if (dr.Read())
                {
                    model.Id= Convert.ToInt32(dr["Id"]);
                    model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["UserIP"])
                        model.UserIP = dr["UserIP"].ToString();
                    if (DBNull.Value!=dr["UserCity"])
                        model.UserCity = dr["UserCity"].ToString();
                    if (DBNull.Value!=dr["Device"])
                        model.Device= Convert.ToInt32(dr["Device"]);
                    if (DBNull.Value!=dr["Browse"])
                        model.Browse = dr["Browse"].ToString();
                    if (DBNull.Value!=dr["Url"])
                        model.Url = dr["Url"].ToString();
                    if (DBNull.Value!=dr["GroupId"])
                        model.GroupId= Convert.ToInt32(dr["GroupId"]);
                    if (DBNull.Value!=dr["ProId"])
                        model.ProId= Convert.ToInt32(dr["ProId"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    if (DBNull.Value!=dr["VisitCount"])
                        model.VisitCount= Convert.ToInt32(dr["VisitCount"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    model.IsFront = Convert.ToBoolean(dr["IsFront"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>VisitLog实体类对象</returns>
        public List<VisitLog> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<VisitLog> list = new List<VisitLog>();
            VisitLog model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("VisitLog_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new VisitLog();
                    model.Id= Convert.ToInt32(dr["Id"]);
                    model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["UserIP"])
                        model.UserIP = dr["UserIP"].ToString();
                    if (DBNull.Value!=dr["UserCity"])
                        model.UserCity = dr["UserCity"].ToString();
                    if (DBNull.Value!=dr["Device"])
                        model.Device= Convert.ToInt32(dr["Device"]);
                    if (DBNull.Value!=dr["Browse"])
                        model.Browse = dr["Browse"].ToString();
                    if (DBNull.Value!=dr["Url"])
                        model.Url = dr["Url"].ToString();
                    if (DBNull.Value!=dr["GroupId"])
                        model.GroupId= Convert.ToInt32(dr["GroupId"]);
                    if (DBNull.Value!=dr["ProId"])
                        model.ProId= Convert.ToInt32(dr["ProId"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    if (DBNull.Value!=dr["VisitCount"])
                        model.VisitCount= Convert.ToInt32(dr["VisitCount"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    model.IsFront = Convert.ToBoolean(dr["IsFront"]);
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
        /// <returns>VisitLog实体类对象</returns>
        public List<VisitLog> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<VisitLog> list = new List<VisitLog>();
            VisitLog model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("VisitLog_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new VisitLog();
                    model.Id= Convert.ToInt32(dr["Id"]);
                    model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["UserIP"])
                        model.UserIP = dr["UserIP"].ToString();
                    if (DBNull.Value!=dr["UserCity"])
                        model.UserCity = dr["UserCity"].ToString();
                    if (DBNull.Value!=dr["Device"])
                        model.Device= Convert.ToInt32(dr["Device"]);
                    if (DBNull.Value!=dr["Browse"])
                        model.Browse = dr["Browse"].ToString();
                    if (DBNull.Value!=dr["Url"])
                        model.Url = dr["Url"].ToString();
                    if (DBNull.Value!=dr["GroupId"])
                        model.GroupId= Convert.ToInt32(dr["GroupId"]);
                    if (DBNull.Value!=dr["ProId"])
                        model.ProId= Convert.ToInt32(dr["ProId"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    if (DBNull.Value!=dr["VisitCount"])
                        model.VisitCount= Convert.ToInt32(dr["VisitCount"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    model.IsFront = Convert.ToBoolean(dr["IsFront"]);
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

