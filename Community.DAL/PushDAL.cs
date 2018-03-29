using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class PushDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Push">Push实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(Push model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PushName",model.PushName),
                new SqlParameter ("@Content",model.Content),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@Remark",model.Remark),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@ObjType",model.ObjType),
                new SqlParameter ("@ObjId",model.ObjId),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("Push_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Push">Push实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(Push model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PushName",model.PushName),
                new SqlParameter ("@Content",model.Content),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@Remark",model.Remark),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@ObjType",model.ObjType),
                new SqlParameter ("@ObjId",model.ObjId),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("Push_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Push">Push实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(Push model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PushId",model.PushId),
                new SqlParameter ("@PushName",model.PushName),
                new SqlParameter ("@Content",model.Content),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@Remark",model.Remark),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@ObjType",model.ObjType),
                new SqlParameter ("@ObjId",model.ObjId),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("Push_Change",param);
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
                new SqlParameter ("@PushId",Id)
            };
           return DBHelper.ExecuteNonQuery ("Push_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("Push_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<Push> SelectAll()
        {
            List<Push> list = new List<Push>();
            Push model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Push_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new Push();
                    model.PushId= Convert.ToInt32(dr["PushId"]);
                    if (DBNull.Value!=dr["PushName"])
                        model.PushName = dr["PushName"].ToString();
                    if (DBNull.Value!=dr["Content"])
                        model.Content = dr["Content"].ToString();
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["Remark"])
                        model.Remark = dr["Remark"].ToString();
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToBoolean(dr["Status"]);
                    if (DBNull.Value!=dr["ObjType"])
                        model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    if (DBNull.Value!=dr["ObjId"])
                        model.ObjId= Convert.ToInt32(dr["ObjId"]);
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
        /// <returns>Push实体类对象</returns>
        public Push SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PushId",Id)
            };
            Push model = new Push();
            using (SqlDataReader dr = DBHelper.RunProcedure("Push_SelectById", param))
            {
                if (dr.Read())
                {
                    model.PushId= Convert.ToInt32(dr["PushId"]);
                    if (DBNull.Value!=dr["PushName"])
                        model.PushName = dr["PushName"].ToString();
                    if (DBNull.Value!=dr["Content"])
                        model.Content = dr["Content"].ToString();
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["Remark"])
                        model.Remark = dr["Remark"].ToString();
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToBoolean(dr["Status"]);
                    if (DBNull.Value!=dr["ObjType"])
                        model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    if (DBNull.Value!=dr["ObjId"])
                        model.ObjId= Convert.ToInt32(dr["ObjId"]);
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
        /// <returns>Push实体类对象</returns>
        public List<Push> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<Push> list = new List<Push>();
            Push model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Push_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new Push();
                    model.PushId= Convert.ToInt32(dr["PushId"]);
                    if (DBNull.Value!=dr["PushName"])
                        model.PushName = dr["PushName"].ToString();
                    if (DBNull.Value!=dr["Content"])
                        model.Content = dr["Content"].ToString();
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["Remark"])
                        model.Remark = dr["Remark"].ToString();
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToBoolean(dr["Status"]);
                    if (DBNull.Value!=dr["ObjType"])
                        model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    if (DBNull.Value!=dr["ObjId"])
                        model.ObjId= Convert.ToInt32(dr["ObjId"]);
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
        /// <returns>Push实体类对象</returns>
        public List<Push> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<Push> list = new List<Push>();
            Push model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Push_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new Push();
                    model.PushId= Convert.ToInt32(dr["PushId"]);
                    if (DBNull.Value!=dr["PushName"])
                        model.PushName = dr["PushName"].ToString();
                    if (DBNull.Value!=dr["Content"])
                        model.Content = dr["Content"].ToString();
                    if (DBNull.Value!=dr["UserId"])
                        model.UserId= Convert.ToInt32(dr["UserId"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["Remark"])
                        model.Remark = dr["Remark"].ToString();
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToBoolean(dr["Status"]);
                    if (DBNull.Value!=dr["ObjType"])
                        model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    if (DBNull.Value!=dr["ObjId"])
                        model.ObjId= Convert.ToInt32(dr["ObjId"]);
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

