using UnityEngine;

public class RunningState : IStates<PlayerController>
{
    public PlayerController Controller { get; set; }
    private GenericStateMachine<PlayerController> stateMachine;
    public RunningState(GenericStateMachine<PlayerController> stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter() { }

    public void OnStateExit() { }

    public void Update() 
    {
        Move();
    }
    public void Move()
    {
        Controller.PlayerView.transform.position += Vector3.forward * Controller.PlayerModel.PlayerSpeed * Time.deltaTime;
        Controller.EventService.OnPlayerPassingGround.Invoke(Controller.PlayerView.transform);
    }
}