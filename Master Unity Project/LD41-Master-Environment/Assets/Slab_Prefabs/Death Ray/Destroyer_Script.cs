using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer_Script : MonoBehaviour {

    public GameObject dSoundObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Breakable"))
        {
            if(Vector3.Distance(GameController.instance.player.position,other.transform.position) < 40 )
            other.SendMessage("explode");
        }
        else if (other.CompareTag("Player"))
        {
            GameController.instance.KillPlayer(other.gameObject);
        }
    }


}
