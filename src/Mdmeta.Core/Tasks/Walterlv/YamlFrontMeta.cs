using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace Mdmeta.Tasks.Walterlv
{
    public sealed class YamlFrontMeta
    {
        [YamlMember(Alias = "title", ApplyNamingConventions = false)]
        public string Title { get; set; }

        [YamlMember(Alias = "date", ApplyNamingConventions = false)]
        public string Date { get; set; }

        [YamlMember(Alias = "publishDate", ApplyNamingConventions = false)]
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
        
        public string CurrentVersion => string.IsNullOrWhiteSpace(Version) ? Current : Version;

        [YamlMember(Alias = "current", ApplyNamingConventions = false)]
        public string Current { get; set; }

        [YamlMember(Alias = "version", ApplyNamingConventions = false)]
        public string Version { get; set; }

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
