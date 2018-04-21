using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance;
    AudioSource audiosource;
    AudioClip letter_jingle;

    private void Awake()
    {
        if (Player.instance == null)
            Player.instance = this;
        else if (Player.instance != this)
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LetterTile"))
        {
            PlayerInventory.instance.AddItem(other.gameObject);
            //audiosource.PlayOneShot(letter_jingle);
            Destroy(other.gameObject);
        }
    }

}
