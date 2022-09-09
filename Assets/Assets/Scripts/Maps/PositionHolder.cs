using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UnityEngine.EventSystems
{
    
    public class PositionHolder : MonoBehaviour
    {   
        public string[,] state;
        public MapLineGenerator mapGenerator;
        public GameObject[,] nodes = new GameObject[7,10];
        public int level;
        List<string> strings = new List<string>();
        public void OnClicked(Button button)
        {
            //scene will be changed due to its stance(minorenemy,shop,treassure)
            //
            nodes = mapGenerator.nodeCollector;
            strings.Add(button.name);
            string nodeName = strings[strings.Count-1];//gives objects name
            Debug.Log(nodeName[0] + "x" + nodeName[2]);
            mapGenerator.SecondRandomCreator(nodeName[0], nodeName[2],this);
            print(nodeName[0]+"x"+ nodeName[2]);
            if (this.state[nodeName[0],nodeName[2]] == "MinorEnemy")
            {
                //MinorEnemyScene
                print(nodeName[0]+"x"+nodeName[2]+ state); 
            }
            else if (this.state[nodeName[0],nodeName[2]] == "Elite")
            {
                print(nodeName[0] + "x" + nodeName[2] + state);

                //EliteScene
            }
            else if (this.state[nodeName[0],nodeName[2]] == "Market")
            {
                print(nodeName[0] + "x" + nodeName[2] + state);
                //Market
            }
            else if (this.state[nodeName[0],nodeName[2]] == "Mystery")
            {
                print(nodeName[0] + "x" + nodeName[2] + state);
                //Mystery
            }
            else if (this.state[nodeName[0], nodeName[2]] == "RestSite")
            {
                print(nodeName[0] + "x" + nodeName[2] + state);
                //RestSite
            }

        }
        

    }

}
