using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSlot : MonoBehaviour {

    //roads: 1 tile
    //buildings:  2x2, 2x3, 3x3, 3x4



    public GameObject[] possibleTiles;

    //public enum SlotType { building , breakable, tree, subtiles }

    //public int width;
    //public int length;
    //public SlotType slot_type;

    private void Start()
    {
        if (possibleTiles.Length > 0)
        {
            Transform sub = Instantiate(possibleTiles[Random.Range(0, possibleTiles.Length)]).transform;
            sub.position = transform.position;
            sub.rotation = transform.rotation;
            sub.parent = transform.parent;
            Destroy(this.gameObject);
        }
    }

    //void InitializeTile()
    //{
    //    switch (slot_type) {
    //        case SlotType.building:
    //            InitializeBuilding();
    //            return;
    //        case SlotType.breakable:
    //            return;
    //        case SlotType.tree:
    //            return;
    //        default:
    //            return;
    //    }
    //}

    //void InitializeBuilding()
    //{

    //} 



}
