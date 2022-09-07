using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public static class JsonController
{
    public static CardDatabaseStructure.Root getJsonWithPath(string path)
    {
        string jsonString = new StreamReader(Application.dataPath + path).ReadToEnd();

        // use below syntax to access JSON file
        CardDatabaseStructure.Root jsonFile = JsonConvert.DeserializeObject<CardDatabaseStructure.Root>(jsonString);
        return jsonFile;
        
    }
}
