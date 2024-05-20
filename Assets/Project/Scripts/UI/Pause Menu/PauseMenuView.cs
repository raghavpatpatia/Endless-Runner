using UnityEngine;
using UnityEngine.UI;

public class PauseMenuView : MonoBehaviour
{
    [SerializeField] private Image audioImage;
    [SerializeField] private Slider audioSlider;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Sprite audioFullSprite;
    [SerializeField] private Sprite audioMuteSprite;
    private EventService eventService;
    private SoundController soundController;
    private void OnEnable() => Time.timeScale = 0f;
    private void Start()
    {
        audioSlider.onValueChanged.AddListener(OnAudioSliderValueChanged);
        resumeButton.onClick.AddListener(OnResumeButtonClick);
    }
    public void Init(EventService eventService) => this.eventService = eventService;
    private void OnDisable() => Time.timeScale = 1.0f;
    
    private void OnResumeButtonClick()
    {
        eventService.OnSoundEffectPlay.Invoke(Sounds.BUTTONCLICK);
        gameObject.SetActive(false);
    }

    private void OnAudioSliderValueChanged(float value)
    {
        eventService.OnBGMusicVolumeChange.Invoke(value);
        UpdateAudioIcon(value);
    }

    private void UpdateAudioIcon(float value)
    {
        if (value == 0)
        {
            audioImage.sprite = audioMuteSprite;
        }
        else
        {
            audioImage.sprite = audioFullSprite;
        }
    }

}