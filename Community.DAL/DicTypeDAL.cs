using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class DicTypeDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="DicType">DicType实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(DicType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@DicTypeName",model.DicTypeName),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@IsSystem",model.IsSystem),
                new SqlParameter ("@ObjType",model.ObjType)
            };
           return DBHelper.ExecuteNonQuery("DicType_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="DicType">DicType实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(DicType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@DicTypeName",model.DicTypeName),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@IsSystem",model.IsSystem),
                new SqlParameter ("@ObjType",model.ObjType)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("DicType_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="DicType">DicType实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(DicType model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@DicTypeId",model.DicTypeId),
                new SqlParameter ("@DicTypeName",model.DicTypeName),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@IsSystem",model.IsSystem),
                new SqlParameter ("@ObjType",model.ObjType)
            };
           return DBHelper.ExecuteNonQuery("DicType_Change",param);
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
                new SqlParameter ("@DicTypeId",Id)
            };
           return DBHelper.ExecuteNonQuery ("DicType_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("DicType_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<DicType> SelectAll()
        {
            List<DicType> list = new List<DicType>();
            DicType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("DicType_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new DicType();
                    if (DBNull.Value!=dr["DicTypeId"])
                        model.DicTypeId= Convert.ToInt32(dr["DicTypeId"]);
                    if (DBNull.Value!=dr["DicTypeName"])
                        model.DicTypeName = dr["DicTypeName"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["IsSystem"])
                        model.IsSystem= Convert.ToInt32(dr["IsSystem"]);
                    if (DBNull.Value!=dr["ObjType"])
                        model.ObjType= Convert.ToInt32(dr["ObjType"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>DicType实体类对象</returns>
        public DicType SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@DicTypeId",Id)
            };
            DicType model = new DicType();
            using (SqlDataReader dr = DBHelper.RunProcedure("DicType_SelectById", param))
            {
                if (dr.Read())
                {
                    if (DBNull.Value!=dr["DicTypeId"])
                        model.DicTypeId= Convert.ToInt32(dr["DicTypeId"]);
                    if (DBNull.Value!=dr["DicTypeName"])
                        model.DicTypeName = dr["DicTypeName"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["IsSystem"])
                        model.IsSystem= Convert.ToInt32(dr["IsSystem"]);
                    if (DBNull.Value!=dr["ObjType"])
                        model.ObjType= Convert.ToInt32(dr["ObjType"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>DicType实体类对象</returns>
        public List<DicType> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<DicType> list = new List<DicType>();
            DicType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("DicType_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new DicType();
                    if (DBNull.Value!=dr["DicTypeId"])
                        model.DicTypeId= Convert.ToInt32(dr["DicTypeId"]);
                    if (DBNull.Value!=dr["DicTypeName"])
                        model.DicTypeName = dr["DicTypeName"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["IsSystem"])
                        model.IsSystem= Convert.ToInt32(dr["IsSystem"]);
                    if (DBNull.Value!=dr["ObjType"])
                        model.ObjType= Convert.ToInt32(dr["ObjType"]);
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
        /// <returns>DicType实体类对象</returns>
        public List<DicType> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<DicType> list = new List<DicType>();
            DicType model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("DicType_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new DicType();
                    if (DBNull.Value!=dr["DicTypeId"])
                        model.DicTypeId= Convert.ToInt32(dr["DicTypeId"]);
                    if (DBNull.Value!=dr["DicTypeName"])
                        model.DicTypeName = dr["DicTypeName"].ToString();
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["IsSystem"])
                        model.IsSystem= Convert.ToInt32(dr["IsSystem"]);
                    if (DBNull.Value!=dr["ObjType"])
                        model.ObjType= Convert.ToInt32(dr["ObjType"]);
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

