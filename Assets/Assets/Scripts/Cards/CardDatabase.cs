using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardDatabase
{
    public static List<CardDatabaseStructure.ICardInfoInterface> initalizecardsList(CardDatabaseStructure.Root cardDatabaseJson)
    {
        List<CardDatabaseStructure.ICardInfoInterface> cardsList = new List<CardDatabaseStructure.ICardInfoInterface>();

        foreach (CardDatabaseStructure.SingleEnemy card in cardDatabaseJson.singleEnemy)
        {
            card.description = HelperFunctions.descriptionBuilder(card);
            card.cardTarget = CardTarget.SingleEnemy;
            cardsList.Add(card);
        }
        foreach (CardDatabaseStructure.Player card in cardDatabaseJson.player)
        {
            card.description = HelperFunctions.descriptionBuilder(card);
            card.cardTarget = CardTarget.Player;
            cardsList.Add(card);
        }

        return cardsList;
    }
}
