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
    private GameObject[] cardsOnDeck;

    // Start is called before the first frame update
    void Start()
    {
        startFight(EnemyType.Normal, EnemyTier.Tier2, 1);
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
        Debug.Log(GameManager.Instance.turnSide);

        startNewTurn();
    }

    public void endTurn()
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        foreach (var item in cards)
        {
            Destroy(item.gameObject);
        }
        GameManager.Instance.turnSide = decideTurnSide(GameManager.Instance.turnSide);
        if (GameManager.Instance.turnSide == Characters.Player)
        {
            GameManager.Instance.playerController.applyNextTurnDeltas();
            GameManager.Instance.playerController.normalizeDamageToEnemyMultipliers();
        }
        startNewTurn();
    }

    public void startNewTurn()
    {
        if (GameManager.Instance.turnSide == Characters.Player)
        {
            // TODO
            // create enemy intentions
            GameManager.Instance.playerController.playerMana = Constants.PlayerConstants.initialMana;
            Debug.Log("Player Turn");
            //GameManager.Instance.playerController.applyStateEffects();
        } else if(GameManager.Instance.turnSide == Characters.Enemy)
        {
            // TODO
            enemy_.GetComponent<EnemyController>().applyDecidedIntentions_all();
            Invoke("endTurn", 2);
            EnemyController.Instance.applyNextTurnDamageMultiplier_all();
            Debug.Log("Enemy Turn");
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