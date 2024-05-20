public class PlayerModel
{
    public float PlayerSpeed { get; private set; }
    public float PlayerJumpForce { get; private set; }
    public BoundarySO PlayerBoundary { get; private set; }
    private EventService eventService;
    public PlayerModel(PlayerSO playerSO, EventService eventService)
    {
        this.PlayerSpeed = playerSO.PlayerSpeed;
        this.PlayerJumpForce = playerSO.PlayerJumpForce;
        this.PlayerBoundary = playerSO.BoundarySO;
        this.eventService = eventService;
        eventService.IncreaseSpeed.AddListener(IncreasePlayerSpeed);
    }

    private void IncreasePlayerSpeed(float speed) => PlayerSpeed += speed;

    ~PlayerModel()
    {
        eventService.IncreaseSpeed.RemoveListener(IncreasePlayerSpeed);
    }
}