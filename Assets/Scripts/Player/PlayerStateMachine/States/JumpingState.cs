public class JumpingState : PlayerAbstractState
{
    public JumpingState(GenericStateMachine<PlayerController> stateMachine) : base(stateMachine) { }

    public override void OnStateEnter()
    {
        Jump();
        stateMachine.ChangeState(States.RUNNING);
    }

    public override void OnStateExit() { }

    public override void Update() { }

    private void Jump()
    {
        Controller.EventService.OnSoundEffectPlay.Invoke(Sounds.PLAYERJUMP);
        Controller.PlayerView.PlayerAnimator.SetTrigger("Jump");
        Controller.Jump();
    }
}