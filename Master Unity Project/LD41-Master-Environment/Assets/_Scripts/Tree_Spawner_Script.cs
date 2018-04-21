using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Spawner_Script : MonoBehaviour {

    public GameObject[] trees = new GameObject[3];

    private void Start()
    {
        int objNum = Random.Range(-1, trees.Length);
        if (objNum != -1)
        {
            GameObject newCan = Instantiate(trees[objNum], transform.position, transform.rotation);
        }
        Destroy(this.gameObject);
    }
}
