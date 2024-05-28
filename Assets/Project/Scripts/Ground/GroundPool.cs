using System.Collections.Generic;
using UnityEngine;

public class GroundPool : GenericPool<GroundController>
{
    private GroundSO groundSO;
    private GroundService groundService;
    private EventService eventService;
    private List <GroundController> groundControllers;
    public GroundPool(GroundSO groundSO, GroundService groundService, EventService eventService)
    {
        this.groundSO = groundSO;
        this.groundService = groundService;
        this.eventService = eventService;
        groundControllers = new List<GroundController>();
    }
    public GroundController GetGroundObject() => GetItem<GroundController>();
    protected override GroundController CreateItem<T>()
    {
        GroundController ground = new GroundController(groundSO.Ground[Random.Range(0, groundSO.Ground.Length)], groundService.GetZPos(), this, eventService);
        groundControllers.Add(ground);
        return ground;
    }

    public void DisposeGroundControllers()
    {
        foreach (GroundController ground in groundControllers)
        {
            ground.Dispose();
        }
    }
}