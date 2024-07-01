using System;
using System.Collections.Generic;

public class AlphabetPool : GenericPool<AlphabetController>
{
    private char alphabet;
    private WordPowerupController wordPowerupController;
    private EventService eventService;
    public AlphabetPool(WordPowerupController wordPowerupController, EventService eventService)
    {
        this.wordPowerupController = wordPowerupController;
        this.eventService = eventService;
    }

    public void SetAlphabet(char alphabet) => this.alphabet = alphabet;

    public AlphabetController GetItem()
    {
        PooledObject<AlphabetController> pooledAlphabet = PooledItems.Find(p => p.Item.AlphabetCharacter == alphabet && !p.IsUsed);
        if (pooledAlphabet != null)
        {
            pooledAlphabet.IsUsed = true;
            return pooledAlphabet.Item;
        }
        return CreateNewPooledObject<AlphabetController>();
    }

    protected override AlphabetController CreateItem<U>()
    {
        AlphabetView alphabetView = Array.Find(wordPowerupController.WordPowerupSO.AlphabetSO.Alphabets, i => i.AlphabetName == alphabet).AlphabetView;
        AlphabetController alphabetController = new AlphabetController(alphabetView, wordPowerupController, eventService, alphabet, this);
        return alphabetController;
    }
}