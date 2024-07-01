using UnityEngine;

public class AlphabetView : MonoBehaviour
{
    public AlphabetController AlphabetController { get; private set; }
    public void SetAlphabetController(AlphabetController alphabetController) => this.AlphabetController = alphabetController;
    private void Start()
    {
        StartCoroutine(AlphabetController.DestroyAfterSomeTime());
    }
    private void OnTriggerEnter(Collider other)
    {
        AlphabetController.OnTriggerEnter(other);
    }
}