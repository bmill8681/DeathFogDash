using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {

    public static GameController instance = null;

    public Material[] housecolors;
    public GameObject ChasmPrefab;
    public GameObject SlabPrefab;
    public GameObject WallPrefab;
    public Transform player;
    public GameObject PauseMenu;
    public bool paused = false;
    public int blocks_travelled { get { return Mathf.FloorToInt(player.position.x / 44f); } }
    public float total_distance_travelled { get { return player.position.x; } }
    public float distance_to_deathwall { get { return player.position.x - Proceed.instance.deathray.position.x; } }

    bool ThirdPersonOn = false;
    public GameObject top_down_Camera;
    public GameObject third_person_Camera;
    public GameObject MiniMap;
    public GameObject MiniMapCam;
    public UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl tpcontroller;

    public uint level = 3;

    private void Awake()
    {
        if (GameController.instance == null)
            GameController.instance = this;
        else if (GameController.instance != this)
            Destroy(this);
    }

    public void ToggleCameraStyle()
    {
        if (ThirdPersonOn)
        {
            ThirdPersonOn = false;

            top_down_Camera.SetActive(true);
            top_down_Camera.tag = "MainCamera";
            tpcontroller.m_Cam = top_down_Camera.transform;

            third_person_Camera.SetActive(false);
            third_person_Camera.tag = "Untagged";
            MiniMap.SetActive(false);
            MiniMapCam.SetActive(false);
        }
        else
        {
            ThirdPersonOn = true;

            third_person_Camera.SetActive(true);
            third_person_Camera.tag = "MainCamera";
            tpcontroller.m_Cam = third_person_Camera.transform;
            MiniMap.SetActive(true);
            MiniMapCam.SetActive(true);

            top_down_Camera.SetActive(false);
            top_down_Camera.tag = "Untagged";
        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        if (!paused && Input.GetKeyDown(KeyCode.T)) { ToggleCameraStyle(); }
	}

    public void PauseGame()
    {
        if (!paused)
        {
            paused = true;
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        else { UnPauseGame(); }
    }

    public void UnPauseGame()
    {
        paused = false;
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }

}
