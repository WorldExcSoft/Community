using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class ProductionDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Production">Production实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(Production model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ProductionName",model.ProductionName),
                new SqlParameter ("@ProductionDesc",model.ProductionDesc),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@AuthorInfo",model.AuthorInfo),
                new SqlParameter ("@ProductionTypeId",model.ProductionTypeId),
                new SqlParameter ("@AssistCount",model.AssistCount),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@ClickCount",model.ClickCount),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Status",model.Status)
            };
           return DBHelper.ExecuteNonQuery("Production_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Production">Production实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(Production model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ProductionName",model.ProductionName),
                new SqlParameter ("@ProductionDesc",model.ProductionDesc),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@AuthorInfo",model.AuthorInfo),
                new SqlParameter ("@ProductionTypeId",model.ProductionTypeId),
                new SqlParameter ("@AssistCount",model.AssistCount),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@ClickCount",model.ClickCount),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Status",model.Status)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("Production_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Production">Production实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(Production model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ProductionId",model.ProductionId),
                new SqlParameter ("@ProductionName",model.ProductionName),
                new SqlParameter ("@ProductionDesc",model.ProductionDesc),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@AuthorInfo",model.AuthorInfo),
                new SqlParameter ("@ProductionTypeId",model.ProductionTypeId),
                new SqlParameter ("@AssistCount",model.AssistCount),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@ClickCount",model.ClickCount),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Status",model.Status)
            };
           return DBHelper.ExecuteNonQuery("Production_Change",param);
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
                new SqlParameter ("@ProductionId",Id)
            };
           return DBHelper.ExecuteNonQuery ("Production_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("Production_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<Production> SelectAll()
        {
            List<Production> list = new List<Production>();
            Production model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Production_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new Production();
                    model.ProductionId= Convert.ToInt32(dr["ProductionId"]);
                    if (DBNull.Value!=dr["ProductionName"])
                        model.ProductionName = dr["ProductionName"].ToString();
                    if (DBNull.Value!=dr["ProductionDesc"])
                        model.ProductionDesc = dr["ProductionDesc"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value!=dr["AuthorInfo"])
                        model.AuthorInfo = dr["AuthorInfo"].ToString();
                    if (DBNull.Value!=dr["ProductionTypeId"])
                        model.ProductionTypeId= Convert.ToInt32(dr["ProductionTypeId"]);
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
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
        /// <returns>Production实体类对象</returns>
        public Production SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ProductionId",Id)
            };
            Production model = new Production();
            using (SqlDataReader dr = DBHelper.RunProcedure("Production_SelectById", param))
            {
                if (dr.Read())
                {
                    model.ProductionId= Convert.ToInt32(dr["ProductionId"]);
                    if (DBNull.Value!=dr["ProductionName"])
                        model.ProductionName = dr["ProductionName"].ToString();
                    if (DBNull.Value!=dr["ProductionDesc"])
                        model.ProductionDesc = dr["ProductionDesc"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value!=dr["AuthorInfo"])
                        model.AuthorInfo = dr["AuthorInfo"].ToString();
                    if (DBNull.Value!=dr["ProductionTypeId"])
                        model.ProductionTypeId= Convert.ToInt32(dr["ProductionTypeId"]);
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
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
        /// <returns>Production实体类对象</returns>
        public List<Production> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<Production> list = new List<Production>();
            Production model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Production_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new Production();
                    model.ProductionId= Convert.ToInt32(dr["ProductionId"]);
                    if (DBNull.Value!=dr["ProductionName"])
                        model.ProductionName = dr["ProductionName"].ToString();
                    if (DBNull.Value!=dr["ProductionDesc"])
                        model.ProductionDesc = dr["ProductionDesc"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value!=dr["AuthorInfo"])
                        model.AuthorInfo = dr["AuthorInfo"].ToString();
                    if (DBNull.Value!=dr["ProductionTypeId"])
                        model.ProductionTypeId= Convert.ToInt32(dr["ProductionTypeId"]);
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
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
        /// <returns>Production实体类对象</returns>
        public List<Production> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<Production> list = new List<Production>();
            Production model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Production_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new Production();
                    model.ProductionId= Convert.ToInt32(dr["ProductionId"]);
                    if (DBNull.Value!=dr["ProductionName"])
                        model.ProductionName = dr["ProductionName"].ToString();
                    if (DBNull.Value!=dr["ProductionDesc"])
                        model.ProductionDesc = dr["ProductionDesc"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value!=dr["AuthorInfo"])
                        model.AuthorInfo = dr["AuthorInfo"].ToString();
                    if (DBNull.Value!=dr["ProductionTypeId"])
                        model.ProductionTypeId= Convert.ToInt32(dr["ProductionTypeId"]);
                    if (DBNull.Value!=dr["AssistCount"])
                        model.AssistCount= Convert.ToInt32(dr["AssistCount"]);
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
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

