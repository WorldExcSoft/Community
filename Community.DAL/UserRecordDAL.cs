using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class UserRecordDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="UserRecord">UserRecord实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(UserRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@Details",model.Details),
                new SqlParameter ("@Record",model.Record),
                new SqlParameter ("@CreateTime",model.CreateTime),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@RecordType",model.RecordType),
                new SqlParameter ("@ObjType",model.ObjType),
                new SqlParameter ("@ObjId",model.ObjId),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("UserRecord_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="UserRecord">UserRecord实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(UserRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@Details",model.Details),
                new SqlParameter ("@Record",model.Record),
                new SqlParameter ("@CreateTime",model.CreateTime),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@RecordType",model.RecordType),
                new SqlParameter ("@ObjType",model.ObjType),
                new SqlParameter ("@ObjId",model.ObjId),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("UserRecord_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="UserRecord">UserRecord实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(UserRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@RecordId",model.RecordId),
                new SqlParameter ("@Details",model.Details),
                new SqlParameter ("@Record",model.Record),
                new SqlParameter ("@CreateTime",model.CreateTime),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@RecordType",model.RecordType),
                new SqlParameter ("@ObjType",model.ObjType),
                new SqlParameter ("@ObjId",model.ObjId),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("UserRecord_Change",param);
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
                new SqlParameter ("@RecordId",Id)
            };
           return DBHelper.ExecuteNonQuery ("UserRecord_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("UserRecord_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<UserRecord> SelectAll()
        {
            List<UserRecord> list = new List<UserRecord>();
            UserRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("UserRecord_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new UserRecord();
                    model.RecordId= Convert.ToInt32(dr["RecordId"]);
                    if (DBNull.Value!=dr["Details"])
                        model.Details = dr["Details"].ToString();
                    model.Record= Convert.ToDecimal(dr["Record"]);
                    model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.RecordType= Convert.ToInt32(dr["RecordType"]);
                    model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    model.ObjId= Convert.ToInt32(dr["ObjId"]);
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
        /// <returns>UserRecord实体类对象</returns>
        public UserRecord SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@RecordId",Id)
            };
            UserRecord model = new UserRecord();
            using (SqlDataReader dr = DBHelper.RunProcedure("UserRecord_SelectById", param))
            {
                if (dr.Read())
                {
                    model.RecordId= Convert.ToInt32(dr["RecordId"]);
                    if (DBNull.Value!=dr["Details"])
                        model.Details = dr["Details"].ToString();
                    model.Record= Convert.ToDecimal(dr["Record"]);
                    model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.RecordType= Convert.ToInt32(dr["RecordType"]);
                    model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    model.ObjId= Convert.ToInt32(dr["ObjId"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>UserRecord实体类对象</returns>
        public List<UserRecord> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<UserRecord> list = new List<UserRecord>();
            UserRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("UserRecord_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new UserRecord();
                    model.RecordId= Convert.ToInt32(dr["RecordId"]);
                    if (DBNull.Value!=dr["Details"])
                        model.Details = dr["Details"].ToString();
                    model.Record= Convert.ToDecimal(dr["Record"]);
                    model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.RecordType= Convert.ToInt32(dr["RecordType"]);
                    model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    model.ObjId= Convert.ToInt32(dr["ObjId"]);
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
        /// <returns>UserRecord实体类对象</returns>
        public List<UserRecord> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<UserRecord> list = new List<UserRecord>();
            UserRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("UserRecord_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new UserRecord();
                    model.RecordId= Convert.ToInt32(dr["RecordId"]);
                    if (DBNull.Value!=dr["Details"])
                        model.Details = dr["Details"].ToString();
                    model.Record= Convert.ToDecimal(dr["Record"]);
                    model.CreateTime= Convert.ToDateTime(dr["CreateTime"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.RecordType= Convert.ToInt32(dr["RecordType"]);
                    model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    model.ObjId= Convert.ToInt32(dr["ObjId"]);
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

