using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains information and functions of player character
/// </summary>
public class PlayerController : CharacterBaseClass
{
    public List<StateEffect> stateEffects;

    private static PlayerController instance = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static PlayerController Instance { get; private set; }
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

    // constructor
    private PlayerController(float fullHealth, float shield, float strength, string name)
    {
        this.fullHealth = fullHealth;
        this.currentHealth = fullHealth;
        this.shield = shield;
        this.strength = strength;
        this._name = name;
    }

    public static PlayerController getInstance()
    {
        if (instance == null)
            instance = new PlayerController(fullHealth: Constants.PlayerConstants.initialFullHealth,
            shield: Constants.PlayerConstants.initialShield,
            strength: Constants.PlayerConstants.initalStrength,
            name: "SixtyFour");
        return instance;
    }

    // self-modifier functions
    public void getDamage(float damage)
    {
        currentHealth -= damage * GameManager.Instance.playerDamageMultiplier - shield;
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
