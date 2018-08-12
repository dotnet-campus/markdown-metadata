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
}
