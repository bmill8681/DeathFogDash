using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShittyMovement : MonoBehaviour {
    public float mSpeed = 0.0f;

    public Transform[] blades;

    void Update () {
        if(!GameController.instance.paused)
        {
            Vector3 thisDirection = new Vector3(1.0f * mSpeed, 0, 0);
            transform.position += thisDirection;

            for (int i = 0; i < blades.Length; i++)
            {
                blades[i].rotation = Quaternion.Euler(0, 0, .6f * Mathf.Sin((Time.time+i)*(i+1)));
            }
        }
        
		
	}
}
