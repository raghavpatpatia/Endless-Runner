using UnityEngine;

[CreateAssetMenu(fileName = "GroundSO", menuName = "ScriptableObjects/Data/GroundSO")]
public class GroundSO : ScriptableObject
{
    public GroundView[] Ground;
    public int ZPos;
    public float SpawnTime;
}