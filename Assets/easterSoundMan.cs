using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easterSoundMan : MonoBehaviour
{
    public AudioClip mainMusic;
    public AudioClip heavenMusic;
    public AudioClip winMusic;
    public AudioSource musicSrc;
    public AudioSource soundEffectsSrc;
    public static easterSoundMan instance = null;
    
    // Start is called before the first frame update
    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if(instance == null)
        {   //if not, set it to this.
            instance = this;    
        }   //If instance already exists:
        else if(instance != this)
        {
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
    }
    public void playMainLoop()
    {
        musicSrc.clip = mainMusic;
        musicSrc.Play();
    }
    public void playHeavenMusic()
    {
        musicSrc.clip = heavenMusic;
        musicSrc.Play();
    }
    public void playEggDeathNoise()
    {
        soundEffectsSrc.Play();
    }
    public void playWinMusic()
    {
        musicSrc.clip = winMusic;
        musicSrc.Play();
    }
}
