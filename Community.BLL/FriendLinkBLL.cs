using System;
using System.Collections.Generic;
using System.Text;
using Community.Common;
using Community.DAL;
using Community.Model;

namespace Community.BLL
{
   public class FriendLinkBLL
   {
        
       FriendLinkDAL dal = new FriendLinkDAL();

        
       #region 业务逻辑层其他扩展方法        


       
            #region 搜索查询

       public string GetFriendLinkParam(FriendLink param)
       {

           StringBuilder sb = new StringBuilder();

           if (!string.IsNullOrEmpty(param.LinkName))
           {
               sb.AppendFormat(" where IsDelete=0 and   LinkName like '%{0}%' ", Utils.SqlSafe(param.LinkName));
           }



           return sb.ToString();

       }

       #endregion

       #endregion        
 
      #region 业务逻辑层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="FriendLink">FriendLink实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(FriendLink model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="FriendLink">FriendLink实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(FriendLink model)
        {
            return dal.AddReturnId(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="FriendLink">FriendLink实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(FriendLink model)
        {
            return dal.Change(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id">主键Id</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Delete(int Id)
        {
            return dal.Delete(Id);
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="WhereString">删除条件</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool DeleteByWhere(string WhereString)
        {
            return dal.DeleteByWhere(WhereString);
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        public List<FriendLink> SelectAll()
        {
            return dal.SelectAll();
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        public FriendLink SelectById(int Id)
        {
            return dal.SelectById(Id);
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        public List<FriendLink> SelectByWhere(string WhereString)
        {
            return dal.SelectByWhere(WhereString);
        }

        /// <summary>
        /// 通过条件查询并分页
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        /// <param name="PageIndex">当前页码</param>
        /// <param name="PageSize">页大小（每页显示多少条数据）</param>
        /// <param name="OrderString">排序条件</param>
        /// <param name="TotalCount">返回符合条件的数据总的记录数</param>
        public List<FriendLink> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            return dal.SelectByWhereAndPage(WhereString , PageIndex , PageSize , OrderString, out TotalCount);
        }

        
 
      #endregion

    }
}

