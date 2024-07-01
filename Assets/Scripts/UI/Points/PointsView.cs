using UnityEngine;
using TMPro;

public class PointsView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    public void SetPointsAmount(int amount) => pointsText.text = amount.ToString();
}