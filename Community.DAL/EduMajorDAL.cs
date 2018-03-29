using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class EduMajorDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="EduMajor">EduMajor实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(EduMajor model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@EduMajorName",model.EduMajorName),
                new SqlParameter ("@MajorDesc",model.MajorDesc),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@OrderIndex",model.OrderIndex)
            };
           return DBHelper.ExecuteNonQuery("EduMajor_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="EduMajor">EduMajor实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(EduMajor model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@EduMajorName",model.EduMajorName),
                new SqlParameter ("@MajorDesc",model.MajorDesc),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@OrderIndex",model.OrderIndex)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("EduMajor_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="EduMajor">EduMajor实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(EduMajor model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@EduMajorId",model.EduMajorId),
                new SqlParameter ("@EduMajorName",model.EduMajorName),
                new SqlParameter ("@MajorDesc",model.MajorDesc),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@OrderIndex",model.OrderIndex)
            };
           return DBHelper.ExecuteNonQuery("EduMajor_Change",param);
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
                new SqlParameter ("@EduMajorId",Id)
            };
           return DBHelper.ExecuteNonQuery ("EduMajor_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("EduMajor_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<EduMajor> SelectAll()
        {
            List<EduMajor> list = new List<EduMajor>();
            EduMajor model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("EduMajor_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new EduMajor();
                    model.EduMajorId= Convert.ToInt32(dr["EduMajorId"]);
                    if (DBNull.Value!=dr["EduMajorName"])
                        model.EduMajorName = dr["EduMajorName"].ToString();
                    if (DBNull.Value!=dr["MajorDesc"])
                        model.MajorDesc = dr["MajorDesc"].ToString();
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>EduMajor实体类对象</returns>
        public EduMajor SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@EduMajorId",Id)
            };
            EduMajor model = new EduMajor();
            using (SqlDataReader dr = DBHelper.RunProcedure("EduMajor_SelectById", param))
            {
                if (dr.Read())
                {
                    model.EduMajorId= Convert.ToInt32(dr["EduMajorId"]);
                    if (DBNull.Value!=dr["EduMajorName"])
                        model.EduMajorName = dr["EduMajorName"].ToString();
                    if (DBNull.Value!=dr["MajorDesc"])
                        model.MajorDesc = dr["MajorDesc"].ToString();
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>EduMajor实体类对象</returns>
        public List<EduMajor> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<EduMajor> list = new List<EduMajor>();
            EduMajor model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("EduMajor_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new EduMajor();
                    model.EduMajorId= Convert.ToInt32(dr["EduMajorId"]);
                    if (DBNull.Value!=dr["EduMajorName"])
                        model.EduMajorName = dr["EduMajorName"].ToString();
                    if (DBNull.Value!=dr["MajorDesc"])
                        model.MajorDesc = dr["MajorDesc"].ToString();
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
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
        /// <returns>EduMajor实体类对象</returns>
        public List<EduMajor> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<EduMajor> list = new List<EduMajor>();
            EduMajor model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("EduMajor_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new EduMajor();
                    model.EduMajorId= Convert.ToInt32(dr["EduMajorId"]);
                    if (DBNull.Value!=dr["EduMajorName"])
                        model.EduMajorName = dr["EduMajorName"].ToString();
                    if (DBNull.Value!=dr["MajorDesc"])
                        model.MajorDesc = dr["MajorDesc"].ToString();
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
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

