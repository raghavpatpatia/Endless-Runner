public class PlayerStateMachine : GenericStateMachine<PlayerController>
{
    public PlayerStateMachine(PlayerController controller) : base(controller)
    {
        this.controller = controller;
        CreateStates();
        SetController();
    }
    private void CreateStates() 
    {
        states.Add(States.RUNNING, new RunningState(this));
        states.Add(States.JUMPING, new JumpingState(this));
        states.Add(States.DEAD, new DeathState(this));
    }
}