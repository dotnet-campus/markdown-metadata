using Mdmeta.Core;
using System.IO;
using static Mdmeta.Tasks.Walterlv.MdmetaUtils;
using static Mdmeta.Tasks.Walterlv.MarkdownPoster;

namespace Mdmeta.Tasks.Walterlv
{
    [CommandMetadata("wimage", Description = "将 Markdown 文件中的图片上传。")]
    public class ImageTask : CommandTask
    {
        [CommandArgument("[file]", Description = "要转换格式的文件的完全限定路径。")]
        public string FileName { get; set; }

        [CommandOption("-b|--image-base-path", Description = "图片在本地文件系统中的基地址。")]
        public string ImageBasePath { get; set; }

        public override int Run()
        {
            if (!File.Exists(FileName))
            {
                OutputError("文件不存在。");
                return 4;
            }

            UploadLocalImages(FileName, ImageBasePath);
            return 0;
        }
    }
}
