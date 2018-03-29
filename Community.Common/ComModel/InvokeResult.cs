using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Community.Common
{
    public class InvokeResult
    {
        public InvokeResult()
        {
        }
        public InvokeResult(ResultStatus resultStatus)
        {
            code = resultStatus;
        }
        /// <summary>
        /// 结果状态
        /// </summary>
        public ResultStatus code { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int count { get; set; }
        
        /// <summary>
        /// 返回数据
        /// </summary>
        public object data { get; set; }
    }

    public enum ResultStatus
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 0,
        /// <summary>
        /// 失败
        /// </summary>
        Failure = 1,
        /// <summary>
        /// 重复
        /// </summary>
        Repetition=2
    }
}