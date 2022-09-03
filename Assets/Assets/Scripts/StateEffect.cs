using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateEffect 
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // function to use in buff and debuffs
    private void changeDamagePercentageForPlayer(float multiplier)
    {
        gameManager.playerDamageMultiplier = gameManager.playerDamageMultiplier * multiplier;
    }

    // buffs

    // debuffs
    public void getTwiceDamage()
    {
        changeDamagePercentageForPlayer(2f);
    }
}
