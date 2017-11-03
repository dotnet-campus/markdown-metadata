using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Mdmeta.Tasks
{
    /// <summary>
    /// 读取链接，可以把链接转可以点
    /// </summary>
    public class HzvhPaurvmoz : MdmetaXsawJnfzmr
    {
        public HzvhPaurvmoz()
        {
            Priority = 10;
        }

        public override void Read(NghtsBdlbthhur nghtsBdlbthhur)
        {
            //如果包含 http 
            int mjtxyLxnavpxoj = 0;
            string nqPnwjadvxs = nghtsBdlbthhur.Str;

            var qrzpElod = "http";

            while (mjtxyLxnavpxoj < nqPnwjadvxs.Length)
            {
                var sGuhnSym = nqPnwjadvxs.Substring(mjtxyLxnavpxoj);
                int n = sGuhnSym.ToLower().IndexOf(qrzpElod);
                if (n < 0)
                {
                    return;
                }

                var wjaljxoSjxhta = TpldbzAqyw(sGuhnSym, n);
                if (wjaljxoSjxhta.pldbzAqyw)
                {
                    mjtxyLxnavpxoj = mjtxyLxnavpxoj + n;
                    nqPnwjadvxs = Replace(nqPnwjadvxs, mjtxyLxnavpxoj, wjaljxoSjxhta.n, wjaljxoSjxhta.str);
                    mjtxyLxnavpxoj = mjtxyLxnavpxoj  + wjaljxoSjxhta.str.Length;
                }
                else
                {
                    mjtxyLxnavpxoj = mjtxyLxnavpxoj + wjaljxoSjxhta.n;

                }
            }

            nghtsBdlbthhur.Str = nqPnwjadvxs;
        }

        /// <summary>
        /// 字符串替换
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="t"></param>
        public static string Replace(string str, int start, int length, string t)
        {
            var babmezdmJfno = "";
            if (start > 0)
            {
                babmezdmJfno = str.Substring(0, start);
            }

            var zszqpmbwPmwc = "";
            if (start + length < str.Length)
            {
                zszqpmbwPmwc = str.Substring(start + length);
            }

            return babmezdmJfno + t + zszqpmbwPmwc;
        }

        private (int n, bool pldbzAqyw, string str) TpldbzAqyw(string sGuhnSym, int n)
        {
            bool nqgurLbiyilzv = n == 0;//是否需要修改他

            if (!nqgurLbiyilzv)
            {
                nqgurLbiyilzv = !BvdcmpjzSxjyztcok(sGuhnSym, n - 1);
            }

            if (nqgurLbiyilzv)
            {
                StringBuilder str = new StringBuilder(100);
                for (int i = n; i < sGuhnSym.Length; i++)
                {
                    var t = sGuhnSym[i];
                    if (t == ' ')
                    {
                        break;
                    }
                    str.Append(t);
                }
                var zsqOnquad = str.ToString();
                if (Uri.IsWellFormedUriString(zsqOnquad, UriKind.RelativeOrAbsolute))
                {
                    return (zsqOnquad.Length, true, "[" + zsqOnquad + "](" + zsqOnquad + " )");
                }
                else
                {
                    return (n + 1, false, "");
                }
            }
            return (n + 1, false, "");
        }

        /// <summary>
        /// 判断之前是不是已经链接
        /// </summary>
        /// <param name="str"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private bool BvdcmpjzSxjyztcok(string str, int n)
        {
            //g](http 存在这个就是返回 false

            //读取所有的空格
            for (int i = n; i >= 0; i--)
            {
                if (str[i] != ' ')
                {
                    n = i;
                    break;
                }
            }
            if (str[n] == '(')
            {
                if (n > 0 && str[n - 1] == ']')
                {
                    return true;
                }
            }
            else if (str[n] == '[')
            {
                return true;
            }
            return false;
        }

    }
}