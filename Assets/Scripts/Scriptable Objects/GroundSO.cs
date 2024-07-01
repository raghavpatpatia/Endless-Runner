using UnityEngine;

[CreateAssetMenu(fileName = "GroundSO", menuName = "ScriptableObjects/Data/GroundSO")]
public class GroundSO : ScriptableObject
{
    public GroundView[] Ground;
    public float ZPos;
    public float SpawnTime;
}