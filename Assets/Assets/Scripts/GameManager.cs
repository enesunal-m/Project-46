using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
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

    [Header("Enemy Animator")]

    [HideInInspector] public PlayerController playerController;
    public List<GameObject> enemyList = new List<GameObject>();

    public Language gameLanguage = Language.en;

    public CardDatabaseStructure.Root cardDatabaseJson;
    public List<CardDatabaseStructure.ICardInfoInterface> cardsList;

    public EnemyDatabaseStructure.Root enemyDatabaseJson;
    public List<EnemyDatabaseStructure.IEnemyInfoInterface> enemyDataList;

    public BuffDebuffDatabaseStructure.Root buffDebuffDatabaseJson;
    public List<BuffDebuffDatabaseStructure.IBuffDebuffInfoInterface> buffDebuffList;

    public bool isAnyCardSelected = false;

    public List<GameObject> selectedCards = new List<GameObject>();

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

        enemyDatabaseJson = JsonController.getEnemyJsonWithPath(Constants.URLConstants.enemyDatabaseJsonBaseUrl);
        enemyDataList = EnemyController.initalizeEnemyList(enemyDatabaseJson);

        buffDebuffDatabaseJson = JsonController.getBuffDebuffJsonWithPath(Constants.URLConstants.buffDebuffDatabaseJsonBaseUrl);
        buffDebuffList = BuffDebuffController.initalizeBuffDebuffList(buffDebuffDatabaseJson);

        GameManager.Instance.gameObject.GetComponent<CardSelectorController>().generateCardsForSelector(3);
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
        playerController = PlayerController.Instance;
    }
}
