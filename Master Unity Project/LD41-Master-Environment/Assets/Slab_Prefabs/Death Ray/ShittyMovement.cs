using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShittyMovement : MonoBehaviour {
    public float mSpeed = 0.0f;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.P))
        {
            Vector3 thisDirection = new Vector3(1.0f * mSpeed, 0, 0);
            transform.Translate(thisDirection);
        }
        
		
	}
}
