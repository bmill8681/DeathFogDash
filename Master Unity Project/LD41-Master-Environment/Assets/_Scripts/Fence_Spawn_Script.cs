using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence_Spawn_Script : MonoBehaviour {

    public GameObject[] fences = new GameObject[3];

    private void Start()
    {
        int objNum = Random.Range(-1, fences.Length);
        if (objNum != -1)
        {
            GameObject newCan = Instantiate(fences[objNum], transform.position, transform.rotation);
        }
        Destroy(this.gameObject);
    }
}
