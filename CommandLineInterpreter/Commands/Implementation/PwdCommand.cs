using CommandLineInterpreter.Commands.Abstraction;


namespace CommandLineInterpreter.Commands.Implementation
{
    internal class PwdCommand : ICommand
    {
        private SystemProperties _properties;
       
        public PwdCommand(SystemProperties properties) 
        { 
            _properties = properties;
         
        }
        public CommandResult Execute()
        {
            return new CommandResult()
            {
                Status = ResultStatus.Success,
                Result = new List<string> { _properties.GetCurrentDirectory()}
            };
           
        }
    }
}
