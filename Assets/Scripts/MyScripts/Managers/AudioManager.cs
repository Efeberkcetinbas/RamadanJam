using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip LoopMusic;

    public AudioClip BuffDeactiveSound,fireBuffSound,timeStopBuffSound,speedUpBuffSound,shieldBuffSound,wallBuffSound,starCollectSound;

    private AudioSource musicSource, effectSource;

    private void Start() 
    {
        musicSource=GetComponent<AudioSource>();
        musicSource.clip=LoopMusic;
        effectSource=gameObject.AddComponent<AudioSource>();
        effectSource.volume=0.6f;
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnBuffDeactive,PlayBuffDeactive);
        EventManager.AddHandler(GameEvent.OnFireActive,PlayFireBuff);
        EventManager.AddHandler(GameEvent.OnTimeStop,PlayTimeStopBuff);
        EventManager.AddHandler(GameEvent.OnSpeedUp,PlaySpeedUpBuff);
        EventManager.AddHandler(GameEvent.OnInvulnerable,PlayShieldBuff);
        EventManager.AddHandler(GameEvent.OnPassThroughDoors,PlayWallBuff);
        EventManager.AddHandler(GameEvent.OnStarCollect,PlayStarCollect);

    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnBuffDeactive,PlayBuffDeactive);
        EventManager.RemoveHandler(GameEvent.OnFireActive,PlayFireBuff);
        EventManager.RemoveHandler(GameEvent.OnTimeStop,PlayTimeStopBuff);
        EventManager.RemoveHandler(GameEvent.OnSpeedUp,PlaySpeedUpBuff);
        EventManager.RemoveHandler(GameEvent.OnInvulnerable,PlayShieldBuff);
        EventManager.RemoveHandler(GameEvent.OnPassThroughDoors,PlayWallBuff);
        EventManager.RemoveHandler(GameEvent.OnStarCollect,PlayStarCollect);

    }


    

    void PlayBuffDeactive()
    {
        effectSource.PlayOneShot(BuffDeactiveSound);
    }

    void PlayFireBuff()
    {
        effectSource.PlayOneShot(fireBuffSound);
    }

    void PlayTimeStopBuff()
    {
        effectSource.PlayOneShot(timeStopBuffSound);
    }

    void PlaySpeedUpBuff()
    {
        effectSource.PlayOneShot(speedUpBuffSound);
    }

    void PlayShieldBuff()
    {
        effectSource.PlayOneShot(shieldBuffSound);
    }

    void PlayWallBuff()
    {
        effectSource.PlayOneShot(wallBuffSound);
    }

    void PlayStarCollect()
    {
        effectSource.PlayOneShot(starCollectSound);
    }
}
