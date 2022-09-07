using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the processes about all enemies spawned
/// </summary>
public class EnemyController : MonoBehaviour
{
    private static EnemyController instance = null;
    public static float nextTurnDamageToPlayerMultiplier = 1f;

    public static EnemyController Instance
    {
        get
        {
            if (instance == null)
                instance = new EnemyController();
            return instance;
        }
    }

    public static List<EnemyDatabaseStructure.IEnemyInfoInterface> initalizeEnemyList(EnemyDatabaseStructure.Root enemyDatabaseJson)
    {
        List<EnemyDatabaseStructure.IEnemyInfoInterface> enemyList = new List<EnemyDatabaseStructure.IEnemyInfoInterface>();

        foreach (var enemyType in enemyDatabaseJson.GetType().GetProperties())
        {
            var enemyType_ = Nullable.GetUnderlyingType(enemyType.PropertyType) ?? enemyType.PropertyType;
            foreach (var enemyTier in enemyType.GetType().GetProperties())
            {
                var enemyTier_ = Nullable.GetUnderlyingType(enemyTier.PropertyType) ?? enemyTier.PropertyType;
            }
        }

        foreach (EnemyDatabaseStructure.IEnemyTierInterface item in enemyDatabaseJson.Normal.Tier1)
        {
            string tier_ = "Tier1";
            string type_ = "Normal";

        }
        foreach (EnemyDatabaseStructure.IEnemyTierInterface item in enemyDatabaseJson.Normal.Tier2)
        {

        }
        foreach (EnemyDatabaseStructure.IEnemyTierInterface item in enemyDatabaseJson.Normal.Tier3)
        {

        }
        foreach (EnemyDatabaseStructure.IEnemyTierInterface item in enemyDatabaseJson.Normal.Tier4)
        {

        }

        foreach (EnemyDatabaseStructure.IEnemyTierInterface item in enemyDatabaseJson.Elite.Tier1)
        {

        }
        foreach (EnemyDatabaseStructure.IEnemyTierInterface item in enemyDatabaseJson.Elite.Tier2)
        {

        }
        foreach (EnemyDatabaseStructure.IEnemyTierInterface item in enemyDatabaseJson.Elite.Tier3)
        {

        }
        foreach (EnemyDatabaseStructure.IEnemyTierInterface item in enemyDatabaseJson.Elite.Tier4)
        {

        }

        foreach (EnemyDatabaseStructure.IEnemyTierInterface item in enemyDatabaseJson.Boss.Tier1)
        {

        }
        foreach (EnemyDatabaseStructure.IEnemyTierInterface item in enemyDatabaseJson.Boss.Tier2)
        {

        }
        foreach (EnemyDatabaseStructure.IEnemyTierInterface item in enemyDatabaseJson.Boss.Tier3)
        {

        }
        foreach (EnemyDatabaseStructure.IEnemyTierInterface item in enemyDatabaseJson.Boss.Tier4)
        {

        }

        return enemyList;
    }

    public void applyDecidedIntentions_all()
    {
        Debug.Log("DEBUG: " + GameManager.Instance.enemyList.Count);
        foreach (GameObject enemy in GameManager.Instance.enemyList)
        {
            enemy.GetComponent<Enemy>().applyDecidedIntention();    
        }
    }

    public void decideEnemyIntention_all()
    {
        foreach (GameObject enemy in GameManager.Instance.enemyList)
        {
            enemy.GetComponent<Enemy>().decideIntention();
        }
    }

    public void applyNextTurnDamageMultiplier_all()
    {
        GameManager.Instance.playerDamageMultiplier = GameManager.Instance.playerDamageMultiplier * nextTurnDamageToPlayerMultiplier;
    }
}
