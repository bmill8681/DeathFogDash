using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {
    public GameObject instructionsMenu;
    public GameObject creditsMenu;



    public void enableInstructionsMenu()
    {
        if (instructionsMenu.activeSelf)
            instructionsMenu.SetActive(false);
        else if (!instructionsMenu.activeSelf)
        {
            closeMenu();
            instructionsMenu.SetActive(true);
        }
    }
    public void enableCreditsMenu()
    {
        if (creditsMenu.activeSelf)
            creditsMenu.SetActive(false);
        else if (!creditsMenu.activeSelf)
        {
            closeMenu();
            creditsMenu.SetActive(true);
        }
    }
    private void closeMenu()
    {
        if(creditsMenu.activeSelf)
        {
            creditsMenu.SetActive(false);
        }
        else if (instructionsMenu.activeSelf)
        {
            instructionsMenu.SetActive(false);
        }
    }
    public void exitGame()
    {
        saveGameData();
        Application.Quit();
        Debug.Log("I QUIT");
    }

    private void saveGameData()
    {
        //Replace this with code to save settings and high score data
    }
}
