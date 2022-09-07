using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject selectedCard;
    public List<Enemy> selectedEnemies= new List<Enemy>();

    public static CardManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UseSelectedCard()
    {
        CardFunctions.cardFunctionDictionary[selectedCard.GetComponent<CardDisplay>().id].
            run(selectedEnemies, selectedCard.GetComponent<CardDisplay>());

        PlayerController.getInstance().playerMana -= int.Parse(selectedCard.GetComponent<CardDisplay>().manaCost.text.ToString());
    }
}
