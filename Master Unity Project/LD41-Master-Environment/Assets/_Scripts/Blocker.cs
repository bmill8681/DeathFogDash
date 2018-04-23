using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour {

    public List<BuildingTransparency> houses;

    public void pingFade()
    {
        for(int i = 0; i < houses.Count; i++)
        {
            houses[i].pingFade();
        }

    }


}
