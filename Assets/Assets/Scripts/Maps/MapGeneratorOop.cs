using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class MapGeneratorOop : MonoBehaviour
{
    public System.Random a = new System.Random();
    public List<int> uniqueRandomList = new List<int>();
    public List<int> tempRandomList = new List<int>();
    public List<Vector2> fullGrids;
    public GameObject node, parent;
    public GameObject lineRenderer;
    [HideInInspector] static bool[,] nodesCoords = new bool[10, 7];
    [HideInInspector] GameObject[,] nodeCollector;
    int row = 10;
    int q, random;
    int randomListChanger;

    private void Start()
    {
        GameObject[,] nodeCollector = new GameObject[10, 7];
        randomListChanger = 0;
        Transform parentObject = parent.GetComponent<Transform>();
        for (int i = 0; i < row; i++)
        {
            if (i == 0)
            {
                q = Random.Range(2, 5);//how many nodes will be created at first row
                for (int j = 0; j < q; j++)
                {
                    uniqueRandomList.Add(NewNumber());//farklı random
                    GameObject tempNode = Instantiate(node, parentObject);
                    Grid.Move(tempNode, i, uniqueRandomList[j]);
                    tempNode.name = (i + "x" + uniqueRandomList[j]);
                    tempRandomList.Add(uniqueRandomList[j]);
                    nodeCollector[0, uniqueRandomList[j]] = tempNode;
                    print(uniqueRandomList[j]);
                    nodesCoords[i, uniqueRandomList[j]] = true;

                }
                uniqueRandomList.Clear();
            }
            else
            {
                randomListChanger++;//%2==1 bu değilse temprandomlist
                switch (randomListChanger % 2)
                {
                    case 1:
                        foreach (int p in tempRandomList)
                        {
                            int temp = (int)p;
                            random = Random.Range(0, 3);//0,temp=3
                            if (random == 0 && temp != 0 && nodeCollector[i, (p - 1)] == null)//left
                            {
                                GameObject tempNode = Instantiate(node, parentObject);
                                nodeCollector[i, p] = tempNode;

                                Grid.Move(tempNode, i, p - 1);
                                tempNode.name = (i + "x" + (p - 1));
                                uniqueRandomList.Add(p - 1);
                                Vector2 upper = Grid.Position(i, p - 1);
                                Vector2 lower = Grid.Position(i - 1, p);
                                GameObject lr = Instantiate(lineRenderer, parentObject);
                                lr.GetComponent<LineRenderer>().SetPosition(0, lower);
                                lr.GetComponent<LineRenderer>().SetPosition(1, upper);
                                lr.name = (" lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + (p - 1) + "]");
                                //Debug.Log(" lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + (p - 1) + "] i : " + i + "p-1 : " + (p - 1));
                                nodeCollector[i, p - 1] = tempNode;
                                nodesCoords[i, p - 1] = true;


                            }
                            else if (random == 1 && temp != 6)//right
                            {
                                GameObject tempNode = Instantiate(node, parentObject);
                                Grid.Move(tempNode, i, p + 1);
                                tempNode.name = (i + "x" + (p + 1));
                                uniqueRandomList.Add(p + 1);
                                Vector2 upper = Grid.Position(i, p + 1);
                                Vector2 lower = Grid.Position(i - 1, p);
                                GameObject lr = Instantiate(lineRenderer, parentObject);
                                lr.GetComponent<LineRenderer>().SetPosition(0, lower);
                                lr.GetComponent<LineRenderer>().SetPosition(1, upper);
                                lr.name = ("lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + (p + 1) + "]");
                                //Debug.Log(" lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + (p + 1) + "] i : " + i + "p+1 : " + (p + 1));
                                nodeCollector[i, p + 1] = tempNode;
                                nodesCoords[i, p + 1] = true;

                            }
                            else//front
                            {

                                GameObject tempNode = Instantiate(node, parentObject);
                                Grid.Move(tempNode, i, p);
                                tempNode.name = (i + "x" + p);
                                uniqueRandomList.Add(p);
                                Vector2 upper = Grid.Position(i, p);
                                Vector2 lower = Grid.Position(i - 1, p);
                                GameObject lr = Instantiate(lineRenderer, parentObject);
                                lr.GetComponent<LineRenderer>().SetPosition(0, lower);
                                lr.GetComponent<LineRenderer>().SetPosition(1, upper);
                                lr.name = ("lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + p + "]");
                                //Debug.Log(" lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + p + "] i : " + i + "p : " + p);
                                nodeCollector[i, p] = tempNode;
                                nodesCoords[i, p] = true;
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
                                Vector2 upper = Grid.Position(i, p - 1);
                                Vector2 lower = Grid.Position(i - 1, p);
                                GameObject lr = Instantiate(lineRenderer, parentObject);
                                lr.GetComponent<LineRenderer>().SetPosition(0, lower);
                                lr.GetComponent<LineRenderer>().SetPosition(1, upper);
                                lr.name = (" lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + (p - 1) + "]");
                                //Debug.Log(" lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + (p - 1) + "] i : " + i + "p-1 : " + (p - 1));
                                nodeCollector[i, p - 1] = tempNode;
                                nodesCoords[i, p - 1] = true;

                            }
                            else if (random == 1 && temp != 6)//right
                            {
                                GameObject tempNode = Instantiate(node, parentObject);
                                Grid.Move(tempNode, i, p + 1);
                                tempNode.name = (i + "x" + (p + 1));
                                tempRandomList.Add(p + 1);
                                Vector2 upper = Grid.Position(i, p + 1);
                                Vector2 lower = Grid.Position(i - 1, p);
                                GameObject lr = Instantiate(lineRenderer, parentObject);
                                lr.GetComponent<LineRenderer>().SetPosition(0, lower);
                                lr.GetComponent<LineRenderer>().SetPosition(1, upper);
                                lr.name = ("lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + (p + 1) + "]");
                                //Debug.Log(" lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + (p + 1) + "] i : " + i + "p+1 : " + (p + 1));
                                nodeCollector[i, p + 1] = tempNode;
                                nodesCoords[i, p + 1] = true;
                            }
                            else//front
                            {

                                GameObject tempNode = Instantiate(node, parentObject);
                                Grid.Move(tempNode, i, p);
                                tempNode.name = (i + "x" + p);
                                tempRandomList.Add(p);
                                Vector2 upper = Grid.Position(i, p);
                                Vector2 lower = Grid.Position(i - 1, p);
                                GameObject lr = Instantiate(lineRenderer, parentObject);
                                lr.GetComponent<LineRenderer>().SetPosition(0, lower);
                                lr.GetComponent<LineRenderer>().SetPosition(1, upper);
                                lr.name = ("lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + p + "]");
                                //Debug.Log(" lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + (p) + "] i : " + i + "p-1 : " + (p));
                                nodeCollector[i, p] = tempNode;
                                nodesCoords[i, p] = true;
                                //Draw line from lower to upper
                            }



                        }
                        uniqueRandomList.Clear();
                        break;

                }

            }

        }

        NodeClass.NodeClassification(nodeCollector,nodesCoords);
        //classification.NodeCollection(nodeCollector);
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



    //public void ListElements(List<int> list)
    //{
    //    foreach (int h in list)
    //    {
    //    }
    //}



}

