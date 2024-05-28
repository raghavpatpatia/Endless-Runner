using UnityEngine;

public class MoveLeftCommand : AbstractPlayerCommands
{
    public MoveLeftCommand(PlayerController playerController) : base(playerController) { }
    public override void Execute() 
    {
        float centerBoundary = playerController.PlayerModel.PlayerBoundary.CenterBoundary;
        float leftBoundary = playerController.PlayerModel.PlayerBoundary.LeftBoundary;
        float targetX = Mathf.Round(playerController.PlayerView.transform.position.x) > centerBoundary ? centerBoundary : leftBoundary;
        playerController.PlayerView.transform.position = new Vector3(targetX, playerController.PlayerView.transform.position.y, playerController.PlayerView.transform.position.z);
    } 
}