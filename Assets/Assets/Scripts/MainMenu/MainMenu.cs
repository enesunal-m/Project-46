using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject enArrow;
    [SerializeField] private GameObject trArrow;

    private void Start()
    {
        if (PlayerPrefs.GetString("Language")== "tr")
        {
            LocalizationSettings.SelectedLocale = Locale.CreateLocale("tr-TR");
            trArrow.SetActive(true);
            enArrow.SetActive(false);
        }
        else
        {
            LocalizationSettings.SelectedLocale = Locale.CreateLocale("en");
            trArrow.SetActive(false);
            enArrow.SetActive(true);
        }

        PlayerPrefs.SetInt("level", 0);
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("notStartOfRun", 0);
        SceneManager.LoadScene(2);
    }
    
    public void ExitGame() // quit function
    {
        Application.Quit();
    }

    public void Credits() // quit function
    {
        SceneManager.LoadScene(4);
    }
}
