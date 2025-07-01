

using CommandLineInterpreter.Commands.Abstraction;

namespace CommandLineInterpreter.Commands.Implementation
{
    internal class RmdirCommand: ICommand
    {
        private List<string> _args;
        public RmdirCommand(List<string> args)
        {
            _args = args;
        }
        public CommandResult Execute()
        {
            if (_args.Count != 2)
                return new CommandResult(ResultStatus.Error, "Invalid number of arguments with rmdir\nRun help for more info\n");
            string path = _args[1];
            
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
                return new CommandResult(ResultStatus.Error, "Directory Not found\n");


            if (!IsEmptyDirectory(dir))
                return new CommandResult(ResultStatus.Error, "Use rm -r to remove recursive files\nRun help for more info\n");
            
            dir.Delete();

            return new CommandResult()
            {
                Status = ResultStatus.Success,
                Result = new List<string> { $"Directory is deleted successfully {path}" }
            };


        }

        private bool IsEmptyDirectory(DirectoryInfo dir)
        {
            return !dir.EnumerateFiles().Any() && !dir.EnumerateDirectories().Any();
        }
      
    }
}
