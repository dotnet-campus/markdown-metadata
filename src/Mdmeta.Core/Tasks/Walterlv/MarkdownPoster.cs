using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static Mdmeta.Tasks.Walterlv.MdmetaUtils;

namespace Mdmeta.Tasks.Walterlv
{
    public class MarkdownPoster
    {
        public static void UploadLocalImages(string markdownFile, string imageBasePath)
        {
            var file = new FileInfo(markdownFile);

            var text = File.ReadAllText(file.FullName, Encoding.UTF8);
            //                           |  非 <!-- 开头 |  取 ！[ ] 部分  |      取 ( ) 部分
            var imageRegex = new Regex(@"(?<!\<\!\-\-\s?)!\[(?<name>.+)\]\((?<path>/static/posts/[\d-]+\.png)\)");
            var matches = imageRegex.Matches(text);
            int count = 0;
            foreach (Match match in matches)
            {
                var name = match.Groups["name"].Value;
                var path = match.Groups["path"].Value;

                var server = new Smms();
                var localImagePath = Path.GetFullPath(imageBasePath + path);
                if (!File.Exists(localImagePath))
                {
                    Console.WriteLine(
                        $"{count.ToString().PadLeft(2, ' ')}. " +
                        $"{path} 已经是网络图片，无需上传。");
                    count++;
                    continue;
                }

                Console.Write(
                    $"{count.ToString().PadLeft(2, ' ')}. " +
                    $"{name} ");
                try
                {
                    Console.CursorLeft = 4;
                    var uploadedUrl = server.UploadAsync(localImagePath).Result.Url;
                    Console.WriteLine($"{path} 已上传至 {uploadedUrl} 。");

                    text = text.Replace(match.Value, $@"<!-- {match.Value} -->
{match.Value.Replace(path, uploadedUrl)}");
                }
                catch (Exception ex)
                {
                    OutputError($"{path} 上传失败：{ex.Message}");
                }

                count++;
            }

            File.WriteAllText(file.FullName, text, Encoding.UTF8);
        }
    }
}
