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

        [CommandOption("-l|--license-file", Description = "知识共享协议的 Markdown 文件路径。")]
        public string LicenseFile { get; set; }

        public override int Run()
        {
            var fileName = Path.GetFullPath(FileName);
            if (!File.Exists(fileName))
            {
                OutputError($"文件 {FileName} 不存在。");
                return 4;
            }

            Console.WriteLine($"将 {FileName} 转换为 CSDN 格式：");

            var originalText = File.ReadAllText(fileName);
            var license = File.ReadAllText(LicenseFile);
            var text = originalText;

            text = UploadLocalImages(text, ImageBasePath).Output("[1] 已上传图片 {0} / {1} 张。", "[1] 无需上传图片。");
            text = ReplaceToc(text).Output("[2] 已替换目录为 TOC。", "[2] 无需替换目录。");
            text = ReplaceSelfSites(text, SiteUrl).Output("[3] 已替换 {0} / {1} 个博客路径。", "[3] 无需替换博客路径。");
            text = AppendLicense(text, license).Output("[4] 已添加知识共享许可协议", "[4] 无需添加知识共享许可协议。");

            if (text != originalText)
            {
                File.WriteAllText(fileName, text, Encoding.UTF8);
            }

            return 0;
        }

        private static (string newText, int replacedCount, int totalCount) ReplaceToc(
            string originalText)
        {
            var text = originalText.Replace(@"<div id=""toc""></div>", "@[TOC](本文内容)");
            var count = text == originalText ? 0 : 1;
            return (text, count, 1);
        }

        private static (string newText, int replacedCount, int totalCount) ReplaceSelfSites(
            string text, string siteUrl)
        {
            var imageRegex = new Regex(@"\[.+\]\(/post/[\w\-\.]+\)");
            var matches = imageRegex.Matches(text);
            var count = 0;

            foreach (Match match in matches)
            {
                text = text.Replace(
                    match.Value,
                    match.Value.Replace("](/post/", $"]({siteUrl}/post/"));
                count++;
            }

            return (text, count, count);
        }

        private static (string newText, int replacedCount, int totalCount) AppendLicense(
            string originalText, string license)
        {
            if (originalText.Contains("知识共享许可协议"))
            {
                return (originalText, 0, 1);
            }

            var text = $@"{originalText}{license}";
            return (text, 1, 1);
        }
    }
}
