using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mdmeta.Core;
using Microsoft.Extensions.CommandLineUtils;

namespace Mdmeta
{
    internal static class CommandLineReflector
    {
        internal static void ReflectFrom(this CommandLineApplication app, Assembly assembly)
        {
            foreach (var ct in assembly.GetTypes()
                .Where(x => typeof(CommandTask).IsAssignableFrom(x)))
            {
                var commandAttribute = ct.GetCustomAttribute<CommandMetadataAttribute>();
                if (commandAttribute == null)
                {
                    continue;
                }
                app.Command(commandAttribute.Name, command =>
                {
                    ConfigCommand(command, commandAttribute.Description, ct);
                });
            }
        }

        private static void ConfigCommand(CommandLineApplication command, string commandDescription, Type taskType)
        {
            command.Description = commandDescription;
            command.HelpOption("-?|-h|--help");

            var argumentPropertyList = new List<(CommandArgument argument, PropertyInfo property)>();
            var optionPropertyList = new List<(CommandOption option, PropertyInfo property)>();
            foreach (var property in taskType.GetTypeInfo().DeclaredProperties)
            {
                var argumentAttribute = property.GetCustomAttribute<CommandArgumentMetadataAttribute>();
                var optionAttribute = property.GetCustomAttribute<CommandOptionMetadataAttribute>();
                if (argumentAttribute != null && property.CanWrite)
                {
                    var argument = command.Argument(
                        argumentAttribute.Name,
                        argumentAttribute.Description);
                    argumentPropertyList.Add((argument, property));
                }
                else if (optionAttribute != null && property.CanWrite)
                {
                    CommandOptionType commandOptionType;
                    if (typeof(IEnumerable<string>).IsAssignableFrom(property.PropertyType))
                    {
                        // If this property is a List<string>.
                        commandOptionType = CommandOptionType.MultipleValue;
                    }
                    else if (typeof(string).IsAssignableFrom(property.PropertyType))
                    {
                        // If this property is a string.
                        commandOptionType = CommandOptionType.SingleValue;
                    }
                    else if (typeof(bool).IsAssignableFrom(property.PropertyType))
                    {
                        // If this property is a bool.
                        commandOptionType = CommandOptionType.NoValue;
                    }
                    else
                    {
                        continue;
                    }
                    var option = command.Option(
                        optionAttribute.Template,
                        optionAttribute.Description,
                        commandOptionType);
                    optionPropertyList.Add((option, property));
                }
            }
            command.OnExecute(() =>
            {
                var commandTask = (CommandTask) Activator.CreateInstance(taskType);
                foreach (var (argument, property) in argumentPropertyList)
                {
                    property.SetValue(commandTask, argument.Value);
                }
                foreach (var (option, property) in optionPropertyList)
                {
                    switch (option.OptionType)
                    {
                        case CommandOptionType.MultipleValue:
                            property.SetValue(commandTask, option.Values.ToList());
                            break;
                        case CommandOptionType.SingleValue:
                            property.SetValue(commandTask, option.Value());
                            break;
                        case CommandOptionType.NoValue:
                            property.SetValue(commandTask, option.HasValue());
                            break;
                        default:
                            continue;
                    }
                }
                return commandTask.Run();
            });
        }
    }
}
