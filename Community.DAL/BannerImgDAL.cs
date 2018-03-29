using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class BannerImgDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="BannerImg">BannerImg实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(BannerImg model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@BannerImgName",model.BannerImgName),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@Url",model.Url),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@PlatformId",model.PlatformId),
                new SqlParameter ("@IsShow",model.IsShow),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@ObjType",model.ObjType)
            };
           return DBHelper.ExecuteNonQuery("BannerImg_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="BannerImg">BannerImg实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(BannerImg model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@BannerImgName",model.BannerImgName),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@Url",model.Url),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@PlatformId",model.PlatformId),
                new SqlParameter ("@IsShow",model.IsShow),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@ObjType",model.ObjType)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("BannerImg_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="BannerImg">BannerImg实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(BannerImg model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@BannerImgId",model.BannerImgId),
                new SqlParameter ("@BannerImgName",model.BannerImgName),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@Url",model.Url),
                new SqlParameter ("@Description",model.Description),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@PlatformId",model.PlatformId),
                new SqlParameter ("@IsShow",model.IsShow),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@ObjType",model.ObjType)
            };
           return DBHelper.ExecuteNonQuery("BannerImg_Change",param);
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
                new SqlParameter ("@BannerImgId",Id)
            };
           return DBHelper.ExecuteNonQuery ("BannerImg_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("BannerImg_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<BannerImg> SelectAll()
        {
            List<BannerImg> list = new List<BannerImg>();
            BannerImg model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("BannerImg_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new BannerImg();
                    model.BannerImgId= Convert.ToInt32(dr["BannerImgId"]);
                    if (DBNull.Value!=dr["BannerImgName"])
                        model.BannerImgName = dr["BannerImgName"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["Url"])
                        model.Url = dr["Url"].ToString();
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["PlatformId"])
                        model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
                    if (DBNull.Value!=dr["IsShow"])
                        model.IsShow= Convert.ToBoolean(dr["IsShow"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
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
        /// <returns>BannerImg实体类对象</returns>
        public BannerImg SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@BannerImgId",Id)
            };
            BannerImg model = new BannerImg();
            using (SqlDataReader dr = DBHelper.RunProcedure("BannerImg_SelectById", param))
            {
                if (dr.Read())
                {
                    model.BannerImgId= Convert.ToInt32(dr["BannerImgId"]);
                    if (DBNull.Value!=dr["BannerImgName"])
                        model.BannerImgName = dr["BannerImgName"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["Url"])
                        model.Url = dr["Url"].ToString();
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["PlatformId"])
                        model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
                    if (DBNull.Value!=dr["IsShow"])
                        model.IsShow= Convert.ToBoolean(dr["IsShow"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
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
        /// <returns>BannerImg实体类对象</returns>
        public List<BannerImg> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<BannerImg> list = new List<BannerImg>();
            BannerImg model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("BannerImg_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new BannerImg();
                    model.BannerImgId= Convert.ToInt32(dr["BannerImgId"]);
                    if (DBNull.Value!=dr["BannerImgName"])
                        model.BannerImgName = dr["BannerImgName"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["Url"])
                        model.Url = dr["Url"].ToString();
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["PlatformId"])
                        model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
                    if (DBNull.Value!=dr["IsShow"])
                        model.IsShow= Convert.ToBoolean(dr["IsShow"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
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
        /// <returns>BannerImg实体类对象</returns>
        public List<BannerImg> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<BannerImg> list = new List<BannerImg>();
            BannerImg model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("BannerImg_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new BannerImg();
                    model.BannerImgId= Convert.ToInt32(dr["BannerImgId"]);
                    if (DBNull.Value!=dr["BannerImgName"])
                        model.BannerImgName = dr["BannerImgName"].ToString();
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["Url"])
                        model.Url = dr["Url"].ToString();
                    if (DBNull.Value!=dr["Description"])
                        model.Description = dr["Description"].ToString();
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["PlatformId"])
                        model.PlatformId= Convert.ToInt32(dr["PlatformId"]);
                    if (DBNull.Value!=dr["IsShow"])
                        model.IsShow= Convert.ToBoolean(dr["IsShow"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
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

