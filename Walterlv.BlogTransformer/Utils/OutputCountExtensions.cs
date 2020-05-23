using System;

using static Walterlv.BlogTransformer.Blogs.MdmetaUtils;

namespace Walterlv.BlogTransformer.Utils
{
    internal static class OutputCountExtensions
    {
        internal static T Output<T>(this (T, int, int) result, string output, string fallback)
        {
            var (r, count, totalCount) = result;

            if (count == 0)
            {
                Console.WriteLine(fallback);
            }
            else
            {
                OutputOn(string.Format(output, count, totalCount), ConsoleColor.Green);
            }

            return r;
        }
    }
}
