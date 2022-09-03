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
        gameManager = this.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!spawnOnce && gameManager.turnSide == Characters.Player)
        {
           
            for (int i = 0; i < 5; i++)
            {
                var co = Spawner();
            }
            spawnOnce = true;

        }
        else if (gameManager.turnSide == Characters.Enemy)
        {
            spawnOnce = false;
        }
    }
    IEnumerator Spawner()
    {
        var cardSpawned = Instantiate(card);
        cardSpawned.transform.parent = hand.gameObject.transform;
        yield return new WaitForSeconds(1.2f);
    }
}
