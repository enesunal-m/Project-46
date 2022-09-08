using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CardDisplay : MonoBehaviour
{
    public Image image;
    public Image cardLogo;
    public CardTarget cardTarget;

    public new TextMeshProUGUI name;
    public TextMeshProUGUI description;
    public List<string> types;
    public CardDatabaseStructure.Attributes attributes;

    public TextMeshProUGUI manaCost;
    public int cost;
    public string cardId;

    public int index;
    public int spawnIndex;

    public bool isSelectionCard = false;

    public string id;
    void Start()
    {
        
    }

    public void initializeCard(CardDatabaseStructure.ICardInfoInterface cardInfo)
    {
        // image.sprite = cardDatabase.cardList[i].image;        
        cardLogo.sprite = DrawCardLogo(cardInfo.types);
        image.sprite = drawCardImage(cardInfo.id);
        name.text = cardInfo.name;
        description.text = cardInfo.description;
        types = cardInfo.types;
        attributes = cardInfo.attributes;
        manaCost.text = cardInfo.cost.ToString();
        cardTarget = cardInfo.cardTarget;

        //Card Stats
        cost = cardInfo.cost;
        cardId = cardInfo.id;
    }

    private Sprite DrawCardLogo(List<string> logoTypeList)
    {
        string url = String.Format(Constants.URLConstants.cardLogos, logoTypeList[0]);
        return HelperFunctions.ImageFromUrl(url);
    }
    private Sprite drawCardImage (string cardId)
    {
        string url = String.Format(Constants.URLConstants.cardImages, cardId);
        return HelperFunctions.ImageFromUrl(url);
    }
}
