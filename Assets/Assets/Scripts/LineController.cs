using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public GameObject lineprefab;
    public GameObject currentLine;

    public LineRenderer linerenderer;
    public List<Vector2> FingerPositions;
    public bool drawLine = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //    if (drawLine)
        //    {
        //        currentLine = Instantiate(lineprefab, Vector3.zero, Quaternion.identity);

        //        drawLine = false;
        //    }

        //    CreateLine();
        //    /*if (Input.GetMouseButton(0))
        //    {
        //        Vector2 temFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //        if (Vector2.Distance(temFingerPos, FingerPositions[FingerPositions.Count - 1]) > .1f)
        //        {

        //            UpdateLine(temFingerPos);
        //        }
        //    }*/
        //}


        //void CreateLine()
        //{       
        //    linerenderer = currentLine.GetComponent<LineRenderer>();
        //    FingerPositions.Clear();
        //    FingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //    FingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //    linerenderer.SetPosition(0, Vector3.zero);
        //    linerenderer.SetPosition(1, FingerPositions[1]);
        //}

        //void UpdateLine(Vector2 newFingerPos)
        //{
        //    FingerPositions.Add(newFingerPos);
        //    linerenderer.positionCount++;
        //    linerenderer.SetPosition(linerenderer.positionCount - 1, newFingerPos);
        //}
    }
}

