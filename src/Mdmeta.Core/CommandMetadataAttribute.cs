using System;

namespace Mdmeta
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class CommandMetadataAttribute : Attribute
    {
        public string Name { get; }
        public string Description { get; set; }

        public CommandMetadataAttribute(string commandName)
        {
            Name = commandName;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CommandArgumentMetadataAttribute : Attribute
    {
        public string Name { get; }
        public string Description { get; set; }

        public CommandArgumentMetadataAttribute(string argumentName)
        {
            Name = argumentName;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CommandOptionMetadataAttribute : Attribute
    {
        public string Template { get; }
        public string Description { get; set; }

        public CommandOptionMetadataAttribute(string template)
        {
            Template = template;
        }
    }
}
