using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
using UnityEngine.EventSystems;
using System.IO;
using System.Linq;
using UnityEditor.Experimental.GraphView;

public class MapLineGenerator : MonoBehaviour
{
    public GameObject map;
    public Sprite[] images = new Sprite[7];
    public System.Random a = new System.Random();
    public List<int> uniqueRandomList = new List<int>();
    public List<int> tempRandomList = new List<int>();
    public List<Vector2> fullGrids;
    public GameObject node, parent;
    public GameObject lineRenderer;
    public GameObject[,] nodeCollector = new GameObject[10, 7];
    public List<Vector2> lineNameCollectorUpper = new List<Vector2>();
    public List<int> lineNameCollectorUpperX = new List<int>();
    public List<int> lineNameCollectorUpperY = new List<int>();
    public List<Vector2> lineNameCollectorLower = new List<Vector2>();
    public List<int> lineNameCollectorLowerX = new List<int>();
    public List<int> lineNameCollectorLowerY = new List<int>();
    public bool runStarted;//Becomes true when run starts
    public int isGenerated;
    public List<int> firstRowIndexes = new List<int>();
    public List<int> firstRowIndexes_ = new List<int>();
    public List<Vector2> nodeIndexes = new List<Vector2>();
    public List<int> randomHolder = new List<int>();
    public List<int> secondRandomHolder = new List<int>();

    public GameObject[,] extraNodes = new GameObject[10, 7];
    [HideInInspector] static bool[,] nodesCoords = new bool[10, 7];
    int row = 10;
    int q, random, leb, hak;


    private void Start()
    {

        if (PlayerPrefs.GetInt("mapGenerated") < 1)//will add 1 at the end of the fight
        {
            Transform parentObject = parent.GetComponent<Transform>();

            for (int i = 0; i < row; i++)
            {
                if (i == 0)
                {
                    q = 3;//Random.Range(3, 5);//how many nodes will be created at first row
                    for (int j = 0; j < q; j++)
                    {
                        uniqueRandomList.Add(NewNumber());//farkli random
                        firstRowIndexes.Add(uniqueRandomList[j]);//save file[0,newnumber]
                        GameObject tempNode = Instantiate(node, parentObject);
                        Grid.Move(tempNode, i, uniqueRandomList[j]);
                        tempNode.name = (i + "x" + uniqueRandomList[j]);
                        tempRandomList.Add(uniqueRandomList[j]);
                        nodeCollector[0, uniqueRandomList[j]] = tempNode;
                    }
                    uniqueRandomList.Clear();
                }
                else
                {

                    //%2==1 bu deðilse temprandomlist
                    switch (i % 2)
                    {
                        case 1:
                            foreach (int p in tempRandomList)
                            {
                                int temp = (int)p;
                                random = Random.Range(0, 3);//0,temp=3
                                randomHolder.Add(random);
                                if (random == 0 && temp != 0)//left
                                {
                                    GameObject tempNode = Instantiate(node, parentObject);
                                    Grid.Move(tempNode, i, p - 1);
                                    tempNode.name = (i + "x" + (p - 1));
                                    uniqueRandomList.Add(p - 1);

                                    LineCreatorLeft(i, p, parentObject);

                                    if (nodeCollector[i, (p - 1)] != null)
                                    {
                                        extraNodes[i, p - 1] = tempNode;
                                    }
                                    else
                                    {
                                        nodeCollector[i, p - 1] = tempNode;
                                    }

                                    //nodesCoords[i, p - 1] = true;


                                }
                                else if (random == 1 && temp != 6)//right
                                {
                                    GameObject tempNode = Instantiate(node, parentObject);
                                    Grid.Move(tempNode, i, p + 1);
                                    tempNode.name = (i + "x" + (p + 1));
                                    uniqueRandomList.Add(p + 1);

                                    LineCreatorRight(i, p, parentObject);

                                    if (nodeCollector[i, (p + 1)] != null)
                                    {
                                        extraNodes[i, p + 1] = tempNode;
                                    }
                                    else
                                    {
                                        nodeCollector[i, p + 1] = tempNode;
                                    }

                                }
                                else//front
                                {

                                    GameObject tempNode = Instantiate(node, parentObject);
                                    Grid.Move(tempNode, i, p);
                                    tempNode.name = (i + "x" + p);
                                    uniqueRandomList.Add(p);

                                    LineCreatorFront(i, p, parentObject);

                                    if (nodeCollector[i, p] != null)
                                    {
                                        extraNodes[i, p] = tempNode;
                                    }
                                    else
                                    {
                                        nodeCollector[i, p] = tempNode;
                                    }
                                    //nodesCoords[i, p] = true;
                                    //Draw line from lower to upper
                                }



                            }
                            tempRandomList.Clear();
                            break;
                        case 0:
                            foreach (int p in uniqueRandomList)
                            {
                                int temp = (int)p;
                                random = Random.Range(0, 3);//0,temp=3
                                secondRandomHolder.Add(random);
                                if (random == 0 && temp != 0)//left
                                {
                                    GameObject tempNode = Instantiate(node, parentObject);

                                    Grid.Move(tempNode, i, p - 1);
                                    tempNode.name = (i + "x" + (p - 1));
                                    tempRandomList.Add(p - 1);

                                    LineCreatorLeft(i, p, parentObject);

                                    if (nodeCollector[i, (p - 1)] != null)
                                    {
                                        extraNodes[i, p - 1] = tempNode;
                                    }
                                    else
                                    {
                                        nodeCollector[i, p - 1] = tempNode;
                                    }
                                    //nodesCoords[i, p - 1] = true;

                                }
                                else if (random == 1 && temp != 6)//right
                                {
                                    GameObject tempNode = Instantiate(node, parentObject);
                                    Grid.Move(tempNode, i, p + 1);
                                    tempNode.name = (i + "x" + (p + 1));
                                    tempRandomList.Add(p + 1);

                                    LineCreatorRight(i, p, parentObject);

                                    if (nodeCollector[i, (p + 1)] != null)
                                    {
                                        extraNodes[i, p + 1] = tempNode;
                                    }
                                    else
                                    {
                                        nodeCollector[i, p + 1] = tempNode;
                                    }
                                    //nodesCoords[i, p + 1] = true;
                                }
                                else//front
                                {

                                    GameObject tempNode = Instantiate(node, parentObject);
                                    Grid.Move(tempNode, i, p);
                                    tempNode.name = (i + "x" + p);
                                    tempRandomList.Add(p);
                                    LineCreatorFront(i, p, parentObject);

                                    if (nodeCollector[i, p] != null)
                                    {
                                        //print(tempNode.name);
                                        extraNodes[i, p] = tempNode;
                                    }
                                    else
                                    {
                                        nodeCollector[i, p] = tempNode;
                                    }
                                }

                            }
                            uniqueRandomList.Clear();
                            break;

                    }

                }

            }
            NodeClass.NodeClassification(nodeCollector, nodesCoords, extraNodes, images);
            //if (!mapGenerator.runStarted)//runa yeni ba?lay?nca true olacak
            {
                for (int j = 0; j < 7; j++)
                {
                    if (nodeCollector[0, j])
                    {
                        nodeCollector[0, j].GetComponent<Button>().interactable = true;
                    }

                }

            }
            foreach (GameObject item in extraNodes)
            {
                Destroy(item);
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (nodeCollector[i, j])
                    {
                        nodeIndexes.Add(new Vector2(i, j));
                    }
                }
            }
            WriteListToFile();
        }
        else
        {
            ReadListFromFile();
            leb = 0;
            hak = 0;

            Transform parentObject = parent.GetComponent<Transform>();

            for (int i = 0; i < row; i++)
            {
                if (i == 0)
                {
                    q = 3;//Random.Range(3, 5);//how many nodes will be created at first row
                    for (int j = 0; j < q; j++)
                    {
                        uniqueRandomList.Add(firstRowIndexes[j]);//save file[0,newnumber]
                        GameObject tempNode = Instantiate(node, parentObject);
                        Grid.Move(tempNode, i, uniqueRandomList[j]);
                        tempNode.name = (i + "x" + uniqueRandomList[j]);
                        tempRandomList.Add(uniqueRandomList[j]);
                        nodeCollector[0, uniqueRandomList[j]] = tempNode;
                    }
                    uniqueRandomList.Clear();
                }
                else
                {
                    //%2==1 bu deðilse temprandomlist
                    switch (i % 2)
                    {
                        case 1:
                            foreach (int p in tempRandomList)
                            {
                                int temp = (int)p;
                                random = randomHolder[leb];//0,temp=3
                                leb++;
                                if (random == 0 && temp != 0)//left
                                {
                                    GameObject tempNode = Instantiate(node, parentObject);
                                    Grid.Move(tempNode, i, p - 1);
                                    tempNode.name = (i + "x" + (p - 1));
                                    uniqueRandomList.Add(p - 1);

                                    LineCreatorLeft(i, p, parentObject);

                                    if (nodeCollector[i, (p - 1)] != null)
                                    {
                                        extraNodes[i, p - 1] = tempNode;
                                    }
                                    else
                                    {
                                        nodeCollector[i, p - 1] = tempNode;
                                    }

                                    //nodesCoords[i, p - 1] = true;


                                }
                                else if (random == 1 && temp != 6)//right
                                {
                                    GameObject tempNode = Instantiate(node, parentObject);
                                    Grid.Move(tempNode, i, p + 1);
                                    tempNode.name = (i + "x" + (p + 1));
                                    uniqueRandomList.Add(p + 1);

                                    LineCreatorRight(i, p, parentObject);

                                    if (nodeCollector[i, (p + 1)] != null)
                                    {
                                        extraNodes[i, p + 1] = tempNode;
                                    }
                                    else
                                    {
                                        nodeCollector[i, p + 1] = tempNode;
                                    }

                                }
                                else//front
                                {

                                    GameObject tempNode = Instantiate(node, parentObject);
                                    Grid.Move(tempNode, i, p);
                                    tempNode.name = (i + "x" + p);
                                    uniqueRandomList.Add(p);

                                    LineCreatorFront(i, p, parentObject);

                                    if (nodeCollector[i, p] != null)
                                    {
                                        extraNodes[i, p] = tempNode;
                                    }
                                    else
                                    {
                                        nodeCollector[i, p] = tempNode;
                                    }
                                    //nodesCoords[i, p] = true;
                                    //Draw line from lower to upper
                                }



                            }
                            tempRandomList.Clear();
                            break;
                        case 0:
                            foreach (int p in uniqueRandomList)
                            {
                                int temp = (int)p;
                                random = randomHolder[hak];//0,temp=3
                                hak++;
                                if (random == 0 && temp != 0)//left
                                {
                                    GameObject tempNode = Instantiate(node, parentObject);

                                    Grid.Move(tempNode, i, p - 1);
                                    tempNode.name = (i + "x" + (p - 1));
                                    tempRandomList.Add(p - 1);

                                    LineCreatorLeft(i, p, parentObject);

                                    if (nodeCollector[i, (p - 1)] != null)
                                    {
                                        extraNodes[i, p - 1] = tempNode;
                                    }
                                    else
                                    {
                                        nodeCollector[i, p - 1] = tempNode;
                                    }
                                    //nodesCoords[i, p - 1] = true;

                                }
                                else if (random == 1 && temp != 6)//right
                                {
                                    GameObject tempNode = Instantiate(node, parentObject);
                                    Grid.Move(tempNode, i, p + 1);
                                    tempNode.name = (i + "x" + (p + 1));
                                    tempRandomList.Add(p + 1);

                                    LineCreatorRight(i, p, parentObject);

                                    if (nodeCollector[i, (p + 1)] != null)
                                    {
                                        extraNodes[i, p + 1] = tempNode;
                                    }
                                    else
                                    {
                                        nodeCollector[i, p + 1] = tempNode;
                                    }
                                    //nodesCoords[i, p + 1] = true;
                                }
                                else//front
                                {

                                    GameObject tempNode = Instantiate(node, parentObject);
                                    Grid.Move(tempNode, i, p);
                                    tempNode.name = (i + "x" + p);
                                    tempRandomList.Add(p);
                                    LineCreatorFront(i, p, parentObject);

                                    if (nodeCollector[i, p] != null)
                                    {
                                        //print(tempNode.name);
                                        extraNodes[i, p] = tempNode;
                                    }
                                    else
                                    {
                                        nodeCollector[i, p] = tempNode;
                                    }
                                }

                            }
                            uniqueRandomList.Clear();
                            break;

                    }

                }

            }
            NodeClass.NodeClassification(nodeCollector, nodesCoords, extraNodes, images);
            //if (!mapGenerator.runStarted)//runa yeni ba?lay?nca true olacak
            {
                for (int j = 0; j < 7; j++)
                {
                    if (nodeCollector[0, j])
                    {
                        nodeCollector[0, j].GetComponent<Button>().interactable = true;
                    }

                }

            }
            foreach (GameObject item in extraNodes)
            {
                Destroy(item);
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (nodeCollector[i, j])
                    {
                        nodeIndexes.Add(new Vector2(i, j));
                    }
                }
            }
            int tempX = PlayerPrefs.GetInt("tempX");
            int tempY = PlayerPrefs.GetInt("tempY");
            nodeCollector[tempY, tempX].GetComponent<Button>().interactable = true;
            Debug.Log("first index : "+ tempX+"second index:"+tempY);
            for (int i = 1; i < 10; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (lineNameCollectorLowerY[j] == tempX && lineNameCollectorLowerX[i] == tempX)
                    {
                        nodeCollector[lineNameCollectorUpperX[i], lineNameCollectorUpperY[j]].GetComponent<Button>().interactable = true;
                    }
                }


            }
        }
        isGenerated++;
    }

    private int NewNumber()
    {
        int myNumber = Random.Range(0, 7);
        while (uniqueRandomList.Contains(myNumber))
        {
            myNumber = Random.Range(0, 7);
        }
        return myNumber;

    }

    private void LineCreatorLeft(int i, int p, Transform parentObject)//row=i column=p
    {
        Vector2 upper = Grid.Position(i, p - 1);
        Vector2 lower = Grid.Position(i - 1, p);
        GameObject lr = Instantiate(lineRenderer, parentObject);
        lr.GetComponent<LineRenderer>().SetPosition(0, lower);
        lr.GetComponent<LineRenderer>().SetPosition(1, upper);
        lr.name = ("lower:[" + (i - 1) + "," + p + "] upper:[" + i + "," + (p - 1) + "]");//first 2 num->lower last 2 num->upper
        lineNameCollectorUpper.Add(new Vector2(i, p - 1));
        lineNameCollectorUpperX.Add(i);
        lineNameCollectorUpperY.Add(p - 1);
        lineNameCollectorLower.Add(new Vector2(i - 1, p));
        lineNameCollectorLowerX.Add(i - 1);
        lineNameCollectorLowerY.Add(p);

    }
    private void LineCreatorRight(int i, int p, Transform parentObject)//row=i column=p
    {
        Vector2 upper = Grid.Position(i, p + 1);
        Vector2 lower = Grid.Position(i - 1, p);
        GameObject lr = Instantiate(lineRenderer, parentObject);
        lr.GetComponent<LineRenderer>().SetPosition(0, lower);
        lr.GetComponent<LineRenderer>().SetPosition(1, upper);
        lr.name = ("lower:[" + (i - 1) + "," + p + "] upper:[" + i + "," + (p + 1) + "]");
        lineNameCollectorUpper.Add(new Vector2(i, p + 1));
        lineNameCollectorUpperX.Add(i);
        lineNameCollectorUpperY.Add(p + 1);
        lineNameCollectorLower.Add(new Vector2(i - 1, p));
        lineNameCollectorLowerX.Add(i - 1);
        lineNameCollectorLowerY.Add(p);

    }
    private void LineCreatorFront(int i, int p, Transform parentObject)//row=i column=p
    {
        Vector2 upper = Grid.Position(i, p);
        Vector2 lower = Grid.Position(i - 1, p);
        GameObject lr = Instantiate(lineRenderer, parentObject);
        lr.GetComponent<LineRenderer>().SetPosition(0, lower);
        lr.GetComponent<LineRenderer>().SetPosition(1, upper);
        lr.name = ("lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + p + "]");
        lineNameCollectorUpper.Add(new Vector2(i, p));
        lineNameCollectorUpperX.Add(i);
        lineNameCollectorUpperY.Add(p);
        lineNameCollectorLower.Add(new Vector2(i - 1, p));
        lineNameCollectorLowerX.Add(i - 1);
        lineNameCollectorLowerY.Add(p);

    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("mapGenerated", 0);
    }
    public void WriteListToFile()
    {

        File.WriteAllLines(Application.dataPath + @"/Assets/Database/firstRowIndexes.txt", firstRowIndexes.Select(x => x.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/lineNameCollectorUpperX.txt", lineNameCollectorUpperX.Select(x => x.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/lineNameCollectorUpperY.txt", lineNameCollectorUpperY.Select(x => x.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/lineNameCollectorLowerX.txt", lineNameCollectorLowerX.Select(x => x.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/lineNameCollectorLowerY.txt", lineNameCollectorLowerY.Select(x => x.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/randomHolder.txt", randomHolder.Select(x => x.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/secondRandomHolder.txt", secondRandomHolder.Select(x => x.ToString()));
    }

    public void ReadListFromFile()
    {
        firstRowIndexes = File.ReadLines(Application.dataPath + @"/Assets/Database/firstRowIndexes.txt").Select(x => int.Parse(x)).ToList();
        lineNameCollectorUpperX = File.ReadLines(Application.dataPath + @"/Assets/Database/lineNameCollectorUpperX.txt").Select(x => int.Parse(x)).ToList();
        lineNameCollectorUpperY = File.ReadLines(Application.dataPath + @"/Assets/Database/lineNameCollectorUpperY.txt").Select(x => int.Parse(x)).ToList();
        lineNameCollectorLowerX = File.ReadLines(Application.dataPath + @"/Assets/Database/lineNameCollectorLowerX.txt").Select(x => int.Parse(x)).ToList();
        lineNameCollectorLowerY = File.ReadLines(Application.dataPath + @"/Assets/Database/lineNameCollectorLowerY.txt").Select(x => int.Parse(x)).ToList();
        randomHolder = File.ReadLines(Application.dataPath + @"/Assets/Database/randomHolder.txt").Select(x => int.Parse(x)).ToList();
        secondRandomHolder = File.ReadLines(Application.dataPath + @"/Assets/Database/secondRandomHolder.txt").Select(x => int.Parse(x)).ToList();

        for (int i = 0; i < lineNameCollectorLowerX.Count; i++)
        {
            lineNameCollectorLower.Add(new Vector2(lineNameCollectorLowerX[i], lineNameCollectorLowerY[i]));

        }
        for (int i = 0; i < lineNameCollectorUpperX.Count; i++)
        {
            lineNameCollectorUpper.Add(new Vector2(lineNameCollectorUpperX[i], lineNameCollectorUpperY[i]));

        }



    }

}

