using System;
using System.Collections.Generic;
using System.Text;
using Community.Common;
using Community.DAL;
using Community.Model;

namespace Community.BLL
{
   public class ArticleTypeBLL
   {
        
       ArticleTypeDAL dal = new ArticleTypeDAL();
       ArticleBLL articleBll = new ArticleBLL();

        
       #region 业务逻辑层其他扩展方法      


       #region 搜索查询

       public string GetArticleTypeParam(ArticleType param)
       {

           StringBuilder sb = new StringBuilder();

           sb.AppendFormat("where 1=1 and IsDelete=0 ");

            //if (!string.IsNullOrEmpty(param.ParentId.ToString()))
            //{
            //    sb.AppendFormat("  and  (ParentId=-1  or   ParentId=" + param.ParentId + ") ");
            //}

            //if (!string.IsNullOrEmpty(param.PlatformId.ToString()))
            //{
            //   sb.AppendFormat("  and  PlatformId=" + param.PlatformId);
            //}
           if (!string.IsNullOrEmpty(param.ArticleTypeName))
           {
               sb.AppendFormat(" and  ArticleTypeName like '%{0}%' ", Utils.SqlSafe(param.ArticleTypeName));
           }
           else
           {
               sb.AppendFormat(" and  ParentId=0 ");
           }
           if (string.IsNullOrEmpty(sb.ToString()))
           {
               sb.AppendFormat(" where ParentId=0 ");
           }

           return sb.ToString();

       }

       #endregion


       #region 字典类数据生成树的Json格式（生成EasyuiTree格式的树形Json数据）

       private StringBuilder sbJSON = new StringBuilder();
       public string GetEasyuiTreeJson(List<ArticleType> lst)
       {

           if (lst.Count > 0)
           {
               sbJSON.Append("[");
               for (int i = 0; i < lst.Count; i++)
               {
                   sbJSON.Append("{");
                   sbJSON.Append("\"id\":" + lst[i].ArticleTypeId + ",");
                   sbJSON.Append("\"name\":\"" + lst[i].ArticleTypeName + "\",");
                   sbJSON.Append("\"OrderIndex\":\"" + lst[i].OrderIndex + "\",");


                   //如果下级
                   List<ArticleType> lst1;
                   lst1 = SelectByWhere(" where IsDelete=0 and  ParentId=" + lst[i].ArticleTypeId);
                   sbJSON.Append("\"Size\":\"" + lst1.Count + "\",");

                   //如果有文章
                   List<Article> list;
                   list = articleBll.SelectByWhere(" where IsDelete=0 and  ArticleType like '%," + lst[i].ArticleTypeId + ",%'");
                   sbJSON.Append("\"Count\":\"" + list.Count + "\"");

                   if (lst1 != null && lst1.Count > 0)
                   {
                       sbJSON.Append(",\"state\":\"closed\",");   //closed
                       sbJSON.Append("\"children\":");
                       GetEasyuiTreeJson(lst1);
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


       #region 字典类数据生成树的Json格式（生成EasyuiComboTree格式的树形Json数据）

       public string GetEasyuiComboTreeJson(List<ArticleType> lst)
       {

           if (lst.Count > 0)
           {
               sbJSON.Append("[");
               for (int i = 0; i < lst.Count; i++)
               {
                   sbJSON.Append("{");
                   sbJSON.Append("\"id\":" + lst[i].ArticleTypeId + ",");
                   sbJSON.Append("\"text\":\"" + lst[i].ArticleTypeName + "\"");


                   //如果下级
                   List<ArticleType> lst1;
                   lst1 = SelectByWhere(" where  IsDelete=0 and  ParentId=" + lst[i].ArticleTypeId);

                   if (lst1 != null && lst1.Count > 0)
                   {
                       sbJSON.Append(",\"state\":\"expand\",");   //closed
                       sbJSON.Append("\"children\":");
                       GetEasyuiComboTreeJson(lst1);
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
       public void GetMyList(List<ArticleType> list, ref List<ArticleType> newList, int step, int parentId)
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
           foreach (ArticleType atype in list)
           {
               if (atype.ParentId == parentId)
               {
                   int n = newList.Count;
                   newList.Add(atype);
                   newList[n].ArticleTypeName = _Step + atype.ArticleTypeName;
                   newList[n].ArticleTypeId = atype.ArticleTypeId;
                   newList[n].OrderIndex = atype.OrderIndex;
                   newList[n].ParentId = atype.ParentId;
                   newList[n].IsDelete = atype.IsDelete;
                   newList[n].Status = atype.Status;
                   int newstep = step + 1;
                   GetMyList(list, ref newList, newstep, Convert.ToInt32(atype.ArticleTypeId));
               }
           }
       }


       #endregion


       #region 根据文章分类获取分类名称

       /// <summary>
       /// 根据文章分类获取分类名称
       /// </summary>
       /// <param name="channelType">文章表中的分类（传入的数据形式为空或者 如：,1,2,3,   即两端都有逗号隔开）</param>
       /// <returns></returns>
       public string[] GetArticleTypeNameList(string articleType)
       {
           string[] strArr = null;
           string str = String.Empty;
           List<string> list = new List<string>();
           if (!string.IsNullOrEmpty(articleType))
           {
               articleType = articleType.Substring(1, articleType.Length - 2);
               strArr = articleType.Split(',');
           }

           if (strArr != null && strArr.Length > 0)
           {
               foreach (string channelId in strArr)
               {
                   str = SelectById(Convert.ToInt32(channelId)).ArticleTypeName;
                   list.Add(str);
               }
           }
           if (list.Count == 0)
           {
               list[0] = " ";
           }

           return list.ToArray();
       }

       #endregion

       



       #endregion        
 
      #region 业务逻辑层基本方法

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ArticleType">ArticleType实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Add(ArticleType model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="ArticleType">ArticleType实体对象</param>
        /// <returns>int值,返回自增ID</returns>
        public int AddReturnId(ArticleType model)
        {
            return dal.AddReturnId(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ArticleType">ArticleType实体对象</param>
        /// <returns>bool值,判断是否操作成功</returns>
        public bool Change(ArticleType model)
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
        public List<ArticleType> SelectAll()
        {
            return dal.SelectAll();
        }

        /// <summary>
        /// 通过Id查询
        /// </summary>
        /// <param name="Id">主键Id</param>
        public ArticleType SelectById(int Id)
        {
            return dal.SelectById(Id);
        }

        /// <summary>
        /// 通过条件查询
        /// </summary>
        /// <param name="WhereString">查询条件</param>
        public List<ArticleType> SelectByWhere(string WhereString)
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
        public List<ArticleType> SelectByWhereAndPage(string WhereString,int PageIndex,int PageSize,string OrderString,out int TotalCount)
        {
            return dal.SelectByWhereAndPage(WhereString , PageIndex , PageSize , OrderString, out TotalCount);
        }

        
 
      #endregion


    }
}

