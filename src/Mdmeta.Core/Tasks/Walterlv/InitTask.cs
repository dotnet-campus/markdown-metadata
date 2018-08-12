using System;
using Mdmeta.Core;

namespace Mdmeta.Tasks.Walterlv
{
    [CommandMetadata("wbuild",
        Description = "Add metadata to markdown files.")]
    public sealed class BuildTask : CommandTask
    {
        [CommandArgument("file",
            Description = "Which file to add markdown.")]
        public string FileOrFolderName { get; set; }

        [CommandOption("--override",
            Description = "Indicate whether to override files that already has front matter or not.")]
        public bool Override { get; set; }

        public override int Run()
        {
            Console.WriteLine($"{FileOrFolderName}");
            return 0;
        }
    }
}
