using System;
using System.Diagnostics;
using System.IO;

using dotnetCampus.Cli;

using Walterlv.BlogTransformer.Blogs;
using Walterlv.BlogTransformer.Core;

using static Walterlv.BlogTransformer.Blogs.MdmetaUtils;

namespace Walterlv.BlogTransformer.Tasks
{
    /// <summary>
    /// 将所有的 md 文件按照 YAML 元数据设置文件属性。
    /// </summary>
    [Verb("init")]
    internal sealed class InitTask : CommandLineTask
    {
        /// <summary>
        /// 要初始化 md 文件属性的文件夹。（如果不指定，则会自动查找。）
        /// </summary>
        [Option("Directory")]
        public string FolderName { get; set; }

        public override void Run()
        {
            var folderName = FindPostFolder(FolderName);
            var folder = new DirectoryInfo(Path.GetFullPath(folderName));

            Console.WriteLine("初始化文件时间：");
            var watch = new Stopwatch();
            watch.Start();
            var index = 1;
            foreach (var file in folder.EnumerateFiles("*.md", SearchOption.AllDirectories))
            {
                Console.WriteLine($"{index.ToString().PadLeft(3, ' ')} {file.FullName}");
                index++;
                InitFile(file);
            }
            watch.Stop();
            Console.WriteLine($"耗时：{watch.Elapsed}");
        }

        private void InitFile(FileInfo file)
        {
            var frontMatter = PostMeta.FromFile(file);
            if (frontMatter == null)
            {
                OutputOn("    没有 YAML 元数据。", ConsoleColor.Yellow);
                return;
            }

            var dateString = frontMatter.Date;
            var publishDateString = frontMatter.PublishDate ?? dateString;

            if (!string.IsNullOrWhiteSpace(dateString))
            {
                var date = DateTimeOffset.Parse(dateString);
                var publishDate = DateTimeOffset.Parse(publishDateString);

                Console.WriteLine($"    创建于 {publishDate}，更新于 {date}。");
                FixFileDate(file, publishDate, date);
            }
            else
            {
                OutputOn("    YAML 元数据中没有发现时间。", ConsoleColor.Yellow);
            }
        }

        private void FixFileDate(FileInfo file, DateTimeOffset createdTime, DateTimeOffset modifiedTime)
        {
            file.CreationTimeUtc = createdTime.UtcDateTime;
            file.LastWriteTimeUtc = modifiedTime.UtcDateTime;
            file.LastAccessTimeUtc = DateTimeOffset.Now.UtcDateTime;
        }
    }
}
