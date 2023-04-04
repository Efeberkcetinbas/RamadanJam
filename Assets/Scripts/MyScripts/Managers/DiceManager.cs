using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public GameData gameData;

    private int index;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnCallDice,MakeRandomDice);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnCallDice,MakeRandomDice);
    }

    private void MakeRandomDice()
    {
        index=Random.Range(0,5);
        EventManager.Broadcast(GameEvent.OnBuffActive);
        switch(index)
        {
            case 0:
                OnStopTime();
                break;
            case 1:
                OnSwordActive();
                break;
            case 2:
                OnSpeedUp();
                break;
            case 3:
                OnPassThroughDoors();
                break;
            case 4:
                OnInvulnerable();
                break;
            
        }
    }
    
    void OnStopTime()
    {
        EventManager.Broadcast(GameEvent.OnTimeStop);
        StartCoroutine(CancelBuff(5,GameEvent.OnTimeContinue));
    }
    void OnSwordActive()
    {
        EventManager.Broadcast(GameEvent.OnSwordActive);
        StartCoroutine(CancelBuff(5,GameEvent.OnSwordDeactive));
    }

    void OnSpeedUp()
    {
        EventManager.Broadcast(GameEvent.OnSpeedUp);
        StartCoroutine(CancelBuff(5,GameEvent.OnSpeedNormal));
    }

    void OnPassThroughDoors()
    {
        EventManager.Broadcast(GameEvent.OnPassThroughDoors);
        StartCoroutine(CancelBuff(5,GameEvent.OnNotPasThroughDoors));
    }

    void OnInvulnerable()
    {
        EventManager.Broadcast(GameEvent.OnInvulnerable);
        StartCoroutine(CancelBuff(5,GameEvent.OnVulnerable));
    }

    private IEnumerator CancelBuff(float time,GameEvent gameEvent)
    {
        yield return new WaitForSeconds(time);
        EventManager.Broadcast(gameEvent);
    }

}
