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
        GameManager.Instance.initializePlayerController();

        // Spawn enemies
        enemySpawner.spawnEnemies(enemyType, enemyTier, enemyCount);

        // Decide the each enemy intention on the start of the fight
        EnemyController.Instance.decideEnemyIntention_all();

        // Pass turn to Player
        GameManager.Instance.turnSide = Characters.Player;

        startNewTurn();
    }

    public void endTurn()
    {
        GameManager.Instance.turnSide = decideTurnSide(GameManager.Instance.turnSide);
        startNewTurn();
    }

    public void startNewTurn()
    {
        if (GameManager.Instance.turnSide == Characters.Player)
        {
            // TODO
            // create enemy intentions
            GameManager.Instance.playerMana = Constants.PlayerConstants.initialMana;
            GameManager.Instance.playerController.applyStateEffects();
        } else if(GameManager.Instance.turnSide == Characters.Enemy)
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