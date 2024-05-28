public abstract class PlayerAbstractState : IStates<PlayerController>
{
    public PlayerController Controller { get; set; }
    protected GenericStateMachine<PlayerController> stateMachine;
    public PlayerAbstractState(GenericStateMachine<PlayerController> stateMachine) => this.stateMachine = stateMachine;
    public abstract void OnStateEnter();

    public abstract void OnStateExit();

    public abstract void Update();
}