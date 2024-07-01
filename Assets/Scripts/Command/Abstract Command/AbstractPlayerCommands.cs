public abstract class AbstractPlayerCommands : ICommand
{
    protected PlayerController playerController;
    public AbstractPlayerCommands(PlayerController playerController) => this.playerController = playerController;
    public abstract void Execute();
}