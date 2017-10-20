using Mdmeta.Core;
using Microsoft.Extensions.CommandLineUtils;

namespace Mdmeta
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "mdmeta"
            };
            app.HelpOption("-?|-h|--help");
            app.VersionOption("--version", "0.1");
            app.OnExecute(() =>
            {
                app.ShowHelp();
                return 0;
            });
            app.ReflectFrom(typeof(CommandTask).Assembly);
            var exitCode = app.Execute(args);
            return exitCode;
        }
    }
}
