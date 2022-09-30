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
        public Vector2 playerPosition;
        bool digitController = true;
        string tempxCollector,tempyCollector;

        public void OnClicked(Button button)
        {
            //scene will be changed due to its stance(minorenemy,shop,treassure)
            foreach(char c in button.name)//15x21
            {
                
                if (digitController == true)
                {
                    if (c == 'x')
                    {
                        digitController = false;
                        continue;
                    }
                    tempxCollector += c;
                    Debug.Log(tempxCollector);
                    
                }
                else
                {
                    tempyCollector += c;
                }
            }
            int tempx = int.Parse(tempxCollector);
            int tempy = int.Parse(tempyCollector);
            Debug.Log(tempx+"x"+tempy);

            if (CompareTag("MinorEnemy"))
            {
                state = "Minor Enemy Scene";

                PlayerPrefs.SetString("EnemyType","Normal");
                SceneRouter.GoToScene(SceneType.Fight);

                //GetComponent<Image>().sprite = images[3];
                //MinorEnemyScene
            }
            else if (CompareTag("EliteScene"))
            {
                state = "Elite Scene";

                PlayerPrefs.SetString("EnemyType", "Elite");
                SceneRouter.GoToScene(SceneType.Fight);
                //Scene("MinorEnemyScene")
                //EliteScene
            }
            else if (CompareTag("Boss"))
            {
                state = "Boss Scene";

                PlayerPrefs.SetString("EnemyType", "Boss");
                SceneRouter.GoToScene(SceneType.Fight);
            }
            else if (CompareTag("Market"))
            {
                state = "Market";
                SceneRouter.GoToScene(SceneType.Shop);
                //Scene("MinorEnemyScene")

                //GetComponent<Image>().sprite = images[4];
                //print(nodeName[0] + "x" + nodeName[2] + state);
                //Market
            }
            else if (CompareTag("Mystery")) 
            {
                state = "Mystery";
                //Scene("Mystery")
                //Mystery
            }
            else if (CompareTag("RestSite"))
            {
                state = "Rest Site";
                SceneRouter.GoToScene(SceneType.RestSite);
                //Scene("MinorEnemyScene")

                //GetComponent<Image>().sprite = images[1];
                //print(nodeName[0] + "x" + nodeName[2] + state);

                //RestSite
            }
            else if(CompareTag("Treasure"))
            {
                state = "Treasure";

                //Scene("Treasure")
                //Treasure
            }

            PlayerPrefs.SetInt("tempX", tempx);
            PlayerPrefs.SetInt("tempY", tempy);

        }

        //public int ToInt(string s)
        //{
        //    return s-'0';
            
        //}
    }

}
