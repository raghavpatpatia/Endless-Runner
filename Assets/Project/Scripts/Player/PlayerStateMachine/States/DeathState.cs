public class DeathState : PlayerAbstractState
{
    public DeathState(GenericStateMachine<PlayerController> stateMachine) : base(stateMachine) { }

    public override void OnStateEnter() 
    {
        Controller.IsPlayerDead = true;
        Controller.EventService.OnSoundEffectPlay.Invoke(Sounds.PLAYERDEATH);
        Controller.PlayerView.PlayerAnimator.SetBool("IsDead", true);
        Controller.EventService.OnPlayerDead.Invoke();
    }

    public override void OnStateExit() { }

    public override void Update() { }
}