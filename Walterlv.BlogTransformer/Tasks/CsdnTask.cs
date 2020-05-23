using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using dotnetCampus.Cli;

using Walterlv.BlogTransformer.Core;

using static Walterlv.BlogTransformer.Blogs.MdmetaUtils;
using static Walterlv.BlogTransformer.Blogs.MarkdownPoster;
using Walterlv.BlogTransformer.Utils;

namespace Mdmeta.Tasks.Walterlv
{
    /// <summary>
    /// 将文件转换为 CSDN 博客能原生支持的 Markdown 格式。
    /// </summary>
    [Verb("csdn")]
    internal class CsdnTask : CommandLineTask
    {
        /// <summary>
        /// 要转换格式的文件的完全限定路径。
        /// </summary>
        [Option("File")]
        public string FileName { get; set; }

        /// <summary>
        /// 图片在本地文件系统中的基地址。
        /// </summary>
        [Option('b', "ImageBasePath")]
        public string ImageBasePath { get; set; }

        /// <summary>
        /// 如果指定将此图片 url 换成绝对路径，那么将不会上传本地路径，而是拼接路径。
        /// </summary>
        [Option('i', "ImageExistedUrl")]
        public string ImageExistedUrl { get; set; }

        /// <summary>
        /// 相对路径的博客需要添加的网址。
        /// </summary>
        [Option('s', "SiteUrl")]
        public string SiteUrl { get; set; }

        /// <summary>
        /// 知识共享协议的 Markdown 文件路径。
        /// </summary>
        [Option('l', "LicenseFile")]
        public string LicenseFile { get; set; }

        public override void Run()
        {
            var fileName = Path.GetFullPath(FileName);
            if (!File.Exists(fileName))
            {
                OutputError($"文件 {FileName} 不存在。");
                return;
            }

            Console.WriteLine($"将 {FileName} 转换为 CSDN 格式：");

            var originalText = File.ReadAllText(fileName);
            var license = File.ReadAllText(LicenseFile);
            var text = originalText;

            if (!string.IsNullOrWhiteSpace(ImageExistedUrl))
            {
                text = ReplaceLocalImagesToUrl(text, ImageExistedUrl).Output("[1] 已替换图片 {0} / {1} 张。", "[1] 无需上传图片。");
            }
            else
            {
                text = UploadLocalImages(text, ImageBasePath).Output("[1] 已上传图片 {0} / {1} 张。", "[1] 无需上传图片。");
            }
            text = ReplaceToc(text).Output("[2] 已替换目录为 TOC。", "[2] 无需替换目录。");
            text = ReplaceSelfSites(text, SiteUrl).Output("[3] 已替换 {0} / {1} 个博客路径。", "[3] 无需替换博客路径。");
            text = AppendLicense(text, license).Output("[4] 已添加知识共享许可协议", "[4] 无需添加知识共享许可协议。");

            if (text != originalText)
            {
                File.WriteAllText(fileName, text, Encoding.UTF8);
            }
        }

        private static (string newText, int replacedCount, int totalCount) ReplaceToc(
            string originalText)
        {
            if (originalText.Contains(@"<div id=""toc""></div>"))
            {
                var text = originalText.Replace(@"<div id=""toc""></div>", "@[TOC](本文内容)");
                return (text, 1, 1);
            }

            if (originalText.Contains(@"@[TOC](本文内容)"))
            {
                return (originalText, 0, 1);
            }

            return (originalText, 0, 0);
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
