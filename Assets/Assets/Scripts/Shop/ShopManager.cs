using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public RectTransform canvas;
    public GameObject card;
    public GameObject gold;
    [SerializeField] TMP_Text healt;
    List<CardDatabaseStructure.ICardInfoInterface> cardList;
    // Start is called before the first frame update
    int cardxPosition = 375;
    int cardyPosition = 375;

    List<int> indexes;
    void Start()
    {
        healt.text = HealtPercentCalculater(500,400)+"/100";
        cardList = GameManager.Instance.cardsList;
        indexes = new List<int>();

        for (int i = 0; i < cardList.Count; i++)
        {
            indexes.Add(i);
        }

        getPosition();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void getPosition()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject spawnedCard = Instantiate(card);
                GameObject spawnedGold = Instantiate(gold);
                spawnedCard.GetComponent<CardDisplay>().initializeCard(cardList[RandomIndex()]);
                spawnedCard.transform.parent = canvas;
                spawnedGold.transform.parent = spawnedCard.transform;
                spawnedCard.GetComponent<Canvas>().sortingOrder = 1;
                spawnedCard.GetComponent<RectTransform>().position = new Vector3(cardxPosition, cardyPosition, 0);
                spawnedGold.GetComponent<RectTransform>().position = new Vector3(cardxPosition - 25, cardyPosition - 200, 0);
                cardxPosition += 285;
                ColorControl(99, spawnedGold.GetComponentInChildren<TMP_Text>());
            }
            cardyPosition += 400;
            cardxPosition = 375;

        }

    }
    void ColorControl(int cardPrice, TMP_Text cardPriceText)
    {
        if (cardPrice > MoneyManager.totalMoney)
        {
            cardPriceText.color = Color.red;
        }
        else
        {
            cardPriceText.color = Color.white;
        }

    }

    int RandomIndex()
    {

        int index = Random.Range(0, indexes.Count);

        int value = indexes[index];
        indexes.RemoveAt(index);
        return value;

    }
    int HealtPercentCalculater(int totalHealt, int currentHealt)
    {
        return (currentHealt * 100) / totalHealt ;
    }
}
