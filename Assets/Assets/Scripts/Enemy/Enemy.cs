using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

/// <summary>
/// Contains information and functions of enemy character
/// </summary>
public class Enemy : CharacterBaseClass
{
    public string passive = "";

    public List<StateEffect> selfStateEffects;
    public bool normalizeProbabilities = false;
    public TextMeshProUGUI intentionText;

    [Header("Effects")]
    public GameObject attackEffect;
    public GameObject sleepEffect;
    public GameObject buffEffect;
    public GameObject shieldEffect;

    private TurnController turnController;

    [Header("Monster Sounds")]
    [SerializeField] AudioClip[] soundEffectsOfEnemies;
    private bool canMakeSoundAgain = true;

    List<KeyValuePair<EnemyIntention, float>>
        intentionsWithProbability_agressive;
    List<KeyValuePair<EnemyIntention, float>>
        intentionsWithProbability_defensive;
    private EnemyIntention selfIntention;

    public string id;
    [Header("HealthBar")]
    [SerializeField] TextMeshProUGUI currentHealthText;
    [SerializeField] TextMeshProUGUI maxHealthText;
    [SerializeField] TextMeshProUGUI shieldText;
    public float chipSpeed;
    public Image frontHealthBar;
    public Image backHealthBar;
    private float lerpTimer;


    public Enemy()
    {

    }

    public void initializeSelf(EnemyDatabaseStructure.IEnemyInfoInterface enemyInfo)
    {
    // core attributes
        this.shield = enemyInfo.shield;
        this.strength = enemyInfo.strength;

        this._name = enemyInfo.name;

        this.id = enemyInfo.id;
        initializeSoundEffect(enemyInfo.id);
        this.fullHealth = enemyInfo.health;
        this.currentHealth = enemyInfo.health;


        passive = enemyInfo.passive;
    }

    private void Start()
    {
        Debug.Log("INFOO: " + id);
        turnController = GameManager.Instance.transform.GetComponent<TurnController>();
        initializeIntentionProbabilities(
               80, 15, 2, 3,
                80, 10, 3, 7);
    }
    private void initializeSoundEffect(string id)
    {
        
        switch (id)
        {

            case "mayex":
                this.GetComponent<AudioSource>().clip = soundEffectsOfEnemies[0];
                break;
            case "maypo":
                this.GetComponent<AudioSource>().clip = soundEffectsOfEnemies[1];
                break;
            case "mayrotta":
                this.GetComponent<AudioSource>().clip = soundEffectsOfEnemies[2];
                break;
            case "mayamma":
                this.GetComponent<AudioSource>().clip = soundEffectsOfEnemies[3];
                break;
            case "nuckelavee":
                this.GetComponent<AudioSource>().clip = soundEffectsOfEnemies[4];
                break;
            default:
                break;
        }
    }
    private void Update()
    {
        //Play monster sounds
        if (canMakeSoundAgain)
        {
            StartCoroutine(playSound());

        }

        //Update Enemy's Health and Shield Interface
        currentHealthText.text = currentHealth.ToString("0");
        maxHealthText.text = fullHealth.ToString("0");
        shieldText.text = shield.ToString("0");
        Debug.Log("INFOO: " + this.id);
        intentionText.text = selfIntention.ToString();
        UpdateHealthUI();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Invoke("die", GameObject.FindGameObjectWithTag("AttackEffect").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
        
    }
    private IEnumerator playSound()
    {
        canMakeSoundAgain = false;
        int randTime = Random.Range(7, 17);
        yield return new WaitForSeconds(randTime);
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(this.GetComponent<AudioSource>().clip.length + 1);
        canMakeSoundAgain = true;

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

    public void attackToPlayer(float damage)
    {
        GameManager.Instance.playerController.getDamage(damage);
        var tempEffect = Instantiate(attackEffect);
        tempEffect.transform.position = PlayerController.Instance.transform.position;
        turnController.waitTillEndTurn = tempEffect.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Vector3 moveTo = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        transform.DOMove(moveTo, 0.2f)
            .SetEase(Ease.OutSine);
        if (normalizeProbabilities)
        {
            initializeIntentionProbabilities(
                80, 15, 2, 3,
                80, 10, 3, 7);
        }
    }
    public void getDamage(float damage)
    {
        Vector3 moveTo = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        transform.DOMove(moveTo, 0.2f)
            .SetEase(Ease.OutSine);
        float tempShield = shield;
        if (shield > 0)
        {
            shield -= damage;

        }
        if (shield <= 0)
        {
            currentHealth -= damage * GameManager.Instance.playerDamageMultiplier - tempShield;
            shield = 0;
        }
    }
    public void sleep()
    {
        var tempEffect = Instantiate(sleepEffect);
        tempEffect.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y + 1.5f, this.transform.position.z);
        turnController.waitTillEndTurn = tempEffect.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
    }
    public void buff()
    {
        var tempEffect = Instantiate(buffEffect);
        tempEffect.transform.position = new Vector3 (this.transform.position.x +1, this.transform.position.y + 1.5f, this.transform.position.z);
        turnController.waitTillEndTurn = tempEffect.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length / 2.5f;
    }
    public void getTrueDamage(float damage)
    {
        currentHealth -= damage * GameManager.Instance.playerDamageMultiplier;
    }
    public void changeHealth(float healthChange)
    {
        currentHealth += healthChange;
        lerpTimer = 0;
    }
    public void changeShield(float shieldChange)
    {
        var tempEffect = Instantiate(shieldEffect);
        tempEffect.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y + 1.5f, this.transform.position.z);
        turnController.waitTillEndTurn = tempEffect.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        shield += shieldChange;
    }
    public void changeStrength(float strengthChange)
    {
        strength += strengthChange;
    }
    public void die()
    {
        //die
        Destroy(gameObject);
        GameManager.Instance.GoToShopScene();
    }
    /// <summary>
    /// Make enemy to decide intention every time when turn comes to player
    /// </summary>
    public void decideIntention()
    {
        if (intentionsWithProbability_agressive == null)
        {
                initializeIntentionProbabilities(
                80, 15, 2, 3,
                80, 10, 3, 7);
        }
        if (GameManager.Instance.playerController.healthPercentage <= healthPercentage)
        {
            // agressive
            selfIntention = HelperFunctions.selectElementWithProbability(intentionsWithProbability_agressive);
        }
        else if (GameManager.Instance.playerController.healthPercentage > healthPercentage)
        {
            // defensive
            selfIntention = HelperFunctions.selectElementWithProbability(intentionsWithProbability_defensive);
            
        }
    }

    /// <summary>
    /// Apply the last decided enemy intention
    /// </summary>
    public void applyDecidedIntention()
    {
        
        switch (selfIntention)
        {
            case EnemyIntention.None:
                Debug.Log("NANANAANA");
                break;
            case EnemyIntention.Guard:
                changeShield(5);
                break;
            case EnemyIntention.Attack:
                attackToPlayer(this.strength);
                break;
            case EnemyIntention.Sleep:

                // TODO
                // run the sleep animation and pass to next turn
                break;
            case EnemyIntention.Buff:
                buff();
                // TODO
                // Apply buff
                break;
            default:
                break;
        }
        Debug.Log(selfIntention);
    }

    public void applyStateEffects()
    {
        foreach ((StateEffect selfStateEffect, int i) in selfStateEffects.WithIndex())
        {
            bool stopped = selfStateEffect.run();
            if (stopped)
            {
                selfStateEffects.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// Construct intention probablities KeyValuePair lists
    /// </summary>
    public void initializeIntentionProbabilities(
        float attack_defensiveProbability,
        float guard_defensiveProbability,
        float sleep_defensiveProbability,
        float buff_defensiveProbability,

        float guard_agressiveProbability,
        float attack_agressiveProbability,
        float sleep_agressiveProbability,
        float buff_agressiveProbability
        )
    {
        intentionsWithProbability_agressive = new List<KeyValuePair<EnemyIntention, float>>()
        {
            new KeyValuePair<EnemyIntention, float>(EnemyIntention.Attack, attack_agressiveProbability),
            new KeyValuePair<EnemyIntention, float>(EnemyIntention.Guard, guard_agressiveProbability),
            new KeyValuePair<EnemyIntention, float>(EnemyIntention.Sleep, sleep_agressiveProbability),
            new KeyValuePair<EnemyIntention, float>(EnemyIntention.Buff, buff_agressiveProbability),
        };
        intentionsWithProbability_defensive = new List<KeyValuePair<EnemyIntention, float>>()
        {
            new KeyValuePair<EnemyIntention, float>(EnemyIntention.Guard, guard_defensiveProbability),
            new KeyValuePair<EnemyIntention, float>(EnemyIntention.Attack, attack_defensiveProbability),
            new KeyValuePair<EnemyIntention, float>(EnemyIntention.Sleep, sleep_defensiveProbability),
            new KeyValuePair<EnemyIntention, float>(EnemyIntention.Buff, buff_defensiveProbability),
        };
    }
}
