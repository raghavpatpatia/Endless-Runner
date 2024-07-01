using UnityEngine;

[CreateAssetMenu(fileName = "AlphabetSO", menuName = "ScriptableObjects/Data/AlphabetSO")]
public class AlphabetSO : ScriptableObject
{
    public Alphabet[] Alphabets = new Alphabet[26];
    public float AlphabetDestroyTime;
}