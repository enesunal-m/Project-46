using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCollector
{   //Created this class to define floor and positions for nodes
    public int floorCount;
    public Vector3 newNodePosition;
}

public class MapGenerator : MonoBehaviour
{
    [SerializeField] GameObject node, map;
    //map, lineSprite yukarý taþý
    [HideInInspector] public int totalNodesBeforeBossFight, floorCount;
    [HideInInspector] public Vector3 newNodePosition;

    float nodeDiameter, portionalWidthOfMap, portionalHeightOfMap;

    int seed, counter;
    NodeCollector collector;
    List<NodeCollector> floorAndNodePosition = new List<NodeCollector>();

    private void Awake()
    {

        NodeCreation();
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

    void HideNode(int randomSeed, int counter)
    {
        

    }
    /// <summary>
    /// Spawns nodes randomly.
    /// </summary>
    void NodeCreation()
    {
        float portionalWidthOfMap = map.GetComponent<SpriteRenderer>().bounds.size.x; //Took the dimensions of the map
        float portionalHeightOfMap = map.GetComponent<SpriteRenderer>().bounds.size.y;
        float nodeDiameter = node.GetComponent<SpriteRenderer>().bounds.size.x;

        for (int j = 0; j < 10; j++)
        {

            counter = 0;
            floorCount++;//where we start to play is floor zero,first fight's at floor one.
            for (var i = 0; i < 5; i++)
            {

                float k = Random.Range(-0.9f, 0.9f);//Randomly positioning in a radii
                newNodePosition = new Vector3(k + nodeDiameter * 2 - portionalWidthOfMap / 2 + i * portionalWidthOfMap / 5, k + nodeDiameter - portionalHeightOfMap / 2 + portionalHeightOfMap / 3 * j, -1);
                seed = Random.Range(0, 50);//To generate random seeds
                if (seed<=35)
                {
                    counter++;
                    if (counter<=3)
                    {

                        Instantiate(node, newNodePosition, Quaternion.identity); //totalNodesBeforeBossFight will be added as divider of portional height of map
                    }
                
                }
                collector = new NodeCollector();
                collector.floorCount = floorCount;
                collector.newNodePosition = newNodePosition;
                floorAndNodePosition.Add(collector);

                HideNode(seed, counter);
                Debug.Log("i,j = " + i + " " + j + floorAndNodePosition[i].floorCount + " " + floorAndNodePosition[i].newNodePosition);

            }
        }



    }


}


