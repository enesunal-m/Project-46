using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardDatabase
{
    public static List<ICardInfoInterface> initalizecardsList(Root cardDatabaseJson)
    {
        List<ICardInfoInterface> cardsList = new List<ICardInfoInterface>();

        foreach (var item in cardDatabaseJson.all)
        {
            
        }
        foreach (var item in cardDatabaseJson.mutlipleEnemies)
        {

        }
        foreach (var item in cardDatabaseJson.player)
        {

        }
        foreach (var item in cardDatabaseJson.singleEnemy)
        {

        }
    }
}
