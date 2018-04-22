using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShittyMovement : MonoBehaviour {
    public float mSpeed = 0.0f;

    //public Transform[] blades;
    //public float[] bladeheight = new float[5];

    //private void Start()
    //{
    //    for (int i = 0; i < blades.Length; i++)
    //    {
    //        bladeheight[i] = blades[i].position.y;
    //    }
    //}

    void Update () {
        if(!Input.GetKey(KeyCode.P))
        {
            Vector3 thisDirection = new Vector3(1.0f * mSpeed, 0, 0);
            transform.position += thisDirection;
            //for(int i = 0; i < blades.Length; i++)
            //{
            //    blades[i].position =  Vector3.up * (bladeheight[i] + (1000*Mathf.Sin(Time.deltaTime)));
            //}
        }
        
		
	}
}
