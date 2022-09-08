using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class MapLineGenerator : MonoBehaviour
{
    public System.Random a = new System.Random();
    public List<int> uniqueRandomList = new List<int>();
    public List<int> tempRandomList = new List<int>();
    public List<Vector2> fullGrids;
    public GameObject node, parent;
    public GameObject lineRenderer;
    [HideInInspector] GameObject[,] nodeCollector = new GameObject[10, 7];
    [HideInInspector] GameObject[,] extraNodes = new GameObject[10, 7];
    [HideInInspector] static bool[,] nodesCoords = new bool[10, 7];
    int row = 10;
    int q, random;

    private void Start()
    {

        Transform parentObject = parent.GetComponent<Transform>();
        for (int i = 0; i < row; i++)
        {
            if (i == 0)
            {
                q = Random.Range(2, 5);//how many nodes will be created at first row
                for (int j = 0; j < q; j++)
                {
                    uniqueRandomList.Add(NewNumber());//farklý random
                    GameObject tempNode = Instantiate(node, parentObject);
                    Grid.Move(tempNode, i, uniqueRandomList[j]);
                    tempNode.name = (i + "x" + uniqueRandomList[j]);
                    tempRandomList.Add(uniqueRandomList[j]);
                    nodeCollector[0, uniqueRandomList[j]] = tempNode;
                    //nodesCoords[i, uniqueRandomList[j]] = true;

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
                                    print(tempNode.name);
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
        NodeClass.NodeClassification(nodeCollector,nodesCoords,extraNodes);
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
        lr.name = (" lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + (p - 1) + "]");

    }
    private void LineCreatorRight(int i, int p, Transform parentObject)//row=i column=p
    {
        Vector2 upper = Grid.Position(i, p + 1);
        Vector2 lower = Grid.Position(i - 1, p);
        GameObject lr = Instantiate(lineRenderer, parentObject);
        lr.GetComponent<LineRenderer>().SetPosition(0, lower);
        lr.GetComponent<LineRenderer>().SetPosition(1, upper);
        lr.name = ("lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + (p + 1) + "]");

    }
    private void LineCreatorFront(int i, int p, Transform parentObject)//row=i column=p
    {
        Vector2 upper = Grid.Position(i, p);
        Vector2 lower = Grid.Position(i - 1, p);
        GameObject lr = Instantiate(lineRenderer, parentObject);
        lr.GetComponent<LineRenderer>().SetPosition(0, lower);
        lr.GetComponent<LineRenderer>().SetPosition(1, upper);
        lr.name = ("lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + p + "]");

    }



}

