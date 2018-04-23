using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RoadStrip : MonoBehaviour {


    public Transform[] slots;
    Transform[] items;
    public Tile[] word;
    int offset;
    MeshRenderer mr;

    private void Awake()
    {
        items = new Transform[slots.Length];
    }

    /// <summary>
    /// Make the tiles do something and then go away
    /// </summary>
    void WordCompleted()
    {
        Debug.Log("Word completed " + word.Length);
        for (int i = 0; i < word.Length; i++)
        {
            Destroy(items[offset + i].gameObject);
            slots[offset + i].gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Check whether the tile completes a word. If the word is completed and wrong, drop the tile piece into the chasm.
    /// If the word is not completed, lay down a letter where the chasm was and update the word.
    /// If the word is completed and the 
    /// </summary>
    public void SubmitTile(Tile tile, int index)
    {
        Tile[] temp_word = word;
        temp_word[index] = tile;
        for(int i = 0; i< temp_word.Length; i++)
        {
            if (temp_word[i] == Tile._)
            {
                //word not complete yet
                Debug.Log("not complete");
                PlaceTileAtChasm(tile, index);
                word = temp_word;
                if (GameController.instance.point_style == PointStyle.PlacedLetterOnly) { GameController.instance.total_points += Mathf.FloorToInt(GameController.instance.block_multiplier * WordHandler.GetCharValue(WordHandler.TiletoChar(tile))); }
                return;
            }
        }
        //word is now complete check if it works
        if (WordHandler.instance.EvalWord(word) != -1)
        {
            //works, complete word, 
            PlaceTileAtChasm(tile, index);
            word = temp_word;
            WordCompleted();
            if(GameController.instance.point_style == PointStyle.PlacedLetterOnly) { GameController.instance.total_points += Mathf.FloorToInt(GameController.instance.block_multiplier * WordHandler.GetCharValue(WordHandler.TiletoChar(tile))); }
        }
        else
        {
            //make tile fall, don't do anything.
        }
        Tile_Selection_Script.instance.Discard();
        
    }

    /// <summary>
    /// delete chasm, place new tile instead
    /// </summary>
    void PlaceTileAtChasm(Tile tile, int index)
    {
        Transform letter_holder = Instantiate(WordHandler.instance.LetterPrefab, slots[index + offset].position, transform.rotation).transform;

        mr = letter_holder.GetComponent<MeshRenderer>();
        mr.material.SetTexture("_MainTex", WordHandler.instance.lettertile_textures[(int)word[index]]);

        letter_holder.parent = slots[index + offset].parent;

        Destroy(items[index + offset].gameObject);
        items[index + offset] = letter_holder;
    }

    public void SetWord()
    {
        int min_length = Mathf.Clamp(Mathf.FloorToInt(GameController.instance.block_multiplier / 8f) - 1, 3, slots.Length - 1);
        int max_length = Mathf.Clamp(Mathf.FloorToInt(GameController.instance.block_multiplier / 8f) + 2, 3, slots.Length - 1);
        int level = (int)GameController.instance.level;
        word = WordHandler.instance.RandomWord(Random.Range(min_length, max_length));
        offset = Random.Range(0, slots.Length - word.Length);
        for(int i = 0; i < word.Length; i++)
        {
            if ( word[i] == Tile.question_mark || word[i] == Tile._ )
            {
                Chasm chasm = Instantiate(GameController.instance.ChasmPrefab, slots[i + offset].position, transform.rotation).GetComponent<Chasm>();
                chasm.full_word = this;
                chasm.this_index = i;
                chasm.transform.parent = slots[i + offset].parent;
                slots[i + offset].gameObject.SetActive(false);
                items[i + offset] = chasm.transform;
            }
            else
            {
                Transform letter_holder = Instantiate(WordHandler.instance.LetterPrefab, slots[i + offset].position, transform.rotation).transform;
                mr = letter_holder.GetComponent<MeshRenderer>();
                mr.material.SetTexture("_MainTex", WordHandler.instance.lettertile_textures[(int)word[i]]);
                letter_holder.parent = slots[i + offset].parent;
                slots[i + offset].gameObject.SetActive(false);
                items[i + offset] = letter_holder;
            }
        }

    }
}
