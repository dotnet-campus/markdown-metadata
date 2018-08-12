using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Mdmeta.Core;
using YamlDotNet.Serialization;

namespace Mdmeta.Tasks.Walterlv
{
    [CommandMetadata("winit", Description = "将所有的 md 文件按照 YAML 元数据设置文件属性。")]
    public sealed class InitTask : CommandTask
    {
        [CommandArgument("[folder]", Description = "要初始化 md 文件属性的文件夹。（如果不指定，则会自动查找。）")]
        public string FolderName { get; set; }

        public override int Run()
        {
            string folderName;
            if (FolderName == null)
            {
                if (File.Exists("_config.yml"))
                {
                    folderName = "_posts";
                }
                else if (File.Exists("config.yaml") || File.Exists("config.boml"))
                {
                    folderName = "content";
                }
                else
                {
                    OutputError(@"没有找到 Hugo 或者 Jekyll 的静态页面目录，你可能需要手工指定一个。
示例： mdmeta winit ./posts");
                    return 1;
                }
            }
            else
            {
                folderName = FolderName;
            }

            var folder = new DirectoryInfo(Path.GetFullPath(folderName));
            InitFolder(folder);

            return 0;
        }

        private void InitFolder(DirectoryInfo folder)
        {
            foreach (var file in folder.EnumerateFiles("*.md", SearchOption.AllDirectories))
            {
                InitFile(file);
            }
        }

        private void InitFile(FileInfo file)
        {
            var frontMatter = ReadFrontMatter(file);

            if (frontMatter == null)
            {
                return;
            }

            var dateString = frontMatter.Date;
            var publishDateString = frontMatter.PublishDate ?? dateString;

            if (!string.IsNullOrWhiteSpace(dateString))
            {
                var date = DateTimeOffset.Parse(dateString);
                var publishDate = DateTimeOffset.Parse(publishDateString);

                FixFileDate(file, publishDate, date);
            }
        }

        private void FixFileDate(FileInfo file, DateTimeOffset createdTime, DateTimeOffset modifiedTime)
        {
            file.CreationTimeUtc = createdTime.UtcDateTime;
            file.LastWriteTimeUtc = modifiedTime.UtcDateTime;
            file.LastAccessTimeUtc = DateTimeOffset.Now.UtcDateTime;
        }

        private static YamlFrontMeta ReadFrontMatter(FileInfo file)
        {
            var yaml = FindYamlFrontMatter(file);

            if (string.IsNullOrWhiteSpace(yaml))
            {
                return null;
            }

            var deserializer = new Deserializer();
            var matter = deserializer.Deserialize<YamlFrontMeta>(yaml);

            return matter;
        }

        private static string FindYamlFrontMatter(FileInfo file)
        {
            bool? containsYamlMatter = null;
            var yamlLines = new List<string>();

            using (var fileStream = file.OpenRead())
            using (var reader = new StreamReader(fileStream, Encoding.UTF8, true))
            {
                var line = reader.ReadLine()?.Trim();
                while (line != null)
                {
                    if (containsYamlMatter == null)
                    {
                        if (line == "---")
                        {
                            containsYamlMatter = true;
                            line = reader.ReadLine()?.Trim();
                            continue;
                        }

                        containsYamlMatter = false;
                        break;
                    }

                    if (line != "---")
                    {
                        yamlLines.Add(line);
                        line = reader.ReadLine()?.Trim();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (containsYamlMatter is true)
            {
                var builder = new StringBuilder();
                foreach (var line in yamlLines)
                {
                    builder.AppendLine(line);
                }

                return builder.ToString();
            }

            return null;
        }

        private static void OutputError(string message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = color;
        }
    }
}
