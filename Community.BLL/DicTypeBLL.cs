using System;
using System.Collections.Generic;
using System.Text;
using Community.DAL;
using Community.Model;

namespace Community.BLL
{
   public class DicTypeBLL
   {
        
       DicTypeDAL dal = new DicTypeDAL();

        
       #region 业务逻辑层其他扩展方法     
   

       #region 字典类数据生成树的Json格式

       private StringBuilder sbJSON = new StringBuilder();
       public string GetJson(List<DicType> lst)
       {

           if (lst.Count > 0)
           {
               sbJSON.Append("[");
               for (int i = 0; i < lst.Count; i++)
               {
                   sbJSON.Append("{");
                   sbJSON.Append("\"id\":" + lst[i].DicTypeId + ",");
                   sbJSON.Append("\"name\":\"" + lst[i].DicTypeName + "\"");


                   //如果下级
                   List<DicType> lst1;
                   lst1 = SelectByWhere(" where ParentId=" + lst[i].DicTypeId);

                   if (lst1 != null && lst1.Count > 0)
                   {
                       sbJSON.Append(",\"state\":\"closed\",");   //closed
                       sbJSON.Append("\"children\":");
                       GetJson(lst1);
                   }
                   if (i != lst.Count - 1)
                   {
                       sbJSON.Append("},");
                   }
                   else
                   {
                       sbJSON.Append("}");
                   }
               }
               sbJSON.Append("]");
           }

           return sbJSON.ToString();
       }

       #endregion


       #region 递归方法格式化分类

       /// <summary>
       /// 递归方法格式化分类
       /// </summary>
       /// <param name="list">需要格式化的List类型的数据</param>
       /// <param name="newList">格式化后返回的List类型的数据</param>
       /// <param name="step">步骤，第一次执行时为0</param>
       /// <param name="PerID">这个是上一级分类的分类ID（即当前分类的的父级ID）</param>
       public void GetMyList(List<DicType> list, ref List<DicType> newList, int step, int PerID)
       {
           if (list.Count == 0)
           {
               return;
           }

           string _Step = "";
           for (int i = 0; i < step; i++)
           {
               _Step += "　　";
           }
           _Step += "├";
           foreach (DicType atype in list)
           {
               if (atype.ParentId == PerID)
               {
                   int n = newList.Count;
                   newList.Add(atype);
                   newList[n].DicTypeName = _Step + atype.DicTypeName;
                   newList[n].DicTypeId = atype.DicTypeId;
                   newList[n].OrderIndex = atype.OrderIndex;
                   newList[n].ParentId = atype.ParentId;
                   newList[n].IsSystem = atype.IsSystem;
                   newList[n].IsDelete = atype.IsDelete;
                   int newstep = step + 1;
                   GetMyList(list, ref newList, newstep, Convert.ToInt32(atype.DicTypeId));
               }
           }
       }

       #endregion

       


       #endregion        
 
      #region 业务逻辑层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="DicType">DicType实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(DicType model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="DicType">DicType实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(DicType model)
        {
            return dal.AddReturnId(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="DicType">DicType实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(DicType model)
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
        public List<DicType> SelectAll()
        {
            return dal.SelectAll();
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        public DicType SelectById(int Id)
        {
            return dal.SelectById(Id);
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        public List<DicType> SelectByWhere(string WhereString)
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
        public List<DicType> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            return dal.SelectByWhereAndPage(WhereString , PageIndex , PageSize , OrderString, out TotalCount);
        }

        
 
      #endregion

    }
}

