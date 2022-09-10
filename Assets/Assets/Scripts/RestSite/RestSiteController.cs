using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestSiteController : MonoBehaviour 
{   
    public void Rest()
    {
        PlayerPrefs.SetFloat("playerHealth", PlayerPrefs.GetFloat("playerHealth") * 1.3f);
        gameObject.GetComponent<Button>().interactable = false;

        SceneManager.LoadScene(1);
    }   

    public void UpgradeSelectedCard()
    {
        CardDatabaseStructure.ICardInfoInterface cardInfo = new CardDatabaseStructure.ICardInfoInterface();
        cardInfo.name = cardInfo + "<b>+</b>";
        CardUpgradeFunctions.cardUpgradeFunctionsDictionary[cardInfo.id].run(cardInfo);
    }
}
