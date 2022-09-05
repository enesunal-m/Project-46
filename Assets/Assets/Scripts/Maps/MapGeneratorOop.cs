using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGeneratorOop : MonoBehaviour
{
        int row = 7;
        int column = 10;
        
    // Start is called before the first frame update
    void Start()
    {
        Button[,] buttons = new Button[column, row];
        for (int i = 0; i < buttons.GetUpperBound(0); i++)
        {
            for (int j = 0; j < buttons.GetUpperBound(1) j++)
            {
                buttons[i, j] = new Button;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
