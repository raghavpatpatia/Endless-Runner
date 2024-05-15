using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObjects/Player/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public BoundarySO BoundarySO;
    public float PlayerSpeed;
    public float PlayerJumpForce;
    public PlayerView PlayerView;
}
