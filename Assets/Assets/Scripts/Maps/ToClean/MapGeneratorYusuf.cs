using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGeneratorYusuf: MonoBehaviour
{
    public static int rowNumber = 10;
    public static int collumnNumber = 5;
    public int[,] createdNodes = new int[rowNumber, collumnNumber];

    public void fillCreatedNodes()
    {
        List<int> nodesPosition;
        for(int i = 0; i < rowNumber; i++)
        {
            nodesPosition = nodesPositions(collumnNumber, nodesNumberInRow());

            foreach (int j in nodesPosition)
            {
                createdNodes[i, j] = 1;
            }
        }
    }





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

    public int nodesNumberInRow()
    {
        int nodesNum;
        int a = 0;
        a = Random.Range(0, 4);
        //To maintain good destrubition of nodes number in row (2,3,4 -> 20%,60%,20%)
        switch (a)
        {
            case 0:
                nodesNum = 2;
                break;
            case 4:
                nodesNum = 4;
                break;
            default:
                nodesNum = 3;
                break;
        }
        return nodesNum;
    }
}

/*public class NodeCollector
{   Created this class to define floor and positions for nodes
    public int floorCount;
    public Vector3 newNodePosition;
}

public class MapGenerator : MonoBehaviour
{
    [SerializeField] GameObject node, canvas, mapImageToSlide;
    map, lineSprite yukar� ta��
    [HideInInspector] public int totalNodesBeforeBossFight, floorCount, floorSpawnCounter, destroyedCounter;
    [HideInInspector] public int[] floorCountAndIndexOfNode;
    [HideInInspector] public Vector3 newNodePosition;


    float nodeDiameter, portionalWidthOfMap, portionalHeightOfMap;

    int[] chances;
    int seed, counter;
    NodeCollector collector;
    List<NodeCollector> floorAndNodePosition = new List<NodeCollector>();

    private void Awake()
    {

        NodeCreation();
        HideNode();
    }

    void Start()
    {


    }

    void LineDraw()
    {

    }

    void NodeClassification()
    {

    }



    void HideNode()
    {
        int rand;
        float portionalWidthOfMap = canvas.GetComponent<CanvasScaler>().referenceResolution.x; Took the dimensions of the map
        float portionalHeightOfMap = canvas.GetComponent<CanvasScaler>().referenceResolution.y;
        float nodeDiameter = node.GetComponent<RectTransform>().rect.width;Could've used height
        float k = Random.Range(-portionalWidthOfMap * 0.05f, portionalHeightOfMap * 0.05f);Randomly positioning in a radii
        destroyedCounter = 0;


        node.name = "node" + i + "x" + j;

        newNodePosition = new Vector3(k + nodeDiameter * 2 - portionalWidthOfMap / 2 + i * portionalWidthOfMap / 7, k + nodeDiameter - portionalHeightOfMap / 11 + portionalHeightOfMap / 3 * j, -1);
        var Image = Instantiate(node, newNodePosition, Quaternion.identity); totalNodesBeforeBossFight will be added as divider of portional height of map
        Image.transform.SetParent(mapImageToSlide.transform, false);
        counter++;

        {
            for (int floor = 0; floor < 10; floor++)
            {
                seed = Random.Range(0, 50);
                if (seed <= 5)%10 chance
                    for (int row = 0; row < 3; row++)Create 4 random objects
                    {
                        rand = Random.Range(0, 6);

                    }

                else if (seed <= 20)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        rand = Random.Range(0, 6);
                        GameObject go = GameObject.Find("node" + floor + "x" + rand + "(Clone)");
                        if (go)
                        {
                            Destroy(go.gameObject);
                        }
                        else
                        {
                            print("Nesne yok. " + floor + ". kat" + rand + ". obje");
                        }

                    }
                    Destroy 4 random objects
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        rand = Random.Range(0, 6);
                        GameObject go = GameObject.Find("node" + floor + "x" + rand + "(Clone)");
                        if (go)
                        {
                            Destroy(go.gameObject);
                        }
                        else
                        {
                            print("Nesne yok. " + floor + ". kat" + rand + ". obje");
                        }

                    }
                }
            }


        }



    }

     <summary>
     Spawn nodes.
     </summary>
    void NodeCreation()
    {
        float portionalWidthOfMap = canvas.GetComponent<CanvasScaler>().referenceResolution.x; Took the dimensions of the map
        float portionalHeightOfMap = canvas.GetComponent<CanvasScaler>().referenceResolution.y;
        float nodeDiameter = node.GetComponent<RectTransform>().rect.width;Could've used height

        for (int j = 0; j < 10; j++)
        {

            counter = 0;
            floorCount++;where we start to play is floor zero,first fight's at floor one.
            for (var i = 0; i < 7; i++)
            {

                node.name = "node" + i + "x" + j;
                float k = Random.Range(-portionalWidthOfMap * 0.05f, portionalHeightOfMap * 0.05f);Randomly positioning in a radii
                newNodePosition = new Vector3(k + nodeDiameter * 2 - portionalWidthOfMap / 2 + i * portionalWidthOfMap / 7, k + nodeDiameter - portionalHeightOfMap / 2 + portionalHeightOfMap / 3 * j, -1);
                var Image = Instantiate(node, newNodePosition, Quaternion.identity); totalNodesBeforeBossFight will be added as divider of portional height of map
                Image.transform.SetParent(mapImageToSlide.transform, false);
                counter++;



                collector = new NodeCollector();
                collector.floorCount = floorCount;
                collector.newNodePosition = newNodePosition;
                floorAndNodePosition.Add(collector);

            }
        }



    }


}
*/

