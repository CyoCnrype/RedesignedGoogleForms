using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace DBTools
{
    public class logger
    {
        //public static string logPath;
        public static string logPath
        {
            get {
                string thisFilePath = HttpContext.Current.Server.MapPath("~/");   //取得自己.aspx的路徑
                string thisFilePathFather = PathFinder.GetUpLevelDirectory(thisFilePath, 2) + "\\Data\\Logs\\";   //找上2層，Logs
                thisFilePathFather = thisFilePathFather + "Log.log";
                return thisFilePathFather; 
            }
        }

        public static void WriteLog(Exception ex)
        {
            string msg = $@"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
                        {ex.ToString()}
                ";

            //string logPath = ("C:\\Logs\\FinalProject\\Log.log");
            string folderPath = System.IO.Path.GetDirectoryName(logPath);

            if (!System.IO.Directory.Exists(folderPath))
                System.IO.Directory.CreateDirectory(folderPath);

            if (!System.IO.File.Exists(logPath))
                System.IO.File.Create(logPath);

            System.IO.File.AppendAllText(logPath, msg);

            throw ex;
        }
    }


}
