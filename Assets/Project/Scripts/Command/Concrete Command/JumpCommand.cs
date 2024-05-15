using UnityEngine;

public class JumpCommand : ICommand
{
    private PlayerController playerController;
    public JumpCommand(PlayerController playerController) => this.playerController = playerController;
    public void Execute() => Jump();
    private void Jump()
    {
        if (playerController.IsPlayerOnGround() == true)
        {
            playerController.SetIsOnGround(false);
            playerController.PlayerView.RigidBody.AddForce(Vector3.up * playerController.PlayerModel.PlayerJumpForce, ForceMode.Impulse);
        }
    }
}