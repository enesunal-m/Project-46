using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

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

            //nodes = mapGenerator.nodeCollector;
            //linesLower = mapGenerator.lineNameCollectorLower;
            //linesUpper = mapGenerator.lineNameCollectorUpper;
            //strings.Add(button.name);
            //string nodeName = strings[0];//gives objects name

            int tempx = button.name[0] -'0';
            int tempy = button.name[2] - '0';
            //Debug.Log("tempx:"+tempx);
            //Debug.Log("tempy:"+tempy);
            //Vector2 positionn = new Vector2(tempx,tempy);
            //this.GetComponent<Button>().interactable = true;
            //int index = 0;
            //if (PlayerPrefs.GetInt("tempX") == null)
            //{
            //    Debug.Log("Ýlk adým devam");
            //    PlayerPrefs.SetInt("tempX", tempx);
            //    PlayerPrefs.SetInt("tempY", tempy);
            //}
            //else
            //{
            //    PlayerPrefs.SetInt("tempX", tempx);
            //    PlayerPrefs.SetInt("tempY", tempy);
            //    playerPosition = new Vector2(PlayerPrefs.GetInt("tempX"), PlayerPrefs.GetInt("tempY"));
            //}
            

            
            //foreach (Vector2 item in linesLower)
            //{
                
            //    if (playerPosition == item)
            //    {
            //        mapGenerator.nodeCollector[(int)linesUpper[index].x, (int)linesUpper[index].y].GetComponent<Button>().interactable = true;
            //        mapGenerator.nodeCollector[(int)item.x,(int)item.y].GetComponent<Button>().interactable = false;
                    
            //    }
            //    index++;
                
            //}

            //for (int l = 0; l < 7; l++)
            //{
            //    if (mapGenerator.nodeCollector[(int)playerPosition.x, l])
            //    {
            //        mapGenerator.nodeCollector[(int)playerPosition.x, l].GetComponent<Button>().interactable = false;
            //    }
            //}
            if (this.tag == "MinorEnemy")
            {
                state = "Minor Enemy Scene";
                SceneManager.LoadScene(0);

                //this.GetComponent<Image>().sprite = images[3];
                //MinorEnemyScene
                //print(nodeName[0]+"x"+nodeName[2]+ state); 
            }
            else if (this.tag == "EliteScene")
            {
                state = "Elite Scene";
                //Scene("MinorEnemyScene")

                //this.GetComponent<Image>().sprite = images[5];
                //print(nodeName[0] + "x" + nodeName[2] + state);

                //EliteScene
            }
            else if (this.tag == "Market")
            {
                state = "Market";
                SceneManager.LoadScene(1);
                

                //this.GetComponent<Image>().sprite = images[4];
                //print(nodeName[0] + "x" + nodeName[2] + state);
                //Market
            }
            else if (this.tag == "Mystery") 
            {
                state = "Mystery";

                //Scene("MinorEnemyScene")

                //this.GetComponent<Image>().sprite = images[2];
                //print(nodeName[0] + "x" + nodeName[2] + state);
                //Mystery
            }
            else if (this.tag == "RestSite")
            {
                state = "Rest Site";

                //Scene("MinorEnemyScene")

                //this.GetComponent<Image>().sprite = images[1];
                //print(nodeName[0] + "x" + nodeName[2] + state);
                //RestSite
            }
            else if(this.tag == "Treasure")
            {
                state = "Treasure";

                //Scene("MinorEnemyScene")

                //this.GetComponent<Image>().sprite = images[0];
                //print(nodeName[0] + "x" + nodeName[2] + state);
                //Treasure
            }

            PlayerPrefs.SetInt("tempX", tempx);
            PlayerPrefs.SetInt("tempY", tempy);

        }

        public int ToInt(char s)
        {
            return (int)(s-'0');
            
        }
        

    }

}
