using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using DG.Tweening;
public class PlayerBuff : MonoBehaviour
{
    public GameData gameData;
    public PlayerData playerData;
    public ThirdPersonController thirdPersonController;

    [Header("Buffs")]
    public List<MeshCollider> SpecialWalls=new List<MeshCollider>();
    public GameObject fireParticle;
    public ParticleSystem[] speedUpParticle;
    public ParticleSystem timeStopParticle;
    public GameObject shieldParticle;


    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnFireActive,OnFireActive);
        EventManager.AddHandler(GameEvent.OnInvulnerable,OnInvulnerable);
        EventManager.AddHandler(GameEvent.OnSpeedUp,OnSpeedUp);
        EventManager.AddHandler(GameEvent.OnPassThroughDoors,OnPassThroughDoors);
        EventManager.AddHandler(GameEvent.OnTimeStop,OnTimeStop);

        EventManager.AddHandler(GameEvent.OnFireDeactive,OnFireDeactive);
        EventManager.AddHandler(GameEvent.OnVulnerable,OnVulnerable);
        EventManager.AddHandler(GameEvent.OnSpeedNormal,OnSpeedNormal);
        EventManager.AddHandler(GameEvent.OnNotPasThroughDoors,OnPassNotThroughDoors);
        EventManager.AddHandler(GameEvent.OnTimeContinue,OnTimeContinue);
        
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnFireActive,OnFireActive);
        EventManager.RemoveHandler(GameEvent.OnInvulnerable,OnInvulnerable);
        EventManager.RemoveHandler(GameEvent.OnSpeedUp,OnSpeedUp);
        EventManager.RemoveHandler(GameEvent.OnPassThroughDoors,OnPassThroughDoors);
        EventManager.RemoveHandler(GameEvent.OnTimeStop,OnTimeStop);

        EventManager.RemoveHandler(GameEvent.OnFireDeactive,OnFireDeactive);
        EventManager.RemoveHandler(GameEvent.OnVulnerable,OnVulnerable);
        EventManager.RemoveHandler(GameEvent.OnSpeedNormal,OnSpeedNormal);
        EventManager.RemoveHandler(GameEvent.OnNotPasThroughDoors,OnPassNotThroughDoors);
        EventManager.RemoveHandler(GameEvent.OnTimeContinue,OnTimeContinue);
    }

    private void Start() 
    {
        for (int i = 0; i < speedUpParticle.Length; i++)
        {
            speedUpParticle[i].Stop();
            speedUpParticle[i].gameObject.SetActive(false);
        }
        
    }


    void OnFireActive()
    {
        Debug.Log("FIRE ACTIVE");
        fireParticle.SetActive(true);
        fireParticle.transform.DOScale(new Vector3(4,4,4),0.4f).OnComplete(()=>fireParticle.transform.DOScale(new Vector3(2,2,2),0.5f));
        playerData.isInvulnerable=true;
        //ParticleEffect
    }

    void OnInvulnerable()
    {
        Debug.Log("SHIELD ACTIVE");
        shieldParticle.SetActive(true);
        playerData.isInvulnerable=true;
    }

    void OnSpeedUp()
    {
        Debug.Log("SPEED UP!");
        for (int i = 0; i < speedUpParticle.Length; i++)
        {
            speedUpParticle[i].gameObject.SetActive(true);
            speedUpParticle[i].Play();
        }
        thirdPersonController.SprintSpeed=25;
        playerData.isInvulnerable=true;
        
    }

    void OnPassThroughDoors()
    {
        Debug.Log("PASS THROUGH DOORS");
        for (int i = 0; i < SpecialWalls.Count; i++)
        {
            SpecialWalls[i].convex=true;
            SpecialWalls[i].isTrigger=true;
        }
    }

    void OnTimeStop()
    {
        Debug.Log("TIME IS STOP");
        timeStopParticle.Play();
        gameData.stopEnemies=true;
    }

    void OnFireDeactive()
    {
        Debug.Log("FIRE DEACTIVE");
        fireParticle.transform.DOScale(new Vector3(0.1f,0.1f,0.1f),0.2f).OnComplete(()=>{
            fireParticle.SetActive(false);
        });
        playerData.isInvulnerable=false;
        EventManager.Broadcast(GameEvent.OnBuffDeactive);
    }

    void OnVulnerable()
    {
        playerData.isInvulnerable=false;
        shieldParticle.SetActive(false);
        Debug.Log("SHIELD DEACTIVE");
        EventManager.Broadcast(GameEvent.OnBuffDeactive);
    }

    void OnSpeedNormal()
    {
        Debug.Log("SPEED NORMAL");
        for (int i = 0; i < speedUpParticle.Length; i++)
        {
            speedUpParticle[i].gameObject.SetActive(false);
            speedUpParticle[i].Stop();
        }
        thirdPersonController.SprintSpeed=10;
        EventManager.Broadcast(GameEvent.OnBuffDeactive);
        playerData.isInvulnerable=false;
    }

    void OnPassNotThroughDoors()
    {
        Debug.Log("NOT PASS THROUGH DOORS");
        for (int i = 0; i < SpecialWalls.Count; i++)
        {
            SpecialWalls[i].isTrigger=false;
            SpecialWalls[i].convex=false;
        }
        EventManager.Broadcast(GameEvent.OnBuffDeactive);
    }

    void OnTimeContinue()
    {
        Debug.Log("TIME IS CONTINUE");
        EventManager.Broadcast(GameEvent.OnBuffDeactive);
        timeStopParticle.Stop();
        gameData.stopEnemies=false;
    }

    
    
}
