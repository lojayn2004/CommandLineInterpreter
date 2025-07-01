

using CommandLineInterpreter.Commands.Abstraction;

namespace CommandLineInterpreter.Commands.Implementation
{
    internal class ListCommand : ICommand
    {

        private SystemProperties _properties;
        private List<string> _args;
        public ListCommand(SystemProperties properties, List<string> args)
        {
            _properties = properties;
            _args = args;

        }
        public CommandResult Execute()
        {

            List<string> fileInDirectory = GetFilesInDirectory();

            return new CommandResult()
            {
                Status = ResultStatus.Success,
                StatusMessage = "",
                Result = fileInDirectory
            };
        }

        private List<string> GetFilesInDirectory()
        {
            List<string> fileNames = new List<string>();

            if (_args.Count == 1)
            {
                var visibleFiles = new DirectoryInfo(_properties.GetCurrentDirectory())
                                  .GetFileSystemInfos()
                                  .Where(f => !f.Name.StartsWith("."))
                                  .Select(f => f.Name)
                                  .ToList();
                return visibleFiles;
            }

            fileNames = _args[1] switch
            {
                "-r" => new DirectoryInfo(_properties.GetCurrentDirectory())
                                  .GetFileSystemInfos()
                                  .Where(f => !f.Name.StartsWith("."))
                                  .Select(f => f.Name)
                                  .OrderByDescending(f => f)
                                  .ToList(),
                                 
                "-a" => new DirectoryInfo(_properties.GetCurrentDirectory())
                        .GetFileSystemInfos()
                        .Select(f => f.Name)
                        .ToList(),
                _ => new List<string>()
            };

            return fileNames;

        }
    }
}
