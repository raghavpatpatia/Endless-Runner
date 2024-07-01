using System.Collections;
using TMPro;
using UnityEngine;

public class WordPowerupView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wordText;
    [SerializeField] private float totalTime = 5f;
    private WordPowerupController wordPowerupController;
    public void Init(WordPowerupController wordPowerupController)
    {
        this.wordPowerupController = wordPowerupController;
    }

    public void OnWordColleted(string word)
    {
        StartCoroutine(WaitAndDisplayText(word));
    }

    private IEnumerator WaitAndDisplayText(string word)
    {
        wordText.gameObject.SetActive(true);
        wordText.text = word;
        yield return new WaitForSeconds(totalTime);
        wordText.gameObject.SetActive(false);
    }
}