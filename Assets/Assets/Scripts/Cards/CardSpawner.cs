using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    GameObject hand;
    public bool spawnOnce = false;
    GameManager gameManager;
    public GameObject card;
    public int cardAmountPenalty;
    void Start()
    {
        hand = GameObject.FindGameObjectWithTag("Hand");
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnerStarter(int spawnAmount = 5)
    {
        StartCoroutine(Spawner(spawnAmount));
    }

    public IEnumerator Spawner(int cardSpawnAmount)
    {

        GameManager.Instance.GetComponent<DeckController>().spawnedCardList = new List<CardDatabaseStructure.ICardInfoInterface>();

        if (GameManager.Instance.GetComponent<DeckController>().deckCardInfoList.Count <= 0)
        {
            GameManager.Instance.GetComponent<DeckController>().deckCardInfoList = GameManager.Instance.GetComponent<DeckController>().discardedCardInfoList;
            GameManager.Instance.GetComponent<DeckController>().discardedCardInfoList = new List<CardDatabaseStructure.ICardInfoInterface>();
        }

        for (int i = 0; i < cardSpawnAmount - cardAmountPenalty; i++)
        {
            int randomIndex = new System.Random().Next(0, GameManager.Instance.GetComponent<DeckController>().deckCardInfoList.Count);
            var cardSpawned = Instantiate(card);

            cardSpawned.GetComponent<CardDisplay>().initializeCard(GameManager.Instance.GetComponent<DeckController>().deckCardInfoList[randomIndex]);

            GameManager.Instance.GetComponent<DeckController>().discardedCardInfoList.Add(GameManager.Instance.GetComponent<DeckController>().deckCardInfoList[randomIndex]);

            GameManager.Instance.GetComponent<DeckController>().spawnedCardList.Add(GameManager.Instance.GetComponent<DeckController>().deckCardInfoList[randomIndex]);
            GameManager.Instance.GetComponent<DeckController>().deckCardInfoList.Remove(GameManager.Instance.GetComponent<DeckController>().deckCardInfoList[randomIndex]);


            cardSpawned.transform.parent = hand.gameObject.transform;
            cardSpawned.GetComponent<CardDisplay>().spawnIndex = i;
            yield return new WaitForSeconds(.15f);
        }

    }
    public void SpawnCardWithId(string id)
    {
        var cardSpawned = Instantiate(card);

        cardSpawned.GetComponent<CardDisplay>().initializeCard(GameManager.Instance.cardsList.Where(card => card.id == id).First());
        cardSpawned.transform.parent = hand.gameObject.transform;
    }
}
