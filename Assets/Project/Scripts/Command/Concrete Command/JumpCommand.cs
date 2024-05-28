using UnityEngine;

public class JumpCommand : AbstractPlayerCommands
{
    public JumpCommand(PlayerController playerController) : base(playerController) { }
    public override void Execute() 
    {
        if (playerController.IsOnGround)
        {
            playerController.IsOnGround = false;
            playerController.PlayerView.RigidBody.AddForce(Vector3.up * playerController.PlayerModel.PlayerJumpForce, ForceMode.Impulse);
        }
    } 
}