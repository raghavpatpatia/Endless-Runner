using UnityEngine;

public class PlayerController
{
    public PlayerModel PlayerModel { get; private set; }
    public PlayerView PlayerView { get; private set; }
    public CommandInvoker CommandInvoker { get; private set; }
    private Camera camera;
    public EventService EventService { get; private set; }
    private PlayerStateMachine playerStateMachine;
    public bool IsOnGround { get; set; }
    public bool IsPlayerDead { get; set; }
    public PlayerController(PlayerSO playerSO, Vector3 playerSpawnPoint, CommandInvoker commandInvoker, EventService eventService)
    {
        this.PlayerModel = new PlayerModel(playerSO, eventService);
        this.PlayerView = GameObject.Instantiate<PlayerView>(playerSO.PlayerView, playerSpawnPoint, Quaternion.identity);
        this.PlayerView.Init(this);
        this.CommandInvoker = commandInvoker;
        this.camera = Camera.main;
        this.EventService = eventService;
        this.playerStateMachine = new PlayerStateMachine(this);
        IsOnGround = true;
        IsPlayerDead = false;
        ChangeState(States.RUNNING);
        this.EventService.OnPlayerDead.AddListener(OnPlayerDeath);
    }

    public void UpdateState() => playerStateMachine.Update();

    public void MoveLeft()
    {
        MoveLeftCommand leftCommand = new MoveLeftCommand(this);
        CommandInvoker.ProcessCommand(leftCommand);
    }

    public void MoveRight()
    {
        MoveRightCommand rightCommand = new MoveRightCommand(this);
        CommandInvoker.ProcessCommand(rightCommand);
    }
    public void ChangeState(States state) => playerStateMachine.ChangeState(state);
    public void SetCamera() => camera.transform.SetParent(PlayerView.CameraSpawnPoint);

    private void OnPlayerDeath() => PlayerView.SetColliderHeight(0);

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<GroundView>() != null)
        {
            IsOnGround = true;
        }
        else
        {
            ChangeState(States.DEAD);
        }
    }

    ~PlayerController()
    {
        EventService.OnPlayerDead.RemoveListener(OnPlayerDeath);
    }
}