using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Controls turns and turn structure, and starts and ends the turns
/// </summary>
public class TurnController : MonoBehaviour
{
    public int turnCount;

    public GameManager gameManager;

    public GameObject enemy_;

    // Start is called before the first frame update
    void Start()
    {
        startFight(EnemyType.Normal, EnemyTier.Tier1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startFight(EnemyType enemyType, EnemyTier enemyTier, int enemyCount)
    {
        // Create enemy spawner object
        EnemySpawner enemySpawner = new EnemySpawner(enemy_);

        // Initialize player controller
        gameManager.initializePlayerController();

        // Spawn enemies
        enemySpawner.spawnEnemies(enemyType, enemyTier, enemyCount);

        // Decide the each enemy intention on the start of the fight
        EnemyController.Instance.decideEnemyIntention_all();

        // Pass turn to Player
        gameManager.turnSide = Characters.Player;

        startNewTurn();
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
            gameManager.playerController.applyStateEffects();
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