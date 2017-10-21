using System.Collections.Generic;

namespace Mdmeta.Tasks
{
    /// <summary>
    /// 正文与摘要分割
    /// </summary>
    public class Excerpt
    {
        public Excerpt(IReadOnlyList<string> srcExcerptSeparator, string excerptSeparator)
        {
            if (srcExcerptSeparator == null)
            {
                srcExcerptSeparator = new List<string>()
                {
                    "<!--more-->","---"
                };
            }
            SrcExcerptSeparator = srcExcerptSeparator;
            ExcerptSeparator = excerptSeparator;
        }

        /// <summary>
        /// 原文可能使用分割
        /// </summary>
        public IReadOnlyList<string> SrcExcerptSeparator { get; }

        /// <summary>
        /// 输出的分割
        /// </summary>
        public string ExcerptSeparator { get; }
    }
}