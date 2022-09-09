using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace UnityEngine.EventSystems
{
    
    public class PositionHolder : MonoBehaviour
    {   
        public string state;
        public MapLineGenerator mapGenerator;
        public GameObject[,] nodes = new GameObject[7,10];
        public Vector2 playerPosition;
        List<string> strings = new List<string>();
        List<Vector2> linesLower = new List<Vector2>();
        List<Vector2> linesUpper = new List<Vector2>();

        public void OnClicked(Button button)
        {
            //scene will be changed due to its stance(minorenemy,shop,treassure)
            //
            Debug.Log(this.name);
            nodes = mapGenerator.nodeCollector;
            linesLower = mapGenerator.lineNameCollectorLower;
            linesUpper = mapGenerator.lineNameCollectorUpper;
            strings.Add(button.name);
            string nodeName = strings[0];//gives objects name

            int tempx = button.name[0] -'0';
            int tempy = button.name[2] - '0';
            Debug.Log(tempx);
            Vector2 positionn = new Vector2(tempx,tempy);
            playerPosition = positionn;
            this.GetComponent<Button>().interactable = true;
            int index = 0;
            foreach (Vector2 item in linesLower)
            {
                
                if (playerPosition == item)
                {
                    mapGenerator.nodeCollector[(int)linesUpper[index].x, (int)linesUpper[index].y].GetComponent<Button>().interactable = true;
                    mapGenerator.nodeCollector[(int)item.x,(int)item.y].GetComponent<Button>().enabled = false;
                    
                }
                index++;

            }
            if (this.GetComponent<Image>().color == Color.yellow)
            {
                state = "Minor Enemy Scene";
                //MinorEnemyScene
                //print(nodeName[0]+"x"+nodeName[2]+ state); 
            }
            else if (this.GetComponent<Image>().color == Color.red)
            {
                state = "Elite Scene";
                //print(nodeName[0] + "x" + nodeName[2] + state);

                //EliteScene
            }
            else if (this.GetComponent<Image>().color == Color.black)
            {
                state = "Market";
                //print(nodeName[0] + "x" + nodeName[2] + state);
                //Market
            }
            else if (this.GetComponent<Image>().color == Color.cyan) 
            {
                state = "Mystery";
                //print(nodeName[0] + "x" + nodeName[2] + state);
                //Mystery
            }
            else if (this.GetComponent<Image>().color == Color.blue)
            {
                state = "Rest Site";
                //print(nodeName[0] + "x" + nodeName[2] + state);
                //RestSite
            }
            else if(this.GetComponent<Image>().color== Color.green)
            {
                state = "Treasure";
                //print(nodeName[0] + "x" + nodeName[2] + state);
                //Treasure
            }


            for (int l = 0; l < 7; l++)
            {
                if (mapGenerator.nodeCollector[0,l])
                {
                    mapGenerator.nodeCollector[0, l].GetComponent<Button>().enabled = false;
                }
            }
        }

        public int ToInt(char s)
        {
            return (int)(s-'0');
            
        }
        

    }

}
