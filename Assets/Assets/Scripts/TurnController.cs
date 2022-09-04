using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnController
{
    public int turnCount;

    private GameManager gameManager;
    public PlayerController playerController;

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
        gameManager.initializePlayerController();
        // TODO
        // create enemies
        startNewTurn();
        gameManager.turnSide = Characters.Player;
    }

    public void endTurn()
    {
        gameManager.turnSide = decideTurnSide(gameManager.turnSide);
        startNewTurn();
    }

    public void startNewTurn()
    {
        if (gameManager.turnSide == Characters.Player)
        {
            // TODO
            // create enemy intentions
            gameManager.playerMana = Constants.PlayerConstants.initialMana;
            playerController.applyStateEffects();
        } else if(gameManager.turnSide == Characters.Enemy)
        {
            // TODO
            // apply enemy effects on enemies
            // wait at least 1.5 secs
        }
    }

    private Characters decideTurnSide(Characters currentSide)
    {
        if (currentSide == Characters.Player)
        {
            return Characters.Enemy;
        }else
        {
            return Characters.Player;
        }
    }
}

// withIndex extension for indexed foreach
public static class EnumExtension
{
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
       => self.Select((item, index) => (item, index));
}