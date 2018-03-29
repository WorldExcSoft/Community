using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web; 

namespace Community.Common
{
    public class FileHelper
    {
        public static bool JudgeFileExist(string url)
        {
            try
            {
                //创建根据网络地址的请求对象
                System.Net.HttpWebRequest httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.CreateDefault(new Uri(url));
                httpWebRequest.Method = "HEAD";
                httpWebRequest.Timeout = 1000;
                //返回响应状态是否是成功比较的布尔值
                return (((System.Net.HttpWebResponse)httpWebRequest.GetResponse()).StatusCode == System.Net.HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }

        public static ExcelFileModel ExcleFileToDataTable(HttpPostedFileBase file,string serverPath)
        {
            ExcelFileModel model = new ExcelFileModel();
            //文件名
            var fileName = file.FileName;
            if (string.Empty.Equals(fileName))
            {
                model.Code = 1;
                model.Msg = "文件不能为空！";
                return model;
            }
            //后缀名
            var fileextension = fileName.Substring(fileName.LastIndexOf('.'));
            //获取新文件名
            var uuid = Guid.NewGuid().ToString();
            var newFileName = uuid + fileextension;
            var savepath = Path.Combine(serverPath, newFileName);

            //1、保存excel文件
            file.SaveAs(savepath);
            //2、读取excel文件
            FileStream fs = new FileStream(savepath, FileMode.Open, FileAccess.Read);
            IWorkbook book = new XSSFWorkbook(fs);
            ISheet sheet = book.GetSheet(book.GetSheetName(0));
            //读取图片
            List<PicturesInfo> list = new List<PicturesInfo>();
            list = NpoiExtend.GetAllPictureInfos(sheet);
            //读取文字
            DataTable dt = new DataTable();
            ExcelHelper excelHelper = new ExcelHelper(file.FileName, savepath);
            dt = excelHelper.ExcelToDataTable("sheet1", true);

            model.Code = 0;
            model.PicList = list;
            model.InfoList = dt;
            model.SavePath = savepath;
            return model;
        }
    }
}
