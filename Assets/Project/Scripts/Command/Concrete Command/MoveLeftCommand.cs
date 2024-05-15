using UnityEngine;

public class MoveLeftCommand : ICommand
{
    private PlayerController playerController;
    public MoveLeftCommand(PlayerController playerController) => this.playerController = playerController;
    public void Execute() => MoveLeft();
    public void MoveLeft()
    {
        float centerBoundary = playerController.PlayerModel.PlayerBoundary.CenterBoundary;
        float leftBoundary = playerController.PlayerModel.PlayerBoundary.LeftBoundary;
        float targetX = Mathf.Round(playerController.PlayerView.transform.position.x) > centerBoundary ? centerBoundary : leftBoundary;
        playerController.PlayerView.transform.position = new Vector3(targetX, playerController.PlayerView.transform.position.y, playerController.PlayerView.transform.position.z);
    }

}