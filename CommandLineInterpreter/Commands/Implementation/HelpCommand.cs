
using CommandLineInterpreter.Commands.Abstraction;

namespace CommandLineInterpreter.Commands.Implementation
{
    internal class HelpCommand : ICommand
    {
        public CommandResult Execute()
        {
            var helpText = new List<string> {

                "cd       : Move to home directory",
                "cd ..    : Move to parent directory",
                "cd ~     : Move to home directory",
                "ls       : List directory contents",
                "ls -a    : Show all files (including hidden)",
                "ls -r    : List in reverse order",
                "mkdir    : Create new directory",
                "rmdir    : Remove empty directory",
                "rm       : Remove file",
                "rm -r    : Remove directory recursively",
                "touch    : Create empty file or update timestamp",
                "pwd      : Print current directory path",
                "cat      : Display file contents",
                "",
                "Redirection operators (used with cat):",
                "      cat file.txt > output.txt  : Overwrite output.txt with file contents",
                "      cat file.txt >> output.txt : Append file contents to output.txt",
  
            };

            return new CommandResult
            {
                Status = ResultStatus.Success,
                Result = helpText
            };
        }
    }
}
