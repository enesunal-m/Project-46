using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestSiteController : MonoBehaviour 
{
    public bool healthIncreased = false;
    public void Rest()
    {
        if (!healthIncreased)
        {
            PlayerPrefs.SetFloat("playerHealth", PlayerPrefs.GetFloat("playerHealth") * 1.3f);
            SceneManager.LoadScene(3);
        }
        
    }   

    public void UpgradeSelectedCard()
    {
        CardDatabaseStructure.ICardInfoInterface cardInfo = new CardDatabaseStructure.ICardInfoInterface();
        cardInfo.name = cardInfo + "<b>+</b>";
        CardUpgradeFunctions.cardUpgradeFunctionsDictionary[cardInfo.id].run(cardInfo);
    }
}
