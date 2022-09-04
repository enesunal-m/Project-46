using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterBaseClass
{
    private GameManager gameManager;

    public List<StateEffect> stateEffects;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // constructor
    public PlayerController(float fullHealth, float currentHealth, float shield, float strength, string name)
    {
        this.fullHealth = fullHealth;
        this.currentHealth = fullHealth;
        this.shield = shield;
        this.strength = strength;
        this.name = name;
    }

    public PlayerController(float fullHealth, float shield, float strength, string name)
    {
        this.fullHealth = fullHealth;
        this.shield = shield;
        this.strength = strength;
        this.name = name;
    }

    // self-modifier functions
    public void getDamage(float damage)
    {
        currentHealth -= damage * gameManager.playerDamageMultiplier - shield;
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


    public void applyStateEffects()
    {
        foreach ( (StateEffect stateEffect, int i) in stateEffects.WithIndex())
        {
            bool stopped = stateEffect.run();
            if (stopped)
            {
                stateEffects.RemoveAt(i);
            }
        }
    }
}
