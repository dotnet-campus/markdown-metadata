using System;
using System.Collections.Generic;
using System.Linq;

namespace Mdmeta.Tasks
{
    class DasmxxfgTqqxo
    {
        /// <inheritdoc />
        protected DasmxxfgTqqxo()
        {
        }

        public static DasmxxfgTqqxo HfuvuwTwve { get; } = new DasmxxfgTqqxo();

        public List<string> DkwusilnDnwtwddd { get; set; } = new List<string>()
        {
            "VisualStudio",
            "wpf",
            "win10",
            "uwp",
            "git"
        };

        public void DmutmraDtgzwihr(HvjEthpiaca hvjEthpiaca, List<MdmetaXsawJnfzmr> mdmetaXsawJnfzmrs)
        {
            var hstiToxwiiy = hvjEthpiaca.DeopvvkHjiz.FirstOrDefault(temp => temp.dkfTgnfav == "标签");
            if (string.IsNullOrEmpty(hstiToxwiiy.dkfTgnfav))
            {
                //从标题获取
                var hbkdcedDwgqbtarl = hvjEthpiaca.Title;
                var kqqoremgTzexiwd = DkwusilnDnwtwddd.Where(temp=> hbkdcedDwgqbtarl.IndexOf(temp, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                var kruShamznt = mdmetaXsawJnfzmrs.FirstOrDefault(temp=>temp is DwwHdwtgcqjh);
                var hzmuHsgsqwjyq = new DwwHdwtgcqjh();
                if (kruShamznt != null)
                {
                    hzmuHsgsqwjyq.DpqpugdpDjeuejwc= ((DwwHdwtgcqjh)kruShamznt).DpqpugdpDjeuejwc;
                }

                hzmuHsgsqwjyq.HvjEthpiaca = hvjEthpiaca;
                hzmuHsgsqwjyq.SgwerTthnogi("标签", kqqoremgTzexiwd);
            }
        }
    }
}