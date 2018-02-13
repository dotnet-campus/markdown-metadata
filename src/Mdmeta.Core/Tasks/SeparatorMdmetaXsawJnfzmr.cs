using System.Text;

namespace Mdmeta.Tasks
{
    public class SeparatorMdmetaXsawJnfzmr : MdmetaXsawJnfzmr
    {
        /// <summary>
        /// 转换分割
        /// </summary>
        /// <param name="excerpt"></param>
        public SeparatorMdmetaXsawJnfzmr(Excerpt excerpt)
        {
            Excerpt = excerpt;
            Priority = 1;
        }

        public override void Read(NghtsBdlbthhur nghtsBdlbthhur)
        {
            var str = nghtsBdlbthhur.Str;

            //当前是否是分割
            foreach (var temp in Excerpt.SrcExcerptSeparator)
            {
                var n = str.IndexOf(temp);
                if (n == 0)
                {
                    if (string.IsNullOrWhiteSpace(str.Replace(temp, "")))
                    {
                        HvjEthpiaca.Excerpt = Text.ToString() + "\r\n" + Excerpt.ExcerptSeparator + "\r\n";

                        nghtsBdlbthhur.Handle = true;
                        ReadCsfLvi = false;
                        return;
                    }
                }
            }

            if(!string.IsNullOrEmpty(nghtsBdlbthhur.Str))
            {
                Text.Append(nghtsBdlbthhur.Str + Line);
            }

            nghtsBdlbthhur.Handle = true;
        }

        private StringBuilder Text { set; get; } = new StringBuilder();

        /// <summary>
        /// Get or Set Excerpt
        /// </summary>
        public Excerpt Excerpt { get; set; }
    }
}