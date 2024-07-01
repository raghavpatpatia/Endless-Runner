using UnityEngine;

public class SoundView : MonoBehaviour
{
    [SerializeField] private AudioSource bgMusic, soundEffects;
    [SerializeField] private SoundType[] soundType;
    public AudioSource BGMusic { get { return bgMusic; } }
    public AudioSource SoundEffect { get { return soundEffects; } }
    public SoundType[] SoundType { get { return soundType; } }
}