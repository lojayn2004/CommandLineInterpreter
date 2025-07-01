namespace CommandLineInterpreter.Commands.Abstraction
{
    internal class CommandResult
    {
        public ResultStatus Status { get; set; }

        public string StatusMessage {get; set;}

        public List<string> Result { get; set; }


        public CommandResult() { }


        public CommandResult(ResultStatus status, string statusMessage)
        {
            Status = status;
            StatusMessage = statusMessage;
        }
    }
}
