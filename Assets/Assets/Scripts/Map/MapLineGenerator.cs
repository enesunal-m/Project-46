using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class MapLineGenerator : MonoBehaviour
{
    public GameObject map;
    public Sprite[] images = new Sprite[7];
    [HideInInspector] List<int> uniqueRandomList = new List<int>();
    public List<int> tempRandomList = new List<int>();
    public List<Vector2> fullGrids;
    public GameObject node, parent;
    public GameObject lineRenderer;
    public GameObject[,] nodeCollector = new GameObject[15, 12];
    public List<Vector2> lineNameCollectorUpper = new List<Vector2>();
    public List<int> lineNameCollectorUpperX = new List<int>();
    public List<int> lineNameCollectorUpperY = new List<int>();
    public List<Vector2> lineNameCollectorLower = new List<Vector2>();
    public List<int> lineNameCollectorLowerX = new List<int>();
    public List<int> lineNameCollectorLowerY = new List<int>();
    public bool runStarted;//Becomes true when run starts
    public List<int> firstRowIndexes = new List<int>();
    public List<int> firstRowIndexes_ = new List<int>();
    public List<Vector2> nodeIndexes = new List<Vector2>();
    public List<int> randomHolder = new List<int>();
    public List<int> secondRandomHolder = new List<int>();
    public List<int> classificationRandomHolder = new List<int>();

    public GameObject[,] extraNodes = new GameObject[15, 12];
    int row = 15;
    int column = 12;
    
    int q, random, leb, hak;
    public int chances;


    private void Start()
    {
        Transform parentObject = parent.GetComponent<Transform>();

        for (int i = 0; i < row; i++)
        {
            if (i == 0)
            {
                q = 5;//Random.Range(3, 5);//how many nodes will be created at first row
                for (int j = 0; j < q; j++)
                {
                    if (PlayerPrefs.GetInt("mapGenerated") < 1)
                    {
                        uniqueRandomList.Add(NewNumber());//unique random
                        firstRowIndexes.Add(uniqueRandomList[j]);//save file[0,newnumber]
                    }
                    else
                    {
                        ReadListFromFile();
                        uniqueRandomList.Add(firstRowIndexes[j]);
                        leb = 0;
                        hak = 0;
                    }

                    GameObject tempNode = Instantiate(node, parentObject);
                    Grid.Move(tempNode, i, uniqueRandomList[j]);
                    tempNode.name = (i + "x" + uniqueRandomList[j]);
                    tempRandomList.Add(uniqueRandomList[j]);
                    nodeCollector[0, uniqueRandomList[j]] = tempNode;
                    if (PlayerPrefs.GetInt("mapGenerated") < 1)
                    {
                        nodeCollector[0, uniqueRandomList[j]].GetComponent<Button>().interactable = true;
                    }
                    
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
                            if (PlayerPrefs.GetInt("mapGenerated") < 1)
                            {
                                random = Random.Range(0, 3);//0,temp=3
                                randomHolder.Add(random);
                            }
                            else
                            {
                                random = randomHolder[leb];//0,temp=3
                                leb++;
                            }

                            if (random == 0 && temp != 0)//left
                            {
                                NodeCreator(i, p - 1, node, parentObject, uniqueRandomList, nodeCollector);
                                LineCreatorLeft(i, p, parentObject);

                            }
                            else if (random == 1 && temp != column-1)//right
                            {
                                NodeCreator(i, p + 1, node, parentObject, uniqueRandomList, nodeCollector);
                                LineCreatorRight(i, p, parentObject);
                            }
                            else//front
                            {
                                NodeCreator(i, p, node, parentObject, uniqueRandomList, nodeCollector);
                                LineCreatorFront(i, p, parentObject);
                            }
                        }
                        tempRandomList.Clear();
                        break;
                    case 0:
                        foreach (int p in uniqueRandomList)
                        {
                            int temp = (int)p;
                            if (PlayerPrefs.GetInt("mapGenerated") < 1)
                            {
                                random = Random.Range(0, 3);//0,temp=3
                                secondRandomHolder.Add(random);
                            }
                            else
                            {
                                random = secondRandomHolder[hak];
                                hak++;
                            }

                            if (random == 0 && temp != 0)//left
                            {
                                NodeCreator(i, p - 1, node, parentObject, tempRandomList, nodeCollector);
                                LineCreatorLeft(i, p, parentObject);

                            }
                            else if (random == 1 && temp != column - 1)//right
                            {
                                NodeCreator(i, p + 1, node, parentObject, tempRandomList, nodeCollector);
                                LineCreatorRight(i, p, parentObject);

                            }
                            else//front
                            {
                                NodeCreator(i, p, node, parentObject, tempRandomList, nodeCollector);
                                LineCreatorFront(i, p, parentObject);
                            }
                        }
                        uniqueRandomList.Clear();
                        break;

                }
            }
        }
        NodeClassification(nodeCollector, extraNodes, images);
        if(PlayerPrefs.GetInt("mapGenerated") >= 1)
        {
            int tempX = PlayerPrefs.GetInt("tempX");
            int tempY = PlayerPrefs.GetInt("tempY");
            int count = lineNameCollectorLower.Count;
            for (int i = 0; i < count; i++)
            {
                if (new Vector2(lineNameCollectorLower[i].x, lineNameCollectorLower[i].y) == new Vector2(tempX, tempY))
                {
                    nodeCollector[(int)lineNameCollectorUpper[i].x, (int)lineNameCollectorUpper[i].y].GetComponent<Button>().interactable = true;
                }
            }
        }



        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if (nodeCollector[i, j])
                {
                    nodeIndexes.Add(new Vector2(i, j));
                }
            }
        }

        WriteListToFile();

        if (PlayerPrefs.GetInt("mapGenerated") < 1)
        {
            int cameraPositionBottom = 0;
            int cameraPositionTop = -1971;
            map.GetComponent<RectTransform>().offsetMax = new Vector2(map.GetComponent<RectTransform>().offsetMax.x, -cameraPositionTop);
            map.GetComponent<RectTransform>().offsetMin = new Vector2(map.GetComponent<RectTransform>().offsetMin.x, cameraPositionBottom);

        }
        else
        {
            int cameraPositionBottom = PlayerPrefs.GetInt("tempX") * -235;
            int cameraPositionTop = -1971 - cameraPositionBottom;
            map.GetComponent<RectTransform>().offsetMax = new Vector2(map.GetComponent<RectTransform>().offsetMax.x, -cameraPositionTop);
            map.GetComponent<RectTransform>().offsetMin = new Vector2(map.GetComponent<RectTransform>().offsetMin.x, cameraPositionBottom);
        }
    }




    private int NewNumber()
    {
        int myNumber = Random.Range(0, column);
        while (uniqueRandomList.Contains(myNumber))
        {
            myNumber = Random.Range(0, column);
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
        lr.name = ("lower:[" + (i - 1) + "," + p + "] upper:[" + i + "," + (p - 1) + "]");
        lineNameCollectorUpperX.Add(i);
        lineNameCollectorUpperY.Add(p - 1);
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
        lineNameCollectorUpperX.Add(i);
        lineNameCollectorUpperY.Add(p + 1);
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
        lineNameCollectorUpperX.Add(i);
        lineNameCollectorUpperY.Add(p);
        lineNameCollectorLowerX.Add(i - 1);
        lineNameCollectorLowerY.Add(p);

    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("mapGenerated", 0);
    }
    public void WriteListToFile()
    {


        File.WriteAllLines(Application.streamingAssetsPath + "/firstRowIndexes.txt", firstRowIndexes.Select(x => x.ToString()));
        File.WriteAllLines(Application.streamingAssetsPath + "/lineNameCollectorUpperX.txt", lineNameCollectorUpperX.Select(x => x.ToString()));
        File.WriteAllLines(Application.streamingAssetsPath + "/lineNameCollectorUpperY.txt", lineNameCollectorUpperY.Select(x => x.ToString()));
        File.WriteAllLines(Application.streamingAssetsPath + "/lineNameCollectorLowerX.txt", lineNameCollectorLowerX.Select(x => x.ToString()));
        File.WriteAllLines(Application.streamingAssetsPath + "/lineNameCollectorLowerY.txt", lineNameCollectorLowerY.Select(x => x.ToString()));
        File.WriteAllLines(Application.streamingAssetsPath + "/randomHolder.txt", randomHolder.Select(x => x.ToString()));
        File.WriteAllLines(Application.streamingAssetsPath + "/secondRandomHolder.txt", secondRandomHolder.Select(x => x.ToString()));
        File.WriteAllLines(Application.streamingAssetsPath + "/classificationRandomHolder.txt", classificationRandomHolder.Select(x => x.ToString()));

    }

    public void ReadListFromFile()
    {
        firstRowIndexes = File.ReadLines(Application.streamingAssetsPath + "/firstRowIndexes.txt").Select(x => int.Parse(x)).ToList();
        lineNameCollectorUpperX = File.ReadLines(Application.streamingAssetsPath + "/lineNameCollectorUpperX.txt").Select(x => int.Parse(x)).ToList();
        lineNameCollectorUpperY = File.ReadLines(Application.streamingAssetsPath + "/lineNameCollectorUpperY.txt").Select(x => int.Parse(x)).ToList();
        lineNameCollectorLowerX = File.ReadLines(Application.streamingAssetsPath + "/lineNameCollectorLowerX.txt").Select(x => int.Parse(x)).ToList();
        lineNameCollectorLowerY = File.ReadLines(Application.streamingAssetsPath + "/lineNameCollectorLowerY.txt").Select(x => int.Parse(x)).ToList();
        randomHolder = File.ReadLines(Application.streamingAssetsPath + "/randomHolder.txt").Select(x => int.Parse(x)).ToList();
        secondRandomHolder = File.ReadLines(Application.streamingAssetsPath + "/secondRandomHolder.txt").Select(x => int.Parse(x)).ToList();
        classificationRandomHolder = File.ReadLines(Application.streamingAssetsPath + "/classificationRandomHolder.txt").Select(x => int.Parse(x)).ToList();

        for (int i = 0; i < lineNameCollectorLowerX.Count; i++)
        {
            lineNameCollectorLower.Add(new Vector2(lineNameCollectorLowerX[i], lineNameCollectorLowerY[i]));
            //0. index = 0,6
        }
        for (int i = 0; i < lineNameCollectorUpperX.Count; i++)
        {
            lineNameCollectorUpper.Add(new Vector2(lineNameCollectorUpperX[i], lineNameCollectorUpperY[i]));
            //0. index = 1,5
        }

    }

    public int[,] NodeClassification(GameObject[,] nodes, GameObject[,] extraNodes, Sprite[] mapImages)
    {
        int tempType;
        int[,] nodesType = new int[row, column];
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
        int k = 0;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {

                if (nodes[i, j] != null)
                {
                    nodes[i, j].tag = "MinorEnemy";//MinorEnemy
                    nodes[i, j].GetComponent<Image>().sprite = mapImages[3];
                    typesCount = typesCounter.Count;
                    if (typesCount != 0)
                    {
                        tempType = RandomCreator(k);
                        k++;
                        typesCounter.Remove(tempType);
                        nodesType[i, j] = tempType;
                        switch (tempType)
                        {
                            case 1:
                                nodes[i, j].tag = "Elite";//Elite
                                nodes[i, j].GetComponent<Image>().sprite = mapImages[5];//Elite
                                break;
                            case 2:
                                nodes[i, j].tag = "Market";//Market
                                nodes[i, j].GetComponent<Image>().sprite = mapImages[4];
                                break;
                            case 3:
                                nodes[i, j].tag = "Mystery";//Mystery
                                nodes[i, j].GetComponent<Image>().sprite = mapImages[2];
                                break;
                            case 4:
                                nodes[i, j].tag = "RestSite";//RestSite
                                nodes[i, j].GetComponent<Image>().sprite = mapImages[1];
                                break;
                            case 5:
                                nodes[i, j].tag = "Treasure";//Treasure
                                nodes[i, j].GetComponent<Image>().sprite = mapImages[0];
                                break;

                        }
                    }
                    else
                    {
                        nodesType[i, j] = 6;
                        nodes[i, j].tag = "MinorEnemy";
                        nodes[i, j].GetComponent<Image>().sprite = mapImages[3];
                    }
                }
            }
        }
        k = 0;

        return nodesType;
    }

    public int RandomCreator(int k)
    {

        if (PlayerPrefs.GetInt("mapGenerated") < 1)
        {
            chances = Random.Range(0, 100);
            classificationRandomHolder.Add(chances);
        }
        else
        {
            chances = classificationRandomHolder[k];
        }
        int tempType;
        if (chances < 4)
        {
            tempType = 1;
        }
        else if (chances < 8)
        {
            tempType = 2;
        }
        else if (chances < 8)
        {
            tempType = 3;
        }
        else if (chances < 12)
        {
            tempType = 4;
        }
        else if (chances < 12)
        {
            tempType = 5;
        }
        else
        {
            tempType = 6;
        }

        return tempType;
    }

    public void NodeCreator(int i, int p, GameObject node, Transform parentObject, List<int> uniqueRandomList, GameObject[,] nodeCollector)
    {
        if (nodeCollector[i, (p)] == null)
        {
            GameObject tempNode = Instantiate(node, parentObject);
            Grid.Move(tempNode, i, p);
            tempNode.name = (i + "x" + p);
            uniqueRandomList.Add(p);
            nodeCollector[i, p] = tempNode;
        }
    }
}

