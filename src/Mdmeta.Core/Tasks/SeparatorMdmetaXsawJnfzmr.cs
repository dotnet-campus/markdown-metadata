using System.IO;
using System.Linq;
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
            Priority = 10;
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

            if (!string.IsNullOrEmpty(nghtsBdlbthhur.Str))
            {
                Text.Append(nghtsBdlbthhur.Str + Line);
            }

            nghtsBdlbthhur.Handle = true;
        }

        public override void HgvaHhloe()
        {
            if (ReadCsfLvi)
            {
                HvjEthpiaca.Text = Text.ToString();
            }

            base.HgvaHhloe();
        }

        private void KwfTndf()
        {
            using (StringReader stream = new StringReader(HvjEthpiaca.Text))
            {
                while (stream.Peek() < HvjEthpiaca.Text.Length)
                {
                    var str = stream.ReadLine();

                    if (!string.IsNullOrEmpty(str))
                    {
                        var hkkjtatjaDluavcig = str;

                        if (hkkjtatjaDluavcig.Length > 200)
                        {
                            HvjEthpiaca.Excerpt = hkkjtatjaDluavcig.Substring(0, 200);
                        }
                    }
                }
            }
        }


        private StringBuilder Text { set; get; } = new StringBuilder();

        /// <summary>
        /// Get or Set Excerpt
        /// </summary>
        public Excerpt Excerpt { get; set; }
    }
}