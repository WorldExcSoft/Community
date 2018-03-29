using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class GiftDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Gift">Gift实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(Gift model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@GiftName",model.GiftName),
                new SqlParameter ("@GiftDesc",model.GiftDesc),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@GiftType",model.GiftType),
                new SqlParameter ("@StockNumber",model.StockNumber),
                new SqlParameter ("@AlreadyIssuedNumber",model.AlreadyIssuedNumber),
                new SqlParameter ("@BeingIssuedNumber",model.BeingIssuedNumber),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@NeedCoin",model.NeedCoin),
                new SqlParameter ("@LimitNumber",model.LimitNumber),
                new SqlParameter ("@ClickCount",model.ClickCount),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Status",model.Status)
            };
           return DBHelper.ExecuteNonQuery("Gift_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Gift">Gift实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(Gift model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@GiftName",model.GiftName),
                new SqlParameter ("@GiftDesc",model.GiftDesc),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@GiftType",model.GiftType),
                new SqlParameter ("@StockNumber",model.StockNumber),
                new SqlParameter ("@AlreadyIssuedNumber",model.AlreadyIssuedNumber),
                new SqlParameter ("@BeingIssuedNumber",model.BeingIssuedNumber),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@NeedCoin",model.NeedCoin),
                new SqlParameter ("@LimitNumber",model.LimitNumber),
                new SqlParameter ("@ClickCount",model.ClickCount),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Status",model.Status)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("Gift_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Gift">Gift实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(Gift model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@GiftId",model.GiftId),
                new SqlParameter ("@GiftName",model.GiftName),
                new SqlParameter ("@GiftDesc",model.GiftDesc),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@GiftType",model.GiftType),
                new SqlParameter ("@StockNumber",model.StockNumber),
                new SqlParameter ("@AlreadyIssuedNumber",model.AlreadyIssuedNumber),
                new SqlParameter ("@BeingIssuedNumber",model.BeingIssuedNumber),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@NeedCoin",model.NeedCoin),
                new SqlParameter ("@LimitNumber",model.LimitNumber),
                new SqlParameter ("@ClickCount",model.ClickCount),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Status",model.Status)
            };
           return DBHelper.ExecuteNonQuery("Gift_Change",param);
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
                new SqlParameter ("@GiftId",Id)
            };
           return DBHelper.ExecuteNonQuery ("Gift_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("Gift_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<Gift> SelectAll()
        {
            List<Gift> list = new List<Gift>();
            Gift model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Gift_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new Gift();
                    model.GiftId= Convert.ToInt32(dr["GiftId"]);
                    if (DBNull.Value!=dr["GiftName"])
                        model.GiftName = dr["GiftName"].ToString();
                    if (DBNull.Value!=dr["GiftDesc"])
                        model.GiftDesc = dr["GiftDesc"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["GiftType"])
                        model.GiftType= Convert.ToInt32(dr["GiftType"]);
                    if (DBNull.Value!=dr["StockNumber"])
                        model.StockNumber= Convert.ToInt32(dr["StockNumber"]);
                    if (DBNull.Value!=dr["AlreadyIssuedNumber"])
                        model.AlreadyIssuedNumber= Convert.ToInt32(dr["AlreadyIssuedNumber"]);
                    if (DBNull.Value!=dr["BeingIssuedNumber"])
                        model.BeingIssuedNumber= Convert.ToInt32(dr["BeingIssuedNumber"]);
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["NeedCoin"])
                        model.NeedCoin= Convert.ToDecimal(dr["NeedCoin"]);
                    if (DBNull.Value!=dr["LimitNumber"])
                        model.LimitNumber= Convert.ToInt32(dr["LimitNumber"]);
                    if (DBNull.Value!=dr["ClickCount"])
                        model.ClickCount= Convert.ToInt32(dr["ClickCount"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
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
        /// <returns>Gift实体类对象</returns>
        public Gift SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@GiftId",Id)
            };
            Gift model = new Gift();
            using (SqlDataReader dr = DBHelper.RunProcedure("Gift_SelectById", param))
            {
                if (dr.Read())
                {
                    model.GiftId= Convert.ToInt32(dr["GiftId"]);
                    if (DBNull.Value!=dr["GiftName"])
                        model.GiftName = dr["GiftName"].ToString();
                    if (DBNull.Value!=dr["GiftDesc"])
                        model.GiftDesc = dr["GiftDesc"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["GiftType"])
                        model.GiftType= Convert.ToInt32(dr["GiftType"]);
                    if (DBNull.Value!=dr["StockNumber"])
                        model.StockNumber= Convert.ToInt32(dr["StockNumber"]);
                    if (DBNull.Value!=dr["AlreadyIssuedNumber"])
                        model.AlreadyIssuedNumber= Convert.ToInt32(dr["AlreadyIssuedNumber"]);
                    if (DBNull.Value!=dr["BeingIssuedNumber"])
                        model.BeingIssuedNumber= Convert.ToInt32(dr["BeingIssuedNumber"]);
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["NeedCoin"])
                        model.NeedCoin= Convert.ToDecimal(dr["NeedCoin"]);
                    if (DBNull.Value!=dr["LimitNumber"])
                        model.LimitNumber= Convert.ToInt32(dr["LimitNumber"]);
                    if (DBNull.Value!=dr["ClickCount"])
                        model.ClickCount= Convert.ToInt32(dr["ClickCount"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
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
        /// <returns>Gift实体类对象</returns>
        public List<Gift> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<Gift> list = new List<Gift>();
            Gift model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Gift_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new Gift();
                    model.GiftId= Convert.ToInt32(dr["GiftId"]);
                    if (DBNull.Value!=dr["GiftName"])
                        model.GiftName = dr["GiftName"].ToString();
                    if (DBNull.Value!=dr["GiftDesc"])
                        model.GiftDesc = dr["GiftDesc"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["GiftType"])
                        model.GiftType= Convert.ToInt32(dr["GiftType"]);
                    if (DBNull.Value!=dr["StockNumber"])
                        model.StockNumber= Convert.ToInt32(dr["StockNumber"]);
                    if (DBNull.Value!=dr["AlreadyIssuedNumber"])
                        model.AlreadyIssuedNumber= Convert.ToInt32(dr["AlreadyIssuedNumber"]);
                    if (DBNull.Value!=dr["BeingIssuedNumber"])
                        model.BeingIssuedNumber= Convert.ToInt32(dr["BeingIssuedNumber"]);
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["NeedCoin"])
                        model.NeedCoin= Convert.ToDecimal(dr["NeedCoin"]);
                    if (DBNull.Value!=dr["LimitNumber"])
                        model.LimitNumber= Convert.ToInt32(dr["LimitNumber"]);
                    if (DBNull.Value!=dr["ClickCount"])
                        model.ClickCount= Convert.ToInt32(dr["ClickCount"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
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
        /// <returns>Gift实体类对象</returns>
        public List<Gift> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<Gift> list = new List<Gift>();
            Gift model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Gift_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new Gift();
                    model.GiftId= Convert.ToInt32(dr["GiftId"]);
                    if (DBNull.Value!=dr["GiftName"])
                        model.GiftName = dr["GiftName"].ToString();
                    if (DBNull.Value!=dr["GiftDesc"])
                        model.GiftDesc = dr["GiftDesc"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["GiftType"])
                        model.GiftType= Convert.ToInt32(dr["GiftType"]);
                    if (DBNull.Value!=dr["StockNumber"])
                        model.StockNumber= Convert.ToInt32(dr["StockNumber"]);
                    if (DBNull.Value!=dr["AlreadyIssuedNumber"])
                        model.AlreadyIssuedNumber= Convert.ToInt32(dr["AlreadyIssuedNumber"]);
                    if (DBNull.Value!=dr["BeingIssuedNumber"])
                        model.BeingIssuedNumber= Convert.ToInt32(dr["BeingIssuedNumber"]);
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["NeedCoin"])
                        model.NeedCoin= Convert.ToDecimal(dr["NeedCoin"]);
                    if (DBNull.Value!=dr["LimitNumber"])
                        model.LimitNumber= Convert.ToInt32(dr["LimitNumber"]);
                    if (DBNull.Value!=dr["ClickCount"])
                        model.ClickCount= Convert.ToInt32(dr["ClickCount"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
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

