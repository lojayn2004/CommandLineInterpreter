using CommandLineInterpreter.Commands.Abstraction;
using CommandLineInterpreter.Commands.Implementation;
using System.Net.Http.Headers;

namespace CommandLineInterpreter
{
    internal static class CommandFactory
    {
        public static ICommand CreateCommand(List<string> args)
        {
            if(args.Contains(">") || args.Contains(">>"))
                return new RedirectionCommand(args);
            return args[0] switch
            {
                "ls" => new ListCommand(SystemProperties.Property, args),
                "cd" => new CdCommand(SystemProperties.Property, args),
                "mkdir" => new MkdirCommand(args),
                "rmdir" => new RmdirCommand(args),
                "rm" => new RemoveCommand(args),
                "pwd" => new PwdCommand(SystemProperties.Property),
                "touch" => new TouchCommand(SystemProperties.Property, args),
                "cat" => new CatCommand(args),
                "help" => new HelpCommand(),
                _ => throw new InvalidOperationException("Invalid Command\n")
            };
         

        }
    }
}
