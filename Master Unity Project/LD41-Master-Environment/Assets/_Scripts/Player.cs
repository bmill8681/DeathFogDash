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

 //   Vector3 lastpos = Vector3.zero;
 //   Vector3 thispos = Vector3.zero;
 //   //float vel = Vector3.zero;


 //   // Update is called once per frame
 //   void Update () {
 //       lastpos = thispos;
 //       thispos = transform.position;
 //      Debug.Log(Vector3.Distance(thispos,lastpos)/Time.deltaTime);
	//}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LetterTile"))
        {
            Tile tile = other.GetComponent<LetterTile>()._letter;
            if (Tile_Selection_Script.instance.AddTile(tile))
            {
                AudioManagerScript.instance.playTileSound(0);
                Destroy(other.gameObject);
            }
        }
    }

}
