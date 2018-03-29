using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class ExamDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Exam">Exam实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(Exam model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamName",model.ExamName),
                new SqlParameter ("@ExamType",model.ExamType),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@LastUpdateDate",model.LastUpdateDate),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@TimeLimit",model.TimeLimit),
                new SqlParameter ("@IsUserLimit",model.IsUserLimit),
                new SqlParameter ("@CountLimit",model.CountLimit),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@StartDate",model.StartDate),
                new SqlParameter ("@EndDate",model.EndDate),
                new SqlParameter ("@IsShowAnswer",model.IsShowAnswer),
                new SqlParameter ("@IsShowAnswerDesc",model.IsShowAnswerDesc),
                new SqlParameter ("@Credit",model.Credit),
                new SqlParameter ("@Coin",model.Coin),
                new SqlParameter ("@IsRandomTheme",model.IsRandomTheme),
                new SqlParameter ("@IsRandomPaper",model.IsRandomPaper),
                new SqlParameter ("@PassPercent",model.PassPercent),
                new SqlParameter ("@IsCourseExam",model.IsCourseExam),
                new SqlParameter ("@ExamDesc",model.ExamDesc),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@ExamRule",model.ExamRule)
            };
           return DBHelper.ExecuteNonQuery("Exam_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Exam">Exam实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(Exam model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamName",model.ExamName),
                new SqlParameter ("@ExamType",model.ExamType),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@LastUpdateDate",model.LastUpdateDate),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@TimeLimit",model.TimeLimit),
                new SqlParameter ("@IsUserLimit",model.IsUserLimit),
                new SqlParameter ("@CountLimit",model.CountLimit),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@StartDate",model.StartDate),
                new SqlParameter ("@EndDate",model.EndDate),
                new SqlParameter ("@IsShowAnswer",model.IsShowAnswer),
                new SqlParameter ("@IsShowAnswerDesc",model.IsShowAnswerDesc),
                new SqlParameter ("@Credit",model.Credit),
                new SqlParameter ("@Coin",model.Coin),
                new SqlParameter ("@IsRandomTheme",model.IsRandomTheme),
                new SqlParameter ("@IsRandomPaper",model.IsRandomPaper),
                new SqlParameter ("@PassPercent",model.PassPercent),
                new SqlParameter ("@IsCourseExam",model.IsCourseExam),
                new SqlParameter ("@ExamDesc",model.ExamDesc),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@ExamRule",model.ExamRule)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("Exam_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Exam">Exam实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(Exam model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamId",model.ExamId),
                new SqlParameter ("@ExamName",model.ExamName),
                new SqlParameter ("@ExamType",model.ExamType),
                new SqlParameter ("@CreateDate",model.CreateDate),
                new SqlParameter ("@LastUpdateDate",model.LastUpdateDate),
                new SqlParameter ("@AuthorName",model.AuthorName),
                new SqlParameter ("@CreateUserId",model.CreateUserId),
                new SqlParameter ("@TimeLimit",model.TimeLimit),
                new SqlParameter ("@IsUserLimit",model.IsUserLimit),
                new SqlParameter ("@CountLimit",model.CountLimit),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@StartDate",model.StartDate),
                new SqlParameter ("@EndDate",model.EndDate),
                new SqlParameter ("@IsShowAnswer",model.IsShowAnswer),
                new SqlParameter ("@IsShowAnswerDesc",model.IsShowAnswerDesc),
                new SqlParameter ("@Credit",model.Credit),
                new SqlParameter ("@Coin",model.Coin),
                new SqlParameter ("@IsRandomTheme",model.IsRandomTheme),
                new SqlParameter ("@IsRandomPaper",model.IsRandomPaper),
                new SqlParameter ("@PassPercent",model.PassPercent),
                new SqlParameter ("@IsCourseExam",model.IsCourseExam),
                new SqlParameter ("@ExamDesc",model.ExamDesc),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@ExamRule",model.ExamRule)
            };
           return DBHelper.ExecuteNonQuery("Exam_Change",param);
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
                new SqlParameter ("@ExamId",Id)
            };
           return DBHelper.ExecuteNonQuery ("Exam_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("Exam_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<Exam> SelectAll()
        {
            List<Exam> list = new List<Exam>();
            Exam model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Exam_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new Exam();
                    model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    model.ExamName = dr["ExamName"].ToString();
                    model.ExamType= Convert.ToInt32(dr["ExamType"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastUpdateDate"])
                        model.LastUpdateDate= Convert.ToDateTime(dr["LastUpdateDate"]);
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["TimeLimit"])
                        model.TimeLimit= Convert.ToInt32(dr["TimeLimit"]);
                    if (DBNull.Value!=dr["IsUserLimit"])
                        model.IsUserLimit= Convert.ToBoolean(dr["IsUserLimit"]);
                    if (DBNull.Value!=dr["CountLimit"])
                        model.CountLimit= Convert.ToInt32(dr["CountLimit"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["StartDate"])
                        model.StartDate= Convert.ToDateTime(dr["StartDate"]);
                    if (DBNull.Value!=dr["EndDate"])
                        model.EndDate= Convert.ToDateTime(dr["EndDate"]);
                    if (DBNull.Value!=dr["IsShowAnswer"])
                        model.IsShowAnswer= Convert.ToInt32(dr["IsShowAnswer"]);
                    if (DBNull.Value!=dr["IsShowAnswerDesc"])
                        model.IsShowAnswerDesc= Convert.ToInt32(dr["IsShowAnswerDesc"]);
                    if (DBNull.Value!=dr["Credit"])
                        model.Credit= Convert.ToDecimal(dr["Credit"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
                    if (DBNull.Value!=dr["IsRandomTheme"])
                        model.IsRandomTheme= Convert.ToBoolean(dr["IsRandomTheme"]);
                    if (DBNull.Value!=dr["IsRandomPaper"])
                        model.IsRandomPaper= Convert.ToBoolean(dr["IsRandomPaper"]);
                    if (DBNull.Value!=dr["PassPercent"])
                        model.PassPercent= Convert.ToInt32(dr["PassPercent"]);
                    if (DBNull.Value!=dr["IsCourseExam"])
                        model.IsCourseExam= Convert.ToBoolean(dr["IsCourseExam"]);
                    if (DBNull.Value!=dr["ExamDesc"])
                        model.ExamDesc = dr["ExamDesc"].ToString();
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["ExamRule"])
                        model.ExamRule = dr["ExamRule"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>Exam实体类对象</returns>
        public Exam SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ExamId",Id)
            };
            Exam model = new Exam();
            using (SqlDataReader dr = DBHelper.RunProcedure("Exam_SelectById", param))
            {
                if (dr.Read())
                {
                    model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    model.ExamName = dr["ExamName"].ToString();
                    model.ExamType= Convert.ToInt32(dr["ExamType"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastUpdateDate"])
                        model.LastUpdateDate= Convert.ToDateTime(dr["LastUpdateDate"]);
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["TimeLimit"])
                        model.TimeLimit= Convert.ToInt32(dr["TimeLimit"]);
                    if (DBNull.Value!=dr["IsUserLimit"])
                        model.IsUserLimit= Convert.ToBoolean(dr["IsUserLimit"]);
                    if (DBNull.Value!=dr["CountLimit"])
                        model.CountLimit= Convert.ToInt32(dr["CountLimit"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["StartDate"])
                        model.StartDate= Convert.ToDateTime(dr["StartDate"]);
                    if (DBNull.Value!=dr["EndDate"])
                        model.EndDate= Convert.ToDateTime(dr["EndDate"]);
                    if (DBNull.Value!=dr["IsShowAnswer"])
                        model.IsShowAnswer= Convert.ToInt32(dr["IsShowAnswer"]);
                    if (DBNull.Value!=dr["IsShowAnswerDesc"])
                        model.IsShowAnswerDesc= Convert.ToInt32(dr["IsShowAnswerDesc"]);
                    if (DBNull.Value!=dr["Credit"])
                        model.Credit= Convert.ToDecimal(dr["Credit"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
                    if (DBNull.Value!=dr["IsRandomTheme"])
                        model.IsRandomTheme= Convert.ToBoolean(dr["IsRandomTheme"]);
                    if (DBNull.Value!=dr["IsRandomPaper"])
                        model.IsRandomPaper= Convert.ToBoolean(dr["IsRandomPaper"]);
                    if (DBNull.Value!=dr["PassPercent"])
                        model.PassPercent= Convert.ToInt32(dr["PassPercent"]);
                    if (DBNull.Value!=dr["IsCourseExam"])
                        model.IsCourseExam= Convert.ToBoolean(dr["IsCourseExam"]);
                    if (DBNull.Value!=dr["ExamDesc"])
                        model.ExamDesc = dr["ExamDesc"].ToString();
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["ExamRule"])
                        model.ExamRule = dr["ExamRule"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>Exam实体类对象</returns>
        public List<Exam> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<Exam> list = new List<Exam>();
            Exam model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Exam_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new Exam();
                    model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    model.ExamName = dr["ExamName"].ToString();
                    model.ExamType= Convert.ToInt32(dr["ExamType"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastUpdateDate"])
                        model.LastUpdateDate= Convert.ToDateTime(dr["LastUpdateDate"]);
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["TimeLimit"])
                        model.TimeLimit= Convert.ToInt32(dr["TimeLimit"]);
                    if (DBNull.Value!=dr["IsUserLimit"])
                        model.IsUserLimit= Convert.ToBoolean(dr["IsUserLimit"]);
                    if (DBNull.Value!=dr["CountLimit"])
                        model.CountLimit= Convert.ToInt32(dr["CountLimit"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["StartDate"])
                        model.StartDate= Convert.ToDateTime(dr["StartDate"]);
                    if (DBNull.Value!=dr["EndDate"])
                        model.EndDate= Convert.ToDateTime(dr["EndDate"]);
                    if (DBNull.Value!=dr["IsShowAnswer"])
                        model.IsShowAnswer= Convert.ToInt32(dr["IsShowAnswer"]);
                    if (DBNull.Value!=dr["IsShowAnswerDesc"])
                        model.IsShowAnswerDesc= Convert.ToInt32(dr["IsShowAnswerDesc"]);
                    if (DBNull.Value!=dr["Credit"])
                        model.Credit= Convert.ToDecimal(dr["Credit"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
                    if (DBNull.Value!=dr["IsRandomTheme"])
                        model.IsRandomTheme= Convert.ToBoolean(dr["IsRandomTheme"]);
                    if (DBNull.Value!=dr["IsRandomPaper"])
                        model.IsRandomPaper= Convert.ToBoolean(dr["IsRandomPaper"]);
                    if (DBNull.Value!=dr["PassPercent"])
                        model.PassPercent= Convert.ToInt32(dr["PassPercent"]);
                    if (DBNull.Value!=dr["IsCourseExam"])
                        model.IsCourseExam= Convert.ToBoolean(dr["IsCourseExam"]);
                    if (DBNull.Value!=dr["ExamDesc"])
                        model.ExamDesc = dr["ExamDesc"].ToString();
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["ExamRule"])
                        model.ExamRule = dr["ExamRule"].ToString();
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
        /// <returns>Exam实体类对象</returns>
        public List<Exam> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<Exam> list = new List<Exam>();
            Exam model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Exam_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new Exam();
                    model.ExamId= Convert.ToInt32(dr["ExamId"]);
                    model.ExamName = dr["ExamName"].ToString();
                    model.ExamType= Convert.ToInt32(dr["ExamType"]);
                    if (DBNull.Value!=dr["CreateDate"])
                        model.CreateDate= Convert.ToDateTime(dr["CreateDate"]);
                    if (DBNull.Value!=dr["LastUpdateDate"])
                        model.LastUpdateDate= Convert.ToDateTime(dr["LastUpdateDate"]);
                    if (DBNull.Value!=dr["AuthorName"])
                        model.AuthorName = dr["AuthorName"].ToString();
                    if (DBNull.Value!=dr["CreateUserId"])
                        model.CreateUserId= Convert.ToInt32(dr["CreateUserId"]);
                    if (DBNull.Value!=dr["TimeLimit"])
                        model.TimeLimit= Convert.ToInt32(dr["TimeLimit"]);
                    if (DBNull.Value!=dr["IsUserLimit"])
                        model.IsUserLimit= Convert.ToBoolean(dr["IsUserLimit"]);
                    if (DBNull.Value!=dr["CountLimit"])
                        model.CountLimit= Convert.ToInt32(dr["CountLimit"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["StartDate"])
                        model.StartDate= Convert.ToDateTime(dr["StartDate"]);
                    if (DBNull.Value!=dr["EndDate"])
                        model.EndDate= Convert.ToDateTime(dr["EndDate"]);
                    if (DBNull.Value!=dr["IsShowAnswer"])
                        model.IsShowAnswer= Convert.ToInt32(dr["IsShowAnswer"]);
                    if (DBNull.Value!=dr["IsShowAnswerDesc"])
                        model.IsShowAnswerDesc= Convert.ToInt32(dr["IsShowAnswerDesc"]);
                    if (DBNull.Value!=dr["Credit"])
                        model.Credit= Convert.ToDecimal(dr["Credit"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
                    if (DBNull.Value!=dr["IsRandomTheme"])
                        model.IsRandomTheme= Convert.ToBoolean(dr["IsRandomTheme"]);
                    if (DBNull.Value!=dr["IsRandomPaper"])
                        model.IsRandomPaper= Convert.ToBoolean(dr["IsRandomPaper"]);
                    if (DBNull.Value!=dr["PassPercent"])
                        model.PassPercent= Convert.ToInt32(dr["PassPercent"]);
                    if (DBNull.Value!=dr["IsCourseExam"])
                        model.IsCourseExam= Convert.ToBoolean(dr["IsCourseExam"]);
                    if (DBNull.Value!=dr["ExamDesc"])
                        model.ExamDesc = dr["ExamDesc"].ToString();
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["ExamRule"])
                        model.ExamRule = dr["ExamRule"].ToString();
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

