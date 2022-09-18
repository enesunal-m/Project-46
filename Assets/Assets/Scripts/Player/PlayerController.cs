using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

/// <summary>
/// Contains information and functions of player character
/// </summary>
public class PlayerController : CharacterBaseClass
{
    public List<StateEffect> stateEffects;

    private static PlayerController instance = null;

    [Header("HealthBar")]
    [SerializeField] TextMeshProUGUI currentHealthText;
    [SerializeField] TextMeshProUGUI maxHealthText;
    [SerializeField] TextMeshProUGUI shieldText;
    [SerializeField] TextMeshProUGUI currentManaText;
    [SerializeField] TextMeshProUGUI maxManaText;
    [Header("AnimatedHealthBar")]
    public float chipSpeed;
    public Image frontHealthBar;
    public Image backHealthBar;
    private float lerpTimer;

    public int coin;

    [SerializeField] float animScaler;
    public int playerMana = Constants.PlayerConstants.initialMana;

    // Start is called before the first frame update
    void Start()
    {
        float lastHealth = PlayerPrefs.GetFloat("playerHealth");
        if (lastHealth <= 0)
        {
            currentHealth = Constants.PlayerConstants.initialFullHealth;
        }else
        {
            currentHealth = lastHealth;
        }

        coin = 0;

        Dictionary<string, float> playerInfoDict = PlayerPrefsController.GetPlayerInfo();
        if (playerInfoDict["health"] == 0)
        {
            playerInfoDict["health"] = Constants.PlayerConstants.initialFullHealth;
        }

        this.fullHealth = Constants.PlayerConstants.initialFullHealth;
        this.currentHealth = playerInfoDict["health"];
        this.shield = Constants.PlayerConstants.initialShield;
        this.strength = Constants.PlayerConstants.initalStrength;
        this.nextTurnDamageMultiplier = 1f;
        this._name = "YonJuuRoku";
        coin = (int)playerInfoDict["coin"];
        ScaleAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > fullHealth)
        {
            currentHealth = fullHealth;
        }
        if (currentHealth <= 0)
        {
            SceneRouter.GoToScene(SceneType.MainMenu);
        }

        //Update Player's Health and Shield Interface
        currentHealthText.text = currentHealth.ToString("0");
        maxHealthText.text = fullHealth.ToString("0");
        shieldText.text = shield.ToString("0");
        currentManaText.text = playerMana.ToString("0");
        maxManaText.text = Constants.PlayerConstants.initialMana.ToString("0");
        if (Input.GetKeyDown(KeyCode.A))
        {
            changeHealth(-10);
        }
        UpdateHealthUI();
    }

    public void ScaleAnimation()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 scaleTo = new Vector3(transform.localScale.x, transform.localScale.y + animScaler, transform.localScale.z);
        Vector3 moveTo = new Vector3(transform.position.x, transform.position.y + animScaler, transform.position.z);
        transform.DOMove(moveTo, 0.7f)
            .SetEase(Ease.OutSine)
            .SetLoops(-1, LoopType.Yoyo);
        transform.DOScale(scaleTo, 0.7f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);


    }
    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;

        float hFraction = healthPercentage / 100;

        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer * chipSpeed;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);

        }
    }
    public static PlayerController Instance { get; 
         private set; }
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

    // self-modifier functions
    public void getDamage(float damage)
    {
        Vector3 moveTo = new Vector3(transform.position.x -0.1f, transform.position.y, transform.position.z);
        transform.DOMove(moveTo, 0.15f)
            .SetEase(Ease.OutSine)
            .SetLoops(2, LoopType.Yoyo);
        float tempShield = shield;
        if (shield > 0)
        {
            shield -= damage;
        }
        if (shield <= 0)
        {
            currentHealth -= damage * GameManager.Instance.enemyDamageMultiplier - tempShield;
            shield = 0;
        }

        if (currentHealth < 0)
            currentHealth = 0;
    }
    public void changeHealth(float healthChange)
    {
        currentHealth += healthChange;
        lerpTimer = 0;
    }
    public void changeShield(float shieldChange)
    {
        shield += shieldChange;
    }

    // buff de-buff functions
    public void changeStrength(float strengthChange)
    {
        strength += strengthChange;
    }

    public void applyNextTurnDeltas()
    {
        currentHealth += nextTurnHealthDelta;
        shield += nextTurnShieldDelta;
        strength += nextTurnStrengthDelta;
        playerMana += nextTurnManaDelta;

        nextTurnHealthDelta = 0;
        nextTurnManaDelta = 0;
        nextTurnShieldDelta = 0;
        nextTurnStrengthDelta = 0;
    }

    public void normalizeNextTurnDeltas()
    {
        nextTurnHealthDelta = 0;
        nextTurnManaDelta = 0;
        nextTurnShieldDelta = 0;
        nextTurnStrengthDelta = 0;
    }
    public void normalizeDamageToEnemyMultipliers()
    {
        GameManager.Instance.enemyDamageMultiplier = GameManager.Instance.enemyDamageMultiplier * nextTurnDamageMultiplier;
    }


    public void applyStateEffects()
    {
        foreach ( (StateEffect stateEffect, int i) in stateEffects.WithIndex())
        {
            bool stopped = stateEffect.run();
            if (stopped)
            {
                stateEffects.RemoveAt(i);
            }
        }
    }
}
