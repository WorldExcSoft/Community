using System;
using System.Collections.Generic;
using Community.Model;
using Community.Common;
using System.Data;
using System.Data.SqlClient;

namespace Community.DAL
{
    public class EduClassDAL
    {
        
       #region 数据访问层其他扩展方法        

       #endregion        
 
      #region 数据访问层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="EduClass">EduClass实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(EduClass model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@EduClassName",model.EduClassName),
                new SqlParameter ("@EduClassDesc",model.EduClassDesc),
                new SqlParameter ("@EduSchoolId",model.EduSchoolId),
                new SqlParameter ("@EduMajorId",model.EduMajorId),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@ClassTime",model.ClassTime),
                new SqlParameter ("@ClassPlace",model.ClassPlace),
                new SqlParameter ("@ClassMaterial",model.ClassMaterial),
                new SqlParameter ("@ClassMoney",model.ClassMoney),
                new SqlParameter ("@HostUnit",model.HostUnit),
                new SqlParameter ("@Organizer",model.Organizer),
                new SqlParameter ("@StartApplyDate",model.StartApplyDate),
                new SqlParameter ("@EndApplyDate",model.EndApplyDate),
                new SqlParameter ("@StartClassDate",model.StartClassDate),
                new SqlParameter ("@EndClassDate",model.EndClassDate),
                new SqlParameter ("@ClassHour",model.ClassHour),
                new SqlParameter ("@ClassYear",model.ClassYear),
                new SqlParameter ("@LimitUserCount",model.LimitUserCount),
                new SqlParameter ("@LimitClassCount",model.LimitClassCount),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Status",model.Status)
            };
           return DBHelper.ExecuteNonQuery("EduClass_Add",param);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="EduClass">EduClass实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(EduClass model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@EduClassName",model.EduClassName),
                new SqlParameter ("@EduClassDesc",model.EduClassDesc),
                new SqlParameter ("@EduSchoolId",model.EduSchoolId),
                new SqlParameter ("@EduMajorId",model.EduMajorId),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@ClassTime",model.ClassTime),
                new SqlParameter ("@ClassPlace",model.ClassPlace),
                new SqlParameter ("@ClassMaterial",model.ClassMaterial),
                new SqlParameter ("@ClassMoney",model.ClassMoney),
                new SqlParameter ("@HostUnit",model.HostUnit),
                new SqlParameter ("@Organizer",model.Organizer),
                new SqlParameter ("@StartApplyDate",model.StartApplyDate),
                new SqlParameter ("@EndApplyDate",model.EndApplyDate),
                new SqlParameter ("@StartClassDate",model.StartClassDate),
                new SqlParameter ("@EndClassDate",model.EndClassDate),
                new SqlParameter ("@ClassHour",model.ClassHour),
                new SqlParameter ("@ClassYear",model.ClassYear),
                new SqlParameter ("@LimitUserCount",model.LimitUserCount),
                new SqlParameter ("@LimitClassCount",model.LimitClassCount),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Status",model.Status)
            };
           return Convert.ToInt32(DBHelper.ExecuteScalar ("EduClass_AddReturnId",param));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="EduClass">EduClass实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(EduClass model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@EduClassId",model.EduClassId),
                new SqlParameter ("@EduClassName",model.EduClassName),
                new SqlParameter ("@EduClassDesc",model.EduClassDesc),
                new SqlParameter ("@EduSchoolId",model.EduSchoolId),
                new SqlParameter ("@EduMajorId",model.EduMajorId),
                new SqlParameter ("@Image",model.Image),
                new SqlParameter ("@ClassTime",model.ClassTime),
                new SqlParameter ("@ClassPlace",model.ClassPlace),
                new SqlParameter ("@ClassMaterial",model.ClassMaterial),
                new SqlParameter ("@ClassMoney",model.ClassMoney),
                new SqlParameter ("@HostUnit",model.HostUnit),
                new SqlParameter ("@Organizer",model.Organizer),
                new SqlParameter ("@StartApplyDate",model.StartApplyDate),
                new SqlParameter ("@EndApplyDate",model.EndApplyDate),
                new SqlParameter ("@StartClassDate",model.StartClassDate),
                new SqlParameter ("@EndClassDate",model.EndClassDate),
                new SqlParameter ("@ClassHour",model.ClassHour),
                new SqlParameter ("@ClassYear",model.ClassYear),
                new SqlParameter ("@LimitUserCount",model.LimitUserCount),
                new SqlParameter ("@LimitClassCount",model.LimitClassCount),
                new SqlParameter ("@OrderIndex",model.OrderIndex),
                new SqlParameter ("@IsDelete",model.IsDelete),
                new SqlParameter ("@Status",model.Status)
            };
           return DBHelper.ExecuteNonQuery("EduClass_Change",param);
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
                new SqlParameter ("@EduClassId",Id)
            };
           return DBHelper.ExecuteNonQuery ("EduClass_Delete",param);
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
           return DBHelper.ExecuteNonQuery ("EduClass_DeleteByWhere",param);
        }

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>list集合</returns>
        public List<EduClass> SelectAll()
        {
            List<EduClass> list = new List<EduClass>();
            EduClass model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("EduClass_SelectAll", null))
            {
                while (dr.Read())
                {
                    model = new EduClass();
                    model.EduClassId= Convert.ToInt32(dr["EduClassId"]);
                    if (DBNull.Value!=dr["EduClassName"])
                        model.EduClassName = dr["EduClassName"].ToString();
                    if (DBNull.Value!=dr["EduClassDesc"])
                        model.EduClassDesc = dr["EduClassDesc"].ToString();
                    if (DBNull.Value!=dr["EduSchoolId"])
                        model.EduSchoolId= Convert.ToInt32(dr["EduSchoolId"]);
                    if (DBNull.Value!=dr["EduMajorId"])
                        model.EduMajorId= Convert.ToInt32(dr["EduMajorId"]);
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["ClassTime"])
                        model.ClassTime= dr["ClassTime"].ToString();
                    if (DBNull.Value!=dr["ClassPlace"])
                        model.ClassPlace = dr["ClassPlace"].ToString();
                    if (DBNull.Value!=dr["ClassMaterial"])
                        model.ClassMaterial = dr["ClassMaterial"].ToString();
                    if (DBNull.Value!=dr["ClassMoney"])
                        model.ClassMoney= Convert.ToDecimal(dr["ClassMoney"]);
                    if (DBNull.Value!=dr["HostUnit"])
                        model.HostUnit = dr["HostUnit"].ToString();
                    if (DBNull.Value!=dr["Organizer"])
                        model.Organizer = dr["Organizer"].ToString();
                    if (DBNull.Value!=dr["StartApplyDate"])
                        model.StartApplyDate= Convert.ToDateTime(dr["StartApplyDate"]);
                    if (DBNull.Value!=dr["EndApplyDate"])
                        model.EndApplyDate= Convert.ToDateTime(dr["EndApplyDate"]);
                    if (DBNull.Value!=dr["StartClassDate"])
                        model.StartClassDate= Convert.ToDateTime(dr["StartClassDate"]);
                    if (DBNull.Value!=dr["EndClassDate"])
                        model.EndClassDate= Convert.ToDateTime(dr["EndClassDate"]);
                    if (DBNull.Value!=dr["ClassHour"])
                        model.ClassHour= Convert.ToDecimal(dr["ClassHour"]);
                    if (DBNull.Value!=dr["ClassYear"])
                        model.ClassYear= Convert.ToDecimal(dr["ClassYear"]);
                    if (DBNull.Value!=dr["LimitUserCount"])
                        model.LimitUserCount= Convert.ToInt32(dr["LimitUserCount"]);
                    if (DBNull.Value!=dr["LimitClassCount"])
                        model.LimitClassCount= Convert.ToInt32(dr["LimitClassCount"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>EduClass实体类对象</returns>
        public EduClass SelectById(int Id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@EduClassId",Id)
            };
            EduClass model = new EduClass();
            using (SqlDataReader dr = DBHelper.RunProcedure("EduClass_SelectById", param))
            {
                if (dr.Read())
                {
                    model.EduClassId= Convert.ToInt32(dr["EduClassId"]);
                    if (DBNull.Value!=dr["EduClassName"])
                        model.EduClassName = dr["EduClassName"].ToString();
                    if (DBNull.Value!=dr["EduClassDesc"])
                        model.EduClassDesc = dr["EduClassDesc"].ToString();
                    if (DBNull.Value!=dr["EduSchoolId"])
                        model.EduSchoolId= Convert.ToInt32(dr["EduSchoolId"]);
                    if (DBNull.Value!=dr["EduMajorId"])
                        model.EduMajorId= Convert.ToInt32(dr["EduMajorId"]);
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["ClassTime"])
                        model.ClassTime = dr["ClassTime"].ToString();
                    if (DBNull.Value!=dr["ClassPlace"])
                        model.ClassPlace = dr["ClassPlace"].ToString();
                    if (DBNull.Value!=dr["ClassMaterial"])
                        model.ClassMaterial = dr["ClassMaterial"].ToString();
                    if (DBNull.Value!=dr["ClassMoney"])
                        model.ClassMoney= Convert.ToDecimal(dr["ClassMoney"]);
                    if (DBNull.Value!=dr["HostUnit"])
                        model.HostUnit = dr["HostUnit"].ToString();
                    if (DBNull.Value!=dr["Organizer"])
                        model.Organizer = dr["Organizer"].ToString();
                    if (DBNull.Value!=dr["StartApplyDate"])
                        model.StartApplyDate= Convert.ToDateTime(dr["StartApplyDate"]);
                    if (DBNull.Value!=dr["EndApplyDate"])
                        model.EndApplyDate= Convert.ToDateTime(dr["EndApplyDate"]);
                    if (DBNull.Value!=dr["StartClassDate"])
                        model.StartClassDate= Convert.ToDateTime(dr["StartClassDate"]);
                    if (DBNull.Value!=dr["EndClassDate"])
                        model.EndClassDate= Convert.ToDateTime(dr["EndClassDate"]);
                    if (DBNull.Value!=dr["ClassHour"])
                        model.ClassHour= Convert.ToDecimal(dr["ClassHour"]);
                    if (DBNull.Value!=dr["ClassYear"])
                        model.ClassYear= Convert.ToDecimal(dr["ClassYear"]);
                    if (DBNull.Value!=dr["LimitUserCount"])
                        model.LimitUserCount= Convert.ToInt32(dr["LimitUserCount"]);
                    if (DBNull.Value!=dr["LimitClassCount"])
                        model.LimitClassCount= Convert.ToInt32(dr["LimitClassCount"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <returns>EduClass实体类对象</returns>
        public List<EduClass> SelectByWhere(string WhereString)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString)
            };
            List<EduClass> list = new List<EduClass>();
            EduClass model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("EduClass_SelectByWhere", param))
            {
                while (dr.Read())
                {
                    model = new EduClass();
                    model.EduClassId= Convert.ToInt32(dr["EduClassId"]);
                    if (DBNull.Value!=dr["EduClassName"])
                        model.EduClassName = dr["EduClassName"].ToString();
                    if (DBNull.Value!=dr["EduClassDesc"])
                        model.EduClassDesc = dr["EduClassDesc"].ToString();
                    if (DBNull.Value!=dr["EduSchoolId"])
                        model.EduSchoolId= Convert.ToInt32(dr["EduSchoolId"]);
                    if (DBNull.Value!=dr["EduMajorId"])
                        model.EduMajorId= Convert.ToInt32(dr["EduMajorId"]);
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["ClassTime"])
                        model.ClassTime= dr["ClassTime"].ToString();
                    if (DBNull.Value!=dr["ClassPlace"])
                        model.ClassPlace = dr["ClassPlace"].ToString();
                    if (DBNull.Value!=dr["ClassMaterial"])
                        model.ClassMaterial = dr["ClassMaterial"].ToString();
                    if (DBNull.Value!=dr["ClassMoney"])
                        model.ClassMoney= Convert.ToDecimal(dr["ClassMoney"]);
                    if (DBNull.Value!=dr["HostUnit"])
                        model.HostUnit = dr["HostUnit"].ToString();
                    if (DBNull.Value!=dr["Organizer"])
                        model.Organizer = dr["Organizer"].ToString();
                    if (DBNull.Value!=dr["StartApplyDate"])
                        model.StartApplyDate= Convert.ToDateTime(dr["StartApplyDate"]);
                    if (DBNull.Value!=dr["EndApplyDate"])
                        model.EndApplyDate= Convert.ToDateTime(dr["EndApplyDate"]);
                    if (DBNull.Value!=dr["StartClassDate"])
                        model.StartClassDate= Convert.ToDateTime(dr["StartClassDate"]);
                    if (DBNull.Value!=dr["EndClassDate"])
                        model.EndClassDate= Convert.ToDateTime(dr["EndClassDate"]);
                    if (DBNull.Value!=dr["ClassHour"])
                        model.ClassHour= Convert.ToDecimal(dr["ClassHour"]);
                    if (DBNull.Value!=dr["ClassYear"])
                        model.ClassYear= Convert.ToDecimal(dr["ClassYear"]);
                    if (DBNull.Value!=dr["LimitUserCount"])
                        model.LimitUserCount= Convert.ToInt32(dr["LimitUserCount"]);
                    if (DBNull.Value!=dr["LimitClassCount"])
                        model.LimitClassCount= Convert.ToInt32(dr["LimitClassCount"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
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
        /// <returns>EduClass实体类对象</returns>
        public List<EduClass> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@where",WhereString),
                new SqlParameter ("@pageIndex",PageIndex),
                new SqlParameter ("@pageSize",PageSize),
                new SqlParameter ("@orderString",OrderString),
                new SqlParameter ("@TotalCount",ParameterDirection.Output)
            };
            List<EduClass> list = new List<EduClass>();
            EduClass model = null;
            using (SqlDataReader dr =  DBHelper.RunProcedure("EduClass_SelectByWhereAndPage", param))
            {
                while (dr.Read())
                {
                    model = new EduClass();
                    model.EduClassId= Convert.ToInt32(dr["EduClassId"]);
                    if (DBNull.Value!=dr["EduClassName"])
                        model.EduClassName = dr["EduClassName"].ToString();
                    if (DBNull.Value!=dr["EduClassDesc"])
                        model.EduClassDesc = dr["EduClassDesc"].ToString();
                    if (DBNull.Value!=dr["EduSchoolId"])
                        model.EduSchoolId= Convert.ToInt32(dr["EduSchoolId"]);
                    if (DBNull.Value!=dr["EduMajorId"])
                        model.EduMajorId= Convert.ToInt32(dr["EduMajorId"]);
                    if (DBNull.Value!=dr["Image"])
                        model.Image = dr["Image"].ToString();
                    if (DBNull.Value!=dr["ClassTime"])
                        model.ClassTime= dr["ClassTime"].ToString();
                    if (DBNull.Value!=dr["ClassPlace"])
                        model.ClassPlace = dr["ClassPlace"].ToString();
                    if (DBNull.Value!=dr["ClassMaterial"])
                        model.ClassMaterial = dr["ClassMaterial"].ToString();
                    if (DBNull.Value!=dr["ClassMoney"])
                        model.ClassMoney= Convert.ToDecimal(dr["ClassMoney"]);
                    if (DBNull.Value!=dr["HostUnit"])
                        model.HostUnit = dr["HostUnit"].ToString();
                    if (DBNull.Value!=dr["Organizer"])
                        model.Organizer = dr["Organizer"].ToString();
                    if (DBNull.Value!=dr["StartApplyDate"])
                        model.StartApplyDate= Convert.ToDateTime(dr["StartApplyDate"]);
                    if (DBNull.Value!=dr["EndApplyDate"])
                        model.EndApplyDate= Convert.ToDateTime(dr["EndApplyDate"]);
                    if (DBNull.Value!=dr["StartClassDate"])
                        model.StartClassDate= Convert.ToDateTime(dr["StartClassDate"]);
                    if (DBNull.Value!=dr["EndClassDate"])
                        model.EndClassDate= Convert.ToDateTime(dr["EndClassDate"]);
                    if (DBNull.Value!=dr["ClassHour"])
                        model.ClassHour= Convert.ToDecimal(dr["ClassHour"]);
                    if (DBNull.Value!=dr["ClassYear"])
                        model.ClassYear= Convert.ToDecimal(dr["ClassYear"]);
                    if (DBNull.Value!=dr["LimitUserCount"])
                        model.LimitUserCount= Convert.ToInt32(dr["LimitUserCount"]);
                    if (DBNull.Value!=dr["LimitClassCount"])
                        model.LimitClassCount= Convert.ToInt32(dr["LimitClassCount"]);
                    if (DBNull.Value!=dr["OrderIndex"])
                        model.OrderIndex= Convert.ToInt32(dr["OrderIndex"]);
                    if (DBNull.Value!=dr["IsDelete"])
                        model.IsDelete= Convert.ToBoolean(dr["IsDelete"]);
                    if (DBNull.Value!=dr["Status"])
                        model.Status= Convert.ToInt32(dr["Status"]);
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

