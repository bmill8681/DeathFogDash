using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlabInit : MonoBehaviour {

    public RoadStrip[] road_strips;
    public Transform Grass;
    public Transform roots;


    private void Start()
    {
        for(int i = 0; i < road_strips.Length; i++)
        {
            if(Random.value > .30f) { road_strips[i].SetWord(); }
            else
            {
                int first = Random.Range(0, road_strips[i].slots.Length);
                int second;
                Instantiate(WordHandler.instance.letter_tile_prefab, road_strips[i].slots[first].position + (Vector3.up * .3f) , transform.rotation);
                if (road_strips[i].slots.Length - first > 4) { second = Random.Range(3, 5) + first; }
                else {second = first - Random.Range(2, 4); }
                Instantiate(WordHandler.instance.letter_tile_prefab, road_strips[i].slots[second].position + (Vector3.up * .3f), transform.rotation);
            }
        }
    }


}
