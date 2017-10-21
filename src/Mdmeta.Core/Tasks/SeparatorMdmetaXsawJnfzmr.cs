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
            Priority = 100;
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
                        nghtsBdlbthhur.Text = str.Replace(temp, Excerpt.ExcerptSeparator) + Line;
                        _replaceExcerpt = true;
                        nghtsBdlbthhur.Handle = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Get or Set Excerpt
        /// </summary>
        public Excerpt Excerpt { get; set; }

        /// <summary>
        /// 是否已经替换
        /// </summary>
        private bool _replaceExcerpt
        {
            set => ReadCsfLvi = !value;
            get => ReadCsfLvi;
        }
    }
}