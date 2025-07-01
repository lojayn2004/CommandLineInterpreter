

using CommandLineInterpreter.Commands.Abstraction;
using System.Runtime.CompilerServices;

namespace CommandLineInterpreter.Commands.Implementation
{
    internal class CatCommand : ICommand
    {
        private List<string> _args;
        public CatCommand(List<string> args)
        { 
            _args = args;
        }

        public CommandResult Execute()
        {
            List<string> result = new List<string>();   

            for(int i = 1; i < _args.Count;i++)
            {
                if (File.Exists(_args[i]))
                    result.Add(File.ReadAllText(_args[i]));
                else
                    return new CommandResult(ResultStatus.Error, $"Invalid file Name {_args[i]}");
            }

            
            return new CommandResult()
            {
                Status = ResultStatus.Success,
                Result = result
            };
        }
    }
}
