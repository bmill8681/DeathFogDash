﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShittyMovement : MonoBehaviour {
    public float mSpeed = 0.0f;


    void Update () {
        if(!GameController.instance.paused)
        {
            Vector3 thisDirection = new Vector3(1.0f * mSpeed, 0, 0);
            transform.position += thisDirection;
        }
        
		
	}
}
