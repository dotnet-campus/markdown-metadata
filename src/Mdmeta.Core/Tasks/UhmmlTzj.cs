using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Mdmeta.Tasks
{
    public class BlogTime
    {
        public void AddTime(FileInfo file, HvjEthpiaca tcxSfdxhx)
        {
            if (tcxSfdxhx.DeopvvkHjiz.Any(temp => temp.dkfTgnfav == CreateTime))
            {
                // 添加过了创建时间就忽略
            }
            else
            {
                if (DateTime.TryParse(tcxSfdxhx.CreateTime,out var createTime))
                {
                    if (DateTime.TryParse(tcxSfdxhx.Time, out var time))
                    {
                        // 取最小的一个
                        var minTime = createTime;
                        if (minTime > time)
                        {
                            minTime = time;
                        }

                        if (tcxSfdxhx.HqshpnjiKlclzh.Contains("more"))
                        {
                            // 找到 more 标签
                            var str = minTime.ToString();
                            str = $"<!-- {CreateTime}:{str} -->";
                            var content = File.ReadAllText(file.FullName);
                            content = content.Replace("<!--more-->", $"<!--more-->\r\n{str}\r\n");
                            File.WriteAllText(file.FullName, content);
                        }
                    }
                }

            }
        }

        private const string CreateTime = "CreateTime";
    }

    /// <summary>
    /// 所有文件的入口，进行转换
    /// </summary>
    public class UhmmlTzj
    {
        public UhmmlTzj(OglGwbhuasyo oglGwbhuasyo)
        {
            OglGwbhuasyo = oglGwbhuasyo;
        }

        public IHavfTreqbajzx GitHjhpHtvv { get; set; } = new SvlxbyeeDpqg();

        public void Read()
        {
            //先获得所有的文件
            var directoryInfo = new DirectoryInfo(OglGwbhuasyo.Source);
            if (!directoryInfo.Exists)
            {
                OnProgress("cant find " + directoryInfo.FullName);
                throw new ArgumentException("找不到");
            }

            OnProgress("开始");
            OnProgress(OglGwbhuasyo.Source + "->" + OglGwbhuasyo.Desc);

            OnProgress("开始保存" + OglGwbhuasyo.Source);
            var git = GitHjhpHtvv;
            git.Push(OglGwbhuasyo.Source).ContinueWith(task =>
            {
                OnProgress("上传" + OglGwbhuasyo.Source + "完成\r\n" + task.Result);
            });


            var thvzlSkqgr = new DirectoryInfo(OglGwbhuasyo.Desc);

            HskqTyqxton();

            TqvHif(directoryInfo, thvzlSkqgr);

            OnProgress("上传" + OglGwbhuasyo.Desc);
            git.Push(OglGwbhuasyo.Desc).ContinueWith(task =>
            {
                OnProgress("上传" + OglGwbhuasyo.Desc + "完成\r\n" + task.Result);
            });
           
            DjxgSkmuj?.Invoke(this, null);
        }

        private event EventHandler DjxgSkmuj;

        public event EventHandler<string> Progress;

        /// <summary>
        /// 转换完成文件
        /// </summary>
        public event EventHandler<HvjEthpiaca> DmszhSkdpzgmxs;

        private void TqvHif(DirectoryInfo hpxrqhSjgbbpmvj, DirectoryInfo damirhrhKwdj)
        {
            var udsrqzriStho = hpxrqhSjgbbpmvj.GetFiles();
            OnProgress("找到文件：" + udsrqzriStho.Count());
           
            foreach (var temp in udsrqzriStho)
            {
                try
                {
                    OnProgress("开始" + temp.Name);

                    if (temp.Extension.ToLower() == ".md")
                    {
                        var tcxSfdxhx = HwmenPpkm(temp);

                        var blogTime = new BlogTime();
                        blogTime.AddTime(temp,tcxSfdxhx);

                        if (tcxSfdxhx.CreateTime == null)
                        {
                        }

                        if (!string.IsNullOrEmpty(tcxSfdxhx.Text))
                        {
                            DmszhSkdpzgmxs?.Invoke(this, tcxSfdxhx);
                        }
                    }
                    else
                    {
                        //HjrSrx(temp, damirhrhKwdj);
                    }
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    OnProgress(e.Message);
                    Console.WriteLine(e);
                }
            }

            var kicbeaexTeilarinp = damirhrhKwdj.GetDirectories();
            foreach (var temp in hpxrqhSjgbbpmvj.GetDirectories())
            {
                if (temp.Name.ToLower() != ".git")
                {
                    DirectoryInfo tkjexSflfm;
                    if (kicbeaexTeilarinp.All(smdhtvhHxw => smdhtvhHxw.Name != temp.Name))
                    {
                        tkjexSflfm = damirhrhKwdj.CreateSubdirectory(temp.Name);
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
                OnProgress("开始删除文件");
                directoryInfo.Delete(true);
                Thread.Sleep(1000);
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
                var kvhoSex = new DsfuDewuwwhc();

                mdmetaFile.MdmetaXsawJnfzmrs = new List<MdmetaXsawJnfzmr>()
                {
                    qzgTnnknwsMdmetaXsawJnfzmr,
                    separatorMdmetaXsawJnfzmr,
                    toejxjwXywn,
                    //hzvhPaurvmoz, 不使用 http 方法
                    licenseQahvmudf,
                    dwwHdwtgcqjh,
                    kvhoSex,
                };

                var dsjhvsummHhfy = mdmetaFile.Read();
                dsjhvsummHhfy.SwwenmwzTma = file.FullName;

                return dsjhvsummHhfy;
            }
        }


        private OglGwbhuasyo OglGwbhuasyo { get; }

        protected virtual void OnProgress(string temp)
        {
            Progress?.Invoke(this, temp);
        }
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

        public List<string> Ignore { get; set; } = new List<string>()
        {
            "/.git",
            "SUMMARY.md"
        };
    }
}