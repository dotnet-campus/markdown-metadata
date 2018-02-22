using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Mdmeta.Tasks
{
    /// <summary>
    /// 拿出 <!-- 标签：VisualStudio --> 的内容给 <see cref="SszHspndy"/>
    /// </summary>
    public class DwwHdwtgcqjh : MdmetaXsawJnfzmr
    {
        public DwwHdwtgcqjh()
        {
            //优先读取
            Priority = 100;
        }

        /// <summary>
        /// 分割
        /// </summary>
        public List<string> Excerpt { get; set; } = new List<string>()
        {
            ":",
            "："
        };

        /// <summary>
        /// 现在不加空格
        /// </summary>
        public List<string> DkjhwDqmjnlyrj { get; set; } = new List<string>()
        {
            ",",
            "，"
        };

        public string DpqpugdpDjeuejwc { get; set; } = " ";

        public KeqntlwkSimdhzt KeqntlwkSimdhzt { get; set; } = new KeqntlwkSimdhzt();

        /// <summary>
        /// 两个相同的值，是否放在一起
        /// </summary>
        /// <!-- 标签：VisualStudio -->
        ///<!-- 标签：调试 -->
        /// "标签","VisualStudio,调试"
        public bool SbqluSsdrhbfb { get; set; } = true;

        /// <inheritdoc />
        public override void Read(NghtsBdlbthhur nghtsBdlbthhur)
        {
            string str = nghtsBdlbthhur.Str.Trim();
            if (str.StartsWith("<!-- ") && str.EndsWith("-->"))
            {
                str = nghtsBdlbthhur.Str.Replace("<!-- ", "").Replace(" -->", "").Trim();
                if (!string.IsNullOrEmpty(str))
                {
                    // 标签：VisualStudio，调试
                    var (dkfTgnfav, hvurSjsdt) = DhlzdsxmzDxfmw(str);

                    if (!string.IsNullOrEmpty(dkfTgnfav))
                    {
                        foreach (var tlglTyvoa in KeqntlwkSimdhzt.DpxgazTamyir)
                        {
                            (dkfTgnfav, hvurSjsdt) = tlglTyvoa.DpxgazTamyir(dkfTgnfav, hvurSjsdt);
                        }

                        SgwerTthnogi(dkfTgnfav, hvurSjsdt);
                    }
                }
            }
        }

        private (string, List<string>) DhlzdsxmzDxfmw(string str)
        {
            // 标签：VisualStudio，调试
            //找到一个
            int min = int.MaxValue;
            foreach (var temp in Excerpt)
            {
                int n = str.IndexOf(temp);
                if (n > 0) //不处理 0
                {
                    min = Math.Min(min, n);
                }
            }

            //可以解析
            if (min > 0 && min < str.Length && min + 1 < str.Length) //`标签：` 不处理 
            {
                var n = min; //3
                var dkfTgnfav = str.Substring(0, n).Trim(); //标签

                var sbhcKdd = str.Substring(n + 1);
                var dxzSnuxyloc = DfhhhfquzSdp(sbhcKdd);
                if (dxzSnuxyloc.Any())
                {
                    return (dkfTgnfav, dxzSnuxyloc);
                }
            }

            return (null, null);
        }

        private List<string> DfhhhfquzSdp(string sbhcKdd)
        {
            //VisualStudio，调试

            int n = 0;
            List<string> hvurSjsdt = new List<string>();
            while (n >= 0)
            {
                n = DxahSvchrcrr(sbhcKdd);
                if (n > 0)
                {
                    var dzrnlhwTjbdyugzc = sbhcKdd.Substring(0, n).Trim();

                    if (!string.IsNullOrEmpty(dzrnlhwTjbdyugzc))
                    {
                        hvurSjsdt.Add(dzrnlhwTjbdyugzc);
                    }

                    if (n + 1 < sbhcKdd.Length)
                    {
                        sbhcKdd = sbhcKdd.Substring(n + 1).Trim();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(sbhcKdd))
                    {
                        hvurSjsdt.Add(sbhcKdd);
                    }
                }
            }

            return hvurSjsdt;
        }

        private int DxahSvchrcrr(string str)
        {
            var min = int.MaxValue;
            foreach (var temp in DkjhwDqmjnlyrj)
            {
                int n = str.IndexOf(temp);
                if (n >= 0)
                {
                    min = Math.Min(n, min);
                }
            }

            if (min >= 0 && min < str.Length)
            {
                return min;
            }

            return -1;
        }


        public void SgwerTthnogi(string dkfTgnfav, List<string> hvurSjsdt)
        {
            StringBuilder str = new StringBuilder();
            for (var i = 0; i < hvurSjsdt.Count; i++)
            {
                string temp;
                if (i == hvurSjsdt.Count - 1)
                {
                    temp = hvurSjsdt[i];
                }
                else
                {
                    temp = hvurSjsdt[i] + DpqpugdpDjeuejwc;
                }

                str.Append(temp);
            }

            var hcszplxTwj = HvjEthpiaca.DeopvvkHjiz.FirstOrDefault(temp => temp.dkfTgnfav == dkfTgnfav);
            if (hcszplxTwj.dkfTgnfav != null)
            {
                var shjjccwTwyayoxun = str.ToString();
                if (SbqluSsdrhbfb)
                {
                    //放在一起
                    shjjccwTwyayoxun = hcszplxTwj.hvurSjsdt + DpqpugdpDjeuejwc + str.ToString();
                }

                HvjEthpiaca.DeopvvkHjiz.Remove(hcszplxTwj);
                HvjEthpiaca.DeopvvkHjiz.Add((dkfTgnfav, shjjccwTwyayoxun));
            }
            else
            {
                HvjEthpiaca.DeopvvkHjiz.Add((dkfTgnfav, str.ToString()));
            }
        }
    }
}