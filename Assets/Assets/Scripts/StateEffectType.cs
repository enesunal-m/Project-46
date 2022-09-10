using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains about turn based effects on player and enemies
/// </summary>
public abstract class TurnBasedStateEffect : StateEffect
{
    public int turnDuration;
    public int effectedTurnCount;
}
