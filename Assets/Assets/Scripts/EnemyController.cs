using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the processes about all enemies spawned
/// </summary>
public class EnemyController : CharacterBaseClass
{
    private static EnemyController instance = null;

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
        foreach (GameObject enemy in GameManager.Instance.enemyList)
        {
            enemy.GetComponent<Enemy>().applyDecidedIntention();    
        }
    }

    public void decideEnemyIntention_all()
    {
        Debug.Log(GameManager.Instance.enemyList == null);
        int i = 0;
        foreach (GameObject enemy in GameManager.Instance.enemyList)
        {
            Debug.Log("lista" + enemy + " " + i);
            i++;
            enemy.GetComponent<Enemy>().decideIntention();
        }
    }
}
