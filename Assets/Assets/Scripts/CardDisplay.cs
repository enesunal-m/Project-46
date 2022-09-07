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

    public int index;
    public int spawnIndex;

    public string id;
    void Start()
    {
        // image.sprite = cardDatabase.cardList[i].image;        
        cardLogo.sprite = DrawCardLogo(GameManager.Instance.cardsList.Where(card => card.id == this.id).First().types);
        image.sprite = drawCardImage(GameManager.Instance.cardsList.Where(card => card.id == this.id).First().id);
        name.text = GameManager.Instance.cardsList.Where(card => card.id == this.id).First().name;
        description.text = GameManager.Instance.cardsList.Where(card => card.id == this.id).First().description;
        types = GameManager.Instance.cardsList.Where(card => card.id == this.id).First().types;
        attributes = GameManager.Instance.cardsList.Where(card => card.id == this.id).First().attributes;
        manaCost.text = GameManager.Instance.cardsList.Where(card => card.id == this.id).First().cost.ToString();
        cardTarget = GameManager.Instance.cardsList.Where(card => card.id == this.id).First().cardTarget;
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
