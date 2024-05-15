﻿using UnityEngine;

public class GroundController
{
    private GroundView groundView;
    private GroundPool groundObjectPool;
    private EventService eventService;
    public GroundController(GroundView groundView, int initialPosition, GroundPool groundObjectPool, EventService eventService)
    {
        this.groundView = GameObject.Instantiate<GroundView>(groundView, new Vector3(0, 0, initialPosition), groundView.gameObject.transform.rotation);
        this.groundView.Init(this);
        this.groundObjectPool = groundObjectPool;
        this.eventService = eventService;
        InitializeCoins();
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        eventService.OnPlayerPassingGround.AddListener(ReturnGroundObject);
    }

    public void ConfigureGroundController(int zPos)
    {
        groundView.gameObject.SetActive(true);
        groundView.transform.position = new Vector3(0, 0, zPos);
        SetCoinsActiveStatus(true);
    }

    private void ReturnGroundObject(Transform playerTransform)
    {
        if (playerTransform.position.z > groundView.EndPoint.position.z)
        {
            groundView.gameObject.SetActive(false);
            groundObjectPool.ReturnItem(this);
            SetCoinsActiveStatus(false);
        }
    }

    private void SetCoinsActiveStatus(bool value)
    {
        foreach (CoinView coin in groundView.CoinViews)
        {
            coin.SetActive(value);
        }
    }

    public void InitializeCoins()
    {
        foreach (CoinView coin in groundView.CoinViews)
        {
            coin.Init(eventService);
        }
    }

    private void UnsubscribeEvents()
    {
        eventService.OnPlayerPassingGround.RemoveListener(ReturnGroundObject);
    }

    ~GroundController() => UnsubscribeEvents();
}