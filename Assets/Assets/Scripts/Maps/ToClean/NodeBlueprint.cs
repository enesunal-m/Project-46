using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBlueprint : MonoBehaviour
{
    public enum NodeTypes
    {
        MinorEnemy,
        EliteEnemy,
        RestSite,
        Treasure,
        Market,
        Boss,
        Mystery
    }

    public enum NodeStates
    {
        Visited,
        Current,
        Locked,
        Attainable
    }
}
