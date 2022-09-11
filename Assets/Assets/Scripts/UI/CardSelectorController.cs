using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class CardSelectorController : MonoBehaviour
{
    [SerializeField] private List<GameObject> panelList;
    [SerializeField] private GameObject selectCardObject;
    public List<CardDatabaseStructure.ICardInfoInterface> selectedCardsList = new List<CardDatabaseStructure.ICardInfoInterface>();

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
            var cardSpawned = Instantiate(selectCardObject, panelList[i].gameObject.transform);
            cardSpawned.GetComponent<CardDisplay>().initializeCard(GameManager.Instance.cardsList[randomIndex]);

            cardSpawned.GetComponent<CardDisplay>().isSelectionCard = true;

            cardSpawned.GetComponent<Canvas>().sortingOrder = 5;
        }
    }

    public void selectCard(CardDisplay cardObject)
    {

        CardDatabaseStructure.ICardInfoInterface cardInfo = new CardDatabaseStructure.ICardInfoInterface();

        selectedCardsList.Add(GameManager.Instance.cardsList.Where(card => card.id == cardObject.cardId).First());
        GameManager.Instance.GetComponent<DeckController>().deckCardInfoList.AddRange(selectedCardsList);
        Debug.Log(CardManager.Instance.getAllCards().Count);
        JsonController.createCardJsonTempWithPath(Constants.URLConstants.cardTempDatabaseJsonBaseUrl, CardManager.Instance.getAllCards());

        PlayerPrefs.SetInt("notStartOfRun", 1);
        // SceneManager.LoadScene(0);
        GameManager.Instance.GoToShopScene();
    }
}
