﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single_Tree_Spawner : MonoBehaviour
{

    public GameObject[] trees = new GameObject[3];


    private void Start()
    {
        float scaleFactor = Random.Range(2.0f, 5.0f);
        int objNum = Random.Range(-1, trees.Length);
        if (objNum != -1)
        {
            GameObject newTree = Instantiate(trees[objNum], transform.position, transform.rotation);
            newTree.transform.localScale = new Vector3(scaleFactor * transform.localScale.x, scaleFactor * transform.localScale.y, scaleFactor * transform.localScale.z);
        }
        Destroy(this.gameObject);
    }
}
