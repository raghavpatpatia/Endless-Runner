using UnityEngine;

[CreateAssetMenu(fileName = "BoundarySO", menuName = "ScriptableObjects/Data/BoundarySO")]
public class BoundarySO : ScriptableObject
{
    public float LeftBoundary;
    public float CenterBoundary;
    public float RightBoundary;
}
