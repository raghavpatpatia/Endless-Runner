public class PointsAchievementModel
{
    public int PointsThreshold { get; private set; }
    public float IncreaseSpeed { get; private set; }

    public PointsAchievementModel(PointsAchievementSO pointsSO)
    {
        PointsThreshold = pointsSO.PointsThreshold;
        IncreaseSpeed = pointsSO.IncreaseSpeed;
    }
}