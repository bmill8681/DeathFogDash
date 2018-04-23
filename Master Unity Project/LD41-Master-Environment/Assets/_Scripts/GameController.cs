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
    bool paused = false;
    public int blocks_travelled { get { return Mathf.FloorToInt(player.position.x / 44f); } }
    public float total_distance_travelled { get { return player.position.x; } }
    public float distance_to_deathwall { get { return player.position.x - Proceed.instance.deathray.position.x; } }


    public uint level = 3;

    private void Awake()
    {
        if (GameController.instance == null)
            GameController.instance = this;
        else if (GameController.instance != this)
            Destroy(this);
    }


	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
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
