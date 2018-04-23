using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Menu_Script : MonoBehaviour {
    public GameObject camPanel;
    public GameObject audioPanel;
    public GameObject playerPanel;

    public Slider minimapSlider;
    public Slider masterVol;
    public Slider musicVol;
    public Slider sfxVol;
    public Slider skinSelector;
    
    public SkinnedMeshRenderer playerSkinRend;
    public SkinnedMeshRenderer[] pSkins = new SkinnedMeshRenderer[3];


    public void enableCamSettings()
    {
        if (camPanel.activeSelf)
            camPanel.SetActive(false);
        else if (!camPanel.activeSelf)
        {
            closeAllMenus();
            camPanel.SetActive(true);
        }
    }

    public void enableAudioSettings()
    {
        if (audioPanel.activeSelf)
            audioPanel.SetActive(false);
        else if (!audioPanel.activeSelf)
        {
            closeAllMenus();
            audioPanel.SetActive(true);
        }
    }

    public void enablePlayerSettings()
    {
        if (playerPanel.activeSelf)
            playerPanel.SetActive(false);
        else if (!playerPanel.activeSelf)
        {
            closeAllMenus();
            playerPanel.SetActive(true);
        }
    }

    public void resumeGame()
    {
        // Add script here to resume the game
        closeAllMenus();
        this.gameObject.SetActive(false);
    }

    public void closeAllMenus()
    {
        for(int x = 0; x < 3; x++)
        {
            switch (x)
            {
                case 0:
                    camPanel.SetActive(false);
                    break;

                case 1:
                    audioPanel.SetActive(false);
                    break;

                case 2:
                    playerPanel.SetActive(false);
                    break;

                default:
                    Debug.Log("Error: Line 39, Pause_Menu_Script");
                    break;
            }
        }
    }

    public void changePlayerSkin()
    {
        SkinnedMeshRenderer newSkin;
        float skinNum = skinSelector.value;
        if (skinNum == 1)
        {
            newSkin = pSkins[0];
            playerSkinRend.sharedMesh = newSkin.sharedMesh;

        }
        else if (skinNum == 2)
        {
            newSkin = pSkins[1];
            playerSkinRend.sharedMesh = newSkin.sharedMesh;
        }
        else if (skinNum == 3)
        {
            newSkin = pSkins[2];
            playerSkinRend.sharedMesh = newSkin.sharedMesh;
        }

    }

        private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log(playerSkinRend.ToString());
        }
    }
    public void exitToMenu()
    {
        // Put Script Here to exit to main menu
    }

    public void disableMenu(GameObject menu)
    {
        menu.SetActive(false);
    }
}
