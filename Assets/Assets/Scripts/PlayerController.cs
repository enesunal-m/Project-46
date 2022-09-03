using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterBaseClass
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        fullHealth = Constants.PlayerConstants.initialFullHealth;
        currentHealth = Constants.PlayerConstants.initialFullHealth;
        shield = Constants.PlayerConstants.initialShield;
        strength = Constants.PlayerConstants.initalStrength;
        name = "SixtyFour";
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
