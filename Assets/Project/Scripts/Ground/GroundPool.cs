using UnityEngine;

public class GroundPool : GenericPool<GroundController>
{
    private GroundSO groundSO;
    private GroundService groundService;
    private EventService eventService;
    public GroundPool(GroundSO groundSO, GroundService groundService, EventService eventService)
    {
        this.groundSO = groundSO;
        this.groundService = groundService;
        this.eventService = eventService;
    }
    public GroundController GetGroundObject() => GetItem<GroundController>();
    protected override GroundController CreateItem<T>() => new GroundController(groundSO.Ground[Random.Range(0, groundSO.Ground.Length)], groundService.GetZPos(), this, eventService);
}