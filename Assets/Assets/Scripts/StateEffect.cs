using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateEffect 
{
    public string name;
    public string description;
}

public static class StateEffectFunctions
{

    private static GameManager gameManager;

    // function to use in buff and debuffs
    public static void changeDamagePercentageForPlayer(float multiplier)
    {
        gameManager.playerDamageMultiplier = gameManager.playerDamageMultiplier + multiplier;
    }
}

// character gets x1.5 damage
public class HalfMoreDamage : TurnBasedStateEffect
{
    private float damageIncreasePercentage = .5f;

    public HalfMoreDamage(int turnDuration, string name, string description)
    {
        this.effectedTurnCount = 0;
        this.turnDuration = turnDuration;
        this.name = name;
        this.description = description;
    }

    public void getHalfMoreDamage()
    {
        StateEffectFunctions.changeDamagePercentageForPlayer(damageIncreasePercentage);
    }
    public void normalizeDamage()
    {
        StateEffectFunctions.changeDamagePercentageForPlayer(-damageIncreasePercentage);
    }

    // apply the effect and check the turn count
    public bool run()
    {
        effectedTurnCount += 1;
        if (effectedTurnCount >= turnDuration)
        {
            end();
            return false;
        } else
        {
            return true;
        }
    }
    public void end()
    {
        normalizeDamage();
    }
}


