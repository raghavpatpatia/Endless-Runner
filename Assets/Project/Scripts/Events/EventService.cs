using UnityEngine;

public class EventService
{
    public EventController<Transform> OnPlayerPassingGround;
    public EventController OnCoinCollect;
    public EventService() 
    {
        OnPlayerPassingGround = new EventController<Transform>();
        OnCoinCollect = new EventController();
    }
}