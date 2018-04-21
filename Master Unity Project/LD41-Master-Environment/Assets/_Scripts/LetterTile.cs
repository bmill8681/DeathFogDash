using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LetterTile : Item {

    bool isOnBoard = true;
    public string letter;
    public Tile _letter;

	void Update () {
        if(isOnBoard)
        transform.Rotate(Vector3.up, 2f);
	}
}
