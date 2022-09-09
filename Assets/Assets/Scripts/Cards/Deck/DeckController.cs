using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeckController : MonoBehaviour
{
    GameObject deckPile;
    GameObject card_;
    public List<CardDatabaseStructure.ICardInfoInterface> deckCardInfoList = new List<CardDatabaseStructure.ICardInfoInterface>();
    public List<CardDatabaseStructure.ICardInfoInterface> discardedCardInfoList = new List<CardDatabaseStructure.ICardInfoInterface>();

    public GameObject currentDeckCardAmount;
    public GameObject totalDeckCardAmount;

    public List<CardDatabaseStructure.ICardInfoInterface> spawnedCardList = new List<CardDatabaseStructure.ICardInfoInterface>();

    [SerializeField] private List<GameObject> cardBackList = new List<GameObject>();
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

    public CardDatabaseStructure.ICardInfoInterface DeckPileFiller(int cardSpawnAmount, bool isSelfLoop = false)
    {
        CardDatabaseStructure.ICardInfoInterface cardData = new CardDatabaseStructure.ICardInfoInterface();
        for (int i = 0; i < cardSpawnAmount; i++)
        {
            System.Random randomGenerator = new System.Random();
            int randomIndex = randomGenerator.Next(GameManager.Instance.cardsList.Count);
            cardData = GameManager.Instance.cardsList[randomIndex];
            if (Constants.CardConstants.relicIdList.ContainsKey(cardData.id))
            {
                if (Constants.CardConstants.relicIdList[cardData.id] > 0)
                {
                    cardData = DeckPileFiller(1, true);
                }else
                {
                    Constants.CardConstants.relicIdList[cardData.id] += 1;
                }
            }
            cardData.uuid = i.ToString();
            if (!isSelfLoop)
            {
                deckCardInfoList.Add(cardData);
            }
        }
        return cardData;
    }

    public void UpdateCardCount(int currentCount, int totalCount)
    {
        currentDeckCardAmount.GetComponent<TextMeshProUGUI>().text = currentCount.ToString();
        totalDeckCardAmount.GetComponent<TextMeshProUGUI>().text = totalCount.ToString();

        switch (currentCount)
        {
            case 0:
                break;
            case < 5:
                break;
            case < 10:
                break;
            case < 15:
                break;
            case < 20:
                break;
            case < 25:
                break;
            default:
                break;
        }
    }
}
