using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private Button leaderboardButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private int quitButtonScene;

    private GameOverController gameOverController;
    private EventService eventService;

    private void Start()
    {
        leaderboardButton.onClick.AddListener(gameOverController.OnLeaderboardButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
    }

    public void Init(GameOverController gameOverController, EventService eventService)
    {
        this.gameOverController = gameOverController;
        this.eventService = eventService;
    }

    public void SetPointText(int amount) => pointText.text = string.Format("Total Score: {0}", amount);

    private void OnQuitButtonClick()
    {
        eventService.OnSoundEffectPlay.Invoke(Sounds.BUTTONCLICK);
        SceneManager.LoadScene(quitButtonScene);
    }
}