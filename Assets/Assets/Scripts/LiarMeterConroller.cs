using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiarMeterConroller : MonoBehaviour
{
    private static LiarMeterConroller instance = null;

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

    public static LiarMeterConroller getInstance()
    {
        if (instance == null)
            instance = new LiarMeterConroller();
        return instance;
    }

    void setLiarValue(int change)
    {
        liarValue += change;
        liarmeter.SetValue(liarValue);
    }
}
