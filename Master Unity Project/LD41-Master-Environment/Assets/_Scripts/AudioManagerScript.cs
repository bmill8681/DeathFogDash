using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour {

    public static AudioManagerScript instance;

    public AudioSource[] sources = new AudioSource[6];
    public AudioClip[]  explosionSounds = new AudioClip[3];
    public AudioClip[]  tileSounds = new AudioClip[3];
    public AudioClip    walkingSound;
    public AudioClip    bgMusic;

    /*  NOTES
     *  
     *  Sources 0-1 Are for explosions
     *  Source 2 is for Tile Sounds
     *  Source 3 is for Music
     *  Source 4 is for Walking
     *      Walking I have set up kind of poorly. Right now you would send a boolean flag
     *      to the audio manager using the setPlayerWalking method whenever the player is walking.
     *      if you want to do this differently... go ahead. It's not how I would typically do it.
     *  Source 5 is for Menu Sounds
     **/

    private bool playerIsWalking;

    private void Awake()
    {
        if (AudioManagerScript.instance == null)
            AudioManagerScript.instance = this;
        else if (AudioManagerScript.instance != this)
            Destroy(this.gameObject);


        // initializing Walking sounds
        playerIsWalking = false;
        sources[4].Stop();
        sources[4].clip = walkingSound;
        sources[4].loop = true;

        // ensuring all point clips are not set to loop
        for(int x = 0; x < 3; x++)
        {
            sources[x].loop = false;
        }

        // setting loop and playing bg music
        sources[3].loop = true;
        sources[3].clip = bgMusic;
        sources[3].Play();
    }

    private void LateUpdate()
    {
        if(playerIsWalking)
        {
            sources[4].Play();
        }
        else if (!playerIsWalking)
        {
            sources[4].Stop();
        }
    }

    #region Volume Modification
    /** Volume Modification
     * 
     * If a volume has been changed in the pause menu
     * all volumes will be updated to the proper value
     * 
     * change volumes using the set[volumeName]Volume(float ) function
     * */

    public void stopMusic()
    {
        sources[3].Stop();
    }
    public void startMusic()
    {
        sources[3].Play();
    }
    public void setMusicVolume(float vol)
    {
        sources[3].volume = vol;
    }
    public void setSFXVolume(float vol)
    {
        sources[0].volume = vol;
        sources[1].volume = vol;
        sources[2].volume = vol;
        sources[4].volume = vol;
        sources[5].volume = vol;
    }
    #endregion

    public void setPlayerWalking(bool isWalking)
    {
        playerIsWalking = isWalking;
    }

    public void playTileSound(int x)
    {
        /*
         * 0 = Pick Up Tile Sound
         * 1 = Place Tile Sound
         * 2 = Invalid / Destroyed Tile Sound
         * */

        sources[2].clip = tileSounds[x];
        sources[2].Play();
    }
    public void playDestructionSound()
    {
        AudioSource source = getSource(0);
        if (source != null)
        {
            AudioClip sClip = explosionSounds[Random.Range(0, explosionSounds.Length)];
            source.clip = sClip;
            source.loop = false;
            source.Play();
        }
    }

    public void playCrateSound()
    {
        AudioSource source = getSource(0);
        if (source != null)
        {
            AudioClip sClip = explosionSounds[2];
            source.clip = sClip;
            source.loop = false;
            source.Play();
        }
    }


    private AudioSource getSource(int x)
    {
        /*
        * Checks each of the first 3 audio sources to see if they are currently playing.
        * if it is not, it returns that source. If all 3 sources are currently playing a
        * sound, it returns null.
        **/
        AudioSource source = null;
        if(sources[x].isPlaying && x < 2)
        {
            x++;
            source = getSource(x);
        }
        else if (!sources[x].isPlaying && x < 2)
        {
            source = sources[x];
        }
        else if (x >= 3)
        {
            source = null;
        }

        return source;
    }
}
