using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : MonoBehaviour
{

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, Random.value * 360, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO other break stuff
        if (other.CompareTag("Player"))
        {
            WordHandler.instance.PlaceRandomLetter(transform);
            Destroy(this.gameObject);
            AudioManagerScript.instance.playCrateSound();
        }
    }

}
