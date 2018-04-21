using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    public static PlayerInventory instance;
    List<Item> items;

    private void Awake()
    {
        if (PlayerInventory.instance == null)
            PlayerInventory.instance = this;
        else if (PlayerInventory.instance != this)
            Destroy(this.gameObject);
    }

    void Start () {
        items = new List<Item>();
	}

    public void AddItem(GameObject g_o)
    {
        items.Add(g_o.GetComponent<LetterTile>());
        //Add g_o.GetComponent<LetterTile>() to GUI
    }

}
