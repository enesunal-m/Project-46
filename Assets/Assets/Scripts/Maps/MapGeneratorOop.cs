using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGeneratorOop : MonoBehaviour
{
    int row = 10;
    int column = 7;
    [SerializeField] GameObject node, mapParent, canvas;
    Vector2[,] nodePositionArray;

    void Start()
    {

        GameObject[,] nodes = new GameObject[column, row];
        for (int i = 0; i < column; i++)
        {
            for (int j = 0; j < row; j++)
            {

                nodes[i, j] = Instantiate(node);
                nodes[i, j].transform.SetParent(mapParent.transform, false);
                nodes[i, j].name = "node" + i + "x" + j;

            }

        }
        NodePositionerAndPositionHolder(nodes);
    }



    void NodePositionerAndPositionHolder(GameObject[,] nodes)
    {
        //Canvas Dimensions

        float portionalWidthOfMap = canvas.GetComponent<CanvasScaler>().referenceResolution.x / row;
        float portionalHeightOfMap = canvas.GetComponent<CanvasScaler>().referenceResolution.y / column;
        float nodeDiameter = node.GetComponent<RectTransform>().rect.width;
        int skipNodeProductionCounter=0;
        float k = Random.Range(-portionalWidthOfMap * 0.05f, portionalHeightOfMap * 0.05f);

        //Canvas Dimensions

        for (int i = 0; i < column; i++)
        {
            for (int j = 0; j < row; j++)
            {
                
                    
                
                

                if (Random.Range(0f, 10f) < 1f && skipNodeProductionCounter < 4)
                {
                    i++;
                    skipNodeProductionCounter++;
                    //continue;
                }
                else
                {
                    //screen sizes
                    Vector2 temp = new Vector2(i * 1.5f * portionalWidthOfMap, 1.3f * j * portionalHeightOfMap);
                    nodes[i, j].GetComponent<RectTransform>().anchoredPosition = temp;
                    //nodePositionArray[i, j] = temp;
                }




            }
            
        }
    }
}
