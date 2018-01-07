using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Mdmeta.Tasks
{
    /// <summary>
    /// 用于过滤文字
    /// </summary>
    public class TextFilter
    {
        /// <summary>
        /// 违禁的词语
        /// </summary>
        public List<string> Violate { get; set; }

        /// <summary>
        /// 白名单
        /// </summary>
        public List<string> Wiolate { get; set; }

        /// <summary>
        /// 删除前后词语
        /// </summary>
        public int RemoveCharacte { set; get; }

        /// <summary>
        /// 过滤违禁词语
        /// </summary>
        /// <param name="str"></param>
        public string Filter(string str)
        {
            var ret = new StringBuilder(str.Length);
            using (var stringReader = new StringReader(str))
            {
                while ((str = stringReader.ReadLine()) != null)
                {
                    ret.Append(RhbjZuiez(str) + "\r\n");
                }
            }
            return ret.ToString();
        }

        private string RhbjZuiez(string str)
        {
            foreach (var temp in Violate)
            {
                int n = str.IndexOf(temp);
                if (n > 0)
                {
                    int t = n - RemoveCharacte;
                    if (t < 0)
                    {
                        t = 0;
                    }

                    int t2 = n + temp.Length + RemoveCharacte;
                    if (t2 > str.Length)
                    {
                        t2 = str.Length;
                    }

                    str = str.Substring(0, t) + str.Substring(t2);
                }
            }
            return str;
        }
    }
}
