using UnityEngine;

public class CoinView : MonoBehaviour
{
    private EventService eventService;
    public void Init(EventService eventService) => this.eventService = eventService;
    public void SetActive(bool value) => gameObject.SetActive(value);
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerView>() != null)
        {
            eventService.OnSoundEffectPlay.Invoke(Sounds.COINCOLLECT);
            gameObject.SetActive(false);
            eventService.OnCoinCollect.Invoke();
        }
    }
}