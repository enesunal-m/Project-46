using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the game
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Turn system")]
    public Characters turnSide = Characters.Enemy; // 0 --> Player, 1 --> Enemy

    [Header("Global vars for enemies and player")]
    public float playerDamageMultiplier = Constants.DamageConstants.initalPlayerMultiplier;
    public float enemyDamageMultiplier = Constants.DamageConstants.initalEnemyMultiplier;

    [HideInInspector] public PlayerController playerController;
    public List<GameObject> enemyList = new List<GameObject>();

    public Language gameLanguage = Language.en;

    public Root cardDatabaseJson;
    public List<ICardInfoInterface> cardsList;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        cardDatabaseJson = LanguageManager.getCardDatabaseWithLanguage();
        cardsList = CardDatabase.initalizecardsList(cardDatabaseJson);
    }

    void Update()
    {
    }

    public void initalizeEnemyList(List<GameObject> _enemyList)
    {
        this.enemyList = _enemyList;
    }

    public void initializePlayerController()
    {
        playerController = PlayerController.getInstance();
    }
}
