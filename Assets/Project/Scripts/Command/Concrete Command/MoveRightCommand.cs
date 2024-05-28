using UnityEngine;

public class MoveRightCommand : AbstractPlayerCommands
{
    public MoveRightCommand(PlayerController playerController) : base(playerController) { }
    public override void Execute() 
    {
        float centerBoundary = playerController.PlayerModel.PlayerBoundary.CenterBoundary;
        float rightBoundary = playerController.PlayerModel.PlayerBoundary.RightBoundary;
        float targetX = Mathf.Round(playerController.PlayerView.transform.position.x) < centerBoundary ? centerBoundary : rightBoundary;
        playerController.PlayerView.transform.position = new Vector3(targetX, playerController.PlayerView.transform.position.y, playerController.PlayerView.transform.position.z);
    } 
}