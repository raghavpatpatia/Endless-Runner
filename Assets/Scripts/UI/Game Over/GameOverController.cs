using System;

public class GameOverController : IDisposable
{
    private GameOverView gameOverView;
    private EventService eventService;
    private PointsController pointsController;
    private LeaderboardController leaderboardController;
    public GameOverController(GameOverView gameOverView, EventService eventService, PointsController pointsController, LeaderboardController leaderboardController) 
    {
        this.gameOverView = gameOverView;
        this.gameOverView.Init(this, eventService);
        this.gameOverView.gameObject.SetActive(false);
        this.eventService = eventService;
        this.pointsController = pointsController;
        this.leaderboardController = leaderboardController;
        SubscribeEvents();
    }
    private void SubscribeEvents() => eventService.OnPlayerDead.AddListener(OnPlayerDeath);
    private void OnPlayerDeath()
    {
        gameOverView.gameObject.SetActive(true);
        gameOverView.SetPointText(pointsController.GetTotalPoints());
    }

    public void OnLeaderboardButtonClick()
    {
        eventService.OnSoundEffectPlay.Invoke(Sounds.BUTTONCLICK);
        leaderboardController.ShowLeaderboard();
    }

    private void UnsubscribeEvents() => eventService.OnPlayerDead.RemoveListener(OnPlayerDeath);

    public void Dispose() => UnsubscribeEvents();
}