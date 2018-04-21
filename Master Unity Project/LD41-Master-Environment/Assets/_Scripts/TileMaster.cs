using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMaster : MonoBehaviour {

    public GameObject[] buildingTiles;
    public GameObject[] objectTiles;
    public GameObject[] letterTiles;
    public GameObject[] treeTiles;
    public Hashtable openWith;
    public static TileMaster instance = null;


	void Awake () {
        if (instance != null)
            instance = this;
        else if (instance != this)
            Destroy(this);
	}
	
}
