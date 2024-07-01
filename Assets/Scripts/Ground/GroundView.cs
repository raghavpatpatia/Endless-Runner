using UnityEngine;

public class GroundView : MonoBehaviour
{
    [SerializeField] private Transform endPoint;
    [SerializeField] private CoinView[] coinViews;
    public Transform EndPoint { get { return endPoint; } }
    public CoinView[] CoinViews { get { return coinViews; } }
    private GroundController groundController;
    public void Init(GroundController groundController) => this.groundController = groundController;
}