using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class GiftRecordDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="GiftRecord">GiftRecord实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(GiftRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@GiftId",model.GiftId),
                new SqlParameter ("@GiftRecordName",model.GiftRecordName),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@UseCoin",model.UseCoin),
                new SqlParameter ("@IsIssued",model.IsIssued),
                new SqlParameter ("@IssuedDate",model.IssuedDate),
                new SqlParameter ("@IsReceive",model.IsReceive),
                new SqlParameter ("@ReceiveDate",model.ReceiveDate),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("GiftRecord_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="GiftRecord">GiftRecord实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(GiftRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@GiftId",model.GiftId),
                new SqlParameter ("@GiftRecordName",model.GiftRecordName),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@UseCoin",model.UseCoin),
                new SqlParameter ("@IsIssued",model.IsIssued),
                new SqlParameter ("@IssuedDate",model.IssuedDate),
                new SqlParameter ("@IsReceive",model.IsReceive),
                new SqlParameter ("@ReceiveDate",model.ReceiveDate),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("GiftRecord_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="GiftRecord">GiftRecord实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(GiftRecord model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@GiftRecordId",model.GiftRecordId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@GiftId",model.GiftId),
                new SqlParameter ("@GiftRecordName",model.GiftRecordName),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@UseCoin",model.UseCoin),
                new SqlParameter ("@IsIssued",model.IsIssued),
                new SqlParameter ("@IssuedDate",model.IssuedDate),
                new SqlParameter ("@IsReceive",model.IsReceive),
                new SqlParameter ("@ReceiveDate",model.ReceiveDate),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("GiftRecord_Change",param);
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
                new SqlParameter ("@GiftRecordId",Id)
            };
           return DBHelper.ExecuteNonQuery ("GiftRecord_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("GiftRecord_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<GiftRecord> SelectAll()
        {
            List<GiftRecord> list = new List<GiftRecord>();
            GiftRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("GiftRecord_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new GiftRecord();
                    model.GiftRecordId= Convert.ToInt32(dr["GiftRecordId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.GiftId= Convert.ToInt32(dr["GiftId"]);
                    if (DBNull.Value!=dr["GiftRecordName"])
                        model.GiftRecordName = dr["GiftRecordName"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["UseCoin"])
                        model.UseCoin= Convert.ToDecimal(dr["UseCoin"]);
                    if (DBNull.Value!=dr["IsIssued"])
                        model.IsIssued= Convert.ToBoolean(dr["IsIssued"]);
                    if (DBNull.Value!=dr["IssuedDate"])
                        model.IssuedDate= Convert.ToDateTime(dr["IssuedDate"]);
                    if (DBNull.Value!=dr["IsReceive"])
                        model.IsReceive= Convert.ToBoolean(dr["IsReceive"]);
                    if (DBNull.Value!=dr["ReceiveDate"])
                        model.ReceiveDate= Convert.ToDateTime(dr["ReceiveDate"]);
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
        /// <returns>GiftRecord实体类对象</returns>
        public GiftRecord SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@GiftRecordId",Id)
            };
            GiftRecord model = new GiftRecord();
            using (SqlDataReader dr = DBHelper.RunProcedure("GiftRecord_SelectById", param))
            {
                if (dr.Read())
                {
                    model.GiftRecordId= Convert.ToInt32(dr["GiftRecordId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.GiftId= Convert.ToInt32(dr["GiftId"]);
                    if (DBNull.Value!=dr["GiftRecordName"])
                        model.GiftRecordName = dr["GiftRecordName"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["UseCoin"])
                        model.UseCoin= Convert.ToDecimal(dr["UseCoin"]);
                    if (DBNull.Value!=dr["IsIssued"])
                        model.IsIssued= Convert.ToBoolean(dr["IsIssued"]);
                    if (DBNull.Value!=dr["IssuedDate"])
                        model.IssuedDate= Convert.ToDateTime(dr["IssuedDate"]);
                    if (DBNull.Value!=dr["IsReceive"])
                        model.IsReceive= Convert.ToBoolean(dr["IsReceive"]);
                    if (DBNull.Value!=dr["ReceiveDate"])
                        model.ReceiveDate= Convert.ToDateTime(dr["ReceiveDate"]);
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
        /// <returns>GiftRecord实体类对象</returns>
        public List<GiftRecord> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<GiftRecord> list = new List<GiftRecord>();
            GiftRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("GiftRecord_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new GiftRecord();
                    model.GiftRecordId= Convert.ToInt32(dr["GiftRecordId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.GiftId= Convert.ToInt32(dr["GiftId"]);
                    if (DBNull.Value!=dr["GiftRecordName"])
                        model.GiftRecordName = dr["GiftRecordName"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["UseCoin"])
                        model.UseCoin= Convert.ToDecimal(dr["UseCoin"]);
                    if (DBNull.Value!=dr["IsIssued"])
                        model.IsIssued= Convert.ToBoolean(dr["IsIssued"]);
                    if (DBNull.Value!=dr["IssuedDate"])
                        model.IssuedDate= Convert.ToDateTime(dr["IssuedDate"]);
                    if (DBNull.Value!=dr["IsReceive"])
                        model.IsReceive= Convert.ToBoolean(dr["IsReceive"]);
                    if (DBNull.Value!=dr["ReceiveDate"])
                        model.ReceiveDate= Convert.ToDateTime(dr["ReceiveDate"]);
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
        /// <returns>GiftRecord实体类对象</returns>
        public List<GiftRecord> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<GiftRecord> list = new List<GiftRecord>();
            GiftRecord model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("GiftRecord_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new GiftRecord();
                    model.GiftRecordId= Convert.ToInt32(dr["GiftRecordId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.GiftId= Convert.ToInt32(dr["GiftId"]);
                    if (DBNull.Value!=dr["GiftRecordName"])
                        model.GiftRecordName = dr["GiftRecordName"].ToString();
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["UseCoin"])
                        model.UseCoin= Convert.ToDecimal(dr["UseCoin"]);
                    if (DBNull.Value!=dr["IsIssued"])
                        model.IsIssued= Convert.ToBoolean(dr["IsIssued"]);
                    if (DBNull.Value!=dr["IssuedDate"])
                        model.IssuedDate= Convert.ToDateTime(dr["IssuedDate"]);
                    if (DBNull.Value!=dr["IsReceive"])
                        model.IsReceive= Convert.ToBoolean(dr["IsReceive"]);
                    if (DBNull.Value!=dr["ReceiveDate"])
                        model.ReceiveDate= Convert.ToDateTime(dr["ReceiveDate"]);
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

