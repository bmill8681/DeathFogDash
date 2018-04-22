﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCaster : MonoBehaviour {


    Ray ray;
    RaycastHit hit;
    public LayerMask chasm_mask;
    public LayerMask gui_trash;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, chasm_mask))
        {
            hit.collider.BroadcastMessage("pingFade", Tile_Selection_Script.instance.tiles[Tile_Selection_Script.instance.curTile]);

            if (Input.GetMouseButtonDown(0)) { hit.collider.BroadcastMessage("SubmitLetter", Tile_Selection_Script.instance.tiles[Tile_Selection_Script.instance.curTile]); }
        }
        
    }


}
