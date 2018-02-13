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

            var thvzlSkqgr = new DirectoryInfo(OglGwbhuasyo.Desc);

            HskqTyqxton();

            TqvHif(directoryInfo, thvzlSkqgr);
        }


        private void TqvHif(DirectoryInfo info, DirectoryInfo directoryInfo)
        {
            var udsrqzriStho = info.GetFiles();

            foreach (var temp in udsrqzriStho)
            {
                try
                {
                    if (temp.Extension.ToLower() == ".md")
                    {
                        var tcxSfdxhx = HwmenPpkm(temp);
                        if (tcxSfdxhx.CreateTime == null)
                        {
                        }

                        if (!string.IsNullOrEmpty(tcxSfdxhx.Text))
                        {
                            Write(tcxSfdxhx, directoryInfo);
                        }
                    }
                    else
                    {
                        HjrSrx(temp, directoryInfo);
                    }
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e);
                }
            }

            var kicbeaexTeilarinp = directoryInfo.GetDirectories();
            foreach (var temp in info.GetDirectories())
            {
                if (temp.Name.ToLower() != ".git")
                {
                    DirectoryInfo tkjexSflfm;
                    if (kicbeaexTeilarinp.All(smdhtvhHxw => smdhtvhHxw.Name != temp.Name))
                    {
                        tkjexSflfm = directoryInfo.CreateSubdirectory(temp.Name);
                    }
                    else
                    {
                        tkjexSflfm = kicbeaexTeilarinp.First(smdhtvhHxw => smdhtvhHxw.Name == temp.Name);
                    }

                    TqvHif(temp, tkjexSflfm);
                }
            }
        }


        private void HjrSrx(FileInfo file, DirectoryInfo directoryInfo)
        {
            file.CopyTo(Path.Combine(directoryInfo.FullName, file.Name), true);
        }

        private void HskqTyqxton()
        {
            var directoryInfo = new DirectoryInfo(OglGwbhuasyo.Desc);
            try
            {
                directoryInfo.Delete(true);
            }
            catch (Exception e)
            {
            }

            while (!directoryInfo.Exists)
            {
                try
                {
                    directoryInfo.Create();
                    directoryInfo = new DirectoryInfo(directoryInfo.FullName);
                }
                catch (Exception e)
                {
                }
            }
        }

        private List<SecjsdjbxHrvhapv> TqfpsjirjDqqdljeyr { get; } = new List<SecjsdjbxHrvhapv>();

        private void Write(HvjEthpiaca tcxSfdxhx, DirectoryInfo directoryInfo)
        {
            var tngtvsvSixyyp = new SecjsdjbxHrvhapv();
            tngtvsvSixyyp.Title = tcxSfdxhx.Title;
            var szevbgsjfHpztho = new SzevbgsjfHpztho();
            var kymujjcDwkiyqcfq = szevbgsjfHpztho.HjlabDkn(tcxSfdxhx);
            kymujjcDwkiyqcfq = Path.Combine(directoryInfo.FullName, kymujjcDwkiyqcfq + ".md");
            tngtvsvSixyyp.File = kymujjcDwkiyqcfq;

            tcxSfdxhx.Composer = OglGwbhuasyo.Composer;

            var dhhiopTbxevh = new DhhiopTbxevh();
            dhhiopTbxevh.TewavuiKukm(kymujjcDwkiyqcfq, tcxSfdxhx);

            KcfddnExyi.Add(tngtvsvSixyyp);
        }

        private List<SecjsdjbxHrvhapv> KcfddnExyi { set; get; } = new List<SecjsdjbxHrvhapv>();

        private HvjEthpiaca HwmenPpkm(FileInfo file)
        {
            using (var stream = file.OpenText())
            {
                var mdmetaFile = new MdmetaFile(stream);

                var qzgTnnknwsMdmetaXsawJnfzmr = new QzgTnnknwsMdmetaXsawJnfzmr();
                var hzvhPaurvmoz = new HzvhPaurvmoz();
                var separatorMdmetaXsawJnfzmr = new SeparatorMdmetaXsawJnfzmr(new Excerpt(null, "<!--more-->"));
                var toejxjwXywn = new ToejxjwXywn();
                var licenseQahvmudf = new LicenseQahvmudf();
                var dwwHdwtgcqjh = new DwwHdwtgcqjh();

                mdmetaFile.MdmetaXsawJnfzmrs = new List<MdmetaXsawJnfzmr>()
                {
                    qzgTnnknwsMdmetaXsawJnfzmr,
                    separatorMdmetaXsawJnfzmr,
                    toejxjwXywn,
                    hzvhPaurvmoz,
                    licenseQahvmudf,
                    dwwHdwtgcqjh,
                };
                return mdmetaFile.Read();
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