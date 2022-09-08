using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CardSelectorController : MonoBehaviour
{
    [SerializeField] private List<GameObject> panelList;
    [SerializeField] private GameObject card;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void generateCardsForSelector(int cardSpawnAmount)
    {
        for (int i = 0; i < cardSpawnAmount; i++)
        {
            int randomIndex = Random.Range(0, GameManager.Instance.cardsList.Count);
            var cardSpawned = Instantiate(card, panelList[i].gameObject.transform);
            Debug.Log("YARATTIM ABÝ: " + cardSpawned.gameObject.transform.position);
            cardSpawned.GetComponent<CardDisplay>().id = GameManager.Instance.cardsList[randomIndex].id;
            cardSpawned.GetComponent<Canvas>().sortingOrder = 5;
        }
    }
}
