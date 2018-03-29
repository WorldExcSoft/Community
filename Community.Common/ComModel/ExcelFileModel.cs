using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Community.Common
{
    /// <summary>
    /// excel转换为实体信息
    /// </summary>
   public class ExcelFileModel
    {
        //图片信息
        public List<PicturesInfo> PicList { get; set; }
        //文字信息
        public DataTable InfoList { get; set; }

        public int Code { get; set; }

        public string Msg { get; set; }
        //保存的路径
        public string SavePath { get; set; }
    }
}
