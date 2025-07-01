using CommandLineInterpreter.Commands.Abstraction;

internal class RemoveCommand : ICommand
{
    private readonly List<string> _args;

    public RemoveCommand(List<string> args)
    {
        _args = args;
    }

    public CommandResult Execute()
    {
        if (_args.Count < 2)
            return new CommandResult(ResultStatus.Error, "Insufficient number of arguments with rm\nRun help for more info\n");

       
        bool isRecursive = _args.Contains("-r");
        string path = isRecursive ? _args[2] : _args[1];

        try
        {
            if (File.Exists(path))
                return HandleFileDelete(path);
            

            if (Directory.Exists(path))
                return HandleDirectoryDelete(path, isRecursive);

            return new CommandResult(ResultStatus.Error, "Path not found");
        }
        catch (Exception ex)
        {
            return new CommandResult(ResultStatus.Error, ex.Message);
        }
    }

    private CommandResult HandleFileDelete(string path)
    {
        File.Delete(path);
        return new CommandResult()
        {
            Status = ResultStatus.Success,
            Result = new List<string> { $"File {path} deleted successfully" }
        };
    }

    private CommandResult HandleDirectoryDelete(string path, bool isRecursive)
    {
        var dir = new DirectoryInfo(path);

        if (!isRecursive && !IsEmptyDirectory(dir))
        {
            return new CommandResult(
                ResultStatus.Error,
                "Directory is not empty. Use -r to remove recursively\nRun help for more info\n");
        }

        dir.Delete(recursive: isRecursive);
        return new CommandResult()
        {
            Status = ResultStatus.Success,
            Result = new List<string> { $"Directory {path} deleted successfully" }
        };
    }

    private bool IsEmptyDirectory(DirectoryInfo dir)
    {
        return !dir.EnumerateFiles().Any() && !dir.EnumerateDirectories().Any();
    }
}