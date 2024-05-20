using UnityEngine;

public class EventService
{
    public EventController<Transform> OnPlayerPassingGround;
    public EventController OnCoinCollect;
    public EventController OnPlayerDead;
    public EventController<float> IncreaseSpeed;
    public EventController<string> AddScoresToLeaderboard;
    public EventController<Sounds> OnBGMusicPlay;
    public EventController<Sounds> OnSoundEffectPlay;
    public EventController<float> OnBGMusicVolumeChange;
    public EventService() 
    {
        OnPlayerPassingGround = new EventController<Transform>();
        OnCoinCollect = new EventController();
        OnPlayerDead = new EventController();
        IncreaseSpeed = new EventController<float>();
        AddScoresToLeaderboard = new EventController<string>();
        OnBGMusicPlay = new EventController<Sounds>();
        OnSoundEffectPlay = new EventController<Sounds>();
        OnBGMusicVolumeChange = new EventController<float>();
    }
}