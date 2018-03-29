using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class ThemeTypeDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ThemeType">ThemeType实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(ThemeType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ThemeTypeName",model.ThemeTypeName),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@ParentId",model.ParentId)
            };
           return DBHelper.ExecuteNonQuery("ThemeType_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ThemeType">ThemeType实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(ThemeType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ThemeTypeName",model.ThemeTypeName),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@ParentId",model.ParentId)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("ThemeType_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ThemeType">ThemeType实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(ThemeType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ThemeTypeId",model.ThemeTypeId),
                new SqlParameter ("@ThemeTypeName",model.ThemeTypeName),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@ParentId",model.ParentId)
            };
           return DBHelper.ExecuteNonQuery("ThemeType_Change",param);
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
                new SqlParameter ("@ThemeTypeId",Id)
            };
           return DBHelper.ExecuteNonQuery ("ThemeType_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("ThemeType_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<ThemeType> SelectAll()
        {
            List<ThemeType> list = new List<ThemeType>();
            ThemeType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ThemeType_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new ThemeType();
                    model.ThemeTypeId= Convert.ToInt32(dr["ThemeTypeId"]);
                    if (DBNull.Value!=dr["ThemeTypeName"])
                        model.ThemeTypeName = dr["ThemeTypeName"].ToString();
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>ThemeType实体类对象</returns>
        public ThemeType SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ThemeTypeId",Id)
            };
            ThemeType model = new ThemeType();
            using (SqlDataReader dr = DBHelper.RunProcedure("ThemeType_SelectById", param))
            {
                if (dr.Read())
                {
                    model.ThemeTypeId= Convert.ToInt32(dr["ThemeTypeId"]);
                    if (DBNull.Value!=dr["ThemeTypeName"])
                        model.ThemeTypeName = dr["ThemeTypeName"].ToString();
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>ThemeType实体类对象</returns>
        public List<ThemeType> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<ThemeType> list = new List<ThemeType>();
            ThemeType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ThemeType_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new ThemeType();
                    model.ThemeTypeId= Convert.ToInt32(dr["ThemeTypeId"]);
                    if (DBNull.Value!=dr["ThemeTypeName"])
                        model.ThemeTypeName = dr["ThemeTypeName"].ToString();
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
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
        /// <returns>ThemeType实体类对象</returns>
        public List<ThemeType> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<ThemeType> list = new List<ThemeType>();
            ThemeType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ThemeType_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new ThemeType();
                    model.ThemeTypeId= Convert.ToInt32(dr["ThemeTypeId"]);
                    if (DBNull.Value!=dr["ThemeTypeName"])
                        model.ThemeTypeName = dr["ThemeTypeName"].ToString();
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
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

