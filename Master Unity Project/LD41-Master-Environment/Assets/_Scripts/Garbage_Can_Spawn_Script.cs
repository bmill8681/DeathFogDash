using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage_Can_Spawn_Script : MonoBehaviour {

    public GameObject[] garbageCans = new GameObject[3];
    public Transform parkParent;

    private void Start()
    {
        float scaleFactor = 10.0f;
        int objNum = Random.Range(-1, garbageCans.Length);
        if (objNum != -1)
        {
            GameObject newCan = Instantiate(garbageCans[objNum], transform.position, transform.rotation);
            newCan.transform.SetParent(parkParent);
            newCan.transform.localScale = new Vector3(scaleFactor * parkParent.localScale.x, scaleFactor * parkParent.localScale.y, scaleFactor * parkParent.localScale.z);
        }
        Destroy(this.gameObject);
    } 
}
