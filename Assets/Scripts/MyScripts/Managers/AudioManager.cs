using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip LoopMusic;

    public AudioClip BuffActiveSound,BuffDeactiveSound;

    private AudioSource musicSource, effectSource;

    private void Start() 
    {
        musicSource=GetComponent<AudioSource>();
        musicSource.clip=LoopMusic;
        effectSource=gameObject.AddComponent<AudioSource>();
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnBuffActive,PlayBuffActive);
        EventManager.AddHandler(GameEvent.OnBuffDeactive,PlayBuffDeactive);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnBuffActive,PlayBuffActive);
        EventManager.RemoveHandler(GameEvent.OnBuffDeactive,PlayBuffDeactive);
    }


    void PlayBuffActive()
    {
        Debug.Log("BUFF ACTIVE MUZIK");
        //effectSource.PlayOneShot(BuffActiveSound);
    }

    void PlayBuffDeactive()
    {
        Debug.Log("BUFF DEACTIVE MUZIK");
        //effectSource.PlayOneShot(BuffDeactiveSound);
    }
}
