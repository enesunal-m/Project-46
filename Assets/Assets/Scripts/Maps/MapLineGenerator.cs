using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using System;
using Random = UnityEngine.Random;
//using UnityEngine.EventSystems;
using System.IO;
using System.Linq;
//using UnityEditor.Experimental.GraphView;

public class MapLineGenerator : MonoBehaviour
{
    public GameObject map;
    public Sprite[] images = new Sprite[7];
    public System.Random a = new System.Random();
    [HideInInspector] List<int> uniqueRandomList = new List<int>();
    public List<int> tempRandomList = new List<int>();
    public List<Vector2> fullGrids;
    public GameObject node, parent;
    public GameObject lineRenderer;
    public GameObject[,] nodeCollector = new GameObject[10, 7];
    public List<Vector2> lineNameCollectorUpper = new List<Vector2>();
    public List<int> lineNameCollectorUpperX = new List<int>();
    public List<int> lineNameCollectorUpperY = new List<int>();
    public List<Vector2> lineNameCollectorLower = new List<Vector2>();
    public List<int> lineNameCollectorLowerX = new List<int>();
    public List<int> lineNameCollectorLowerY = new List<int>();
    public bool runStarted;//Becomes true when run starts
    public int isGenerated;
    public List<int> firstRowIndexes = new List<int>();
    public List<int> firstRowIndexes_ = new List<int>();
    public List<Vector2> nodeIndexes = new List<Vector2>();
    public List<int> randomHolder = new List<int>();
    public List<int> secondRandomHolder = new List<int>();
    public List<int> classificationRandomHolder = new List<int>();

    public GameObject[,] extraNodes = new GameObject[10, 7];
    int row = 10;
    int q, random, leb, hak;
    public int chances;


    private void Start()
    {

        if (PlayerPrefs.GetInt("mapGenerated") < 1)//will add 1 at the end of the fight
        {
            Transform parentObject = parent.GetComponent<Transform>();

            for (int i = 0; i < row; i++)
            {
                if (i == 0)
                {
                    q = 4;//Random.Range(3, 5);//how many nodes will be created at first row
                    for (int j = 0; j < q; j++)
                    {
                        uniqueRandomList.Add(NewNumber());//farkli random
                        firstRowIndexes.Add(uniqueRandomList[j]);//save file[0,newnumber]
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

                    //%2==1 bu deðilse temprandomlist
                    switch (i % 2)
                    {
                        case 1:
                            foreach (int p in tempRandomList)
                            {
                                int temp = (int)p;
                                random = Random.Range(0, 3);//0,temp=3
                                randomHolder.Add(random);
                                if (random == 0 && temp != 0)//left
                                {


                                    if (nodeCollector[i, (p - 1)] == null)
                                    {
                                        GameObject tempNode = Instantiate(node, parentObject);
                                        Grid.Move(tempNode, i, p - 1);
                                        tempNode.name = (i + "x" + (p - 1));
                                        uniqueRandomList.Add(p - 1);
                                        nodeCollector[i, p - 1] = tempNode;
                                    }
                                    //Debug.Log((i - 1) + "," + (p) + "noktasýndan sola gittim");
                                    LineCreatorLeft(i, p, parentObject);




                                }
                                else if (random == 1 && temp != 6)//right
                                {


                                    if (nodeCollector[i, (p + 1)] == null)
                                    {
                                        GameObject tempNode = Instantiate(node, parentObject);
                                        Grid.Move(tempNode, i, p + 1);
                                        tempNode.name = (i + "x" + (p + 1));
                                        uniqueRandomList.Add(p + 1);
                                        nodeCollector[i, p + 1] = tempNode;
                                    }
                                    //Debug.Log((i - 1) + "," + (p) + "noktasýndan saða gittim");
                                    LineCreatorRight(i, p, parentObject);


                                }
                                else//front
                                {



                                    if (nodeCollector[i, p] == null)
                                    {
                                        GameObject tempNode = Instantiate(node, parentObject);
                                        Grid.Move(tempNode, i, p);
                                        tempNode.name = (i + "x" + p);
                                        uniqueRandomList.Add(p);
                                        nodeCollector[i, p] = tempNode;
                                    }
                                    //Debug.Log((i - 1) + "," + (p) + "noktasýndan düz gittim");
                                    LineCreatorFront(i, p, parentObject);
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
                                secondRandomHolder.Add(random);
                                if (random == 0 && temp != 0)//left
                                {


                                    if (nodeCollector[i, (p - 1)] == null)
                                    {
                                        GameObject tempNode = Instantiate(node, parentObject);
                                        Grid.Move(tempNode, i, p - 1);
                                        tempNode.name = (i + "x" + (p - 1));
                                        tempRandomList.Add(p - 1);
                                        nodeCollector[i, p - 1] = tempNode;

                                    }
                                    //Debug.Log((i - 1) + "," + (p) + "noktasýndan sola gittim");
                                    LineCreatorLeft(i, p, parentObject);

                                }
                                else if (random == 1 && temp != 6)//right
                                {



                                    if (nodeCollector[i, (p + 1)] == null)
                                    {
                                        GameObject tempNode = Instantiate(node, parentObject);
                                        Grid.Move(tempNode, i, p + 1);
                                        tempNode.name = (i + "x" + (p + 1));
                                        tempRandomList.Add(p + 1);
                                        nodeCollector[i, p + 1] = tempNode;
                                    }
                                    //Debug.Log((i - 1) + "," + (p) + "noktasýndan saða gittim");
                                    LineCreatorRight(i, p, parentObject);

                                }
                                else//front
                                {



                                    if (nodeCollector[i, p] == null)
                                    {
                                        GameObject tempNode = Instantiate(node, parentObject);
                                        Grid.Move(tempNode, i, p);
                                        tempNode.name = (i + "x" + p);
                                        tempRandomList.Add(p);
                                        //print(tempNode.name);
                                        nodeCollector[i, p] = tempNode;
                                    }
                                    //Debug.Log((i - 1) + "," + (p) + "noktasýndan düz gittim");
                                    LineCreatorFront(i, p, parentObject);

                                }

                            }
                            uniqueRandomList.Clear();
                            break;

                    }

                }

            }
            NodeClassification(nodeCollector, extraNodes, images);
            foreach (GameObject item in extraNodes)
            {
                Destroy(item);
            }
            {
                for (int j = 0; j < 7; j++)
                {
                    if (nodeCollector[0, j])
                    {
                        nodeCollector[0, j].GetComponent<Button>().interactable = true;
                    }

                }

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

            ReadListFromFile();
            leb = 0;
            hak = 0;

            Transform parentObject = parent.GetComponent<Transform>();

            for (int i = 0; i < row; i++)
            {
                if (i == 0)
                {
                    q = 4;//Random.Range(3, 5);//how many nodes will be created at first row
                    for (int j = 0; j < q; j++)
                    {
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


                                    if (nodeCollector[i, (p - 1)] == null)
                                    {
                                        GameObject tempNode = Instantiate(node, parentObject);
                                        Grid.Move(tempNode, i, p - 1);
                                        tempNode.name = (i + "x" + (p - 1));
                                        uniqueRandomList.Add(p - 1);
                                        //Debug.Log("Extra Node :" + i + "," + (p - 1));
                                        nodeCollector[i, p - 1] = tempNode;
                                    }
                                    //Debug.Log((i - 1) + "," + (p) + "noktasýndan sola gittim");
                                    LineCreatorLeft(i, p, parentObject);



                                }
                                else if (random == 1 && temp != 6)//right
                                {


                                    if (nodeCollector[i, (p + 1)] == null)
                                    {
                                        GameObject tempNode = Instantiate(node, parentObject);
                                        Grid.Move(tempNode, i, p + 1);
                                        tempNode.name = (i + "x" + (p + 1));
                                        uniqueRandomList.Add(p + 1);

                                        //Debug.Log("Extra Node :" + i + "," + (p + 1));
                                        nodeCollector[i, p + 1] = tempNode;
                                    }
                                    //Debug.Log((i - 1) + "," + (p) + "noktasýndan saða gittim");
                                    LineCreatorRight(i, p, parentObject);


                                }
                                else//front
                                {
                                    if (nodeCollector[i, p] == null)
                                    {
                                        GameObject tempNode = Instantiate(node, parentObject);
                                        Grid.Move(tempNode, i, p);
                                        tempNode.name = (i + "x" + p);
                                        uniqueRandomList.Add(p);
                                        //Debug.Log("Extra Node :" + i + "," + (p));
                                        nodeCollector[i, p] = tempNode;
                                    }
                                    //Debug.Log((i - 1) + "," + (p) + "noktasýndan düz gittim");
                                    LineCreatorFront(i, p, parentObject);

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

                                    if (nodeCollector[i, (p - 1)] == null)
                                    {
                                        GameObject tempNode = Instantiate(node, parentObject);
                                        Grid.Move(tempNode, i, p - 1);
                                        tempNode.name = (i + "x" + (p - 1));
                                        tempRandomList.Add(p - 1);
                                        nodeCollector[i, p - 1] = tempNode;
                                    }
                                    //Debug.Log((i - 1) + "," + (p) + "noktasýndan sola gittim");
                                    LineCreatorLeft(i, p, parentObject);


                                }
                                else if (random == 1 && temp != 6)//right
                                {
                                    if (nodeCollector[i, (p + 1)] == null)
                                    {
                                        //Debug.Log("Extra Node :" + i + "," + (p + 1));
                                        GameObject tempNode = Instantiate(node, parentObject);
                                        Grid.Move(tempNode, i, p + 1);
                                        tempNode.name = (i + "x" + (p + 1));
                                        tempRandomList.Add(p + 1);
                                        nodeCollector[i, p + 1] = tempNode;
                                    }
                                    //Debug.Log((i - 1) + "," + (p) + "noktasýndan saða gittim");
                                    LineCreatorRight(i, p, parentObject);
                                }
                                else//front
                                {



                                    if (nodeCollector[i, p] == null)
                                    {
                                        GameObject tempNode = Instantiate(node, parentObject);
                                        Grid.Move(tempNode, i, p);
                                        tempNode.name = (i + "x" + p);
                                        tempRandomList.Add(p);
                                        nodeCollector[i, p] = tempNode;
                                    }
                                    //Debug.Log((i - 1) + "," + (p) + "noktasýndan düz gittim");
                                    LineCreatorFront(i, p, parentObject);

                                }

                            }
                            uniqueRandomList.Clear();
                            break;

                    }

                }

            }

            NodeClassification(nodeCollector, extraNodes, images);
            foreach (GameObject item in extraNodes)
            {
                Destroy(item);
            }

            int tempX = PlayerPrefs.GetInt("tempX");
            int tempY = PlayerPrefs.GetInt("tempY");
            //Debug.Log("first index : " + tempX + "second index:" + tempY);
            int count = lineNameCollectorLower.Count;
            for (int i = 0; i < count; i++)
            {
                if (new Vector2(lineNameCollectorLower[i].x, lineNameCollectorLower[i].y) == new Vector2(tempX, tempY))
                {
                    //Debug.Log((int)lineNameCollectorUpper[i].x + "," + (int)lineNameCollectorUpper[i].y + " açýldý");//Doðru çalýþýyor
                    nodeCollector[(int)lineNameCollectorUpper[i].x, (int)lineNameCollectorUpper[i].y].GetComponent<Button>().interactable = true;
                }

            }

            isGenerated++;

        }
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
        //lineNameCollectorUpper.Add(new Vector2(i, p - 1));
        lineNameCollectorUpperX.Add(i);
        lineNameCollectorUpperY.Add(p - 1);
        //lineNameCollectorLower.Add(new Vector2(i - 1, p));
        lineNameCollectorLowerX.Add(i - 1);
        lineNameCollectorLowerY.Add(p);
        //Debug.Log("Left -- UpperX :" + i + " UpperY :" + (p - 1) + "LowerX :" + (i - 1) + " LowerY :" + p);
    }
    private void LineCreatorRight(int i, int p, Transform parentObject)//row=i column=p
    {
        Vector2 upper = Grid.Position(i, p + 1);
        Vector2 lower = Grid.Position(i - 1, p);
        GameObject lr = Instantiate(lineRenderer, parentObject);
        lr.GetComponent<LineRenderer>().SetPosition(0, lower);
        lr.GetComponent<LineRenderer>().SetPosition(1, upper);
        lr.name = ("lower:[" + (i - 1) + "," + p + "] upper:[" + i + "," + (p + 1) + "]");
        //lineNameCollectorUpper.Add(new Vector2(i, p + 1));
        lineNameCollectorUpperX.Add(i);
        lineNameCollectorUpperY.Add(p + 1);
        //lineNameCollectorLower.Add(new Vector2(i - 1, p));
        lineNameCollectorLowerX.Add(i - 1);
        lineNameCollectorLowerY.Add(p);
        //Debug.Log("Right -- UpperX :" + i + " UpperY :" + (p + 1) + "LowerX :" + (i - 1) + " LowerY :" + p);//Burada doðru

    }
    private void LineCreatorFront(int i, int p, Transform parentObject)//row=i column=p
    {
        Vector2 upper = Grid.Position(i, p);
        Vector2 lower = Grid.Position(i - 1, p);
        GameObject lr = Instantiate(lineRenderer, parentObject);
        lr.GetComponent<LineRenderer>().SetPosition(0, lower);
        lr.GetComponent<LineRenderer>().SetPosition(1, upper);
        lr.name = ("lower:[" + (i - 1) + "," + p + "]" + "upper:[" + i + "," + p + "]");
        //lineNameCollectorUpper.Add(new Vector2(i, p));
        lineNameCollectorUpperX.Add(i);
        lineNameCollectorUpperY.Add(p);
        //lineNameCollectorLower.Add(new Vector2(i - 1, p));
        lineNameCollectorLowerX.Add(i - 1);
        lineNameCollectorLowerY.Add(p);
        //Debug.Log("Front -- UpperX :" + i + " UpperY :" + (p) + "LowerX :" + (i - 1) + " LowerY :" + p);

    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("mapGenerated", 0);
    }
    public void WriteListToFile()
    {


        File.WriteAllLines(Application.dataPath + @"/Assets/Database/firstRowIndexes.txt", firstRowIndexes.Select(x => x.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/lineNameCollectorUpperX.txt", lineNameCollectorUpperX.Select(x => x.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/lineNameCollectorUpperY.txt", lineNameCollectorUpperY.Select(x => x.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/lineNameCollectorLowerX.txt", lineNameCollectorLowerX.Select(x => x.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/lineNameCollectorLowerY.txt", lineNameCollectorLowerY.Select(x => x.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/randomHolder.txt", randomHolder.Select(x => x.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/secondRandomHolder.txt", secondRandomHolder.Select(x => x.ToString()));
        File.WriteAllLines(Application.dataPath + @"/Assets/Database/classificationRandomHolder.txt", classificationRandomHolder.Select(x => x.ToString()));

    }

    public void ReadListFromFile()
    {
        firstRowIndexes = File.ReadLines(Application.dataPath + @"/Assets/Database/firstRowIndexes.txt").Select(x => int.Parse(x)).ToList();
        lineNameCollectorUpperX = File.ReadLines(Application.dataPath + @"/Assets/Database/lineNameCollectorUpperX.txt").Select(x => int.Parse(x)).ToList();
        lineNameCollectorUpperY = File.ReadLines(Application.dataPath + @"/Assets/Database/lineNameCollectorUpperY.txt").Select(x => int.Parse(x)).ToList();
        lineNameCollectorLowerX = File.ReadLines(Application.dataPath + @"/Assets/Database/lineNameCollectorLowerX.txt").Select(x => int.Parse(x)).ToList();
        lineNameCollectorLowerY = File.ReadLines(Application.dataPath + @"/Assets/Database/lineNameCollectorLowerY.txt").Select(x => int.Parse(x)).ToList();
        randomHolder = File.ReadLines(Application.dataPath + @"/Assets/Database/randomHolder.txt").Select(x => int.Parse(x)).ToList();
        secondRandomHolder = File.ReadLines(Application.dataPath + @"/Assets/Database/secondRandomHolder.txt").Select(x => int.Parse(x)).ToList();
        classificationRandomHolder = File.ReadLines(Application.dataPath + @"/Assets/Database/classificationRandomHolder.txt").Select(x => int.Parse(x)).ToList();

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
        int k = 0;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 7; j++)
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

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 7; j++)
            {

                if (extraNodes[i, j] != null)
                {
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

}

