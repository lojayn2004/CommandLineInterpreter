


namespace CommandLineInterpreter
{

    class Program
    {
        public static void Main(string[] args)
        {
            
            CommandLineInterpreter cli = new CommandLineInterpreter(SystemProperties.Property);
            cli.Run();
        }
    }




}

