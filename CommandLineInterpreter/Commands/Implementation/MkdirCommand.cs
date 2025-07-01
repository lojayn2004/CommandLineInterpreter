using CommandLineInterpreter.Commands.Abstraction;

namespace CommandLineInterpreter.Commands.Implementation
{
    internal class MkdirCommand : ICommand
    {
        private List<string> _args;
        public MkdirCommand(List<string> args)
        {
            _args = args;
        }
        public CommandResult Execute()
        {
            if(_args.Count < 2)
                return new CommandResult(ResultStatus.Error, "Insufficient number of arguments with mkdir\nRun help for more info\n");
            
            List<string> result = new List<string>();   
            
            
            for(int i = 1;i < _args.Count;i++)
            {
                try
                {
                    string message = CreateDirectory(_args[i]);
                    result.Add(message);
                }
                catch (Exception ex)
                {
                    return new CommandResult(ResultStatus.Error, ex.Message);
               
                }

            }

            return new CommandResult()
            {
                Status = ResultStatus.Success,
                Result = result

            };
        }
        private string CreateDirectory(string path)
        {
            if (Directory.Exists(path))
                throw new ArgumentException("Directory Found Before\n");
            Directory.CreateDirectory(path);
            return $"A new directory {path} was created successfully";
        }
    }
}
