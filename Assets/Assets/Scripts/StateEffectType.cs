using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// types of different state effects
public abstract class TurnBasedStateEffect : StateEffect
{
    public int turnDuration;
    public int effectedTurnCount;
}
