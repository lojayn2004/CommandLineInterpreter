
using CommandLineInterpreter.Commands.Abstraction;

namespace CommandLineInterpreter.Commands.Implementation
{
    internal class CdCommand : ICommand
    {
        private List<string> _args;
        private SystemProperties _properties;
        public CdCommand(SystemProperties properties, List<string> args)
        {
            _properties = properties;
            _args = args;
        }
        public CommandResult Execute()
        {
            if (_args.Count > 2)
                return new CommandResult(ResultStatus.Error, "Too many data for cd\nCheck help for more info\n");
            if (_args.Count == 1)
                _args.Add("~");

            if (_args[1] == ".")
                return new CommandResult(ResultStatus.Success, "");

            string newPath = GetNewPath();
          
            try
            {
                _properties.ChangeWorkingDirectory(newPath);
                return new CommandResult()
                {
                    Status = ResultStatus.Success,
                    Result = new List<string> { $"Changed to directory {newPath}"}
                };
            }
            catch
            {
                return new CommandResult(ResultStatus.Error, "Invalid Path");
            }  
            
        }

        private string GetNewPath()
        {
            string newPath;
            if (_args.Count == 1)
            {
                newPath = Environment.SpecialFolder.UserProfile.ToString();
            }
            else
            {
                newPath = _args[1] switch
                {
                    ".." => Directory.GetParent(_properties.GetCurrentDirectory()).ToString(),
                    "~" => Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    _ => _args[1]
                };

            }
            return newPath;

        }
    }
}
