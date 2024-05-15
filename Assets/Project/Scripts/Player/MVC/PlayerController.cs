using UnityEngine;

public class PlayerController
{
    public PlayerModel PlayerModel { get; private set; }
    public PlayerView PlayerView { get; private set; }
    private CommandInvoker commandInvoker;
    private Camera camera;
    private EventService eventService;
    private bool isOnGround;
    public PlayerController(PlayerSO playerSO, Vector3 playerSpawnPoint, CommandInvoker commandInvoker, EventService eventService)
    {
        this.PlayerModel = new PlayerModel(playerSO);
        this.PlayerView = GameObject.Instantiate<PlayerView>(playerSO.PlayerView, playerSpawnPoint, Quaternion.identity);
        this.PlayerView.Init(this);
        this.commandInvoker = commandInvoker;
        this.camera = Camera.main;
        this.eventService = eventService;
        isOnGround = true;
    }

    public void Move()
    {
        Vector3 movement = Vector3.forward * PlayerModel.PlayerSpeed * Time.deltaTime;
        PlayerView.transform.position += movement;
        OnPlayerPassingGround();
    }

    public void MoveLeft()
    {
        MoveLeftCommand leftCommand = new MoveLeftCommand(this);
        commandInvoker.ProcessCommand(leftCommand);
    }

    public void MoveRight()
    {
        MoveRightCommand rightCommand = new MoveRightCommand(this);
        commandInvoker.ProcessCommand(rightCommand);
    }

    public void Jump()
    {
        JumpCommand jumpCommand = new JumpCommand(this);
        commandInvoker.ProcessCommand(jumpCommand);
    }

    public bool IsPlayerOnGround() => isOnGround;
    public void SetIsOnGround(bool value) => isOnGround = value;
    private void OnPlayerPassingGround() => eventService.OnPlayerPassingGround.Invoke(PlayerView.transform);
    public void SetCamera() => camera.transform.SetParent(PlayerView.CameraSpawnPoint);

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<GroundView>() != null)
        {
            isOnGround = true;
        }
    }
}