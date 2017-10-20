using System;

namespace Mdmeta.Core
{
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
}
