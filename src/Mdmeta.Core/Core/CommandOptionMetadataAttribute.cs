using System;

namespace Mdmeta.Core
{
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
