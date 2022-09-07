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
    public List<int> randomHorizontalAxisValues = new List<int>();
    public GameObject node,parent;
    int row=10;
    int q;

    private void Start()
    {
        Transform parentObject = parent.GetComponent<Transform>();
        int x = 0;
        for (int i = 0; i < row; i++)
        {            
            q=Random.Range(2, 4);//how many nodes will be created

            for (int j = 0; j < q; j++)
            {
                uniqueRandomList.Add(NewNumber());
                GameObject tempNode = Instantiate(node,parentObject);
                Grid.Move(tempNode, uniqueRandomList[j],i );
                tempNode.name = (i+" "+j);
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

