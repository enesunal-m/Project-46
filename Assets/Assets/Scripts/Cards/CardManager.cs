using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject selectedCard;
    public List<Enemy> selectedEnemies= new List<Enemy>();

    public GameObject effect;

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
        Debug.Log("BELLLLL " + selectedCard.GetComponent<CardDisplay>().cardTarget);
        if (selectedCard.GetComponent<CardDisplay>().cardTarget == CardTarget.Player && cardTarget == CardTarget.Player)
        {
            CardFunctions.cardFunctionDictionary[selectedCard.GetComponent<CardDisplay>().cardId].run(new List<Enemy>(), selectedCard.GetComponent<CardDisplay>().GetSelfCardInfo());
            if (selectedCard.GetComponent<CardDisplay>().cardId == "conscience")
            {
                Instantiate(effect);
            }
        }
        else if (selectedCard.GetComponent<CardDisplay>().cardTarget == CardTarget.SingleEnemy && cardTarget == CardTarget.SingleEnemy )
        {
            CardFunctions.cardFunctionDictionary[selectedCard.GetComponent<CardDisplay>().cardId].
                run(selectedEnemies, selectedCard.GetComponent<CardDisplay>().GetSelfCardInfo());
            Debug.Log("AAAA " + selectedCard.GetComponent<CardDisplay>().cardId);
        }
        else
        {
            return;
        }
        GameManager.Instance.isCardSelected = false;
        GameManager.Instance.isAnyCardSelected = false;
        Destroy(GameObject.FindGameObjectWithTag("Line"));
        Destroy(selectedCard.gameObject);
        
        PlayerController.Instance.playerMana -= int.Parse(selectedCard.GetComponent<CardDisplay>().manaCost.text.ToString());
        selectedCard = null;
    }

    public void CheckDeck()
    {
        foreach (CardDatabaseStructure.ICardInfoInterface cardInfo in getAllCards())
        {

            if (CardFunctions.customCardFunctionDictionary.ContainsKey(cardInfo.id))
            {
                CardFunctions.customCardFunctionDictionary[cardInfo.id].run(new List<Enemy>(), cardInfo);
            }
        }
        
    }

    public List<CardDatabaseStructure.ICardInfoInterface> getAllCards()
    {
        List<CardDatabaseStructure.ICardInfoInterface> allCards_ = new List<CardDatabaseStructure.ICardInfoInterface>();
        allCards_.AddRange(GameManager.Instance.GetComponent<DeckController>().spawnedCardList);
        allCards_.AddRange(GameManager.Instance.GetComponent<DeckController>().discardedCardInfoList);
        allCards_.AddRange(GameManager.Instance.GetComponent<DeckController>().deckCardInfoList);
        return allCards_;
    }
}
