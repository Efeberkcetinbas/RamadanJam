using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameEvent
{
    //Buffs
    OnSwordActive,
    OnSwordDeactive,
    OnInvulnerable,
    OnVulnerable,
    OnSpeedUp,
    OnSpeedNormal,
    OnPassThroughDoors,
    OnNotPasThroughDoors,
    OnTimeStop,
    OnTimeContinue,
    OnBuffDeactive,
    OnBuffActive,

    //Game
    OnDeath,
    OnUpdateUI,
    OnCallDice,
    
    //Doors
    OnDoorOpen,
    OnDoorClose
}
public class EventManager
{
   private static Dictionary<GameEvent,Action> eventTable = new Dictionary<GameEvent, Action>();
    
    private static Dictionary<GameEvent,Action<int>> IdEventTable=new Dictionary<GameEvent, Action<int>>();
    //2 parametre baglayacagimiz ile bagladigimiz

    
    public static void AddHandler(GameEvent gameEvent,Action action)
    {
        if(!eventTable.ContainsKey(gameEvent))
            eventTable[gameEvent]=action;
        else eventTable[gameEvent]+=action;
    }

    public static void RemoveHandler(GameEvent gameEvent,Action action)
    {
        if(eventTable[gameEvent]!=null)
            eventTable[gameEvent]-=action;
        if(eventTable[gameEvent]==null)
            eventTable.Remove(gameEvent);
    }

    public static void Broadcast(GameEvent gameEvent)
    {
        if(eventTable[gameEvent]!=null)
            eventTable[gameEvent]();
    }


    public static void AddIdHandler(GameEvent gameIdEvent,Action<int> actionId)
    {
        if(!IdEventTable.ContainsKey(gameIdEvent))
            IdEventTable[gameIdEvent]=actionId;
        else IdEventTable[gameIdEvent]+=actionId;
    }

    public static void RemoveIdHandler(GameEvent gameIdEvent,Action<int> actionId)
    {
        if(IdEventTable[gameIdEvent]!=null)
            IdEventTable[gameIdEvent]-=actionId;
        if(IdEventTable[gameIdEvent]==null)
            IdEventTable.Remove(gameIdEvent);
    }

    public static void BroadcastId(GameEvent gameIdEvent,int id)
    {
        if(IdEventTable[gameIdEvent]!=null)
            IdEventTable[gameIdEvent](id);
    }
}
