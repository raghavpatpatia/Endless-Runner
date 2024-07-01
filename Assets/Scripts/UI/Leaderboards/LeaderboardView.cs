using UnityEngine;
using UnityEngine.UI;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private Transform positionToSpawn;
    [SerializeField] private LeaderboardEntityView leaderboardEntityView;
    [SerializeField] private Button closeButton;
    public Transform PositionToSpawn { get { return positionToSpawn; } }
    public LeaderboardEntityView LeaderboardEntityView { get { return leaderboardEntityView; } }
    private LeaderboardController leaderboardController;

    public void Init(LeaderboardController leaderboardController) => this.leaderboardController = leaderboardController;

    private void Start()
    {
        closeButton.onClick.AddListener(OnCloseButtonClick);
    }
    private void OnCloseButtonClick() => leaderboardController.OnCloseButtonClick();
}