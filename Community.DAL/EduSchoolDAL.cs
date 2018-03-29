using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class EduSchoolDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="EduSchool">EduSchool实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(EduSchool model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@EduSchoolName",model.EduSchoolName),
                new SqlParameter ("@SchoolDesc",model.SchoolDesc),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@SchoolUrl",model.SchoolUrl),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@OrderIndex",model.OrderIndex)
            };
           return DBHelper.ExecuteNonQuery("EduSchool_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="EduSchool">EduSchool实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(EduSchool model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@EduSchoolName",model.EduSchoolName),
                new SqlParameter ("@SchoolDesc",model.SchoolDesc),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@SchoolUrl",model.SchoolUrl),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@OrderIndex",model.OrderIndex)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("EduSchool_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="EduSchool">EduSchool实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(EduSchool model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@EduSchoolId",model.EduSchoolId),
                new SqlParameter ("@EduSchoolName",model.EduSchoolName),
                new SqlParameter ("@SchoolDesc",model.SchoolDesc),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@SchoolUrl",model.SchoolUrl),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@OrderIndex",model.OrderIndex)
            };
           return DBHelper.ExecuteNonQuery("EduSchool_Change",param);
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
                new SqlParameter ("@EduSchoolId",Id)
            };
           return DBHelper.ExecuteNonQuery ("EduSchool_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("EduSchool_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<EduSchool> SelectAll()
        {
            List<EduSchool> list = new List<EduSchool>();
            EduSchool model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("EduSchool_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new EduSchool();
                    model.EduSchoolId= Convert.ToInt32(dr["EduSchoolId"]);
                    if (DBNull.Value!=dr["EduSchoolName"])
                        model.EduSchoolName = dr["EduSchoolName"].ToString();
                    if (DBNull.Value!=dr["SchoolDesc"])
                        model.SchoolDesc = dr["SchoolDesc"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["SchoolUrl"])
                        model.SchoolUrl = dr["SchoolUrl"].ToString();
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
        /// <returns>EduSchool实体类对象</returns>
        public EduSchool SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@EduSchoolId",Id)
            };
            EduSchool model = new EduSchool();
            using (SqlDataReader dr = DBHelper.RunProcedure("EduSchool_SelectById", param))
            {
                if (dr.Read())
                {
                    model.EduSchoolId= Convert.ToInt32(dr["EduSchoolId"]);
                    if (DBNull.Value!=dr["EduSchoolName"])
                        model.EduSchoolName = dr["EduSchoolName"].ToString();
                    if (DBNull.Value!=dr["SchoolDesc"])
                        model.SchoolDesc = dr["SchoolDesc"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["SchoolUrl"])
                        model.SchoolUrl = dr["SchoolUrl"].ToString();
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
        /// <returns>EduSchool实体类对象</returns>
        public List<EduSchool> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<EduSchool> list = new List<EduSchool>();
            EduSchool model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("EduSchool_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new EduSchool();
                    model.EduSchoolId= Convert.ToInt32(dr["EduSchoolId"]);
                    if (DBNull.Value!=dr["EduSchoolName"])
                        model.EduSchoolName = dr["EduSchoolName"].ToString();
                    if (DBNull.Value!=dr["SchoolDesc"])
                        model.SchoolDesc = dr["SchoolDesc"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["SchoolUrl"])
                        model.SchoolUrl = dr["SchoolUrl"].ToString();
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
        /// <returns>EduSchool实体类对象</returns>
        public List<EduSchool> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<EduSchool> list = new List<EduSchool>();
            EduSchool model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("EduSchool_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new EduSchool();
                    model.EduSchoolId= Convert.ToInt32(dr["EduSchoolId"]);
                    if (DBNull.Value!=dr["EduSchoolName"])
                        model.EduSchoolName = dr["EduSchoolName"].ToString();
                    if (DBNull.Value!=dr["SchoolDesc"])
                        model.SchoolDesc = dr["SchoolDesc"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["SchoolUrl"])
                        model.SchoolUrl = dr["SchoolUrl"].ToString();
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

