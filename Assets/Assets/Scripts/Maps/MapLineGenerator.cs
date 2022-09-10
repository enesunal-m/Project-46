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
    public List<Vector2> lineNameCollectorLower = new List<Vector2>();
    public bool runStarted;//Becomes true when run starts
    public int isGenerated;

    public List<int> firstRowIndexes = new List<int>();
    public List<int> firstRowIndexes_ = new List<int>();
    public List<Vector2> nodeIndexes = new List<Vector2>();
    public List<int> randomHolder = new List<int>();
    public List<int> secondRandomHolder = new List<int>();
    //public List<Vector2> randomRight = new List<Vector2>();
    //public List<Vector2> randomFront = new List<Vector2>();

    public GameObject[,] extraNodes = new GameObject[10, 7];
    [HideInInspector] static bool[,] nodesCoords = new bool[10, 7];
    int row = 10;
    int q, random, leb, hak;


    private void Start()
    {
<<<<<<< Updated upstream
=======


        if (PlayerPrefs.GetInt("mapGenerated") < 1)//will add 1 at the end of the fight
        {

>>>>>>> Stashed changes

        Transform parentObject = parent.GetComponent<Transform>();
        
        for (int i = 0; i < row; i++)
        {
            if (i == 0)
            {
                q = 3;//Random.Range(3, 5);//how many nodes will be created at first row
                for (int j = 0; j < q; j++)
                {
<<<<<<< Updated upstream
                    uniqueRandomList.Add(NewNumber());//farkli random
                    GameObject tempNode = Instantiate(node, parentObject);
                    Grid.Move(tempNode, i, uniqueRandomList[j]);
                    tempNode.name = (i + "x" + uniqueRandomList[j]);
                    tempRandomList.Add(uniqueRandomList[j]);
                    nodeCollector[0, uniqueRandomList[j]] = tempNode;
                    //nodesCoords[i, uniqueRandomList[j]] = true;

=======
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
                        //nodesCoords[i, uniqueRandomList[j]] = true;

                    }
                    uniqueRandomList.Clear();
>>>>>>> Stashed changes
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
                            if (random == 0 && temp != 0)//left
                            {
<<<<<<< Updated upstream
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
=======
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
>>>>>>> Stashed changes


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
<<<<<<< Updated upstream
                                    nodeCollector[i, p + 1] = tempNode;
                                }
=======
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
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
                                    nodeCollector[i, p] = tempNode;
=======

                                    GameObject tempNode = Instantiate(node, parentObject);
                                    Grid.Move(tempNode, i, p);
                                    tempNode.name = (i + "x" + p);
                                    uniqueRandomList.Add(p);

                                    //randomFront.Add(new Vector2(i, p));
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
>>>>>>> Stashed changes
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
                            if (random == 0 && temp != 0)//left
                            {
<<<<<<< Updated upstream
                                GameObject tempNode = Instantiate(node, parentObject);

                                Grid.Move(tempNode, i, p - 1);
                                tempNode.name = (i + "x" + (p - 1));
                                tempRandomList.Add(p - 1);
=======
                                int temp = (int)p;
                                random = Random.Range(0, 3);//0,temp=3
                                secondRandomHolder.Add(random);
                                if (random == 0 && temp != 0)//left
                                {
                                    GameObject tempNode = Instantiate(node, parentObject);

                                    Grid.Move(tempNode, i, p - 1);
                                    tempNode.name = (i + "x" + (p - 1));
                                    tempRandomList.Add(p - 1);

                                    //randomRight.Add(new Vector2(i, p));
                                    LineCreatorLeft(i, p, parentObject);
>>>>>>> Stashed changes

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
        NodeClass.NodeClassification(nodeCollector,nodesCoords,extraNodes,images);
        //if (!mapGenerator.runStarted)//runa yeni ba?lay?nca true olacak
        {
            for (int j = 0; j < 7; j++)
            {
                if (nodeCollector[0, j])
                {
                    nodeCollector[0, j].GetComponent<Button>().interactable = true;
                }

            }
<<<<<<< Updated upstream

        }
        foreach (GameObject item in extraNodes)
        {
            Destroy(item);
        }
        //for (int i = 1; i < 10; i++)
        //{
        //    for (int j = 0; j < 7; j++)
        //    {
        //        Debug.Log(i+"x"+j);
        //        GameObject nodeToBeDestroyed = map.transform.Find(i + "x" + j).gameObject;
        //        if (nodeToBeDestroyed.GetComponent<Button>().interactable == false)
        //        {
        //            Destroy(nodeToBeDestroyed);
        //            j--;

        //        }

        //    }

        //}

=======
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
            //Debug.Log("x");
            ReadListFromFile();
            
            Transform parentObject = parent.GetComponent<Transform>();

            tempRandomList = new List<int>();
            for (int i = 0; i < row; i++)
            {
                if (i == 0)
                {
                    q = 3;//Random.Range(3, 5);//how many nodes will be created at first row
                    for (int j = 0; j < q; j++)
                    {
                        //Debug.Log("Selam:" + firstRowIndexes[j]);
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
                    leb = 0;
                    hak = 0;
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

                                    //randomFront.Add(new Vector2(i, p));
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
                                random = secondRandomHolder[hak];//0,temp=3
                                hak++;
                                if (random == 0 && temp != 0)//left
                                {
                                    GameObject tempNode = Instantiate(node, parentObject);

                                    Grid.Move(tempNode, i, p - 1);
                                    tempNode.name = (i + "x" + (p - 1));
                                    tempRandomList.Add(p - 1);

                                    //randomRight.Add(new Vector2(i, p));
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
        }
        isGenerated++;


    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("mapGenerated", 0);
>>>>>>> Stashed changes
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
        lineNameCollectorLower.Add(new Vector2(i - 1, p));

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
        lineNameCollectorLower.Add(new Vector2(i - 1, p));

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
        lineNameCollectorLower.Add(new Vector2(i - 1, p));

    }


<<<<<<< Updated upstream
    void SaveRunX(int runStartxAxis)
    {
        PlayerPrefs.SetInt("runStateXAxis", runStartxAxis);
    }
    int LoadRunXAxis(int xPosition)
    {
        return PlayerPrefs.GetInt("runStateXAxis", xPosition);
    }
    void SaveRunY(int runStartyAxis)
    {
        PlayerPrefs.SetInt("runStateYAxis", runStartyAxis);
    }
    int LoadRunYAxis(int yPosition)
    {
        return PlayerPrefs.GetInt("runStateYAxis", yPosition);
=======
    public void WriteListToFile()
    {
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/firstRowIndexes.txt", firstRowIndexes.Select(x => x.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/nodeIndexes_x.txt", nodeIndexes.Select(x => x.x.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/nodeIndexes_y.txt", nodeIndexes.Select(x => x.y.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/randomHolder.txt", randomHolder.Select(x => x.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/secondRandomHolder.txt", secondRandomHolder.Select(x => x.ToString()));
    }

    public void ReadListFromFile()
    {
        firstRowIndexes = File.ReadLines(Application.dataPath + @"/Assets/Database/firstRowIndexes.txt").Select(x =>int.Parse(x)).ToList();
        
        randomHolder = File.ReadLines(Application.dataPath + @"/Assets/Database/randomHolder.txt").Select(x => int.Parse(x)).ToList();
        secondRandomHolder = File.ReadLines(Application.dataPath + @"/Assets/Database/secondRandomHolder.txt").Select(x => int.Parse(x)).ToList();

        //Debug.Log(firstRowIndexes.Count);
        //Debug.Log(randomHolder.Count);
        //Debug.Log(secondRandomHolder.Count);
    }
    public void CheckLowerLinesUpperNode()
    {

>>>>>>> Stashed changes
    }
}

