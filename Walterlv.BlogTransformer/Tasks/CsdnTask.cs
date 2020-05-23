using System;
using System.IO;
using System.Text.RegularExpressions;

using dotnetCampus.Cli;

using Walterlv.BlogTransformer.Core;

using static Walterlv.BlogTransformer.Blogs.MdmetaUtils;
using static Walterlv.BlogTransformer.Blogs.MarkdownPoster;
using Walterlv.BlogTransformer.Utils;
using System.Collections.Generic;
using System.Linq;
using Walterlv.BlogTransformer.Blogs;

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
        [Value(0), Option('f', "Files")]
        public IList<string> Files { get; set; }

        /// <summary>
        /// 转换后的文件需要放到这个文件夹。
        /// </summary>
        [Option('o', "OutputDirectory")]
        public string OutputDirectory { get; set; }

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
            if (Files is null)
            {
                throw new ArgumentException("必须指定要转换的文件。", nameof(Files));
            }

            if (OutputDirectory is null)
            {
                throw new ArgumentException("必须指定转换的目标文件。", nameof(OutputDirectory));
            }

            var outputDirectory = new DirectoryInfo(OutputDirectory);
            foreach (var file in Files.Select(x=> new FileInfo(Path.GetFullPath(x))))
            {
                var (title, text) = TransformToCsdn(file.FullName);
                if (text is null || string.IsNullOrWhiteSpace(text))
                {
                    continue;
                }

                title = title?.Replace('/', ' ')?.Replace('\\', ' ');
                var newFileName = Path.Combine(outputDirectory.FullName, $"{title}.md");
                File.WriteAllText(newFileName, text);
            }
        }

        public (string? title, string? content) TransformToCsdn(string fileName)
        {
            if (!File.Exists(fileName))
            {
                OutputError($"文件 {fileName} 不存在。");
                return (null, null);
            }

            Console.WriteLine($"将 {fileName} 转换为 CSDN 格式：");

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

            var frontMatter = PostMeta.FromFile(new FileInfo(fileName));
            var a1 = text.Substring(3);
            var a2 = a1.Substring(a1.IndexOf("---") + 4);
            return (frontMatter.Title, a2);
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
