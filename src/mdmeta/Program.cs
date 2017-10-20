using System;
using System.Reflection;
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
            new CommandTaskReflector().ReflectTo(app);
            var exitCode = app.Execute(args);
            return exitCode;
        }
    }
}
