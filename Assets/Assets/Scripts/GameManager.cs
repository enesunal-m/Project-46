using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

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

    [Header("Card Control")]
    public bool isCardSelected = false;

    public Language gameLanguage;

    public CardDatabaseStructure.Root cardDatabaseJson;
    public List<CardDatabaseStructure.ICardInfoInterface> cardsList;

    public EnemyDatabaseStructure.Root enemyDatabaseJson;
    public List<EnemyDatabaseStructure.IEnemyInfoInterface> enemyDataList;

    public BuffDebuffDatabaseStructure.Root buffDebuffDatabaseJson;
    public List<BuffDebuffDatabaseStructure.IBuffDebuffInfoInterface> buffDebuffList;

    public bool isAnyCardSelected = false;

    public List<string> selectedCards = new List<string>();

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
        if (!File.Exists(Application.dataPath + Constants.URLConstants.cardTempDatabaseJsonBaseUrl))
        {
            using (File.Create(Application.dataPath + Constants.URLConstants.cardTempDatabaseJsonBaseUrl)) ;
        }
        if (PlayerPrefs.GetString("Language") == "tr")
        {
            gameLanguage = Language.tr;
        }
        else if (PlayerPrefs.GetString("Language") == "en")
        {
            gameLanguage = Language.en;
        }

        if (PlayerPrefs.GetInt("fromShop") == 1)
        {
            cardsList = JsonController.readCardJsonTempWithPath(Constants.URLConstants.cardTempDatabaseJsonBaseUrl);
            Constants.CardConstants.deckCardCount = cardsList.Count;
            PlayerPrefs.SetInt("fromShop", 0);
        } else
        {
            cardDatabaseJson = LanguageManager.getCardDatabaseWithLanguage();
            cardsList = CardDatabase.initalizecardsList(cardDatabaseJson);
        }

        enemyDatabaseJson = JsonController.getEnemyJsonWithPath(Constants.URLConstants.enemyDatabaseJsonBaseUrl);
        enemyDataList = EnemyController.initalizeEnemyList(enemyDatabaseJson);

        buffDebuffDatabaseJson = JsonController.getBuffDebuffJsonWithPath(Constants.URLConstants.buffDebuffDatabaseJsonBaseUrl);
        buffDebuffList = BuffDebuffController.initalizeBuffDebuffList(buffDebuffDatabaseJson);

        GameManager.Instance.gameObject.GetComponent<CardSelectorController>().generateCardsForSelector(3);
        Instance.gameObject.GetComponent<DeckController>().BuildDeck(Constants.CardConstants.deckCardCount);

        CardManager.Instance.CheckDeck();
    }

    void Update()
    {
    }

    private void OnApplicationQuit()
    {
        using (File.Create(Application.dataPath + Constants.URLConstants.cardTempDatabaseJsonBaseUrl)) ;
    }

    public void initalizeEnemyList(List<GameObject> _enemyList)
    {
        this.enemyList = _enemyList;
    }

    public void initializePlayerController()
    {
        playerController = PlayerController.Instance;
    }

    public void GoToShopScene()
    {
        PlayerPrefs.SetInt("playerCoin", PlayerPrefs.GetInt("playerCoin") + 30 );
        SceneManager.LoadScene(1);
    }
}
