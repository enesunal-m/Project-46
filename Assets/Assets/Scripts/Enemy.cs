using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Contains information and functions of enemy character
/// </summary>
public class Enemy : CharacterBaseClass
{

    public List<StateEffect> selfStateEffects;
    public bool normalizeProbabilities = false;
    public TextMeshProUGUI intentionText;

    List<KeyValuePair<EnemyIntention, float>>
        intentionsWithProbability_agressive;
    List<KeyValuePair<EnemyIntention, float>>
        intentionsWithProbability_defensive;

    private EnemyIntention selfIntention;

    [SerializeField] TextMeshProUGUI currentHealthText;
    [SerializeField] TextMeshProUGUI maxHealthText;
    [SerializeField] TextMeshProUGUI shieldText;
    [SerializeField] Slider slider;

    public Enemy()
    {

    }

    private void Start()
    {
        initializeIntentionProbabilities(
               30, 50, 10, 10,
                80, 10, 3, 7);
    }
    private void Update()
    {
        //Update Enemy's Health and Shield Interface
        currentHealthText.text = currentHealth.ToString("0");
        maxHealthText.text = fullHealth.ToString("0");
        shieldText.text = shield.ToString("0");
        slider.maxValue = fullHealth;
        slider.value = currentHealth;

        intentionText.text = selfIntention.ToString();
    }

    public void attackToPlayer(float damage)
    {
        GameManager.Instance.playerController.getDamage(damage);
        if (normalizeProbabilities)
        {
            initializeIntentionProbabilities(
                30, 50, 10, 10,
                80, 10, 3, 7);
        }
    }
    public void getDamage(float damage)
    {
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
    public void changeHealth(float healthChange)
    {
        currentHealth += healthChange;
    }
    public void changeShield(float shieldChange)
    {
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
    }

    /// <summary>
    /// Make enemy to decide intention every time when turn comes to player
    /// </summary>
    public void decideIntention()
    {
        if (intentionsWithProbability_agressive == null)
        {
                initializeIntentionProbabilities(
           30, 50, 10, 10,
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
