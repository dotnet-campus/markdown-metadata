using System;
using System.Collections.Generic;
using System.Linq;

namespace Mdmeta.Tasks
{
    public class DasmxxfgTqqxo
    {
        /// <inheritdoc />
        protected DasmxxfgTqqxo()
        {
        }

        public static DasmxxfgTqqxo HfuvuwTwve { get; } = new DasmxxfgTqqxo();

        public List<string> DkwusilnDnwtwddd { get; set; } = new List<string>()
        {
            "VisualStudio",
            "WPF",
            "Win10",
            "UWP",
            "git",
            "dotnet",
            "jekyll",
            "win2d",
            "爬虫",
            "SourceGenerator",
            "OpenXML",
            "WinUI",
            "Avalonia",
            "MAUI",
            "UNO",
            "X11",
            "Roslyn",
            "ReSharper",
            "IIncrementalGenerator",
            "SemanticKernel"
        };

        public List<(string kyizlgozbHiwgxncf, string str)> DqkhwlpaTbz =
            new List<(string kyizlgozbHiwgxncf, string str)>()
            {
                ("C#", "C#"),
                ("C＃", "C#"),
                ("Source Generator", "SourceGenerator"),
                ("ASP.NET Core", "ASP.NETCore"),
            };

        public void DmutmraDtgzwihr(HvjEthpiaca hvjEthpiaca, List<MdmetaXsawJnfzmr> mdmetaXsawJnfzmrs)
        {
            var hstiToxwiiy = hvjEthpiaca.DeopvvkHjiz.FirstOrDefault(temp => temp.dkfTgnfav == "标签");
            if (string.IsNullOrEmpty(hstiToxwiiy.dkfTgnfav))
            {
                //从标题获取
                var hbkdcedDwgqbtarl = hvjEthpiaca.Title;
                var kqqoremgTzexiwd = DkwusilnDnwtwddd
                    .Where(temp => hbkdcedDwgqbtarl.IndexOf(temp, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                kqqoremgTzexiwd.AddRange(DqkhwlpaTbz.Where(temp =>
                        hbkdcedDwgqbtarl.IndexOf(temp.kyizlgozbHiwgxncf, StringComparison.OrdinalIgnoreCase) >= 0)
                    .Select(temp => temp.str));

                var kruShamznt = mdmetaXsawJnfzmrs.FirstOrDefault(temp => temp is DwwHdwtgcqjh);
                var hzmuHsgsqwjyq = new DwwHdwtgcqjh();
                if (kruShamznt != null)
                {
                    hzmuHsgsqwjyq.DpqpugdpDjeuejwc = ((DwwHdwtgcqjh) kruShamznt).DpqpugdpDjeuejwc;
                }

                hzmuHsgsqwjyq.HvjEthpiaca = hvjEthpiaca;
                hzmuHsgsqwjyq.SbqluSsdrhbfb = true;
                hzmuHsgsqwjyq.SgwerTthnogi("标签", kqqoremgTzexiwd);
            }
        }
    }
}