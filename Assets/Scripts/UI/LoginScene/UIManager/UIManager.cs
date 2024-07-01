using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private int loadSceneIndex;
    [SerializeField] private Button leaderboardsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private AuthManagerView authManagerView;
    [SerializeField] private LeaderboardView leaderboardView;
    [SerializeField] private SoundView soundView;

    private AuthManagerController authManagerController;
    private EventService eventService;
    private LeaderboardController leaderboardController;
    private SoundController soundController;
    private void Start()
    {
        Initialize();
        if (PlayerPrefs.GetInt("LoggedIn") == 0)
        {
            authManagerView.gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("LoggedIn") == 1)
        {
            authManagerView.gameObject.SetActive(false);
        }
        playButton.onClick.AddListener(OnPlayButtonClicked);
        leaderboardsButton.onClick.AddListener(OnLeaderboardbuttonclick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
    }

    private void Initialize()
    {
        eventService = new EventService();
        authManagerController = new AuthManagerController(authManagerView, eventService);
        leaderboardController = new LeaderboardController(leaderboardView, eventService);
        soundController = new SoundController(soundView, eventService);
    }

    private void OnPlayButtonClicked()
    {
        eventService.OnSoundEffectPlay.Invoke(Sounds.BUTTONCLICK);
        SceneManager.LoadScene(loadSceneIndex);
    }

    private void OnLeaderboardbuttonclick()
    {
        eventService.OnSoundEffectPlay.Invoke(Sounds.BUTTONCLICK);
        leaderboardController.ShowLeaderboard();
    }

    private void OnQuitButtonClick()
    {
        eventService.OnSoundEffectPlay.Invoke(Sounds.BUTTONCLICK);
        PlayerPrefs.SetInt("LoggedIn", 0);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void OnDestroy()
    {
        soundController.Dispose();
        leaderboardController.Dispose();
    }
}