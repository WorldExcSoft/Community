using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class PaperTypeDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="PaperType">PaperType实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(PaperType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PaperTypeName",model.PaperTypeName),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("PaperType_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="PaperType">PaperType实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(PaperType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PaperTypeName",model.PaperTypeName),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("PaperType_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="PaperType">PaperType实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(PaperType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PaperTypeId",model.PaperTypeId),
                new SqlParameter ("@PaperTypeName",model.PaperTypeName),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("PaperType_Change",param);
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
                new SqlParameter ("@PaperTypeId",Id)
            };
           return DBHelper.ExecuteNonQuery ("PaperType_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("PaperType_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<PaperType> SelectAll()
        {
            List<PaperType> list = new List<PaperType>();
            PaperType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("PaperType_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new PaperType();
                    model.PaperTypeId= Convert.ToInt32(dr["PaperTypeId"]);
                    if (DBNull.Value != dr["PaperTypeName"])
                        model.PaperTypeName = dr["PaperTypeName"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
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
        /// <returns>PaperType实体类对象</returns>
        public PaperType SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@PaperTypeId",Id)
            };
            PaperType model = new PaperType();
            using (SqlDataReader dr = DBHelper.RunProcedure("PaperType_SelectById", param))
            {
                if (dr.Read())
                {
                    model.PaperTypeId= Convert.ToInt32(dr["PaperTypeId"]);
                    if (DBNull.Value != dr["PaperTypeName"])
                        model.PaperTypeName = dr["PaperTypeName"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>PaperType实体类对象</returns>
        public List<PaperType> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<PaperType> list = new List<PaperType>();
            PaperType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("PaperType_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new PaperType();
                    model.PaperTypeId= Convert.ToInt32(dr["PaperTypeId"]);
                    if (DBNull.Value != dr["PaperTypeName"])
                        model.PaperTypeName = dr["PaperTypeName"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
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
        /// <returns>PaperType实体类对象</returns>
        public List<PaperType> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<PaperType> list = new List<PaperType>();
            PaperType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("PaperType_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new PaperType();
                    model.PaperTypeId= Convert.ToInt32(dr["PaperTypeId"]);
                    if (DBNull.Value != dr["PaperTypeName"])
                        model.PaperTypeName = dr["PaperTypeName"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
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

