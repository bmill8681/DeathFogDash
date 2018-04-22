using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCaster : MonoBehaviour {


    Ray ray;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    }
}
