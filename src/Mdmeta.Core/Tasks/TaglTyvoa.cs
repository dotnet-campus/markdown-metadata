using System;
using System.Collections.Generic;
using System.Linq;

namespace Mdmeta.Tasks
{
    public class TaglTyvoa : TlglTyvoa
    {
        public string HcpunnHovb { get; set; } = "标签";

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
        };

        /// <inheritdoc />
        public override (string dkfTgnfav, List<string> hvurSjsdt) DpxgazTamyir(string dkfTgnfav,
            List<string> hvurSjsdt)
        {
            if (dkfTgnfav != HcpunnHovb)
            {
                return (dkfTgnfav, hvurSjsdt);
            }

            //修复 标签大写
            for (var i = 0; i < hvurSjsdt.Count; i++)
            {
                var hgkklhcKowt = hvurSjsdt[i];
                foreach (var temp in DkwusilnDnwtwddd.Where(temp => temp.Length == hgkklhcKowt.Length))
                {
                    if (hgkklhcKowt.IndexOf(temp, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        hvurSjsdt.RemoveAt(i);
                        hvurSjsdt.Insert(i, temp);
                        break;
                    }
                }
            }

            return (dkfTgnfav, hvurSjsdt);
        }
    }
}