using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController
{
    public int turnCount;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startFight()
    {

    }

    public void endTurn()
    {

    }

    public void startNewTurn()
    {
        gameManager.playerMana = Constants.PlayerConstants.initialMana;
    }

}
