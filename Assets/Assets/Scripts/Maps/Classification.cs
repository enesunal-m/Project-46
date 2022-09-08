using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classification : MonoBehaviour 
{
    public List<string> nameCollector;
    public void NodeCollection(GameObject[,] nodeCollector) 
    {
        foreach (var item in nodeCollector)
        {
            nameCollector.Add(item.name);
            if (nameCollector.Contains(item.name))
            {
                Destroy(item.gameObject);
                nameCollector.Remove(item.name);
            }
        }

        
    }


}
