using System;
using System.IO;

namespace Mdmeta.Tasks.Walterlv
{
    public static class MdmetaUtils
    {
        public static void OutputError(string message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = color;
        }

        public static string FindPostFolder(string specifiedFolderArgument)
        {
            string folderName;
            if (specifiedFolderArgument == null)
            {
                if (File.Exists("_config.yml"))
                {
                    folderName = "_posts";
                }
                else if (File.Exists("config.yaml") || File.Exists("config.boml"))
                {
                    folderName = "content";
                }
                else
                {
                    throw new ArgumentException(@"没有找到 Hugo 或者 Jekyll 的静态页面目录，你可能需要手工指定一个。
示例： mdmeta winit ./posts");
                }
            }
            else
            {
                folderName = specifiedFolderArgument;
            }

            return folderName;
        }
    }
}
