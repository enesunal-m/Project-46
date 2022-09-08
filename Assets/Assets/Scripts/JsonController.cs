using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public static class JsonController
{
    public static CardDatabaseStructure.Root getCardJsonWithPath(string path)
    {
        string jsonString = new StreamReader(Application.dataPath + path).ReadToEnd();

        // use below syntax to access JSON file
        CardDatabaseStructure.Root jsonFile = JsonConvert.DeserializeObject<CardDatabaseStructure.Root>(jsonString);
        return jsonFile;
        
    }

    public static void createCardJsonWithPath(string path, List<CardDatabaseStructure.ICardInfoInterface> cards)
    {
        Debug.Log(cards[0].name);
        CardDatabaseStructure.Root x = new CardDatabaseStructure.Root();
        x.player.Add((CardDatabaseStructure.Player)cards[0]);
        new StreamWriter(Application.dataPath + path).WriteAsync(JsonConvert.SerializeObject(x));

        // use below syntax to access JSON file
        Debug.Log(JsonConvert.SerializeObject(cards));
    }

    public static EnemyDatabaseStructure.Root getEnemyJsonWithPath(string path)
    {
        string jsonString = new StreamReader(Application.dataPath + path).ReadToEnd();

        // use below syntax to access JSON file
        EnemyDatabaseStructure.Root jsonFile = JsonConvert.DeserializeObject<EnemyDatabaseStructure.Root>(jsonString);
        return jsonFile;

    }

    public static BuffDebuffDatabaseStructure.Root getBuffDebuffJsonWithPath(string path)
    {
        string jsonString = new StreamReader(Application.dataPath + path).ReadToEnd();

        // use below syntax to access JSON file
        BuffDebuffDatabaseStructure.Root jsonFile = JsonConvert.DeserializeObject<BuffDebuffDatabaseStructure.Root>(jsonString);
        return jsonFile;

    }
}
