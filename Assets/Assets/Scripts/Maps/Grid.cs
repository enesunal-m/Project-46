using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Grid
{
    public static void Move(GameObject node,int desiredRow,int desiredColumn)
    {
        //Later will be changed with variables
        int maxWidth = 800;
        int maxHeigth = 1200;
        int row = 10;
        int column = 7;

        //distances between Grid tiles
        int horizontalDistance = maxWidth / column;
        int verticalDistance = maxHeigth / row;
        Vector2 gridIndexes;

        float y = 250+desiredRow* verticalDistance ;
        float x = 250+desiredColumn * horizontalDistance;
        gridIndexes = new Vector2(x, y);
        node.GetComponent<Transform>().position = gridIndexes;
    }
    public static Vector2 Position(int desiredRow, int desiredColumn)
    {
        //Later will be changed with variables
        int maxWidth = 800;
        int maxHeigth = 1200;
        int row = 10;
        int column = 7;

        //distances between Grid tiles
        int horizontalDistance = maxWidth / column;
        int verticalDistance = maxHeigth / row;
        Vector2 gridIndexes;

        float y = desiredRow * verticalDistance-10;
        float x = desiredColumn * horizontalDistance+150;
        gridIndexes = new Vector2(x, y);
        Debug.Log(gridIndexes);
        return gridIndexes;
    }



    }
