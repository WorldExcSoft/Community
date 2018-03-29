using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class AssistConstraintDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="AssistConstraint">AssistConstraint实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(AssistConstraint model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ConstraintType",model.ConstraintType),
                new SqlParameter ("@ConstraintNum",model.ConstraintNum),
                new SqlParameter ("@ObjId",model.ObjId),
                new SqlParameter ("@ConstraintTimeLength",model.ConstraintTimeLength),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@TimeUnit",model.TimeUnit)
            };
           return DBHelper.ExecuteNonQuery("AssistConstraint_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="AssistConstraint">AssistConstraint实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(AssistConstraint model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ConstraintType",model.ConstraintType),
                new SqlParameter ("@ConstraintNum",model.ConstraintNum),
                new SqlParameter ("@ObjId",model.ObjId),
                new SqlParameter ("@ConstraintTimeLength",model.ConstraintTimeLength),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@TimeUnit",model.TimeUnit)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("AssistConstraint_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="AssistConstraint">AssistConstraint实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(AssistConstraint model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ConstraintId",model.ConstraintId),
                new SqlParameter ("@ConstraintType",model.ConstraintType),
                new SqlParameter ("@ConstraintNum",model.ConstraintNum),
                new SqlParameter ("@ObjId",model.ObjId),
                new SqlParameter ("@ConstraintTimeLength",model.ConstraintTimeLength),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@TimeUnit",model.TimeUnit)
            };
           return DBHelper.ExecuteNonQuery("AssistConstraint_Change",param);
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
                new SqlParameter ("@ConstraintId",Id)
            };
           return DBHelper.ExecuteNonQuery ("AssistConstraint_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("AssistConstraint_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<AssistConstraint> SelectAll()
        {
            List<AssistConstraint> list = new List<AssistConstraint>();
            AssistConstraint model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("AssistConstraint_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new AssistConstraint();
                    model.ConstraintId= Convert.ToInt32(dr["ConstraintId"]);
                    model.ConstraintType= Convert.ToInt32(dr["ConstraintType"]);
                    model.ConstraintNum= Convert.ToInt32(dr["ConstraintNum"]);
                    model.ObjId= Convert.ToInt32(dr["ObjId"]);
                    model.ConstraintTimeLength= Convert.ToInt32(dr["ConstraintTimeLength"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    model.TimeUnit= Convert.ToInt32(dr["TimeUnit"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>AssistConstraint实体类对象</returns>
        public AssistConstraint SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ConstraintId",Id)
            };
            AssistConstraint model = new AssistConstraint();
            using (SqlDataReader dr = DBHelper.RunProcedure("AssistConstraint_SelectById", param))
            {
                if (dr.Read())
                {
                    model.ConstraintId= Convert.ToInt32(dr["ConstraintId"]);
                    model.ConstraintType= Convert.ToInt32(dr["ConstraintType"]);
                    model.ConstraintNum= Convert.ToInt32(dr["ConstraintNum"]);
                    model.ObjId= Convert.ToInt32(dr["ObjId"]);
                    model.ConstraintTimeLength= Convert.ToInt32(dr["ConstraintTimeLength"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    model.TimeUnit= Convert.ToInt32(dr["TimeUnit"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>AssistConstraint实体类对象</returns>
        public List<AssistConstraint> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<AssistConstraint> list = new List<AssistConstraint>();
            AssistConstraint model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("AssistConstraint_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new AssistConstraint();
                    model.ConstraintId= Convert.ToInt32(dr["ConstraintId"]);
                    model.ConstraintType= Convert.ToInt32(dr["ConstraintType"]);
                    model.ConstraintNum= Convert.ToInt32(dr["ConstraintNum"]);
                    model.ObjId= Convert.ToInt32(dr["ObjId"]);
                    model.ConstraintTimeLength= Convert.ToInt32(dr["ConstraintTimeLength"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    model.TimeUnit= Convert.ToInt32(dr["TimeUnit"]);
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
        /// <returns>AssistConstraint实体类对象</returns>
        public List<AssistConstraint> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<AssistConstraint> list = new List<AssistConstraint>();
            AssistConstraint model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("AssistConstraint_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new AssistConstraint();
                    model.ConstraintId= Convert.ToInt32(dr["ConstraintId"]);
                    model.ConstraintType= Convert.ToInt32(dr["ConstraintType"]);
                    model.ConstraintNum= Convert.ToInt32(dr["ConstraintNum"]);
                    model.ObjId= Convert.ToInt32(dr["ObjId"]);
                    model.ConstraintTimeLength= Convert.ToInt32(dr["ConstraintTimeLength"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    model.TimeUnit= Convert.ToInt32(dr["TimeUnit"]);
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

