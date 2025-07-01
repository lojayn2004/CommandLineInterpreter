

using CommandLineInterpreter.Commands.Abstraction;

namespace CommandLineInterpreter.Commands.Implementation
{
    internal class TouchCommand: ICommand 
    {
        private SystemProperties _systemProperties;
        private List<string> _args;
        public TouchCommand(SystemProperties systemProperties, List<string> args)
        {
            _systemProperties = systemProperties;
            _args = args;
        }


        public CommandResult Execute()
        {
            if (_args.Count < 2)
                throw new ArgumentException("Invalid number of arguments for touch\nrun help for more info\n");
            List<string> result = new List<string>();
            // touch could create one file or multiple files
            for (int i = 1; i < _args.Count; i++)
            {
                try
                {
                    string message = CreateFile(_args[i]);
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

        private string CreateFile(string path) {
            string fullPath = _systemProperties.GetCurrentDirectory();
            // if the path is not absolute add it
            if(!Path.IsPathFullyQualified(path))
                fullPath = Path.Combine(fullPath, path);
            
            if(!File.Exists(fullPath))
            {
                using FileStream fs = File.Create(fullPath);
                return $"File {fullPath} is created Successfully\n";
            }

            File.SetLastWriteTimeUtc(fullPath, DateTime.UtcNow);
            return $"File {fullPath} time stamp is updated \n";
       
        }
    }
}
