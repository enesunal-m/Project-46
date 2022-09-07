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

        foreach (EnemyDatabaseStructure.IEnemyInfoInterface enemy in enemyDatabaseJson.Normal.Tier1)
        {
            EnemyTier tier_ = EnemyTier.Tier1;
            EnemyType type_ = EnemyType.Normal;
            enemy.enemyType = type_;
            enemy.enemyTier = tier_;

            enemyList.Add(enemy);
        }
        foreach (EnemyDatabaseStructure.IEnemyInfoInterface enemy in enemyDatabaseJson.Normal.Tier2)
        {
            EnemyTier tier_ = EnemyTier.Tier2;
            EnemyType type_ = EnemyType.Normal;
            enemy.enemyType = type_;
            enemy.enemyTier = tier_;

            enemyList.Add(enemy);
        }
        foreach (EnemyDatabaseStructure.IEnemyInfoInterface enemy in enemyDatabaseJson.Normal.Tier3)
        {
            EnemyTier tier_ = EnemyTier.Tier3;
            EnemyType type_ = EnemyType.Normal;
            enemy.enemyType = type_;
            enemy.enemyTier = tier_;

            enemyList.Add(enemy);
        }
        foreach (EnemyDatabaseStructure.IEnemyInfoInterface enemy in enemyDatabaseJson.Normal.Tier4)
        {
            EnemyTier tier_ = EnemyTier.Tier4;
            EnemyType type_ = EnemyType.Normal;
            enemy.enemyType = type_;
            enemy.enemyTier = tier_;

            enemyList.Add(enemy);
        }

        foreach (EnemyDatabaseStructure.IEnemyInfoInterface enemy in enemyDatabaseJson.Elite.Tier1)
        {
            EnemyTier tier_ = EnemyTier.Tier1;
            EnemyType type_ = EnemyType.Elite;
            enemy.enemyType = type_;
            enemy.enemyTier = tier_;

            enemyList.Add(enemy);
        }
        foreach (EnemyDatabaseStructure.IEnemyInfoInterface enemy in enemyDatabaseJson.Elite.Tier2)
        {
            EnemyTier tier_ = EnemyTier.Tier2;
            EnemyType type_ = EnemyType.Elite;
            enemy.enemyType = type_;
            enemy.enemyTier = tier_;

            enemyList.Add(enemy);
        }
        foreach (EnemyDatabaseStructure.IEnemyInfoInterface enemy in enemyDatabaseJson.Elite.Tier3)
        {
            EnemyTier tier_ = EnemyTier.Tier3;
            EnemyType type_ = EnemyType.Elite;
            enemy.enemyType = type_;
            enemy.enemyTier = tier_;

            enemyList.Add(enemy);
        }
        foreach (EnemyDatabaseStructure.IEnemyInfoInterface enemy in enemyDatabaseJson.Elite.Tier4)
        {
            EnemyTier tier_ = EnemyTier.Tier4;
            EnemyType type_ = EnemyType.Elite;
            enemy.enemyType = type_;
            enemy.enemyTier = tier_;

            enemyList.Add(enemy);
        }

        foreach (EnemyDatabaseStructure.IEnemyInfoInterface enemy in enemyDatabaseJson.Boss.Tier1)
        {
            EnemyTier tier_ = EnemyTier.Tier1;
            EnemyType type_ = EnemyType.Boss;
            enemy.enemyType = type_;
            enemy.enemyTier = tier_;

            enemyList.Add(enemy);
        }
        foreach (EnemyDatabaseStructure.IEnemyInfoInterface enemy in enemyDatabaseJson.Boss.Tier2)
        {
            EnemyTier tier_ = EnemyTier.Tier2;
            EnemyType type_ = EnemyType.Boss;
            enemy.enemyType = type_;
            enemy.enemyTier = tier_;

            enemyList.Add(enemy);
        }
        foreach (EnemyDatabaseStructure.IEnemyInfoInterface enemy in enemyDatabaseJson.Boss.Tier3)
        {
            EnemyTier tier_ = EnemyTier.Tier3;
            EnemyType type_ = EnemyType.Boss;
            enemy.enemyType = type_;
            enemy.enemyTier = tier_;

            enemyList.Add(enemy);
        }
        foreach (EnemyDatabaseStructure.IEnemyInfoInterface enemy in enemyDatabaseJson.Boss.Tier4)
        {
            EnemyTier tier_ = EnemyTier.Tier4;
            EnemyType type_ = EnemyType.Boss;
            enemy.enemyType = type_;
            enemy.enemyTier = tier_;

            enemyList.Add(enemy);
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
