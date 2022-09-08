using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject card;
    public int rowNumber = 2;
    public int cardNumberInRow = 5;
    int i;
    int j;
    Vector3 position;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < rowNumber; i++)
        {
            for(j = 0; j < cardNumberInRow; j++)
            {
                position = new Vector3(-7 + (3.5f * j), 1.6f + (i * -3.2f), 0);
                GameObject cardSpawned = Instantiate(card, position,Quaternion.identity);
                Debug.Log("pırt");
                int randomIndex = Random.Range(0, 5);
                Debug.Log("zort");
                
                cardSpawned.GetComponent<CardDisplay>().id = GameManager.Instance.cardsList[randomIndex].id;
                Debug.Log("ossuruk");
                cardSpawned.transform.position = position;  
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
