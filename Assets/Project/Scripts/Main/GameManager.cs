using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private Transform playerSpawnPoint;

    [Header("Ground")]
    [SerializeField] private GroundSO groundSO;
    private float timeBetweenSpwan;

    [Header("UI")]
    [SerializeField] private PointsView pointsView;

    private PlayerController playerController;
    private CommandInvoker commandInvoker;
    private EventService eventService;
    private GroundService groundService;
    private PointsController pointsController;
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        eventService = new EventService();
        commandInvoker = new CommandInvoker();
        playerController = new PlayerController(playerSO, playerSpawnPoint.position, commandInvoker, eventService);
        groundService = new GroundService(groundSO, eventService);
        pointsController = new PointsController(pointsView, eventService);
    }

    private void Update()
    {
        if(timeBetweenSpwan <= 0)
        {
            groundService.CreateGround();
            timeBetweenSpwan = groundSO.SpawnTime;
        }
        else
        {
            timeBetweenSpwan -= Time.deltaTime;
        }
    }
}