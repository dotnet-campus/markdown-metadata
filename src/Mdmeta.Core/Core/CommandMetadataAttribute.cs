using System;

namespace Mdmeta.Core
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
}
