using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public CardsInfo card;

    public Image image;

    public new TextMeshProUGUI name;
    public TextMeshProUGUI description;

    public TextMeshProUGUI manaCost;

    void Start()
    {
        image.sprite = card.image;
        name.text = card.name;
        description.text = card.description;
        manaCost.text = card.manaCost.ToString();
    }
}
