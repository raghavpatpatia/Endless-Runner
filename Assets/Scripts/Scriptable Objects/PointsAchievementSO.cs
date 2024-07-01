using UnityEngine;

[CreateAssetMenu(fileName = "PointsAchievementSO", menuName = "ScriptableObjects/Data/PointsAchievementSO")]
public class PointsAchievementSO : ScriptableObject
{
    public int PointsThreshold;
    public float IncreaseSpeed;
}