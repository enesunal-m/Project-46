using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

    // self-modifier functions
    public void getDamage(float damage)
    {
        currentHealth -= damage - shield;
    }
    public void changeHealth(float healthChange)
    {
        currentHealth += healthChange;
    }
    public void changeShield(float shieldChange)
    {
        shield += shieldChange;
    }

    // buff de-buff functions
    public void changeStrength(float strengthChange)
    {
        strength += strengthChange;
    }

}
