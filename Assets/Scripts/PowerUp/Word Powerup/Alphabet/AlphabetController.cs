using System.Collections;
using UnityEngine;

public class AlphabetController
{
    public AlphabetView AlphabetView { get; private set; }
    private WordPowerupController wordPowerupController;
    private EventService eventService;
    private AlphabetPool alphabetPool;
    private float alphabetDestroyTime;
    public char AlphabetCharacter { get; private set; }
    public AlphabetController(AlphabetView alphabetView, WordPowerupController wordPowerupController, EventService eventService, char alphabetCharacter, AlphabetPool alphabetPool)
    {
        this.AlphabetView = GameObject.Instantiate<AlphabetView>(alphabetView);
        this.AlphabetView.SetAlphabetController(this);
        this.wordPowerupController = wordPowerupController;
        this.eventService = eventService;
        this.AlphabetCharacter = alphabetCharacter;
        this.alphabetPool = alphabetPool;
    }
    public void SetAlphabet(Vector3 position, float time)
    {
        AlphabetView.transform.position = position;
        alphabetDestroyTime = time;
        AlphabetView.gameObject.SetActive(true);
    }

    public IEnumerator DestroyAfterSomeTime()
    {
        yield return new WaitForSeconds(alphabetDestroyTime);
        alphabetPool.ReturnItem(this);
        AlphabetView.gameObject.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerView>() != null)
        {
            wordPowerupController.AlphabetStack.Pop();
            alphabetPool.ReturnItem(this);
            AlphabetView.gameObject.SetActive(false);
            eventService.OnWordCollected.Invoke();
        }
    }
}