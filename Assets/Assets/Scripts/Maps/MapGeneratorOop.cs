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
    public List<int> randomHorizontalAxisValues = new List<int>();
    public GameObject node, parent;
    int row = 10;
    int q, random;

    private void Start()
    {
        Transform parentObject = parent.GetComponent<Transform>();
        int x = 0;
        for (int i = 0; i < row; i++)
        {
            if (i == 0)
            {
                q = Random.Range(2, 5);//how many nodes will be created at first row
                for (int j = 0; j < q; j++)
                {
                    uniqueRandomList.Add(NewNumber());
                    GameObject tempNode = Instantiate(node, parentObject);
                    Grid.Move(tempNode, uniqueRandomList[j], i);
                    tempNode.name = (i + "x" + uniqueRandomList[j]);
                    tempRandomList.Add(uniqueRandomList[j]);

                }
                uniqueRandomList.Clear();
            }
            else
            {//getting inside else 9 times-note to self
             //tempRandomList = uniqueRandomList;
                print("sa");
                foreach (int p in tempRandomList)
                {
                    int temp = (int)p;
                    random = Random.Range(0, 3);
                    if (random == 0 && temp != 0)//left
                    {
                        GameObject tempNode = Instantiate(node, parentObject);
                        Grid.Move(tempNode, p - 1, i);
                        tempNode.name = (i + "x" + (p - 1));
                        uniqueRandomList.Add(p - 1);
                    }
                    else if (random == 1 && temp != 6)//right
                    {
                        GameObject tempNode = Instantiate(node, parentObject);
                        Grid.Move(tempNode, p, i);
                        tempNode.name = (i + "x" + p);
                        uniqueRandomList.Add(p - 1);
                    }
                    else//front
                    {

                        GameObject tempNode = Instantiate(node, parentObject);
                        Grid.Move(tempNode, (p + 1), i);
                        tempNode.name = (i + "x" + (p + 1));
                        uniqueRandomList.Add(p + 1);
                    }



                }
                uniqueRandomList.Clear();
            }


            //List<int> horizontalPositions = uniqueRandomList;

        }
        print(x);


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

    public void ListElements(List<int> list)
    {
        foreach (int h in list)
        {
            print(h);
        }
    }



}

