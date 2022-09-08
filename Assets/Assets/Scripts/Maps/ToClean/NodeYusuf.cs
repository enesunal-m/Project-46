using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeYusuf : MonoBehaviour
{
    public GameObject node { get; set; }
    public Vector2 nodePosition { get; set; }
    public bool isConnected { get; set; }
    public NodeBlueprint.NodeTypes nodeType { get; set; }
    public NodeBlueprint.NodeStates nodeState { get; set; }
    public List<Vector2> ingoing { get; set; }
    public List<Vector2> outgoing { get; set; }

    public NodeYusuf(GameObject node, Vector2 nodePosition /* NodeBlueprint.NodeTypes nodeTypes, NodeBlueprint.NodeStates nodeState*/)
    {
        this.node = node;
        this.nodePosition = nodePosition;
        Instantiate(node);
        //this.nodeType = nodeType;
        //this.nodeState = nodeState;

    }
}
