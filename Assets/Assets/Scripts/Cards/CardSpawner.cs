using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    GameObject hand;
    public bool spawnOnce = false;
    public GameObject card;
    public int cardAmountPenalty;
    void Start()
    {
        hand = GameObject.FindGameObjectWithTag("Hand");
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnerStarter(int spawnAmount = 5)
    {
        GameManager.Instance.areCardsSpawning = true;
        StartCoroutine(Spawner(spawnAmount));
    }

    public IEnumerator Spawner(int cardSpawnAmount)
    {

        GameManager.Instance.GetComponent<DeckController>().spawnedCardList = new List<CardDatabaseStructure.ICardInfoInterface>();

        if (GameManager.Instance.GetComponent<DeckController>().deckCardInfoList.Count <= cardSpawnAmount)
        {
            GameManager.Instance.GetComponent<DeckController>().deckCardInfoList = GameManager.Instance.GetComponent<DeckController>().discardedCardInfoList;
            GameManager.Instance.GetComponent<DeckController>().discardedCardInfoList = new List<CardDatabaseStructure.ICardInfoInterface>();
        }

        for (int i = 0; i < cardSpawnAmount - cardAmountPenalty; i++)
        {
            int randomIndex = new System.Random().Next(0, GameManager.Instance.GetComponent<DeckController>().deckCardInfoList.Count);
            var cardSpawned = Instantiate(card);


            cardSpawned.GetComponent<CardDisplay>().initializeCard(GameManager.Instance.GetComponent<DeckController>().deckCardInfoList[randomIndex]);

            GameManager.Instance.GetComponent<DeckController>().handCardInfoList.Add(GameManager.Instance.GetComponent<DeckController>().deckCardInfoList[randomIndex]);
            GameManager.Instance.GetComponent<DeckController>().deckCardInfoList.Remove(GameManager.Instance.GetComponent<DeckController>().deckCardInfoList[randomIndex]);

            cardSpawned.transform.parent = hand.gameObject.transform;
            cardSpawned.GetComponent<CardDisplay>().spawnIndex = i;
            GameManager.Instance.GetComponent<DeckController>().UpdateCardCount(GameManager.Instance.GetComponent<DeckController>().deckCardInfoList.Count, CardManager.Instance.getAllCards().Count, GameManager.Instance.GetComponent<DeckController>().discardedCardInfoList.Count);
            yield return new WaitForSeconds(.15f);
        }

        GameManager.Instance.areCardsSpawning = false;
    }

    public void HandDiscarder()
    {
        GameManager.Instance.GetComponent<DeckController>().discardedCardInfoList.AddRange(GameManager.Instance.GetComponent<DeckController>().handCardInfoList);
        GameManager.Instance.GetComponent<DeckController>().handCardInfoList = new List<CardDatabaseStructure.ICardInfoInterface>();
    }

    public void SpawnCardWithId(string id)
    {
        var cardSpawned = Instantiate(card);

        cardSpawned.GetComponent<CardDisplay>().initializeCard(GameManager.Instance.cardsList.Where(card => card.id == id).First());
        cardSpawned.transform.parent = hand.gameObject.transform;
    }
}
