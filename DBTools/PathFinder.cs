using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTools
{
    class PathFinder
    {
        /// <summary>
        /// 回傳指定路徑上n層的絕對路徑
        /// </summary>
        /// <param name="path">指定路徑</param>
        /// <param name="upLevel">上n層</param>
        /// <returns></returns>
        public static string GetUpLevelDirectory(string path, int upLevel)
        {
            var directory = File.GetAttributes(path).HasFlag(FileAttributes.Directory)
                ? path
                : Path.GetDirectoryName(path);

            upLevel = upLevel < 0 ? 0 : upLevel;

            for (var i = 0; i < upLevel; i++)
            {
                directory = Path.GetDirectoryName(directory);
            }

            return directory;
        }
    }
}
