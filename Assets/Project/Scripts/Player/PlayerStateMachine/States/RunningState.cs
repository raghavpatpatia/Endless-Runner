using UnityEngine;

public class RunningState : PlayerAbstractState
{
    public RunningState(GenericStateMachine<PlayerController> stateMachine) : base(stateMachine) { }

    public override void OnStateEnter() { }

    public override void OnStateExit() { }

    public override void Update() 
    {
        Move();
    }
    public void Move()
    {
        Controller.PlayerView.transform.position += Vector3.forward * Controller.PlayerModel.PlayerSpeed * Time.deltaTime;
        Controller.EventService.OnPlayerPassingGround.Invoke(Controller.PlayerView.transform);
    }
}