using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WordPowerupSO", menuName = "ScriptableObjects/Data/WordPowerupSO")]
public class WordPowerupSO : ScriptableObject
{
    public List<string> Words;
    public AlphabetSO AlphabetSO;
    public BoundarySO BoundarySO;
    public int WordCompleteScore;
}