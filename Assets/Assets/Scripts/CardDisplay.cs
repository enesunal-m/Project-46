using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public GameObject cardDatabaseObject;

    public Image image;

    public new TextMeshProUGUI name;
    public TextMeshProUGUI description;

    public TextMeshProUGUI manaCost;

    public int index;
    public int spawnIndex;
    void Start()
    {
        var cardDatabase = cardDatabaseObject.GetComponent<CardDatabase>();

        int i = UnityEngine.Random.Range(0, cardDatabase.cardList.Count);
        index = i;
        image.sprite = cardDatabase.cardList[i].image;
        name.text = cardDatabase.cardList[i].name;
        description.text = cardDatabase.cardList[i].description;
        manaCost.text = cardDatabase.cardList[i].manaCost.ToString();
    }
}
