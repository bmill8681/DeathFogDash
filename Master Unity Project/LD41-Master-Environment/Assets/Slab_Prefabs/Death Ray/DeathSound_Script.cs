using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound_Script : MonoBehaviour {

    private AudioSource aSource;
    public AudioClip[] destroySounds = new AudioClip[3];

    private void Awake()
    {
        aSource = GetComponent<AudioSource>();
        playDeathSound();
    }

    private void LateUpdate()
    {
        if(!aSource.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }

    private void playDeathSound()
    {
        int sound = Random.Range(0, destroySounds.Length);
        AudioClip sClip = destroySounds[sound];
        aSource.clip = sClip;
        aSource.Play();
    }
}
