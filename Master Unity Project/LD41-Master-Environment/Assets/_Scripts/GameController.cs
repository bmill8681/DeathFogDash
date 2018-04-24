using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PointStyle { PlacedLetterOnly, EntireWord, Everything }

public class GameController : MonoBehaviour {

    public static GameController instance = null;

    public Material[] housecolors;
    public GameObject ChasmPrefab;
    public GameObject SlabPrefab;
    public GameObject WallPrefab;
    public Transform player;
    public Transform spawn;
    public GameObject PauseMenu;
    public GameObject DeathPanel;
    bool dead = false;
    

    public bool paused = false;
    public int blocks_travelled { get { return Mathf.FloorToInt(total_distance_travelled / 44f); } }
    public int total_distance_travelled { get { return Mathf.FloorToInt(Mathf.Clamp(player.position.x - player_start_pos, 0f, float.MaxValue )); } }
    public float distance_to_deathwall { get { return player.position.x - Proceed.instance.deathray.position.x - 24.5f; } }
    public float block_multiplier { get { return Mathf.FloorToInt(raw_mult * 4f) / 4f; } } // raw mult but in increments of .25
    public float raw_mult { get { return Mathf.Clamp(Mathf.Pow(1.25f, blocks_travelled), 1f, 100f); } } // multiplier based on blocks travelled in x direction (how long the player has continued forward)

    public float player_start_pos = 0;
    public int total_points = 0;
    public PointStyle point_style = PointStyle.EntireWord;


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

        player.position = spawn.position;
        UnPauseGame();
    }

    private void Start()
    {
        player_start_pos = player.position.x;

    }

    void TestonStart()
    {
        Debug.Log("blocks_travelled: " + blocks_travelled);
        Debug.Log("total_distance_travelled: " + total_distance_travelled);
        Debug.Log("distance_to_deathwall: " + distance_to_deathwall);
        Debug.Log("block_multiplier: " + block_multiplier);
        Debug.Log("raw mult: " + raw_mult);
        player.position += Vector3.right * 30f;

        Debug.Log("blocks_travelled: " + blocks_travelled);
        Debug.Log("total_distance_travelled: " + total_distance_travelled);
        Debug.Log("distance_to_deathwall: " + distance_to_deathwall);
        Debug.Log("block_multiplier: " + block_multiplier);
        Debug.Log("raw mult: " + raw_mult);
        player.position += Vector3.right * 150f;

        Debug.Log("blocks_travelled: " + blocks_travelled);
        Debug.Log("total_distance_travelled: " + total_distance_travelled);
        Debug.Log("distance_to_deathwall: " + distance_to_deathwall);
        Debug.Log("block_multiplier: " + block_multiplier);
        Debug.Log("raw mult: " + raw_mult);
        player.position += Vector3.right * 300f;
        Debug.Log("blocks_travelled: " + blocks_travelled);
        Debug.Log("total_distance_travelled: " + total_distance_travelled);
        Debug.Log("distance_to_deathwall: " + distance_to_deathwall);
        Debug.Log("block_multiplier: " + block_multiplier);
        Debug.Log("raw mult: " + raw_mult);
    }

    public void KillPlayer(GameObject g_o)
    {
        if(g_o == player.gameObject)
        {
            dead = true;
            UnPauseGame();
            player.GetComponent<Rigidbody>().isKinematic = true;
            player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            DeathPanel.SetActive(true);
            StartCoroutine(Death());
        }
        else
        {
            Debug.LogError("Bad KillPlayer Call, collided with object that is not player");
        }
    }

    IEnumerator Death()
    {
        while (true)
        {
            player.transform.position += Vector3.up * 0.01f;
            yield return null;
        }

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
        if (!paused && !dead)
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
