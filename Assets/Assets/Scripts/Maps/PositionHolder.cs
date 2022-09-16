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
            int tempx = ToInt(button.name[0]);
            int tempy = ToInt(button.name[2]);
            
            if (this.tag == "MinorEnemy")
            {
                state = "Minor Enemy Scene";
                SceneManager.LoadScene(0);
                //MinorEnemyScene
            }
            else if (this.tag == "EliteScene")
            {
                state = "Elite Scene";
                //Scene("MinorEnemyScene")
                //EliteScene
            }
            else if (this.tag == "Market")
            {
                state = "Market";
                SceneManager.LoadScene(1);
                //Market
            }
            else if (this.tag == "Mystery") 
            {
                state = "Mystery";
                //Scene("Mystery")
                //Mystery
            }
            else if (this.tag == "RestSite")
            {
                state = "Rest Site";
                //Scene("RestSite")
                //RestSite
            }
            else if(this.tag == "Treasure")
            {
                state = "Treasure";

                //Scene("Treasure")
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
