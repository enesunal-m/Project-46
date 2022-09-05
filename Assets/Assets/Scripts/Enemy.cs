using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains information and functions of enemy character
/// </summary>
public class Enemy : CharacterBaseClass
{
    private PlayerController playerController;

    public List<StateEffect> selfStateEffects;
    public bool normalizeProbabilities = false;

    List<KeyValuePair<EnemyIntention, float>>
        intentionsWithProbability_agressive;
    List<KeyValuePair<EnemyIntention, float>>
        intentionsWithProbability_defensive;

    private EnemyIntention selfIntention = EnemyIntention.None;

    private void Start()
    {
        currentHealth = fullHealth;
        initializeIntentionProbabilities(
               60, 20, 10, 10,
               60, 20, 10, 10);
    }
    private void Update()
    {
    }

    public void attackToPlayer(float damage)
    {
        playerController.getDamage(damage);
        if (normalizeProbabilities)
        {
            initializeIntentionProbabilities(
                60, 20, 10, 10,
                60, 20, 10, 10);
        }
    }
    public void getDamage(float damage)
    {
        currentHealth -= damage - shield;
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
        if (playerController.healthPercentage <= healthPercentage)
        {
            // agressive
            selfIntention = HelperFunctions.selectElementWithProbability(intentionsWithProbability_agressive);
        }
        else if (playerController.healthPercentage > healthPercentage)
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
                break;
            case EnemyIntention.Guard:
                changeShield(5);
                break;
            case EnemyIntention.Attack:
                attackToPlayer(10);
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
            new KeyValuePair<EnemyIntention, float>(EnemyIntention.Guard, guard_agressiveProbability),
            new KeyValuePair<EnemyIntention, float>(EnemyIntention.Attack, attack_defensiveProbability),
            new KeyValuePair<EnemyIntention, float>(EnemyIntention.Sleep, sleep_defensiveProbability),
            new KeyValuePair<EnemyIntention, float>(EnemyIntention.Buff, buff_defensiveProbability),
        };
    }
}
