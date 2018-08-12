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
        [CommandArgument("folder", Description = "要初始化 md 文件属性的文件夹。")]
        public string FolderName { get; set; }

        public override int Run()
        {
            var folder = new DirectoryInfo(Path.GetFullPath(FolderName));
            foreach (var file in folder.EnumerateFiles("*.md", SearchOption.AllDirectories))
            {
                var frontMatter = ReadFrontMatter(file);
            }

            return 0;
        }

        private static YamlFrontMeta ReadFrontMatter(FileInfo file)
        {
            var yaml = FindYamlFrontMatter(file);

            var deserializer = new Deserializer();
            var matter = deserializer.Deserialize<YamlFrontMeta>(yaml);

            return matter;
        }

        private static string FindYamlFrontMatter(FileInfo file)
        {
            var yamlLines = new List<string>();

            using (var fileStream = file.OpenRead())
            using (var reader = new StreamReader(fileStream, Encoding.UTF8, true))
            {
                bool? containsYamlMatter = null;
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

            var builder = new StringBuilder();
            foreach (var line in yamlLines)
            {
                builder.AppendLine(line);
            }
            return builder.ToString();
        }
    }

    public sealed class YamlFrontMeta
    {
        [YamlMember(Alias = "title", ApplyNamingConventions = false)]
        public string Title { get; set; }

        [YamlMember(Alias = "date", ApplyNamingConventions = false)]
        public string Date { get; set; }

        [YamlMember(Alias = "date_published", ApplyNamingConventions = false)]
        public string PublishDate { get; set; }

        [YamlMember(Alias = "layout", ApplyNamingConventions = false)]
        public string Layout { get; set; }

        [YamlMember(Alias = "permalink", ApplyNamingConventions = false)]
        public string PermanentUrl { get; set; }

        [YamlMember(Alias = "categories", ApplyNamingConventions = false)]
        public string Categories { get; set; }

        [YamlMember(Alias = "tags", ApplyNamingConventions = false)]
        public string Tags { get; set; }

        [YamlMember(Alias = "keywords", ApplyNamingConventions = false)]
        public string Keywords { get; set; }

        [YamlMember(Alias = "description", ApplyNamingConventions = false)]
        public string Description { get; set; }

        [YamlMember(Alias = "version", ApplyNamingConventions = false)]
        public List<VersionInfo> Version { get; set; }

        [YamlMember(Alias = "versions", ApplyNamingConventions = false)]
        public List<VersionsInfo> Versions { get; set; }

        [YamlMember(Alias = "published", ApplyNamingConventions = false)]
        public bool IsPublished { get; set; } = true;

        [YamlMember(Alias = "sitemap", ApplyNamingConventions = false)]
        public bool IsInSiteMap { get; set; } = true;
    }

    public sealed class VersionInfo
    {
        [YamlMember(Alias = "current", ApplyNamingConventions = false)]
        public string Current { get; set; }
    }

    public sealed class VersionsInfo
    {
        [YamlMember(Alias = "中文", ApplyNamingConventions = false)]
        public string Chinese { get; set; }

        [YamlMember(Alias = "English", ApplyNamingConventions = false)]
        public string English { get; set; }

        [YamlMember(Alias = "русский", ApplyNamingConventions = false)]
        public string Sample0 { get; set; }

        [YamlMember(Alias = "繁體中文", ApplyNamingConventions = false)]
        public string Sample1 { get; set; }

        [YamlMember(Alias = "简体中文", ApplyNamingConventions = false)]
        public string Sample2 { get; set; }

        [YamlMember(Alias = "日本語", ApplyNamingConventions = false)]
        public string Sample3 { get; set; }

        [YamlMember(Alias = "ไทย", ApplyNamingConventions = false)]
        public string Sample4 { get; set; }
    }
}
