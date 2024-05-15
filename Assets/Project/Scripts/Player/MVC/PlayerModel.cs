public class PlayerModel
{
    public float PlayerSpeed { get; private set; }
    public float PlayerJumpForce { get; private set; }
    public BoundarySO PlayerBoundary { get; private set; }
    
    public PlayerModel(PlayerSO playerSO)
    {
        this.PlayerSpeed = playerSO.PlayerSpeed;
        this.PlayerJumpForce = playerSO.PlayerJumpForce;
        this.PlayerBoundary = playerSO.BoundarySO;
    }
}