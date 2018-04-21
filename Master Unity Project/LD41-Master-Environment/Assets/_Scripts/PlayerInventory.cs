using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    List<Item> items;



	void Start () {
        items = new List<Item>();
	}

    private void OnTriggerEnter(Collider other)
    {
        //if()
    }
}
