using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterPlaying : MonoBehaviour {

    private AudioSource source;
	// Use this for initialization
	void Awake () {
        source = GetComponent<AudioSource>();
	}

    private void Start()
    {
        source.Play();
    }
    // Update is called once per frame
    void LateUpdate () {
		if(!source.isPlaying)
        {
            Destroy(this.gameObject);
        }
	}
}
