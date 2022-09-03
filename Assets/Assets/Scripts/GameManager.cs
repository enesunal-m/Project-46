using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Turn System
    public Characters turnSide = 0; // 0 --> Player, 1 --> Enemy

    // global variables for player and enemy characters
    public float playerDamageMultiplier = Constants.DamageConstants.initalPlayerMultiplier;
    public float enemyDamageMultiplier = Constants.DamageConstants.initalEnemyMultiplier;
    public int playerMana = Constants.PlayerConstants.initialMana;

    void Update()
    {
        
    }
}
