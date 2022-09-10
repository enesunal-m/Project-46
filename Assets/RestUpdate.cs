using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RestFunc : MonoBehaviour

    
{
    [SerializeField]PlayerController playerController;

    
    void Rest()
    {
        playerController.changeHealth(30);
        if (playerController.currentHealth > 100)
        {
            playerController.currentHealth = 100;
        }
     
    }   
    



}
