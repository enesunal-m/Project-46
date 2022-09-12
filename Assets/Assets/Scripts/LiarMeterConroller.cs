using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LiarMeterConroller : MonoBehaviour
{
    public int liarValue;
    int maxLiarValue;
    int minLiarValue;
    [SerializeField] Liarmeter liarmeter;

    public Light2D spotlightLeft;
    public Light2D spotlightRight;
    public Light2D spotlightTop;

    private float tColor = 1;
    private Color currentColor;
    private float change_;

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
        if (liarValue > 100)
            liarValue = 100;
        else if (liarValue < 0)
            liarValue = 0;

        if (tColor < 1f)
        { // if end color not reached yet...
            tColor += Time.deltaTime / 2; // advance timer at the right speed
            spotlightTop.color = Color.Lerp(spotlightTop.color, currentColor, tColor);
        }
    }

    public void setLiarValue(int change)
    {
        Debug.Log("Liar changed");
        liarValue += change;
        liarmeter.SetValue(liarValue);
        change_ = change;
        CheckLiarStatus();
    }

    public void CheckLiarStatus()
    {

        Color currentColor_ = spotlightTop.color;
        float colorShard = 0.03f;
        Color newColor;
        if (change_ > 0)
        {
           newColor  = new(1, spotlightTop.color.g - (colorShard * change_), spotlightTop.color.b - (colorShard * change_));
        } else
        {
            newColor = new(spotlightTop.color.r + (colorShard * change_), 1, 1);
        }

        currentColor = newColor;
        tColor = 0;
    }
}
