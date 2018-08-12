using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Mdmeta.Core;

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

        private static Dictionary<string, string> ReadFrontMatter(FileInfo file)
        {
            bool? containsYamlMatter = null;
            var frontMatter = new Dictionary<string, string>();

            using (var fileStream = file.OpenRead())
            using (var reader = new StreamReader(fileStream, Encoding.UTF8, true))
            {
                var lineIndex = 0;
                var keyDepth = 0;
                var line = reader.ReadLine()?.Trim();


                while (line != null)
                {
                    if (containsYamlMatter == null)
                    {
                        if (line == "---")
                        {
                            containsYamlMatter = true;
                            continue;
                        }

                        containsYamlMatter = false;
                        break;
                    }

                    if (containsYamlMatter is true)
                    {
                        var splitIndex = line.IndexOf(':');
                        if (splitIndex > 0)
                        {
                            var key = line.Substring(0, splitIndex).Trim();
                            if (splitIndex + 1 < line.Length)
                            {
                                // key: value
                                var value = line.Substring(splitIndex + 1).Trim();
                                frontMatter[key] = value;
                            }
                            else
                            {
                                // key:
                                //   value
                                keyDepth++;
                            }
                        }
                        else
                        {
                            
                        }

                        throw new NotSupportedException($"在 YAML 元数据中没有找到 key。文件 {file.FullName}，行 {lineIndex + 1}。");
                    }
                }
            }

            return frontMatter;
        }
    }
}
