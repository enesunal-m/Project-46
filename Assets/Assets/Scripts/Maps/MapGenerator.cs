using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeCollector
{   //Created this class to define floor and positions for nodes
    public int floorCount;
    public Vector3 newNodePosition;
}

public class MapGenerator : MonoBehaviour
{
    [SerializeField] GameObject node, canvas, mapImageToSlide;
    //map, lineSprite yukarý taþý
    [HideInInspector] public int totalNodesBeforeBossFight, floorCount, floorSpawnCounter;
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
        int[] chances = new int[3] { 3, 4, 5 };//Number of objects to be hidden(2,3,4 objects will be shown on a single floor)
        int rand;
        seed = Random.Range(0, 50);

        if (seed<=5)//%10 chance
        {
            for (int i = 0; i < 5; i++)
            {
                rand = Random.Range(0, 6);
                //Destroy();
            }
            //Destroy 5 random objects
        }

        else if (seed <= 25)//%50 chance
        {
            for (int i = 0; i < 4; i++)
            {
                rand = Random.Range(0, 6);
            }
            //Destroy 4 random objects
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                rand = Random.Range(0, 6);
            }
        }

    }

    /// <summary>
    /// Spawn nodes.
    /// </summary>
    void NodeCreation()
    {   
        float portionalWidthOfMap = canvas.GetComponent<CanvasScaler>().referenceResolution.x; //Took the dimensions of the map
        float portionalHeightOfMap = canvas.GetComponent<CanvasScaler>().referenceResolution.y;
        float nodeDiameter = node.GetComponent<RectTransform>().rect.width;//Could've used height

        for (int j = 0; j < 10; j++)
        {

            counter = 0;
            floorCount++;//where we start to play is floor zero,first fight's at floor one.
            for (var i = 0; i < 7; i++)
            {

                float k = Random.Range(-portionalWidthOfMap*0.05f, portionalHeightOfMap * 0.05f);//Randomly positioning in a radii
                newNodePosition = new Vector3(k + nodeDiameter * 2 - portionalWidthOfMap / 2 + i * portionalWidthOfMap / 7, k + nodeDiameter - portionalHeightOfMap / 2 + portionalHeightOfMap / 3 * j, -1);
                seed = Random.Range(0, 50);//To generate random seeds
                if (seed<=50)
                {
                    var Image = Instantiate(node, newNodePosition, Quaternion.identity); //totalNodesBeforeBossFight will be added as divider of portional height of map
                    Image.transform.SetParent(mapImageToSlide.transform, false);
                    counter++;

                
                }
                collector = new NodeCollector();
                collector.floorCount = floorCount;
                collector.newNodePosition = newNodePosition;
                floorAndNodePosition.Add(collector);
                Debug.Log("i,j = " + i + " " + j + floorAndNodePosition[i].floorCount + " " + floorAndNodePosition[i].newNodePosition);

            }
        }



    }


}


