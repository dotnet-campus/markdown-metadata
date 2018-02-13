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

        public List<MdmetaXsawJnfzmr> MdmetaXsawJnfzmrs { get; set; } = new List<MdmetaXsawJnfzmr>()
        {
            new QzgTnnknwsMdmetaXsawJnfzmr()
        };

        /// <summary>
        /// Get or Set the max word of title
        /// </summary>
        public int TitleMaxWord { get; set; } = 200;

        public StringBuilder Text { get; } = new StringBuilder();

        public HvjEthpiaca Read()
        {
            //获取标题之后，可以获取内容
            //添加进去，继续获取类别
            //获取是否发布
            MdmetaXsawJnfzmrs.Sort((a, b) => -1 * a.Priority.CompareTo(b.Priority));

            var hvjEthpiaca = new HvjEthpiaca();
            hvjEthpiaca.Title = GetTitle();
            foreach (var temp in MdmetaXsawJnfzmrs)
            {
                temp.HvjEthpiaca = hvjEthpiaca;
            }

            while (!Stream.EndOfStream)
            {
                string str = Stream.ReadLine();

                var nghtsBdlbthhur = new NghtsBdlbthhur(Stream, str);

                foreach (var temp in MdmetaXsawJnfzmrs.Where(temp => temp.ReadCsfLvi))
                {
                    temp.Read(nghtsBdlbthhur);
                    Text.Append(nghtsBdlbthhur.Text);
                    if (nghtsBdlbthhur.Handle)
                    {
                        break;
                    }
                }
            }
            hvjEthpiaca.Text = Text.ToString();
            DasmxxfgTqqxo.HfuvuwTwve.DmutmraDtgzwihr(hvjEthpiaca, MdmetaXsawJnfzmrs);
            
            return hvjEthpiaca;
        }

        /// <summary>
        /// Get <see cref="Stream"/> title
        /// </summary>
        /// <returns></returns>
        private string GetTitle()
        {
            //获取第一行或第一个有 # 的一行
            var str = "";
            while (!Stream.EndOfStream)
            {
                str = Stream.ReadLine();
                if (!string.IsNullOrWhiteSpace(str))
                {
                    //如果是 # 
                    if (str[0] == '#')
                    {
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
                    else
                    {
                        break;
                    }
                }
            }
            Stream.BaseStream.Position = 0;

            var file = new FileInfo((Stream.BaseStream as FileStream).Name);

            return file.Name.Replace(file.Extension, "");
        }




        private int ReadTitle(string str)
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
    }
}
