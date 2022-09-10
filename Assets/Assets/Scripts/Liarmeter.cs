using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Liarmeter : MonoBehaviour
{
    public Slider slider;
    public void SetMaxValue()
    {
        slider.maxValue = 100;
        slider.value = 50;
    }
    public void SetValue(int value)
    {
        slider.value = value;
    }
}
