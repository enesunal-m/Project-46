using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public static class NodeClass
{
    public static int[,] NodeClassification(GameObject[,] nodes, bool[,] nodesCoords, GameObject[,] extraNodes)
    {
        int tempType;
        int[,] nodesType = new int[10, 7];
        List<int> typesCounter = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j < 6; j++)
            {
                typesCounter.Add(j);
            }
        }
        typesCounter.Add(4);

        // Holds counter for all nodes Type
        // (EliteEnemy (2), == 1
        // Market(2), == 2
        // Mystery(2), == 3
        // RestSite(3) == 4
        // and Treasure(2)) == 5 - respectively

        // the rest will be defined as MinorEnemy
        // Boss(1) is static
        int typesCount;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 7; j++)
            {

                if (nodes[i, j] != null)
                {
                    nodes[i, j].tag = "MinorEnemy";//MinorEnemy
                    
                    typesCount = typesCounter.Count;
                    if (typesCount != 0)
                    {
                        tempType = RandomCreator(i, j);
                        typesCounter.Remove(tempType);
                        nodesType[i, j] = tempType;
                        switch (tempType)
                        {
                            case 1:
                                nodes[i, j].tag = "Elite";//Elite
                                break;
                            case 2:
                                nodes[i, j].tag = "Market";//Market

                                break;
                            case 3:
                                nodes[i, j].tag = "Mystery";//Mystery
                                break;
                            case 4:
                                nodes[i, j].tag = "RestSite";//RestSite
                                break;
                            case 5:
                                nodes[i, j].tag = "Treasure";//Treasure
                                break;

                        }
                    }
                    else
                    {
                        nodesType[i, j] = 6;
                        nodes[i, j].tag = "MinorEnemy";
                    }
                }
            }
        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 7; j++)
            {

                if (extraNodes[i, j] != null)
                {
                    typesCount = typesCounter.Count;
                    if (typesCount != 0)
                    {
                        tempType = RandomCreator(i, j);
                        typesCounter.Remove(tempType);
                        nodesType[i, j] = tempType;
                        switch (tempType)
                        {
                            case 1:
                                extraNodes[i, j].tag = "Elite";//Elite
                                break;
                            case 2:
                                extraNodes[i, j].tag = "Market";//Market
                                break;
                            case 3:
                                extraNodes[i, j].tag = "Mystery";//Mystery
                                break;
                            case 4:
                                extraNodes[i, j].tag = "RestSite";//RestSite
                                break;
                            case 5:
                                extraNodes[i, j].tag = "Treasure";//Treasure
                                break;

                        }
                    }
                    else
                    {
                        nodesType[i, j] = 6;
                        extraNodes[i, j].tag = "MinorEnemy"; ;
                    }
                }
            }
        }

        return nodesType;
    }

    public static int RandomCreator(int i, int j)
    {

        int chances = Random.Range(0, 100);
        int tempType;
        if (chances < 4)
        {
            tempType = 1;
        }
        else if (chances < 8)
        {
            tempType = 2;
        }
        else if (chances < 12)
        {
            tempType = 3;
        }
        else if (chances < 16)
        {
            tempType = 4;
        }
        else if (chances < 20)
        {
            tempType = 5;
        }

        else
        {
            tempType = 6;
        }

        return tempType;
    }

    //public static string TempTypeToState(int tempType ,string[,] state,int i,int j)
    //{
    //    if(tempType == 1)
    //    {
    //        state[i, j] = "Elite";
    //        return state[i, j];
    //    }
    //    else if (tempType == 2)
    //    {
    //        state[i, j] = "Market";
    //        return state[i, j];
    //    }
    //    else if (tempType == 3)
    //    {
    //        state[i, j] = "Mystery";
    //        return state[i, j];
    //    }
    //    else if (tempType == 4)
    //    {
    //        state[i, j] = "RestSide";
    //        return state[i, j];
    //    }
    //    else if (tempType == 5)
    //    {
    //        state[i, j] = "Treasure";
    //        return state[i, j];
    //    }
    //    else
    //    {
    //        state[i, j] = "MinorEnemy";
    //        return state[i, j];
    //    }


    //}
}