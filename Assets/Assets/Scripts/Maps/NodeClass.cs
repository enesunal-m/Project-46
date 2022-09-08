using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class NodeClass
{

    public static int[,] NodeClassification(GameObject[,] nodes, bool[,] nodesCoords, GameObject[,] extraNodes)
    {
        int tempType;

        int[,] nodesType = new int[10, 7];
        List<int> typesCounter = new List<int>();
        for (int i = 0; i < 2; i++)
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
        
        int visibleNodes = 0;

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (nodesCoords[i,j])
                {
                    visibleNodes++;
                }
            }
        }

        Debug.Log(visibleNodes);

        int typesCount;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                //Debug.Log("i:"+i+" j:"+j);
                //Debug.Log(nodes[i, j]);

                if (nodes[i, j] != null)
                {
                    nodes[i, j].GetComponent<Image>().color = Color.yellow;
                    typesCount = typesCounter.Count;
                    if (typesCount != 0)
                    {
                        int tempIndex = Random.Range(0, typesCount);

                        tempType = typesCounter[tempIndex];
                        typesCounter.Remove(tempType);
                        nodesType[i, j] = tempType;
                        switch (tempType)
                        {
                            case 1:
                                nodes[i,j].GetComponent<Image>().color = Color.red;//Elite
                                break;
                            case 2:
                                nodes[i, j].GetComponent<Image>().color = Color.black;//Market
                                break;
                            case 3:
                                nodes[i, j].GetComponent<Image>().color = Color.cyan;//Mystery
                                break;
                            case 4:
                                nodes[i, j].GetComponent<Image>().color = Color.blue;//RestSite
                                break;
                            case 5:
                                nodes[i, j].GetComponent<Image>().color = Color.green;//Treassure
                                break;

                        }
                        //Debug.Log(nodesType[i, j]);
                    }
                    else
                    {
                        nodesType[i, j] = 6;
                        //Debug.Log(nodesType[i, j]);
                        nodes[i, j].GetComponent<Image>().color = Color.yellow;
                    }
                }
            }
        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                //Debug.Log("i:"+i+" j:"+j);
                //Debug.Log(nodes[i, j]);

                if (extraNodes[i, j] != null)
                {
                    extraNodes[i, j].GetComponent<Image>().color = Color.yellow;
                    typesCount = typesCounter.Count;
                    if (typesCount != 0)
                    {
                        int chances = Random.Range(0, 100);
                        if (chances<7)
                        {
                            tempType = 0;
                            typesCounter.Remove(tempType);
                            
                            nodesType[i, j] = tempType;
                        }
                        int tempIndex = Random.Range(0, typesCount);
                        //Debug.Log(tempIndex);


                        switch (tempType)
                        {
                            case 1:
                                extraNodes[i, j].GetComponent<Image>().color = Color.red;//Elite
                                break;
                            case 2:
                                extraNodes[i, j].GetComponent<Image>().color = Color.black;//Market
                                break;
                            case 3:
                                extraNodes[i, j].GetComponent<Image>().color = Color.cyan;//Mystery
                                break;
                            case 4:
                                extraNodes[i, j].GetComponent<Image>().color = Color.blue;//RestSite
                                break;
                            case 5:
                                extraNodes[i, j].GetComponent<Image>().color = Color.green;//Treassure
                                break;

                        }
                        //Debug.Log(nodesType[i, j]);
                    }
                    else
                    {
                        nodesType[i, j] = 6;
                        //Debug.Log(nodesType[i, j]);
                        extraNodes[i, j].GetComponent<Image>().color = Color.yellow;
                    }
                }
            }
        }

        return nodesType;
    }
}