using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Contains information and functions of player character
/// </summary>
public class PlayerController : CharacterBaseClass
{
    public List<StateEffect> stateEffects;

    private static PlayerController instance = null;

    [Header("HealthBar")]
    [SerializeField] TextMeshProUGUI currentHealthText;
    [SerializeField] TextMeshProUGUI maxHealthText;
    [SerializeField] TextMeshProUGUI shieldText;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI currentManaText;
    [SerializeField] TextMeshProUGUI maxManaText;

    public int playerMana = Constants.PlayerConstants.initialMana;

    // Start is called before the first frame update
    void Start()
    {
        this.fullHealth = Constants.PlayerConstants.initialFullHealth;
        this.currentHealth = Constants.PlayerConstants.initialFullHealth;
        this.shield = Constants.PlayerConstants.initialShield;
        this.strength = Constants.PlayerConstants.initalStrength;
        this._name = "YonJuuRoku";
    }

    // Update is called once per frame
    void Update()
    {
        //Update Player's Health and Shield Interface
        currentHealthText.text = currentHealth.ToString("0");
        maxHealthText.text = fullHealth.ToString("0");
        shieldText.text = shield.ToString("0");
        slider.maxValue = fullHealth;
        slider.value = currentHealth;
        currentManaText.text = playerMana.ToString("0");
        maxManaText.text = Constants.PlayerConstants.initialMana.ToString("0");
    }

    public static PlayerController Instance { get; 
         private set; }
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

    // self-modifier functions
    public void getDamage(float damage)
    {
        shield -= damage;
        if (shield < 0)
        {
            currentHealth -= damage * GameManager.Instance.enemyDamageMultiplier - shield;
        }
        if (shield < 0)
        {
            shield = 0;
        }
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

    public void applyNextTurnDeltas()
    {
        currentHealth += nextTurnHealthDelta;
        shield += nextTurnShieldDelta;
        strength += nextTurnStrengthDelta;
        playerMana += nextTurnManaDelta;
    }

    public void normalizeNextTurnDeltas()
    {
        nextTurnHealthDelta = 0;
        nextTurnManaDelta = 0;
        nextTurnShieldDelta = 0;
        nextTurnStrengthDelta = 0;
    }
    public void normalizeDamageToEnemyMultipliers()
    {
        GameManager.Instance.enemyDamageMultiplier = GameManager.Instance.enemyDamageMultiplier * nextTurnDamageMultiplier;
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
