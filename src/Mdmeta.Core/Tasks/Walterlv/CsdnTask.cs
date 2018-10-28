using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Mdmeta.Core;
using static Mdmeta.Tasks.Walterlv.MdmetaUtils;
using static Mdmeta.Tasks.Walterlv.MarkdownPoster;

namespace Mdmeta.Tasks.Walterlv
{
    [CommandMetadata("wcsdn", Description = "将文件转换为 CSDN 博客能原生支持的 Markdown 格式。")]
    public class CsdnTask : CommandTask
    {
        [CommandArgument("[file]", Description = "要转换格式的文件的完全限定路径。")]
        public string FileName { get; set; }

        [CommandOption("-b|--image-base-path", Description = "图片在本地文件系统中的基地址。")]
        public string ImageBasePath { get; set; }

        [CommandOption("-s|--site-url", Description = "相对路径的博客需要添加的网址。")]
        public string SiteUrl { get; set; }

        public override int Run()
        {
            if (!File.Exists(FileName))
            {
                OutputError($"文件 {FileName} 不存在。");
                return 4;
            }

            Console.WriteLine($"将 {FileName} 转换为 CSDN 格式：");

            UploadLocalImages(FileName, ImageBasePath);
            ReplaceWithExternalResources(FileName, SiteUrl);

            return 0;
        }

        private static void ReplaceWithExternalResources(string markdownFile, string siteUrl)
        {
            var file = new FileInfo(markdownFile);
            var originalText = File.ReadAllText(file.FullName, Encoding.UTF8);
            var text = originalText.Replace(@"<div id=""toc""></div>", "@[TOC](本文内容)");
            if (text == originalText)
            {
                Console.WriteLine("无需替换目录。");
            }
            else
            {
                OutputOn("已替换目录。", ConsoleColor.Green);
            }

            var imageRegex = new Regex(@"\[.+\]\(/post/[\w\-]+\.html\)");
            var matches = imageRegex.Matches(text);
            int count = 0;
            foreach (Match match in matches)
            {
                text = text.Replace(
                    match.Value,
                    match.Value.Replace("](/post/", $"]({siteUrl}/post/"));
            }

            if (count == 0)
            {
                Console.WriteLine($"无需替换博客路径。");
            }
            else
            {
                OutputOn($"已替换 {count} 个博客路径。", ConsoleColor.Green);
            }

            if (text != originalText)
            {
                File.WriteAllText(markdownFile, text, Encoding.UTF8);
            }
        }
    }
}
