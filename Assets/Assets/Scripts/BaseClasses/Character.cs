using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class of characters i.e. Player, Enemy
/// </summary>
public abstract class CharacterBaseClass : MonoBehaviour
{
    // core attributes
    public float shield;
    public float strength;
    public float nextTurnShieldDelta;
    public float nextTurnStrengthDelta;
    public float nextTurnHealthDelta;
    public int nextTurnManaDelta;
    public float nextTurnDamageMultiplier = 1f;

    public string _name;

    public float fullHealth;
    public float currentHealth;
    public float healthPercentage
    {
        get
        {
            return currentHealth / fullHealth * 100;
        }
    }
}

