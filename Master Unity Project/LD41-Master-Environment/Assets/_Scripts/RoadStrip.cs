using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RoadStrip : MonoBehaviour {


    public Transform[] slots;
    Item[] items;

    private void Start()
    {
        items = new Item[slots.Length];
    }

    public void SetWord()
    {
        int offset = Random.Range(0, 4);
        Tile[] word = WordHandler.instance.RandomWord(Random.Range(3,6));
        MeshRenderer mr;
        for(int i = 0; i < word.Length; i++)
        {
            
            Transform letter_holder = Instantiate(WordHandler.instance.LetterPrefab, slots[i + offset].position, transform.rotation).transform;
            mr = letter_holder.GetComponent<MeshRenderer>();
            Debug.Log((int)word[i]);
            mr.material.SetTexture("_MainTex",WordHandler.instance.lettertile_textures[(int)word[i]]);
            letter_holder.parent = slots[i + offset].parent;
            slots[i + offset].gameObject.SetActive(false);
            items[i + offset] = letter_holder.GetComponent<Item>();
        }

    }
}
