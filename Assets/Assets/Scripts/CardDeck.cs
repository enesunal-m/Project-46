using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public List<ICardInfoInterface> deck = new List<ICardInfoInterface>();

    public GameObject cardDatabaseObject;

    public int index;
    public int deckSize;

    void Start()
    {
        index = 0;
        deckSize = 10;

        for (int i = 0; i < deckSize; i++)
        {
            index = Random.Range(0, GameManager.Instance.cardsList.Count);
            deck.Add(GameManager.Instance.cardsList[index]);
        }
        
    }
}
