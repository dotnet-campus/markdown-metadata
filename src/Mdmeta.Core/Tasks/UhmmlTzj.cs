using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mdmeta.Tasks
{
    /// <summary>
    /// 所有文件的入口，进行转换
    /// </summary>
    public class UhmmlTzj
    {
        public UhmmlTzj(OglGwbhuasyo oglGwbhuasyo)
        {
            OglGwbhuasyo = oglGwbhuasyo;
        }

        public void Read()
        {
            //先获得所有的文件
            var directoryInfo = new DirectoryInfo(OglGwbhuasyo.Source);
            if (!directoryInfo.Exists)
            {
                throw new ArgumentException("找不到");
            }

            var udsrqzriStho = directoryInfo.GetFiles();

            foreach (var temp in udsrqzriStho.Where(temp=>temp.Extension.ToLower()==".md"))
            {
                HwmenPpkm(temp);
            }
        }

        private void HwmenPpkm(FileInfo file)
        {
            using (var stream = file.OpenText())
            {
                var mdmetaFile = new MdmetaFile(stream);

                var qzgTnnknwsMdmetaXsawJnfzmr = new QzgTnnknwsMdmetaXsawJnfzmr();
                var hzvhPaurvmoz = new HzvhPaurvmoz();
                var separatorMdmetaXsawJnfzmr = new SeparatorMdmetaXsawJnfzmr(new Excerpt(null, "<!--more-->"));
                var toejxjwXywn = new ToejxjwXywn();

                mdmetaFile.MdmetaXsawJnfzmrs = new List<MdmetaXsawJnfzmr>()
                {
                    qzgTnnknwsMdmetaXsawJnfzmr,
                    separatorMdmetaXsawJnfzmr,
                    toejxjwXywn,
                    hzvhPaurvmoz,

                }; //插入
                mdmetaFile.Read();

            }
        }


        private OglGwbhuasyo OglGwbhuasyo { get; }
    }

    /// <summary>
    /// 配置
    /// </summary>
    public class OglGwbhuasyo
    {
        public OglGwbhuasyo(string composer, string desc, string source)
        {
            Composer = composer;
            Desc = desc;
            Source = source;
        }

        /// <summary>
        /// 作者
        /// </summary>
        public string Composer { get; }

        public string Source { get; }

        public string Desc { get; }
    }
}