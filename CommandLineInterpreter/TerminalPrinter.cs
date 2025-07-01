
using CommandLineInterpreter.Commands.Abstraction;

namespace CommandLineInterpreter
{
    internal static class TerminalPrinter
    {
        private static void PrintError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(errorMessage);

            Console.ForegroundColor = ConsoleColor.White;

        }

        private static void PrintSuccess(List<string> messages)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            foreach(string message in messages) 
                Console.WriteLine(message);

            Console.ForegroundColor = ConsoleColor.White;

        }

        public static void Print(CommandResult result)
        {
            if(result.Status == ResultStatus.Error)
            
                PrintError(result.StatusMessage);
     
            else
            
                PrintSuccess(result.Result);

        }
    }
}
