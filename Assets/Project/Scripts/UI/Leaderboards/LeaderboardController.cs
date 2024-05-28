using System;
using Unity.Services.Leaderboards;

public class LeaderboardController : IDisposable
{
    private LeaderboardView leaderboardView;
    private EventService eventService;
    private LeaderboardPool leaderboardPool;
    private const string leaderboardID = "EndlessRunner";
    public LeaderboardController(LeaderboardView leaderboardView, EventService eventService)
    {
        this.leaderboardView = leaderboardView;
        this.leaderboardView.Init(this);
        this.eventService = eventService;
        this.leaderboardPool = new LeaderboardPool(leaderboardView.LeaderboardEntityView, leaderboardView.PositionToSpawn);
        SubscribeEvents();
    }

    private void SubscribeEvents() => eventService.OnPlayerDead.AddListener(AddScores);

    public void ShowLeaderboard()
    {
        leaderboardView.gameObject.SetActive(true);
        GetLeaderboardEntities();
    }

    private async void GetLeaderboardEntities()
    {
        var page = await LeaderboardsService.Instance.GetScoresAsync(leaderboardID);
        foreach (var entity in page.Results)
        {
            leaderboardPool.GetLeaderboardEntityController().SetData(entity.PlayerName, (int)entity.Score);
        }
    }

    public void OnCloseButtonClick()
    {
        eventService.OnSoundEffectPlay.Invoke(Sounds.BUTTONCLICK);
        leaderboardView.gameObject.SetActive(false);
        leaderboardPool.ReturnAllItems();
    }

    private void AddScores() => eventService.AddScoresToLeaderboard.Invoke(leaderboardID);

    private void UnsubscribeEvents() => eventService.OnPlayerDead.RemoveListener(AddScores);

    public void Dispose() => UnsubscribeEvents();
}