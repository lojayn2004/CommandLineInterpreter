using CommandLineInterpreter.Commands.Abstraction;
using static System.Net.Mime.MediaTypeNames;


namespace CommandLineInterpreter.Commands.Implementation
{
    internal class RedirectionCommand : ICommand
    {
        private List<string> _args;
        public RedirectionCommand(List<string> args)
        {
            _args = args;
        }

        public CommandResult Execute()
        {
            if (_args.Count != 4)
                return new CommandResult(ResultStatus.Error, "Incorrect number of arguments with redirection \n");
            List<string> catArgs = new List<string>();
            CatCommand catCommand = new CatCommand(new List<string> { _args[0], _args[1] });
            CommandResult catRes = catCommand.Execute();

            IEnumerable<string> content = catRes.Result; 
            string path = _args[3];

            if (!File.Exists(_args[3]))
                return new CommandResult(ResultStatus.Error, $"Output File {_args[3]} not found\n");


            if (_args[2] == ">")
                File.WriteAllLines(path, content);
            else if (_args[2] == ">>")
                File.AppendAllLines(path, content);
            else
                return new CommandResult(ResultStatus.Error, "Invalid redirection operator. Use '>' or '>>'");

            return new CommandResult()
            {
                Status = ResultStatus.Success,
                Result = new List<string> { $"Output redirected to {path}" }
            };
        }
    }
}
