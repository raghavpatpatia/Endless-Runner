using System;
using Unity.Services.Leaderboards;

public class PointsController : IDisposable
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
        eventService.IncreaseScore.AddListener(IncreasePoints);
    }

    private void AddPoints()
    {
        totalPoints++;
        pointsView.SetPointsAmount(totalPoints);
        OnPointAchievementAchieved();
    }

    private void IncreasePoints(int points)
    {
        totalPoints += points;
        pointsView.SetPointsAmount(totalPoints);
    }

    private async void AddTotalScores(string id) => await LeaderboardsService.Instance.AddPlayerScoreAsync(id, GetTotalPoints());

    public int GetTotalPoints() => totalPoints;

    private void OnPointAchievementAchieved()
    {
        if (totalPoints % pointsAchievementModel.PointsThreshold == 0)
            eventService.IncreaseSpeed.Invoke(pointsAchievementModel.IncreaseSpeed);
    }

    public void Dispose()
    {
        eventService.OnCoinCollect.RemoveListener(AddPoints);
        eventService.AddScoresToLeaderboard.RemoveListener(AddTotalScores);
        eventService.IncreaseScore.RemoveListener(IncreasePoints);
    }
}