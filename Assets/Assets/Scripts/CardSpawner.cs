using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    GameObject hand;
    bool spawnOnce = false;
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
        if (!spawnOnce && gameManager.turnSide == Characters.Player)
        {
            StartCoroutine(Spawner());
            spawnOnce = true;
        }
        else if (gameManager.turnSide == Characters.Enemy)
        {
            spawnOnce = false;
        }
    }
    IEnumerator Spawner()
    {
        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, GameManager.Instance.cardsList.Count);
            var cardSpawned = Instantiate(card);

            cardSpawned.GetComponent<CardDisplay>().id = GameManager.Instance.cardsList[randomIndex].id;
            cardSpawned.transform.parent = hand.gameObject.transform;
            cardSpawned.GetComponent<CardDisplay>().spawnIndex = i;
            yield return new WaitForSeconds(.15f);
        }
        
    }
}
