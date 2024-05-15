public class PointsController
{
    private int totalPoints;
    private PointsView pointsView;
    private EventService eventService;
    public PointsController(PointsView pointView, EventService eventService)
    {
        this.pointsView = pointView;
        this.eventService = eventService;
        eventService.OnCoinCollect.AddListener(AddPoints);
    }

    private void AddPoints()
    {
        totalPoints++;
        pointsView.SetPointsAmount(totalPoints);
    }

    ~PointsController()
    {
        eventService.OnCoinCollect.RemoveListener(AddPoints);
    }
}