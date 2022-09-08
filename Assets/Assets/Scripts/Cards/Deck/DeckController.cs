using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    GameObject deckPile;
    GameObject card_;
    public List<CardDatabaseStructure.ICardInfoInterface> deckCardInfoList = new List<CardDatabaseStructure.ICardInfoInterface>();
    public List<CardDatabaseStructure.ICardInfoInterface> discardedCardInfoList = new List<CardDatabaseStructure.ICardInfoInterface>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildDeck(int cardCount)
    {
        DeckPileFiller(cardCount);
    }

    public void DeckPileFiller(int cardSpawnAmount)
    {
        for (int i = 0; i < cardSpawnAmount; i++)
        {
            System.Random randomGenerator = new System.Random();
            int randomIndex = randomGenerator.Next(GameManager.Instance.cardsList.Count);
            CardDatabaseStructure.ICardInfoInterface cardData = GameManager.Instance.cardsList[randomIndex];
            cardData.uuid = i.ToString();
            deckCardInfoList.Add(cardData);
        }
    }
}
