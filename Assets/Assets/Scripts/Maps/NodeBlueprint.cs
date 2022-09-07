using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBlueprint : MonoBehaviour
{
    public enum NodeTypes
    {
        Boss,
        Market,
        Mystery,
        RestSite,
        Treasure,

        MinorEnemy,
        EliteEnemy
    }

    public enum NodeStates
    {
        Visited,
        Current,
        Locked,
        Attainable
    }
}
