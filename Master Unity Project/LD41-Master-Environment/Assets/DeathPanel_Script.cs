using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathPanel_Script : MonoBehaviour
{

    private float timer;
    public GameObject[] stats = new GameObject[4];

    public Image skull;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI blocksText;
    public TextMeshProUGUI distText;
    public TextMeshProUGUI msgText;

    private float fallSpeed = 1.5f;
    private float minHeight = -15.0f;
    private float startStats = 200.0f;
    private float timerIncrement = 0.5f;
    private float fallModifier = 2.0f;

    private int curStat;
    private bool doneFalling;
    private bool displayStats;

    private void Awake()
    {
        // Update these
        int scoreNum = GameController.instance.total_points;
        int blockNum = GameController.instance.blocks_travelled;
        int distNum = GameController.instance.total_distance_travelled;
        int msg1 = 10;
        int msg2 = 100;
        int msg3 = 1000;
        int msg4 = 69000;
        int msg5 = 420000;

        scoreText.text = scoreNum.ToString();
        blocksText.text = blockNum.ToString();
        distText.text = distNum.ToString();

        if (scoreNum < msg1)
        {
            msgText.text = "Better get a dictionary";
        }
        else if (scoreNum >= msg1 && scoreNum < msg2)
        {
            msgText.text = "Spell Check Jr";
        }
        else if (scoreNum >= msg2 && scoreNum < msg3)
        {
            msgText.text = "Wordy Wizard";
        }
        else if (scoreNum >= msg3 && scoreNum < msg4)
        {
            msgText.text = "Master of Diction!";
        }
        else if (scoreNum >= msg4)
        {
            msgText.text = "You broke our game.";
        }
        else if (scoreNum >= msg5)
        {
            msgText.text = "Bruuuuhhhh...";
        }
    }

    void Start()
    {
        doneFalling = false;
        displayStats = false;
        timer = 0.0f;
        curStat = 0;
        disableStats();
    }

    void Update()
    {
        if (true && !doneFalling)
        {
            skull.rectTransform.localPosition = new Vector3(skull.rectTransform.localPosition.x, skull.rectTransform.localPosition.y - (fallSpeed * fallModifier), skull.rectTransform.localPosition.z);
            if (skull.rectTransform.position.y <= startStats)
            {
                displayStats = true;
            }
            if (skull.rectTransform.position.y <= minHeight)
            {
                doneFalling = true;
                skull.rectTransform.localPosition = new Vector3(skull.rectTransform.localPosition.x, 500.0f, skull.rectTransform.localPosition.z);
            }
        }

        if (displayStats)
        {
            if (curStat < stats.Length)
            {
                timer += Time.deltaTime;
                if (curStat == 4)
                {
                    if (timer >= (timerIncrement / fallModifier * 2))
                    {
                        stats[curStat].SetActive(true);
                        displayStats = false;
                    }
                }
                else if (timer >= (timerIncrement / fallModifier))
                {
                    if (curStat != 4)
                    {
                        stats[curStat].SetActive(true);
                        curStat++;
                        timer = 0.0f;
                    }


                }
            }

        }
    }

    private void disableStats()
    {
        for (int x = 0; x < stats.Length; x++)
        {
            stats[x].SetActive(false);
        }
    }

    public void quiteGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }

    public void replayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main_Auggo");
    }
}