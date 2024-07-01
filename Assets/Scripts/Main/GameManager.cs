using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private Transform playerSpawnPoint;

    [Header("Ground")]
    [SerializeField] private GroundSO groundSO;

    [Header("Sound")]
    [SerializeField] private SoundView soundView;

    [Header("UI")]
    [Header("Points")]
    [SerializeField] private PointsView pointsView;
    [SerializeField] private PointsAchievementSO pointsAchievementSO;
    [Header("Game Over")]
    [SerializeField] private GameOverView gameOverView;
    [Header("Pause")]
    [SerializeField] private Button pauseButton;
    [SerializeField] private PauseMenuView pauseMenuView;
    [Header("Leaderboard")]
    [SerializeField] private LeaderboardView leaderboardView;
    [Header("Powerup")]
    [SerializeField] private WordPowerupSO wordPowerupSO;
    [SerializeField] private WordPowerupView wordPowerupView;

    private PlayerController playerController;
    private CommandInvoker commandInvoker;
    private EventService eventService;
    private GroundService groundService;
    private PointsController pointsController;
    private GameOverController gameOverController;
    private LeaderboardController leaderboardController;
    private SoundController soundController;
    private WordPowerupController wordPowerupController;
    private void Start()
    {
        Init();
        pauseButton.onClick.AddListener(OnPauseButtonClick);
        eventService.OnBGMusicPlay.Invoke(Sounds.BGMUSIC);
    }

    private void Init()
    {
        eventService = new EventService();
        commandInvoker = new CommandInvoker();
        pauseMenuView.Init(eventService);
        playerController = new PlayerController(playerSO, playerSpawnPoint.position, commandInvoker, eventService);
        groundService = new GroundService(groundSO, eventService);
        pointsController = new PointsController(pointsView, eventService, pointsAchievementSO);
        leaderboardController = new LeaderboardController(leaderboardView, eventService);
        gameOverController = new GameOverController(gameOverView, eventService, pointsController, leaderboardController);
        soundController = new SoundController(soundView, eventService);
        wordPowerupController = new WordPowerupController(wordPowerupSO, eventService, wordPowerupView, playerController);
    }

    private void Update()
    {
        if (!playerController.IsPlayerDead)
            groundService.GenerateGround();
    }

    private void OnPauseButtonClick()
    {
        eventService.OnSoundEffectPlay.Invoke(Sounds.BUTTONCLICK);
        pauseMenuView.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        soundController.Dispose();
        groundService.Dispose();
        playerController.Dispose();
        gameOverController.Dispose();
        leaderboardController.Dispose();
        pointsController.Dispose();
        wordPowerupController.Dispose();
    }
}