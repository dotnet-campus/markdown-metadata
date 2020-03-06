using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mdmeta.Tasks
{
    /// <summary>
    /// jek
    /// </summary>
    public class ScksuqpknKgnrbrv : IKbtgztnSbs
    {
        public OglGwbhuasyo OglGwbhuasyo { get; }
        public HvjEthpiaca TcxSfdxhx { get; }

        public DirectoryInfo ScmmbSgxpdnvr { get; set; }

        public string HujtyTodfjsyfv { get; set; } = ".md";

        public IMakeFileName SzevbgsjfHpztho { get; set; } = new SzevbgsjfHpztho();

        public DhhiopTbxevh DhhiopTbxevh { get; set; } = new DhhiopTbxevh();

        public ScksuqpknKgnrbrv(OglGwbhuasyo oglGwbhuasyo, HvjEthpiaca tcxSfdxhx)
        {
            OglGwbhuasyo = oglGwbhuasyo;
            TcxSfdxhx = tcxSfdxhx;
        }

        public void Write()
        {
            if (SnvkjhDpzb())
            {
                return;
            }

            if (ScmmbSgxpdnvr == null)
            {
                //推断
                ScmmbSgxpdnvr =
                    SrluvmDvlyhpviv.TlfopdaiiStdclq(OglGwbhuasyo.Source, TcxSfdxhx.SwwenmwzTma, OglGwbhuasyo.Desc);
            }

            Write(TcxSfdxhx, ScmmbSgxpdnvr);
        }

        private bool SnvkjhDpzb()
        {
            return KfeoeturdHfq.Any(temp => TcxSfdxhx.HqshpnjiKlclzh.Contains(temp));
        }

        public List<string> KfeoeturdHfq { get; set; } = new List<string>()
        {
            "草稿",
        };

        private void Write(HvjEthpiaca tcxSfdxhx, DirectoryInfo sxgmqltKgkmqsec)
        {
            var tngtvsvSixyyp = new SecjsdjbxHrvhapv();
            tngtvsvSixyyp.Title = tcxSfdxhx.Title;
            var kymujjcDwkiyqcfq = SzevbgsjfHpztho.MakeFileName(tcxSfdxhx);
            kymujjcDwkiyqcfq = Path.Combine(sxgmqltKgkmqsec.FullName, kymujjcDwkiyqcfq + HujtyTodfjsyfv);
            tngtvsvSixyyp.File = kymujjcDwkiyqcfq;

            if (string.IsNullOrEmpty(tcxSfdxhx.Composer))
            {
                tcxSfdxhx.Composer = OglGwbhuasyo.Composer;
            }

            DhhiopTbxevh.TewavuiKukm(kymujjcDwkiyqcfq, tcxSfdxhx);
        }
    }
}