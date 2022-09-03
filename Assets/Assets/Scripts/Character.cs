using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

    // core attributes
    public float shield;
    public float strength;
    public string name;

    public float fullHealth;
    public float currentHealth;
    public float healthPercentage
    {
        get
        {
            return currentHealth / fullHealth * 100;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

