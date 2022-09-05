using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the game
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Turn system")]
    public Characters turnSide = Characters.Player; // 0 --> Player, 1 --> Enemy

    [Header("Global vars for enemies and player")]
    public float playerDamageMultiplier = Constants.DamageConstants.initalPlayerMultiplier;
    public float enemyDamageMultiplier = Constants.DamageConstants.initalEnemyMultiplier;
    public int playerMana = Constants.PlayerConstants.initialMana;

    public PlayerController playerController;
    public List<GameObject> enemyList;

    private static GameManager instance = null;

    public Language gameLanguage = Language.en;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
    }

    public void initializePlayerController()
    {
        playerController = PlayerController.getInstance();
    }
}
