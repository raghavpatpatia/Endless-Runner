using System.Collections.Generic;
using UnityEngine;

public class LeaderboardPool : GenericPool<LeaderboardEntityController>
{
    private LeaderboardEntityView entityView;
    private Transform position;
    private List<LeaderboardEntityController> leaderboardEntityControllers;

    public LeaderboardPool(LeaderboardEntityView entityView, Transform position)
    {
        this.entityView = entityView;
        this.position = position;
        this.leaderboardEntityControllers = new List<LeaderboardEntityController>();
    }

    public void ReturnAllItems()
    {
        foreach (LeaderboardEntityController controller in leaderboardEntityControllers)
        {
            controller.DisableView();
            ReturnItem(controller);
        }
    }

    public LeaderboardEntityController GetLeaderboardEntityController() => GetItem<LeaderboardEntityController>();

    protected override LeaderboardEntityController CreateItem<T>()
    {
        LeaderboardEntityController item = new LeaderboardEntityController(entityView, position);
        leaderboardEntityControllers.Add(item);
        return item;
    }
}