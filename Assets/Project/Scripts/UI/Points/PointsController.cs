using Unity.Services.Leaderboards;

public class PointsController
{
    private int totalPoints;
    private PointsView pointsView;
    private EventService eventService;
    private PointsAchievementModel pointsAchievementModel;
    public PointsController(PointsView pointView, EventService eventService, PointsAchievementSO pointsAchievementSO)
    {
        this.pointsAchievementModel = new PointsAchievementModel(pointsAchievementSO);
        this.pointsView = pointView;
        this.eventService = eventService;
        eventService.OnCoinCollect.AddListener(AddPoints);
        eventService.AddScoresToLeaderboard.AddListener(AddTotalScores);
    }

    private void AddPoints()
    {
        totalPoints++;
        pointsView.SetPointsAmount(totalPoints);
        OnPointAchievementAchieved();
    }

    private async void AddTotalScores(string id) => await LeaderboardsService.Instance.AddPlayerScoreAsync(id, GetTotalPoints());

    public int GetTotalPoints() => totalPoints;

    private void OnPointAchievementAchieved()
    {
        if (totalPoints % pointsAchievementModel.PointsThreshold == 0)
            eventService.IncreaseSpeed.Invoke(pointsAchievementModel.IncreaseSpeed);
    } 

    ~PointsController()
    {
        eventService.OnCoinCollect.RemoveListener(AddPoints);
        eventService.AddScoresToLeaderboard.RemoveListener(AddTotalScores);
    }
}