using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile_Selection_Script : MonoBehaviour {

    public Image[] tileBorders = new Image[7];
    public static int curTile = 0;

    public int getCurTile()
    {
        return curTile;
    }

    private void Awake()
    {
        for(int x = 1; x < tileBorders.Length; x++)
        {
            Image curBorder = tileBorders[x];
            curBorder.enabled = false;
        }
    }

    private void Update()
    {
        highlightTile();
    }

    private void highlightTile()
    {
        scrollTileHighlight();
        keyTileHighlight();
    }

    private void keyTileHighlight() // Highlight tile to use using the alphanumeric number keys 1-7
    {
        int selectedTile = curTile;

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedTile = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedTile = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedTile = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedTile = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedTile = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            selectedTile = 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            selectedTile = 6;
        }

        if(selectedTile != curTile)
        {
            Image curBoarder = tileBorders[curTile];
            curBoarder.enabled = false;
            curTile = selectedTile;
            curBoarder = tileBorders[curTile];
            curBoarder.enabled = true;
        }
        

    }

    private void scrollTileHighlight()
    {
        double scrollDirection = Input.GetAxis("Mouse ScrollWheel");

        if (scrollDirection > 0)
        {
            Image curBoarder = tileBorders[curTile];
            curBoarder.enabled = false;
            curTile++;
            if (curTile > 6)
            {
                curTile = 0;
            }
            curBoarder = tileBorders[curTile];
            curBoarder.enabled = true;
        }
        else if (scrollDirection < 0)
        {
            Image curBoarder = tileBorders[curTile];
            curBoarder.enabled = false;
            curTile--;
            if (curTile < 0)
            {
                curTile = 6;
            }
            curBoarder = tileBorders[curTile];
            curBoarder.enabled = true;
        }
    } //Highlights appropriate tile using Mouse 3 Scrolling
}
