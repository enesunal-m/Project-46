using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CardManager : MonoBehaviour
{
    public GameObject selectedCard;
    public List<Enemy> selectedEnemies= new List<Enemy>();

    public GameObject effect;
    public GameObject attackEffect;
    public GameObject buffEffect;
    public GameObject shieldEffect;
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
            
            if (selectedCard.GetComponent<CardDisplay>().types.Contains("Buff"))
            {
                var buffTemp = Instantiate(buffEffect);
                buffTemp.transform.position = PlayerController.Instance.transform.position;
            }
            if (selectedCard.GetComponent<CardDisplay>().cardId==("guard") || selectedCard.GetComponent<CardDisplay>().cardId==("holyShield"))
            {
                var shieldTemp = Instantiate(shieldEffect);
                shieldTemp.transform.position = PlayerController.Instance.transform.position;
            }
            if (selectedCard.GetComponent<CardDisplay>().cardId == "conscience")
            {
                var effectTemp = Instantiate(effect);
                effectTemp.transform.position = PlayerController.Instance.transform.position;
            }
        }
        else if (selectedCard.GetComponent<CardDisplay>().cardTarget == CardTarget.SingleEnemy && cardTarget == CardTarget.SingleEnemy )
        {
            CardFunctions.cardFunctionDictionary[selectedCard.GetComponent<CardDisplay>().cardId].
                run(selectedEnemies, selectedCard.GetComponent<CardDisplay>().GetSelfCardInfo());

            if (selectedCard.GetComponent<CardDisplay>().cardId == "attack" || selectedCard.GetComponent<CardDisplay>().cardId == "demonicAttack" || selectedCard.GetComponent<CardDisplay>().cardId == "gambler" || selectedCard.GetComponent<CardDisplay>().cardId == "payback" || selectedCard.GetComponent<CardDisplay>().cardId == "truth")
            {
                foreach (var item in selectedEnemies)
                {
                    var att = Instantiate(attackEffect, item.transform);
                    att.transform.position = new Vector3(item.transform.position.x + 1.2f, item.transform.position.y + 1, item.transform.position.z);
                }
                
            }
        }
        else
        {
            return;
        }
        GameObject destroyEffect = selectedCard.transform.GetChild(7).transform.gameObject;
        destroyEffect.SetActive(true);
        Destroy(GameObject.FindGameObjectWithTag("Line"));
        Destroy(selectedCard.gameObject, destroyEffect.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 0.475f);
        Invoke("WaitForAnimationEnds", destroyEffect.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 0.475f);
        PlayerController.Instance.playerMana -= int.Parse(selectedCard.GetComponent<CardDisplay>().manaCost.text.ToString());
    }
    private void WaitForAnimationEnds()
    {
        GameManager.Instance.isCardSelected = false;
        GameManager.Instance.isAnyCardSelected = false;
        GameManager.Instance.isSelectedCardUsed = false;
        
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
        allCards_.AddRange(GameManager.Instance.GetComponent<DeckController>().handCardInfoList);
        allCards_.AddRange(GameManager.Instance.GetComponent<DeckController>().deckCardInfoList);
        return allCards_;
    }
    public List<CardDatabaseStructure.ICardInfoInterface> getAllCardsWithoutHand()
    {
        List<CardDatabaseStructure.ICardInfoInterface> allCards_ = new List<CardDatabaseStructure.ICardInfoInterface>();
        allCards_.AddRange(GameManager.Instance.GetComponent<DeckController>().discardedCardInfoList);
        allCards_.AddRange(GameManager.Instance.GetComponent<DeckController>().deckCardInfoList);
        return allCards_;
    }
}
