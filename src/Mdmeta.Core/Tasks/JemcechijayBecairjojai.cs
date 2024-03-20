using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mdmeta.Tasks
{
    /// <summary>
    /// 找到在 csdn 没有上传的博客，修改为 csdn 格式
    /// </summary>
    public class JemcechijayBecairjojai
    {
        public JemcechijayBecairjojai(OglGwbhuasyo oglGwbhuasyo)
        {
            OglGwbhuasyo = oglGwbhuasyo;

            SibTqj.SacdpDkqz = @"{{ Excerpt }}

<!-- {{ 标签 }} -->

{{ Content }}

我搭建了自己的博客 https://blog.lindexi.com/ 欢迎大家访问，里面有很多新的博客。只有在我看到博客写成熟之后才会放在csdn或博客园，但是一旦发布了就不再更新

如果在博客看到有任何不懂的，欢迎交流，我搭建了 [dotnet 职业技术学院](https://t.me/dotnet_campus) 欢迎大家加入

<a rel=""license"" href=""http://creativecommons.org/licenses/by-nc-sa/4.0/""><img alt=""知识共享许可协议"" style=""border-width:0"" src=""https://licensebuttons.net/l/by-nc-sa/4.0/88x31.png"" /></a><br />本作品采用<a rel=""license"" href=""http://creativecommons.org/licenses/by-nc-sa/4.0/"">知识共享署名-非商业性使用-相同方式共享 4.0 国际许可协议</a>进行许可。欢迎转载、使用、重新发布，但务必保留文章署名[林德熙](http://blog.csdn.net/lindexi_gd)(包含链接:http://blog.csdn.net/lindexi_gd )，不得用于商业目的，基于本文修改后的作品务必以相同的许可发布。如有任何疑问，请与我[联系](mailto:lindexi_gd@163.com)。";
        }

        /// <summary>
        /// 从哪个文件夹读取文件
        /// </summary>
        private OglGwbhuasyo OglGwbhuasyo { get; }

        public uint Limit { set; get; } = uint.MaxValue;

        /// <summary>
        /// 转换的文档格式
        /// </summary>
        public DhhiopTbxevh SibTqj { get; set; } = new DhhiopTbxevh();

        /// <summary>
        /// 转换博客用于上传到 csdn 博客
        /// </summary>
        public void HajaikeewerejoleNelukeajoducarha()
        {
            WhifuqalbawCerkihubere();

            LaydiqokeeJucheregoceljair(new DirectoryInfo(OglGwbhuasyo.Source),new DirectoryInfo(OglGwbhuasyo.Desc) );
        }

        private void WhifuqalbawCerkihubere()
        {
            var gairkerkeldacaWalgearwawji = OglGwbhuasyo.Desc;

            if (Directory.Exists(gairkerkeldacaWalgearwawji))
            {
                KmnhlHbjk(new DirectoryInfo(gairkerkeldacaWalgearwawji));
            }
            else
            {
                Directory.CreateDirectory(gairkerkeldacaWalgearwawji);
            }
        }

        private void KmnhlHbjk(DirectoryInfo duambhnsTrecxp)
        {
            try
            {
                foreach (var temp in duambhnsTrecxp.GetFiles())
                {
                    temp.Delete();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            foreach (var temp in duambhnsTrecxp.GetDirectories())
            {
                KmnhlHbjk(temp);
            }
        }

        private void LaydiqokeeJucheregoceljair(DirectoryInfo source, DirectoryInfo desc)
        {
            var udsrqzriStho = source.GetFiles();
            OnProgress("找到文件：" + udsrqzriStho.Count());

            int count = 0;

            foreach (var temp in udsrqzriStho)
            {
                try
                {
                    OnProgress("开始" + temp.Name);

                    if (temp.Extension.ToLower() == ".md")
                    {
                        var tcxSfdxhx = HwmenPpkm(temp);

                        if (!string.IsNullOrEmpty(tcxSfdxhx.Text))
                        {
                            if (FowuyocawLawayjerewalfahu(tcxSfdxhx))
                            {
                                count++;
                            }

                            if (count == Limit)
                            {
                                break;
                            }
                        }
                    }
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    OnProgress(e.Message);
                    Console.WriteLine(e);
                }
            }
        }

        private bool FowuyocawLawayjerewalfahu(HvjEthpiaca tcxSfdxhx)
        {
            if (tcxSfdxhx.HqshpnjiKlclzh.Any(temp => string.Equals(temp, "csdn", StringComparison.OrdinalIgnoreCase))
                && !tcxSfdxhx.HqshpnjiKlclzh.Any(temp => temp == "不发布" || temp == "草稿"))
            {
                try
                {
                    var file = Path.Combine(OglGwbhuasyo.Desc, $"{tcxSfdxhx.Title}.md");
                    SibTqj.TewavuiKukm(file, tcxSfdxhx);

                    var hebenerbeaLejaldurbunay = "<!-- csdn -->\r\n";
                    var text = File.ReadAllText(tcxSfdxhx.SwwenmwzTma);
                    text = text.Replace(hebenerbeaLejaldurbunay, "");
                    File.WriteAllText(tcxSfdxhx.SwwenmwzTma, text);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// 将文件转换为原数据
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private HvjEthpiaca HwmenPpkm(FileInfo file)
        {
            using (var stream = file.OpenText())
            {
                var mdmetaFile = new MdmetaFile(stream);

                var qzgTnnknwsMdmetaXsawJnfzmr = new QzgTnnknwsMdmetaXsawJnfzmr();
                var hzvhPaurvmoz = new HzvhPaurvmoz();
                var separatorMdmetaXsawJnfzmr = new SeparatorMdmetaXsawJnfzmr(new Excerpt(null, "<!--more-->"));
                var licenseQahvmudf = new LicenseQahvmudf();
                var dwwHdwtgcqjh = new DwwHdwtgcqjh();
                var toejxjwXywn = new ToejxjwXywn();
                var kvhoSex = new DsfuDewuwwhc();

                mdmetaFile.MdmetaXsawJnfzmrs = new List<MdmetaXsawJnfzmr>()
                {
                    qzgTnnknwsMdmetaXsawJnfzmr,
                    separatorMdmetaXsawJnfzmr,
                    //hzvhPaurvmoz, 不使用 http 方法
                    licenseQahvmudf,
                    dwwHdwtgcqjh,
                    // 在 dwwHdwtgcqjh 之后，才可以获取到创建时间
                    toejxjwXywn,
                    kvhoSex,
                };
                var dsjhvsummHhfy = mdmetaFile.Read();
                dsjhvsummHhfy.SwwenmwzTma = file.FullName;
                return dsjhvsummHhfy;
            }
        }

        protected virtual void OnProgress(string temp)
        {
            Progress?.Invoke(this, temp);
        }
        public event EventHandler<string> Progress;
    }

   
}