using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proceed : MonoBehaviour {

    Transform[] next = new Transform[3];
    Transform[] prev = new Transform[3];
    Transform[] current = new Transform[3];
    Transform[] left_wall = new Transform[3];
    Transform[] right_wall = new Transform[3];

    float current_offset = 0;
    float offset = 88f;
    float wall_offset = 10f;

    // Use this for initialization
    void Start () {
		for( int i = 0; i < 3; i++)
        {
            current[i] = Instantiate(GameController.instance.SlabPrefab, new Vector3(current_offset + offset, 0, i * offset), Quaternion.identity).transform;

            prev[i] = Instantiate(GameController.instance.SlabPrefab, new Vector3(current_offset, 0, i * offset),Quaternion.identity).transform;

            next[i] = Instantiate(GameController.instance.SlabPrefab, new Vector3(current_offset + offset + offset, 0, i * offset), Quaternion.identity).transform;

            left_wall[i] = Instantiate(GameController.instance.WallPrefab, new Vector3(i * offset, 0, -wall_offset - (offset/2)), Quaternion.Euler(0, 180, 0)).transform;
            right_wall[i] = Instantiate(GameController.instance.WallPrefab, new Vector3(i * offset, 0, +wall_offset + (5*offset / 2)), Quaternion.identity).transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
