using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterBaseClass
{
    private PlayerController playerController;
    private void Update()
    {
        if (playerController.healthPercentage < this.healthPercentage)
        {
            //agresif
            int dice100 = UnityEngine.Random.Range(1, 101);
            if (dice100 <= 60)
            {
                //Attack
            }
            else if (60 < dice100 && dice100 <= 80)
            {
                //Guard
            }
            else if (80 < dice100 && dice100 <= 90)
            {
                //Sleep
            }
            else if (90 < dice100 && dice100 <= 100)
            {
                //Buff
            }
        }
        else if (playerController.healthPercentage > this.healthPercentage)
        {
            int dice100 = UnityEngine.Random.Range(1, 101);
            if (dice100 <= 60)
            {
                //Guard
            }
            else if (60 < dice100 && dice100 <= 80)
            {
                //Attack
            }
            else if (80 < dice100 && dice100 <= 90)
            {
                //Sleep
            }
            else if (90 < dice100 && dice100 <= 100)
            {
                //Buff
            }
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
    }
}
