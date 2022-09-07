using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardDatabase
{
    public static List<ICardInfoInterface> initalizecardsList(Root cardDatabaseJson)
    {
        List<ICardInfoInterface> cardsList = new List<ICardInfoInterface>();

        foreach (SingleEnemy card in cardDatabaseJson.singleEnemy)
        {
            card.description = HelperFunctions.descriptionBuilder(card);
            card.cardTarget = CardTarget.SingleEnemy;
            cardsList.Add(card);
        }
        foreach (Player card in cardDatabaseJson.player)
        {
            card.description = HelperFunctions.descriptionBuilder(card);
            card.cardTarget = CardTarget.Player;
            cardsList.Add(card);
        }

        return cardsList;
    }
}
