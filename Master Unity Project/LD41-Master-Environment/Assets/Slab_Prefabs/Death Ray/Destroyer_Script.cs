using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer_Script : MonoBehaviour {

    public GameObject dSoundObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "persistent")
        {
            int chance = Random.Range(0, 5);  // Chance of playing a sound when destroyed
            if(chance == 4)
                Instantiate(dSoundObj, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }


}
