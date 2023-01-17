using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //super simpelt skript som kopplar alla knappar och paneler till menyn - Ville

    
    public GameObject creditsPanel;
    public GameObject quitPanel;
    public GameObject settingsPanel;
    private void Start()
    {
        quitPanel.SetActive(false); //quit-panelen är avstängd i början av scenen - Ville
        creditsPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    public void Play() // Öppnar spelscenen - Ville
    {
        SceneManager.LoadScene(1);
    }
    public void Credits() // Öppnar credits - Ville
    {
        creditsPanel.SetActive(true);
    }

    public void Settings() // Öppnar settings - Ville
    {
        settingsPanel.SetActive(true);
    }

    public void CreditsBack() // Döljer credits igen - Ville
    {
        creditsPanel.SetActive(false);
    }

    public void SettingsBack() // Döljer settings igen - Ville
    {
        settingsPanel.SetActive(false);
    }

    public void QuitCheck()   // visar en panel som frågar om du vill avsluta - Ville
    {
        quitPanel.SetActive(true);
    }

    public void QuitBack()  // Går tillbaka till menyn från quit-panelen - Ville
    {
        quitPanel.SetActive(false);
    }

    public void Quit() // Öppnar medverkarscenen - Ville
    {
        Application.Quit();
    }


}
