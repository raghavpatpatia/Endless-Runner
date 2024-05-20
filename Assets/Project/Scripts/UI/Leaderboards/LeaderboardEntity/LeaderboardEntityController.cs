using UnityEngine;

public class LeaderboardEntityController
{
    private LeaderboardEntityView leaderboardEntityView;
    public LeaderboardEntityController(LeaderboardEntityView leaderboardEntityView, Transform position)
    {
        this.leaderboardEntityView = GameObject.Instantiate<LeaderboardEntityView>(leaderboardEntityView, position);
    }

    public void SetData(string name, int score)
    {
        leaderboardEntityView.SetUserName(name);
        leaderboardEntityView.SetScore(score);
    }

    public void DisableView() => leaderboardEntityView.gameObject.SetActive(false);
}