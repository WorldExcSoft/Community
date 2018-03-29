using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class ChannelDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Channel">Channel实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(Channel model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@ChannelName",model.ChannelName),
                new SqlParameter ("@ChannelImg",model.ChannelImg),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsShow",model.IsShow),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Remark",model.Remark)
            };
           return DBHelper.ExecuteNonQuery("Channel_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="Channel">Channel实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(Channel model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@ChannelName",model.ChannelName),
                new SqlParameter ("@ChannelImg",model.ChannelImg),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsShow",model.IsShow),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Remark",model.Remark)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("Channel_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Channel">Channel实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(Channel model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ChannelId",model.ChannelId),
                new SqlParameter ("@ParentId",model.ParentId),
                new SqlParameter ("@ChannelName",model.ChannelName),
                new SqlParameter ("@ChannelImg",model.ChannelImg),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsShow",model.IsShow),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Remark",model.Remark)
            };
           return DBHelper.ExecuteNonQuery("Channel_Change",param);
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
                new SqlParameter ("@ChannelId",Id)
            };
           return DBHelper.ExecuteNonQuery ("Channel_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("Channel_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<Channel> SelectAll()
        {
            List<Channel> list = new List<Channel>();
            Channel model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Channel_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new Channel();
                    model.ChannelId= Convert.ToInt32(dr["ChannelId"]);
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["ChannelName"])
                        model.ChannelName = dr["ChannelName"].ToString();
                    if (DBNull.Value!=dr["ChannelImg"])
                        model.ChannelImg = dr["ChannelImg"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsShow"])
                        model.IsShow= Convert.ToBoolean(dr["IsShow"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Remark"])
                        model.Remark = dr["Remark"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>Channel实体类对象</returns>
        public Channel SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ChannelId",Id)
            };
            Channel model = new Channel();
            using (SqlDataReader dr = DBHelper.RunProcedure("Channel_SelectById", param))
            {
                if (dr.Read())
                {
                    model.ChannelId= Convert.ToInt32(dr["ChannelId"]);
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["ChannelName"])
                        model.ChannelName = dr["ChannelName"].ToString();
                    if (DBNull.Value!=dr["ChannelImg"])
                        model.ChannelImg = dr["ChannelImg"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsShow"])
                        model.IsShow= Convert.ToBoolean(dr["IsShow"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Remark"])
                        model.Remark = dr["Remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>Channel实体类对象</returns>
        public List<Channel> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<Channel> list = new List<Channel>();
            Channel model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Channel_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new Channel();
                    model.ChannelId= Convert.ToInt32(dr["ChannelId"]);
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["ChannelName"])
                        model.ChannelName = dr["ChannelName"].ToString();
                    if (DBNull.Value!=dr["ChannelImg"])
                        model.ChannelImg = dr["ChannelImg"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsShow"])
                        model.IsShow= Convert.ToBoolean(dr["IsShow"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Remark"])
                        model.Remark = dr["Remark"].ToString();
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
        /// <returns>Channel实体类对象</returns>
        public List<Channel> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<Channel> list = new List<Channel>();
            Channel model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("Channel_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new Channel();
                    model.ChannelId= Convert.ToInt32(dr["ChannelId"]);
                    if (DBNull.Value!=dr["ParentId"])
                        model.ParentId= Convert.ToInt32(dr["ParentId"]);
                    if (DBNull.Value!=dr["ChannelName"])
                        model.ChannelName = dr["ChannelName"].ToString();
                    if (DBNull.Value!=dr["ChannelImg"])
                        model.ChannelImg = dr["ChannelImg"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsShow"])
                        model.IsShow= Convert.ToBoolean(dr["IsShow"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Remark"])
                        model.Remark = dr["Remark"].ToString();
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

