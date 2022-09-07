using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    GameObject hand;
    public bool spawnOnce = false;
    GameManager gameManager;
    public GameObject card;
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
        for (int i = 0; i < cardSpawnAmount; i++)
        {
            int randomIndex = Random.Range(0, GameManager.Instance.cardsList.Count);
            var cardSpawned = Instantiate(card);

            cardSpawned.GetComponent<CardDisplay>().id = GameManager.Instance.cardsList[randomIndex].id;
            cardSpawned.transform.parent = hand.gameObject.transform;
            cardSpawned.GetComponent<CardDisplay>().spawnIndex = i;
            yield return new WaitForSeconds(.15f);
        }
        
    }
    public void SpawnCardWithId(string id)
    {
        var cardSpawned = Instantiate(card);

        cardSpawned.GetComponent<CardDisplay>().id = id;
        cardSpawned.transform.parent = hand.gameObject.transform;
    }
}
