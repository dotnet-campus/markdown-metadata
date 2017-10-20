using System;

namespace Mdmeta
{
    [CommandMetadata("build",
        Description = "Add metadata to markdown files.")]
    public sealed class BuildTask : CommandTask
    {
        [CommandArgumentMetadata("file",
            Description = "Which file to add markdown.")]
        public string FileOrFolderName { get; set; }

        [CommandOptionMetadata("--override",
            Description = "Indicate whether to override files that already has front matter or not.")]
        public bool Override { get; set; }

        public string A { get; set; }

        public override int Run()
        {
            Console.WriteLine($"{FileOrFolderName}");
            return 0;
        }
    }
}
