using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Menu_Script : MonoBehaviour {
    [SerializeField]
    private float masterVolume = 0.5f;
    [SerializeField]
    private float sfxVolume = 0.5f;
    [SerializeField]
    private float musicVolume = 0.5f;
    [SerializeField]
    private float mapZoom = 7.0f;

    public GameObject camPanel;
    public GameObject audioPanel;
    public GameObject playerPanel;
    public GameObject deathPanel;
    public GameObject minimap;

    public Slider minimapSlider;
    public Slider masterVolSlider;
    public Slider musicVolSlider;
    public Slider sfxVolSlider;
    public Slider skinSelector;
    public Slider zoomSlider;
    public Toggle mapToggle;
    public Camera mapCam;
    
    public SkinnedMeshRenderer playerSkinRend;
    public SkinnedMeshRenderer[] pSkins = new SkinnedMeshRenderer[3];

    public AudioManagerScript audManager;

    private void Awake()
    {
        masterVolSlider.value = masterVolume;
        musicVolSlider.value = musicVolume;
        sfxVolSlider.value = sfxVolume;
    }

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

    public void enableDeathPanel()
    {
        deathPanel.SetActive(true);
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

    public void adjustMusicVolume()
    {
        if (musicVolume != musicVolSlider.value)
        {
            musicVolume = musicVolSlider.value * masterVolume;
            audManager.setMusicVolume(musicVolume);
        }
    }
    public void adjustSFXVolume()
    {
        if (sfxVolume != sfxVolSlider.value)
        {
            sfxVolume = sfxVolSlider.value * masterVolume;
            audManager.setSFXVolume(sfxVolume);
        }
    }
    public void adjustMasterVol()
    {
        if(masterVolume != masterVolSlider.value)
        {
            masterVolume = masterVolSlider.value;
            audManager.setMusicVolume(musicVolume * masterVolume);
            audManager.setSFXVolume(sfxVolume * masterVolume);
        }
    }
    public void adjustMapZoom()
    {
        if(mapZoom != zoomSlider.value)
        {
            mapZoom = zoomSlider.value;
            mapCam.orthographicSize = mapZoom;
        }
    }

    public void exitToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }

    public void disableMenu(GameObject menu)
    {
        menu.SetActive(false);
    }

    public void toggleMinimap()
    {
        if(mapToggle.isOn)
        {
            minimap.SetActive(true);
            adjustMapZoom();
        }
        else if (!mapToggle.isOn)
        {
            minimap.SetActive(false);
        }
    }
}
