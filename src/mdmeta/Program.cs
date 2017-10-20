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
            app.OnExecute(() =>
            {
                app.ShowHelp();
                return 0;
            });
            CommandTaskReflector.ReflectTo(typeof(CommandTask).Assembly, app);
            var exitCode = app.Execute(args);
            return exitCode;
        }
    }
}
