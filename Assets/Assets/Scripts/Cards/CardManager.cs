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

    public void UseSelectedCard(CardTarget cardTarget)
    {
        if (selectedCard.GetComponent<CardDisplay>().cardTarget == CardTarget.Player && cardTarget == CardTarget.Player)
        {
            CardFunctions.cardFunctionDictionary[selectedCard.GetComponent<CardDisplay>().id].run(new List<Enemy>(), selectedCard.GetComponent<CardDisplay>());
            Debug.Log("PLAYER CCC: ");
        }
        else if (selectedCard.GetComponent<CardDisplay>().cardTarget == CardTarget.SingleEnemy && cardTarget == CardTarget.SingleEnemy )
        {
            CardFunctions.cardFunctionDictionary[selectedCard.GetComponent<CardDisplay>().id].
                run(selectedEnemies, selectedCard.GetComponent<CardDisplay>());
            Debug.Log("ENEMty CCC: ");
        }
        selectedCard.GetComponent<CardMouseInteraction>().isCardSelected = false;
        GameManager.Instance.isAnyCardSelected = false;
        Destroy(GameObject.FindGameObjectWithTag("Line"));
        Destroy(selectedCard.gameObject);
        
        PlayerController.Instance.playerMana -= int.Parse(selectedCard.GetComponent<CardDisplay>().manaCost.text.ToString());
        selectedCard = null;
    }
}