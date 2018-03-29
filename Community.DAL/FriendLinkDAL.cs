using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class FriendLinkDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="FriendLink">FriendLink实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(FriendLink model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@LinkName",model.LinkName),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@LinkHref",model.LinkHref),
                new SqlParameter ("@LinkType",model.LinkType),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@PlatformId",model.PlatformId),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@IsShow",model.IsShow)
            };
           return DBHelper.ExecuteNonQuery("FriendLink_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="FriendLink">FriendLink实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(FriendLink model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@LinkName",model.LinkName),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@LinkHref",model.LinkHref),
                new SqlParameter ("@LinkType",model.LinkType),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@PlatformId",model.PlatformId),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@IsShow",model.IsShow)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("FriendLink_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="FriendLink">FriendLink实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(FriendLink model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@LinkId",model.LinkId),
                new SqlParameter ("@LinkName",model.LinkName),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@LinkHref",model.LinkHref),
                new SqlParameter ("@LinkType",model.LinkType),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@PlatformId",model.PlatformId),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@IsShow",model.IsShow)
            };
           return DBHelper.ExecuteNonQuery("FriendLink_Change",param);
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
                new SqlParameter ("@LinkId",Id)
            };
           return DBHelper.ExecuteNonQuery ("FriendLink_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("FriendLink_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<FriendLink> SelectAll()
        {
            List<FriendLink> list = new List<FriendLink>();
            FriendLink model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("FriendLink_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new FriendLink();
                    model.LinkId= Convert.ToInt32(dr["LinkId"]);
                    if (DBNull.Value!=dr["LinkName"])
                        model.LinkName = dr["LinkName"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["LinkHref"])
                        model.LinkHref = dr["LinkHref"].ToString();
                    if (DBNull.Value!=dr["LinkType"])
                        model.LinkType= Convert.ToInt32(dr["LinkType"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["PlatformId"])
                        model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["IsShow"])
                        model.IsShow= Convert.ToBoolean(dr["IsShow"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>FriendLink实体类对象</returns>
        public FriendLink SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@LinkId",Id)
            };
            FriendLink model = new FriendLink();
            using (SqlDataReader dr = DBHelper.RunProcedure("FriendLink_SelectById", param))
            {
                if (dr.Read())
                {
                    model.LinkId= Convert.ToInt32(dr["LinkId"]);
                    if (DBNull.Value!=dr["LinkName"])
                        model.LinkName = dr["LinkName"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["LinkHref"])
                        model.LinkHref = dr["LinkHref"].ToString();
                    if (DBNull.Value!=dr["LinkType"])
                        model.LinkType= Convert.ToInt32(dr["LinkType"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["PlatformId"])
                        model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["IsShow"])
                        model.IsShow= Convert.ToBoolean(dr["IsShow"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>FriendLink实体类对象</returns>
        public List<FriendLink> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<FriendLink> list = new List<FriendLink>();
            FriendLink model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("FriendLink_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new FriendLink();
                    model.LinkId= Convert.ToInt32(dr["LinkId"]);
                    if (DBNull.Value!=dr["LinkName"])
                        model.LinkName = dr["LinkName"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["LinkHref"])
                        model.LinkHref = dr["LinkHref"].ToString();
                    if (DBNull.Value!=dr["LinkType"])
                        model.LinkType= Convert.ToInt32(dr["LinkType"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["PlatformId"])
                        model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["IsShow"])
                        model.IsShow= Convert.ToBoolean(dr["IsShow"]);
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
        /// <returns>FriendLink实体类对象</returns>
        public List<FriendLink> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<FriendLink> list = new List<FriendLink>();
            FriendLink model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("FriendLink_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new FriendLink();
                    model.LinkId= Convert.ToInt32(dr["LinkId"]);
                    if (DBNull.Value!=dr["LinkName"])
                        model.LinkName = dr["LinkName"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["LinkHref"])
                        model.LinkHref = dr["LinkHref"].ToString();
                    if (DBNull.Value!=dr["LinkType"])
                        model.LinkType= Convert.ToInt32(dr["LinkType"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["PlatformId"])
                        model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["IsShow"])
                        model.IsShow= Convert.ToBoolean(dr["IsShow"]);
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

