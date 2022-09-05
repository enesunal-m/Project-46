using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGeneratorOop : MonoBehaviour
{
    int row = 7;
    int column = 10;
    [SerializeField] GameObject node, mapParent, canvas;

    private void Awake()
    {
        //Canvas Dimensions

        float portionalWidthOfMap = canvas.GetComponent<CanvasScaler>().referenceResolution.x;
        float portionalHeightOfMap = canvas.GetComponent<CanvasScaler>().referenceResolution.y;
        float nodeDiameter = node.GetComponent<RectTransform>().rect.width;
        float k = Random.Range(-portionalWidthOfMap * 0.05f, portionalHeightOfMap * 0.05f);

        //Canvas Dimensions
    }


    
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
    }



    Vector2 NodePositionerAndPositionHolder(GameObject[,] nodes)
    {
        for (int j = 0; j < column; j++)
        {
            for (int i = 0; i < row; i++)
            {
                nodes[i, j].GetComponent<RectTransform>().position = Vector2.zero;//screen sizes
            }
        }
        return Vector2.zero;
    }
}
