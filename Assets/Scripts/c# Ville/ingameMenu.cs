using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingameMenu : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject quitPanel;
    public GameObject settingsPanel;
    public GameObject ingameMenuPanel;
    void Start()
    {
        quitPanel.SetActive(false); //quit-panelen är avstängd i början av scenen - Ville
        creditsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        ingameMenuPanel.SetActive(false);
    }

    public void ReturnToGame()
    {
        ingameMenuPanel.SetActive(false);
    }
    public void Credits() // Öppnar credits - Ville
    {
        creditsPanel.SetActive(true);
    }

    public void CreditsBack() // Döljer credits igen - Ville
    {
        creditsPanel.SetActive(false);
    }

    public void Settings() // Öppnar settings - Ville
    {
        settingsPanel.SetActive(true);
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

    public void Quit() // 
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ingameMenuPanel.SetActive(true);
        }
    }
}
