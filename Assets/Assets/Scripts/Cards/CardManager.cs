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
            CardFunctions.cardFunctionDictionary[selectedCard.GetComponent<CardDisplay>().cardId].run(new List<Enemy>(), selectedCard.GetComponent<CardDisplay>().GetSelfCardInfo());
        }
        else if (selectedCard.GetComponent<CardDisplay>().cardTarget == CardTarget.SingleEnemy && cardTarget == CardTarget.SingleEnemy )
        {
            CardFunctions.cardFunctionDictionary[selectedCard.GetComponent<CardDisplay>().cardId].
                run(selectedEnemies, selectedCard.GetComponent<CardDisplay>().GetSelfCardInfo());
        }
        GameManager.Instance.isCardSelected = false;
        GameManager.Instance.isAnyCardSelected = false;
        Destroy(GameObject.FindGameObjectWithTag("Line"));
        Destroy(selectedCard.gameObject);
        
        PlayerController.Instance.playerMana -= int.Parse(selectedCard.GetComponent<CardDisplay>().manaCost.text.ToString());
        selectedCard = null;
    }

    public void CheckSpawnedCards()
    {
        foreach (CardDatabaseStructure.ICardInfoInterface cardInfo in GameManager.Instance.GetComponent<DeckController>().spawnedCardList)
        {
            foreach (string type in cardInfo.types)
            {
                if (CardFunctions.customCardFunctionDictionary.ContainsKey(type))
                {
                    Debug.Log(cardInfo.name);
                    CardFunctions.customCardFunctionDictionary[cardInfo.id].run(new List<Enemy>(), cardInfo);
                }
            }
        }
    }
}
