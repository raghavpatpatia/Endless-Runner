using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

public class WordPowerupController : IDisposable
{
    public WordPowerupSO WordPowerupSO { get; private set; }
    private WordPowerupView wordPowerupView;
    private EventService eventService;
    public Stack<char> AlphabetStack;
    private Stack<string> wordStack;
    private PlayerController playerController;
    private AlphabetPool alphabetPool;
    public WordPowerupController(WordPowerupSO wordPowerupSO, EventService eventService, WordPowerupView wordPowerupView, PlayerController playerController)
    {
        this.WordPowerupSO = wordPowerupSO;
        this.wordPowerupView = wordPowerupView;
        this.wordPowerupView.Init(this);
        AlphabetStack = new Stack<char>();
        wordStack = new Stack<string>();
        this.eventService = eventService;
        this.playerController = playerController;
        alphabetPool = new AlphabetPool(this, eventService);
        InitializeWordStack();
        SpawnWord();
        eventService.OnWordCollected.AddListener(OnWordCollected);
    }

    private void InitializeWordStack()
    {
        foreach (string word in WordPowerupSO.Words)
        {
            wordStack.Push(word);
        }
    }

    private void SetAlphabetStack(string word)
    {
        Stack<char> reverserStack = new Stack<char>();
        foreach (char c in word)
        {
            reverserStack.Push(c);
        }
        while (reverserStack.Count != 0)
        {
            AlphabetStack.Push(reverserStack.Pop());
        }
    }

    private void SpawnWord()
    {
        if (wordStack.Count != 0)
        {
            string word = wordStack.Peek();
            SetAlphabetStack(word);
            wordPowerupView.StartCoroutine(SpawnAlphabetCoroutine());
        }
        return;
    }

    private IEnumerator SpawnAlphabetCoroutine()
    {
        yield return new WaitForSeconds(5f);
        while (AlphabetStack.Count > 0)
        {
            char alphabet = AlphabetStack.Peek();
            SpawnAlphabet(alphabet);
            yield return new WaitForSeconds(10);
        }
    }

    private void SpawnAlphabet(char alphabet)
    {
        alphabetPool.SetAlphabet(alphabet);
        AlphabetController alphabetController = alphabetPool.GetItem();
        alphabetController.SetAlphabet(new Vector3(GetXPosition(), 0, playerController.PlayerView.transform.position.z + 15f), WordPowerupSO.AlphabetSO.AlphabetDestroyTime);
    }

    private float GetXPosition()
    {
        int random = UnityEngine.Random.Range(0, 3);
        switch (random)
        {
            case 0: return WordPowerupSO.BoundarySO.LeftBoundary;
            case 1: return WordPowerupSO.BoundarySO.CenterBoundary;
            case 2: return WordPowerupSO.BoundarySO.RightBoundary;
            default: return WordPowerupSO.BoundarySO.CenterBoundary;
        }
    }

    private void OnWordCollected()
    {
        if (AlphabetStack.Count == 0)
        {
            eventService.IncreaseScore.Invoke(WordPowerupSO.WordCompleteScore);
            string word = wordStack.Pop();
            wordPowerupView.OnWordColleted(word);
            SpawnWord();
        }
    }

    public void Dispose()
    {
        eventService.OnWordCollected.RemoveListener(OnWordCollected);
    }
}