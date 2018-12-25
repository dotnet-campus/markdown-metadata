using System;
using static Mdmeta.Tasks.Walterlv.MdmetaUtils;

namespace Mdmeta.Tasks.Walterlv
{
    internal static class OutputCountExtensions
    {
        internal static void Output(this (int, int) result, string output, string fallback)
        {
            var (count, totalCount) = result;
            if (count == 0)
            {
                Console.WriteLine(fallback);
            }
            else
            {
                OutputOn(string.Format(output, count, totalCount), ConsoleColor.Green);
            }
        }
    }
}
