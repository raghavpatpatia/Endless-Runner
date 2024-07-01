using System;
using System.Collections;
using UnityEngine;

public class GroundService : IDisposable
{
    private GroundSO groundSO;
    private float zPos;
    private GroundPool groundPool;
    private EventService eventService;
    private float timeBetweenSpwan;
    private float spawnTime;

    public GroundService(GroundSO groundSO, EventService eventService)
    {
        this.groundSO = groundSO;
        this.zPos = groundSO.ZPos;
        this.eventService = eventService;
        groundPool = new GroundPool(groundSO, this, eventService);
        spawnTime = groundSO.SpawnTime;
        eventService.IncreaseSpeed.AddListener(IncreaseGroundGenerationSpeed);
    }

    public float GetZPos() => zPos;

    private  void CreateGround()
    {
        GroundController groundController = groundPool.GetGroundObject();
        groundController.ConfigureGroundController(GetZPos());
        zPos += groundSO.ZPos;
    }

    public void GenerateGround()
    {
        if (timeBetweenSpwan <= 0)
        {
            CreateGround();
            timeBetweenSpwan = spawnTime;
        }
        else
        {
            timeBetweenSpwan -= Time.deltaTime;
        }
    }

    private void IncreaseGroundGenerationSpeed(float speed)
    {
        if (spawnTime > 0)
            spawnTime -= speed;
        else
            spawnTime = 0;
    }

    public void Dispose()
    {
        groundPool.DisposeGroundControllers();
        eventService.IncreaseSpeed.RemoveListener(IncreaseGroundGenerationSpeed);
    }
}