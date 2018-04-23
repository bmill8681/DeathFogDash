using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proceed : MonoBehaviour {

    public static Proceed instance = null;
    public Transform deathray;
    public Transform[] next = new Transform[3];
    public Transform[] prev = new Transform[3];
    public Transform[] current = new Transform[3];
    Transform[] left_wall = new Transform[3];
    Transform[] right_wall = new Transform[3];


    float current_offset = 0;
    float offset = 88f;
    float wall_offset = 10f;
    public Transform[] holder = new Transform[3];
    float rim_dist;

    private void Awake()
    {
        if (Proceed.instance == null)
        { Proceed.instance = this; }
        else if (Proceed.instance != this)
        { Debug.Log("You have two Proceed Scripts!"); Destroy(this); }
        holder[0] = new GameObject("holder").transform;
        holder[1] = new GameObject("holder").transform;
        holder[2] = new GameObject("holder").transform;
    }

    private void Start()
    {
        rim_dist = offset * 2;
        for (int i = 0; i < 3; i++)
        {
            current[i] = Instantiate(GameController.instance.SlabPrefab, new Vector3(current_offset + offset, 0, i * offset), Quaternion.identity).transform;

            prev[i] = Instantiate(GameController.instance.SlabPrefab, new Vector3(current_offset, 0, i * offset), Quaternion.identity).transform;

            next[i] = Instantiate(GameController.instance.SlabPrefab, new Vector3(current_offset + offset + offset, 0, i * offset), Quaternion.identity).transform;

            left_wall[i] = Instantiate(GameController.instance.WallPrefab, new Vector3(i * offset, 0, -wall_offset - (offset / 2)), Quaternion.Euler(0, 180, 0)).transform;
            right_wall[i] = Instantiate(GameController.instance.WallPrefab, new Vector3(i * offset, 0, +wall_offset + (5 * offset / 2)), Quaternion.identity).transform;
        }
    }


    void Update () {
		if(GameController.instance.player.position.x > rim_dist)
        {
            rim_dist += offset;
            current_offset += offset;
            for (int i = 0; i < 3; i++)
            {
                Destroy(prev[i].gameObject);
                prev[i] = current[i];
                current[i] = next[i];
                next[i] = Instantiate(GameController.instance.SlabPrefab, new Vector3(current_offset + offset + offset, 0, i * offset), Quaternion.identity).transform;
            }

            Transform temp;
            left_wall[0].position += Vector3.right * offset * 3;
            right_wall[0].position += Vector3.right * offset * 3;

            temp = left_wall[0];
            left_wall[0] = left_wall[1];
            left_wall[1] = left_wall[2];
            left_wall[2] = temp;

            temp = right_wall[0];
            right_wall[0] = right_wall[1];
            right_wall[1] = right_wall[2];
            right_wall[2] = temp;

            Destroy(holder[0].gameObject);
            holder[0] = holder[1];
            holder[1] = holder[2];
            holder[2] = new GameObject("holder").transform;

            deathray.position = new Vector3(Mathf.Clamp(deathray.position.x, prev[0].position.x, next[0].position.x), deathray.position.y, deathray.position.z);

        }
	}
}
