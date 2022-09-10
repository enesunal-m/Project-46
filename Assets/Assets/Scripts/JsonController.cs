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
        string jsonString = new StreamReader(Application.streamingAssetsPath + path).ReadToEnd();

        // use below syntax to access JSON file
        CardDatabaseStructure.Root jsonFile = JsonConvert.DeserializeObject<CardDatabaseStructure.Root>(jsonString);
        return jsonFile;
        
    }

    public static void createCardJsonTempWithPath(string path, List<CardDatabaseStructure.ICardInfoInterface> cards)
    {
        StreamWriter sw = new StreamWriter(Application.streamingAssetsPath + path);
        sw.Write(JsonConvert.SerializeObject(cards));
        sw.Flush();
        sw.Close();
    }

    public static List<CardDatabaseStructure.ICardInfoInterface> readCardJsonTempWithPath(string path)
    {
        StreamReader sw = new StreamReader(Application.streamingAssetsPath + path);
        List<CardDatabaseStructure.ICardInfoInterface> cardInfos = JsonConvert.DeserializeObject<List<CardDatabaseStructure.ICardInfoInterface>>(sw.ReadToEnd());
        sw.Close();

        return cardInfos;
    }

    public static EnemyDatabaseStructure.Root getEnemyJsonWithPath(string path)
    {
        string jsonString = new StreamReader(Application.streamingAssetsPath + path).ReadToEnd();

        // use below syntax to access JSON file
        EnemyDatabaseStructure.Root jsonFile = JsonConvert.DeserializeObject<EnemyDatabaseStructure.Root>(jsonString);
        return jsonFile;

    }

    public static BuffDebuffDatabaseStructure.Root getBuffDebuffJsonWithPath(string path)
    {
        string jsonString = new StreamReader(Application.streamingAssetsPath + path).ReadToEnd();

        // use below syntax to access JSON file
        BuffDebuffDatabaseStructure.Root jsonFile = JsonConvert.DeserializeObject<BuffDebuffDatabaseStructure.Root>(jsonString);
        return jsonFile;

    }
}
