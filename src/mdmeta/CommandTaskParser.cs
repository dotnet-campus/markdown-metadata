using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mdmeta.Core;
using Microsoft.Extensions.CommandLineUtils;

namespace Mdmeta
{
    internal static class CommandTaskReflector
    {
        internal static void ReflectTo(Assembly assembly, CommandLineApplication app)
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
                if (optionAttribute != null && property.CanWrite)
                {
                    var option = command.Option(
                        optionAttribute.Template,
                        optionAttribute.Description,
                        CommandOptionType.NoValue);
                    optionPropertyList.Add((option, property));
                }
            }
            command.OnExecute(() =>
            {
                var commandTask = (CommandTask) Activator.CreateInstance(taskType);
                foreach (var argumentProperty in argumentPropertyList)
                {
                    argumentProperty.property.SetValue(commandTask, argumentProperty.argument.Value);
                }
                foreach (var optionProperty in optionPropertyList.Where(o => o.option.HasValue()))
                {
                    optionProperty.property.SetValue(commandTask, true);
                }
                return commandTask.Run();
            });
        }
    }
}
