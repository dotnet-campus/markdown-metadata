using System;

using dotnetCampus.Cli;

using Mdmeta.Tasks.Walterlv;

using Walterlv.BlogTransformer.Tasks;

namespace Walterlv.BlogTransformer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CommandLine.Parse(args)
                    .AddHandler<InitTask>(t => t.Run())
                    .AddHandler<UpdateTask>(t => t.Run())
                    .AddHandler<CsdnTask>(t => t.Run())
                    .Run();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ResetColor();
            }
        }
    }
}
