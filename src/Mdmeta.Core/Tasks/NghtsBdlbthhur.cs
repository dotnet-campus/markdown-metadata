using System.IO;

namespace Mdmeta.Tasks
{
    public class NghtsBdlbthhur
    {
        public NghtsBdlbthhur(StreamReader stream, string str)
        {
            Stream = stream;
            Str = str;
        }

        public StreamReader Stream { get; set; }

        /// <summary>
        /// 原来的一行
        /// </summary>
        public string Str { get; set; }

        /// <summary>
        /// 之后的处理是否继续
        /// </summary>
        public bool Handle { get; set; }

        /// <summary>
        /// 转换得到的文字
        /// </summary>
        public string Text { get; set; } = "";

    }
}