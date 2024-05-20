public class JumpingState : IStates<PlayerController>
{
    public PlayerController Controller { get; set; }
    private GenericStateMachine<PlayerController> stateMachine;

    public JumpingState(GenericStateMachine<PlayerController> stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {
        Jump();
        stateMachine.ChangeState(States.RUNNING);
    }

    public void OnStateExit() { }

    public void Update() { }

    private void Jump()
    {
        Controller.EventService.OnSoundEffectPlay.Invoke(Sounds.PLAYERJUMP);
        Controller.PlayerView.PlayerAnimator.SetTrigger("Jump");
        JumpCommand jumpCommand = new JumpCommand(Controller);
        Controller.CommandInvoker.ProcessCommand(jumpCommand);
    }
}