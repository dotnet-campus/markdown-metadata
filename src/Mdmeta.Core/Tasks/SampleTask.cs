#if DEBUG
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Mdmeta.Core;

namespace Mdmeta.Tasks
{
    /// <summary>
    /// This is a sample that helps you to write your own command task.
    /// In this sample, user can use command like these:
    /// - mdmeta echo
    ///   - Hi!
    /// - mdmeta echo "Hello Markdown Metadata!"
    ///   - Hello Markdown Metadata!
    /// - mdmeta echo "Hello!" -r 3
    ///   - Hello!Hello!Hello!
    /// - mdmeta echo "Hello!" --repeat-count=3 -s " " -s "|"
    ///   - Hello! Hello!|Hello!
    /// </summary>
    [CommandMetadata("echo",
        Description = "Output users command at specified format.")]
    public sealed class SampleTask : CommandTask
    {
        private int _repeatCount;

        /// <summary>
        /// Gets or sets users words that will be output.
        /// It may be null if the user doesn't pass this option.
        /// </summary>
        [CommandArgument("[words]",
            Description = "The words the user wants to output.")]
        public string Words { get; set; }

        /// <summary>
        /// Gets or sets a value that indicate how many times to output the users words.
        /// It may be null if the user doesn't pass this option.
        /// </summary>
        [CommandOption("-r|--repeat-count",
            Description = "Indicates how many times to output the users words.")]
        public string RepeatCountRaw
        {
            get => _repeatCount.ToString();
            set => _repeatCount = value == null ? 1 : int.Parse(value);
        }

        /// <summary>
        /// Gets or sets a value. It indicates that whether all words should be output in upper case.
        /// If the user passes the option, it will be false; otherwise it will be true.
        /// </summary>
        [CommandOption("--upper",
            Description = "Indicates that whether all words shoule be in upper case.")]
        public bool UpperCase { get; set; }

        /// <summary>
        /// Gets or sets a list. All items in the list specify a seperator or each repeat.
        /// If a CommandOption is a List{string}, it will never be null.
        /// </summary>
        [CommandOption("-s|--seperator",
            Description = "Speficy a string to split each repeat.")]
        public List<string> Seperators { get; set; }

        public override int Run()
        {
            if (string.IsNullOrWhiteSpace(Words) || _repeatCount < 0)
            {
                Console.WriteLine("Hi!");
                return 0;
            }

            string output;
            if (_repeatCount == 1)
            {
                output = Words;
            }
            else if (!Seperators.Any())
            {
                output = string.Join(Environment.NewLine, Enumerable.Repeat(Words, _repeatCount));
            }
            else
            {
                var builder = new StringBuilder();
                var index = 0;
                var i = 0;
                foreach (var repeat in Enumerable.Repeat(Words, _repeatCount))
                {
                    builder.Append(repeat);
                    if (i++ < _repeatCount - 1)
                    {
                        builder.Append(Seperators[index]);
                        index = (index + 1) % Seperators.Count;
                    }
                }
                output = builder.ToString();
            }
            Console.WriteLine(UpperCase ? output.ToUpper(CultureInfo.CurrentCulture) : output);
            return 0;
        }
    }
}
#endif
