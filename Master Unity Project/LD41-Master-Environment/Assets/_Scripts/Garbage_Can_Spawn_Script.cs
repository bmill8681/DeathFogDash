using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage_Can_Spawn_Script : MonoBehaviour {

    public GameObject[] garbageCans = new GameObject[3];

    private void Start()
    {
        int objNum = Random.Range(-1, garbageCans.Length);
        if (objNum != -1)
        {
            GameObject newCan = Instantiate(garbageCans[objNum], transform.position, transform.rotation);
        }
        Destroy(this.gameObject);
    } 
}
