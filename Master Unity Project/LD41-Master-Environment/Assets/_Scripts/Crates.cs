using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //TODO other break stuff
        if (other.CompareTag("Player"))
        {
            WordHandler.instance.PlaceRandomLetter(transform);
            Destroy(this.gameObject);

        }
    }

}
