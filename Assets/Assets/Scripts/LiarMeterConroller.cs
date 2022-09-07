using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiarMeterConroller : MonoBehaviour
{
    public int liarValue;
    int maxLiarValue;
    int minLiarValue;
    [SerializeField] Liarmeter liarmeter;

    public static LiarMeterConroller Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        minLiarValue = 0;
        liarValue = 50;
        maxLiarValue = 100;
    }
    private void Update()
    {
        liarmeter.SetValue(liarValue);
        if (60 <= liarValue && liarValue < 70)
        {
            LiarmeterEffects.Instance.LiarmeterEffect60("demonicAttack");
        }
    }

    public void setLiarValue(int change)
    {
        liarValue += change;
        liarmeter.SetValue(liarValue);
    }
}
