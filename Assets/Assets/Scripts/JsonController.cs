using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public static class JsonController
{
    public static Root getJsonWithPath(string path)
    {
        string jsonString = new StreamReader(Application.dataPath + path).ReadToEnd();

        // use below syntax to access JSON file
        Root jsonFile = JsonConvert.DeserializeObject<Root>(jsonString);
        return jsonFile;
        
    }
}
