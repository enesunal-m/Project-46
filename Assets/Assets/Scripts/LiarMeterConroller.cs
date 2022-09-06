using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiarMeterConroller : MonoBehaviour
{
    public int liarValue;
    int maxLiarValue;
    int minLiarValue;
    [SerializeField] Liarmeter liarmeter;
    void Start()
    {
        minLiarValue = 0;
        liarValue = 50;
        maxLiarValue = 100;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            setLiarValue(5);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            setLiarValue(-5);
        }
    }

    void setLiarValue(int change)
    {
        liarValue += change;
        liarmeter.SetValue(liarValue);
    }
}
