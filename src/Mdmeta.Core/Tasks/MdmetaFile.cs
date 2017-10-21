using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Mdmeta.Tasks
{

    public class MdmetaFile
    {
        public MdmetaFile(StreamReader stream)
        {
            Stream = stream;
        }

        public StreamReader Stream { get; }

        /// <summary>
        /// Get or Set Excerpt
        /// </summary>
        public Excerpt Excerpt { get; set; }

        /// <summary>
        /// Get or Set the max word of title
        /// </summary>
        public int TitleMaxWord { get; set; } = 20;

        public StringBuilder Text { get; } = new StringBuilder();

        /// <summary>
        /// Get <see cref="Stream"/> title
        /// </summary>
        /// <returns></returns>
        public string GetTitle()
        {
            //获取第一行或第一个有 # 的一行
            var str = "";
            while (!Stream.EndOfStream)
            {
                str = Stream.ReadLine();
                if (!string.IsNullOrWhiteSpace(str))
                {
                    //如果是 # 
                    int n = ReadTitle(str);//如果是 
                    // # 123
                    //返回3
                    if (n <= str.Length)
                    {
                        var t = str.Length - n;
                        t = t > TitleMaxWord ? TitleMaxWord : t;

                        return str.Substring(n, t);
                    }
                }
            }
            return null;
        }

        public string Read()
        {
            var title = GetTitle();
            //获取标题之后，可以获取内容
            while (!Stream.EndOfStream)
            {
                string str = Stream.ReadLine();
                if (!_replaceExcerpt)
                {
                    ReadSeparator(str);
                }
                else
                {
                    Text.Append(str);
                }
            }
            return Text.ToString();
        }

        private void ReadSeparator(string str)
        {
            //当前是否是分割
            foreach (var temp in Excerpt.SrcExcerptSeparator)
            {
                var n = str.IndexOf(temp);
                if (n == 0)
                {
                    if (string.IsNullOrWhiteSpace(str.Replace(temp, "")))
                    {
                        Text.Append(str.Replace(temp, Excerpt.ExcerptSeparator));
                        _replaceExcerpt = true;
                        break;
                    }
                }
            }
        }

        public int ReadTitle(string str)
        {
            const char empty = ' ';
            for (int i = 0; i < str.Length; i++)
            {
                //跳过空格
                if (str[i] != empty && str[i] != '#')
                {
                    return i;
                }
            }
            return 0;
        }

        /// <summary>
        /// 是否已经替换
        /// </summary>
        private bool _replaceExcerpt;
    }
}
