using System;
using System.Diagnostics;
using System.IO;
using Mdmeta.Core;
using static Mdmeta.Tasks.Walterlv.MdmetaUtils;
using static Mdmeta.Tasks.Walterlv.PostMeta;

namespace Mdmeta.Tasks.Walterlv
{
    [CommandMetadata("wupdate", Description = "根据文件的修改时间更新 YAML 元数据中的更新时间。")]
    public sealed class UpdateTask : CommandTask
    {
        [CommandArgument("[folder]", Description = "要初始化 md 文件属性的文件夹。（如果不指定，则会自动查找。）")]
        public string FolderName { get; set; }

        public override int Run()
        {
            try
            {
                var folderName = FindPostFolder(FolderName);
                var folder = new DirectoryInfo(Path.GetFullPath(folderName));

                Console.WriteLine("更新文件时间：");
                var watch = new Stopwatch();
                watch.Start();
                foreach (var file in folder.EnumerateFiles("*.md", SearchOption.AllDirectories))
                {
                    UpdateFile(file);
                }
                watch.Stop();
                Console.WriteLine($"耗时：{watch.Elapsed}");
                return 0;
            }
            catch (Exception ex)
            {
                OutputError(ex.Message);
                return 1;
            }
        }

        private void UpdateFile(FileInfo file)
        {
            var frontMatter = Read(file);
            if (frontMatter == null) return;

            var dateString = frontMatter.Date;

            if (!string.IsNullOrWhiteSpace(dateString))
            {
                var date = DateTimeOffset.Parse(dateString);

                if (file.LastWriteTimeUtc != date)
                {
                    UpdateMetaTime(file, frontMatter, file.LastWriteTimeUtc);
                }
            }
        }

        private void UpdateMetaTime(FileInfo file, YamlFrontMeta frontMatter, DateTimeOffset date)
        {
            Console.WriteLine($"- {file.FullName}");
            if (string.IsNullOrWhiteSpace(frontMatter.PublishDate))
            {
                // 当没有 date 属性时，将原 date 属性改为 date_published，并添加新的 date 属性。

            }
            else
            {
                // 当原来就有 date_published 属性时，更新 date 属性。
            }
        }
    }
}
