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
    public GameObject node,parent;
    int row=10;
    int q,random;

    private void Start()
    {
        Transform parentObject = parent.GetComponent<Transform>();
        int x = 0;
        for (int i = 0; i < row; i++)
        {            
            q=Random.Range(2, 5);//how many nodes will be created
            if (i == 0)
            {
                for (int j = 0; j < q; j++)
                {
                    uniqueRandomList.Add(NewNumber());
                    GameObject tempNode = Instantiate(node, parentObject);
                    Grid.Move(tempNode, uniqueRandomList[j], i);
                    tempNode.name = (i + "x" + uniqueRandomList[j]);
                    tempRandomList = uniqueRandomList;

                }
                foreach (var p in tempRandomList)
                { print(p); }
            }
            else
            {
                print("sa");
                foreach (var p in tempRandomList)
                {print(p);}
                //foreach (var p in tempRandomList)
                //{
                //    print("saydırıyorum");
                //    int temp = (int)p;
                //    random = Random.Range(0, 3);
                //    print(random);
                //    if (random==0&&temp!=0)//left
                //    {
                //        print("girdim");
                //        uniqueRandomList.Add(NewNumber());
                //        //fullGrids.Add(new Vector2(i, uniqueRandomList[j]));//if(i!=0)Arkadaki konumlara bakarak oluştur fullgridse bak
                //        GameObject tempNode = Instantiate(node, parentObject);
                //        Grid.Move(tempNode, uniqueRandomList[p-1], i);
                //        tempNode.name = (i + "x" + uniqueRandomList[p-1]);
                //        tempRandomList = uniqueRandomList;
                //    }
                //    else if (random == 1&&temp!=6)//right
                //    {
                //        print("girdim");
                //        uniqueRandomList.Add(NewNumber());
                //        //fullGrids.Add(new Vector2(i, uniqueRandomList[j]));//if(i!=0)Arkadaki konumlara bakarak oluştur fullgridse bak
                //        GameObject tempNode = Instantiate(node, parentObject);
                //        Grid.Move(tempNode, uniqueRandomList[p], i);
                //        tempNode.name = (i + "x" + uniqueRandomList[p]);
                //        tempRandomList = uniqueRandomList;
                //    }
                //    else//front
                //    {
                //        print("girdim");
                //        uniqueRandomList.Add(NewNumber());
                //        GameObject tempNode = Instantiate(node, parentObject);
                //        Grid.Move(tempNode, uniqueRandomList[p + 1], i);
                //        tempNode.name = (i + "x" + uniqueRandomList[p + 1]);
                //        tempRandomList = uniqueRandomList;
                //    }


                //}
            }
            
            uniqueRandomList.Clear();

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



}

