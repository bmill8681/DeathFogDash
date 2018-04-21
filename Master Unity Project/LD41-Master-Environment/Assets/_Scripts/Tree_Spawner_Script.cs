using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Spawner_Script : MonoBehaviour {

    public GameObject[] trees = new GameObject[3];
    public Transform parkParent;
    

    private void Start()
    {
        float scaleFactor = Random.Range(30.0f, 50.0f);
        int objNum = Random.Range(-1, trees.Length);
        if (objNum != -1)
        {
            GameObject newTree = Instantiate(trees[objNum], transform.position, transform.rotation);
            newTree.transform.SetParent(parkParent);
            newTree.transform.localScale = new Vector3(scaleFactor * parkParent.localScale.x, scaleFactor * parkParent.localScale.y, scaleFactor * parkParent.localScale.z);
        }
        Destroy(this.gameObject);
    }
}
