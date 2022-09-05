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


    public static List<int> nodesPositions(int max, int nodesNum)
    {
        List<int> randNums = new List<int>();
        int a = 0;
        while (randNums.Count < nodesNum)
        {
            a = Random.Range(0, max);
            if (!randNums.Contains(a))
            {
                randNums.Add(a);
            }
        }
        return randNums;
    }

    public static List<int> nodesNumberInRow()
    {
        List<int> nodesNum = new List<int>();
        int a = 0;
        for (int i = 0; i < 10;i++)
            {
                a = Random.Range(0, 4);
            //To maintain good destrubition of nodes number in row (2,3,4 -> 20%,60%,20%)
            switch (a)
            {
                case 0:
                    nodesNum.Add(2);
                    break;
                case 4:
                    nodesNum.Add(4);
                    break;
                default:
                    nodesNum.Add(3);
                    break;
            }
        }
        return nodesNum;

    }
    void Start()
    {

        GameObject[,] nodes = new GameObject[row, column];
        //MapNode[,] nodes = new MapNode[row,column];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
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

        float portionalWidthOfMap = canvas.GetComponent<CanvasScaler>().referenceResolution.x / column;
        float portionalHeightOfMap = canvas.GetComponent<CanvasScaler>().referenceResolution.y / row;
        float nodeDiameter = node.GetComponent<RectTransform>().rect.width;
        //int skipNodeProductionCounter = 0;
        float k = Random.Range(-portionalWidthOfMap * 0.05f, portionalHeightOfMap * 0.05f);

        //Canvas Dimensions

        //static int newnumber(int r)
        //{
        //    int[] numbers = new int[r];
        //    int a = random.range(0, r);
        //    if (numbers.contains(a))
        //    {
        //        a = random.range(0, r);
        //    }
        //    return a;
        //}
        List<int> nodeNumber = nodesNumberInRow();

        for (int i = 0; i < column; i++)
        {
            int nodesNumber = Random.Range(2, 4);
            List<int> randNums = nodesPositions(7, nodesNumber);
            foreach (int j in randNums)
            {
                Vector2 temp = new Vector2(i * 1.5f * portionalWidthOfMap, 1.3f * j * portionalHeightOfMap);
                nodes[i, j].GetComponent<RectTransform>().anchoredPosition = temp;
                //odePositionArray[i, j] = temp;
                Debug.Log(j);
            }


            //List<int> nodeNumber = nodesNumberInRow();
            ////foreach (int node in nodeNumber)   

            //// int nodesNumber = Random.Range(2, 4);
            //foreach (int j in nodeNumber)
            //{
            //    List<int> randNums = nodesPositions(7, j);
            //    foreach (int n in randNums)
            //    {
            //        Vector2 temp = new Vector2(i * 1.5f * portionalWidthOfMap, 1.3f * n * portionalHeightOfMap);
            //        nodes[i, n].GetComponent<RectTransform>().anchoredPosition = temp;
            //        //odePositionArray[i, j] = temp;
            //        Debug.Log(n);
            //    }

            //}



            //for (int j = 0; j < row; j++)
            //{
            //    if (Random.Range(0f, 10f) < 1f && skipNodeProductionCounter < 4)
            //    {
            //        i++;
            //        skipNodeProductionCounter++;
            //        //continue;
            //    }
            //    else
            //    {
            //        //screen sizes
            //        Vector2 temp = new Vector2(i * 1.5f * portionalWidthOfMap, 1.3f * j * portionalHeightOfMap);
            //        nodes[i, j].GetComponent<RectTransform>().anchoredPosition = temp;
            //        //nodePositionArray[i, j] = temp;
            //    }
            //}

        }
    }
}
