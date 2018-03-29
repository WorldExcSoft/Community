using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class ProductionTypeDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ProductionType">ProductionType实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(ProductionType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ProductionTypeName",model.ProductionTypeName),
                new SqlParameter ("@Decription",model.Decription),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("ProductionType_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ProductionType">ProductionType实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(ProductionType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ProductionTypeName",model.ProductionTypeName),
                new SqlParameter ("@Decription",model.Decription),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("ProductionType_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ProductionType">ProductionType实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(ProductionType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ProductionTypeId",model.ProductionTypeId),
                new SqlParameter ("@ProductionTypeName",model.ProductionTypeName),
                new SqlParameter ("@Decription",model.Decription),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("ProductionType_Change",param);
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
                new SqlParameter ("@ProductionTypeId",Id)
            };
           return DBHelper.ExecuteNonQuery ("ProductionType_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("ProductionType_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<ProductionType> SelectAll()
        {
            List<ProductionType> list = new List<ProductionType>();
            ProductionType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ProductionType_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new ProductionType();
                    model.ProductionTypeId = Convert.ToInt32(dr["ProductionTypeId"]);
                    if (DBNull.Value != dr["ProductionTypeName"])
                        model.ProductionTypeName = dr["ProductionTypeName"].ToString();
                    if (DBNull.Value!=dr["Decription"])
                        model.Decription = dr["Decription"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
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
        /// <returns>ProductionType实体类对象</returns>
        public ProductionType SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ProductionTypeId",Id)
            };
            ProductionType model = new ProductionType();
            using (SqlDataReader dr = DBHelper.RunProcedure("ProductionType_SelectById", param))
            {
                if (dr.Read())
                {
                    model.ProductionTypeId = Convert.ToInt32(dr["ProductionTypeId"]);
                    if (DBNull.Value != dr["ProductionTypeName"])
                        model.ProductionTypeName = dr["ProductionTypeName"].ToString();
                    if (DBNull.Value!=dr["Decription"])
                        model.Decription = dr["Decription"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
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
        /// <returns>ProductionType实体类对象</returns>
        public List<ProductionType> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<ProductionType> list = new List<ProductionType>();
            ProductionType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ProductionType_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new ProductionType();
                    model.ProductionTypeId = Convert.ToInt32(dr["ProductionTypeId"]);
                    if (DBNull.Value != dr["ProductionTypeName"])
                        model.ProductionTypeName = dr["ProductionTypeName"].ToString();
                    if (DBNull.Value!=dr["Decription"])
                        model.Decription = dr["Decription"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
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
        /// <returns>ProductionType实体类对象</returns>
        public List<ProductionType> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<ProductionType> list = new List<ProductionType>();
            ProductionType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ProductionType_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new ProductionType();
                    model.ProductionTypeId = Convert.ToInt32(dr["ProductionTypeId"]);
                    if (DBNull.Value != dr["ProductionTypeName"])
                        model.ProductionTypeName = dr["ProductionTypeName"].ToString();
                    if (DBNull.Value!=dr["Decription"])
                        model.Decription = dr["Decription"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
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

