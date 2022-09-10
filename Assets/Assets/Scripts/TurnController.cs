using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls turns and turn structure, and starts and ends the turns
/// </summary>
public class TurnController : MonoBehaviour
{
    public int turnCount;

    public float waitTillEndTurn;

    public GameObject enemy_;
    private GameObject[] cardsOnDeck;

    private bool justOnceForLiarmeter70, justOnceForLiarmeter85 = false;


    // Start is called before the first frame update
    void Start()
    {
        startFight(EnemyType.Normal, EnemyTier.Tier1, 1);
        PlayerPrefsController.SavePlayerInfo();
        PlayerPrefsController.SaveGlobalPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("LIAAAAR " + GameManager.Instance.transform.GetComponent<LiarMeterConroller>().liarValue);
    }

    public void startFight(EnemyType enemyType, EnemyTier enemyTier, int enemyCount)
    {
        GameObject.Find("Map").SetActive(false);

        // Initialize player controller
        GameManager.Instance.initializePlayerController();

        // Spawn enemies
        GameManager.Instance.GetComponent<EnemySpawner>().spawnEnemies(enemyType, enemyTier, enemyCount);

        // Pass turn to Player
        GameManager.Instance.turnSide = Characters.Player;

        startNewTurn();
    }

    public void endTurn()
    {
        PlayerPrefsController.SavePlayerInfo();
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
        foreach (var item in cards)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in lines)
        {
            Destroy(item.gameObject);
        }
        GameManager.Instance.turnSide = decideTurnSide(GameManager.Instance.turnSide);
        if (GameManager.Instance.turnSide == Characters.Player)
        {
            GameManager.Instance.playerController.applyNextTurnDeltas();
            GameManager.Instance.playerController.normalizeDamageToEnemyMultipliers();
            CardManager.Instance.CheckDeck();

        }
        startNewTurn();
    }

    public void startNewTurn()
    {
        if (GameManager.Instance.turnSide == Characters.Player)
        {
            JsonController.createCardJsonTempWithPath(Constants.URLConstants.cardTempDatabaseJsonBaseUrl, new CardManager().getAllCards());
            // TODO
            // create enemy intentions
            turnCount += 1;

            GameManager.Instance.playerController.shield = 0;

            GameManager.Instance.GetComponent<CardSpawner>().SpawnerStarter();
            GameManager.Instance.GetComponent<CardSpawner>().spawnOnce = true;


            GameManager.Instance.playerController.playerMana = Constants.PlayerConstants.initialMana;
            EnemyController.Instance.decideEnemyIntention_all();

            //LiarmeterEffects
            if (60 <= GameManager.Instance.transform.GetComponent<LiarMeterConroller>().liarValue)
            {
                LiarmeterEffects.Instance.LiarmeterEffect60("demonicAttack");
            }

            foreach (var item in GameObject.FindGameObjectsWithTag("BuffEffect"))
            {
                Destroy(item.gameObject);
            }

            // GameManager.Instance.playerController.applyStateEffects();
        } else if(GameManager.Instance.turnSide == Characters.Enemy)
        {
            GameManager.Instance.GetComponent<CardSpawner>().HandDiscarder();
            // TODO
            EnemyController.Instance.applyDecidedIntentions_all();
            GameManager.Instance.GetComponent<CardSpawner>().spawnOnce = false;
            int liarValue = GameManager.Instance.transform.GetComponent<LiarMeterConroller>().liarValue;
            if (liarValue <= 30 && 15 < liarValue)
            {
                
                LiarmeterEffects.Instance.LiarmeterEffect70();
            }
            else if (70 <= liarValue && liarValue < 80)
            {
                LiarmeterEffects.Instance.LiarmeterEffect70();
            }
            else if ((GameManager.Instance.transform.GetComponent<LiarMeterConroller>().liarValue <= 15 || 85 <= GameManager.Instance.transform.GetComponent<LiarMeterConroller>().liarValue))
            {
                LiarmeterEffects.Instance.LiarmeterEffect85();
            }
            else
            {
                //LiarmeterEffects.Instance.ResetLiarmeterPenalty();
            }

            Invoke("endTurn", waitTillEndTurn);
            EnemyController.Instance.applyNextTurnDamageMultiplier_all();
            Debug.Log("Enemy Turn");
            // apply enemy effects on enemies
            // wait at least 1.5 secs
        }
    }

    public void endFight()
    {
        PlayerPrefs.SetInt("mapGenerated", 1);
        SceneManager.LoadScene(2);

    }
    
    public void changeLanguage()
    {
        if (GameManager.Instance.gameLanguage == Language.tr)
        {
            PlayerPrefs.SetString("Language", "en");
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        }
        else if (GameManager.Instance.gameLanguage == Language.en)
        {
            PlayerPrefs.SetString("Language", "tr");
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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