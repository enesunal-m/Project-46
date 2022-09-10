using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public RectTransform canvas;
    public GameObject card;
    public GameObject gold;
    [SerializeField] TMP_Text health;
    [SerializeField] GameObject discountImage;
    public List<CardDatabaseStructure.ICardInfoInterface> cardList;
    public List<CardDatabaseStructure.ICardInfoInterface> selectedCardsList = new List<CardDatabaseStructure.ICardInfoInterface>();
    // Start is called before the first frame update
    int cardxPosition = 375;
    int cardyPosition = 375;

    List<int> indexes;
    void Start()
    {
        health.text = HealthPercentCalculater() + "/100";
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
                int x = RandomCardPrice(spawnedCard.GetComponent<CardDisplay>().tier);
                spawnedGold.GetComponentInChildren<TMP_Text>().text = x.ToString();
                ColorControl(x, spawnedGold.GetComponentInChildren<TMP_Text>());
            }
            cardyPosition += 400;
            cardxPosition = 375;

        }
        selectDiscountCard();
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
    void selectDiscountCard()
    {
        GameObject[] goldPrices = GameObject.FindGameObjectsWithTag("CardPrice");
        int x = Random.Range(0, goldPrices.Length);
        GameObject go = Instantiate(discountImage);
        go.transform.parent= goldPrices[x].gameObject.transform;
        go.transform.position= goldPrices[x].gameObject.transform.position + new Vector3(-85, 185, 0);        
        goldPrices[x].gameObject.GetComponentInChildren<TMP_Text>().text=((int)(int.Parse(goldPrices[x].gameObject.GetComponentInChildren<TMP_Text>().text)*0.6)).ToString();
        ColorControl(int.Parse(goldPrices[x].gameObject.GetComponentInChildren<TMP_Text>().text), goldPrices[x].gameObject.GetComponentInChildren<TMP_Text>());
    }

    
    public void cardColorUpdate()
    {
        GameObject[] goldPrices = GameObject.FindGameObjectsWithTag("CardPrice");
        foreach (GameObject gold in goldPrices)
        {
            ColorControl(int.Parse(gold.gameObject.GetComponentInChildren<TMP_Text>().text), gold.gameObject.GetComponentInChildren<TMP_Text>());
        }
    }

    int RandomCardPrice(CardTier tier)
    {

        switch (tier)
        {
            case CardTier.Tier1:
                return Random.Range(30, 50);                
            case CardTier.Tier2:
                return Random.Range(50, 70);
            case CardTier.Tier3:
                return Random.Range(70, 90);
            case CardTier.Tier4:
                return Random.Range(90, 110);
            default:
                return 0;
        }
    }

    int RandomIndex()
    {  

        int index = Random.Range(0, indexes.Count);
        int value = indexes[index];
        // indexes.RemoveAt(index);
        return value;

    }
    int HealthPercentCalculater()
    {
        Debug.Log(PlayerPrefs.GetFloat("playerHealth"));
        return (int)((PlayerPrefs.GetFloat("playerHealth") * 100) / Constants.PlayerConstants.initialFullHealth);
    }

    public void Leave()
    {
        PlayerPrefs.SetInt("notStartOfRun", 1);
        SceneManager.LoadScene(0);
    }
}
