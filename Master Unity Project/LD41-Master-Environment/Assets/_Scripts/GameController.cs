﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance = null;

    public Material[] housecolors;

    public uint level = 3;

    private void Awake()
    {
        if (GameController.instance == null)
            GameController.instance = this;
        else if (GameController.instance != this)
            Destroy(this);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}