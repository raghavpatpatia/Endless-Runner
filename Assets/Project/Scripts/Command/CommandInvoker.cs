using System.Collections.Generic;

public class CommandInvoker
{
    private Stack<ICommand> commandRegistery = new Stack<ICommand>();
    public void ProcessCommand(ICommand command)
    {
        RegisterCommand(command);
        ExecuteCommand(command);
    }
    private void ExecuteCommand(ICommand commandToBeExecuted) => commandToBeExecuted.Execute();
    private void RegisterCommand(ICommand commandTBeRegistered) => commandRegistery.Push(commandTBeRegistered);
}