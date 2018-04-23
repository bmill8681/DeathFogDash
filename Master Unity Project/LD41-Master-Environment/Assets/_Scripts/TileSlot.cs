using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSlot : MonoBehaviour {


    public GameObject[] possibleTiles;
    public bool isRoot;
    //public Transform slot_root;
    //SlabInit slab;
    public Blocker blocker;

    private void Start()
    {
        //if (isRoot)
        //{
        //    //slab = transform.parent.parent.GetComponent<SlabInit>();
        //    //if(slab == null) { Debug.LogError("slab doesn't exist at " + transform.position); }
        //    else { slot_root = transform; }
        //}
        if (possibleTiles.Length > 0)
        {
            Transform sub = Instantiate(possibleTiles[Random.Range(0, possibleTiles.Length)]).transform;
            sub.position = transform.position;
            sub.rotation = transform.rotation;

            if (!isRoot)
            {
                Destroy(this.gameObject);
                sub.parent = transform.parent;
            }
            else
            {
                sub.parent = transform;
            }
        }
    }


}
