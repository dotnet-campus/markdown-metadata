using System;
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
                foreach (var file in folder.EnumerateFiles("*.md", SearchOption.AllDirectories))
                {
                    UpdateFile(file);
                }
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


        }
    }
}
