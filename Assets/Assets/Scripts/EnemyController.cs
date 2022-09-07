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
        int i = 0;

        foreach (GameObject enemy in GameManager.Instance.enemyList)
        {
            i++;
            enemy.GetComponent<Enemy>().decideIntention();
        }
    }

    public void applyNextTurnDamageMultiplier_all()
    {
        GameManager.Instance.playerDamageMultiplier = GameManager.Instance.playerDamageMultiplier * nextTurnDamageToPlayerMultiplier;
    }
}
