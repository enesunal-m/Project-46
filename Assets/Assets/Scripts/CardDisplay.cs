using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CardDisplay : MonoBehaviour
{
    public Image image;

    public new TextMeshProUGUI name;
    public TextMeshProUGUI description;

    public TextMeshProUGUI manaCost;

    public int index;
    public int spawnIndex;

    public string id;
    void Start()
    {
        // image.sprite = cardDatabase.cardList[i].image;
        name.text = GameManager.Instance.cardsList.Where(card => card.id == this.id).First().name;
        description.text = GameManager.Instance.cardsList.Where(card => card.id == this.id).First().description;
        manaCost.text = GameManager.Instance.cardsList.Where(card => card.id == this.id).First().cost.ToString();
    }
}
