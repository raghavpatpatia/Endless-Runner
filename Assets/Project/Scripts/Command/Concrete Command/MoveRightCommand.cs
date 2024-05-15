using UnityEngine;

public class MoveRightCommand : ICommand
{
    private PlayerController playerController;
    public MoveRightCommand(PlayerController playerController) => this.playerController = playerController;
    public void Execute() => MoveRight();
    public void MoveRight()
    {
        float centerBoundary = playerController.PlayerModel.PlayerBoundary.CenterBoundary;
        float rightBoundary = playerController.PlayerModel.PlayerBoundary.RightBoundary;
        float targetX = Mathf.Round(playerController.PlayerView.transform.position.x) < centerBoundary ? centerBoundary : rightBoundary;
        playerController.PlayerView.transform.position = new Vector3(targetX, playerController.PlayerView.transform.position.y, playerController.PlayerView.transform.position.z);
    }
}