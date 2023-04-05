using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class PlayerBuff : MonoBehaviour
{
    public GameData gameData;
    public PlayerData playerData;
    public ThirdPersonController thirdPersonController;

    [Header("Buffs")]
    public GameObject Sword;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnSwordActive,OnSwordActive);
        EventManager.AddHandler(GameEvent.OnInvulnerable,OnInvulnerable);
        EventManager.AddHandler(GameEvent.OnSpeedUp,OnSpeedUp);
        EventManager.AddHandler(GameEvent.OnPassThroughDoors,OnPassThroughDoors);
        EventManager.AddHandler(GameEvent.OnTimeStop,OnTimeStop);

        EventManager.AddHandler(GameEvent.OnSwordDeactive,OnSwordDeActive);
        EventManager.AddHandler(GameEvent.OnVulnerable,OnVulnerable);
        EventManager.AddHandler(GameEvent.OnSpeedNormal,OnSpeedNormal);
        EventManager.AddHandler(GameEvent.OnNotPasThroughDoors,OnPassNotThroughDoors);
        EventManager.AddHandler(GameEvent.OnTimeContinue,OnTimeContinue);
        
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnSwordActive,OnSwordActive);
        EventManager.RemoveHandler(GameEvent.OnInvulnerable,OnInvulnerable);
        EventManager.RemoveHandler(GameEvent.OnSpeedUp,OnSpeedUp);
        EventManager.RemoveHandler(GameEvent.OnPassThroughDoors,OnPassThroughDoors);
        EventManager.RemoveHandler(GameEvent.OnTimeStop,OnTimeStop);

        EventManager.RemoveHandler(GameEvent.OnSwordDeactive,OnSwordDeActive);
        EventManager.RemoveHandler(GameEvent.OnVulnerable,OnVulnerable);
        EventManager.RemoveHandler(GameEvent.OnSpeedNormal,OnSpeedNormal);
        EventManager.RemoveHandler(GameEvent.OnNotPasThroughDoors,OnPassNotThroughDoors);
        EventManager.RemoveHandler(GameEvent.OnTimeContinue,OnTimeContinue);
    }

    void OnSwordActive()
    {
        Debug.Log("SWORD ACTIVE");
        playerData.playerCanSwing=true;
        Sword.SetActive(true);
        //ParticleEffect
        Sword.SetActive(true);
    }

    void OnInvulnerable()
    {
        Debug.Log("SHIELD ACTIVE");
        playerData.isInvulnerable=true;
    }

    void OnSpeedUp()
    {
        Debug.Log("SPEED UP!");
        thirdPersonController.SprintSpeed=25;
        
    }

    void OnPassThroughDoors()
    {
        Debug.Log("PASS THROUGH DOORS");
    }

    void OnTimeStop()
    {
        Debug.Log("TIME IS STOP");
        gameData.stopEnemies=true;
    }

    void OnSwordDeActive()
    {
        Debug.Log("SWORD DEACTIVE");
        playerData.playerCanSwing=false;
        Sword.SetActive(false);
        EventManager.Broadcast(GameEvent.OnBuffDeactive);
    }

    void OnVulnerable()
    {
        playerData.isInvulnerable=false;
        Debug.Log("SHIELD DEACTIVE");
        EventManager.Broadcast(GameEvent.OnBuffDeactive);
    }

    void OnSpeedNormal()
    {
        Debug.Log("SPEED NORMAL");
        thirdPersonController.SprintSpeed=10;
        EventManager.Broadcast(GameEvent.OnBuffDeactive);
    }

    void OnPassNotThroughDoors()
    {
        Debug.Log("NOT PASS THROUGH DOORS");
        EventManager.Broadcast(GameEvent.OnBuffDeactive);
    }

    void OnTimeContinue()
    {
        Debug.Log("TIME IS CONTINUE");
        EventManager.Broadcast(GameEvent.OnBuffDeactive);
        gameData.stopEnemies=false;
    }

    
    
}
