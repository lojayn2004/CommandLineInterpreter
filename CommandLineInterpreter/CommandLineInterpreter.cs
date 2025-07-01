using CommandLineInterpreter.Commands.Abstraction;

namespace CommandLineInterpreter
{
    internal class CommandLineInterpreter
    {
        private SystemProperties _properties;

        public CommandLineInterpreter(SystemProperties properties)
        {
            _properties = properties;
        }
        public void Run()
        {

            while (true)
            {
                Console.Write($"{_properties.GetCurrentDirectory()}> ");
                string inputCommand = Console.ReadLine();
                if (string.IsNullOrEmpty(inputCommand))
                    continue;
                if(inputCommand.ToLower() == "exit")
                    break;

                try
                {
                    List<string> args = inputCommand.Split(" ").ToList();
                    ICommand command = CommandFactory.CreateCommand(args);

                    if (command is null)
                    {
                        CommandResult errorResult = new CommandResult()
                        {
                            Status = ResultStatus.Error,
                            StatusMessage = "Invalid Comamnd\nRun help for more Info\n"

                        };
                        TerminalPrinter.Print(errorResult);
                        continue;
                    }
                    CommandResult result = command.Execute();
                    TerminalPrinter.Print(result);
                }
                catch (Exception ex)
                {
                    TerminalPrinter.Print(new CommandResult(ResultStatus.Error, ex.Message));
                }
               
            }
        }
    }
}
