using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NodeClass 
{

    //private static int setRandomType(int i , int j)
    //{
    //    int typeCode;
    //    while (true)
    //    {
    //        int tempType = Random.Range(0, 6);
    //        while (typesCounter[tempType] != 0)
    //        {

    //        }
    //    }
    //    return typeCode;
    //}
    public static int[,] NodeClassification(GameObject[,] nodes)
    {
        //int nodesCount = 0;
        int[,] nodesType = new int[7, 10];

        //int[] typesCounter = new int[5];
        List<int> typesCounter = new List<int>();
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                typesCounter.Add(i);
            }
        }
        typesCounter.Add(3);

        // Holds counter for all nodes Type
        // (Boss (2), == 0
        // Market(2), == 1
        // Mystery(2), == 2
        // RestSite(3) == 3
        // and Treasure(2)) == 4 - respectively

        // the rest will be defined as MinorEnemy
        // EliteEnemy(1) is static

        //for (int i = 0; i < typesCounter.Length; i++)
        //{
        //    typesCounter[i] = 2;
        //}
        //typesCounter[5] = 3;

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if(nodes[i,j])
                {
                    int typesCount = typesCounter.Count;
                    if (typesCount != 0)
                    {
                        int tempType = Random.Range(0, typesCounter.Count);
                        typesCounter.Remove(tempType);
                        nodesType[i, j] = tempType;
                    }
                    else
                    {
                        nodesType[i, j] = 5;
                    }

                    //setRandomType(i,j);
                    //int tempType = Random.Range(0, 6);
                    //while (typesCounter[tempType] != 0)
                    //{

                    //}
                    //nodesCount++;

                }
            }
        }
            
        return nodesType;
    }
}
