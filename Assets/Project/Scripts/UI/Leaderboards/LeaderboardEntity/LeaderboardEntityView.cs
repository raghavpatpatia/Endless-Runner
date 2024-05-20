using TMPro;
using UnityEngine;

public class LeaderboardEntityView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI userName;
    [SerializeField] private TextMeshProUGUI scoreText;

    public void SetUserName(string name) => userName.text = name;
    public void SetScore(int score) => scoreText.text = score.ToString();
}