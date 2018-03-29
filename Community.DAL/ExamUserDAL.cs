using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class ExamUserDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ExamUser">ExamUser实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(ExamUser model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamId",model.ExamId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("ExamUser_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ExamUser">ExamUser实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(ExamUser model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamId",model.ExamId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("ExamUser_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ExamUser">ExamUser实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(ExamUser model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamUserId",model.ExamUserId),
                new SqlParameter ("@ExamId",model.ExamId),
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@IsDelete",model.IsDelete)
            };
           return DBHelper.ExecuteNonQuery("ExamUser_Change",param);
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
                new SqlParameter ("@ExamUserId",Id)
            };
           return DBHelper.ExecuteNonQuery ("ExamUser_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("ExamUser_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<ExamUser> SelectAll()
        {
            List<ExamUser> list = new List<ExamUser>();
            ExamUser model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ExamUser_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new ExamUser();
                    model.ExamUserId= Convert.ToInt32(dr["ExamUserId"]);
                    model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
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
        /// <returns>ExamUser实体类对象</returns>
        public ExamUser SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamUserId",Id)
            };
            ExamUser model = new ExamUser();
            using (SqlDataReader dr = DBHelper.RunProcedure("ExamUser_SelectById", param))
            {
                if (dr.Read())
                {
                    model.ExamUserId= Convert.ToInt32(dr["ExamUserId"]);
                    model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>ExamUser实体类对象</returns>
        public List<ExamUser> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<ExamUser> list = new List<ExamUser>();
            ExamUser model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ExamUser_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new ExamUser();
                    model.ExamUserId= Convert.ToInt32(dr["ExamUserId"]);
                    model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
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
        /// <returns>ExamUser实体类对象</returns>
        public List<ExamUser> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<ExamUser> list = new List<ExamUser>();
            ExamUser model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("ExamUser_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new ExamUser();
                    model.ExamUserId= Convert.ToInt32(dr["ExamUserId"]);
                    model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    model.UserId= Convert.ToInt32(dr["UserId"]);
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

