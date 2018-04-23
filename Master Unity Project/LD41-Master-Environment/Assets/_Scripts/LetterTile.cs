using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LetterTile : Item {

    bool isOnBoard = true;
    public string letter;
    public Tile _letter;
    MeshRenderer mr;
    int[] vowels = new int[] { 1, 5, 9, 15, 21 };

    private void Awake()
    {
        //if (Random.value > 0.45f) { _letter = (Tile)vowels[Random.Range(0, 5)]; }
        //else { _letter = (Tile)Random.Range(1, 27); }
        float rand = Random.value;
       
        if (rand < (5f / WordHandler.instance.total_tiles)) //single tiles
        {
            _letter = WordHandler.chance[Random.Range(0,5)];
        }
        else if (rand < (23f / WordHandler.instance.total_tiles)) // 2 tiles
        {
            _letter = WordHandler.chance[Random.Range(5, 14)];
        }
        else if (rand < 26f / WordHandler.instance.total_tiles) // 3 tiles
        {
            _letter = WordHandler.chance[Random.Range(14, 15)];
        }
        else if (rand < 42f / WordHandler.instance.total_tiles) //4 tiles
        {
            _letter = WordHandler.chance[Random.Range(15, 19)];
        }
        else if (rand < 60f / WordHandler.instance.total_tiles) //6 tiles
        {
            _letter = WordHandler.chance[Random.Range(19, 22)];
        }
        else if (rand < 68f / WordHandler.instance.total_tiles) //8 tiles
        {
            _letter = WordHandler.chance[Random.Range(22, 23)];
        }
        else if (rand < 86f / WordHandler.instance.total_tiles) //9 tiles
        {
            _letter = WordHandler.chance[Random.Range(23, 25)];
        }
        else //12 tiles
        {
            _letter = WordHandler.chance[25];
        }

        mr = transform.GetComponent<MeshRenderer>();
        mr.material.SetTexture("_MainTex", WordHandler.instance.lettertile_textures[(int)_letter]);
    }

    void Update () {
        if(isOnBoard)
        transform.Rotate(Vector3.up, 2f);
	}
}
