using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

/// <summary>
/// Handles processes about spawning enemies on game field
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private void Start()
    {
        Lists.EnemyLists.initEnemy(enemy);
    }
    public void spawnEnemies(EnemyType enemyType, EnemyTier enemyTier, int enemyCount = 3)
    {
        // get enemy list according to the given enemy type and enemy tier
        // structure: Lists.EnemyLists.enemyDictionary[enemyType][enemyTier]
        // Lists.EnemyLists.enemyDictionary[enemyType][enemyTier];
        List<EnemyDatabaseStructure.IEnemyInfoInterface> enemyList = GameManager.Instance.enemyDataList.Where(data => data.enemyTier == enemyTier && data.enemyType == enemyType).ToList();

        // get enemyCount number of random enemy from enemyList
        List<EnemyDatabaseStructure.IEnemyInfoInterface> randomEnemyList = enemyList.TakeRandom(enemyCount).ToList();
        

        // generate enemy locations starting from base enemy location: Constants.LocationConstants.enemyBaseLocation
        List<Vector3> enemyLocations = generateEnemyLocations(enemyCount);

        foreach ((EnemyDatabaseStructure.IEnemyInfoInterface enemyInfo, int i) in randomEnemyList.WithIndex())
        {
            GameObject enemy_ = enemy;
            enemy_.GetComponent<Enemy>().initializeSelf(enemyInfo);
            Transform spriteChildOfEnemy = enemy_.gameObject.transform.GetChild(0);
            spriteChildOfEnemy.GetComponent<SpriteRenderer>().sprite = DrawEnemyImage(enemyType, enemyTier, enemyInfo);
            Animator anim = enemy_.GetComponent<Animator>();
            switch (enemyTier)
            {
                case EnemyTier.Tier1:
                    break;
                case EnemyTier.Tier2:
                    break;
                case EnemyTier.Tier3:
                    break;
                case EnemyTier.Tier4:
                    break;
                default:
                    break;
            } // BURASI YAZILACAK
            GameObject instantiatedEnemy = Instantiate(enemy_, enemyLocations[i], Quaternion.identity);
            GameManager.Instance.enemyList.Add(instantiatedEnemy);
        }
    }

    private Sprite DrawEnemyImage(EnemyType enemyType, EnemyTier enemyTier, EnemyDatabaseStructure.IEnemyInfoInterface enemyInfo)
    {
        Debug.Log(enemyInfo.id);
        Debug.Log(enemyType);
        Debug.Log(enemyTier);
        string url = String.Format(Constants.URLConstants.enemyImages, enemyType, enemyTier, enemyInfo.id);
        return HelperFunctions.ImageFromUrl(url);
    }

    public List<Vector3> generateEnemyLocations(int enemyCount)
    {
        Vector3 baseEnemyLocation = Constants.LocationConstants.enemyBaseLocation;
        List<Vector3> enemyLocationList = new List<Vector3>();

        enemyLocationList.Add(baseEnemyLocation);

        // Pattern: 10px up, 10px right for first 4 enemies
        // Pattern2: 10px up, 10px left for first 4 enemies

        // generate enemyCount number of locations
        for (int i = 0; i < enemyCount - 1; i++)
        {
            switch (i)
            {
                // if enemyCount is equal to 4 or less than 4
                case <3:
                    enemyLocationList.Add(enemyLocationList.Last() + Constants.LocationConstants.rightUpDistanceVector);
                    break;
                // if enemyCount is equal to 7 or in between 5-7
                case < 6:
                    enemyLocationList.Add(enemyLocationList.Last() + Constants.LocationConstants.leftUpDistanceVector);
                    break;
                default:
                    break;
            }
        }

        return enemyLocationList;
    }
}
