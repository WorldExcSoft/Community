using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class UsersDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Users">Users实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(Users model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@UserType",model.UserType),
                new SqlParameter ("@UserAcount",model.UserAcount),
                new SqlParameter ("@UserPwd",model.UserPwd),
                new SqlParameter ("@Salt",model.Salt),
                new SqlParameter ("@UserName",model.UserName),
                new SqlParameter ("@NickName",model.NickName),
                new SqlParameter ("@Sex",model.Sex),
                new SqlParameter ("@BriDate",model.BriDate),
                new SqlParameter ("@Tel",model.Tel),
                new SqlParameter ("@Mobile",model.Mobile),
                new SqlParameter ("@IdCard",model.IdCard),
                new SqlParameter ("@IcCard",model.IcCard),
                new SqlParameter ("@Email",model.Email),
                new SqlParameter ("@UserGroupId",model.UserGroupId),
                new SqlParameter ("@UnitId",model.UnitId),
                new SqlParameter ("@PhotoUrl",model.PhotoUrl),
                new SqlParameter ("@RegTime",model.RegTime),
                new SqlParameter ("@RegDevice",model.RegDevice),
                new SqlParameter ("@LastLoginTime",model.LastLoginTime),
                new SqlParameter ("@LastLoginDevice",model.LastLoginDevice),
                new SqlParameter ("@LoginCount",model.LoginCount),
                new SqlParameter ("@LastLoginIp",model.LastLoginIp),
                new SqlParameter ("@LastLoginMac",model.LastLoginMac),
                new SqlParameter ("@EducationId",model.EducationId),
                new SqlParameter ("@NationId",model.NationId),
                new SqlParameter ("@PoliticId",model.PoliticId),
                new SqlParameter ("@College",model.College),
                new SqlParameter ("@Major",model.Major),
                new SqlParameter ("@JobPost",model.JobPost),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Creidt",model.Creidt),
                new SqlParameter ("@Coin",model.Coin)
            };
           return DBHelper.ExecuteNonQuery("Users_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Users">Users实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(Users model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@UserType",model.UserType),
                new SqlParameter ("@UserAcount",model.UserAcount),
                new SqlParameter ("@UserPwd",model.UserPwd),
                new SqlParameter ("@Salt",model.Salt),
                new SqlParameter ("@UserName",model.UserName),
                new SqlParameter ("@NickName",model.NickName),
                new SqlParameter ("@Sex",model.Sex),
                new SqlParameter ("@BriDate",model.BriDate),
                new SqlParameter ("@Tel",model.Tel),
                new SqlParameter ("@Mobile",model.Mobile),
                new SqlParameter ("@IdCard",model.IdCard),
                new SqlParameter ("@IcCard",model.IcCard),
                new SqlParameter ("@Email",model.Email),
                new SqlParameter ("@UserGroupId",model.UserGroupId),
                new SqlParameter ("@UnitId",model.UnitId),
                new SqlParameter ("@PhotoUrl",model.PhotoUrl),
                new SqlParameter ("@RegTime",model.RegTime),
                new SqlParameter ("@RegDevice",model.RegDevice),
                new SqlParameter ("@LastLoginTime",model.LastLoginTime),
                new SqlParameter ("@LastLoginDevice",model.LastLoginDevice),
                new SqlParameter ("@LoginCount",model.LoginCount),
                new SqlParameter ("@LastLoginIp",model.LastLoginIp),
                new SqlParameter ("@LastLoginMac",model.LastLoginMac),
                new SqlParameter ("@EducationId",model.EducationId),
                new SqlParameter ("@NationId",model.NationId),
                new SqlParameter ("@PoliticId",model.PoliticId),
                new SqlParameter ("@College",model.College),
                new SqlParameter ("@Major",model.Major),
                new SqlParameter ("@JobPost",model.JobPost),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Creidt",model.Creidt),
                new SqlParameter ("@Coin",model.Coin)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("Users_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Users">Users实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(Users model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@UserId",model.UserId),
                new SqlParameter ("@Status",model.Status),
                new SqlParameter ("@UserType",model.UserType),
                new SqlParameter ("@UserAcount",model.UserAcount),
                new SqlParameter ("@UserPwd",model.UserPwd),
                new SqlParameter ("@Salt",model.Salt),
                new SqlParameter ("@UserName",model.UserName),
                new SqlParameter ("@NickName",model.NickName),
                new SqlParameter ("@Sex",model.Sex),
                new SqlParameter ("@BriDate",model.BriDate),
                new SqlParameter ("@Tel",model.Tel),
                new SqlParameter ("@Mobile",model.Mobile),
                new SqlParameter ("@IdCard",model.IdCard),
                new SqlParameter ("@IcCard",model.IcCard),
                new SqlParameter ("@Email",model.Email),
                new SqlParameter ("@UserGroupId",model.UserGroupId),
                new SqlParameter ("@UnitId",model.UnitId),
                new SqlParameter ("@PhotoUrl",model.PhotoUrl),
                new SqlParameter ("@RegTime",model.RegTime),
                new SqlParameter ("@RegDevice",model.RegDevice),
                new SqlParameter ("@LastLoginTime",model.LastLoginTime),
                new SqlParameter ("@LastLoginDevice",model.LastLoginDevice),
                new SqlParameter ("@LoginCount",model.LoginCount),
                new SqlParameter ("@LastLoginIp",model.LastLoginIp),
                new SqlParameter ("@LastLoginMac",model.LastLoginMac),
                new SqlParameter ("@EducationId",model.EducationId),
                new SqlParameter ("@NationId",model.NationId),
                new SqlParameter ("@PoliticId",model.PoliticId),
                new SqlParameter ("@College",model.College),
                new SqlParameter ("@Major",model.Major),
                new SqlParameter ("@JobPost",model.JobPost),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Creidt",model.Creidt),
                new SqlParameter ("@Coin",model.Coin),
                new SqlParameter ("@OpenId",model.OpenId)
            };
           return DBHelper.ExecuteNonQuery("Users_Change",param);
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
                new SqlParameter ("@UserId",Id)
            };
           return DBHelper.ExecuteNonQuery ("Users_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("Users_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<Users> SelectAll()
        {
            List<Users> list = new List<Users>();
            Users model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Users_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new Users();
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["UserType"])
                        model.UserType= Convert.ToInt32(dr["UserType"]);
                    model.UserAcount = dr["UserAcount"].ToString();
                    model.UserPwd = dr["UserPwd"].ToString();
                    model.Salt = dr["Salt"].ToString();
                    model.UserName = dr["UserName"].ToString();
                    if (DBNull.Value!=dr["NickName"])
                        model.NickName = dr["NickName"].ToString();
                    if (DBNull.Value!=dr["Sex"])
                        model.Sex= Convert.ToInt32(dr["Sex"]);
                    if (DBNull.Value!=dr["BriDate"])
                        model.BriDate= Convert.ToDateTime(dr["BriDate"]);
                    if (DBNull.Value!=dr["Tel"])
                        model.Tel = dr["Tel"].ToString();
                    if (DBNull.Value!=dr["Mobile"])
                        model.Mobile = dr["Mobile"].ToString();
                    if (DBNull.Value!=dr["IdCard"])
                        model.IdCard = dr["IdCard"].ToString();
                    if (DBNull.Value!=dr["IcCard"])
                        model.IcCard = dr["IcCard"].ToString();
                    if (DBNull.Value!=dr["Email"])
                        model.Email = dr["Email"].ToString();
                    if (DBNull.Value!=dr["UserGroupId"])
                        model.UserGroupId= Convert.ToInt32(dr["UserGroupId"]);
                    if (DBNull.Value!=dr["UnitId"])
                        model.UnitId= Convert.ToInt32(dr["UnitId"]);
                    if (DBNull.Value!=dr["PhotoUrl"])
                        model.PhotoUrl = dr["PhotoUrl"].ToString();
                    model.RegTime= Convert.ToDateTime(dr["RegTime"]);
                    if (DBNull.Value!=dr["RegDevice"])
                        model.RegDevice= Convert.ToInt32(dr["RegDevice"]);
                    if (DBNull.Value!=dr["LastLoginTime"])
                        model.LastLoginTime= Convert.ToDateTime(dr["LastLoginTime"]);
                    if (DBNull.Value!=dr["LastLoginDevice"])
                        model.LastLoginDevice= Convert.ToInt32(dr["LastLoginDevice"]);
                    if (DBNull.Value!=dr["LoginCount"])
                        model.LoginCount= Convert.ToInt32(dr["LoginCount"]);
                    if (DBNull.Value!=dr["LastLoginIp"])
                        model.LastLoginIp = dr["LastLoginIp"].ToString();
                    if (DBNull.Value!=dr["LastLoginMac"])
                        model.LastLoginMac = dr["LastLoginMac"].ToString();
                    if (DBNull.Value!=dr["EducationId"])
                        model.EducationId= Convert.ToInt32(dr["EducationId"]);
                    if (DBNull.Value!=dr["NationId"])
                        model.NationId= Convert.ToInt32(dr["NationId"]);
                    if (DBNull.Value!=dr["PoliticId"])
                        model.PoliticId= Convert.ToInt32(dr["PoliticId"]);
                    if (DBNull.Value!=dr["College"])
                        model.College = dr["College"].ToString();
                    if (DBNull.Value!=dr["Major"])
                        model.Major = dr["Major"].ToString();
                    if (DBNull.Value!=dr["JobPost"])
                        model.JobPost = dr["JobPost"].ToString();
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Creidt"])
                        model.Creidt= Convert.ToDecimal(dr["Creidt"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>Users实体类对象</returns>
        public Users SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@UserId",Id)
            };
            Users model = new Users();
            using (SqlDataReader dr = DBHelper.RunProcedure("Users_SelectById", param))
            {
                if (dr.Read())
                {
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["UserType"])
                        model.UserType= Convert.ToInt32(dr["UserType"]);
                    model.UserAcount = dr["UserAcount"].ToString();
                    model.UserPwd = dr["UserPwd"].ToString();
                    model.Salt = dr["Salt"].ToString();
                    model.UserName = dr["UserName"].ToString();
                    if (DBNull.Value!=dr["NickName"])
                        model.NickName = dr["NickName"].ToString();
                    if (DBNull.Value!=dr["Sex"])
                        model.Sex= Convert.ToInt32(dr["Sex"]);
                    if (DBNull.Value!=dr["BriDate"])
                        model.BriDate= Convert.ToDateTime(dr["BriDate"]);
                    if (DBNull.Value!=dr["Tel"])
                        model.Tel = dr["Tel"].ToString();
                    if (DBNull.Value!=dr["Mobile"])
                        model.Mobile = dr["Mobile"].ToString();
                    if (DBNull.Value!=dr["IdCard"])
                        model.IdCard = dr["IdCard"].ToString();
                    if (DBNull.Value!=dr["IcCard"])
                        model.IcCard = dr["IcCard"].ToString();
                    if (DBNull.Value!=dr["Email"])
                        model.Email = dr["Email"].ToString();
                    if (DBNull.Value!=dr["UserGroupId"])
                        model.UserGroupId= Convert.ToInt32(dr["UserGroupId"]);
                    if (DBNull.Value!=dr["UnitId"])
                        model.UnitId= Convert.ToInt32(dr["UnitId"]);
                    if (DBNull.Value!=dr["PhotoUrl"])
                        model.PhotoUrl = dr["PhotoUrl"].ToString();
                    model.RegTime= Convert.ToDateTime(dr["RegTime"]);
                    if (DBNull.Value!=dr["RegDevice"])
                        model.RegDevice= Convert.ToInt32(dr["RegDevice"]);
                    if (DBNull.Value!=dr["LastLoginTime"])
                        model.LastLoginTime= Convert.ToDateTime(dr["LastLoginTime"]);
                    if (DBNull.Value!=dr["LastLoginDevice"])
                        model.LastLoginDevice= Convert.ToInt32(dr["LastLoginDevice"]);
                    if (DBNull.Value!=dr["LoginCount"])
                        model.LoginCount= Convert.ToInt32(dr["LoginCount"]);
                    if (DBNull.Value!=dr["LastLoginIp"])
                        model.LastLoginIp = dr["LastLoginIp"].ToString();
                    if (DBNull.Value!=dr["LastLoginMac"])
                        model.LastLoginMac = dr["LastLoginMac"].ToString();
                    if (DBNull.Value!=dr["EducationId"])
                        model.EducationId= Convert.ToInt32(dr["EducationId"]);
                    if (DBNull.Value!=dr["NationId"])
                        model.NationId= Convert.ToInt32(dr["NationId"]);
                    if (DBNull.Value!=dr["PoliticId"])
                        model.PoliticId= Convert.ToInt32(dr["PoliticId"]);
                    if (DBNull.Value!=dr["College"])
                        model.College = dr["College"].ToString();
                    if (DBNull.Value!=dr["Major"])
                        model.Major = dr["Major"].ToString();
                    if (DBNull.Value!=dr["JobPost"])
                        model.JobPost = dr["JobPost"].ToString();
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Creidt"])
                        model.Creidt= Convert.ToDecimal(dr["Creidt"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
                    if (DBNull.Value != dr["OpenId"])
                        model.OpenId = dr["OpenId"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>Users实体类对象</returns>
        public List<Users> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<Users> list = new List<Users>();
            Users model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Users_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new Users();
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["UserType"])
                        model.UserType= Convert.ToInt32(dr["UserType"]);
                    model.UserAcount = dr["UserAcount"].ToString();
                    model.UserPwd = dr["UserPwd"].ToString();
                    model.Salt = dr["Salt"].ToString();
                    model.UserName = dr["UserName"].ToString();
                    if (DBNull.Value!=dr["NickName"])
                        model.NickName = dr["NickName"].ToString();
                    if (DBNull.Value!=dr["Sex"])
                        model.Sex= Convert.ToInt32(dr["Sex"]);
                    if (DBNull.Value!=dr["BriDate"])
                        model.BriDate= Convert.ToDateTime(dr["BriDate"]);
                    if (DBNull.Value!=dr["Tel"])
                        model.Tel = dr["Tel"].ToString();
                    if (DBNull.Value!=dr["Mobile"])
                        model.Mobile = dr["Mobile"].ToString();
                    if (DBNull.Value!=dr["IdCard"])
                        model.IdCard = dr["IdCard"].ToString();
                    if (DBNull.Value!=dr["IcCard"])
                        model.IcCard = dr["IcCard"].ToString();
                    if (DBNull.Value!=dr["Email"])
                        model.Email = dr["Email"].ToString();
                    if (DBNull.Value!=dr["UserGroupId"])
                        model.UserGroupId= Convert.ToInt32(dr["UserGroupId"]);
                    if (DBNull.Value!=dr["UnitId"])
                        model.UnitId= Convert.ToInt32(dr["UnitId"]);
                    if (DBNull.Value!=dr["PhotoUrl"])
                        model.PhotoUrl = dr["PhotoUrl"].ToString();
                    model.RegTime= Convert.ToDateTime(dr["RegTime"]);
                    if (DBNull.Value!=dr["RegDevice"])
                        model.RegDevice= Convert.ToInt32(dr["RegDevice"]);
                    if (DBNull.Value!=dr["LastLoginTime"])
                        model.LastLoginTime= Convert.ToDateTime(dr["LastLoginTime"]);
                    if (DBNull.Value!=dr["LastLoginDevice"])
                        model.LastLoginDevice= Convert.ToInt32(dr["LastLoginDevice"]);
                    if (DBNull.Value!=dr["LoginCount"])
                        model.LoginCount= Convert.ToInt32(dr["LoginCount"]);
                    if (DBNull.Value!=dr["LastLoginIp"])
                        model.LastLoginIp = dr["LastLoginIp"].ToString();
                    if (DBNull.Value!=dr["LastLoginMac"])
                        model.LastLoginMac = dr["LastLoginMac"].ToString();
                    if (DBNull.Value!=dr["EducationId"])
                        model.EducationId= Convert.ToInt32(dr["EducationId"]);
                    if (DBNull.Value!=dr["NationId"])
                        model.NationId= Convert.ToInt32(dr["NationId"]);
                    if (DBNull.Value!=dr["PoliticId"])
                        model.PoliticId= Convert.ToInt32(dr["PoliticId"]);
                    if (DBNull.Value!=dr["College"])
                        model.College = dr["College"].ToString();
                    if (DBNull.Value!=dr["Major"])
                        model.Major = dr["Major"].ToString();
                    if (DBNull.Value!=dr["JobPost"])
                        model.JobPost = dr["JobPost"].ToString();
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Creidt"])
                        model.Creidt= Convert.ToDecimal(dr["Creidt"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
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
        /// <returns>Users实体类对象</returns>
        public List<Users> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<Users> list = new List<Users>();
            Users model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Users_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new Users();
                    model.UserId= Convert.ToInt32(dr["UserId"]);
                    model.Status= Convert.ToInt32(dr["Status"]);
                    if (DBNull.Value!=dr["UserType"])
                        model.UserType= Convert.ToInt32(dr["UserType"]);
                    model.UserAcount = dr["UserAcount"].ToString();
                    model.UserPwd = dr["UserPwd"].ToString();
                    model.Salt = dr["Salt"].ToString();
                    model.UserName = dr["UserName"].ToString();
                    if (DBNull.Value!=dr["NickName"])
                        model.NickName = dr["NickName"].ToString();
                    if (DBNull.Value!=dr["Sex"])
                        model.Sex= Convert.ToInt32(dr["Sex"]);
                    if (DBNull.Value!=dr["BriDate"])
                        model.BriDate= Convert.ToDateTime(dr["BriDate"]);
                    if (DBNull.Value!=dr["Tel"])
                        model.Tel = dr["Tel"].ToString();
                    if (DBNull.Value!=dr["Mobile"])
                        model.Mobile = dr["Mobile"].ToString();
                    if (DBNull.Value!=dr["IdCard"])
                        model.IdCard = dr["IdCard"].ToString();
                    if (DBNull.Value!=dr["IcCard"])
                        model.IcCard = dr["IcCard"].ToString();
                    if (DBNull.Value!=dr["Email"])
                        model.Email = dr["Email"].ToString();
                    if (DBNull.Value!=dr["UserGroupId"])
                        model.UserGroupId= Convert.ToInt32(dr["UserGroupId"]);
                    if (DBNull.Value!=dr["UnitId"])
                        model.UnitId= Convert.ToInt32(dr["UnitId"]);
                    if (DBNull.Value!=dr["PhotoUrl"])
                        model.PhotoUrl = dr["PhotoUrl"].ToString();
                    model.RegTime= Convert.ToDateTime(dr["RegTime"]);
                    if (DBNull.Value!=dr["RegDevice"])
                        model.RegDevice= Convert.ToInt32(dr["RegDevice"]);
                    if (DBNull.Value!=dr["LastLoginTime"])
                        model.LastLoginTime= Convert.ToDateTime(dr["LastLoginTime"]);
                    if (DBNull.Value!=dr["LastLoginDevice"])
                        model.LastLoginDevice= Convert.ToInt32(dr["LastLoginDevice"]);
                    if (DBNull.Value!=dr["LoginCount"])
                        model.LoginCount= Convert.ToInt32(dr["LoginCount"]);
                    if (DBNull.Value!=dr["LastLoginIp"])
                        model.LastLoginIp = dr["LastLoginIp"].ToString();
                    if (DBNull.Value!=dr["LastLoginMac"])
                        model.LastLoginMac = dr["LastLoginMac"].ToString();
                    if (DBNull.Value!=dr["EducationId"])
                        model.EducationId= Convert.ToInt32(dr["EducationId"]);
                    if (DBNull.Value!=dr["NationId"])
                        model.NationId= Convert.ToInt32(dr["NationId"]);
                    if (DBNull.Value!=dr["PoliticId"])
                        model.PoliticId= Convert.ToInt32(dr["PoliticId"]);
                    if (DBNull.Value!=dr["College"])
                        model.College = dr["College"].ToString();
                    if (DBNull.Value!=dr["Major"])
                        model.Major = dr["Major"].ToString();
                    if (DBNull.Value!=dr["JobPost"])
                        model.JobPost = dr["JobPost"].ToString();
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Creidt"])
                        model.Creidt= Convert.ToDecimal(dr["Creidt"]);
                    if (DBNull.Value!=dr["Coin"])
                        model.Coin= Convert.ToDecimal(dr["Coin"]);
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

