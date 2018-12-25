using System;
using System.IO;
using System.Text.RegularExpressions;
using static Mdmeta.Tasks.Walterlv.MdmetaUtils;

namespace Mdmeta.Tasks.Walterlv
{
    public class MarkdownPoster
    {
        public static (string newText, int uploadedCount, int totalCount) UploadLocalImages(
            string originalText, string imageBasePath)
        {
            var uploadCount = 0;
            var text = originalText;
            //                           |  非 <!-- 开头 |  取 ！[ ] 部分  |      取 ( ) 部分
            var imageRegex = new Regex(@"(?<!\<\!\-\-\s?)!\[(?<name>.+)\]\((?<path>/static/posts/[\d-]+\.png)\)");
            var matches = imageRegex.Matches(text);
            var count = 0;
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
                    uploadCount++;

                    text = text.Replace(match.Value, $@"<!-- {match.Value} -->
{match.Value.Replace(path, uploadedUrl)}");
                }
                catch (AggregateException ex)
                {
                    OutputError($"{path} 上传失败：");
                    foreach (var e in ex.Flatten().InnerExceptions)
                    {
                        OutputError($"    - {e.Message}");
                    }
                }
                catch (Exception ex)
                {
                    OutputError($@"{path} 上传失败：
    {ex.Message}");
                }

                count++;
            }

            return (text, uploadCount, count);
        }
    }
}
