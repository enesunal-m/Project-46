using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public List<CardsInfo> deck = new List<CardsInfo>();

    public GameObject cardDatabaseObject;

    public int index;
    public int deckSize;

    void Start()
    {
        var cardDatabase = cardDatabaseObject.GetComponent<CardDatabase>();
        index = 0;
        deckSize = 10;

        for (int i = 0; i < deckSize; i++)
        {
            index = UnityEngine.Random.Range(0, cardDatabase.cardList.Count);
            deck.Add(cardDatabase.cardList[index]);
            Debug.Log(deck);
            Debug.Log("CD" + cardDatabase);
        }
        
    }
}
