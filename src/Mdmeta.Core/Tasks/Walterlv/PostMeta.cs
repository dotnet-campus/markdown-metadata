using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;

namespace Mdmeta.Tasks.Walterlv
{
    public static class PostMeta
    {
        public static YamlFrontMeta Read(FileInfo file)
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
    }
}
