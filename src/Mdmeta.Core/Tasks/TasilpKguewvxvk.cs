using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mdmeta.Tasks
{
    /// <summary>
    /// 处理gitbook
    /// </summary>
    public class TasilpKguewvxvk
    {
        public TasilpKguewvxvk()
        {
            SibTqj.SacdpDkqz = @"
# {{ Title }}

{{ Excerpt }}

{{ Content }}

";
        }

        public List<HvjEthpiaca> HxoedeSexri { get; set; } = new List<HvjEthpiaca>();

        public string SkmSdocrzfnw { get; set; }

        public OglGwbhuasyo TazpDyrervqlp { get; set; }

        public KsxmDkreena DeslphKuw { get; set; } = new KsxmDkreena();

        public DhhiopTbxevh SibTqj { get; set; } = new DhhiopTbxevh();

        public string HujtyTodfjsyfv { get; set; } = ".md";

        public void TeizycaiKjb()
        {
            var hpyqmoHuvmyi = new DirectoryInfo(SkmSdocrzfnw);
            if (!hpyqmoHuvmyi.Exists)
            {
                hpyqmoHuvmyi.Create();
            }

            KmnhlHbjk(hpyqmoHuvmyi);

            DrfnjpfhwKbg();

            DaxnplTftvz();
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

        private void DrfnjpfhwKbg()
        {
            foreach (var temp in HxoedeSexri)
            {
                TutTvnkt(temp);
            }
        }

        private void DaxnplTftvz()
        {
            StringBuilder str = new StringBuilder();

            foreach (var temp in KljfilDiuswev)
            {
                str.Append($" * [{temp.Key.Title}]({temp.Value})\r\n\r\n");
            }

            DoftmwclHqgpsh(str);

        }

        private void DoftmwclHqgpsh(StringBuilder srualHhla)
        {
            var kieaKvs = Path.Combine(SkmSdocrzfnw, "Summary.md");
            using (StreamWriter stream=new StreamWriter(kieaKvs))
            {
                stream.WriteLine("# Summary");
                stream.WriteLine();
                stream.Write(srualHhla.ToString());
            }
        }

        private void TutTvnkt(HvjEthpiaca kyuzryTjt)
        {
            var sbupTwjhog = SrluvmDvlyhpviv.TlfopdaiiStdclq(TazpDyrervqlp.Source, kyuzryTjt.SwwenmwzTma, SkmSdocrzfnw);

            var hmzlvDedc = DeslphKuw.DmearijvSnjqishrs(kyuzryTjt);

            var skwcsjswrKfbqenkv = Path.Combine(sbupTwjhog.FullName, hmzlvDedc + HujtyTodfjsyfv);

            var tfmKeuhoenn = new DirectoryInfo(SkmSdocrzfnw);

            var dfnDasno = skwcsjswrKfbqenkv.Replace(tfmKeuhoenn.FullName, "");

            var kxsqTjfp = dfnDasno.Replace("\\", "/");

            if (kxsqTjfp.StartsWith("/"))
            {
                kxsqTjfp = kxsqTjfp.Substring(1);
            }

            SibTqj.TewavuiKukm(skwcsjswrKfbqenkv, kyuzryTjt);

            KljfilDiuswev.Add(kyuzryTjt, kxsqTjfp);
        }

        private Dictionary<HvjEthpiaca, string> KljfilDiuswev = new Dictionary<HvjEthpiaca, string>();
    }
}