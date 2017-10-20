using Mdmeta.Core;
using Microsoft.Extensions.CommandLineUtils;

namespace Mdmeta
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            // Initialize basic command options.
            var app = new CommandLineApplication
            {
                Name = "mdmeta"
            };
            app.HelpOption("-?|-h|--help");
            app.VersionOption("--version", "0.1");
            app.OnExecute(() =>
            {
                // If the user gives no arguments, show help.
                app.ShowHelp();
                return 0;
            });

            // Config command line from command tasks assembly.
            app.ReflectFrom(typeof(CommandTask).Assembly);

            // Execute the app.
            var exitCode = app.Execute(args);
            return exitCode;
        }
    }
}
