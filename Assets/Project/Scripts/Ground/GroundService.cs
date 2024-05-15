using System.Collections;
using UnityEngine;

public class GroundService
{
    private GroundSO groundSO;
    private int zPos;
    private GroundPool groundPool;
    private EventService eventService;

    public GroundService(GroundSO groundSO, EventService eventService)
    {
        this.groundSO = groundSO;
        this.zPos = groundSO.ZPos;
        this.eventService = eventService;
        groundPool = new GroundPool(groundSO, this, eventService);
    }

    public int GetZPos() => zPos;

    public void CreateGround()
    {
        GroundController groundController = groundPool.GetGroundObject();
        groundController.ConfigureGroundController(GetZPos());
        zPos += groundSO.ZPos;
    }
}