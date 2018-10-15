using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Mdmeta.Core;
using static Mdmeta.Tasks.Walterlv.MdmetaUtils;

namespace Mdmeta.Tasks.Walterlv
{
    [CommandMetadata("wupdate", Description = "根据文件的修改时间更新 YAML 元数据中的更新时间。")]
    public sealed class UpdateTask : CommandTask
    {
        [CommandArgument("[folder]", Description = "要初始化 md 文件属性的文件夹。（如果不指定，则会自动查找。）")]
        public string FolderName { get; set; }

        [CommandOption("-t|--ignore-in-hour", Description = "当修改时间与发布时间间隔在指定的小时数以内时，只更新发布时间。")]
        public string IgnoreInHour { get; set; }

        public override int Run()
        {
            try
            {
                var folderName = FindPostFolder(FolderName);
                var folder = new DirectoryInfo(Path.GetFullPath(folderName));
                var count = 0;

                Console.WriteLine("更新文件时间：");
                var watch = new Stopwatch();
                watch.Start();
                foreach (var file in folder.EnumerateFiles("*.md", SearchOption.AllDirectories))
                {
                    var updated = UpdateFile(file);
                    count += updated ? 1 : 0;
                }

                watch.Stop();
                Console.Write($"耗时：{watch.Elapsed}，");
                if (count > 0)
                {
                    OutputOn($"总计更新 {count} 个。", ConsoleColor.Green);
                }
                else
                {
                    Console.WriteLine($"总计更新 {count} 个。");
                }

                return 0;
            }
            catch (Exception ex)
            {
                OutputError(ex.Message);
                return 1;
            }
        }

        private bool UpdateFile(FileInfo file)
        {
            var frontMatter = PostMeta.FromFile(file);
            if (frontMatter == null) return false;

            var dateString = frontMatter.Date;

            if (!string.IsNullOrWhiteSpace(dateString))
            {
                var date = DateTimeOffset.Parse(dateString);

                var writeTime = file.LastWriteTimeUtc.ToUniversalTime();
                var roundWriteTime = new DateTimeOffset(
                    writeTime.Year, writeTime.Month, writeTime.Day,
                    writeTime.Hour, writeTime.Minute, writeTime.Second, TimeSpan.Zero);
                if (roundWriteTime != date.ToUniversalTime())
                {
                    var splitted = UpdateMetaTime(file, frontMatter, writeTime);
                    // 更新文件的最近写入时间，在此前的时间上额外添加 10ms，以便编辑器或其他软件能够识别到文件变更。
                    var fileLastWriteTime = writeTime + TimeSpan.FromMilliseconds(10);
                    if (splitted)
                    {
                        var fileCreationTime = DateTimeOffset.Parse(
                            frontMatter.PublishDate ?? frontMatter.Date).UtcDateTime;
                        file.CreationTimeUtc = fileCreationTime;
                        file.LastWriteTimeUtc = fileLastWriteTime;
                    }
                    else
                    {
                        file.CreationTimeUtc = fileLastWriteTime;
                        file.LastWriteTimeUtc = fileLastWriteTime;
                    }

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 更新 Markdown Metadata 元数据。
        /// </summary>
        /// <param name="file"></param>
        /// <param name="frontMatter"></param>
        /// <param name="date"></param>
        /// <returns>
        /// 如果更新后日期已分为发布和更新日期，则返回 true；否则返回 false。
        /// </returns>
        private bool UpdateMetaTime(FileInfo file, YamlFrontMeta frontMatter, DateTimeOffset date)
        {
            var originalDateString = frontMatter.Date;
            var newDateString = date.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss zz00");

            if (string.IsNullOrWhiteSpace(frontMatter.PublishDate))
            {
                if (double.TryParse(IgnoreInHour, out var ignoreInHour))
                {
                    var timeSpan = TimeSpan.FromHours(ignoreInHour);
                    var originalDate = DateTimeOffset.Parse(frontMatter.Date);
                    if (date - originalDate < timeSpan)
                    {
                        // 发布时间并没有过去太久，不算作更新。
                        UpdateFrontMatter(file, originalDateString, newDateString, false);
                        return false;
                    }
                }

                // 发布时间过去很久了，现在需要修改。
                UpdateFrontMatter(file, originalDateString, newDateString, true);
                return true;
            }

            // 早已修改过，现在只是再修改而已。
            UpdateFrontMatter(file, originalDateString, newDateString, false);
            return true;
        }

        private void UpdateFrontMatter(FileInfo file, string originalDate, string newDate, bool split)
        {
            Console.WriteLine($"- {file.FullName}");
            var text = File.ReadAllText(file.FullName);
            var builder = new StringBuilder(text);

            if (split)
            {
                // date 和 publishDate 应该分开更新。
                // 适用于不存在 publishDate 时。
                Console.WriteLine($"  publishDate: {originalDate}");
                Console.WriteLine($"  date: {newDate}");
                builder.Replace($"date: {originalDate}", $@"publishDate: {originalDate}
date: {newDate}");
            }
            else
            {
                // 只更新 date。
                // 适用于存在 publishDate，或者不存在 publishDate 但无需更新 date 时。
                Console.WriteLine($"  date: {newDate}");
                builder.Replace($"date: {originalDate}", $@"date: {newDate}");
            }

            File.WriteAllText(file.FullName, builder.ToString());
        }
    }
}
