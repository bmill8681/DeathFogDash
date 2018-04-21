using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LetterTile : Item {

    bool isOnBoard = true;
    public string letter;
    public Tile _letter;
    MeshRenderer mr;

    private void Awake()
    {
        _letter = (Tile)Random.Range(1,27);
        letter = "" + WordHandler.instance.TiletoChar(_letter);
        mr = transform.GetComponent<MeshRenderer>();
        mr.material.SetTexture("_MainTex", WordHandler.instance.lettertile_textures[(int)_letter]);
    }

    void Update () {
        if(isOnBoard)
        transform.Rotate(Vector3.up, 2f);
	}
}
