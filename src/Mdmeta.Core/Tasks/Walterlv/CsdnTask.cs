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

            UploadLocalImages(FileName, ImageBasePath);
            ReplaceWithExternalResources(FileName, SiteUrl);

            return 0;
        }

        private static void ReplaceWithExternalResources(string markdownFile, string siteUrl)
        {
            var file = new FileInfo(markdownFile);
            var text = File.ReadAllText(file.FullName, Encoding.UTF8);
            text = text.Replace(@"<div id=""toc""><div>", "@[TOC](本文内容)");

            var imageRegex = new Regex(@"\[.+\]\(/post/[\w\-]+\.html\)");
            var matches = imageRegex.Matches(text);
            int count = 0;
            foreach (Match match in matches)
            {
                text = text.Replace(
                    match.Value,
                    match.Value.Replace("](/post/", $"]({siteUrl}/post/"));
            }
        }
    }
}
