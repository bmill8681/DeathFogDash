using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Fence : MonoBehaviour {

    public GameObject[] fences = new GameObject[3];

	// Use this for initialization
	void Start () {
        int fenceNum = Random.Range(0, 3);
        GameObject newFence = Instantiate(fences[fenceNum], transform.position, transform.rotation);
        newFence.transform.parent = this.transform;
	}
	
}
