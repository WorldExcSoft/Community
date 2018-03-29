using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Community.Common
{
    public class SaveHelper
    {
        public static RemoteJsonModel SavePictureToServer(HttpPostedFileBase file,int type,string name)
        {
            var curFile = file;
            var fileName = curFile.FileName;
            var fileExtension = fileName.Substring(fileName.LastIndexOf('.'));
            byte[] b = new byte[curFile.ContentLength];
            Stream fs = curFile.InputStream;
            fs.Read(b, 0, curFile.ContentLength);
            string postData = string.Empty;
            if (string.IsNullOrWhiteSpace(name))
            {
                postData= "fileRoot=" + ImageType.ToDirectory(type) + "&fileExtension=" + fileExtension + "&data=" + HttpUtility.UrlEncode(Convert.ToBase64String(b));
            }
            else
            {
                postData = "fileRoot=" + ImageType.ToDirectory(type) + "&name="+name + "&fileExtension=" + fileExtension + "&data=" + HttpUtility.UrlEncode(Convert.ToBase64String(b));
            }
            var webclient = new WebClient();
            webclient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            string remoteUrl = GlobalVars.PathRootSave;
            byte[] buffer = webclient.UploadData(remoteUrl, "POST", byteArray);
            var msg = Encoding.UTF8.GetString(buffer);
            var data = JsonHelper.ParseJSON<RemoteJsonModel>(msg);
            return data;
        }
        public static RemoteJsonModel SaveCoursePictureToServer(byte[] b, int type, string name)
        {
            byte[] c = new byte[b.Length];
            Stream stream = new MemoryStream(c);
            stream.Read(c, 0, b.Length);
            string postData = "fileRoot=" + ImageType.ToDirectory(type) + "&name=" + name + "&data=" + HttpUtility.UrlEncode(Convert.ToBase64String(c));
            var webclient = new WebClient();
            webclient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            string remoteUrl = GlobalVars.PathRootSave;
            byte[] buffer = webclient.UploadData(remoteUrl, "POST", byteArray);
            var msg = Encoding.UTF8.GetString(buffer);
            var data = JsonHelper.ParseJSON<RemoteJsonModel>(msg);
            return data;
        }
    }
}
