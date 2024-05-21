public class DeathState : IStates<PlayerController>
{
    public PlayerController Controller { get; set; }
    private GenericStateMachine<PlayerController> stateMachine;

    public DeathState(GenericStateMachine<PlayerController> stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter() 
    {
        Controller.IsPlayerDead = true;
        Controller.EventService.OnSoundEffectPlay.Invoke(Sounds.PLAYERDEATH);
        Controller.PlayerView.PlayerAnimator.SetBool("IsDead", true);
        Controller.EventService.OnPlayerDead.Invoke();
    }

    public void OnStateExit() { }

    public void Update() { }
}