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

    public Material NormalMat,WallMat;

    [SerializeField] private SkinnedMeshRenderer meshRenderer;


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
        thirdPersonController.SprintSpeed=5;
        fireParticle.SetActive(true);
        fireParticle.transform.DOScale(new Vector3(4,4,4),2f).OnComplete(()=>fireParticle.transform.DOScale(new Vector3(1,1,1),2));
        playerData.isInvulnerable=true;
        //ParticleEffect
    }

    void OnInvulnerable()
    {
        shieldParticle.SetActive(true);
        playerData.isInvulnerable=true;
    }

    void OnSpeedUp()
    {
        for (int i = 0; i < speedUpParticle.Length; i++)
        {
            speedUpParticle[i].gameObject.SetActive(true);
            speedUpParticle[i].Play();
        }
        thirdPersonController.SprintSpeed=15;
        playerData.isInvulnerable=true;
        
    }

    void OnPassThroughDoors()
    {
        meshRenderer.material=WallMat;
        for (int i = 0; i < SpecialWalls.Count; i++)
        {
            SpecialWalls[i].convex=true;
            SpecialWalls[i].isTrigger=true;
        }
    }

    void OnTimeStop()
    {
        timeStopParticle.Play();
        gameData.stopEnemies=true;
    }

    void OnFireDeactive()
    {
        fireParticle.transform.DOScale(new Vector3(0.1f,0.1f,0.1f),0.2f).OnComplete(()=>{
            fireParticle.SetActive(false);
        });
        playerData.isInvulnerable=false;
        thirdPersonController.SprintSpeed=6;
        EventManager.Broadcast(GameEvent.OnBuffDeactive);
    }

    void OnVulnerable()
    {
        playerData.isInvulnerable=false;
        shieldParticle.SetActive(false);
        EventManager.Broadcast(GameEvent.OnBuffDeactive);
    }

    void OnSpeedNormal()
    {
        for (int i = 0; i < speedUpParticle.Length; i++)
        {
            speedUpParticle[i].gameObject.SetActive(false);
            speedUpParticle[i].Stop();
        }
        thirdPersonController.SprintSpeed=6;
        EventManager.Broadcast(GameEvent.OnBuffDeactive);
        playerData.isInvulnerable=false;
    }

    void OnPassNotThroughDoors()
    {
        meshRenderer.material=NormalMat;
        for (int i = 0; i < SpecialWalls.Count; i++)
        {
            SpecialWalls[i].isTrigger=false;
            SpecialWalls[i].convex=false;
        }
        EventManager.Broadcast(GameEvent.OnBuffDeactive);
    }

    void OnTimeContinue()
    {
        EventManager.Broadcast(GameEvent.OnBuffDeactive);
        timeStopParticle.Stop();
        gameData.stopEnemies=false;
    }

    
    
}
