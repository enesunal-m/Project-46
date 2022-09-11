using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Linq;

public class ShopMouseInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    ShopManager shopManager;
    private void Start()
    {
        shopManager = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<ShopManager>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        if (int.Parse(eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.GetComponentInChildren<RawImage>().gameObject.GetComponentInChildren<TMP_Text>().text) <= MoneyManager.totalMoney)
        {
            CardDisplay cardObject = eventData.pointerCurrentRaycast.gameObject.transform.parent.GetComponent<CardDisplay>();
            CardDatabaseStructure.ICardInfoInterface cardInfo = new CardDatabaseStructure.ICardInfoInterface();

            shopManager.selectedCardsList.Add(shopManager.cardList.Where(card => card.id == cardObject.cardId).First());
            List<CardDatabaseStructure.ICardInfoInterface> lastCardDeck = JsonController.readCardJsonTempWithPath(Constants.URLConstants.cardTempDatabaseJsonBaseUrl);
            lastCardDeck.AddRange(shopManager.selectedCardsList);
            JsonController.createCardJsonTempWithPath(Constants.URLConstants.cardTempDatabaseJsonBaseUrl, lastCardDeck);

            Debug.Log(JsonController.readCardJsonTempWithPath(Constants.URLConstants.cardTempDatabaseJsonBaseUrl).Count);

            eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.SetActive(false);
            MoneyManager.Instance.loseMoney(int.Parse(eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.GetComponentInChildren<RawImage>().gameObject.GetComponentInChildren<TMP_Text>().text));

            shopManager.cardColorUpdate();

        }


    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1);
        transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 15, this.transform.position.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 15, this.transform.position.z);
    }
}
